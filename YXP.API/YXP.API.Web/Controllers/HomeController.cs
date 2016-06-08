using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YXP.API.Entity;
using YXP.API.Entity.Models;
using YXP.API.Utility;

namespace YXP.API.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public async Task<ActionResult> GetList(LogModel model, int pageIndex, int pageSize)
        {
            string query = string.Format("?platformid=2&pageIndex={0}&pageSize={1}&", pageIndex, pageSize);
            query += Common.GetQueryString(model);
            var list = await HttpClientHelper.GetAsyncObject<dynamic>("apilog", "LogRecords", "GetList", query);
            return Content(Common.Serialize(list), "text/json");

        }
        public async Task<ActionResult> GetCount(LogModel model)
        {
            string query = "?platformid=2&";
            query += Common.GetQueryString(model);
            var count = await HttpClientHelper.GetAsyncString("apilog", "LogRecords", "GetCount", query);
            return Content(count);
        }
        public async Task<ActionResult> GetTest(int id)
        {
            string query = "?platformid=2&id=" + id;

            var count = await HttpClientHelper.GetAsyncString("apilog", "Home", "GetTime", query);
            return Content(count);


        }
    }


}