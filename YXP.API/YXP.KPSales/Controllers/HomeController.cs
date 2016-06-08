using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YXP.KPSales.Controllers
{
    public class HomeController : WebBaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            var obj = CheckResource();
            return View(obj);
        }

        public ActionResult Account()
        {
            return View();
        }
    }
}