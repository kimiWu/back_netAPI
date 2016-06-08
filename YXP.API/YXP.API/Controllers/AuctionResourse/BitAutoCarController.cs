using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace YXP.API.Controllers.AuctionResourse
{
    public class BitAutoCarController : ApiController
    {
        // GET: api/BitAutoCar
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BitAutoCar/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BitAutoCar
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/BitAutoCar/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BitAutoCar/5
        public void Delete(int id)
        {
        }
    }
}
