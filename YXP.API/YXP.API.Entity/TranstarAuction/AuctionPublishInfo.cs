using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace YXP.API.Entity.TranstarAuction
{
    [Serializable]
    [DataContract]
   public class AuctionPublishInfo
    {
        #region 私有变量
        private Int64 _PublishId;
        private Int32 _CarSourceId;
        private Int32 _PublishProvinceId;
        private Int32 _PublishCityId;
        private Int32 _ActiveDays;
        private Decimal _AnticipantPrice;
        private Byte _AuctionStatus;
        private Byte _IsActive;
        private DateTime _StartTime;
        private DateTime _EndTime;
        private DateTime _StopTime;
        private DateTime _CreateTime;
        private Byte? _IsAcceptMsg;
        private Byte? _IsClosedEvaluation;
        private String _PublishSerial;
        private Decimal _StartPrice;
        private Int32? _PublishTvuId;
        private Decimal _LowestBidPrice;
        private Decimal _HighestBidprice;
        private Int32 _BidCount;
        private String _AgentFeeRule;
        private Decimal _PublishAgentFee;
        private Int32 _PublishAgentFeeType;
        private Int32 _BargainRule;
        private Int32 _BargainRuleType;
        private Int32 _ExpectTransferExpired;
        private Int32 _ExpectMoneyRecExpired;
        private Int32 _IsOpenProfitStat;
        private Int32 _BargainLimitMinutes;
        private DateTime? _BargainLimitTime;
        private Int32 _AuctionType;
        private Int32 _AuctionTypeCategory;
        private Decimal _ReservationPrice;
        private DateTime _PriceEndTime;
        private Int32 _IsAutoSelect;
        private Int32 _IsRelocation;
        private DateTime _PriceStopTime;
        private Int32? _TstSelectMode;
        private Int32 _CarDemand;
        private Int32 _TvaId;
        private Int32 _BidListCount;
        private Int32 _PriceStatus;
        private Int32 _StartPriceDownCount;
        private Decimal _SourceStartPrice;
        private String _SupportTstPayModes;
        private Int32 _AttentionCount;
        private Int32? _FinalTvaID;
        private Int32 _IsAgentTransfer;
        private Int32? _ReservationPriceRegistState;
        private Int32? _ReservationPriceRationality;
        private Decimal? _ReferenceReservationPrice;
        private DateTime? _ReservationPriceRegistTime;
        private Int32 _SysAddressID;
        private Int32 _IsLost;
        private Int32 _FormalitiesSide;
        private Int32? _IsGovAllowance;
        private Int32? _BelongType;
        private String _ReservationPriceOpPeople;
        private Decimal _BuyerHighestBidprice;
        private Int32 _ProductType;
        private Int32 _AuditStatus;
        private Int32 _CircletType;
        private Int32? _SpeciaPerformance;
        private Int32? _DocumentProvided;
        private Decimal _MyAgentFee;
        private Decimal _SellerFeeRule;
        private Decimal _BuyerFeeRule;
        private Decimal _BuyerAgentFee;
        private Decimal _HuCAgentFee;
        private Decimal _SellerAgentFee;
        private Decimal _SelfFee;
        private Decimal? _DisposalPrice;
        private DateTime? _TenderStopTime;
        private DateTime? _PriceStartTime;
        private Int32 _TenderCount;
        private Int32 _PublishType;
        private Decimal _YZHFee;
        private String _FeeCollections;
        private Decimal _ReservationPriceForBuyer;
        private Decimal _SpreadFee;
        private Int32? _PrincipalID;
        private DateTime _OperateStopTime;
        private Int32 _OperateStatus;
        private Decimal? _ThirdPartyPayFee;
        private Decimal _LowestFee;
        private Decimal _HighestFee;
        private String _SpecialExplain;
        #endregion

        # region 属性方法
        [Description("PublishId")]
        [DataMember]
        [Key]
        [Required]
        public Int64 PublishId
        {
            get { return _PublishId; }
            set { _PublishId = value; }
        }

        [Description("CarSourceId")]
        [DataMember]
        [Required]
        public Int32 CarSourceId
        {
            get { return _CarSourceId; }
            set { _CarSourceId = value; }
        }

        [Description("PublishProvinceId")]
        [DataMember]
        [Required]
        public Int32 PublishProvinceId
        {
            get { return _PublishProvinceId; }
            set { _PublishProvinceId = value; }
        }

        [Description("PublishCityId")]
        [DataMember]
        [Required]
        public Int32 PublishCityId
        {
            get { return _PublishCityId; }
            set { _PublishCityId = value; }
        }

        [Description("ActiveDays")]
        [DataMember]
        [Required]
        public Int32 ActiveDays
        {
            get { return _ActiveDays; }
            set { _ActiveDays = value; }
        }

        [Description("AnticipantPrice")]
        [DataMember]
        [Required]
        public Decimal AnticipantPrice
        {
            get { return _AnticipantPrice; }
            set { _AnticipantPrice = value; }
        }

        [Description("AuctionStatus")]
        [DataMember]
        [Required]
        public Byte AuctionStatus
        {
            get { return _AuctionStatus; }
            set { _AuctionStatus = value; }
        }

        [Description("IsActive")]
        [DataMember]
        [Required]
        public Byte IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        [Description("StartTime")]
        [DataMember]
        [Required]
        public DateTime StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }

        [Description("EndTime")]
        [DataMember]
        [Required]
        public DateTime EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }

        [Description("StopTime")]
        [DataMember]
        [Required]
        public DateTime StopTime
        {
            get { return _StopTime; }
            set { _StopTime = value; }
        }

        [Description("CreateTime")]
        [DataMember]
        [Required]
        public DateTime CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }

        [Description("IsAcceptMsg")]
        [DataMember]
        public Byte? IsAcceptMsg
        {
            get { return _IsAcceptMsg; }
            set { _IsAcceptMsg = value; }
        }

        [Description("IsClosedEvaluation")]
        [DataMember]
        public Byte? IsClosedEvaluation
        {
            get { return _IsClosedEvaluation; }
            set { _IsClosedEvaluation = value; }
        }

        [Description("PublishSerial")]
        [DataMember]
        public String PublishSerial
        {
            get { return _PublishSerial; }
            set { _PublishSerial = value; }
        }

        [Description("StartPrice")]
        [DataMember]
        [Required]
        public Decimal StartPrice
        {
            get { return _StartPrice; }
            set { _StartPrice = value; }
        }

        [Description("PublishTvuId")]
        [DataMember]
        public Int32? PublishTvuId
        {
            get { return _PublishTvuId; }
            set { _PublishTvuId = value; }
        }

        [Description("LowestBidPrice")]
        [DataMember]
        [Required]
        public Decimal LowestBidPrice
        {
            get { return _LowestBidPrice; }
            set { _LowestBidPrice = value; }
        }

        [Description("HighestBidprice")]
        [DataMember]
        [Required]
        public Decimal HighestBidprice
        {
            get { return _HighestBidprice; }
            set { _HighestBidprice = value; }
        }

        [Description("BidCount")]
        [DataMember]
        [Required]
        public Int32 BidCount
        {
            get { return _BidCount; }
            set { _BidCount = value; }
        }

        [Description("AgentFeeRule")]
        [DataMember]
        public String AgentFeeRule
        {
            get { return _AgentFeeRule; }
            set { _AgentFeeRule = value; }
        }

        [Description("PublishAgentFee")]
        [DataMember]
        [Required]
        public Decimal PublishAgentFee
        {
            get { return _PublishAgentFee; }
            set { _PublishAgentFee = value; }
        }

        [Description("PublishAgentFeeType")]
        [DataMember]
        [Required]
        public Int32 PublishAgentFeeType
        {
            get { return _PublishAgentFeeType; }
            set { _PublishAgentFeeType = value; }
        }

        [Description("BargainRule")]
        [DataMember]
        [Required]
        public Int32 BargainRule
        {
            get { return _BargainRule; }
            set { _BargainRule = value; }
        }

        [Description("BargainRuleType")]
        [DataMember]
        [Required]
        public Int32 BargainRuleType
        {
            get { return _BargainRuleType; }
            set { _BargainRuleType = value; }
        }

        [Description("ExpectTransferExpired")]
        [DataMember]
        [Required]
        public Int32 ExpectTransferExpired
        {
            get { return _ExpectTransferExpired; }
            set { _ExpectTransferExpired = value; }
        }

        [Description("ExpectMoneyRecExpired")]
        [DataMember]
        [Required]
        public Int32 ExpectMoneyRecExpired
        {
            get { return _ExpectMoneyRecExpired; }
            set { _ExpectMoneyRecExpired = value; }
        }

        [Description("IsOpenProfitStat")]
        [DataMember]
        [Required]
        public Int32 IsOpenProfitStat
        {
            get { return _IsOpenProfitStat; }
            set { _IsOpenProfitStat = value; }
        }

        [Description("BargainLimitMinutes")]
        [DataMember]
        [Required]
        public Int32 BargainLimitMinutes
        {
            get { return _BargainLimitMinutes; }
            set { _BargainLimitMinutes = value; }
        }

        [Description("BargainLimitTime")]
        [DataMember]
        public DateTime? BargainLimitTime
        {
            get { return _BargainLimitTime; }
            set { _BargainLimitTime = value; }
        }

        [Description("AuctionType")]
        [DataMember]
        [Required]
        public Int32 AuctionType
        {
            get { return _AuctionType; }
            set { _AuctionType = value; }
        }

        [Description("AuctionTypeCategory")]
        [DataMember]
        [Required]
        public Int32 AuctionTypeCategory
        {
            get { return _AuctionTypeCategory; }
            set { _AuctionTypeCategory = value; }
        }

        [Description("ReservationPrice")]
        [DataMember]
        [Required]
        public Decimal ReservationPrice
        {
            get { return _ReservationPrice; }
            set { _ReservationPrice = value; }
        }

        [Description("PriceEndTime")]
        [DataMember]
        [Required]
        public DateTime PriceEndTime
        {
            get { return _PriceEndTime; }
            set { _PriceEndTime = value; }
        }

        [Description("IsAutoSelect")]
        [DataMember]
        [Required]
        public Int32 IsAutoSelect
        {
            get { return _IsAutoSelect; }
            set { _IsAutoSelect = value; }
        }

        [Description("IsRelocation")]
        [DataMember]
        [Required]
        public Int32 IsRelocation
        {
            get { return _IsRelocation; }
            set { _IsRelocation = value; }
        }

        [Description("PriceStopTime")]
        [DataMember]
        [Required]
        public DateTime PriceStopTime
        {
            get { return _PriceStopTime; }
            set { _PriceStopTime = value; }
        }

        [Description("TstSelectMode")]
        [DataMember]
        public Int32? TstSelectMode
        {
            get { return _TstSelectMode; }
            set { _TstSelectMode = value; }
        }

        [Description("CarDemand")]
        [DataMember]
        [Required]
        public Int32 CarDemand
        {
            get { return _CarDemand; }
            set { _CarDemand = value; }
        }

        [Description("TvaId")]
        [DataMember]
        [Required]
        public Int32 TvaId
        {
            get { return _TvaId; }
            set { _TvaId = value; }
        }

        [Description("BidListCount")]
        [DataMember]
        [Required]
        public Int32 BidListCount
        {
            get { return _BidListCount; }
            set { _BidListCount = value; }
        }

        [Description("PriceStatus")]
        [DataMember]
        [Required]
        public Int32 PriceStatus
        {
            get { return _PriceStatus; }
            set { _PriceStatus = value; }
        }

        [Description("StartPriceDownCount")]
        [DataMember]
        [Required]
        public Int32 StartPriceDownCount
        {
            get { return _StartPriceDownCount; }
            set { _StartPriceDownCount = value; }
        }

        [Description("SourceStartPrice")]
        [DataMember]
        [Required]
        public Decimal SourceStartPrice
        {
            get { return _SourceStartPrice; }
            set { _SourceStartPrice = value; }
        }

        [Description("SupportTstPayModes")]
        [DataMember]
        public String SupportTstPayModes
        {
            get { return _SupportTstPayModes; }
            set { _SupportTstPayModes = value; }
        }

        [Description("AttentionCount")]
        [DataMember]
        [Required]
        public Int32 AttentionCount
        {
            get { return _AttentionCount; }
            set { _AttentionCount = value; }
        }

        [Description("FinalTvaID")]
        [DataMember]
        public Int32? FinalTvaID
        {
            get { return _FinalTvaID; }
            set { _FinalTvaID = value; }
        }

        [Description("IsAgentTransfer")]
        [DataMember]
        [Required]
        public Int32 IsAgentTransfer
        {
            get { return _IsAgentTransfer; }
            set { _IsAgentTransfer = value; }
        }

        [Description("ReservationPriceRegistState")]
        [DataMember]
        public Int32? ReservationPriceRegistState
        {
            get { return _ReservationPriceRegistState; }
            set { _ReservationPriceRegistState = value; }
        }

        [Description("ReservationPriceRationality")]
        [DataMember]
        public Int32? ReservationPriceRationality
        {
            get { return _ReservationPriceRationality; }
            set { _ReservationPriceRationality = value; }
        }

        [Description("ReferenceReservationPrice")]
        [DataMember]
        public Decimal? ReferenceReservationPrice
        {
            get { return _ReferenceReservationPrice; }
            set { _ReferenceReservationPrice = value; }
        }

        [Description("ReservationPriceRegistTime")]
        [DataMember]
        public DateTime? ReservationPriceRegistTime
        {
            get { return _ReservationPriceRegistTime; }
            set { _ReservationPriceRegistTime = value; }
        }

        [Description("SysAddressID")]
        [DataMember]
        [Required]
        public Int32 SysAddressID
        {
            get { return _SysAddressID; }
            set { _SysAddressID = value; }
        }

        [Description("IsLost")]
        [DataMember]
        [Required]
        public Int32 IsLost
        {
            get { return _IsLost; }
            set { _IsLost = value; }
        }

        [Description("FormalitiesSide")]
        [DataMember]
        [Required]
        public Int32 FormalitiesSide
        {
            get { return _FormalitiesSide; }
            set { _FormalitiesSide = value; }
        }

        [Description("IsGovAllowance")]
        [DataMember]
        public Int32? IsGovAllowance
        {
            get { return _IsGovAllowance; }
            set { _IsGovAllowance = value; }
        }

        [Description("BelongType")]
        [DataMember]
        public Int32? BelongType
        {
            get { return _BelongType; }
            set { _BelongType = value; }
        }

        [Description("ReservationPriceOpPeople")]
        [DataMember]
        public String ReservationPriceOpPeople
        {
            get { return _ReservationPriceOpPeople; }
            set { _ReservationPriceOpPeople = value; }
        }

        [Description("BuyerHighestBidprice")]
        [DataMember]
        [Required]
        public Decimal BuyerHighestBidprice
        {
            get { return _BuyerHighestBidprice; }
            set { _BuyerHighestBidprice = value; }
        }

        [Description("ProductType")]
        [DataMember]
        [Required]
        public Int32 ProductType
        {
            get { return _ProductType; }
            set { _ProductType = value; }
        }

        [Description("AuditStatus")]
        [DataMember]
        [Required]
        public Int32 AuditStatus
        {
            get { return _AuditStatus; }
            set { _AuditStatus = value; }
        }

        [Description("CircletType")]
        [DataMember]
        [Required]
        public Int32 CircletType
        {
            get { return _CircletType; }
            set { _CircletType = value; }
        }

        [Description("SpeciaPerformance")]
        [DataMember]
        public Int32? SpeciaPerformance
        {
            get { return _SpeciaPerformance; }
            set { _SpeciaPerformance = value; }
        }

        [Description("DocumentProvided")]
        [DataMember]
        public Int32? DocumentProvided
        {
            get { return _DocumentProvided; }
            set { _DocumentProvided = value; }
        }

        [Description("MyAgentFee")]
        [DataMember]
        [Required]
        public Decimal MyAgentFee
        {
            get { return _MyAgentFee; }
            set { _MyAgentFee = value; }
        }

        [Description("SellerFeeRule")]
        [DataMember]
        [Required]
        public Decimal SellerFeeRule
        {
            get { return _SellerFeeRule; }
            set { _SellerFeeRule = value; }
        }

        [Description("BuyerFeeRule")]
        [DataMember]
        [Required]
        public Decimal BuyerFeeRule
        {
            get { return _BuyerFeeRule; }
            set { _BuyerFeeRule = value; }
        }

        [Description("BuyerAgentFee")]
        [DataMember]
        [Required]
        public Decimal BuyerAgentFee
        {
            get { return _BuyerAgentFee; }
            set { _BuyerAgentFee = value; }
        }

        [Description("HuCAgentFee")]
        [DataMember]
        [Required]
        public Decimal HuCAgentFee
        {
            get { return _HuCAgentFee; }
            set { _HuCAgentFee = value; }
        }

        [Description("SellerAgentFee")]
        [DataMember]
        [Required]
        public Decimal SellerAgentFee
        {
            get { return _SellerAgentFee; }
            set { _SellerAgentFee = value; }
        }

        [Description("SelfFee")]
        [DataMember]
        [Required]
        public Decimal SelfFee
        {
            get { return _SelfFee; }
            set { _SelfFee = value; }
        }

        [Description("DisposalPrice")]
        [DataMember]
        public Decimal? DisposalPrice
        {
            get { return _DisposalPrice; }
            set { _DisposalPrice = value; }
        }

        [Description("TenderStopTime")]
        [DataMember]
        public DateTime? TenderStopTime
        {
            get { return _TenderStopTime; }
            set { _TenderStopTime = value; }
        }

        [Description("PriceStartTime")]
        [DataMember]
        public DateTime? PriceStartTime
        {
            get { return _PriceStartTime; }
            set { _PriceStartTime = value; }
        }

        [Description("TenderCount")]
        [DataMember]
        [Required]
        public Int32 TenderCount
        {
            get { return _TenderCount; }
            set { _TenderCount = value; }
        }

        [Description("PublishType")]
        [DataMember]
        [Required]
        public Int32 PublishType
        {
            get { return _PublishType; }
            set { _PublishType = value; }
        }

        [Description("YZHFee")]
        [DataMember]
        [Required]
        public Decimal YZHFee
        {
            get { return _YZHFee; }
            set { _YZHFee = value; }
        }

        [Description("FeeCollections")]
        [DataMember]
        [Required]
        public String FeeCollections
        {
            get { return _FeeCollections; }
            set { _FeeCollections = value; }
        }

        [Description("ReservationPriceForBuyer")]
        [DataMember]
        [Required]
        public Decimal ReservationPriceForBuyer
        {
            get { return _ReservationPriceForBuyer; }
            set { _ReservationPriceForBuyer = value; }
        }

        [Description("SpreadFee")]
        [DataMember]
        [Required]
        public Decimal SpreadFee
        {
            get { return _SpreadFee; }
            set { _SpreadFee = value; }
        }

        [Description("PrincipalID")]
        [DataMember]
        public Int32? PrincipalID
        {
            get { return _PrincipalID; }
            set { _PrincipalID = value; }
        }

        [Description("OperateStopTime")]
        [DataMember]
        [Required]
        public DateTime OperateStopTime
        {
            get { return _OperateStopTime; }
            set { _OperateStopTime = value; }
        }

        [Description("OperateStatus")]
        [DataMember]
        [Required]
        public Int32 OperateStatus
        {
            get { return _OperateStatus; }
            set { _OperateStatus = value; }
        }

        [Description("ThirdPartyPayFee")]
        [DataMember]
        public Decimal? ThirdPartyPayFee
        {
            get { return _ThirdPartyPayFee; }
            set { _ThirdPartyPayFee = value; }
        }

        [Description("LowestFee")]
        [DataMember]
        [Required]
        public Decimal LowestFee
        {
            get { return _LowestFee; }
            set { _LowestFee = value; }
        }

        [Description("HighestFee")]
        [DataMember]
        [Required]
        public Decimal HighestFee
        {
            get { return _HighestFee; }
            set { _HighestFee = value; }
        }

        [Description("SpecialExplain")]
        [DataMember]
        public String SpecialExplain
        {
            get { return _SpecialExplain; }
            set { _SpecialExplain = value; }
        }

        #endregion
    }
}
