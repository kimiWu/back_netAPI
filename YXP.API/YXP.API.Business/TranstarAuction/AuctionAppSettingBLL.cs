using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YXP.API.Business.TranstarAuction
{
    public class AuctionAppSettingBLL
    {
        /// <summary>
        /// 优信拍卖家角色ids
        /// </summary>
        private const string YxpBuyerRoleIds = "YxpBuyerRoleIds";

        /// <summary>
        /// 获取优信拍默认买家角色
        /// </summary>
        /// <returns></returns>
        public static string[] GetYxpBuyerRoleIds()
        {
            var v = new YXP.API.DataAccess.TranstarAuction.AuctionAppSettingDAL().GetAppConfigValue(YxpBuyerRoleIds);
            if (string.IsNullOrEmpty(v)) return new string[] { };
            return v.Split('|');
        }
    }
}
