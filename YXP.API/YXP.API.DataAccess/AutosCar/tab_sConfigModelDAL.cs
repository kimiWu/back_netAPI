using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.AutosCar;

namespace YXP.API.DataAccess.AutosCar
{
	public partial class tab_sConfigModelDAL : BaseDAL<tab_sConfigModel>
	{
		public tab_sConfigModelDAL()
		 : base(ConnEnum.AutosCarRead)
		{
		}
	}
}

