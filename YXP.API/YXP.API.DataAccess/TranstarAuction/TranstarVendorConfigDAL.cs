using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity;

namespace YXP.API.DataAccess.TranstarAuction
{
    public class TranstarVendorConfigDAL : BaseDAL<TranstarVendorConfig>
    {
        public TranstarVendorConfigDAL()
            : base(ConnEnum.TranstarAuctionConfigPath)
        {

        }
    }
}
