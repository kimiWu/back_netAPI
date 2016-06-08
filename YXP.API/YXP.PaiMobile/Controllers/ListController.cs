using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using YXP.API.Utility;
using YXP.PaiMobile.Models;

namespace YXP.PaiMobile.Controllers
{
    public class ListController : BaseController
    {


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetList(int cityId = 0, int lastPublishID = 0, int currentPublishID = 0, int currentPage = 0)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            AuctionListSearchEntity entity = new AuctionListSearchEntity() { CitySearch = new List<int> { cityId }, LastPublishID = lastPublishID, CurrentPublishID = currentPublishID, CurrentPage = currentPage };
            string req = Common.Serialize(entity);
            string url = string.Format("{0}/ChannelData/GetListForWap.ashx?req={1}&sessionID={2}", ApiHost, req, SessionID);
            string html = new YXP.API.Utility.HtmlHelper().Get(url);
            watch.Stop();
            log.WriteLine("GetList执行时间:" + watch.ElapsedMilliseconds + "ms");
            return Content(html, "text/json");
        }
        [OutputCache(Duration = 600, VaryByParam = "*")]
        public ActionResult GetCitys()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            string url = string.Format("{0}/ChannelData/GetCenterCityList.ashx?sessionId={1}", ApiHost, SessionID);
            string html = new YXP.API.Utility.HtmlHelper().Get(url);
            watch.Stop();
            log.WriteLine("GetCitys执行时间:" + watch.ElapsedMilliseconds + "ms");
            return Content(html, "text/json");
        }

        public ActionResult GetCount()
        {
            return View();
        }
        public ActionResult Citys()
        {
            return PartialView("SelectCity");
        }

    }
}
