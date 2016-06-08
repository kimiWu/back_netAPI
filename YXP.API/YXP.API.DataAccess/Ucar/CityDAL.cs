using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.Ucar;

namespace YXP.API.DataAccess.Ucar
{
	public partial class CityDAL : BaseDAL<City>
	{
		public CityDAL()
		 : base(ConnEnum.UcarRead)
		{
		}
	}
}

