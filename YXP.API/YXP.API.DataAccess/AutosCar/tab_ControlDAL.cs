using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.AutosCar;

namespace YXP.API.DataAccess.AutosCar
{
	public partial class tab_ControlDAL : BaseDAL<tab_Control>
	{
		public tab_ControlDAL()
		 : base(ConnEnum.AutosCarRead)
		{
		}
	}
}

