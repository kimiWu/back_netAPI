using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.DataAccess;
using YXP.API.DataAccess.Log;
using YXP.API.Entity;

namespace YXP.API.Business.Log
{
    public class LogRecordsBLL
    {
        public IEnumerable<LogRecords> GetAll(string where)
        {
            return new LogRecordsDAL().Where(where);
        }
        public bool Save(LogRecords model)
        {
            var dal = new LogRecordsDAL();
            //if (dal.Exists("", "id=" + model.Id))
            //{
                return dal.Insert(model) > 0;
            //}
            //else
            //{
            //    return new dal.Update(model);
            //}

        }
        public IEnumerable<LogRecords> GetList(string where,int pageIndex,int pageSize) 
        {
            return new LogRecordsDAL().Where(where, "", pageIndex, pageSize);
        }
        public int GetCount(string where)
        {
            return new LogRecordsDAL().Count(where);
        }
    }
}
