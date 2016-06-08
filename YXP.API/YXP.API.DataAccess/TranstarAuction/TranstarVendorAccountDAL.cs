using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity;
using YXP.API.Entity.TranstarAuction;
using YXP.API.Utility;

namespace YXP.API.DataAccess.TranstarAuction
{
    public class TranstarVendorAccountDAL: BaseDAL<TranstarVendorAccount>
    {
        private static string logPath = System.Configuration.ConfigurationManager.AppSettings["logPath"];

        LogWriter log = new LogWriter(System.Configuration.ConfigurationManager.AppSettings["logPath"].ToString());
        public TranstarVendorAccountDAL()
            : base(ConnEnum.TranstarAuctionConfigPath)
        { 
            
        }
        public IEnumerable<TranstarVendorAccount> GetList(string order, int pageSize, int maxId, int minId, string type, string vendorFullName)
        {
            if (string.IsNullOrEmpty(order))
            {
                order = " TvaID desc ";
            }
            var sqlStr = new StringBuilder();
            sqlStr.AppendLine(string.Format("select  top {0} a.TvaID,a.VendorFullName,a.Address,b.UserFullName as LinkMan,b.MobilePhoneNumber  from TranstarVendorAccount a with(nolock) left join TranstarVendorUser b with(nolock) on a.TvaID = b.TvaID where b.IsCompanyLinkMan = 1 and  b.Status=1 and a.VendorFullName like '%{1}%' ", pageSize, vendorFullName));
            if (!string.IsNullOrEmpty(type))
            {
                if (type == "up" && minId != 0)
                {
                    sqlStr.Append("TvaID<" + minId);
                }
            }
            sqlStr.AppendLine(" order by " + order);
            //log.Write("sqlStr：" + sqlStr.ToString());
            try
            {
                var list = Query<TranstarVendorAccount>(sqlStr.ToString());
                return list;
            }
            catch (Exception ex)
            {
                log.Write("TranstarVendorAccountDAL中GetList发生异常：" + ex.Message);
                return null;
            }
        }
    }
}
