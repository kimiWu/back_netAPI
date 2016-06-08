using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.Ucar;

namespace YXP.API.DataAccess.Ucar
{
	public partial class Car_BrandDAL : BaseDAL<Car_Brand>
	{
		public Car_BrandDAL()
		 : base(ConnEnum.UcarRead)
		{
		}
	}
}

