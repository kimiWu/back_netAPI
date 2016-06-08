using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApi.OutputCache.V2;
using YXP.API.Business;
using YXP.API.Business.Log;

namespace YXP.API.Controllers.ApiLog
{
    //使缓存作废
    //[AutoInvalidateCacheOutput]
    [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
    public class HomeController : ApiController
    {
        //[CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        public int GetHome()
        {
            return 456;
        }
        //[IgnoreCacheOutput]
        //[CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60, AnonymousOnly = true)]
        [HttpGet]
        public DateTime GetTime(int id)
        {
            if (id == 1)
            {
                return DateTime.Now.AddHours(1);
            }
            else
            {
                return DateTime.Now.AddMinutes(1);
            }
        }
    }
}
