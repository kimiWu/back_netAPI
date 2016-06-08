using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using YXP.API.DataAccess.TranstarAuction;
using YXP.API.Entity.Models.TranstarAuction;
using YXP.API.Entity.TranstarAuction;
using YXP.API.SMS;
namespace YXP.API.Business.TranstarAuction
{
    public class ADS_OrderBLL
    {



        public bool AddOrder(ADS_Order order)
        {
            ADS_OrderDAL dal = new ADS_OrderDAL();

            ADS_Log log = new ADS_Log();

            log.CreateTime = DateTime.Now;
            log.OperatorType = 1;
            log.Remark = "订单已创建,正在为您分派评估师(手机端)";
            log.UserName = order.Operator;

            if (dal.AddOrder(order, log))
            {
                string msg = string.Format("您的测车订单{0}已创建完成，我们将尽快为您分派评估师，如有问题请联系10101088。", order.OrderSerial);

                long msgNum = MobileMsgService.MsgSend(order.MobileNumber, SMSAppProvider.DefaultApp, msg, MGType.SMS, "创建订单");

                return true;
            }
            return false;
        }

        //public bool AddOrder(YXP.API.DataAccess.ef.ADS_Order order)
        //{
        //    ADS_OrderDAL dal = new ADS_OrderDAL();

        //    YXP.API.DataAccess.ef.ADS_Log log = new YXP.API.DataAccess.ef.ADS_Log();

        //    log.CreateTime = DateTime.Now;
        //    log.OperatorType = 1;
        //    log.Remark = "订单已创建,正在为您分派评估师(手机端)";
        //    log.UserName = order.Operator;

        //    OrderService orderService = new OrderService();

        //    if (orderService.Add(order, log))
        //    {
        //        string msg = string.Format("您的测车订单{0}已创建完成，我们将尽快为您分派评估师，如有问题请联系10101088。", order.OrderSerial);

        //        long msgNum = MobileMsgService.MsgSend(order.MobileNumber, SMSAppProvider.DefaultApp, msg, MGType.SMS, "创建订单");

        //        return true;
        //    }
        //    return false;
        //}

        /// <summary>
        /// 推荐用这种方式书写，这样修改了Entity，引用了entity的Expression的Code处就用自动报错，编译不过去
        /// </summary>
        /// <param name="exp">lambda表达式</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <returns>数据集</returns>
        public IEnumerable<ADS_Order> GetList(Expression<Func<ADS_Order, bool>> exp, string orderBy, int pageIndex, int pageSize)
        {
            ADS_OrderDAL dal = new ADS_OrderDAL();
            return dal.Where(exp, orderBy, pageIndex, pageSize);
        }

        public IEnumerable<ADS_Order> GetListPage(OrderPageModel model, int tvaId, out int totalCount)
        {
            ADS_OrderDAL dal = new ADS_OrderDAL("");
            string sql = @"SELECT ID
                  ,OrderSerial
                  ,LinkMan
                  ,MobileNumber
                  ,Address
                  ,CheckCount
                  ,TvaID
                  ,VendorFullName
                  ,CreateTime
                  ,UpdateTime
                  ,OrderStatus
                  ,AppraiserID
                  ,Operator
                  ,OperatorType
                  ,Remark
                  ,DispatchTime
                  ,LoginName
                  ,CompleteTime
                  ,CancelTime
                  ,AppraiseName
                  ,AppraisePhone
                  ,IsTest
                  ,ArrivalTime
                  ,DetectionTime
              FROM ADS_Order with (nolock)";

            totalCount = dal.Count("select COUNT(1) as Total FROM ADS_Order with (nolock)", "  TvaID=" + tvaId);

            sql += " where TvaID=" + tvaId;

            return dal.Query<ADS_Order>(sql, " ID desc ", model.pageIndex, model.pageSize);
        }

        public ADS_Order GetOrderById(int id)
        {
            ADS_OrderDAL dal = new ADS_OrderDAL("");
            return dal.Get(id);
        }

        public bool CancelOrderById(int id, string userName, out string message)
        {
            ADS_OrderDAL dal = new ADS_OrderDAL("");
            ADS_LogDAL logDal = new ADS_LogDAL();
            TranstarVendorUserDAL tvuDal = new TranstarVendorUserDAL();
            ADS_Order order = dal.Get(id);

            if (order == null)
            {
                message = "订单未找到!";
                return false;
            }
            if (order.OrderStatus == 4)
            {
                message = "订单已取消";
                return false;
            }

            if (order.OrderStatus == 7)
            {
                message = "订单正在进行中，不能取消订单";
                return false;
            }
            if (order.OrderStatus == 3)
            {
                message = "订单已完成，不能取消订单";
                return false;
            }
            order.OrderStatus = 4;
            order.CancelTime = DateTime.Now;

            ADS_Log log = new ADS_Log();

            log.CreateTime = DateTime.Now;
            log.OperatorType = 4;
            log.OrderID = order.ID;
            log.UserName = userName;
            log.Remark = "卖家自行取消订单";

            if (dal.UpdateOrder(order, log))
            {
                string msg = string.Format("您的测车订单{0}已取消，如有问题请联系10101088。", order.OrderSerial);

                if (order.AppraiserID > 0)
                {
                    TranstarVendorUser user = tvuDal.Get(order.AppraiserID);
                    if (user != null)
                    {
                        long msgNum = MobileMsgService.MsgSend(user.MobilePhoneNumber, SMSAppProvider.DefaultApp, msg, MGType.SMS, "取消订单");
                    }
                }
                long msgNum2 = MobileMsgService.MsgSend(/*order.MobileNumber*/"15210328019", SMSAppProvider.DefaultApp, msg, MGType.SMS, "取消订单");
                if (msgNum2 > 0)
                {
                    message = "取消成功!";
                    return true;
                }
                else
                {
                    message = "取消成功,发送短信失败!";
                    return true;
                }

            }
            else
            {
                message = "取消失败!";
                return false;
            }
        }

    }
}
