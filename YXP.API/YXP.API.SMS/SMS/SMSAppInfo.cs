using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YXP.API.SMS
{
    public class SMSAppInfo
    {
        public SMSAppInfo(int appId, string appKey, string appCode)
        {
            this.AppId = appId;
            this.AppKey = appKey;
            this.AppCode = appCode;
        }

        public int AppId
        {
            get;
            set;
        }

        public string AppKey
        {
            get;
            set;
        }

        public string AppCode
        {
            get;
            set;
        }
    }
}