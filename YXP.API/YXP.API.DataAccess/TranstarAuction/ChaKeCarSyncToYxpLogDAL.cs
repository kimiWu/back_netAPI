using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.TranstarAuction;

namespace YXP.API.DataAccess.TranstarAuction
{
   
    public class ChaKeCarSyncToYxpLogDAL : BaseDAL<ChaKeCarSyncToYxpLog>
    {
        public ChaKeCarSyncToYxpLogDAL()
            : base(ConnEnum.TranstarAuction2011ConfigPath)
        {

        }
        public ChaKeCarSyncToYxpLogDAL(string conn)
            : base(ConnEnum.TranstarAuctionConfigPath, "TranstarAuctionConfigPathWrite")
        {

        }
    }
}
