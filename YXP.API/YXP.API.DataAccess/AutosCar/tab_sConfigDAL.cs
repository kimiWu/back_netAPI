﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.AutosCar;

namespace YXP.API.DataAccess.AutosCar
{
	public partial class tab_sConfigDAL : BaseDAL<tab_sConfig>
	{
		public tab_sConfigDAL()
		 : base(ConnEnum.AutosCarRead)
		{
		}
	}
}

