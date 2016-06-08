﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
namespace YXP.API.Utility
{
    public class HttpClientHelper
    {
        public static string ApiHost = System.Configuration.ConfigurationManager.AppSettings["apiWebsite"].ToString();
        public static string _token = SignHelper.Token;
        public static string _sign = SignHelper.Sign;
        public static bool isAuth = false;
        private static string _foldName;
        private static string _controllerName;
        public HttpClientHelper(string foldName, string controllerName)
        {
            _foldName = foldName;
            _controllerName = controllerName;
        }


        #region Get

        /// <summary>
        /// 获取，默认Action Get
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static async Task<string> GetAsyncString(string foldName, string controllerName, string methodName = "Get", string paras = "")
        {
            string url = string.Format("{0}/{1}/{2}/{3}/{4}", ApiHost, foldName, controllerName, methodName, paras);
            if (isAuth)
            {
                url = CreateAuth(url);
            }
            string result = "";
            //创建HttpClient（注意传入HttpClientHandler）
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            //拼接URl
            using (var http = new HttpClient(handler))
            {
                //await异步等待回应
                var response = await http.GetAsync(url);
                //确保HTTP成功状态值 q
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                result = await response.Content.ReadAsStringAsync();
                return result;
            }
        }

        public static async Task<string> GetAsyncString(string methodName = "Get", string paras = "")
        {
            string result = await GetAsyncString(_foldName, _controllerName, methodName, paras);
            return result;
        }



        /// <summary>
        /// HttpClient实现Get请求，condition Json格式串
        /// </summary>
        public static async Task<T> GetAsyncObject<T>(string foldName, string controllerName, string methodName = "Get", string paras = "")
        {
            string result = await GetAsyncString(foldName, controllerName, methodName, paras);

            return string.IsNullOrEmpty(result) ? default(T) : JsonConvert.DeserializeObject<T>(result);

        }
        /// <summary>
        /// HttpClient实现Get请求，condition Json格式串
        /// </summary>
        public static async Task<T> GetAsyncObject<T>(string methodName = "Get", string paras = "")
        {
            string result = await GetAsyncString(_foldName, _controllerName, methodName, paras);
            return string.IsNullOrEmpty(result) ? default(T) : JsonConvert.DeserializeObject<T>(result);
        }

        #endregion

        #region Post
        /// <summary>
        /// HttpClient实现Post请求
        /// </summary>
        public static async Task<string> PostAsync(string foldName, string controllerName, Dictionary<string, string> values, string methodName = "Post")
        {
            string url = string.Format("{0}/{1}/{2}/{3}", ApiHost, foldName, controllerName, methodName);
            if (isAuth)
            {
                url = CreateAuth(url);
            }

            //设置HttpClientHandler的AutomaticDecompression
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            //创建HttpClient（注意传入HttpClientHandler）
            using (var http = new HttpClient(handler))
            {

                if (isAuth)
                {
                    CreateAuth(values);
                }
                //使用FormUrlEncodedContent做HttpContent
                var content = new FormUrlEncodedContent(values);

                //await异步等待回应           
                var response = await http.PostAsync(url, content);
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
        }

        /// <summary>
        /// HttpClient实现Post请求
        /// </summary>
        public static async Task<string> PostAsync<T>(string foldName, string controllerName, T value, string methodName = "Post")
        {
            string url = string.Format("{0}/{1}/{2}/{3}", ApiHost, foldName, controllerName, methodName);
            if (isAuth)
            {
                url = CreateAuth(url);
            }
            //设置HttpClientHandler的AutomaticDecompression
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            //创建HttpClient（注意传入HttpClientHandler）
            using (var http = new HttpClient(handler))
            {
                //使用FormUrlEncodedContent做HttpContent
                var content = new ObjectContent<T>(value, new JsonMediaTypeFormatter());

                //await异步等待回应           
                var response = await http.PostAsync(url, content);
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
        }

        #endregion

        #region Put

        /// <summary>
        /// HttpClient实现Put请求
        /// <param name="id">主键ID</param>
        /// <param name="values">要修改的字段，如： new {Name="test",Age=20}</param>
        /// </summary>
        public static async Task<string> PutAsync(string foldName, string controllerName, object id, object values, string methodName = "Put")
        {
            string url = string.Format("{0}/{1}/{2}/{3}", ApiHost, controllerName, methodName, id);
            if (isAuth)
            {
                url = CreateAuth(url);
            }
            //设置HttpClientHandler的AutomaticDecompression
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            //创建HttpClient（注意传入HttpClientHandler）
            using (var http = new HttpClient(handler))
            {
                string jsonStr = JsonConvert.SerializeObject(values);
                var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                //await异步等待回应
                var response = await http.PutAsync(url, content);
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
        }

        /// <summary>
        /// HttpClient实现Put请求
        /// </summary>
        public static async Task<string> PutAsync<T>(string foldName, string controllerName, object id, T values, string methodName = "Put")
        {
            string url = string.Format("{0}/{1}/{2}/{3}", ApiHost, foldName, controllerName, methodName);
            if (isAuth)
            {
                url = CreateAuth(url);
            }
            //设置HttpClientHandler的AutomaticDecompression
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            //创建HttpClient（注意传入HttpClientHandler）
            using (var http = new HttpClient(handler))
            {
                //使用FormUrlEncodedContent做HttpContent
                var content = new ObjectContent<T>(values, new JsonMediaTypeFormatter());
                //await异步等待回应
                var response = await http.PutAsync(url, content);
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
        }

        #endregion

        #region Delete

        /// <summary>
        /// HttpClient实现Put请求
        /// </summary>
        public static async Task<string> DeleteAsync(string foldName, string controllerName, object code, string methodName = "Delete")
        {
            string url = string.Format("{0}/{1}/{2}/{3}", ApiHost, foldName, controllerName, methodName, code);
            if (isAuth)
            {
                url = CreateAuth(url);
            }
            //设置HttpClientHandler的AutomaticDecompression
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            //创建HttpClient（注意传入HttpClientHandler）
            using (var http = new HttpClient(handler))
            {
                //await异步等待回应
                var response = await http.DeleteAsync(url);
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
        }

        #endregion

        /// <summary>
        /// 创建批量校验
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string CreateAuth(object url)
        {
            return url.ToString();
        }

    }
}
