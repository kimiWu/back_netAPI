using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouXinPai.Common.Data;
using YouXinPai.Common.OP.Data;
using YXP.API.Utility;
using YXP.API.Business.OPFramework;
using YXP.API.Entity.OPFramework;
using System.Web.Security;

namespace YXP.KPSales.Controllers
{
    public class LoginController : Controller
    {
        private DepartmentBLL bll = new DepartmentBLL();
        private static string logPath = System.Configuration.ConfigurationManager.AppSettings["logPath"];
        LogWriter log = new LogWriter(logPath);
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult UserLogin(string loginName, string loginPwd)
        {
            KPSalesResult result = new KPSalesResult();
            try
            {
                string ValidateString = "";

                //var newPwd = EncryptHelper.DESEncrypt(loginPwd);

                int rtn = UserProviderFactory.CreateProvider().CheckPassword(loginName, loginPwd);
                switch (rtn)
                {
                    //-1:用户已删除  0:禁用 1：用户登陆成功 3：用户不存在或者密码不正确
                    case 0:
                        ValidateString = "该用户已禁用，如有问题请联系管理员！";
                        result = new KPSalesResult { Status = -1, Message = ValidateString };
                        return Json(result);
                    case -1:
                        ValidateString = "该用户已删除，如有问题请联系管理员！";
                        result = new KPSalesResult { Status = -1, Message = ValidateString };
                        return Json(result);
                    case 3:
                        ValidateString = "账户名或者密码错误，请重新输入！";
                        result = new KPSalesResult { Status = -1, Message = ValidateString };
                        return Json(result);
                }
                YouXinPai.Common.OP.User loginUser = UserProviderFactory.CreateProvider().GetByLoginName(loginName);
                //loginUser.DeptId
                if (loginUser != null && (loginUser.Roles == null || loginUser.Roles.Count == 0))
                {

                    result = new KPSalesResult { Status = -1, Message = "您还没有分配角色，请联系管理员给您分配角色！" };
                }
                else
                {
                    if (loginUser.Dept != null)
                    {
                        if (loginUser.Dept.DeptType == YouXinPai.Common.Enum.DeptType.卖家业务部门)
                        {
                            result = new KPSalesResult { Status = 1, Message = "登录成功" };
                            SetCookies(loginUser);
                        }
                        else
                        {
                            result = new KPSalesResult { Status = -1, Message = "该用户不具备登录权限，如有问题请联系管理员！" };
                        }
                    }
                    else
                    {
                        result = new KPSalesResult { Status = -1, Message = "您还没有分配部门，请联系管理员给您分配部门！" };
                    }
                }

                String userAgent;
                userAgent = Request.UserAgent ?? "";
                log.WriteLine(DateTime.Now + "  UserId=" + loginUser.UserId + "  UserName=" + loginUser.RealName + "  UserAgent:" + userAgent);
            }
            catch (Exception ex)
            {
                log.WriteLine("Login异常:" + ex.Message);
            }

            return Json(result);
        }



        public ActionResult LogOff()
        {
            //删除Forms身份验证票证
            FormsAuthentication.SignOut();

            //清除Cookie

            HttpCookie cookie;
            int cookieCount = System.Web.HttpContext.Current.Request.Cookies.Count;

            for (int i = 0; i < cookieCount; i++)
            {
                cookie = System.Web.HttpContext.Current.Request.Cookies[i];
                cookie.Expires = DateTime.Now.AddYears(-1);
                System.Web.HttpContext.Current.Response.Cookies.Set(cookie);


            }

            return RedirectToAction("Index", "Login");
        }


        /// <summary>
        /// 设置员工cookie信息
        /// </summary>
        /// <param name="UserModel"></param>
        public void SetCookies(YouXinPai.Common.OP.User loginUser)
        {
            if (loginUser != null)
            {
                HttpCookie loginCookie = new HttpCookie("KPSales_loginUser");
                loginCookie.Values["UserID"] = EncryptHelper.DESEncrypt(loginUser.UserId.ToString());
                loginCookie.Values["LoginName"] = EncryptHelper.DESEncrypt(loginUser.LoginName);
                loginCookie.Values["RealName"] = EncryptHelper.DESEncrypt(loginUser.RealName);
                loginCookie.Expires = DateTime.Now.AddMinutes(600);
                Response.Cookies.Add(loginCookie);
            }
        }


        public class KPSalesResult
        {
            public int Status { get; set; }
            public string Message { get; set; }
        }
    }
}