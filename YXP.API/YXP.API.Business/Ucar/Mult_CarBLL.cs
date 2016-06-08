using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.DataAccess.Ucar;
using YXP.API.Utility;

namespace YXP.API.Business.Ucar
{
    public class Mult_CarBLL
    {
        Mult_CarDAL dal = new Mult_CarDAL();
        public IEnumerable<K> Query<K>(string sql) where K : class
        {
            return dal.Query<K>(sql);
        }
        public IEnumerable<K> Query<K>(string sql, string orderBy, int pageIndex, int pageSize) where K : class
        {
            return dal.Query<K>(sql, orderBy, pageIndex, pageSize);
        }
        public IEnumerable<dynamic> Query(string sql)
        {
            return dal.Query(sql);
        }
        public IEnumerable<dynamic> Query(string sql, string orderBy, int pageIndex, int pageSize)
        {
            return dal.Query(sql, orderBy, pageIndex, pageSize);
        }
    }
}
