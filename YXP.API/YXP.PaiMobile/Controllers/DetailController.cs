using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YXP.API.Utility;
using YXP.PaiMobile.Models;

namespace YXP.PaiMobile.Controllers
{
    public class DetailController : BaseController
    {
        private YXP.API.Utility.HtmlHelper client = new API.Utility.HtmlHelper();

        public ActionResult GetSwiper()
        {

            return View("Swiper");
        }
        /// <summary>
        /// 详情页
        /// </summary>
        /// <param name="auctionId">拍品id</param>
        /// <param name="sessionId">签名</param>
        /// <returns></returns>
        public ActionResult Index(int auctionId, int carSourceID)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var model = new AuctionDetailEntity();
            try
            {
                if (string.IsNullOrEmpty((SessionID)))
                {
                    return View("~/Views/Home/Index.cshtml");
                }
                else
                {
                    Stopwatch watch_api = new Stopwatch();
                    watch_api.Start();

                    string result = "";
                    ApiResultEntity obj = null;
                    string postData = "req=" + auctionId + "&sessionID=" + SessionID;
                    result = client.Post(ApiHost + "/ChannelData/GetAuctionDetail.ashx", postData);
                    obj = Common.Deserialize<ApiResultEntity>(result);
                    if (obj.result != 0)
                    {
                        return View("~/Views/List/Index.cshtml");
                    }
                    else
                    {
                        if (Request["sourceFrom"] == "3")
                        {
                            ViewBag.ReportType = 3;
                        }
                        else
                        {
                            ViewBag.ReportType = 2;
                        }

                        watch_api.Stop();
                        log.WriteLine("Detail watch_api 执行时间:" + watch_api.ElapsedMilliseconds + "ms");
                        if (obj != null && obj.result == 0)
                        {
                            model = Common.Deserialize<AuctionDetailEntity>(obj.data);
                            if (StrUntils.ConvertToDecimal(model.TenderHighPrice) <= StrUntils.ConvertToDecimal(model.MyTenderPrice))
                            {
                                ViewBag.IsTenderHighPrice = 1;
                            }
                            else
                            {
                                ViewBag.IsTenderHighPrice = 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.WriteLine("详情页发生异常:req=" + auctionId + "&sessionID=" + SessionID + "  ----error:" + ex.Message);
            }
            ViewBag.DetailModel = model;
            try
            {
                ViewBag.ReportModel = GetReportModel(auctionId, carSourceID, UserId);
            }
            catch (Exception ex)
            {
                log.WriteLine("详情页ReportModel发生异常:auctionId=" + auctionId + "&carSourceID=" + carSourceID + "  ----error:" + ex.Message);
            }

            ViewBag.State = model.State;  //车辆状态
            ViewBag.currTvaId = CurrentTvaId;  //当前用户
            ViewBag.sessionId = SessionID;  //sessionId
            ViewBag.PublishID = auctionId;  //拍品id
            ViewBag.nextPublishId = model.NextPublishID;  //下一个拍品id
            ViewBag.CanAuction = model.CanAuction;  //是否可参拍
            ViewBag.Ishigh = model.Ishigh;  // 是否是最高投标加
            ViewBag.TenderHighPrice = model.TenderHighPrice;  //最高投标加价
            ViewBag.MyPrice = model.MyPrice;   //我的出价
            ViewBag.MyTenderPrice = model.MyTenderPrice; //我的投标价
            ViewBag.IsNoReserve = string.IsNullOrEmpty(model.IsNoReserve) ? "0" : "1";
            ViewBag.StartPrice = model.StartPrice;
            ViewBag.SocketUrl = SocketUrl;

            watch.Stop();
            log.WriteLine("Detail Index 执行时间:" + watch.ElapsedMilliseconds + "ms");
            return View();
        }

        /// <summary>
        /// 获取报告实体对象
        /// </summary>
        /// <param name="auctionId"></param>
        /// <returns></returns>
        private AuctionDetailFor3ReportResponse GetReportModel(int auctionId, int carSourceID, int userId)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var model = new AuctionDetailFor3ReportResponse();
            var req = "{\"carSourceID\" : \"" + carSourceID + "\",\"userId\" : \"" + userId + "\",\"auctionId\" : \"" + auctionId + "\"}";
            try
            {
                var postData = "req=" + req + "&sessionID=" + SessionID;
                var result = client.Post(ApiHost + "/AuctionBid/GetPubInfoFor3Report.ashx", postData);
                var obj = Common.Deserialize<ApiResultEntity>(result);
                if (obj.result == 0)
                {
                    model = Common.Deserialize<AuctionDetailFor3ReportResponse>(obj.data);
                }

            }
            catch (Exception ex)
            {
                log.WriteLine("获取报告实体对象:req=" + req + "&sessionID=" + SessionID + "  ----error:" + ex.Message);
            }

            watch.Stop();
            log.WriteLine("GetReportModel执行时间:" + watch.ElapsedMilliseconds + "ms");
            return model;
        }

      

        /// <summary>
        /// 验证交易约定
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckTender(int auctionId, decimal tenderPrice)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var uniqueSerialNumber = StrUntils.GetUniqueSerialNumber();
            var deviceModel = StrUntils.GetDeviceModel();
            var req = "{\"auctionId\":\"" + auctionId + "\",\"op\":\"tender\",\"tenderPrice\":\"" + tenderPrice + "\",\"userId\":\"" + UserId + "\",\"currTvaId\":\"" + CurrentTvaId + "\",\"uniqueSerialNumber\":\"" + uniqueSerialNumber + "\",\"deviceModel\":\"" + deviceModel + "\"}";
            try
            {
                var postData = "req=" + req + "&sessionID=" + SessionID;
                var result = client.Post(ApiHost + "/AuctionBid/CheckTender.ashx", postData);
                return Json(result);
            }
            catch (Exception ex)
            {
                log.WriteLine("验证交易约定:req=" + req + "&sessionID=" + SessionID + "  ----error:" + ex.Message);
                return Json(null);
            }
            finally
            {
                watch.Stop();
                log.WriteLine("CheckTender执行时间:" + watch.ElapsedMilliseconds + "ms");
            }
        }

        /// <summary>
        /// 投标
        /// </summary>
        /// <returns></returns>
        public ActionResult Tender(int auctionId, decimal tenderPrice)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var uniqueSerialNumber = StrUntils.GetUniqueSerialNumber();
            var deviceModel = StrUntils.GetDeviceModel();
            var req = "{\"auctionId\":\"" + auctionId + "\",\"op\":\"tender\",\"tenderPrice\":\"" + tenderPrice + "\",\"userId\":\"" + UserId + "\",\"currTvaId\":\"" + CurrentTvaId + "\",\"uniqueSerialNumber\":\"" + uniqueSerialNumber + "\",\"deviceModel\":\"" + deviceModel + "\"}";
            try
            {
                var postData = "req=" + req + "&sessionID=" + SessionID;
                var result = client.Post(ApiHost + "/AuctionBid/AuctionTender.ashx", postData);
                return Json(result);
            }
            catch (Exception ex)
            {
                log.WriteLine("投标请求:req=" + req + "&sessionID=" + SessionID + "  ----error:" + ex.Message);
                return Json(null);
            }
            finally
            {
                watch.Stop();
                log.WriteLine("CheckTender执行时间:" + watch.ElapsedMilliseconds + "ms");
            }
        }

