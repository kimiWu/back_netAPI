using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.OutputCache.V2;
using YXP.API.Business.OPFramework;

namespace YXP.API.Controllers.OPFramework
{
     [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
    public class DepartmentController : ApiController
    {
        public IEnumerable<dynamic> GetAll()
        {
            return new DepartmentBLL().GetList();
        }
    }
}
