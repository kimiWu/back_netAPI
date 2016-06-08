using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.DataAccess.TranstarAuction;
using YXP.API.Entity.TranstarAuction;

namespace YXP.API.Business.TranstarAuction
{
    public class TranstarVendorAccountBLL
    {
        private TranstarVendorAccountDAL dal = new TranstarVendorAccountDAL();
        public IEnumerable<TranstarVendorAccount> GetListByVendorFullName(string order, int pageSize, int maxId, int minId, string type, string vendorFullName)
        {
            return dal.GetList(order, pageSize, maxId, minId, type, vendorFullName);
        }
    }
}
