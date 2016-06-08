using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YXP.API.Entity.Log
{
    public class Orders //: TBase
    {
        public int Id { get; set; }
        public string Serial { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int UId { get; set; }
    }


}
