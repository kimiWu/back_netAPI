using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YXP.API.SMS
{
    public class SMSAppProvider
    {
        private static SMSAppInfo defaultApp;
        /// <summary>
        /// 默认短信平台App
        /// </summary>
        public static SMSAppInfo DefaultApp
        {
            get
            {
                if (defaultApp == null)
                {
                    defaultApp = new SMSAppInfo(AppSettings.SMSDefaultAppId, AppSettings.SMSDefaultKey, AppSettings.SMSDefaultCode);
                }
                return defaultApp;
            }
        }

        private static SMSAppInfo askApp;
        /// <summary>
        /// 询价短信平台App
        /// </summary>
        public static SMSAppInfo AskApp
        {
            get
            {
                if (askApp == null)
                {
                    askApp = new SMSAppInfo(AppSettings.SMSAskAppId, AppSettings.SMSAskKey, AppSettings.SMSAskCode);
                }
                return askApp;
            }
        }

    }
}