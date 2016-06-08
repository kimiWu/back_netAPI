using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.Ucar;

namespace YXP.API.DataAccess.Ucar
{
	public partial class CityAreaDAL : BaseDAL<CityArea>
	{
		public CityAreaDAL()
		 : base(ConnEnum.UcarRead)
		{
		}
	}
}

