using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using YXP.API.Business.TranstarAuction;
using YXP.API.Entity;
using YXP.API.Entity.TranstarAuction;

namespace YXP.API.Controllers.TranstarAuction
{
    public class TradeManageController : ApiController
    {
        private TradeManageBll bll = new TradeManageBll();
        [System.Web.Http.HttpPost]
        [ApiActionFilter]
        public TradeManageEntity GetList([FromBody]TradeManage obj)
        {
            var pageSize = 10;
            var currPage = 1;
            var masterBrandId = "";
            var serialId = "";
            var registDate = "";
            if (obj != null) {
                pageSize = obj.pageSize;
                currPage = obj.currPage;
                masterBrandId = obj.masterBrandId;
                serialId = obj.serialId;
                registDate = obj.registDate;
            }

            var where = "1=1";
            var item = new TradeManageEntity();

            //交易成功

            if (!string.IsNullOrEmpty(masterBrandId))
            {
                where += string.Format(" and t2.MasterBrandId='{0}' ", masterBrandId);
                where = where.Replace(",)", ")");
            }

            if (!string.IsNullOrEmpty(serialId))
            {
                where += string.Format(" and t2.BrandId='{0}' ", serialId);
                where = where.Replace(",)", ")");
            }

            if (!string.IsNullOrEmpty(registDate))
            {
                where += string.Format(" AND DATEPART(YEAR,t2.GetLicenseDate)='{0}' ", registDate);
            }

            string orderBy = "CarsourceId desc";

            item = bll.GetList(where, orderBy, pageSize, currPage);

            return item;
        }
    }

    public class TradeManage : TBase
    {
        public int pageSize { get; set; }
        public int currPage { get; set; }

        public string masterBrandId { get; set; }

        public string serialId { get; set; }

        public string registDate { get; set; }


    }

}