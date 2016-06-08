//using BitAuto.Ucar.Transtar.Auction.BLL;
//using BitAuto.Ucar.Transtar.Auction.BLL.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.DataAccess.TranstarAuction;
using YXP.API.Entity;
using YXP.API.Entity.TranstarAuction;
//using FE = BitAuto.Ucar.Transtar.Auction.NetTiers.Entities;

namespace YXP.API.Business.TranstarAuction
{
    public sealed class VendorServiceBLL
    {
        public bool CreateVendorAccount(VendorServiceReceiveParam model)
        {
            TranstarVendorUserAccount useraccount = new TranstarVendorUserAccount
            {
                Address = model.Address,
                //CardID = model.ca
                CardPwd = model.CardPwd,
                CarPic = model.CarPic,
                CityID = model.CityId,
                IdentityNum = model.IdentityNum,
                IdentityPic = model.IdentityPic,
                KHHM = model.KHHM,
                KHYH = model.KHYH,
                KHZH = model.KHZH,
                MobilePhoneNumber = model.MobilePhoneNumber,
                Sex = model.Sex,
                UserFullName = model.UserFullName,
                VendorClass = model.VendorClass,
                //TvaID = model.TvaID,
                //TvuID = model.TvuID,
                VendorFullName = model.VendorFullName,
                CWSL = model.CWSL,
                YJCGL = model.YJCGL,
                YJCSL = model.YJCSL,
                RYGM = model.RYGM,
                GSJYCD = model.GSJYCD,
                SGSGC = model.SGSGC,
                ESCJYYW = model.ESCJYYW,
                LoginName = model.LoginName,
                Image1 = model.Dbrqzurl,
                Image2 = model.Wtrqzurl,
                DBR = model.DBR,
                DBRMobilePhone = model.DBRMobilePhone,
                BusinessManager = model.BusinessManager,
                //OperatorID = model.OperatorID,
                BranchBankId = model.BranchBankId
            };

            return false;
        }

        /// <summary>
        /// 通过会员卡id查询账户信息
        /// </summary>

        public TranstarVendorUser GetUserAccountByCardId(string cardId)
        {
            TranstarVendorUserDAL dal = new TranstarVendorUserDAL();
            string strSql = string.Format("select * from TranstarVendorUser where CardID={0}", cardId);
            IEnumerable<TranstarVendorUser> list = dal.Query<TranstarVendorUser>(strSql);
            if (list != null)
                return list.FirstOrDefault();
            else
                return null;
        }
        /// <summary>
        /// 通过公司名称和手机获取经销商用户
        /// </summary>
        /// <param name="vendorfullname"></param>
        /// <param name="mobilePhone"></param>
        /// <returns></returns>
        public TranstarVendorAccount GetUserAccountByVendorMobile(string vendorfullname, string mobilePhone)
        {
            YXP.API.DataAccess.TranstarAuction.TranstarVendorAccountDAL dal = new DataAccess.TranstarAuction.TranstarVendorAccountDAL();
            string strSql = string.Format(" with data_set as(select  a.VendorFullName,a.VendorCode,a.VendorShortName,a.CityID,a.[Address],a.VendorClass,a.ZCLX,a.JYCD,a.CLTFCD,a.JYCLJGFW,a.GXQCLPP,a.CLCSFS,a.SFDK,a.KHYH,a.KHHM,a.KHZH,a.KHDH,a.BusinessManager,a.BusinessPersonal,b.TvaID,b.TvuID,b.LoginName,b.LoginPwd,b.UserFullName,b.TelephoneNumber,b.MobilePhoneNumber,b.Email,b.CreateTime,b.[Status],b.IdentityNum,b.QQ,b.IdentityPic,b.CarPic,b.Birthday,a.IsLiveAuction,a.AccountType,a.SGSGC,a.GSJYCD,a.XYCLCL,a.Sex,a.DBRIdentityNum,a.DBR,a.DBRMobilePhone,a.Image1,a.Image2, c.CardID,c.CardPwd,a.IdentityCard,a.IdentityCardPic FROM  TranstarVendorAccount  a inner join TranstarVendorUser b on a.TvaID=b.TvaID and a.[Status]>=0 and b.[Status]>=0 and b.IsCompanyLinkMan=1 left join TranstarVendorUserCard c on b.tvuid=c.TvuID)select * from data_set where AccountType=1 and UserFullName ='{1}' and MobilePhoneNumber='{0}'", vendorfullname, mobilePhone);
            IEnumerable<TranstarVendorAccount> list = dal.Query<TranstarVendorAccount>(strSql);
            if (list != null)
                return list.FirstOrDefault();
            else
                return null;
        }

