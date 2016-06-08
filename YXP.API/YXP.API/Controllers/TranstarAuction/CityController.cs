using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApi.OutputCache.V2;
using YXP.API.Business.TranstarAuction;
using YXP.API.Entity.TranstarAuction;

namespace YXP.API.Controllers.TranstarAuction
{
    [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
    public class CityController : ApiController
    {
        public IEnumerable<City> GetAll()
        {
            return new CityBLL().GetList();
        }

        //public string GetCityName(int cityId)
        //{
        //    var model = new CityBLL().Get(cityId);
        //    if (model != null)
        //    {
        //        return model.city_Name;
        //    }
        //    return "";
        //}
    }
}