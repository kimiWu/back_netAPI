using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.AutosCar;

namespace YXP.API.DataAccess.AutosCar
{
	public partial class tab_sConfigItemsDAL : BaseDAL<tab_sConfigItems>
	{
		public tab_sConfigItemsDAL()
		 : base(ConnEnum.AutosCarRead)
		{
		}
	}
}

