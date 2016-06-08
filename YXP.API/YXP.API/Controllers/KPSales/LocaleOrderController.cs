using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using YXP.API.Business.TranstarAuction;
using YXP.API.Entity;

namespace YXP.API.Controllers.KPSales
{
    public class LocaleOrderController : ApiController
    {
        private xcp_order2carBLL bll = new xcp_order2carBLL();
        // GET: LocaleOrder
        [ApiActionFilter]
        [System.Web.Http.HttpGet]
        public dynamic UpdateCarStatus(int xo2cid, int status)
        {

            if (bll.Update( new { status = status },new { xo2cid = xo2cid }))
                return Json(new { Code = 1, Message = "修改成功" });
            else
                return Json(new { Code = -1, Message = "修改失败" });
        }
    }
}