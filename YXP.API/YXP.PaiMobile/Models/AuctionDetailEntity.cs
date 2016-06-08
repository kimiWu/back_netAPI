using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace YXP.PaiMobile.Models
{
    /// <summary>
    /// 拍品详情类
    /// </summary>
    [DataContract]
    public class AuctionDetailEntity
    {
        //--------------------------不可变-----------------------------------
        /// <summary>
        /// 所属经销商
        /// </summary>
        [DataMember(Name = "tvaid")]
        public int Tvaid { get; set; }

        /// <summary>
        /// 拍品ID
        /// </summary>
        [DataMember(Name = "publishID")]
        public long PublishID { get; set; }

        /// <summary>
        /// 车辆ID
        /// </summary>
        [DataMember(Name = "carSourceID")]
        public int CarSourceID { get; set; }

        /// <summary>
        /// 拍品名称
        /// </summary>
        [DataMember(Name = "auctionName")]
        public string AuctionName { get; set; }

        /// <summary>
        /// 行驶里程
        /// </summary>
        [DataMember(Name = "mile")]
        public string Mile { get; set; }

        /// <summary>
        /// 车辆颜色
        /// </summary>
        [DataMember(Name = "color")]
        public string Color { get; set; }

        /// <summary>
        /// 上牌日期
        /// </summary>
        [DataMember(Name = "registDate")]
        public string RegistDate { get; set; }

        /// <summary>
        /// 竞价开始时间
        /// </summary>
        [DataMember(Name = "priceStartTime")]
        public string PriceStartTime { get; set; }

        /// <summary>
        /// 竞价开始时间
        /// </summary>
        [DataMember(Name = "auctionPriceStartTime")]
        public string AuctionPriceStartTime { get; set; }

        /// <summary>
        /// 竞价结束时间
        /// </summary>
        [DataMember(Name = "priceStopTime")]
        public string PriceStopTime { get; set; }

        /// <summary>
        /// 竞价结束时间 剩余秒数
        /// </summary>
        [DataMember(Name = "withStopTime")]
        public string WithStopTime { get; set; }

        /// <summary>
        /// 是否关注
        /// </summary>
        [DataMember(Name = "isAttention")]
        public int IsAttention { get; set; }

        /// <summary>
        /// 卖家过户条件  外迁过户 = 1, 无要求 = 2, 本市过户 = 3
        /// </summary>
        [DataMember(Name = "isRelocation")]
        public int IsRelocation { get; set; }

        /// <summary>
        /// 城市ID
        /// </summary>
        [DataMember(Name = "cityID")]
        public int CityID { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        [DataMember(Name = "cityName")]
        public string CityName { get; set; }

        /// <summary>
        /// 车系id
        /// </summary>
        [DataMember(Name = "serialID")]
        public long SerialID { get; set; }

        /// <summary>
        /// 车系名称
        /// </summary>
        [DataMember(Name = "serialName")]
        public string SerialName { get; set; }

        /// <summary>
        /// 品牌id
        /// </summary>
        [DataMember(Name = "brandID")]
        public long BrandID { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        [DataMember(Name = "brandName")]
        public string BrandName { get; set; }

        /// <summary>
        ///  车辆来源类型 1个人，2商家，3代拍，4现场，5打包 6：快拍
        /// </summary>
        [DataMember(Name = "carSourceOwner")]
        public int CarSourceOwner { get; set; }

        /// <summary>
        /// 车牌
        /// </summary>
        [DataMember(Name = "carPlaceCity")]
        public string CarPlaceCity { get; set; }

        /// <summary>
        /// 车况等级（旧）
        /// </summary>
        [DataMember(Name = "conditionGrade")]
        public string ConditionGrade { get; set; }
        /// <summary>
        /// 车况等级（新）
        /// </summary>
        [DataMember(Name = "conditionGradeSmall")]
        public string ConditionGradeSmall { get; set; }

        /// <summary>
        /// 起拍价
        /// </summary>
        [DataMember(Name = "startPrice")]
        public string StartPrice { get; set; }

        /// <summary>
        /// 保留价
        /// </summary>
        [DataMember(Name = "resPrice")]
        public string ResPrice { get; set; }

        /// <summary>
        /// 起拍价(外迁)
        /// </summary>
        [DataMember(Name = "outStartPrice")]
        public string OutStartPrice { get; set; }

        /// <summary>
        /// 保留价(外迁)
        /// </summary>
        [DataMember(Name = "outResPrice")]
        public string OutResPrice { get; set; }


        /// <summary>
        /// 所有的过户地点
        /// </summary>
        [DataMember(Name = "transferAdr")]
        public string TransferAdr { get; set; }

        /// <summary>
        /// 拍品类型 1：非集中  4:集中 
        /// </summary>
        [DataMember(Name = "productType")]
        public int ProductType { get; set; }

        /// <summary>
        /// 车辆类型 CarSourceType>0庞大的车
        /// </summary>
        [DataMember(Name = "carSourceType")]
        public int CarSourceType { get; set; }

        /// <summary>
        /// 拍卖类型
        /// </summary>
        [DataMember(Name = "auctionType")]
        public int AuctionType { get; set; }


        /// <summary>
        /// 付款方式 1→支持在线付款；  2→支持线下付款 ； 3→支持在线付款和线下付款
        /// </summary>
        [DataMember(Name = "payType")]
        public int PayType { get; set; }

        /// <summary>
        /// 是否优信拍代办过户 1是优信拍代办过户   2：不是
        /// </summary>
        [DataMember(Name = "isAgentTransfer")]
        public int IsAgentTransfer { get; set; }

        /// <summary>
        /// 是否可参拍   1  可参拍  2  不可参拍
        /// </summary>
        [DataMember(Name = "canAuction")]
        public int CanAuction { get; set; }

        /// <summary>
        /// 是否新车 0:是新车，1不是
        /// </summary>
        [DataMember(Name = "isNewCar")]
        public int IsNewCar { get; set; }

        /// <summary>
        /// 外迁补贴费
        /// </summary>
        [DataMember(Name = "myAgentFee")]
        public string MyAgentFee { get; set; }

        /// <summary>
        /// 付款要求
        /// </summary>
        [DataMember(Name = "payTypeSelect")]
        public int PayTypeSelect { get; set; }

        /// <summary>
        /// 提车要求
        /// </summary>
        [DataMember(Name = "carDemand")]
        public int CarDemand { get; set; }

        /// <summary>
        /// 车主证件
        /// </summary>
        [DataMember(Name = "documentProvided")]
        public int DocumentProvided { get; set; }

        /// <summary>
        /// 过户要求，多少天内 0为无要求
        /// </summary>
        [DataMember(Name = "expectTransferExpired")]
        public int ExpectTransferExpired { get; set; }

        /// <summary>
        /// 小圈型 1为小圈
        /// </summary>
        [DataMember(Name = "isSmallVender")]
        public int IsSmallVender { get; set; }
        //-------------------------------------可变-----------------------------------

        /// <summary>
        /// 竞价我的出价
        /// </summary>
        [DataMember(Name = "myPrice")]
        public string MyPrice { get; set; }
        /// <summary>
        /// 我的投标价
        /// </summary>
        [DataMember(Name = "myTenderPrice")]
        public string MyTenderPrice { get; set; }
        /// <summary>
        /// 最高出价
        /// </summary>
        [DataMember(Name = "highPrice")]
        public string HighPrice { get; set; }

        /// <summary>
        /// 显示保留价或起拍价   1：显示起拍价   2:保留价  
        /// </summary>
        [DataMember(Name = "isOut")]
        public int IsOut { get; set; }

        /// <summary>
        /// 是否最高价 1:是最高价 0：不是最高价
        /// </summary>
        [DataMember(Name = "ishigh")]
        public int Ishigh { get; set; }

        /// <summary>
        /// 竞价手次
        /// </summary>
        [DataMember(Name = "auctionCount")]
        public int AuctionCount { get; set; }

        /// <summary>
        /// 选择的过户方式
        /// </summary>
        [DataMember(Name = "transferType")]
        public int TransferType { get; set; }

        /// <summary>
        /// 用户选择的过户地点
        /// </summary>
        [DataMember(Name = "selectTransferAdr")]
        public string SelectTransferAdr { get; set; }


        /// <summary>
        /// 拍品状态 none = 0, 投标结束 = 1,竞价结束 = 2,竞价开始 = 3
        /// </summary>
        [DataMember(Name = "state")]
        public int State { get; set; }

        /// <summary>
        /// 投标最高价
        /// </summary>
        [DataMember(Name = "tenderHighPrice")]
        public string TenderHighPrice { get; set; }
        /// <summary>
        /// 是否参与  1参与  0未参与
        /// </summary>
        [DataMember(Name = "isPart")]
        public int IsPart { get; set; }
        /// <summary>
        /// 投标结束时间
        /// </summary>
        [DataMember(Name = "tenderEndTime")]
        public string TenderEndTime { get; set; }
        /// <summary>
        /// 是否竞得拍品 1 竞得 0没有
        /// </summary>
        [DataMember(Name = "isSeller")]
        public int IsSeller { get; set; }

        /// <summary>
        /// 选择的支付方式 线上支付1 or 线下支付2
        /// </summary>
        [DataMember(Name = "selectPayType")]
        public int SelectPayType { get; set; }
        /// <summary>
        /// 是否已确定协议 1:已确定，2：未确定
        /// </summary>
        [DataMember(Name = "isTransfer")]
        public int IsTransfer { get; set; }
        /// <summary>
        /// 是否今日拍品  1：是今日拍品  2：明日拍品
        /// </summary>
        [DataMember(Name = "isTodayOrTemoAuction")]
        public int IsTodayOrTemoAuction { get; set; }

        /// <summary>
        /// 上一个拍品id
        /// </summary>
        [DataMember(Name = "priPublishID")]
        public long PriPublishID { get; set; }
        /// <summary>
        /// 下一个拍品id
        /// </summary>
        [DataMember(Name = "nextPublishID")]
        public long NextPublishID { get; set; }
        /// <summary>
        /// 通道id
        /// </summary>
        [DataMember(Name = "chanelId")]
        public long ChanelId { get; set; }
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
        /// 是否已经确认重要信息  0未确认，1已确认
        /// </summary>
        [DataMember(Name = "isReadInfo")]
        public int IsReadInfo { get; set; }

        /// <summary>
        /// 拍品支持的代金卷数额
        /// </summary>
        [DataMember(Name = "promotionFee")]
        public string PromotionFee { get; set; }

        /// <summary>
        /// 通道名称
        /// </summary>
        [DataMember(Name = "channelName")]
        public string ChannelName { get; set; }

        /// <summary>
        /// 是否需要确定协议 1:需要，0：不需要
        /// </summary>
        [DataMember(Name = "canTransfer")]
        public int CanTransfer { get; set; }

        /// <summary>
        /// 是否需要弹出收费规则 1:需要，0不需要
        /// </summary>
        [DataMember(Name = "canCostRule")]
        public int CanCostRule { get; set; }

        /// <summary>
        /// 是否伙伴关系 1:是，0：否
        /// </summary>
        [DataMember(Name = "isPartner")]
        public int IsPartner { get; set; }

        /// <summary>
        /// 锁定时间 -1 未锁定， 十五天 = 0, 一个月 = 1, 二个月 = 2, 三个月 = 3  
        /// </summary>
        [DataMember(Name = "lockDaysType")]
        public int LockDaysType { get; set; }

        /// <summary>
        /// 是否收费 1:是 0:不是
        /// </summary>
        [DataMember(Name = "isFee")]
        public int IsFee { get; set; }

        /// <summary>
        /// 虚假买家 1:是 0:不是
        /// </summary>
        [DataMember(Name = "isVirtual")]
        public int IsVirtual { get; set; }

        /// <summary>
        /// 卖家经销商所属城市名称
        /// </summary>
        [DataMember(Name = "vendorCityName")]
        public string VendorCityName { get; set; }

        /// <summary>
        /// 是否日产现场拍  1:是，0否。
        /// </summary>
        [DataMember(Name = "isNissanLiveAuction")]
        public int IsNissanLiveAuction { get; set; }

        /// <summary>
        /// 交付服务费
        /// </summary>
        [DataMember(Name = "buyerAgentFee")]
        public string BuyerAgentFee { get; set; }

        /// <summary>
        /// 交易佣金
        /// </summary>
        [DataMember(Name = "buyerTradeFee")]
        public string BuyerTradeFee { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        [DataMember(Name = "buyerTotalFee")]
        public string BuyerTotalFee { get; set; }

        /// <summary>
        /// 场地名称
        /// </summary>
        [DataMember(Name = "marketName")]
        public string MarketName { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [DataMember(Name = "lng")]
        public string Lng { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        [DataMember(Name = "lat")]
        public string Lat { get; set; }

        /// <summary>
        /// 交付地点
        /// </summary>
        [DataMember(Name = "placeAddress")]
        public string PlaceAddress { get; set; }

        /// <summary>
        /// 过户说明文字
        /// </summary>
        [DataMember(Name = "transferInstr")]
        public List<string> TransferInstr { get; set; }

        /// <summary>
        /// 过户说明价格
        /// </summary>
        [DataMember(Name = "transferMoney")]
        public string TransferMoney { get; set; }
        /// <summary>
        /// 特别事项
        /// </summary>
        [DataMember(Name = "specialItems")]
        public List<string> SpecialItems;

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

        /// <summary>
        /// 来源 1:采集 2:查客2.0 3:查客3.0 4:地板场 5:其他
        /// </summary>
        [DataMember(Name = "nextSourceFrom")]
        public int NextSourceFrom { get; set; }
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
        #region 导购
        /// <summary>
        /// 卖场导购人
        /// </summary>
        [DataMember(Name = "guideName")]
        public string GuideName { get; set; }

        /// <summary>
        /// 卖场导购人Img
        /// </summary>
        [DataMember(Name = "guideImg")]
        public string GuideImg { get; set; }

        /// <summary>
        /// 导购员电话
        /// </summary>
        [DataMember(Name = "guidePhone")]
        public string GuidePhone { get; set; }

        /// <summary>
        /// 导购员id
        /// </summary>
        [DataMember(Name = "guideID")]
        public int GuideID { get; set; }

        /// <summary>
        /// 是否评价 0:未评价  1:已评价
        /// </summary>
        [DataMember(Name = "isComment")]
        public int IsComment { get; set; }

        /// <summary>
        /// 服务评价 1:好评 2:一般 3:差评
        /// </summary>
        [DataMember(Name = "serviceComment")]
        public int ServiceComment { get; set; }
        /// <summary>
        /// 报告评价 1:好评 2:一般 3:差评
        /// </summary>
        [DataMember(Name = "reportComment")]
        public int ReportComment { get; set; }
        /// <summary>
        /// 评价详情
        /// </summary>
        [DataMember(Name = "commentDetail")]
        public string CommentDetail;
        /// <summary>
        /// 加价幅度
        /// </summary>
        [DataMember(Name = "addPrice")]
        public int AddPrice;

        /// <summary>
        /// 电签状态 0 ：未签证  1：审核中 2：被拒 3：审核通过 4：签证成功 5：无需签约
        /// </summary>
        [DataMember(Name = "signStatus")]
        public int SignStatus
        {
            get;
            set;
        }

        /// <summary>
        /// 等待成交时间
        /// </summary>
        [DataMember(Name = "waitDealTime")]
        public int WaitDealTime { get; set; }
        #endregion

        #region 双通道

        /// <summary>
        /// 另一通道id
        /// </summary>
        [DataMember(Name = "nextChannelID")]
        public int NextChannelID { get; set; }
        /// <summary>
        /// 是否双通道 0：非双通道 1：双通道 
        /// </summary>
        [DataMember(Name = "isDoubleChannel")]
        public int IsDoubleChannel { get; set; }

        /// <summary>
        /// 200是否可用  0:不可用，1：可用。
        /// </summary>
        [DataMember(Name = "canUse200")]
        public int CanUse200 { get; set; }


        #endregion

        /// <summary>
        /// 当前正在拍卖车辆序号
        /// </summary>
        [DataMember(Name = "auctionIndex")]
        public int AuctionIndex { get; set; }
    }


}