        /// <summary>
        /// 查询账户信息
        /// </summary>
        public TranstarVendorUser GetUserAccountByLoginName(string loginName)
        {
            TranstarVendorUserDAL dal = new TranstarVendorUserDAL();
            var condtion = " ";
            if (!string.IsNullOrEmpty(loginName))
                condtion += string.Format(" where  LoginName='{0}' and Status>=0  ", loginName);

            string strSql = string.Format("select * from TranstarVendorUser {0}", condtion);

            IEnumerable<TranstarVendorUser> list = dal.Query<TranstarVendorUser>(strSql);
            if (list != null)
                return list.FirstOrDefault();
            else
                return null;
        }
        /// <summary>
        /// 初始化经销商配置
        /// </summary>
        /// <param name="tvaid"></param>
        /// <param name="tvuId"></param>
        /// <param name="accountType"></param>
        public void InitialVendorConfig(int tvaid, int tvuId, int accountType, int cityId)
        {
            var roleids = new string[] { };
            if (accountType == 1)
            {
                //FE.TranstarVendorConfig Config = TranstarGateway.TranstarVendorConfigProvider.GetVendorConfig(tvaid, TranstarVendorConfigKeyHelper.CanAuctionConfig);
                YXP.API.Entity.TranstarVendorConfig Config = new Business.TranstarAuction.TranstarVendorConfigBLL().GetConfigById(tvaid, YXP.API.Entity.TranstarVendorConfigKeyHelper.CanAuctionConfig);
                if (Config == null)
                {
                    Config = new YXP.API.Entity.TranstarVendorConfig();
                    Config.TvaID = tvaid;
                    Config.ConfigKey = YXP.API.Entity.TranstarVendorConfigKeyHelper.CanAuctionConfig;
                    Config.ConfigValue = "1";//默认可参拍 --edited by lvming 2014-4-1 打包车修改 新建买家会员默认为专业级
                    //Config.ConfigValue = "0";// 现场拍创建的买家 默认入门级
                    Config.UpdateTime = DateTime.Now;
                    Config.CreateTime = DateTime.Now;
                }
                else
                {
                    Config.ConfigValue = "1";//默认可参拍 --edited by lvming 2014-4-1 打包车修改 新建买家会员默认为专业级
                    //Config.ConfigValue = "0";// 现场拍创建的买家 默认入门级
                    Config.UpdateTime = DateTime.Now;
                    Config.CreateTime = DateTime.Now;


                }
                //TranstarGateway.TranstarVendorConfigProvider.Save(Config);
                roleids = AuctionAppSettingBLL.GetYxpBuyerRoleIds();
            }
            try
            {
                //DAL.Account.TranstarVendorUseAccountDAL.Instance.InsertUserRoleIds(tvuId, roleids);
                //DAL.Account.TranstarVendorUseAccountDAL.Instance.InitVendor(tvaid);
            }
            catch (Exception ex)
            {
                //OPGetway.OperationLogProvider.LogErrorMsg(string.Format("tvaid={0}初始化角色或者创建保证金账户失败，失败原因{1},事务已经回滚", tvaid, ex.Message));
            }
        }

