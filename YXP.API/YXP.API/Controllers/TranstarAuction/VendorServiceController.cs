using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using YXP.API.Entity.TranstarAuction;
using YXP.API.Entity;

namespace YXP.API.Controllers.TranstarAuction
{
    public class VendorServiceController : ApiController
    {
        public object GetVendorUserData([FromBody]VendorServiceReceiveParam param)
        {
            List<TranstarVendorUserAccount> list = new List<TranstarVendorUserAccount>();
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (!list[i].VendorFullName.Contains("直购"))
                    {
                        list[i].MobileCreateTime = list[i].CreateTime.HasValue ? list[i].CreateTime.Value.ToShortDateString() : "";
                    }
                    else
                    {
                        list.RemoveAt(i);
                        i = i - 1;
                    }
                }
            }
            return list;
        }

        public ApiResult CreateVendorAccount([FromBody]VendorServiceReceiveParam param)
        {
            ApiResult resule = new ApiResult();
            if (param == null)
            {
                resule.Status = -1;
                resule.Message = "无任何参数！";
            }
            return resule;
        }
    }
}