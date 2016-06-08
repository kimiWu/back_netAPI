using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity;
using YXP.API.Entity.TranstarAuction;

namespace YXP.API.DataAccess.TranstarAuction
{
    public  class AuctionApolloOrderDAL:BaseDAL<AuctionApolloOrder>
    {
        public AuctionApolloOrderDAL()
            : base(ConnEnum.TranstarAuctionConfigPath)
        {

        }
        /// <summary>
        /// 根据拍品ID和车源ID获取已经存在的订单
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="cid"></param>
        /// <returns></returns>
        public AuctionApolloOrder GetApolloOrder(int PublishId, int CarSourceId)
        {
            AuctionApolloOrder model = new AuctionApolloOrder();
            string strSql = string.Format("select ID,PublishId,CarSourceId,DraftTime,ISDispose,CreateTime from AuctionApolloOrder where PublishId={0} and CarSourceId={1}", PublishId, CarSourceId);
            IEnumerable<AuctionApolloOrder> list = Query<AuctionApolloOrder>(strSql);
            if (list != null && list.Count() > 0)
            {
                model = list.First();
            }
            return model;
        }
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateApolloOrder(AuctionApolloOrder model)
        {
            return Update(model);
        }
    }
}
