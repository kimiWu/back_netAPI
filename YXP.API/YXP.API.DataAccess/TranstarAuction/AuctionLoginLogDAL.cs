using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.ADS.Entity;
using YXP.ADS.Entity.TranstarAuction;

namespace YXP.API.DataAccess.TranstarAuction
{
    public class AuctionLoginLogDAL : BaseDAL<AuctionLoginLog>
    {
        public AuctionLoginLogDAL()
            : base(ConnEnum.TranstarAuctionConfigPath)
        {
        }
    }
}
