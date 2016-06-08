using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.DataAccess.KPSales;
using YXP.API.Entity;
using YXP.API.Entity.KPSales;

namespace YXP.API.Business.KPSales
{
    public class KPSalesBll
    {
        private KPSalesDal dal = new KPSalesDal();

        public IEnumerable<KPSalesListEntity> GetList(string tvaIds, string order, int pageSize, int maxId, int minId, int state, string type,int UserId)
        {
            return dal.GetList(tvaIds, order, pageSize, maxId, minId, state, type,UserId);
        }

        public int GetCount(string tvaIds, int state,int UserId)
        {
            return dal.GetCount(tvaIds, state,UserId);
        }

        public KPSalesListEntity GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public dynamic VirtualBidRecordResult(int publishId, int auctionStatus)
        {
            return dal.VirtualBidRecordResult(publishId, auctionStatus);
        }

        public dynamic ExecVirtualBid(int publishId, int auctionStatus)
        {
            return dal.VirtualBidRecordResult(publishId, auctionStatus);
        }

        public dynamic ApplyInvest(long PublishID, decimal CurrSalesPrice, decimal SWFee, int UserID, decimal CompetitorPrice, decimal InvestMaxFee, int Sgn)
        {
            return dal.ApplyInvest(PublishID, CurrSalesPrice, SWFee, UserID,CompetitorPrice,InvestMaxFee,Sgn);
        }
    }
}
