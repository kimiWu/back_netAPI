using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.OutputCache.V2;
using YXP.API.Business;
using YXP.API.Business.Log;
using YXP.API.Entity;
using YXP.API.Entity.Log;

namespace YXP.API.Controllers.ApiLog
{
   [CacheOutput(ClientTimeSpan = 30, ServerTimeSpan = 40)]
    public class OrdersController : ApiController
    {
        OrdersBLL bll = new OrdersBLL();
        
        /// <summary>
        /// 带类的post必须使用JSON格式传递，否则api端收不到
        /// </summary>
        /// <param name="demo"></param>
        /// <returns></returns>
        public IEnumerable<Orders> GetOrders1([FromUri]Demo demo)
        {
            return bll.GetList1();
        }
        public IEnumerable<Orders> GetOrders11([FromUri]Demo demo)
        {
            return bll.GetList11();
        }
        [HttpPost]
        public IEnumerable<dynamic> GetOrders2([FromBody]Demo demo)
        {
            return bll.GetList2();
        }
         [HttpPost]
        public IEnumerable<Demo> GetOrders3([FromUri]Demo demo)
        {
            return bll.GetList3();
        }
         [HttpGet]
         public int GetCount()
         {
             return bll.Count();
         }
        // GET api/values/5
        public Orders Get(int id)
        {
            var item = bll.Get(id);
            return item;
        }
       [HttpGet]
        public dynamic Test()
        {
            var item = bll.Test();
            return item;
        }

        [HttpPost]
        // POST api/values
        public bool Post2(string value)
        {
            var entity = JsonConvert.DeserializeObject<Orders>(value);
            return bll.Update(entity);
        }
        [HttpPost]
        public int Post([FromBody]Orders entity)
        {
            // {
            //    "id": 1,
            //    "serial": "aa",
            //    "name": "tom",
            //    "price": 100,
            //    "uid": 10
            //}
            return bll.Add(entity);
        }
        public bool Save()
        {
            return new OrdersBLL().Save();
        }
        [HttpPost]
        // PUT api/values/5
        public bool Put2(int id, [FromBody]string value)
        {
            var entity = JsonConvert.DeserializeObject<Orders>(value);
            return bll.Update(entity, new { id = id });
        }
        [HttpPost]
        public bool Put(int id, [FromBody]Orders entity)
        {
            return bll.Update(entity, new { id = id });
        }
        [HttpPost]
        public bool Delete(int id)
        {
            return bll.Delete(id);
        }
    }
}
