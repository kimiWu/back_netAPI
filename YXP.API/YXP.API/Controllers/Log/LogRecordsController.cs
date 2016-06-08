using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using YXP.API.Business.Log;
using YXP.API.Entity;
using YXP.API.Entity.Models;
using YXP.API.Utility;

namespace YXP.API.Controllers.ApiLog
{
    public class LogRecordsController : ApiController
    {
        // GET: Log
        public string Get()
        {
            return "hello";
        }

        public IEnumerable<LogRecords> GetList(LogModel model, int pageIndex, int pageSize)
        {
            string where = Common.GetQuerySQL<LogModel>(model);
            IEnumerable<LogRecords> list = new LogRecordsBLL().GetList(where, pageIndex, pageSize);
            return list;
        }
        public int GetCount(LogModel model)
        {
            string where = Common.GetQuerySQL<LogModel>(model);
            int count = new LogRecordsBLL().GetCount(where);
            return count;
        }
        [System.Web.Http.HttpGet]
        public dynamic LogTest()
        {
            YXP.API.Business.TranstarAuction.ADS_LogBLL bll = new Business.TranstarAuction.ADS_LogBLL();
            return bll.Insert();
        }
    }
}