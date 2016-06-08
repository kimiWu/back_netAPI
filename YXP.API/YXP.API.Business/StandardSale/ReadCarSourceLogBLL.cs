using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.DataAccess.StandardSale;
using YXP.API.Entity.StandardSale;

namespace YXP.API.Business.StandardSale
{
    public class ReadCarSourceLogBLL
    {
        private ReadCarSourceLogDAL dal = new ReadCarSourceLogDAL();

        public void SaveReadCarSourceLog(ReadCarSourceLog model)
        {
            dal.Insert(model);
        }
    }
}
