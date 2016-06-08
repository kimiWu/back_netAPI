using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YXP.API.Entity.Common
{
    public class PageEntity
    {
        public int currPage { get; set; }

        public int totalPage { get; set; }

        public int totalCount { get; set; }
    }
}
