using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.Ucar;

namespace YXP.API.DataAccess.Ucar
{
	public partial class Car_MasterBrandDAL : BaseDAL<Car_MasterBrand>
	{
		public Car_MasterBrandDAL()
		 : base(ConnEnum.UcarRead)
		{
		}
	}
}

