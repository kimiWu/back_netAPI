using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity;

namespace YXP.API.DataAccess.Log
{
    public partial class LogRecordsDAL : BaseDAL<LogRecords>
    {
        public LogRecordsDAL()
            : base(ConnEnum.ApiLogConfigPath)
        {

        }
    }
}

