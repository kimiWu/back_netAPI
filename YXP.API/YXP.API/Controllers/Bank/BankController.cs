using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApi.OutputCache.V2;
using YXP.API.Business.Bank;
using YXP.API.Entity;
using YXP.API.Utility;

namespace YXP.API.Controllers.Bank
{
    //[CacheOutput(ClientTimeSpan = 10, ServerTimeSpan = 10)]
    public class BankController : ApiController
    {
        /// <summary>
        /// 一个参数调用示例
        /// </summary>
        /// <param name="bankstr"></param>
        /// <returns></returns>
        [HttpPost]
        [ApiActionFilter]
        public IEnumerable<string> GetName([FromBody]string bankstr)
        {
            try
            {
                IEnumerable<string> listString = new List<string>();
                listString = new BankBll().GetBankName(bankstr);
                return listString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 多个参数调用示例
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [ApiActionFilter]
        public IEnumerable<dynamic> GetBranch([FromBody]Branch obj)
        {
            try
            {
                string bankname = "", branchstr = "";
                if (obj != null)
                {
                    bankname = obj.bankname;
                    branchstr = obj.branchstr;
                }
                IEnumerable<dynamic> listStr = null;
                listStr = new BankBll().GetBranch(bankname, branchstr);
                return listStr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public string GetLog(string hello)
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["logPath"].ToString();
            var lw = new LogWriter(path);
            lw.WriteLine(DateTime.Now.ToString() + " " + hello);
            string str = File.ReadAllText(lw.FileName);
            return str;
        }
    }

    public class Branch : TBase
    {
        public string bankname { get; set; }
        public string branchstr { get; set; }

    
    }


}
