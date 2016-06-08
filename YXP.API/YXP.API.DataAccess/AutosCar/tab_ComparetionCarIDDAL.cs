using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.AutosCar;

namespace YXP.API.DataAccess.AutosCar
{
	public partial class tab_ComparetionCarIDDAL : BaseDAL<tab_ComparetionCarID>
	{
		public tab_ComparetionCarIDDAL()
		 : base(ConnEnum.AutosCarRead)
		{
		}
	}
}

