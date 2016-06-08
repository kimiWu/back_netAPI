using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YXP.API.Utility;

namespace YXP.KPSales.Controllers
{
    public class WebBaseController : Controller
    {
        private static string logPath = System.Configuration.ConfigurationManager.AppSettings["logPath"];
        LogWriter log = new LogWriter(logPath);
        /// <summary>
        /// 当前登录人
        /// </summary>
        public static YouXinPai.Common.OP.User loginUser
        {
            get
            {
                return GetUserFromCookie();
            }
        }


        /// <summary>
        /// 获取当前用户弹性资金池
        /// </summary>
        public static YXP.API.Entity.TranstarAuction.SalesTXFund salesTXFund
        {
            get
            {

                YXP.API.Business.TranstarAuction.SalesTXFundBLL salesTXFundBLL = new YXP.API.Business.TranstarAuction.SalesTXFundBLL();
                return salesTXFundBLL.Get(loginUser.UserId);
            }
        }


        /// <summary>
        /// 获取当前用户所绑定的卖家
        /// </summary>
        /// <returns></returns>
        public List<int> GetTvaID()
        {
            try
            {
                YXP.API.Business.OPFramework.AreaUserRoleMapBLL bll = new API.Business.OPFramework.AreaUserRoleMapBLL();
                var list = bll.GetList(string.Format(" IsActive=1 and userid={0}", loginUser.UserId), " ID asc");
                //var list = bll.GetList(string.Format(" IsActive=1 and userid={0}", 170), " ID asc");
                if (list != null)
                {
                    var newlist = (from item in list
                                   select item.TvaID).ToList();

                    return newlist;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                log.Write("GetTvaID异常：" + ex.Message);
                return null;
            }
        }


        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        public YXP.KPSales.Models.Resources GetResource()
        {
            string str = Server.MapPath("~/");
            str = str + "Resource.xml";
            YXP.KPSales.Models.Resources obj = XmlHelper.XmlDeserializeFromFile<YXP.KPSales.Models.Resources>(str, System.Text.Encoding.UTF8);
            return obj;

        }


        public YXP.KPSales.Models.Resources CheckResource()
        {
            var obj = GetResource();
            YXP.API.Business.OPFramework.AuthorityResourceBLL bll = new API.Business.OPFramework.AuthorityResourceBLL();
            var list = bll.GetList(obj.ID, loginUser.UserId);
            if (list != null)
            {
                foreach (var Code in list)
                {
                    if (obj.ResourceList.Exists(x => x.ID == Code))
                        obj.ResourceList.Find(x => x.ID == Code).Enable = true;
                }
            }
            return obj;
        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);


            //进行校验用户是否登录
            if (Request.Cookies["KPSales_loginUser"] == null)
            {
                //HttpContext.Response.Redirect("/Login/Index");
                filterContext.Result = new RedirectResult("/Login/Index");
                return;
            }

            //进行校验用户是否有权限进行该操作
            var obj = CheckResource();
            if (obj.Enable)
            {
                string CurrentControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                if (CurrentControllerName != "Home" && !obj.ResourceList.Exists(x => x.ControllerName == CurrentControllerName && x.Enable))
                {
                    filterContext.Result = new RedirectResult("/Home/Index");
                    return;
                }

            }
        }


        #region [获取cookie登陆实体]
        private static YouXinPai.Common.OP.User GetUserFromCookie()
        {
            HttpCookie loginCookie = System.Web.HttpContext.Current.Request.Cookies["KPSales_loginUser"];
            YouXinPai.Common.OP.User UserModel = null;
            if (loginCookie != null)
            {

                UserModel = new YouXinPai.Common.OP.User();
                int UserID = 0;
                Int32.TryParse(EncryptHelper.DESDecrypt(loginCookie["UserID"]), out UserID);
                string LoginName = EncryptHelper.DESDecrypt(loginCookie["LoginName"]);
                string RealName = EncryptHelper.DESDecrypt(loginCookie["RealName"]);

                UserModel = new YouXinPai.Common.OP.User();
                UserModel.UserId = UserID;
                UserModel.LoginName = LoginName;
                UserModel.RealName = RealName;

                return UserModel;
            }
            else
            {
                return UserModel;
            }
        }
        #endregion



        public class CommonResult
        {
            public int Status { get; set; }
            public string Message { get; set; }
        }

        private static List<YXP.API.Entity.TranstarAuction.City> _cityList = new List<API.Entity.TranstarAuction.City>();
        public static List<YXP.API.Entity.TranstarAuction.City> cityList
        {
            get
            {
                if (_cityList == null || _cityList.Count == 0)
                {
                    _cityList = Models.CommonUtils.GetAll();
                }
                return _cityList;

            }
            set { _cityList = value; }
        }

    }
}