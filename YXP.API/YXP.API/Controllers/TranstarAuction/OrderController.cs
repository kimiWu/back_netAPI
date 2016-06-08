using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using YXP.API.Business.TranstarAuction;
using YXP.API.Entity;
using YXP.API.Entity.Models.TranstarAuction;
using YXP.API.Entity.TranstarAuction;
using YXP.API.Utility;

namespace YXP.API.Controllers.TranstarAuction
{
    public class OrderController : ApiController
    {
        MobileSessionCacheBLL MCB = new MobileSessionCacheBLL();
        TranstarVendorUserBLL tvuBll = new TranstarVendorUserBLL();
        TranstarVendorConfigBLL tvcBll = new TranstarVendorConfigBLL();
        ADS_OrderBLL orderBll = new ADS_OrderBLL();
        ADS_LogBLL logBll = new ADS_LogBLL();
        AuctionGuaranteeFundBLL agfBll = new AuctionGuaranteeFundBLL();

        private string sessionOut = "您的账号已在其他设备登陆或密码已修改！如非您本人操作，请及时修改密码！";

        // GET api/order
        [HttpPost]
        public ApiResultModel AddOrder([FromBody]OrderDto order)
        {
            ApiResultModel arm = new ApiResultModel();

            try
            {
                if (order == null)
                {
                    arm.Code = -2;
                    arm.Message = "参数为NULL!";
                    return arm;
                }

                if (string.IsNullOrEmpty(order.sessionId))
                {
                    arm.Code = -3;
                    arm.Message = "session为空!";
                    return arm;
                }

                //YXP.API.DataAccess.ef.MobileSessionCache session = MCB.QueryBySessionId(order.sessionId);
                MobileSessionCache session = MCB.QueryBySessionId(order.sessionId);
                //string sessionId = "133x9r9j8w4j5q449070710122";

                //IEnumerable<MobileSessionCache> mscList = MCB.GetList(p => p.SessionID == sessionId, " SID desc ");

                //if (mscList != null && mscList.Count() > 0)
                //{

                //}
                if (session == null)
                {
                    arm.Code = -1;
                    arm.Message = sessionOut;
                    return arm;
                }

                dynamic user = tvuBll.GetUserInfo(session.tvuid.Value);

                if (user == null)
                {
                    arm.Code = -4;
                    arm.Message = "未查找到用户信息!";
                    return arm;
                }



                if (string.IsNullOrWhiteSpace(order.Address))
                {
                    arm.Code = -5;
                    arm.Message = "地址为空!";
                    return arm;
                }

                if (Common.StringTrueLength(order.Address) > 100)
                {
                    arm.Code = -5;
                    arm.Message = "地址最长为100个字符!";
                    return arm;
                }

                if (order.CheckCount <= 0)
                {
                    arm.Code = -6;
                    arm.Message = "测车数量必须大于0!";
                    return arm;
                }
                if (order.CheckCount >= 9999)
                {
                    arm.Code = -6;
                    arm.Message = "测车数量必须小于9999!";
                    return arm;
                }

                if (string.IsNullOrWhiteSpace(order.LinkMan))
                {
                    arm.Code = -7;
                    arm.Message = "联系人不能为空!";
                    return arm;
                }

                if (Common.StringTrueLength(order.LinkMan) > 20)
                {
                    arm.Code = -7;
                    arm.Message = "联系人最长为20个字符!";
                    return arm;
                }
                //List<string> testUser = System.Configuration.ConfigurationManager.AppSettings["testUser"].ToString().Split(',').ToList();
                if (string.IsNullOrWhiteSpace(user.LoginName))
                {
                    arm.Code = -8;
                    arm.Message = "登录名不能为空!";
                    return arm;
                }

                if (!Regex.IsMatch(order.MobileNumber, "^1\\d{10}$"))
                {
                    arm.Code = -9;
                    arm.Message = "手机号格式不正确!";
                    return arm;
                }

                List<string> testUserList = System.Configuration.ConfigurationManager.AppSettings["testUser"].ToString().Split(',').ToList();


                if (testUserList.Contains(user.LoginName) || testUserList.Contains(order.LoginName))
                {
                    order.IsTest = true;
                }
                else
                {
                    order.IsTest = false;
                }
               
                //string orderNum = (session.tvuid.Value + rdNum.ToString()).Substring(0, 7);

                //YXP.API.DataAccess.ef.ADS_Order adsOrder = new YXP.API.DataAccess.ef.ADS_Order();
                ADS_Order adsOrder = new ADS_Order();

                adsOrder.Address = order.Address;
                adsOrder.CheckCount = order.CheckCount;
                adsOrder.CreateTime = DateTime.Now;
                adsOrder.IsTest = order.IsTest;// Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IsTest"].ToString()); //order.IsTest;
                adsOrder.LinkMan = order.LinkMan;
                adsOrder.LoginName = user.LoginName;
                adsOrder.MobileNumber = order.MobileNumber;
                adsOrder.Operator = user.LoginName;
                adsOrder.OperatorType = 1;
                adsOrder.OrderSerial = DateTime.Now.ToString("yyMMdd");// DateTime.Now.ToString("yyMMddHHmm") + (session.tvuid.Value.ToString() + rdNum.ToString()).Substring(0, 6);
                adsOrder.OrderStatus = 1;
                adsOrder.TvaID = session.tvaid.Value;
                adsOrder.VendorFullName = user.VendorFullName;
                adsOrder.UpdateTime = DateTime.Now;
                //adsOrder.DetectionTime = DateTime.Parse("2000/01/01");
                //adsOrder.ArrivalTime = DateTime.Parse("2000/01/01");


                if (orderBll.AddOrder(adsOrder))
                {
                    arm.Code = 1;
                    arm.Message = "下单成功!";
                }
                else
                {
                    arm.Code = -100;
                    arm.Message = "操作失败!";
                }
                return arm;
            }
            catch (Exception ex)
            {
                arm.Code = -500;
                arm.Message = "异常:" + ex.Message;
                if (arm.Message.Contains("请求被中止"))
                {
                    arm.Message = "服务器繁忙，请稍后重试";
                }

                return arm;
            }
        }

