using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YXP.API.Entity.Models.TranstarAuction
{
    public class OrderPageModel
    {
        public int pageIndex { get; set; }

        public int pageSize { get; set; }

        public string sessionId { get; set; }

    }
}
