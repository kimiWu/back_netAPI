using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.OutputCache.V2;
using YXP.API.Business.TranstarAuction;
using YXP.API.Entity.TranstarAuction;

namespace YXP.API.Controllers.TranstarAuction
{
     [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
    public class ProvinceController : ApiController
    {
        public IEnumerable<Province> GetAll()
        {
            return new ProvinceBLL().GetList();
        }
    }
}
