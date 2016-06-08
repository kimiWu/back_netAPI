using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.Ucar;

namespace YXP.API.DataAccess.Ucar
{
	public partial class Car_XMLDAL : BaseDAL<Car_XML>
	{
		public Car_XMLDAL()
		 : base(ConnEnum.UcarRead)
		{
		}
	}
}

