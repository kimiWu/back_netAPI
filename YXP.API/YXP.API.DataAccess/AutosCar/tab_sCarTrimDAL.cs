using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.AutosCar;

namespace YXP.API.DataAccess.AutosCar
{
	public partial class tab_sCarTrimDAL : BaseDAL<tab_sCarTrim>
	{
		public tab_sCarTrimDAL()
		 : base(ConnEnum.AutosCarRead)
		{
		}
	}
}

