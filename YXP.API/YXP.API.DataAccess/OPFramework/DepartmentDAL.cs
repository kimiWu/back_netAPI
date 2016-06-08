using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.OPFramework;

namespace YXP.API.DataAccess.OPFramework
{
	public partial class DepartmentDAL : BaseDAL<Department>
	{
		public DepartmentDAL()
            : base("OPFramework")
		{
		}
	}
}

