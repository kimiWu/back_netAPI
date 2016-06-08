using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.DataAccess.TranstarAuction;
using YXP.API.Entity.TranstarAuction;

namespace YXP.API.Business.TranstarAuction
{

    public class TradeManageBll
    {
        private TradeManageDal dal = new TradeManageDal();

        public TradeManageEntity GetList(string where,string orderBy, int pageSize, int currPage)
        {
            return dal.GetList(where, orderBy, pageSize, currPage);
        }
    }
}
