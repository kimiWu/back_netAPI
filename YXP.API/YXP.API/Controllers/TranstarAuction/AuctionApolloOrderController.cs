using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace YXP.API.Controllers
{
    public class AuctionApolloOrderController : ApiController
    {
        /// <summary>
        /// 根据拍品ID和车源ID将订单设置为已处置
        /// </summary>
        /// <param name="PublishId">拍品ID</param>
        /// <param name="CarSourceId">车源ID</param>
        /// <returns></returns>
        [HttpGet]
        //[ApiActionFilter]
        public async Task<object> SetApolloOrderISDispose(int PublishId, int CarSourceId)
        {
            Result re = new Result();
            await Task.Run(() =>
            {

                string msg = string.Empty;
                bool bResult = new YXP.API.Business.AuctionApolloOrderBLL().SetApolloOrderISDispose(PublishId, CarSourceId, out msg);
                if (bResult)
                    re.result = 1;
                else
                    re.result = -1;
                re.message = msg;
            });
            return re;
        }
    }
    public class Result
    {
        /// <summary>
        /// 处理结果
        /// </summary>
        public int result { get; set; }
        /// <summary>
        /// 结果描述
        /// </summary>
        public string message { get; set; }
    }
}