        // GET api/order/5
        [HttpGet]
        public ApiResultModel GetListPage([FromUri]OrderPageModel opm)
        {

            ApiResultModel arm = new ApiResultModel();

            try
            {
                if (opm == null)
                {
                    arm.Code = -2;
                    arm.Message = "参数为NULL!";
                    return arm;
                }

                if (string.IsNullOrWhiteSpace(opm.sessionId))
                {
                    arm.Code = -3;
                    arm.Message = "Session为空!";
                    return arm;
                }

                opm.pageIndex = opm.pageIndex - 1;

                // YXP.API.DataAccess.ef.MobileSessionCache session = MCB.QueryBySessionId(opm.sessionId);
                MobileSessionCache session = MCB.QueryBySessionId(opm.sessionId);

                if (session == null)
                {
                    arm.Code = -1;
                    arm.Message = sessionOut;
                    return arm;
                }

                int totalCount = 0;

                IEnumerable<ADS_Order> orderList = orderBll.GetListPage(opm, session.tvaid.Value, out totalCount);
                List<Order> oList = new List<Order>();
                if (orderList != null && totalCount > 0)
                {
                    foreach (var item in orderList)
                    {
                        Order o = new Order();
                        o.Address = item.Address;
                        if (item.Address == null)
                        {
                            o.Address = "";
                        }
                        o.AppraiseName = item.AppraiseName;
                        if (item.AppraiseName == null)
                        {
                            o.AppraiseName = "";
                        }
                        o.AppraisePhone = item.AppraisePhone;
                        if (item.AppraisePhone == null)
                        {
                            o.AppraisePhone = "";
                        }
                        o.AppraiserID = item.AppraiserID;

                        o.CancelTime = GenerateTimeStamp(item.CancelTime);
                        if (item.CancelTime == null)
                        {
                            o.CancelTime = "";
                        }
                        o.CheckCount = item.CheckCount;
                        if (item.CheckCount == null)
                        {
                            o.CheckCount = 0;
                        }
                        o.CompleteTime = GenerateTimeStamp(item.CompleteTime);
                        if (item.CompleteTime == null)
                        {
                            o.CompleteTime = "";
                        }
                        o.CreateTime = GenerateTimeStamp(item.CreateTime);
                        if (item.CreateTime == null)
                        {
                            o.CreateTime = "";
                        }

                        o.DispatchTime = GenerateTimeStamp(item.DispatchTime);
                        if (item.DispatchTime == null)
                        {
                            o.DispatchTime = "";
                        }

                        o.DetectionTime = GenerateTimeStamp(item.DetectionTime);
                        if (item.DetectionTime == null)
                        {
                            o.DetectionTime = "";
                        }

                        o.IsTest = item.IsTest == null ? "" : item.IsTest.ToString();
                        if (item.IsTest == null)
                        {
                            o.IsTest = "";
                        }

                        o.ID = item.ID;

                        o.LinkMan = item.LinkMan;
                        if (item.LinkMan == null)
                        {
                            o.LinkMan = "";
                        }

                        o.LoginName = item.LoginName;
                        if (item.LoginName == null)
                        {
                            o.LoginName = "";
                        }

                        o.MobileNumber = item.MobileNumber;
                        if (item.MobileNumber == null)
                        {
                            o.MobileNumber = "";
                        }

                        o.Operator = item.Operator;
                        if (item.Operator == null)
                        {
                            o.Operator = "";
                        }

                        o.OperatorType = item.OperatorType;
                        if (item.OperatorType == null)
                        {
                            o.OperatorType = 0;
                        }

                        o.OrderSerial = item.OrderSerial;
                        if (item.OrderSerial == null)
                        {
                            o.OrderSerial = "";
                        }
                        o.OrderStatus = item.OrderStatus;
                        if (item.OrderStatus == null)
                        {
                            o.OrderStatus = 1;
                        }
                        o.Remark = item.Remark;
                        if (item.Remark == null)
                        {
                            o.Remark = "";
                        }
                        o.TvaID = item.TvaID;

                        o.UpdateTime = GenerateTimeStamp(item.UpdateTime);
                        if (item.UpdateTime == null)
                        {
                            o.UpdateTime = "";
                        }
                        o.VendorFullName = item.VendorFullName;
                        if (item.VendorFullName == null)
                        {
                            o.VendorFullName = "";
                        }
                        oList.Add(o);
                    }
                }

                var result = new { orderList = oList, totalCount = totalCount };

                arm.Code = 1;
                arm.Data = result;
                arm.Message = "获取成功!";
            }
            catch (Exception ex)
            {
                arm.Code = -500;
                arm.Message = "异常：" + ex.Message;
            }
            return arm;
        }
        private string GenerateTimeStamp(DateTime? dt)
        {
            if (dt == null)
            {
                return "";
            }
            // Default implementation of UNIX time of the current UTC time  
            TimeSpan ts = dt.Value.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        [HttpGet]
        public ApiResultModel GetOrderTrack([FromUri]OrderInfoModel oim)
        {

            ApiResultModel arm = new ApiResultModel();

            try
            {
                if (oim == null)
                {
                    arm.Code = -2;
                    arm.Message = "参数为NULL!";
                    return arm;
                }

                if (string.IsNullOrWhiteSpace(oim.sessionId))
                {
                    arm.Code = -3;
                    arm.Message = "Session为空!";
                    return arm;
                }

                //YXP.API.DataAccess.ef.MobileSessionCache session = MCB.QueryBySessionId(oim.sessionId);
                MobileSessionCache session = MCB.QueryBySessionId(oim.sessionId);

                if (session == null)
                {
                    arm.Code = -1;
                    arm.Message = sessionOut;
                    return arm;
                }

                IEnumerable<dynamic> logList = logBll.GetLogInfo(oim.orderId);

                List<LogInfo> lList = new List<LogInfo>();

                int orderStatus = 0;
                string AppraiseName = "";
                string AppraisePhone = "";
                string DispatchTime = "";
                if (logList != null)
                {
                    dynamic l = logList.FirstOrDefault();
                    //if (l.DispatchTime == null)
                    //{
                    //    DispatchTime = "";
                    //}
                    //else
                    //{
                    //    DispatchTime = GenerateTimeStamp(l.DispatchTime);
                    //}

                    foreach (var item in logList)
                    {
                        LogInfo log = new LogInfo();

                        orderStatus = item.OrderStatus;

                        log.CreateTime = GenerateTimeStamp(item.CreateTime);
                        if (item.CreateTime == null)
                        {
                            log.CreateTime = "";
                        }

                        //log.DispatchTime = GenerateTimeStamp(item.DispatchTime);
                        //if (item.DispatchTime == null)
                        //{
                        //    log.DispatchTime = "";
                        //}

                        log.ID = item.ID;
                        log.OrderID = item.OrderID;
                        log.Remark = item.Remark;
                        log.OperatorType = item.OperatorType;

                        if (log.OperatorType == 6)
                        {
                            if (log.Remark.Contains("预计到达时间"))
                            {
                                //try
                                //{
                                //    DateTime dtArrive = DateTime.Parse(log.Remark.Split('|')[1].Split('：')[1].Replace('-', '/'));
                                //    DispatchTime = GenerateTimeStamp(dtArrive);
                                //}
                                //catch (Exception ex) { }
                                log.Remark = log.Remark.Split('|')[0];
                            }
                        }

                        DateTime? dtArr = item.ArrivalTime;
                        if (dtArr != null)
                        {
                            DispatchTime = GenerateTimeStamp(dtArr);
                        }

                        if (string.IsNullOrWhiteSpace(item.Remark))
                        {
                            log.Remark = "";
                        }
                        if (log.OperatorType == 4)
                        {
                            log.Remark = "订单取消";
                        }
                        log.Remark = log.Remark.Replace("(手机端)", "");
                        log.UserName = item.UserName;
                        if (string.IsNullOrWhiteSpace(item.UserName))
                        {
                            log.UserName = "";
                        }
                        //log.AppraiseName = item.AppraiseName;
                        //if (string.IsNullOrWhiteSpace(item.AppraiseName))
                        //{
                        //    log.AppraiseName = "";
                        //}
                        //log.AppraisePhone = item.AppraisePhone;
                        //if (string.IsNullOrWhiteSpace(item.AppraisePhone))
                        //{
                        //    log.AppraisePhone = "";
                        //}

                        if (orderStatus != 4)
                        {
                            if (!string.IsNullOrWhiteSpace(item.AppraiseName))
                            {
                                AppraiseName = item.AppraiseName;
                            }
                            if (!string.IsNullOrWhiteSpace(item.AppraisePhone))
                            {
                                AppraisePhone = item.AppraisePhone;
                            }
                        }
                        if (!log.Remark.Contains("修改订单"))
                        {
                            lList.Add(log);
                        }
                    }
                }

                var result = new { logList = lList, orderStatus = orderStatus, AppraiseName = AppraiseName, AppraisePhone = AppraisePhone, DispatchTime = DispatchTime };
                arm.Code = 1;
                arm.Data = result;
                arm.Message = "获取成功!";
            }
            catch (Exception ex)
            {
                arm.Code = -500;
                arm.Message = "异常：" + ex.Message;
            }
            return arm;
        }

        [HttpGet]
        public ApiResultModel GetOrderInfo([FromUri]OrderInfoModel oim)
        {

            ApiResultModel arm = new ApiResultModel();

            try
            {

                if (oim == null)
                {
                    arm.Code = -2;
                    arm.Message = "参数为NULL!";
                    return arm;
                }

                if (string.IsNullOrWhiteSpace(oim.sessionId))
                {
                    arm.Code = -3;
                    arm.Message = "Session为空!";
                    return arm;
                }

                MobileSessionCache session = MCB.QueryBySessionId(oim.sessionId);
                // YXP.API.DataAccess.ef.MobileSessionCache session = MCB.QueryBySessionId(oim.sessionId);

                if (session == null)
                {
                    arm.Code = -1;
                    arm.Message = sessionOut;
                    return arm;
                }

                ADS_Order order = orderBll.GetOrderById(oim.orderId);

                Order o = null;

                if (order != null)
                {
                    o = new Order();
                    o.Address = order.Address;
                    if (order.Address == null)
                    {
                        o.Address = "";
                    }
                    o.AppraiseName = order.AppraiseName;
                    if (order.AppraiseName == null)
                    {
                        o.AppraiseName = "";
                    }
                    o.AppraisePhone = order.AppraisePhone;
                    if (order.AppraisePhone == null)
                    {
                        o.AppraisePhone = "";
                    }
                    o.AppraiserID = order.AppraiserID;

                    o.CancelTime = GenerateTimeStamp(order.CancelTime);
                    if (order.CancelTime == null)
                    {
                        o.CancelTime = "";
                    }
                    o.CheckCount = order.CheckCount;
                    if (order.CheckCount == null)
                    {
                        o.CheckCount = 0;
                    }
                    o.CompleteTime = GenerateTimeStamp(order.CompleteTime);
                    if (order.CompleteTime == null)
                    {
                        o.CompleteTime = "";
                    }
                    o.CreateTime = GenerateTimeStamp(order.CreateTime);
                    if (order.CreateTime == null)
                    {
                        o.CreateTime = "";
                    }

                    o.DispatchTime = GenerateTimeStamp(order.DispatchTime);
                    if (order.DispatchTime == null)
                    {
                        o.DispatchTime = "";
                    }

                    o.IsTest = order.IsTest == null ? "" : order.IsTest.ToString();
                    if (order.IsTest == null)
                    {
                        o.IsTest = "";
                    }

                    o.ID = order.ID;

                    o.LinkMan = order.LinkMan;
                    if (order.LinkMan == null)
                    {
                        o.LinkMan = "";
                    }

                    o.LoginName = order.LoginName;
                    if (order.LoginName == null)
                    {
                        o.LoginName = "";
                    }

                    o.MobileNumber = order.MobileNumber;
                    if (order.MobileNumber == null)
                    {
                        o.MobileNumber = "";
                    }

                    o.Operator = order.Operator;
                    if (order.Operator == null)
                    {
                        o.Operator = "";
                    }

                    o.OperatorType = order.OperatorType;
                    if (order.OperatorType == null)
                    {
                        o.OperatorType = 0;
                    }

                    o.OrderSerial = order.OrderSerial;
                    if (order.OrderSerial == null)
                    {
                        o.OrderSerial = "";
                    }
                    o.OrderStatus = order.OrderStatus;
                    if (order.OrderStatus == null)
                    {
                        o.OrderStatus = 1;
                    }
                    o.Remark = order.Remark;
                    if (order.Remark == null)
                    {
                        o.Remark = "";
                    }
                    o.TvaID = order.TvaID;

                    o.UpdateTime = GenerateTimeStamp(order.UpdateTime);
                    if (order.UpdateTime == null)
                    {
                        o.UpdateTime = "";
                    }
                    o.VendorFullName = order.VendorFullName;
                    if (order.VendorFullName == null)
                    {
                        o.VendorFullName = "";
                    }
                }



                arm.Code = 1;
                arm.Data = o;
                arm.Message = "获取成功!";
            }
            catch (Exception ex)
            {
                arm.Code = -500;
                arm.Message = "异常：" + ex.Message;
            }
            return arm;
        }

        [HttpPost]
        public ApiResultModel CancelOrderById([FromBody]OrderInfoModel oim)
        {

            ApiResultModel arm = new ApiResultModel();

            try
            {
                if (oim == null)
                {
                    arm.Code = -2;
                    arm.Message = "参数为NULL!";
                    return arm;
                }

                if (string.IsNullOrWhiteSpace(oim.sessionId))
                {
                    arm.Code = -3;
                    arm.Message = "Session为空!";
                    return arm;
                }

                //YXP.API.DataAccess.ef.MobileSessionCache session = MCB.QueryBySessionId(oim.sessionId);
                MobileSessionCache session = MCB.QueryBySessionId(oim.sessionId);
                if (session == null)
                {
                    arm.Code = -1;
                    arm.Message = sessionOut;
                    return arm;
                }
                if (string.IsNullOrWhiteSpace(oim.LoginName))
                {
                    arm.Code = -10;
                    arm.Message = "LoginName为空!";
                    return arm;
                }

                string msg = "";
                if (orderBll.CancelOrderById(oim.orderId, oim.LoginName, out msg))
                {
                    arm.Code = 1;
                    arm.Data = "";
                    arm.Message = msg;
                }
                else
                {
                    arm.Code = -100;
                    arm.Data = "";
                    arm.Message = msg;
                }

            }
            catch (Exception ex)
            {
                arm.Code = -500;
                arm.Message = "异常：" + ex.Message;
            }
            return arm;
        }

        [HttpGet]
        public ApiResultModel UserCenter([FromUri]OrderInfoModel oim)
        {

            ApiResultModel arm = new ApiResultModel();

            try
            {
                if (oim == null)
                {
                    arm.Code = -2;
                    arm.Message = "参数为NULL!";
                    return arm;
                }

                if (string.IsNullOrWhiteSpace(oim.sessionId))
                {
                    arm.Code = -3;
                    arm.Message = "Session为空!";
                    return arm;
                }

                // YXP.API.DataAccess.ef.MobileSessionCache session = MCB.QueryBySessionId(oim.sessionId);
                MobileSessionCache session = MCB.QueryBySessionId(oim.sessionId);

                if (session == null)
                {
                    arm.Code = -1;
                    arm.Message = sessionOut;
                    return arm;
                }

                TranstarVendorConfig config = tvcBll.GetConfigById(session.tvaid.Value, "AuctionDisableSet");

                if (config == null)
                {
                    arm.Code = -11;
                    arm.Data = "";
                    arm.Message = "卖家级别未找到";
                }

                string companyType = string.Empty;

                if (config != null && config.ConfigValue == "0")
                {
                    companyType = "入门级卖家";
                }
                else
                {
                    companyType = "专业级卖家";
                }

                AuctionGuaranteeFund agf = agfBll.GetFundByTvaId(session.tvaid.Value);

                decimal price = 0;

                if (agf == null)
                {
                    price = 0;
                }
                else
                {
                    price = agf.CurrBalance;
                }

                dynamic user = tvuBll.GetUserInfo(session.tvuid.Value);

                if (user == null)
                {
                    arm.Code = -12;
                    arm.Message = "用户信息获取失败!";
                    return arm;
                }

                var result = new { UserRealName = user.UserFullName, VendorFullName = user.VendorFullName, Cash = price, CompanyType = companyType };

                arm.Code = 1;
                arm.Message = "获取成功!";
                arm.Data = result;

                return arm;

            }
            catch (Exception ex)
            {
                arm.Code = -500;
                arm.Message = "异常：" + ex.Message;
            }
            return arm;
        }

    }
}
