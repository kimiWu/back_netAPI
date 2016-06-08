using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace YXP.API.SMS
{
    public class AppSettings
    {
        protected static string[] SMSDefaultArr = ConfigurationManager.AppSettings["SMSDefaultApp"].ToString().Split(',');
        protected static string[] SMSAskArr = ConfigurationManager.AppSettings["SMSAskApp"].ToString().Split(',');
        /// <summary>
        /// 默认短信平台应用ID
        /// </summary>
        public static int SMSDefaultAppId
        {
            get { return Convert.ToInt32(SMSDefaultArr[0]); }
        }
        /// <summary>
        /// 默认短信IdentityCode
        /// </summary>
        public static string SMSDefaultCode
        {
            get { return GetAppSettingValue(SMSDefaultArr[1]); }
        }
        /// <summary>
        /// 默认短信校验key
        /// </summary>
        public static string SMSDefaultKey
        {
            get { return GetAppSettingValue(SMSDefaultArr[2]); }
        }

   

        /// <summary>
        /// 询价短信平台应用ID
        /// </summary>
        public static int SMSAskAppId
        {
            get { return Convert.ToInt32(SMSAskArr[0]); }
        }
        /// <summary>
        /// 询价短信IdentityCode
        /// </summary>
        public static string SMSAskCode
        {
            get { return GetAppSettingValue(SMSAskArr[1]); }
        }
        /// <summary>
        /// 询价短信校验key
        /// </summary>
        public static string SMSAskKey
        {
            get { return GetAppSettingValue(SMSAskArr[2]); }
        }



        /// <summary>
        /// 询价短信上行接受号码
        /// </summary>
        public static string SMSReMobile
        {
            get { return GetAppSettingValue("SMSReMobile"); }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string SMSUcarSignName
        {
            get { return GetAppSettingValue("SMSUcarSignName"); }
        }

        public static string GetAppSettingValue(string key )
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch
            {
                
                return string.Empty;
            }
        }
        
        
    }
}