using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity;
using YXP.API.Entity.TranstarAuction;

namespace YXP.API.DataAccess.TranstarAuction
{
	public partial class MobileSessionCacheDAL : BaseDAL<MobileSessionCache>
	{
		public MobileSessionCacheDAL()
            : base(ConnEnum.TranstarAuctionConfigPath)
		{
		}
        public MobileSessionCacheDAL(string str)
            : base(ConnEnum.TranstarAuctionConfigPath, "TranstarAuctionConfigPathWrite")
        {
        }
	}
}

