using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using YXP.ADS.Entity;
using YXP.ADS.Entity.TranstarAuction;
using YXP.API.DataAccess;
using YXP.API.DataAccess.TranstarAuction;
using YXP.API.Entity;
using YXP.API.Entity.Models.TranstarAuction;
using YXP.API.Entity.TranstarAuction;
using YXP.API.Utility;

namespace YXP.API.Business.TranstarAuction
{
    public class TranstarVendorUserBLL
    {
        //private TranstarVendorUserDAL dal = new TranstarVendorUserDAL();
        //private MobileSessionCacheDAL mscDal = new MobileSessionCacheDAL();
        //private AuctionLoginLogDAL logDal = new AuctionLoginLogDAL();
        public dynamic GetUserInfo(int userId)
        {
            TranstarVendorUserDAL dal = new TranstarVendorUserDAL();
            string sql = "SELECT A.LoginName,B.VendorFullName,A.UserFullName FROM TranstarVendorUser AS A LEFT JOIN TranstarVendorAccount AS B ON A.TvaID=B.TvaID WHERE A.TvuID=" + userId;
            return dal.Query(sql).FirstOrDefault();
        }



        public LoginModel Login(LoginRequest request, out ApiResultModel arm)
        {
            TranstarVendorUserDAL dal = new TranstarVendorUserDAL();
            MobileSessionCacheDAL mscDal = new MobileSessionCacheDAL();
            AuctionLoginLogDAL logDal = new AuctionLoginLogDAL();
            LoginModel lm = new LoginModel();
            arm = new ApiResultModel();

            string sql = string.Format(@"SELECT  a.TvuID
      
            ,a.LoginName
            ,a.LoginPwd
            ,a.UserFullName
            ,a.MobilePhoneNumber,
            b.AccountType,
            b.Address,
            b.CityID,
            a.TvaID,
            b.VendorFullName
            FROM TranstarVendorUser as a left join TranstarVendorAccount as b on a.TvaID=b.TvaID where a.Status=1 and a.LoginName='{0}'", request.UserName);

            lm = dal.Query<LoginModel>(sql).FirstOrDefault();

            if (lm == null)
            {
                arm.Code = -21;
                arm.Message = "帐号不存在";
                return null;
            }

            if (request.RandomNum == null)
            {
                arm.Code = -24;
                arm.Message = "随机数不能为空!";
                return null;
            }
            if (string.IsNullOrWhiteSpace(lm.LoginPwd))
            {
                arm.Code = -24;
                arm.Message = "密码未设置!";
                return null;
            }

            //string enPassword = EncryptHelper.Md5(lm.LoginPwd + request.RandomNum, 32, System.Text.Encoding.UTF8);

            string originalPwd = EncryptHelper.DESDecrypt(lm.LoginPwd);

            //return originalPwd.Equals(password);//测试用，等正式环境用下面加密的
            //new String((originalPwd + random).ToCharArray()).OrderBy<char, char>(c => c).ToArray<char>()
            //string newPwd = EncryptHelper.MD5Encrypt(originalPwd.Trim() + random.Trim());

            //上面加密有问题，修改
            //MD5 md5 = new MD5CryptoServiceProvider();
            //byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(originalPwd.Trim() + request.RandomNum));
            //string newPwd = BitConverter.ToString(bytes).Replace("-", "").ToLower();
            string newPwd = EncryptHelper.Md5(originalPwd.Trim() + request.RandomNum);

            if (newPwd != request.Password)
            {
                arm.Code = -22;
                arm.Message = "密码不正确!";
                return null;
            }
            if (!(lm.AccountType == "2" || lm.AccountType == "3"))
            {
                arm.Code = -23;
                arm.Message = "只有卖家才能登录!";
                return null;
            }

            string SessionId = LoginEncryption.Instance.GetReqEncryptionString(1);
            string userKey = LoginEncryption.Instance.GetUserKey();
            string mobileType = "";
            switch (request.MobileType)
            {
                case 1:
                    mobileType = "Android";
                    break;
                case 2:
                    mobileType = "IOS";
                    break;
                default:
                    mobileType = "Mobile";
                    break;
            }

            MobileSessionCache msc = mscDal.Query<MobileSessionCache>("select * from MobileSessionCache where tvuid=" + lm.TvuID).FirstOrDefault();

            if (msc != null)
            {
                msc.tvaid = lm.TvaID;
                msc.tvuid = lm.TvuID;
                msc.SessionID = SessionId;
                msc.UserKey = userKey;
                msc.PhoneType = mobileType;
                msc.CreateTime = DateTime.Now;
                msc.UpdateTime = DateTime.Now;
                msc.Data = "";
                msc.DeviceModel = request.DeviceModel;
                msc.SourceType = 1;

                mscDal.Update(msc);

            }
            else
            {
                msc = new MobileSessionCache();

                msc.tvaid = lm.TvaID;
                msc.tvuid = lm.TvuID;
                msc.SessionID = SessionId;
                msc.UserKey = userKey;
                msc.PhoneType = mobileType;
                msc.CreateTime = DateTime.Now;
                msc.UpdateTime = DateTime.Now;
                msc.Data = "";
                msc.DeviceModel = request.DeviceModel;
                msc.SourceType = 1;

                mscDal.Insert(msc);
            }

            lm.SessionId = SessionId;

            AuctionLoginLog loginLog = new AuctionLoginLog();

            string ip = "";
            try
            {
                ip = System.Web.HttpContext.Current.Request.UserHostAddress;
            }
            catch (Exception exce)
            {
            }

            loginLog.CreateTime = DateTime.Now;
            loginLog.LoginCity = "";
            loginLog.LoginCount = 1;
            loginLog.LoginIP = ip;
            loginLog.LoginName = request.UserName;
            loginLog.LoginSource = "webApi";
            loginLog.LogType = "login";
            loginLog.OSVersion = request.Version;
            loginLog.PriLoginTime = DateTime.Now;
            loginLog.SIMCardInfo = "";
            loginLog.TvaID = lm.TvaID;
            loginLog.TvuID = lm.TvuID;
            loginLog.WindowWH = request.WindowWH;

            int result = logDal.Insert(loginLog);


            arm.Code = 1;
            arm.Message = "登陆成功!";
            return lm;
        }

        /// <summary>
        /// 身份验证，用户原始密码和随机数拼接，转成char数组，升序排列，MD5加密
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="password">客户端加密后的密码</param>
        /// <param name="random">客户端加密使用的随机数</param>
        /// <returns>密码是否一致</returns>
        public static bool CheckUserPassword(TranstarVendorUser user, string password, string random)
        {
            if (user == null)
                return false;
            string originalPwd = EncryptHelper.DESDecrypt(user.LoginPwd);

            //return originalPwd.Equals(password);//测试用，等正式环境用下面加密的
            //new String((originalPwd + random).ToCharArray()).OrderBy<char, char>(c => c).ToArray<char>()
            //string newPwd = EncryptHelper.MD5Encrypt(originalPwd.Trim() + random.Trim());

            //上面加密有问题，修改
            //MD5 md5 = new MD5CryptoServiceProvider();
            //byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(originalPwd.Trim() + random.Trim()));
            //string newPwd = BitConverter.ToString(bytes).Replace("-", "").ToLower();

            string newPwd = EncryptHelper.Md5(originalPwd.Trim() + random.Trim());

            //_Log.Debug(string.Format("接收参数：/{0}/,/{1}/，密码：/{2}/，加密：/{3}/", password, random, originalPwd, newPwd));
            return newPwd.Equals(password);
        }
    }
}
