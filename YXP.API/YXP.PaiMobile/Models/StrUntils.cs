using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YXP.PaiMobile.Models
{
    public class StrUntils
    {
        /// <summary>
        /// 根据秒获取小时分钟秒
        /// </summary>
        /// <param name="second"></param>
        /// <returns></returns>
        public static string GetTimeStr(object second)
        {
            if (second != null)
            {
                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(second));
                return ts.Hours + "小时" + ts.Seconds + "分" + ts.Seconds + "秒";
            }
            else
            {
                return "00小时00分00秒";
            }



        }

        /// <summary>
        /// 获取手机序列号
        /// </summary>
        /// <returns></returns>
        public static string GetDeviceModel()
        {
            return "";
        }
        /// <summary>
        /// 获取唯一码
        /// </summary>
        /// <returns></returns>
        public static string GetUniqueSerialNumber()
        {
            return "";
        }


        /// <summary>
        /// 返回deciaml，保留2位小数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ConvertToDecimal(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return 0.00M;
            }
            return Math.Round(Convert.ToDecimal(obj.ToString()), 2);
        }
    }
}