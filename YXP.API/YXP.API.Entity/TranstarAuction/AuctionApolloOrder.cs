using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YXP.API.Entity.TranstarAuction
{
    [Serializable]
    public sealed class AuctionApolloOrder
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 拍品ID
        /// </summary>
        public int PublishId { get; set; }
        /// <summary>
        /// 车源ID
        /// </summary>
        public int CarSourceId { get; set; }
        /// <summary>
        /// 订单成交时间
        /// </summary>
        public DateTime DraftTime { get; set; }
        /// <summary>
        /// 是否处置   0未处置|1已处置|2已自动发拍
        /// </summary>
        public int ISDispose { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }
}
