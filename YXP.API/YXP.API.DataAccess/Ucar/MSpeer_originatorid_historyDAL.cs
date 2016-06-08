using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.Ucar;

namespace YXP.API.DataAccess.Ucar
{
	public partial class MSpeer_originatorid_historyDAL : BaseDAL<MSpeer_originatorid_history>
	{
		public MSpeer_originatorid_historyDAL()
		 : base(ConnEnum.UcarRead)
		{
		}
	}
}

