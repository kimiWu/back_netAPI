using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YXP.API.Business.KPSales;
using YXP.API.Entity.KPSales;
using YXP.API.Utility;
using System.Diagnostics;

namespace YXP.KPSales.Controllers
{
    public class KPSalesController : WebBaseController
    {
        private static string logPath = System.Configuration.ConfigurationManager.AppSettings["logPath"];
        LogWriter log = new LogWriter(logPath);

        private static string apiClearCache = System.Configuration.ConfigurationManager.AppSettings["apiClearCache"];

        public static string ReportViewUrl = System.Configuration.ConfigurationManager.AppSettings["ReportViewUrl"];

        private KPSalesBll bll = new KPSalesBll();

        /// <summary>
        /// 列表首页
        /// </summary>
        /// <param name="id">状态 1：等待成交 2：正在投标 3：成交 4：流拍</param>
        /// <returns></returns>
        public ActionResult Index(int id = 1)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ViewBag.state = id;
            var model = GetList(10, id, "");
            string aa = loginUser.RealName;
            //if (model != null && model.Count > 0)
            //{
            //    CookieHelper.SetCookie(loginUser.UserId + "_maxPublishId", model[0].publishId.ToString(), DateTime.Now.AddHours(1));
            //    CookieHelper.SetCookie(loginUser.UserId + "_minPublishId", model[model.Count - 1].publishId.ToString(), DateTime.Now.AddHours(1));
            //}
            watch.Stop();
            log.WriteLine(DateTime.Now + "  " + loginUser.LoginName + "(" + loginUser.UserId + ")" + " KPSales-Index/" + id + " 执行时间： " + watch.ElapsedMilliseconds);
            return View(model);
        }
        /// <summary>
        /// 下拉刷新
        /// </summary>
        /// <param name="maxId"></param>
        /// <param name="pageSize"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ListData(string type, int pageSize = 10, int state = 1, int max = 0, int min = 0)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var model = GetList(pageSize, state, type, max, min);
            ViewBag.state = state;
            //if (model != null && model.Count > 0)
            //{
            //    if (type == "up")
            //    {
            //        CookieHelper.SetCookie(loginUser.UserId + "_minPublishId", model[model.Count - 1].publishId.ToString(), DateTime.Now.AddHours(1));
            //    }
            //    if (type == "down")
            //    {
            //        CookieHelper.SetCookie(loginUser.UserId + "_maxPublishId", model[0].publishId.ToString(), DateTime.Now.AddHours(1));
            //    }
            //}
            watch.Stop();
            log.WriteLine(DateTime.Now + "  " + loginUser.LoginName + "(" + loginUser.UserId + ")" + " KPSales-ListData 执行时间： " + watch.ElapsedMilliseconds);
            return PartialView("/Views/PartView/ListDataPartView.cshtml", model);
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="maxId"></param>
        /// <param name="pageSize"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public List<KPSalesListEntity> GetList(int pageSize = 10, int state = 1, string type = "", int max = 0, int min = 0)
        {
            try
            {
                var TvaList = GetTvaID();
                string str = String.Join(",", TvaList.ConvertAll<string>(new Converter<int, string>(m => m.ToString())).ToArray());
                if (string.IsNullOrEmpty(str) && state == 2)
                {
                    return null;
                }
                else
                {
                    //var maxPid = 0;

                    //if (!string.IsNullOrEmpty(CookieHelper.GetCookieValue(loginUser.UserId + "_maxPublishId")))
                    //    maxPid = int.Parse(CookieHelper.GetCookieValue(loginUser.UserId + "_maxPublishId"));

                    //var minPid = 0;

                    //if (!string.IsNullOrEmpty(CookieHelper.GetCookieValue(loginUser.UserId + "_minPublishId")))
                    //    minPid = int.Parse(CookieHelper.GetCookieValue(loginUser.UserId + "_minPublishId"));

                    var list = bll.GetList(str, "", pageSize, max, min, state, type, loginUser.UserId) as List<KPSalesListEntity>;
                    return list;
                }
            }
            catch (Exception ex)
            {
                log.WriteLine(DateTime.Now + "  " + loginUser.LoginName + "(" + loginUser.UserId + ")" + " KPSales-GetList 发生异常： " + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public ActionResult Detail(int id, int state)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var model = bll.GetModel(id);
            ViewBag.state = state;
            watch.Stop();
            log.WriteLine(DateTime.Now + "  " + loginUser.LoginName + "(" + loginUser.UserId + ")" + " KPSales-Detail/" + id + " 执行时间： " + watch.ElapsedMilliseconds);
            if (state == 1)
            {
                return View("/Views/Detail/ddcjDetail.cshtml", model);
            }
            else if (state == 2)
            {
                return View("/Views/Detail/zatbDetail.cshtml", model);
            }
            else if (state == 3)
            {
                return View("/Views/Detail/cjDetail.cshtml", model);
            }
            else if (state == 4)
            {
                return View("/Views/Detail/lpDetail.cshtml", model);
            }

            return View();
        }



        public ActionResult ReportDetail(int id,int state)
        {
            var model = bll.GetModel(id);
            ViewBag.state = state;
            return View("/Views/Detail/rpDetail.cshtml",model);
        }


        /// <summary>
        /// 获取车易拍数据
        /// </summary>
        /// <returns></returns>
        public string GetCYPData(string EngineNum)
        {
            return Models.CommonUtils.GetCYPData(EngineNum);
        }

        /// <summary>
        /// 提交报价
        /// </summary>
        /// <param name="PublishID"></param>
        /// <param name="TvaID"></param>
        /// <param name="CurrSalesPrice"></param>
        /// <param name="SWFee"></param>
        /// <returns></returns>
        public JsonResult Commit(string PublishID, string TvaID, string CurrSalesPrice, string SWFee)
        {
            YXP.API.Business.TranstarAuction.SalesTXFundBLL bll = new API.Business.TranstarAuction.SalesTXFundBLL();
            string exInfo = "";
            var result = bll.Commit(long.Parse(PublishID), decimal.Parse(CurrSalesPrice), decimal.Parse(SWFee), loginUser.UserId);
            if (result != null && result[0] != null && result[0].suc == 1)
            {
                try
                {
                    YXP.API.Utility.HtmlHelper help = new API.Utility.HtmlHelper();
                    string sn = MD5(PublishID + "dao123.abc" + DateTime.Now.Minute.ToString());
                    exInfo = string.Format("{0}?pId={1}&tvaid={2}&sn={3}", apiClearCache, PublishID, TvaID, sn);
                    string resultStr = help.Get(string.Format("{0}?pId={1}&tvaid={2}&sn={3}", apiClearCache, PublishID, TvaID, sn));
                    log.WriteLine("缓存清除：" + exInfo);
                }
                catch (Exception ex)
                {
                    log.WriteLine("缓存清除出错：" + ex.ToString() + "exInfo=" + exInfo);

                }
            }
            return Json(result);
        }


        /// <summary>
        /// 申请投资/取消申请投资
        /// </summary>
        /// <param name="PublishID"></param>
        /// <param name="TvaID"></param>
        /// <param name="CurrSalesPrice"></param>
        /// <param name="SWFee"></param>
        /// <param name="CompetitorPrice"></param>
        /// <param name="InvestMaxFee"></param>
        /// <param name="Sgn"></param>
        /// <returns></returns>
        public JsonResult ApplyInvest(string PublishID, string TvaID, string CurrSalesPrice, string SWFee,string CompetitorPrice,string InvestMaxFee,int Sgn)
        {

            var result = bll.ApplyInvest(long.Parse(PublishID), decimal.Parse(CurrSalesPrice), decimal.Parse(SWFee), loginUser.UserId,decimal.Parse(CompetitorPrice),decimal.Parse(InvestMaxFee),Sgn);
            return Json(result);
        }


        /// <summary>
        /// 获取拍品的投资信息
        /// </summary>
        /// <param name="PublishID"></param>
        /// <returns></returns>
        public JsonResult GetInvestData(string PublishID)
        {
            YXP.API.Business.TranstarAuction.InvestPublishHisBLL investbll = new API.Business.TranstarAuction.InvestPublishHisBLL();

            var list = investbll.GetList(string.Format(" PublishId={0} and IsSuccess in (0,1)", PublishID)).ToList();
            if (list.Count > 0)
            {
                if (list.Exists(x=>x.IsSuccess==1))
                {
                    return Json(list.First(x => x.IsSuccess == 1));
                }
                else
                {
                    return Json(list.First(x => x.IsSuccess == 0));
                }
            }
            else
            {
                return Json(null);
            }
            
        }


        public string MD5(string input)
        {
            System.Security.Cryptography.MD5 alg = System.Security.Cryptography.MD5.Create();
            byte[] hashBytes = alg.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(hashBytes).Replace("-", "");
        }

        public ActionResult ClearCityList()
        {
            cityList = new List<API.Entity.TranstarAuction.City>();
            return Content("success");
        }

    }


}