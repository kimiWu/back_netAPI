using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YXP.API.Utility;

namespace YXP.PaiMobile.filter
{
    public class WebHandleErrorAttribute : HandleErrorAttribute
    {
        LogWriter log = new LogWriter(System.Configuration.ConfigurationManager.AppSettings["logPath"]);
        /// <summary>
        /// 重写异常处理方法  
        /// </summary>
        /// <param name="filterContext">上下文对象  该类继承于ControllerContext</param>
        public override void OnException(ExceptionContext filterContext)
        {
            log.WriteLine(filterContext.Exception);
        }
    }
}