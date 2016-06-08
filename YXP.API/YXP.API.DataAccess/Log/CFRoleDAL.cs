using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity;
//using Dapper;
using DapperExtensions;
using YXP.API.Entity.Log;
 

namespace YXP.API.DataAccess.Log
{
    public class CFRoleDAL : BaseDAL<CFRole>
    {



        public CFRoleDAL()
            : base("ApiLogConfigPath")
        {
           
        }
    }
}
