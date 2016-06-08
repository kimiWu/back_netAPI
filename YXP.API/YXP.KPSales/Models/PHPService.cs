using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using YXP.API.Entity.LocaleOrder;
using YXP.API.Entity.TranstarAuction;

namespace YXP.API.Utility
{

    /// <summary>
    /// php或者是auctionservice提供的ashx
    /// </summary>
    public class PHPService
    {


        /// <summary>
        /// 现场下单-------添加委托单url
        /// </summary>
        /// <returns></returns>
        public string GetLocaleOrderAddUrlPost()
        {
            if (ConfigHelper.GetInt32("IsFormalEnvironment") == 0)
                return string.Format("http://padapi.test.youxinpai.com/api/api_xcp/order_create/");
            return string.Format("http://padapi.youxinpai.com/api/api_xcp/order_create/");
        }


        /// <summary>
        /// 现场下单-------撤单委托单url（PHP）
        /// </summary>
        /// <returns></returns>
        public string GetLocaleOrderRemoveUrlPost()
        {
            if (ConfigHelper.GetInt32("IsFormalEnvironment") == 0)
                return string.Format("http://padapi.test.youxinpai.com/api/api_xcp/cancle_car/");
            return string.Format("http://padapi.youxinpai.com/api/api_xcp/cancle_car/");
        }


        /// <summary>
        /// 现场下单-------现场下单后撤销车辆扣除保证金url(auctionservice服务中)
        /// </summary>
        /// <returns></returns>
        public string GetLocaleOrderRemoveAbateAmountUrlPost()
        {
            if (ConfigHelper.GetInt32("IsFormalEnvironment") == 0)
                return string.Format("http://192.168.200.43:8090/CentralizedPayment.ashx");
            return string.Format("http://auctionservice.youxinpai.com/CentralizedPayment.ashx");
        }

        /// <summary>
        /// 获取业务经理所有场地
        /// </summary>
        /// <returns></returns>
        public string GetLocaleOrderFieldUrlPost()
        {
            if (ConfigHelper.GetInt32("IsFormalEnvironment") == 0)
                return string.Format("http://padapi.test.youxinpai.com/api/api_xcp/market_list/");
            return string.Format("http://padapi.youxinpai.com/api/api_xcp/market_list/");
        }


        public string GetLocaleOrderApplypayUrlPost()
        {
            if (ConfigHelper.GetInt32("IsFormalEnvironment") == 0)
                return string.Format("http://padapi.test.youxinpai.com/api/api_activity/wf_applypay");
            return string.Format("http://padapi.youxinpai.com/api/api_activity/wf_applypay");
        }


        /// <summary>
        /// 现场下单--添加（下单）
        /// </summary>
        /// <param name="localeOrderInfo"></param>
        /// <returns></returns>
        public PhpResult LocaleOrderAdd(xcp_order orderInfo, IList<LocaleCarInfo> cars)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            string url = GetLocaleOrderAddUrlPost();
            string pcar = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(cars);

            string sn = MD5Encrypt(string.Format("dealer_id={0}&op_id=800&otype=8{1}", orderInfo.dealer_id, DateTime.Now.ToString("yyyy-MM-dd")), System.Text.Encoding.UTF8);
            string http_parameter = string.Format(@"dealer_id={0}&op_id=800&otype=8&agent_id={1}&remark={2}&car_list={3}&sn={4}",
                orderInfo.dealer_id, orderInfo.master_id, orderInfo.remark, pcar, sn);

            try
            {
                string responseData = PostWebRequest(url, http_parameter, System.Text.Encoding.UTF8);
                stopWatch.Stop();

                if (stopWatch.ElapsedMilliseconds > 500)
                {
                    LogHelper.Warn(url, "post", http_parameter, string.Empty, 0, stopWatch.ElapsedMilliseconds);
                }
                LogHelper.Error(string.Format("{0}\r\n  现场下单--添加：地址:{1},参数：{2},返回数据：{3},耗时：{4}", DateTime.Now.ToString("yyyy-MM-dd mm:hh:ss"), url, http_parameter, responseData, stopWatch.ElapsedMilliseconds));
                return new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<PhpResult>(responseData);
            }
            catch (Exception ex)
            {
                stopWatch.Stop();

                LogHelper.Error(string.Format("{0}\r\n  现场下单--添加：地址:{1},参数：{2},错误提示：{3},耗时：{4}", DateTime.Now.ToString("yyyy-MM-dd mm:hh:ss"), url, http_parameter, ex.Message, stopWatch.ElapsedMilliseconds));
                return new PhpResult
                {
                    code = -10,
                    message = ex.Message,
                    data = ""
                };
            }



        }

