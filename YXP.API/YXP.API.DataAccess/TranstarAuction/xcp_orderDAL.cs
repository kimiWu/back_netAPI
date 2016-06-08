using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.TranstarAuction;
using YXP.API.Utility;

namespace YXP.API.DataAccess.TranstarAuction
{
    public partial class xcp_orderDAL : BaseDAL<xcp_order>
    {
        public xcp_orderDAL()
            : base(ConnEnum.TranstarAuctionConfigPath)
        {
        }
        private static string logPath = System.Configuration.ConfigurationManager.AppSettings["logPath"];

        LogWriter log = new LogWriter(System.Configuration.ConfigurationManager.AppSettings["logPath"].ToString());
        public IEnumerable<xcp_order> GetList(string order, int pageSize, int maxId, int minId, string type, int UserId)
        {
            if (string.IsNullOrEmpty(order))
            {
                order = " ID desc";
            }
            var sqlStr = new StringBuilder();
            sqlStr.AppendLine(string.Format("select  top {0} *   from  xcp_order with(nolock) where type=9 and  dealer_id={1}", pageSize, UserId));
            if (!string.IsNullOrEmpty(type))
            {
                if (type == "up" && minId != 0)
                {
                    sqlStr.Append(" and  ID<" + minId);
                }
            }
            sqlStr.AppendLine(" order by " + order);
            //log.Write("sqlStr：" + sqlStr.ToString());
            try
            {
                var list = Query<xcp_order>(sqlStr.ToString());
                return list;
            }
            catch (Exception ex)
            {
                log.Write("xcp_orderDAL中GetList发生异常：" + ex.Message);
                return null;
            }
        }
        public int CreateOrder(xcp_order model)
        {
            return Insert(model);
        }
        public xcp_order GetById(int id)
        {
            string strSQL = string.Format("select  top 1 * ,0 as carselfcount,0 as carsendcount  from  xcp_order with(nolock) where type=9 and  ID={0}", id);


            try
            {
                var model = Query<xcp_order>(strSQL);
                if (model != null && model.Count() > 0)
                {
                    return model.First();
                }
                return null;

            }
            catch (Exception ex)
            {
                log.Write("xcp_orderDAL中GetById发生异常：" + ex.Message);
                return null;
            }
        }

    }
}

