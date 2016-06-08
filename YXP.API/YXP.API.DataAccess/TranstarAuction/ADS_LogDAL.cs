using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity;
using YXP.API.Entity.TranstarAuction;

namespace YXP.API.DataAccess.TranstarAuction
{
    public class ADS_LogDAL : BaseDAL<ADS_Log>
    {
        public ADS_LogDAL()
            : base(ConnEnum.TranstarAuctionConfigPath)
        {

        }
        public ADS_LogDAL(string conn)
            : base(ConnEnum.TranstarAuctionConfigPath, "TranstarAuctionConfigPathWrite")
        {

        }
    }
}
