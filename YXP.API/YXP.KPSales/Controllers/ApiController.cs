using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YXP.API.Business.KPSales;
using YXP.API.Utility;

namespace YXP.KPSales.Controllers
{
    public class ApiController : Controller
    {
        private static string logPath = System.Configuration.ConfigurationManager.AppSettings["logPath"];
        LogWriter log = new LogWriter(logPath);
         
        // GET: /Api/
        public ActionResult GetStatus(int publishId, int auctionStatus, string token)
        {
            KPSalesBll bll = new KPSalesBll();
            try
            {
                string _token = MD5(publishId + "yxp_zjhhl" + DateTime.Now.ToString("yyyy/M/d"));

                log.WriteLine("接口：【GetStatus】 url:publishId=" + publishId + "auctionStatus=" + auctionStatus + "token=" + token);
                var result = bll.ExecVirtualBid(publishId, auctionStatus);

                if (result == 1)
                {
                    return Json(new Test01()
                    {
                        Status = 1,
                        Message = "成功",
                        Data = result
                    }, JsonRequestBehavior.AllowGet);
                }
                else if (result == -2)
                {
                    return Json(new Test01()
                    {
                        Status = -2,
                        Message = "阿波罗未投标",
                        Data = result
                    }, JsonRequestBehavior.AllowGet);
                }
                else if (result == -3)
                {
                    return Json(new Test01()
                    {
                        Status = -3,
                        Message = "用户不是拥有TX资金用户",
                        Data = result
                    }, JsonRequestBehavior.AllowGet);
                }
                else if (result == -4)
                {
                    return Json(new Test01()
                    {
                        Status = -4,
                        Message = "传入拍品状态错误",
                        Data = result
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new Test01()
                    {
                        Status = -1,
                        Message = "异常",
                        Data = -1
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                log.WriteLine("GetStatus异常" + ex.Message);
                throw;
            }
        }


        public ActionResult UpdateCarStatus(int xo2cid, int status, string token)
        {
            YXP.API.Business.TranstarAuction.xcp_order2carBLL bll = new API.Business.TranstarAuction.xcp_order2carBLL();
            try
            {
                //string _token = MD5(xo2cid + "yxp_zjhhl" + DateTime.Now.ToString("yyyy/M/d"));

                log.WriteLine("接口：【UpdateCarStatus】 url:xo2cid=" + xo2cid + "status=" + status + "token=" + token);
                var result = 1;
                //var result = bll.u(publishId, auctionStatus);

                if (result == 1)
                {
                    return Json(new Test01()
                    {
                        Status = 1,
                        Message = "成功",
                        Data = result
                    }, JsonRequestBehavior.AllowGet);
                }
                else if (result == -2)
                {
                    return Json(new Test01()
                    {
                        Status = -2,
                        Message = "阿波罗未投标",
                        Data = result
                    }, JsonRequestBehavior.AllowGet);
                }
                else if (result == -3)
                {
                    return Json(new Test01()
                    {
                        Status = -3,
                        Message = "用户不是拥有TX资金用户",
                        Data = result
                    }, JsonRequestBehavior.AllowGet);
                }
                else if (result == -4)
                {
                    return Json(new Test01()
                    {
                        Status = -4,
                        Message = "传入拍品状态错误",
                        Data = result
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new Test01()
                    {
                        Status = -1,
                        Message = "异常",
                        Data = -1
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                log.WriteLine("GetStatus异常" + ex.Message);
                throw;
            }
        }

        public string MD5(string input)
        {
            System.Security.Cryptography.MD5 alg = System.Security.Cryptography.MD5.Create();
            byte[] hashBytes = alg.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(hashBytes).Replace("-", "");
        }
    }
    public class Test01
    {
        public int Status { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}