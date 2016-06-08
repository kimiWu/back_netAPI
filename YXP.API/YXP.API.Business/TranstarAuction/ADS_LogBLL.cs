using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.DataAccess.TranstarAuction;
using YXP.API.Entity;

namespace YXP.API.Business.TranstarAuction
{
    public class ADS_LogBLL
    {
        #region Test Log Write
        public dynamic Insert()
        {
            //ADS_LogDAL dal = new ADS_LogDAL();
            //Entity.TranstarAuction.ADS_Log log = new Entity.TranstarAuction.ADS_Log()
            //{
            //    CreateTime = DateTime.Now,
            //    OperatorType = 1,
            //    OrderID = 9999999,
            //    Remark = "测试写库",
            //    UserName = "测试写库用户"
            //};
            //return dal.Insert(log);
           return Insert2();
        }
        public dynamic Insert2()
        {
            string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["TranstarAuctionConfigPathWrite"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("insert into ADS_Log(UserName,OrderID,OperatorType,CreateTime,Remark) values(@UserName,@OrderID,@OperatorType,@CreateTime,@Remark)", conn);
                cmd.Parameters.Add(new SqlParameter("@UserName", "测试写库用户"));
                cmd.Parameters.Add(new SqlParameter("@CreateTime", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@OperatorType", 1));
                cmd.Parameters.Add(new SqlParameter("@OrderID", 9999999));
                cmd.Parameters.Add(new SqlParameter("@Remark", "测试写库"));
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("写库异常," + connstr + "错误信息：" + ex.Message);
            }
        }

        #endregion

        public IEnumerable<dynamic> GetLogInfo(int orderId)
        {
            ADS_LogDAL dal = new ADS_LogDAL("");
            string sql = @"SELECT  a.ID,a.UserName
                          ,a.OrderID
                          ,a.OperatorType
                          ,a.CreateTime
                          ,a.Remark
                          ,b.DispatchTime,
                          b.OrderStatus,
                          b.AppraiseName,
                          b.AppraisePhone,
                          b.ArrivalTime,
                          b.DetectionTime
                          FROM ADS_Log as a left join ADS_Order as b on a.OrderID=b.ID";
            sql += " where a.OrderID=" + orderId + " and a.LogType=0 order by a.ID asc";
            return dal.Query(sql);
        }
    }
}
