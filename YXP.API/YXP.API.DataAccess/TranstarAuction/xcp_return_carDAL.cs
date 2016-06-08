using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.TranstarAuction;

namespace YXP.API.DataAccess.TranstarAuction
{
	public partial class xcp_return_carDAL : BaseDAL<xcp_return_car>
	{
		public xcp_return_carDAL()
		 : base(ConnEnum.TranstarAuctionConfigPath)
		{
		}
	}
}

