using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.TranstarAuction;

namespace YXP.API.DataAccess.TranstarAuction
{
    public class AuctionAppSettingDAL : BaseDAL<AuctionAppSetting>
    {
        public AuctionAppSettingDAL()
            : base(ConnEnum.TranstarAuctionConfigPath)
        {

        }


        public string GetAppConfigValue(string key)
        {
            string strSql = string.Format("select * from AuctionAppSetting where key='{0}'", key);
            var m = Query<AuctionAppSetting>(strSql);
            if (m != null)
                return m.FirstOrDefault().Value;
            else
                return string.Empty ;
        }
    }
}