        public void FillTranstarVendor(TranstarVendorAccount vendor, TranstarVendorUserAccount userAccount)
        {
            vendor.ZCLX = userAccount.ZCLX;
            vendor.JYCD = userAccount.JYCD;
            vendor.CLTFCD = userAccount.CLTFCD;
            vendor.JYCLJGFW = userAccount.JYCLJGFW;
            vendor.GXQCLPP = userAccount.GXQCLPP;
            vendor.CLCSFS = userAccount.CLCSFS;
            vendor.SFDK = userAccount.SFDK;
            vendor.KHYH = userAccount.KHYH;
            vendor.KHHM = userAccount.KHHM;
            vendor.KHZH = userAccount.KHZH;
            vendor.KHDH = userAccount.KHDH;
            vendor.CWSL = userAccount.CWSL;
            vendor.YJCGL = userAccount.YJCGL;
            vendor.YJCSL = userAccount.YJCSL;
            vendor.RYGM = userAccount.RYGM;
            vendor.ESCJYYW = userAccount.ESCJYYW;
            vendor.SGSGC = userAccount.SGSGC;
            vendor.GSJYCD = userAccount.GSJYCD;
            vendor.XYCLCL = userAccount.XYCLCL;
            vendor.Sex = userAccount.Sex;
            vendor.LastModifyTime = DateTime.Now;
            vendor.Address = userAccount.Address;
            vendor.DBR = userAccount.DBR;
            vendor.DBRIdentityNum = userAccount.DBRIdentityNum;
            vendor.DBRMobilePhone = userAccount.DBRMobilePhone;
            vendor.Image1 = userAccount.Image1;
            vendor.Image2 = userAccount.Image2;
            vendor.BusinessManager = userAccount.BusinessManager;
            vendor.BusinessPersonal = userAccount.BusinessPersonal;//业务人员

            vendor.IdentityCard = userAccount.IdentityNum;
            vendor.IdentityCardPic = userAccount.IdentityPic;
            vendor.company_id = userAccount.company_id;//分公司
            vendor.VendorClassCategory = userAccount.VendorClassCategory;

            vendor.BankAccount = userAccount.BranchBankId;
        }

