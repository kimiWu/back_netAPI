using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.DataAccess.TranstarAuction;
using YXP.API.Entity;

namespace YXP.API.Business.TranstarAuction
{
    public class TranstarVendorConfigBLL
    {
        

        public TranstarVendorConfig GetConfigById(int tvaId, string key)
        {
            TranstarVendorConfigDAL dal = new TranstarVendorConfigDAL();

            string sql = @"SELECT  TvaID
                          ,ConfigKey
                          ,ConfigValue
                          ,CreateTime
                          ,UpdateTime
                          FROM TranstarVendorConfig ";
            
            sql += string.Format(" where ConfigKey='{0}' and TvaID={1}", key, tvaId);

            return dal.Query<TranstarVendorConfig>(sql).FirstOrDefault();
        }
    }
}
