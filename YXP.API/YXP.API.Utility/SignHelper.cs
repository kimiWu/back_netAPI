
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.Enum;

namespace YXP.API.Utility
{
    public static class SignHelper
    {
        public const string PlatformId = "platformId";
        public const string Token = "token";
        public const string Sign = "sign";
        public static string passCode = System.Configuration.ConfigurationManager.AppSettings["passCode"];

        ///// <summary>  
        ///// 获取防篡改签名，组织原始字符串的方式为：先get后post，该签名要求Tracker在加密时为全小写，同时该方法隐含要求tracker和sign必须通过QueryString方式传递  
        ///// </summary>  
        ///// <param name="getCollection">通过QueryString方式传递的键值集合,如果内部包含tracker或者sign，相关字段在组织原始字符串时将会被移除</param>  
        ///// <param name="Tracker">合作账号</param>  
        ///// <param name="trackerKey">合作Key</param>  
        ///// <param name="postCollection">通过Form方式传递的键值集合，如果包含tracker或者sign，此部分不会被做特殊处理</param>  
        ///// <returns></returns>  
        //public static string GetSecuritySign(this NameValueCollection getCollection, string trackId, string pmsId, string hotelId, NameValueCollection postCollection = null)
        //{
        //    if (string.IsNullOrWhiteSpace(trackId) || string.IsNullOrWhiteSpace(pmsId))
        //    {
        //        throw new ArgumentNullException();
        //    }
        //    var dic = SignHelper.GetDictionary(getCollection,
        //        (k) =>
        //        {
        //            return string.Equals(k, SignHelper.Track, StringComparison.OrdinalIgnoreCase) || string.Equals(k, SignHelper.Sign, StringComparison.OrdinalIgnoreCase);
        //        });
        //    dic.Add(SignHelper.Track, trackId);
        //    StringBuilder tmp = new StringBuilder();
        //    SignHelper.FillStringBuilder(tmp, dic);
        //    dic = SignHelper.GetDictionary(postCollection);
        //    SignHelper.FillStringBuilder(tmp, dic);
        //    tmp.Append(pmsId);
        //    tmp.Remove(0, 1);
        //    return EncryptHelper.Md5(tmp.ToString());
        //}
        //private static Dictionary<string, string> GetDictionary(NameValueCollection collection, Func<string, bool> filter = null)
        //{  
        //    Dictionary<string, string> dic = new Dictionary<string, string>();
        //    if (collection != null && collection.Count > 0)
        //    {
        //        foreach (var k in collection.AllKeys)
        //        {
        //            if (filter == null || !filter(k))
        //            {
        //                dic.Add(k, collection[k]);
        //            }
        //        }
        //    }
        //    return dic;
        //}

        //private static void FillStringBuilder(StringBuilder builder, Dictionary<string, string> dic)
        //{
        //    foreach (var kv in dic)
        //    {
        //        builder.Append('&');
        //        builder.Append(kv.Key);
        //        builder.Append('=');
        //        builder.Append(kv.Value);
        //    }  
        //}

        public static bool IsPassVerify(NameValueCollection nvc, Dictionary<string, object> dict)
        {
            bool re = false;
            string pids = GetSign(SignHelper.PlatformId, nvc, dict);

            int platformId = string.IsNullOrEmpty(pids) ? 0 : Convert.ToInt16(pids);
            string token = GetSign(SignHelper.Token, nvc, dict);
            string token2 = "";
            string publishId = GetSign("publishId", nvc, dict);
            switch (platformId)
            {
                case (int)Platform.手机买家APP:
                    token2 = EncryptHelper.Md5(publishId + "yxp" + DateTime.Now.ToString("yyyy/M/d"), 32, System.Text.Encoding.UTF8);
                    re = token2.Equals(token, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(token);
                    break;
                case (int)Platform.测试平台:
                    token2 = passCode;
                    re = token2.Equals(token, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(token);
                    break;
                case (int)Platform.手机卖家APP:
                    token2 = EncryptHelper.Md5(publishId + "yxp_seller", 32, System.Text.Encoding.UTF8);
                    re = token2.Equals(token, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(token);
                    break;
                case (int)Platform.紫金红葫芦:
                    token2 = EncryptHelper.Md5("yxp_zjhhl" + DateTime.Now.ToString("yyyy/M/d"), 32, System.Text.Encoding.UTF8);
                    re = token2.Equals(token, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(token);
                    break;
                case (int)Platform.置换系统:
                    token2 = EncryptHelper.Md5("yxp_zhxt" + DateTime.Now.ToString("yyyy/M/d HH"), 32, System.Text.Encoding.UTF8);
                    re = token2.Equals(token, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(token);
                    break;
                case (int)Platform.查客车源同步:
                    token2 = EncryptHelper.Md5(publishId + "chaKeCarSyncToYxp", 32, System.Text.Encoding.UTF8);
                    re = token2.Equals(token, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(token);
                    break;
            }
            return re;
        }

        private static string GetSign(string key, NameValueCollection nvc, Dictionary<string, object> dict)
        {
            string val = "";

            if (nvc.Count > 0)
            {
                if (nvc[key] != null)
                {
                    val = nvc[key];
                    return val;
                }

            }
            if (dict.Count > 0)
            {
                foreach (var item in dict.Values)
                {
                    if (item != null)
                    {
                        var type = item.GetType();
                        var pi = type.GetProperty(key);
                        if (pi != null)
                        {
                            val = pi.GetValue(item).ToString();
                            return val;
                        }
                    }
                }
            }
            return val;
        }



    }
}
