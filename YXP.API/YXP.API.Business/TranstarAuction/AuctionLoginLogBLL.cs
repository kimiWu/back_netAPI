using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.ADS.Entity;
using YXP.ADS.Entity.TranstarAuction;
using YXP.API.DataAccess.TranstarAuction;

namespace YXP.API.Business.TranstarAuction
{
    public class AuctionLoginLogBLL
    {
        AuctionLoginLogDAL dal = new AuctionLoginLogDAL();

        public dynamic Insert(AuctionLoginLog log)
        {
            return dal.Insert(log);
        }
    }
}
