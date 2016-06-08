using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using YXP.API.Utility;
using System.Web.Security;
using YXP.PaiMobile.Models;

namespace YXP.PaiMobile.Controllers
{
    public class BaseController : Controller
    {
        public string ApiHost = ConfigurationManager.AppSettings["ApiHost"];

        public static string logPath = System.Configuration.ConfigurationManager.AppSettings["logPath"];

        public string SocketUrl = ConfigurationManager.AppSettings["socketUrl"];

        public LogWriter log = new LogWriter(logPath);


        public string SessionID
        {
            get
            {
                if (LoginData != null)
                {
                    return LoginData.SessionId;
                }
                else
                {
                    return "";
                }
            }
        }



        public int UserId
        {
            get
            {
                if (LoginData != null)
                {
                    return LoginData.UserId;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int CurrentTvaId
        {
            get
            {
                if (LoginData != null)
                {
                    return LoginData.VendorId;
                }
                else
                {
                    return 0;
                }
            }
        }
        public LoginResponse LoginData
        {
            get
            {
                //HttpCookie cookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                //if (cookie == null || string.IsNullOrEmpty(cookie.Value))
                //    return null;
                //var ticket = FormsAuthentication.Decrypt(cookie.Value);
                var userData = Session["UserData"];
                var response = userData as LoginResponse;
                return response;
            }
        }

        /// <summary>
        /// 验证是否有权限
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (NeedAuthorization)
            {
                if (filterContext == null)
                {
                    throw new ArgumentNullException("httpContext");
                }
                //!filterContext.HttpContext.User.Identity.IsAuthenticated ||
                if (LoginData == null)
                {
                    filterContext.Result = new RedirectResult("~/Home/Index");
                }
            }
        }
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Response.Write(filterContext.Exception.StackTrace);
        }


        private bool _NeedAuthorization = true;

        public bool NeedAuthorization
        {
            get { return _NeedAuthorization; }
            set { _NeedAuthorization = value; }
        }
    }
}
