using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity;
using YXP.API.Entity.TranstarAuction;

namespace YXP.API.DataAccess.TranstarAuction
{
    public class ADS_OrderDAL : BaseDAL<ADS_Order>
    {
        public ADS_OrderDAL()
            : base(ConnEnum.TranstarAuctionConfigPath)
        {

        }
        public ADS_OrderDAL(string conn)
            : base(ConnEnum.TranstarAuctionConfigPath, "TranstarAuctionConfigPathWrite")
        {

        }
        public bool AddOrder(ADS_Order order, ADS_Log log)
        {

            var db = GetDB(1);
            try
            {

                db.BeginTransaction();

                //int count = CountOrder("SELECT COUNT(1) FROM ADS_Order WITH(UPDLOCK)  ", string.Format("  OrderSerial='{0}'", order.OrderSerial));

                //if (count > 0)
                //{
                //    order.OrderSerial = OrderSeriealExit();
                //}

                //if (string.IsNullOrEmpty(order.OrderSerial))
                //{
                //    return false;
                //}

                Insert(order);

                Random rd = new Random();

                int rdNum = rd.Next(100000000, 999999999);

                int result = db.Update(string.Format("update ADS_Order set OrderSerial='D{0}' where ID={1}", DateTime.Now.ToString("yyMMdd") + (order.ID.ToString() + rdNum.ToString()).Substring(0,8), order.ID));

                log.OrderID = order.ID;

                db.Insert<ADS_Log>(log);

                db.Commit();


                return true;
            }
            catch (Exception ex)
            {
                db.Rollback();
            }
            finally
            {
                db.Dispose();
            }
            return false;
        }

        public string OrderSeriealExit()
        {
            string OrderSerial = string.Empty;

            for (int i = 0; i < 2; i++)
            {

                Random rd = new Random();

                int rdNum = rd.Next(0, 9);

                OrderSerial = DateTime.Now.ToString("yyMMddHHmmssfff") + rdNum;

                int count = CountOrder("SELECT COUNT(1) FROM ADS_Order  ", string.Format("  OrderSerial='{0}'", OrderSerial));

                if (count == 0)
                {
                    break;
                }

                OrderSerial = "PG";
            }
            return OrderSerial;
        }
        public bool UpdateOrder(ADS_Order order, ADS_Log log)
        {
            var db = GetDB(1);
            try
            {
                IDbTransaction tran = db.BeginTransaction();

                order_d d_order = db.Query<order_d>("SELECT ID ,OrderStatus FROM ADS_Order WHITH(UPDLOCK) where ID=" + order.ID, "ID", 0, 10, null, 1000, false, tran).FirstOrDefault();

                if (d_order != null)
                {
                    if (d_order.OrderStatus != 4)
                    {
                        int result = db.Update(string.Format("update ADS_Order set OrderStatus=4,CancelTime='{0}' where ID={1}", DateTime.Now, order.ID));

                        log.OrderID = order.ID;

                        db.Insert<ADS_Log>(log);

                        db.Commit();

                        return true;
                    }
                }

                return false;

            }
            catch (Exception ex)
            {
                db.Rollback();
            }
            finally
            {
                db.Dispose();
            }
            return false;
        }
    }
    public class order_d
    {
        public int ID { get; set; }
        public int OrderStatus { get; set; }
    }
}