        /// <summary>
        /// 现场下单--撤销(通知php撤销车辆)
        /// </summary>
        /// <param name="xo2cid "></param>
        /// <returns></returns>
        public PhpResult LocaleOrderRemove(int xo2cid)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                string url = GetLocaleOrderRemoveUrlPost();
                string key = "nb2GzYCiHfaQzBUZ";
                string http_build_query = string.Format("secret=1&xo2cid={0}{1}{2}", xo2cid, key, DateTime.Now.ToString("yyyy-MM-dd"));
                string sn = MD5Encrypt(http_build_query, System.Text.Encoding.UTF8);
                string requestData = string.Format("secret=1&sn={0}&xo2cid={1}", sn, xo2cid);
                string responseData = PostWebRequest(url, requestData, System.Text.Encoding.UTF8);
                stopWatch.Stop();
                if (stopWatch.ElapsedMilliseconds > 500)
                {
                    LogHelper.Warn(url, "post", requestData, string.Empty, 0, stopWatch.ElapsedMilliseconds);
                }
                LogHelper.Error(string.Format("{0}\r\n  现场下单--撤销：地址:{1},参数：{2},返回数据：{3},耗时：{4}", DateTime.Now.ToString("yyyy-MM-dd mm:hh:ss"), url, requestData, responseData, stopWatch.ElapsedMilliseconds));
                return new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<PhpResult>(responseData); ;
            }
            catch (Exception ex)
            {
                stopWatch.Stop();
                LogHelper.Error(string.Format("{0}\r\n  现场下单--撤销--错误提示：{1},耗时：{2}", DateTime.Now.ToString("yyyy-MM-dd mm:hh:ss"), ex.Message, stopWatch.ElapsedMilliseconds));
                return new PhpResult
                {
                    code = -10,
                    message = ex.Message,
                    data = ""
                };
            }

        }


        /// <summary>
        /// 现场下单--现场下单后撤销车辆+扣除保证金url(auctionservice服务中)
        /// </summary>
        /// <param name="localeOrderInfo"></param>
        /// <returns></returns>
        public Result LocaleOrderRemoveAbateAmount(int id)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string url = GetLocaleOrderRemoveAbateAmountUrlPost();

            string http_parameter = string.Format("id={0}&cmd=ProxyDelegateOrderCancelCarInfo&token={1}", id, MD5Encrypt(id.ToString()));
            try
            {
                string responseData = PostWebRequest(url, http_parameter, System.Text.Encoding.UTF8);
                stopWatch.Stop();
                if (stopWatch.ElapsedMilliseconds > 500)
                {
                    LogHelper.Warn(url, "post", http_parameter, string.Empty, 0, stopWatch.ElapsedMilliseconds);
                }
                LogHelper.Info(string.Format("{0}\r\n  现场下单--撤销：地址:{1},参数：{2},返回数据：{3},耗时：{4}", DateTime.Now.ToString("yyyy-MM-dd mm:hh:ss"), url, http_parameter, responseData, stopWatch.ElapsedMilliseconds));
                return new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Result>(responseData);
            }
            catch (Exception ex)
            {
                stopWatch.Stop();

                LogHelper.Error(string.Format("{0}\r\n  现场下单--撤销：地址:{1},参数：{2},错误提示：{3},耗时：{4}", DateTime.Now.ToString("yyyy-MM-dd mm:hh:ss"), url, http_parameter, ex.Message, stopWatch.ElapsedMilliseconds));
                return new Result
                {
                    IsSuccess = false,
                    Data = ex.Message
                };
            }

        }


        /// <summary>
        /// 获取业务经理所有场地
        /// </summary>
        /// <param name="market_type">场地类型1集中交付场地2现场拍场地</param>
        /// <param name="dtype">是否排除测试场地1否2是 </param>
        /// <returns></returns>
        public PhpResult LocaleOrderField(int market_type, int dtype)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            string url = GetLocaleOrderFieldUrlPost();
            try
            {
                string key = "nb2GzYCiHfaQzBUZ";
                string http_build_query = string.Format("dtype={0}&market_type={1}&secret=1{2}{3}", dtype, market_type, key, DateTime.Now.ToString("yyyy-MM-dd"));
                string sn = MD5Encrypt(http_build_query, System.Text.Encoding.UTF8);
                string requestData = string.Format("dtype={0}&market_type={1}&secret=1&sn={2}", dtype, market_type, sn);
                string responseData = PostWebRequest(url, requestData, System.Text.Encoding.UTF8);
                stopWatch.Stop();

                if (stopWatch.ElapsedMilliseconds > 500)
                {
                    LogHelper.Warn(url, "post", requestData, string.Empty, 0, stopWatch.ElapsedMilliseconds);
                }
                LogHelper.Info(string.Format("{0}\r\n  现场下单--获取业务经理所有场地：地址:{1},返回数据：{2},耗时：{3}", DateTime.Now.ToString("yyyy-MM-dd mm:hh:ss"), url, responseData, stopWatch.ElapsedMilliseconds));
                return new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<PhpResult>(responseData);
            }
            catch (Exception ex)
            {
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;

                LogHelper.Error(string.Format("{0}\r\n  现场下单--获取业务经理所有场地：地址:{1},错误提示：{2},耗时：{3}", DateTime.Now.ToString("yyyy-MM-dd mm:hh:ss"), url, ex.Message, stopWatch.ElapsedMilliseconds));
                return new PhpResult
                {
                    code = false,
                    message = ex.Message,
                    data = null
                };
            }

        }




        /// <summary>
        /// 代理人订单申请付款
        /// </summary>
        /// <param name="publish_bid"></param>
        /// <param name="publish_id"></param>
        /// <returns></returns>
        public PhpResult LocaleOrderApplypay(string publish_bid, int publish_id)
        {
            string url = GetLocaleOrderApplypayUrlPost();

            string strparameter = string.Format("publish_bid={0}&publish_id={1}", publish_bid, publish_id);
            string token = MD5Encrypt(strparameter + "BngkDoReQENEk1QM", System.Text.Encoding.UTF8);
            string http_parameter = strparameter + string.Format("&sn={0}", token);

            try
            {
                string responseData = PostWebRequest(url, http_parameter, System.Text.Encoding.UTF8);
                return new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<PhpResult>(responseData);
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("{0}\r\n  现场下单--添加：地址:{1},参数：{2},错误提示：{3}", DateTime.Now.ToString("yyyy-MM-dd mm:hh:ss"), url, http_parameter, ex.Message));
                return new PhpResult
                {
                    code = "-1",
                    data = ex.Message
                };
            }

        }

        /// <summary>
        /// 申请退车
        /// </summary>
        /// <param name="xo2Cid">现场拍车源ID</param>
        /// <param name="returnTime"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public string UpdateReturnCarStatus(int xo2Cid, int returnType, string reason)
        {
            string _apipath = string.Empty;
            try
            {
                if (xo2Cid <= 0) return "参数错误";

                string api = string.Format("{0}{1}", ConfigHelper.GetStringVlaue("ApiDomainByPhp"), YouXinPai.Mobile.Platform.Model.Common.Constant.ApplyReturnCarApiByPhp);

                // string param = string.Format("&predict_arrive_time={0}", string.Empty);
                //string param = string.Format("&predict_return_time={0}", returnTime.ToString("yyyy-MM-dd HH:mm:ss"));                                           

                string param = string.Empty;
                if (!string.IsNullOrEmpty(reason))
                {
                    param += string.Format("reason={0}&", reason);
                }
                param += string.Format("return_type={0}", returnType);
                param += string.Format("&secret=1");
                param += string.Format("&xcarid={0}", xo2Cid.ToString());

                Stopwatch watch = new Stopwatch();
                watch.Start();

                _apipath = string.Format("{0}{1}", api, string.Format("{0}&sn={1}", param, ApiTokenHelper.GetReturnCarToken(param)));
                string response = WebHttp.WebPostForm(api, string.Format("{0}&sn={1}", param, ApiTokenHelper.GetReturnCarToken(param)));

                watch.Stop();
                if (watch.ElapsedMilliseconds >= 500)
                {
                    LogHelper.Warn(string.Format("{2}?{0}&sn={1}", param, ApiTokenHelper.GetReturnCarToken(param), api), "UpdateReturnCarStatus", "调用php接口申请退车", string.Empty, 0, watch.ElapsedMilliseconds);
                }

                //string response = WebHttp.WebPostForm(api, string.Format("{0}&sn={1}&debug={2}", param, ApiTokenHelper.GetReturnCarToken(param), ConfigHelper.GetStringVlaue("TokenKeyByPhp")));

                LogHelper.Info(string.Format("{0} 调用php申请退车接口地址：{1} \r\n response:{2} ",
                   DateTime.Now
                   , string.Format("{0}{1}&sn={2}", api, param, ApiTokenHelper.GetReturnCarToken(param))
                   , response)
               );

                if (!string.IsNullOrEmpty(response))
                {
                    PhpResult result = JsonHelper.Deserialize<PhpResult>(response);
                    if (Convert.ToInt32(result.code) > 0)
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return result.message.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("-------------------------------------------------------\r\n");
                LogHelper.Error(string.Format("{0} php申请退车接口抛出异常 Request='{4}' ：Message:{2} \r\n StackTrace:{3}  \r\n",
                    DateTime.Now
                    , xo2Cid
                    , ex.Message
                    , ex.StackTrace
                    , _apipath)
                );
                LogHelper.Error("-------------------------------------------------------\r\n");

                return "PHP接口异常";
            }

            return string.Empty;
        }

        /// <summary>
        /// PHP接口，用来添加代理人银行账号 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="returnType"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public PhpResult add_xin_agent_bank(
            int agent_type,
            int agent_id,
            int bank_type,
            int bank_prop,
            string bank_code,
            string bank_name,
            string _branch_bank_name,
            string bank_no,
            string title,
            string mobile,
            string create_person,
            string applicant,
            string remark,
            string sn)
        {
            /*
            agent_type  tinyint  代理人，委托方类型  1代理人，2委托方  是  
            agent_id  int  经销商id  1234  是  
            bank_type  tinyint  账户类型  银行，财付通  是  
            bank_prop  tinyint  账户属性  对公，对私  是  
            bank_code  varchar  银行代码 例如000998800006  是  
            bank_name  vachar 银行名称  中国工商银行  是  
            bank_no string  银行账号  620009988000069  是  
            title varchar  开户人  刘某某  是  
            mobile  varchar 开户人手机  13000000000  是  
            userid int 登录人id 1234 否  
            applicant varchar 提报人 刘某某 否  
            remark varchar 备注信息 备注 否  
            */
            //string url = "http://padapi.test.youxinpai.com/api/api_agent_bank/add_xin_agent_bank/ ";


            //TODO:记录文本日志
            StringBuilder _jsonParamSB = new StringBuilder();

            _jsonParamSB.Append("name={");
            _jsonParamSB.AppendFormat("\"agent_type\":{0},", agent_type);
            _jsonParamSB.AppendFormat("\"agent_id\":{0},", agent_id);
            _jsonParamSB.AppendFormat("\"bank_type\":{0},", bank_type);
            _jsonParamSB.AppendFormat("\"bank_prop\":\"{0}\",", bank_prop);
            _jsonParamSB.AppendFormat("\"bank_code\":\"{0}\",", bank_code);
            _jsonParamSB.AppendFormat("\"bank_name\":\"{0}\",", bank_name);
            _jsonParamSB.AppendFormat("\"bank_name_short\":\"{0}\",", _branch_bank_name);
            _jsonParamSB.AppendFormat("\"bank_no\":\"{0}\",", bank_no);
            _jsonParamSB.AppendFormat("\"title\":\"{0}\",", title);
            _jsonParamSB.AppendFormat("\"mobile\":\"{0}\",", mobile);
            _jsonParamSB.AppendFormat("\"create_person\":\"{0}\",", create_person);
            _jsonParamSB.AppendFormat("\"applicant\":\"{0}\",", applicant);
            _jsonParamSB.AppendFormat("\"remark\":\"{0}\",", remark);
            _jsonParamSB.AppendFormat("\"sn\":\"{0}\"", sn);
            _jsonParamSB.Append("}");

            string php_padapiHost = "http://padapi.test.youxinpai.com";
            if (ConfigHelper.GetInt32("IsFormalEnvironment") == 0)
                php_padapiHost= string.Format("http://padapi.test.youxinpai.com");
            else
                php_padapiHost = string.Format("http://padapi.youxinpai.com");

            // TODO：配置打牌配置文件里节点 ConfigHelper.GetAppSetting["php_padapiHost"];

            string url = string.Format("{0}/api/api_agent_bank/add_xin_agent_bank/", php_padapiHost);

            try
            {
                string rets = WebHttp.WebPostForm(url, _jsonParamSB.ToString());

                PhpResult _ret = JsonConvert.DeserializeObject<PhpResult>(rets);

                LogHelper.Info(string.Format("调用add_xin_agent_bank成功,传入参数为:{0}，调用结果为:{1}", _jsonParamSB.ToString(), rets));

                return _ret;
                //TODO:记日志
            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("调用add_xin_agent_bank出现异常,传入参数为:{0}，异常信息为:{1},异常堆栈:{2}",
                    _jsonParamSB.ToString(), ex.Message, ex.StackTrace));

                //TODO:记日志
                return new PhpResult()
                {
                    code = -1,
                    message = ex.Message
                };
            }


        }

        #region  PHP接口调用相关 基本操作

        /// <summary>
        /// 获取时间的时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public int ConvertDateTimeInt(DateTime dateTime)
        {
            DateTime startTime = new DateTime(1970, 1, 1, 8, 0, 0);
            int timeSpan = (int)(dateTime - startTime).TotalSeconds;
            return timeSpan;
        }

        /// <summary>
        /// 将时间戳转换为时间
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public DateTime ConvertIntDateTime(int timeSpan)
        {
            DateTime startTime = new DateTime(1970, 1, 1, 8, 0, 0);
            DateTime dateTime = startTime.AddSeconds(timeSpan);
            return dateTime;
        }



        /// <summary>
        /// Post发送请求
        /// </summary>
        /// <param name="postUrl"></param>
        /// <param name="paramData"></param>
        /// <param name="dataEncode">使用utf-8</param>
        /// <returns></returns>
        public string PostWebRequest(string url, string paramData, Encoding dataEncode)
        {
            string ret = string.Empty;
            try
            {

                byte[] byteArray = dataEncode.GetBytes(paramData); //转化
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(url));
                webReq.Method = "POST"; //"GET";  psot在url中传递参数是无效果，get可以
                webReq.ContentType = "application/x-www-form-urlencoded";

                webReq.ContentLength = byteArray.Length;
                System.IO.Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), dataEncode);
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();
                LogHelper.Info(string.Format("{0}\r\n php服务访问成功：地址:{1},请求数据：{2},返回数据：{3}", DateTime.Now, url, paramData, ret));
                return ret;

            }
            catch (Exception ex)
            {

                LogHelper.Error(string.Format("{0}\r\n php服务访问错误：地址:{1},请求数据：{2},返回值：{3}", DateTime.Now.ToString("yyyy-MM-dd mm:hh:ss"), url, paramData, ex.Message));
                return string.Empty;
            }

        }


        /// <summary>
        /// Get发送请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetWebRequest(string url, Encoding dataEncode)
        {

            string ret = string.Empty;
            try
            {
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(url));
                webReq.Method = "Get";
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
                LogHelper.Info(string.Format("{0}\r\n php服务访问成功：地址:{1},返回数据：{2}", DateTime.Now, url, ret));
                return ret;

            }
            catch (Exception ex)
            {
                LogHelper.Error(string.Format("{0}\r\n php服务访问错误：地址:{1},错误信息：{2}", DateTime.Now.ToString("yyyy-MM-dd mm:hh:ss"), url, ex.Message));
                return string.Empty;
            }


        }




        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="proclaimedInWriting">加密的字符串</param>
        /// <param name="iEncoding">加密前的字符串编码对象</param>
        /// <returns></returns>
        public string MD5Encrypt(string proclaimedInWriting, System.Text.Encoding iEncoding)
        {
            byte[] bMess = iEncoding.GetBytes(proclaimedInWriting);
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] ecMess = md5.ComputeHash(bMess);
            string newStr = BitConverter.ToString(ecMess).Replace("-", "");
            return newStr.ToLower();

        }

        /// <summary>
        /// MD5加密 Auctionservice使用
        /// </summary>
        /// <param name="originStr"></param>
        public string MD5Encrypt(string originStr)
        {
            string newStr = string.Empty;
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(originStr.Trim() + "yxp" + DateTime.Now.ToString("yyyy/M/d")));
            newStr = BitConverter.ToString(bytes).Replace("-", "");
            return newStr.ToLower();
        }
        #endregion
    }



    /// <summary>
    /// json 结果类
    /// added by jtz 
    /// </summary>
    [Serializable]
    public class Result
    {
        /// <summary>
        /// 初始化 IsSuccess = false;
        /// </summary>
        public Result()
        {
            IsSuccess = false;
            Data = "";
        }
        public Result(bool issuccess, object data)
        {
            IsSuccess = issuccess;
            Data = data;
        }
        public bool IsSuccess { set; get; }
        public object Data { set; get; }
    }

    public class PhpResult
    {
        /// <summary>
        /// 初始化 IsSuccess = false;
        /// </summary>
        public PhpResult()
        {
            code = "";
            data = "";
            message = "";
        }
        public PhpResult(object codes, object datas)
        {
            code = codes;
            data = datas;
        }


        public object code { set; get; }
        public object data { set; get; }
        public object message { set; get; }

        public bool IsSucceed
        {
            get
            {
                return (code != null && code.ToString().Trim() == "1");
            }
        }
    }


}
