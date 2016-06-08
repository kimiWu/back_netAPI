using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace YXP.PaiMobile.Models
{
    /// <summary>
    /// 大厅列表返回
    /// </summary>
    [DataContract]
    public class AuctionListResponseEntity
    {
        /// <summary>
        /// 最后一条拍品id
        /// </summary>
        [DataMember(Name = "lastPublishID")]
        public long LastPublishID { get; set; }
        /// <summary>
        /// 拍品在列表中的位置
        /// </summary>
        [DataMember(Name = "pageIndex")]
        public int PageIndex { get; set; }
        /// <summary>
        /// 大厅返回列表
        /// </summary>
        [DataMember(Name = "auctionListEntity")]
        public List<AuctionListEntity> aleL { get; set; }

        /// <summary>
        /// 待排序标识 0排序 1待排序
        /// </summary>
        [DataMember(Name = "isWait")]
        public int IsWait { get; set; }

        /// <summary>
        /// 通道名称
        /// </summary>
        [DataMember(Name = "listChannelName")]
        public string ListChannelName { get; set; }
    }
    /// <summary>
    /// 手动订阅
    /// </summary>
    [DataContract]
    public class SubscribeAuctionListResponseEntity
    {
        /// <summary>
        /// 手动订阅条件
        /// </summary>
        [DataMember(Name = "searchEntity")]
        public AuctionListSearchEntity condition { get; set; }
        [DataMember(Name = "searchName")]
        public string conditionName { get; set; }
        /// <summary>
        /// 手动订阅返回列表
        /// </summary>
        [DataMember(Name = "auctionListEntity")]
        public List<AuctionListEntity> aleL { get; set; }
        /// <summary>
        /// 最后一条拍品id
        /// </summary>
        [DataMember(Name = "lastPublishID")]
        public long LastPublishID { get; set; }
        /// <summary>
        /// 拍品在列表中的位置
        /// </summary>
        [DataMember(Name = "pageIndex")]
        public int PageIndex { get; set; }
    }
    /// <summary>
    /// 手动订阅
    /// </summary>
    [DataContract]
    public class SubscribeAuctionListResponseEntity2
    {
        /// <summary>
        /// 手动订阅条件
        /// </summary>
        [DataMember(Name = "searchEntity")]
        public AuctionListSearchEntity condition { get; set; }


        [DataMember(Name = "searchName")]
        public string conditionName { get; set; }
        ///// <summary>
        ///// 手动订阅返回列表
        ///// </summary>
        //[DataMember(Name = "auctionListEntity")]
        //public List<AuctionListEntity> aleL { get; set; }
    }
    /// <summary>
    /// 系统推荐
    /// </summary>
    [DataContract]
    public class SubscribeAuctionListResponseEntity3
    {
        /// <summary>
        /// 返回列表
        /// </summary>
        [DataMember(Name = "auctionListEntity")]
        public List<AuctionListEntity> aleL { get; set; }
    }
    /// <summary>
    /// 大厅列表返回
    /// </summary>
    [DataContract]
    public class AuctionListEntity
    {
        /// <summary>
        /// 来源 1个人 2商家 3 代拍 
        /// </summary>
        [DataMember(Name = "origin")]
        public int Origin { get; set; }
        /// <summary>
        /// 名称 
        /// </summary>
        [DataMember(Name = "auctionTitle")]
        public string AuctionTitle { get; set; }
        /// <summary>
        /// 起拍价 
        /// </summary>
        [DataMember(Name = "pricesStart")]
        public string PricesStart { get; set; }
        /// <summary>
        /// 车况 
        /// </summary>
        [DataMember(Name = "vehicleCondition")]
        public string VehicleCondition { get; set; }
        /// <summary>
        /// 车况（新） 
        /// </summary>
        [DataMember(Name = "conditionGradeSmall")]
        public string ConditionGradeSmall { get; set; }
        /// <summary>
        /// 车位号 
        /// </summary>
        [DataMember(Name = "parkingNum")]
        public string ParkingNum { get; set; }
        /// <summary>
        /// 车辆归属地 城市
        /// </summary>
        [DataMember(Name = "vehicleBelong")]
        public string VehicleBelong { get; set; }
        /// <summary>
        /// 拍品id 
        /// </summary>
        [DataMember(Name = "id")]
        public string ID { get; set; }
        /// <summary>
        /// 车源id 
        /// </summary>
        [DataMember(Name = "carSourceID")]
        public string CarSourceID { get; set; }
        /// <summary>
        /// 图片 
        /// </summary>
        [DataMember(Name = "imgUrl")]
        public string ImgUrl { get; set; }
        /// <summary>
        /// 年份 
        /// </summary>
        [DataMember(Name = "year")]
        public string Year { get; set; }
        /// <summary>
        /// 公里数
        /// </summary>
        [DataMember(Name = "kilometers")]
        public string Kilometers { get; set; }
        /// <summary>
        /// 是否关注此车 1是，0否 
        /// </summary>
        [DataMember(Name = "isAttention")]
        public string IsAttention { get; set; }
        /// <summary>
        /// 通道名称 
        /// </summary>
        [DataMember(Name = "channelName")]
        public string ChannelName { get; set; }
        /// <summary>
        /// 拍卖状态  0正在投标, 1等待竞价, 2正在竞价  
        /// </summary>
        [DataMember(Name = "auctionStatus")]
        public string AuctionStatus { get; set; }
        /// <summary>
        /// 通道类型 0：在线 1:小圈  2:现场 3:快拍
        /// </summary>
        [DataMember(Name = "channelType")]
        public string ChannelType { get; set; }
        /// <summary>
        /// 车牌
        /// </summary>
        [DataMember(Name = "carPlaceCity")]
        public string CarPlaceCity { get; set; }
        /// <summary>
        /// 是否营运 0非营运 ,1营运, 2营转非, 3租赁, 4租赁公司非营运
        /// </summary>
        [DataMember(Name = "carUseType")]
        public int CarUseType { get; set; }
        /// <summary>
        /// 拍品支持的代金券数额
        /// </summary>
        [DataMember(Name = "promotionFee")]
        public string PromotionFee { get; set; }
        /// <summary>
        /// 座位数
        /// </summary>
        [DataMember(Name = "seatsNumber")]
        public int SeatsNumber { get; set; }
        /// <summary>
        /// 是否出价
        /// </summary>
        [DataMember(Name = "isBid")]
        public int IsBid { get; set; }
        /// <summary>
        /// 是否伙伴  1:伙伴  0:非伙伴
        /// </summary>
        [DataMember(Name = "isPartner")]
        public int IsPartner { get; set; }
        /// <summary>
        /// 排序时间
        /// </summary>
        public DateTime SortAuctionTime;
        /// <summary>
        /// 竞价开始时间
        /// </summary>
        public DateTime AuctionStartTime;
        /// <summary>
        /// 显示保留价或起拍价   1：显示起拍价   2:保留价  
        /// </summary>
        [DataMember(Name = "isOut")]
        public int IsOut { get; set; }
        public int OrderID;
        public int CarYear;

        /// <summary>
        /// 如果从大数据拿数据时该拍品在大数据中的次序
        /// </summary>
        public int OriginalIndex { get; set; }

        /// <summary>
        /// 实际推送给客户端的次序
        /// </summary>
        public int ActualIndex { get; set; }
        /// <summary>
        /// 是否抽奖  1：抽奖  0：代金券 -1：无奖励
        /// </summary>
        [DataMember(Name = "isLottery")]
        public int IsLottery { get; set; }
        /// <summary>
        /// 来源 1:采集 2:查客2.0 3:查客3.0 4:地板场 5:其他
        /// </summary>
        [DataMember(Name = "sourceFrom")]
        public int SourceFrom { get; set; }
        private string standardCode = "";
        /// <summary>
        /// 国标码
        /// </summary>
        [DataMember(Name = "standardCode")]
        public string StandardCode { get { return standardCode; } set { standardCode = value; } }

        /// <summary>
        /// 是否无底价拍卖
        /// </summary>
        [DataMember(Name = "isNoReserve")]
        public string IsNoReserve { get; set; }

        /// <summary>
        /// 拍品所属下标
        /// </summary>
        [DataMember(Name = "currentIndex")]
        public int CurrentIndex { get; set; }
        /// <summary>
        /// 通道内拍品总数
        /// </summary>
        [DataMember(Name = "channelCount")]
        public int ChannelCount { get; set; }
        /// <summary>
        /// 投标结束时间
        /// </summary>
        [DataMember(Name = "tenderEndTime")]
        public string TenderEndTime { get; set; }
        /// <summary>
        /// 是否为心愿条件  0：非，1：是
        /// </summary>
        [DataMember(Name = "isWish")]
        public int IsWish { get; set; }

        [IgnoreDataMember]
        public string ChannelInfo { get; set; }
    }
    /// <summary>
    /// 双通道列表返回
    /// </summary>
    [DataContract]
    public class DoubleChannelEntity:AuctionListEntity
    {
        ///// <summary>
        ///// 拍品所属下标
        ///// </summary>
        //[DataMember(Name = "currentIndex")]
        //public int CurrentIndex { get; set; }
        ///// <summary>
        ///// 通道内拍品总数
        ///// </summary>
        //[DataMember(Name = "channelCount")]
        //public int ChannelCount { get; set; }
        /// <summary>
        /// 关注的拍品总数
        /// </summary>
        [DataMember(Name = "attentionCount")]
        public int AttentionCount { get; set; }
        /// <summary>
        /// 最高出价
        /// </summary>
        [DataMember(Name = "highPrice")]
        public string HighPrice { get; set; }
        /// <summary>
        /// 通道状态  0正在投标, 1等待竞价, 2正在竞价  3:竞价结束
        /// </summary>
        [DataMember(Name = "channelStatus")]
        public string ChannelStatus { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        [DataMember(Name = "channelMsg")]
        public string ChannelMsg { get; set; }
    }
}
