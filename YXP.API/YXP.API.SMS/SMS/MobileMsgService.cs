
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace YXP.API.SMS
{
    public class MobileMsgService
    {
        public static Int64 MsgSend(string mobile, SMSAppInfo app, string msgText, MGType mgType, string subject)
        {
            MobileMessaging.MobileMessagingServicesSoapClient mobileMsgService = new MobileMessaging.MobileMessagingServicesSoapClient();
            //MobileMessaging.MobileMessagingServices mobileMsgService = new MobileMessaging.MobileMessagingServices();
            string sign = string.Empty;
            Int64 smsMsgId = 0;
            if (mgType == MGType.SMS)
            {
                msgText += AppSettings.SMSUcarSignName;
                sign = MakeSign(app.AppId, app.AppKey, msgText, mobile);
                smsMsgId = mobileMsgService.SmsSend(app.AppId, msgText, mobile, sign);
              
              
            }




           
            return smsMsgId;
        }


        /// <summary>
        /// 彩信Sign
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="mmsContent"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        private static string MakeSign(int appId, string appKey, string subject, string mmsContent, string destination)
        {
            string computedSign = MD5(string.Format("{0},{1},{2},{3},{4}", appId, appKey, subject, mmsContent, destination));
            return computedSign;
        }

        /// <summary>
        /// 短信Sign
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appKey"></param>
        /// <param name="content"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        private static string MakeSign(int appId, string appKey, string content, string destination)
        {
            string computedSign = MD5(string.Format("{0},{1},{2},{3}", appId, appKey, content, destination));
            return computedSign;
        }

        private static string MD5(string input)
        {
            System.Security.Cryptography.MD5 alg = System.Security.Cryptography.MD5.Create();
            byte[] hashBytes = alg.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(hashBytes).Replace("-", "");
        }

         
    }
}
