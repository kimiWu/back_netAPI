using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YXP.API.Utility;
using YXP.PaiMobile.Models;
using System.Diagnostics;

namespace YXP.PaiMobile.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        {
            base.NeedAuthorization = false;
        }
  
        //
        // GET: /Home/
        [AllowAnonymous]
        public ActionResult Index()
        {
            // @Html.AntiForgeryToken()
            // [ValidateAntiForgeryToken]  
            log.WriteLine(Common.GetWebClientIP() +" " + DateTime.Now.ToString() + " login");
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login()
        {
            log.WriteLine(DateTime.Now.ToString() + "login");
            Stopwatch watch = new Stopwatch();
            watch.Start();
            TBase ljson = new TBase();
            try
            {
                string LoginName = Request["username"] == null ? "" : Request["username"].ToString();
                string Pwd = Request["password"] == null ? "" : Request["password"].ToString();
                Random rd = new Random();
                string random = rd.Next(10000, 99999).ToString();
                string newPwd = YXP.API.Utility.EncryptHelper.Md5(Pwd.Trim() + random);
                LoginRequest lrequest = new LoginRequest();
                lrequest.UserName = LoginName.Trim();
                lrequest.Password = newPwd;
                lrequest.MobileType = 3;//手机网页登录
                lrequest.RandomNum = random;
                lrequest.DeviceModel = "手机网页";
                string result = new YXP.API.Utility.HtmlHelper().Get(string.Format(ApiHost + "/AuctionBid/login.ashx?req={0}&random={1}", Common.Serialize(lrequest), random));
                if (!string.IsNullOrEmpty(result))
                {
                    BaseResponse response = Common.Deserialize<BaseResponse>(result);
                    if (response != null)
                    {
                        LoginResponse lresponse = Common.Deserialize<LoginResponse>(response.Message);
                        if (response.Result == 0)
                        {
                            if (lresponse.Result == 0)
                            {
                                string json = JsonConvert.SerializeObject(lresponse);
                                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, "UserInfo", DateTime.Now, DateTime.Now.AddDays(30), false, json, "/");
                                string ticketStr = FormsAuthentication.Encrypt(ticket);
                                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketStr);
                                FormsAuthentication.SetAuthCookie("UserInfo", true);
                                Response.Cookies.Add(cookie);
                                Session["UserData"] = lresponse;
                                ljson.Status = 1;
                                ljson.Message = "成功";
                                log.WriteLine("userName:" + lrequest.UserName + " -- login");
                            }
                            else
                            {
                                ljson.Status = lresponse.Result;
                                ljson.Message = lresponse.Message;
                            }
                        }
                        else
                        {
                            ljson.Status = response.Result;
                            ljson.Message = lresponse.Message;
                        }
                    }
                    else
                    {
                        ljson.Status = -1;
                        ljson.Message = "登录失败，请重试";
                    }
                }
            }
            catch (Exception ex)
            {
                ljson.Status = -1;
                ljson.Message = "网络异常，请重试";
                log.WriteLine("手机网页端登录异常，异常信息{0}，{1}" + ex.Message + ex.StackTrace);
                // throw;
            }
            watch.Stop();
            log.WriteLine("login 执行时间:" + watch.ElapsedMilliseconds + "ms");
            return Content(Common.Serialize(ljson), "text/json");
        }

        public ActionResult LogOut()
        {
            //删除Forms身份验证票证
            FormsAuthentication.SignOut();

            //清除Cookie
            HttpCookie cookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null || string.IsNullOrEmpty(cookie.Value))
                return null;

            return RedirectToAction("Index", "Home");
        }

 


    }
}
