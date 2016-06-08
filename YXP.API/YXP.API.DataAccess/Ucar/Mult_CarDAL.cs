using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.Ucar;

namespace YXP.API.DataAccess.Ucar
{
    public class Mult_CarDAL : BaseDAL<object>
    {
        public Mult_CarDAL()
            : base(ConnEnum.UcarRead)
        {

        }
    }
}
