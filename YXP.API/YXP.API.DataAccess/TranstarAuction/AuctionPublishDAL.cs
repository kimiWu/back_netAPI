using YXP.API.Entity;
using YXP.API.Entity.TranstarAuction;

namespace YXP.API.DataAccess.TranstarAuction
{
    public  class AuctionPublishDAL : BaseDAL<AuctionPublishInfo>
    {
        public AuctionPublishDAL()
            : base(ConnEnum.TranstarAuctionConfigPath)
        { 
        
        }
    }
}