        private void FillTranstarVendorUser(TranstarVendorUser user, TranstarVendorUserAccount userAccount)
        {
            user.LastModifyTime = DateTime.Now;
            user.Birthday = userAccount.Birthday;
            user.QQ = userAccount.QQ;
            //user.CardID = userAccount.CardID;
            //user.CardPwd = userAccount.CardPwd;
            user.IdentityNum = userAccount.IdentityNum;
            user.IdentityPic = userAccount.IdentityPic;
            user.CarPic = userAccount.CarPic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAccount"></param>
        /// <param name="isPHPCreateBuyer">是否是php创建的买家</param>
        /// <returns></returns>
        public YXP.API.Entity.ApiResult CreateTranstarVendorUserAccount(TranstarVendorUserAccount userAccount, bool isPHPCreateBuyer = false)
        {
            YXP.API.Entity.ApiResult r = new YXP.API.Entity.ApiResult();
            try
            {
                if (!isPHPCreateBuyer)
                {
                    if (string.IsNullOrEmpty(userAccount.CardID) == false && GetUserAccountByCardId(userAccount.CardID) != null)
                    {
                        r.Data = "创建账户失败，该会员卡已经使用";
                        throw new Exception("创建账户失败，该会员卡已经使用");
                    }
                }
                else
                {
                    var vendoruser = GetUserAccountByVendorMobile(userAccount.VendorFullName, userAccount.MobilePhoneNumber);
                    if (vendoruser != null)
                    {
                        r.Status =1;
                        r.Data = vendoruser;
                        return r;
                    }
                    else
                    {
                        var existsuser = GetUserAccountByLoginName(userAccount.MobilePhoneNumber);
                        if (existsuser != null)
                        {
                            r.Status = 1;
                            r.Data = existsuser;
                            return r;
                        }
                    }
                }

                #region 创建经销商
                TranstarVendorAccount vendor = new TranstarVendorAccount();
                FillTranstarVendor(vendor, userAccount);
                vendor.MobilePhoneNumber = userAccount.MobilePhoneNumber;
                vendor.LinkMan = userAccount.UserFullName;
                vendor.CityID = userAccount.CityID;

                //个人
                if (vendor.VendorClass == 1)
                {
                    vendor.VendorClassCategory = 1;
                }
                //专业公司
                else if (vendor.VendorClass == 3)
                {
                    vendor.VendorClassCategory = 2;
                }

                vendor.AccountType = userAccount.AccountType;
                vendor.CircletType = 0;
                vendor.IsLiveAuction = isPHPCreateBuyer ? 2 : 1;
                vendor.IsVirtualBuyer = 0;

                vendor.IsBankAccountVisible = true;
                vendor.CreateTime = DateTime.Now;

                vendor.Status = 1;
                //是否支持在线付款 默认为1（支持）0（不支持）
                vendor.IsOnlinePayEnable = 0;
                vendor.VendorClass = userAccount.VendorClass;  //3：专业公司  1：个人
                vendor.VendorFullName = userAccount.VendorFullName;
                if (string.IsNullOrEmpty(vendor.VendorFullName))
                    vendor.VendorFullName = string.IsNullOrEmpty(userAccount.KHZH) ? userAccount.UserFullName : userAccount.KHZH;
                vendor.VendorShortName = vendor.VendorFullName;

                vendor.ManageType = 1;
                vendor.UseAccountType = 1;

                vendor.CustomVersionNo = "youxinpai";
                vendor.SiID = 1;
                vendor.ChargeType = 1;
                vendor.PostCode = "";
                vendor.SuperiorID = 271;
                vendor.VendorCode = "";
                vendor.LockDaysType = -1;//ww add 20141008
                vendor.BusinessPersonal = userAccount.BusinessPersonal;//业务人员
                var tempLoginName = userAccount.LoginName;
                //if (string.IsNullOrEmpty(tempLoginName))
                //{
                //    r.Data = "创建经销商失败，登录名不能为空";
                //    throw new Exception("创建经销商失败，登录名不能为空！");

                //}
                //if (GetUserAccountByLoginName(tempLoginName) != null)
                //{
                //    r.Data = "创建经销商失败，登录名已经存在！";
                //    throw new Exception("创建经销商失败，登录名已经存在！");
                //}
                ////创建经销商
                //if (!TranstarVendorUseAccountDAL.Instance.CreateTranstarVendorAccount(vendor))
                //{
                //    r.Data = "创建经销商失败";
                //    throw new Exception("创建经销商失败");
                //}

                #endregion

                #region 创建用户
                TranstarVendorUser user = new TranstarVendorUser();
                FillTranstarVendorUser(user, userAccount);
                user.TvaID = vendor.TvaID;
                user.UserFullName = userAccount.UserFullName;
                user.TelephoneNumber = userAccount.TelephoneNumber;
                user.MobilePhoneNumber = userAccount.MobilePhoneNumber;
                user.Email = userAccount.Email;
                user.IsCompanyLinkMan = 1;
                user.LoginName = tempLoginName;
                user.LoginPwd = userAccount.CardPwd;

                user.CreateTime = DateTime.Now;

                user.Status = 1;
                user.SiID = 1;
                user.Level = 1;

                //if (!TranstarVendorUseAccountDAL.Instance.CreateTranstarVendorUser(user))
                //{
                //    r.Data = "创建用户失败";
                //    throw new Exception("创建用户失败");
                //}
                #endregion


                //TranstarVendorModel vendorModel = new TranstarVendorModel();
                //OPGetway.PhpServiceProvider.CopyTo(vendor, ref vendorModel);
                //OPGetway.PhpServiceProvider.CopyTo(user, ref vendorModel);
                //vendorModel.ClientType = 6;
                //YouXinPai.OP.Model.APIService.RetMessage<int[]> result = OPGetway.PhpServiceProvider.CreateTranstarVendorAccountUrlPost(vendorModel);
                //if (result.IsSucceed)
                //{
                //    user.TvaID = result.Data[0];
                //    user.TvuID = result.Data[1];
                //}
                //else
                //{
                //    OPGetway.OperationLogProvider.LogInterfaceMsg(string.Format("现场拍创建经销商{0}，姓名{1}失败，错误原因：{2}", userAccount.VendorFullName, userAccount.UserFullName, result.ErrorMsg));
                //    r.IsSuccess = false;
                //    r.Data = result.ErrorMsg;
                //    return r;
                //}

                /*
                #region 会员卡
                if (!string.IsNullOrEmpty(userAccount.CardID))
                {
                    TranstarVendorUserCard usercard = new TranstarVendorUserCard();
                    usercard.TvuID = user.TvuID;
                    usercard.CardID = userAccount.CardID;
                    usercard.CardPwd = userAccount.CardPwd;
                    usercard.CardType = 1;//1 普卡，2 金卡（积分卡）
                    usercard.OperatorID = userAccount.OperatorID;
                    usercard.CreateTime = DateTime.Now;
                    usercard.UpdateTime = usercard.CreateTime;
                    if (!TranstarVendorUseAccountDAL.Instance.CreateTranstarVendorUserCard(usercard))
                    {
                        r.Data = "创建会员卡失败";
                        throw new Exception("创建会员卡失败");
                    }
                }
                #endregion

                //初始化经销商配置
                InitialVendorConfig(user.TvaID, user.TvuID, vendor.AccountType, vendor.CityID);
                //发送卖家创建成功短信
                if (vendor.AccountType == 2)
                {
                    OPGetway.SendMessageProvider.SendCreateLiveAuctionMobileMsg(user.TvaID, user.TvuID, user.UserFullName, YouXinPai.Utility.EncryptHelper.DesDecrypt(user.CardPwd), user.LoginName, YouXinPai.Utility.EncryptHelper.DesDecrypt(user.LoginPwd), user.MobilePhoneNumber);
                }
                //通知php创建买家成功
                if (vendor.AccountType == 1)
                {
                    try
                    {

                        // bool juge = BitAuto.Ucar.Transtar.Auction.BLL.TranstarGateway.PhpServiceProvider.CreateBuyerSuccessNotice(userAccount.OperatorID, vendor.TvaID, vendor.CityID, 2, 3, vendor.company_id);
                        bool juge = BitAuto.Ucar.Transtar.Auction.BLL.TranstarGateway.PhpServiceProvider.CreateBuyerSuccessNotice(userAccount.OperatorID, vendor.TvaID,
                            //vendor.CityID,
                            2, 3, vendor.company_id, 1);
                        if (juge)
                        {
                            OP.BLL.OPGetway.OperationLogProvider.LogInterfaceMsg("注册送券通知成功！tvaid=" + user.TvaID);
                        }
                        else
                        {
                            OP.BLL.OPGetway.OperationLogProvider.LogInterfaceMsg("注册送券通知失败！tvaid=" + user.TvaID);
                        }
                    }
                    catch (Exception ex)
                    {
                        OP.BLL.OPGetway.OperationLogProvider.LogInterfaceMsg("注册送券通知异常：tvaid=" + user.TvaID + ",ex:" + ex.Message);
                    }
                }
                r.IsSuccess = true;
                if (isPHPCreateBuyer)
                {
                    r.Data = GetUserAccountByTvuId(user.TvuID);
                }
                else
                {
                    r.Data = user.TvuID;
                }

                //通知php创建买家成功 
                //OPGetway.PhpServiceProvider.NoticPHPUrlPost(3, user.TvaID, user.TvuID);
                 */
            }
            catch (Exception ex)
            {
                //if (DAL.TranstarAuctionMapperManager.Instance.LocalSession != null)
                //    DAL.TranstarAuctionMapperManager.Instance.RollBackTransaction();
                //OPGetway.OperationLogProvider.LogInterfaceMsg(string.Format("创建经销商{0}，姓名{1}失败，错误原因：{2}", userAccount.VendorFullName, userAccount.UserFullName, ex.Message));
                //r.IsSuccess = false;
            }
            return r;
        }
    }
}
