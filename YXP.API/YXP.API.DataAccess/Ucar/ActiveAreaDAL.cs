using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.Ucar;

namespace YXP.API.DataAccess.Ucar
{
	public partial class ActiveAreaDAL : BaseDAL<ActiveArea>
	{
		public ActiveAreaDAL()
		 : base(ConnEnum.UcarRead)
		{
		}
	}
}

