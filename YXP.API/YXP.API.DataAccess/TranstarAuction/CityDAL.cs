﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity;
using YXP.API.Entity.TranstarAuction;

namespace YXP.API.DataAccess.TranstarAuction
{
	public  class CityDAL : BaseDAL<City>
	{
		public CityDAL()
		 : base(ConnEnum.TranstarAuctionConfigPath)
		{
		}
	}
}