        /// <summary>
        /// 计算合手价
        /// </summary>
        /// <returns></returns>
        public ActionResult CalcPrice(int auctionId, string myPrice)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var req = "{\"myPrice\":\"" + myPrice + "\",\"publishId\":\"" + auctionId + "\",\"TvaId\":\"" + CurrentTvaId + "\"}";
            try
            {
                var postData = "req=" + req + "&sessionID=" + SessionID;
                var result = client.Post(ApiHost + "/AuctionBid/AuctionBidCalcPrice.ashx", postData);
                return Json(result);
            }
            catch (Exception ex)
            {
                log.WriteLine("计算合手价:req=" + req + "&sessionID=" + SessionID + "  ----error:" + ex.Message);
                return Json(null);
            }
            finally
            {
                watch.Stop();
                log.WriteLine("CalcPrice执行时间:" + watch.ElapsedMilliseconds + "ms");
            }
        }

        /// <summary>
        /// 竞价
        /// </summary>
        /// <returns></returns>
        public ActionResult BidPrice(int auctionId, decimal currentPrice, decimal pd)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var deviceModel = StrUntils.GetDeviceModel();
            var uniqueSerialNumber = StrUntils.GetUniqueSerialNumber();

            var req = "{\"auctionId\":\"" + auctionId + "\",\"op\":\"auc1\",\"pd\":\"" + pd + "\",\"currentPrice\":\"" + currentPrice + "\",\"bidSourceType\":\"10\",\"uniqueSerialNumber\":\"" + uniqueSerialNumber + "\",\"deviceModel\":\"" + deviceModel + "\"}";
            try
            {
                var postData = "req=" + req + "&sessionID=" + SessionID;
                var result = client.Post(ApiHost + "/AuctionBid/AuctionBidPrice.ashx", postData);
                return Json(result);
            }
            catch (Exception ex)
            {
                log.WriteLine("加价请求:req=" + req + "&sessionID=" + SessionID + "  ----error:" + ex.Message);
                return Json(null);
            }
            finally
            {
                watch.Stop();
                log.WriteLine("BidPrice执行时间:" + watch.ElapsedMilliseconds + "ms");
            }
        }
        /// <summary>
        /// 获取翻牌结果状态数据
        /// </summary>
        /// <param name="publishid"></param>
        /// <returns></returns>
        public ActionResult GetEndStatus(int publishid)
        {
            if (publishid > 0)
            {
                try
                {
                    var postData = "req={\"publishid\":" + publishid + ",\"isonauctioning\":1}&sessionID=" + SessionID;
                    var result = client.Post(ApiHost + "/ChannelData/GetPushDataWithHttp.ashx", postData);
                    return Json(result);
                }
                catch (Exception ex)
                {
                    log.WriteLine("获取翻牌结果异常请求:req=" + publishid + "&sessionID=" + SessionID + "  ----error:" + ex.Message);

                }
            }
            return Json(null);
        }

        /// <summary>
        /// 根据状态分布请求出价区
        /// </summary>
        /// <param name="type"></param>
        /// <param name="auctionId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public ActionResult GetPartView(string type, int auctionId, int state)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var model = new AuctionDetailEntity();
            try
            {
                var postData = "req=" + auctionId + "&sessionID=" + SessionID;
                var result = client.Post(ApiHost + "/ChannelData/GetAuctionDetail.ashx", postData);
                var obj = Common.Deserialize<ApiResultEntity>(result);

                if (obj.result == 0)
                {
                    model = Common.Deserialize<AuctionDetailEntity>(obj.data);
                }

            }
            catch (Exception ex)
            {
                log.WriteLine("根据状态分布请求出价区:req=" + auctionId + "&sessionID=" + SessionID + "  ----error:" + ex.Message);
            }
            ViewBag.DetailModel = model;
            ViewBag.nextPublishId = model.NextPublishID;
            watch.Stop();
            log.WriteLine("GetPartView执行时间:" + watch.ElapsedMilliseconds + "ms");
            if (type == "add")  //go正在竞价
            {
                return PartialView("/Views/PartViews/detail/bidarea/Bidding.cshtml");
            }
            else if (type == "deal" && state == 1) //先go等待成交  5s之后跳转到下一辆车正在竞价 
            {
                return PartialView("/Views/PartViews/detail/bidarea/WaitSale.cshtml");
            }
            else if ((type == "sale" && (state == 3 || state == 4)) || (type == "deal" && (state == 3 || state == 4)))  //先go成交  5s之后跳转到下一辆车正在竞价 
            {
                return PartialView("/Views/PartViews/detail/bidarea/Sale.cshtml");
            }
            else if (type == "stop" || (type == "deal" && state == 2))  //先go流拍  5s之后跳转到下一辆车正在竞价 
            {
                return PartialView("/Views/PartViews/detail/bidarea/Pass.cshtml");
            }
            else
            {
                return View();
            }
        }

        #region 获取Detail report 需要用到的方法，返回值JSON by liunian 2016/05/91
        /// <summary>
        /// 获取报告页
        /// </summary>
        /// <param name="auctionId"></param>
        /// <param name="carSourceID"></param>
        /// <returns>JSON</returns>
        public ActionResult GetCarReportor(int auctionId, int carSourceID)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var model = new AuctionDetailFor3ReportResponse();
            var req = "{\"carSourceID\" : \"" + carSourceID + "\",\"userId\" : \"" + base.UserId + "\",\"auctionId\" : \"" + auctionId + "\"}";
            string result = "";
            try
            {
                var postData = "req=" + req + "&sessionID=" + SessionID;
                result = new YXP.API.Utility.HtmlHelper().Post(ApiHost + "/AuctionBid/GetPubInfoFor3Report.ashx", postData);
            }
            catch (Exception ex)
            {
                log.WriteLine("获取报告实体对象:req=" + req + "&sessionID=" + SessionID + "  ----error:" + ex.Message);
            }
            watch.Stop();
            log.WriteLine("GetCarReportor执行时间:" + watch.ElapsedMilliseconds + "ms");
            return Content(result, "text/json");
        }
        /// <summary>
        /// 车辆详情
        /// </summary>
        /// <param name="auctionId"></param>
        /// <returns></returns>
        public ActionResult GetCarDetail(int auctionId)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            string result = "";
            try
            {
                if (string.IsNullOrEmpty((base.SessionID)))
                {
                    return View("~/Views/Home/Index.cshtml");
                }
                else
                {
                    var postData = "req=" + auctionId + "&sessionID=" + SessionID;
                    result = new YXP.API.Utility.HtmlHelper().Post(ApiHost + "/ChannelData/GetAuctionDetail.ashx", postData);
                }
            }
            catch (Exception ex)
            {
                log.WriteLine("详情页发生异常:req=" + auctionId + "&sessionID=" + SessionID + "  ----error:" + ex.Message);
            }
            watch.Stop();
            log.WriteLine("GetCarDetail执行时间:" + watch.ElapsedMilliseconds + "ms");
            return Content(result, "text/json");
        }

        /// <summary>
        /// 2.0报告
        /// </summary>
        /// <param name="auctionId"></param>
        /// <param name="carSourceID"></param>
        /// <returns></returns>
        public ActionResult GetReportImage(int auctionId, int carSourceID)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            string result = "";
            try
            {
                if (string.IsNullOrEmpty((base.SessionID)))
                {
                    return View("~/Views/Home/Index.cshtml");
                }
                else
                {
                    var req = "{\"carSourceID\" : \"" + carSourceID + "\",\"userId\" : \"" + base.UserId + "\",\"auctionId\" : \"" + auctionId + "\"}";
                    var postData = "req=" + req + "&sessionID=" + base.SessionID;
                    result = new YXP.API.Utility.HtmlHelper().Post(ApiHost + "/AuctionBid/GetPubInfo.ashx", postData);
                }
            }
            catch (Exception ex)
            {
                log.WriteLine("详情页发生异常:req=" + auctionId + "&sessionID=" + base.SessionID + "  ----error:" + ex.Message);
            }
            watch.Stop();
            log.WriteLine("GetReportImage执行时间:" + watch.ElapsedMilliseconds + "ms");
            return Content(result, "text/json");
        }

        #endregion
    }
}
