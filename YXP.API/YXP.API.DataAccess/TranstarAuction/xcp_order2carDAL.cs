using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.TranstarAuction;
using YXP.API.Utility;

namespace YXP.API.DataAccess.TranstarAuction
{
	public partial class xcp_order2carDAL : BaseDAL<xcp_order2car>
    {
        private static string logPath = System.Configuration.ConfigurationManager.AppSettings["logPath"];

        LogWriter log = new LogWriter(System.Configuration.ConfigurationManager.AppSettings["logPath"].ToString());
		public xcp_order2carDAL()
		 : base(ConnEnum.TranstarAuctionConfigPath)
		{
		}
        public int GetCount(int? xo_id, int receive_type)
        {
            var sqlStr = new StringBuilder();
            sqlStr.AppendLine(" select  count(*)as number ");
            sqlStr.AppendLine("  from  xcp_order2car with(nolock) ");
            sqlStr.AppendLine(" group by xo_id,receive_type "); ;
            sqlStr.AppendLine(string.Format(" having receive_type={0} and xo_id={1} ", receive_type, xo_id));
            try
            {
                return Count(sqlStr.ToString());
            }
            catch (Exception ex)
            {
                log.Write("GetCount发生异常：" + ex.Message);
                return 0;
            }
        }
	}
}

