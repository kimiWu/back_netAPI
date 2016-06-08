using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YXP.API.Business;
using YXP.API.Business.TranstarAuction;
using YXP.API.Entity;
using YXP.API.Utility;

namespace YXP.API.Controllers.TranstarAuction
{
    public class LoginController : ApiController
    {
        MobileSessionCacheBLL MCB = new MobileSessionCacheBLL();
        TranstarVendorUserBLL BLL = new TranstarVendorUserBLL();
        [HttpGet]
        public ApiResultModel Login([FromUri]LoginRequest request)
        {
            ApiResultModel arm = new ApiResultModel();
            try
            {
                var result = BLL.Login(request, out arm);//"sgm001_admin"

                arm.Data = result;
            }
            catch (Exception ex)
            {
                arm.Code = -500;
                arm.Message = "异常：" + ex.Message;
            }
            return arm;
        }
        [HttpGet]
        public ApiResultModel LogOut(string sessionId)
        {
            ApiResultModel arm = new ApiResultModel();
            try
            {
                if (MCB.DeleteSession(sessionId))
                {
                    arm.Code = 1;
                    arm.Message = "退出成功!";
                }
                else
                {
                    arm.Code = -100;
                    arm.Message = "退出失败!";
                }
                return arm;
            }
            catch (Exception ex)
            {
                arm.Code = -500;
                arm.Message = "异常：" + ex.Message;
            }
            return arm;
        }
        [HttpGet]
        public ApiResultModel CheckVersion()
        {
            ApiResultModel arm = new ApiResultModel();
            try
            {
                string version = System.Configuration.ConfigurationManager.AppSettings["version"].ToString();
                string updateInfo = System.Configuration.ConfigurationManager.AppSettings["updateInfo"].ToString();
                string updateTitle = System.Configuration.ConfigurationManager.AppSettings["updateTitle"].ToString();
                string size = System.Configuration.ConfigurationManager.AppSettings["size"].ToString();

                var result = new { version = version, updateInfo = updateInfo, updateTitle = updateTitle, size = size };

                arm.Code = 1;
                arm.Message = "获取成功!";
                arm.Data = result;

                return arm;
            }
            catch (Exception ex)
            {
                arm.Code = -500;
                arm.Message = "异常：" + ex.Message;
            }
            return arm;
        }

        /// <summary>
        ///获取静态资源 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiResultModel GetStaticResource(string fileName)
        {
            ApiResultModel arm = new ApiResultModel();

            if (string.IsNullOrWhiteSpace(fileName))
            {
                arm.Data = "";
                arm.Code = -1;
                arm.Message = "文件名称不能为空!";
                return arm;
            }
            string filePath = string.Empty;

            arm.Code = 1;
            arm.Message = "请求成功!";

            switch (fileName)
            {
                case "ActiveImg":
                    filePath = System.Configuration.ConfigurationManager.AppSettings["ActiveImg"].ToString(); //Request.RequestUri.Scheme + "://" + Request.RequestUri.Host + ":" + Request.RequestUri.Port + "/Images/ActiveImg.jpg";
                    break;
                case "Condition":
                    filePath = System.Configuration.ConfigurationManager.AppSettings["Condition"].ToString();
                    break;
                default:
                    arm.Code = -1;
                    arm.Message = "文件名称未找到!";
                    break;
            }

            arm.Data = filePath;

            return arm;
        }

    
    }
}
