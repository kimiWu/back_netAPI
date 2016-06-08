using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using YXP.API.Business.KPSales;
using YXP.API.Entity;

namespace YXP.API.Controllers.KPSales
{
    public class KPSalesController : ApiController
    {
        private KPSalesBll bll = new KPSalesBll();
        // GET: /KPSales/
        [ApiActionFilter]
        public dynamic GetStatus(int publishId, int auctionStatus)
        {
            return bll.VirtualBidRecordResult(publishId, auctionStatus);    
        }
    }
}