using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.TranstarAuction;
using YXP.API.Utility;

namespace YXP.API.DataAccess.TranstarAuction
{
	public partial class AuctionTransferAddressDAL : BaseDAL<AuctionTransferAddress>
	{
        private static string logPath = System.Configuration.ConfigurationManager.AppSettings["logPath"];

        LogWriter log = new LogWriter(System.Configuration.ConfigurationManager.AppSettings["logPath"].ToString());
		public AuctionTransferAddressDAL()
		 : base(ConnEnum.TranstarAuctionConfigPath)
		{
		}
        public IEnumerable<AuctionTransferAddress> GetList(string cityId)
        {
            if (string.IsNullOrEmpty(cityId))
            {
                return null;
            }
            string strSql= string.Format("select * from  AuctionTransferAddress with(nolock) where Remark=1 and  BelongCityId={0} ", cityId);
            
            try
            {
                var list = Query<AuctionTransferAddress>(strSql);
                return list;
            }
            catch (Exception ex)
            {
                log.Write("AuctionTransferAddressDAL中GetList发生异常：" + ex.Message);
                return null;
            }
        }
	}
}

