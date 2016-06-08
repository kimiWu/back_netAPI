using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace YXP.API.Entity.TranstarAuction
{
	[Serializable]
	[DataContract]
	public partial class TranstarAuctionCarSource
	{
		#region 私有变量
		private Int32 _CarSourceID;
		private Int32 _ProducerId;
		private Int32 _BrandId;
		private Int32 _CarTypeId;
		private String _CarIdentityNumber = "";
		private Byte _Transmission;
		private Decimal _Exhaust;
		private String _CarBodyColor = "";
		private Int32 _Mileage;
		private String _CarConfigInfo = "";
		private Byte _ExchangeWithLicense;
		private Int32 _CityId;
		private Int32 _ProvinceId;
		private Int32 _LicenseCityId;
		private Int32 _LicenseProvinceId;
		private DateTime _GetLicenseDate;
		private Byte _CarUseType;
		private DateTime? _RegistDate;
		private Byte _IsEffluentYellow;
		private Byte _IsHaveMaintenance;
		private DateTime _CarShipTaxExpireDate;
		private Byte _IsHavePurchaseTax;
		private DateTime _AnnualDetectionDate;
		private Byte _IsHaveFoAssurance;
		private DateTime? _FoAssuranceDate;
		private Byte _IsHaveComAssurance;
		private DateTime? _ComAssuranceDate;
		private Byte _IsHaveAssuranceRecord;
		private Int32 _PaintDesc;
		private Int32 _SurfaceDesc;
		private Int32 _SeriousAccidentDesc;
		private Int32 _EngineDesc;
		private Int32 _TransmissionDesc;
		private Int32 _OtherFileDesc;
		private Byte _CarStatus;
		private String _AdditionalDesc = "";
		private Int32 _TvaID;
		private DateTime _CreateTime;
		private DateTime _ModifyTime;
		private DateTime? _SaledTime;
		private Byte _IsActive;
		private Int32 _TvuID;
		private String _LeftFront45 = "";
		private String _RightBehind45 = "";
		private String _EngineCabin = "";
		private String _InnerInstrument = "";
		private String _InnerBackChair = "";
		private String _SideFace = "";
		private Int32? _ImageCount;
		private Int32 _MasterBrandId;
		private String _CarCheckReport = "";
		private String _PaintRemark = "";
		private String _SurfaceRemark = "";
		private String _SeriousAccidentRemark = "";
		private String _EngineRemark = "";
		private String _TransmissionRemark = "";
		private String _OtherFileRemark = "";
		private String _HuoYanReportUrl = "";
		private Int32 _EffluentAdd;
		private Int32 _CarSourceOwner;
		private String _DamageType = "";
		private String _Starter = "";
		private String _StarterDesc = "";
		private String _ShockAbsorber = "";
		private String _ShockAbsorberDesc = "";
		private String _Chassis = "";
		private String _ChassisDesc = "";
		private String _Brake = "";
		private String _BrakeDesc = "";
		private String _ExhaustSystem = "";
		private String _ExhaustSystemDesc = "";
		private String _ElectricalSystem = "";
		private String _ElectricalSystemDesc = "";
		private String _SupplementInfo = "";
		private String _NewEngine = "";
		private String _NewEngineDesc = "";
		private String _NewTransmission = "";
		private String _NewTransmissionDesc = "";
		private Decimal _OrginalPrice;
		private Int32 _IsNewCar;
		private Decimal? _PurchasePrice;
		private Int32 _IsFrameNum;
		private Int32 _IsChangeEngineNum;
		private DateTime? _LastTransferDate;
		private Decimal? _ComAssurancePrice;
		private String _EngineNum = "";
		private String _DetectOuterInfo = "";
		private String _DetectInnerInfo = "";
		private String _DetectSkeletonInfo = "";
		private String _OuterSheetMetal = "";
		private String _SkeletonSheetMetal = "";
		private String _LicenseNumber = "";
		private String _PersonalityInfo = "";
		private String _AttachmentInfo = "";
		private String _DiagData = "";
		private String _Explain = "";
		private Int32? _Owner;
		private Int32 _CarState;
		private Int32? _DrivingCertification;
		private Int32? _Registration;
		private Int32? _BuyingReceipt;
		private Int32? _TransferInvoice;
		private Int32? _TransferCount;
		private Int32? _ExplainBook;
		private Int32? _CarKeys;
		private Int32? _MaintenanceKM;
		private Int32? _LicenseCarStatue;
		private String _CarOriginalColor = "";
		private Int32? _FuelType;
		private String _NoticeNumber = "";
		private Int32? _IsRefit;
		private String _RefitContent = "";
		private String _ChairContent = "";
		private Int32? _CityAreaId;
		private String _GasbagContent = "";
		private Int32? _IsHaveCarShiptax;
		private Int32? _IsNewData;
		private String _Attachment = "";
		private Int32? _Turbocharger;
		private Int32? _IsHaveCard;
		private String _CarBody = "";
		private Int32? _NewCarWarranty;
		private Int32? _PracticalMileage;
		private Boolean _IsButlerService;
		private Int32? _Vehicletype;
		private Int32? _OwnTvaID;
		private String _ConditionGrade = "";
		private DateTime? _TaskDate;
		private String _ParkingNumber = "";
		private Int32? _TransferType;
		private Decimal? _Fee;
		private Decimal? _DealerPrice;
		private String _FormalitiesRetroactive = "";
		private String _NewCarIdentityNumber = "";
		private String _NewCarOwnerName = "";
		private String _OldCarOwnerName = "";
		private Int32? _CarLocation;
		private String _ConditionGradeSmall = "";
		private Int32 _SelfInsurance;
		private DateTime? _AnnualValidity;
		private Int32 _SteeringAssistStatus;
		private String _SteeringAssistRemark = "";
		private Int32 _EngineOilStatus;
		private String _EngineOilRemark = "";
		private Int32 _AntifreezeStatus;
		private String _AntifreezeRemark = "";
		private String _PresentStatus = "";
		private String _RepairStatus = "";
		private Int32 _PowerOil;
		private Int32 _BrakeOil;
		private Int32 _RoadTest;
		private String _PaintRepair = "";
		private Int32 _PeccancyResponsible;
		private Int32 _PeccancysScore;
		private Int32 _PeccancysPrice;
		private Int32 _PeccancysDays;
		private Int32 _SourceFrom;
		private Int32 _IsBubbleCar;
		private Int32 _LeakCheckStatus;
		private String _LeakCheckRemark = "";
		private Int32 _SmokeCheckStatus;
		private String _SmokeCheckRemark = "";
		private Int32 _WorkCheckStatus;
		private String _WorkCheckRemark = "";
		private Int32 _AbnormalSoundStatus;
		private String _AbnormalSoundRemark = "";
		private Int32 _ZuoGongCheckStatus;
		private String _ZuoGongCheckRemark = "";
		private Int32 _CoolingCheckStatus;
		private String _CoolingCheckRemark = "";
		private String _PowerOilRemark = "";
		private String _BrakeOilRemark = "";
		private Int32 _XcpCarId;
		private String _CarConfigKey = "";
		private Int32 _JqSelfInsurance;
		private String _brandname = "";
		private String _seriesname = "";
		private String _modelname = "";
		private Int32? _DetectTvuid;
		private Int32? _GuideTvuid;
		private String _GuideTel = "";
		private String _AppearancePaint = "";
		private String _SkeletonPaint = "";
		private Int32 _BatteryCheckStatus;
		private String _BatteryCheckRemark = "";
		private Int32 _BeltCheckStatus;
		private String _BeltCheckRemark = "";
		private String _RedbookName = "";
		private Int32 _DateType;
		private Int32? _certificatecard;
		private Int32? _factorycode;
		private Int32? _newcarphoto;
		private Int32? _maintainmanual;
		private Int32? _thenewcar;
		private Int32? _ReportType;
		private String _Result = "";
		private String _ConditionGradeApllo = "";
		private String _RemarkApllo = "";
		#endregion

		# region 属性方法
		[Description("")]
		[DataMember]
		[Key]
		[Required]
		public Int32 CarSourceID
		{
			get { return _CarSourceID;}
			set { _CarSourceID = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 ProducerId
		{
			get { return _ProducerId;}
			set { _ProducerId = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 BrandId
		{
			get { return _BrandId;}
			set { _BrandId = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 CarTypeId
		{
			get { return _CarTypeId;}
			set { _CarTypeId = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String CarIdentityNumber
		{
			get { return _CarIdentityNumber;}
			set { _CarIdentityNumber = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Byte Transmission
		{
			get { return _Transmission;}
			set { _Transmission = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Decimal Exhaust
		{
			get { return _Exhaust;}
			set { _Exhaust = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String CarBodyColor
		{
			get { return _CarBodyColor;}
			set { _CarBodyColor = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 Mileage
		{
			get { return _Mileage;}
			set { _Mileage = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String CarConfigInfo
		{
			get { return _CarConfigInfo;}
			set { _CarConfigInfo = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Byte ExchangeWithLicense
		{
			get { return _ExchangeWithLicense;}
			set { _ExchangeWithLicense = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 CityId
		{
			get { return _CityId;}
			set { _CityId = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 ProvinceId
		{
			get { return _ProvinceId;}
			set { _ProvinceId = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 LicenseCityId
		{
			get { return _LicenseCityId;}
			set { _LicenseCityId = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 LicenseProvinceId
		{
			get { return _LicenseProvinceId;}
			set { _LicenseProvinceId = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public DateTime GetLicenseDate
		{
			get { return _GetLicenseDate;}
			set { _GetLicenseDate = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Byte CarUseType
		{
			get { return _CarUseType;}
			set { _CarUseType = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? RegistDate
		{
			get { return _RegistDate;}
			set { _RegistDate = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Byte IsEffluentYellow
		{
			get { return _IsEffluentYellow;}
			set { _IsEffluentYellow = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Byte IsHaveMaintenance
		{
			get { return _IsHaveMaintenance;}
			set { _IsHaveMaintenance = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public DateTime CarShipTaxExpireDate
		{
			get { return _CarShipTaxExpireDate;}
			set { _CarShipTaxExpireDate = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Byte IsHavePurchaseTax
		{
			get { return _IsHavePurchaseTax;}
			set { _IsHavePurchaseTax = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public DateTime AnnualDetectionDate
		{
			get { return _AnnualDetectionDate;}
			set { _AnnualDetectionDate = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Byte IsHaveFoAssurance
		{
			get { return _IsHaveFoAssurance;}
			set { _IsHaveFoAssurance = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? FoAssuranceDate
		{
			get { return _FoAssuranceDate;}
			set { _FoAssuranceDate = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Byte IsHaveComAssurance
		{
			get { return _IsHaveComAssurance;}
			set { _IsHaveComAssurance = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? ComAssuranceDate
		{
			get { return _ComAssuranceDate;}
			set { _ComAssuranceDate = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Byte IsHaveAssuranceRecord
		{
			get { return _IsHaveAssuranceRecord;}
			set { _IsHaveAssuranceRecord = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 PaintDesc
		{
			get { return _PaintDesc;}
			set { _PaintDesc = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 SurfaceDesc
		{
			get { return _SurfaceDesc;}
			set { _SurfaceDesc = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 SeriousAccidentDesc
		{
			get { return _SeriousAccidentDesc;}
			set { _SeriousAccidentDesc = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 EngineDesc
		{
			get { return _EngineDesc;}
			set { _EngineDesc = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 TransmissionDesc
		{
			get { return _TransmissionDesc;}
			set { _TransmissionDesc = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 OtherFileDesc
		{
			get { return _OtherFileDesc;}
			set { _OtherFileDesc = value;}
		}

		[Description("1-未出售 2-已出售")]
		[DataMember]
		[Required]
		public Byte CarStatus
		{
			get { return _CarStatus;}
			set { _CarStatus = value;}
		}

		[Description("")]
		[DataMember]
		public String AdditionalDesc
		{
			get { return _AdditionalDesc;}
			set { _AdditionalDesc = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 TvaID
		{
			get { return _TvaID;}
			set { _TvaID = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public DateTime CreateTime
		{
			get { return _CreateTime;}
			set { _CreateTime = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public DateTime ModifyTime
		{
			get { return _ModifyTime;}
			set { _ModifyTime = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? SaledTime
		{
			get { return _SaledTime;}
			set { _SaledTime = value;}
		}

		[Description("1-正常 2-删除")]
		[DataMember]
		[Required]
		public Byte IsActive
		{
			get { return _IsActive;}
			set { _IsActive = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 TvuID
		{
			get { return _TvuID;}
			set { _TvuID = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String LeftFront45
		{
			get { return _LeftFront45;}
			set { _LeftFront45 = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String RightBehind45
		{
			get { return _RightBehind45;}
			set { _RightBehind45 = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String EngineCabin
		{
			get { return _EngineCabin;}
			set { _EngineCabin = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String InnerInstrument
		{
			get { return _InnerInstrument;}
			set { _InnerInstrument = value;}
		}

		[Description("")]
		[DataMember]
		public String InnerBackChair
		{
			get { return _InnerBackChair;}
			set { _InnerBackChair = value;}
		}

		[Description("")]
		[DataMember]
		public String SideFace
		{
			get { return _SideFace;}
			set { _SideFace = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? ImageCount
		{
			get { return _ImageCount;}
			set { _ImageCount = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 MasterBrandId
		{
			get { return _MasterBrandId;}
			set { _MasterBrandId = value;}
		}

		[Description("")]
		[DataMember]
		public String CarCheckReport
		{
			get { return _CarCheckReport;}
			set { _CarCheckReport = value;}
		}

		[Description("")]
		[DataMember]
		public String PaintRemark
		{
			get { return _PaintRemark;}
			set { _PaintRemark = value;}
		}

		[Description("")]
		[DataMember]
		public String SurfaceRemark
		{
			get { return _SurfaceRemark;}
			set { _SurfaceRemark = value;}
		}

		[Description("")]
		[DataMember]
		public String SeriousAccidentRemark
		{
			get { return _SeriousAccidentRemark;}
			set { _SeriousAccidentRemark = value;}
		}

		[Description("")]
		[DataMember]
		public String EngineRemark
		{
			get { return _EngineRemark;}
			set { _EngineRemark = value;}
		}

		[Description("")]
		[DataMember]
		public String TransmissionRemark
		{
			get { return _TransmissionRemark;}
			set { _TransmissionRemark = value;}
		}

		[Description("")]
		[DataMember]
		public String OtherFileRemark
		{
			get { return _OtherFileRemark;}
			set { _OtherFileRemark = value;}
		}

		[Description("")]
		[DataMember]
		public String HuoYanReportUrl
		{
			get { return _HuoYanReportUrl;}
			set { _HuoYanReportUrl = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 EffluentAdd
		{
			get { return _EffluentAdd;}
			set { _EffluentAdd = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 CarSourceOwner
		{
			get { return _CarSourceOwner;}
			set { _CarSourceOwner = value;}
		}

		[Description("")]
		[DataMember]
		public String DamageType
		{
			get { return _DamageType;}
			set { _DamageType = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String Starter
		{
			get { return _Starter;}
			set { _Starter = value;}
		}

		[Description("")]
		[DataMember]
		public String StarterDesc
		{
			get { return _StarterDesc;}
			set { _StarterDesc = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String ShockAbsorber
		{
			get { return _ShockAbsorber;}
			set { _ShockAbsorber = value;}
		}

		[Description("")]
		[DataMember]
		public String ShockAbsorberDesc
		{
			get { return _ShockAbsorberDesc;}
			set { _ShockAbsorberDesc = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String Chassis
		{
			get { return _Chassis;}
			set { _Chassis = value;}
		}

		[Description("")]
		[DataMember]
		public String ChassisDesc
		{
			get { return _ChassisDesc;}
			set { _ChassisDesc = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String Brake
		{
			get { return _Brake;}
			set { _Brake = value;}
		}

		[Description("")]
		[DataMember]
		public String BrakeDesc
		{
			get { return _BrakeDesc;}
			set { _BrakeDesc = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String ExhaustSystem
		{
			get { return _ExhaustSystem;}
			set { _ExhaustSystem = value;}
		}

		[Description("")]
		[DataMember]
		public String ExhaustSystemDesc
		{
			get { return _ExhaustSystemDesc;}
			set { _ExhaustSystemDesc = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String ElectricalSystem
		{
			get { return _ElectricalSystem;}
			set { _ElectricalSystem = value;}
		}

		[Description("")]
		[DataMember]
		public String ElectricalSystemDesc
		{
			get { return _ElectricalSystemDesc;}
			set { _ElectricalSystemDesc = value;}
		}

		[Description("")]
		[DataMember]
		public String SupplementInfo
		{
			get { return _SupplementInfo;}
			set { _SupplementInfo = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String NewEngine
		{
			get { return _NewEngine;}
			set { _NewEngine = value;}
		}

		[Description("")]
		[DataMember]
		public String NewEngineDesc
		{
			get { return _NewEngineDesc;}
			set { _NewEngineDesc = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String NewTransmission
		{
			get { return _NewTransmission;}
			set { _NewTransmission = value;}
		}

		[Description("")]
		[DataMember]
		public String NewTransmissionDesc
		{
			get { return _NewTransmissionDesc;}
			set { _NewTransmissionDesc = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Decimal OrginalPrice
		{
			get { return _OrginalPrice;}
			set { _OrginalPrice = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 IsNewCar
		{
			get { return _IsNewCar;}
			set { _IsNewCar = value;}
		}

		[Description("")]
		[DataMember]
		public Decimal? PurchasePrice
		{
			get { return _PurchasePrice;}
			set { _PurchasePrice = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 IsFrameNum
		{
			get { return _IsFrameNum;}
			set { _IsFrameNum = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 IsChangeEngineNum
		{
			get { return _IsChangeEngineNum;}
			set { _IsChangeEngineNum = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? LastTransferDate
		{
			get { return _LastTransferDate;}
			set { _LastTransferDate = value;}
		}

		[Description("")]
		[DataMember]
		public Decimal? ComAssurancePrice
		{
			get { return _ComAssurancePrice;}
			set { _ComAssurancePrice = value;}
		}

		[Description("")]
		[DataMember]
		public String EngineNum
		{
			get { return _EngineNum;}
			set { _EngineNum = value;}
		}

		[Description("")]
		[DataMember]
		public String DetectOuterInfo
		{
			get { return _DetectOuterInfo;}
			set { _DetectOuterInfo = value;}
		}

		[Description("")]
		[DataMember]
		public String DetectInnerInfo
		{
			get { return _DetectInnerInfo;}
			set { _DetectInnerInfo = value;}
		}

		[Description("")]
		[DataMember]
		public String DetectSkeletonInfo
		{
			get { return _DetectSkeletonInfo;}
			set { _DetectSkeletonInfo = value;}
		}

		[Description("")]
		[DataMember]
		public String OuterSheetMetal
		{
			get { return _OuterSheetMetal;}
			set { _OuterSheetMetal = value;}
		}

		[Description("")]
		[DataMember]
		public String SkeletonSheetMetal
		{
			get { return _SkeletonSheetMetal;}
			set { _SkeletonSheetMetal = value;}
		}

		[Description("")]
		[DataMember]
		public String LicenseNumber
		{
			get { return _LicenseNumber;}
			set { _LicenseNumber = value;}
		}

		[Description("")]
		[DataMember]
		public String PersonalityInfo
		{
			get { return _PersonalityInfo;}
			set { _PersonalityInfo = value;}
		}

		[Description("")]
		[DataMember]
		public String AttachmentInfo
		{
			get { return _AttachmentInfo;}
			set { _AttachmentInfo = value;}
		}

		[Description("")]
		[DataMember]
		public String DiagData
		{
			get { return _DiagData;}
			set { _DiagData = value;}
		}

		[Description("")]
		[DataMember]
		public String Explain
		{
			get { return _Explain;}
			set { _Explain = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? Owner
		{
			get { return _Owner;}
			set { _Owner = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 CarState
		{
			get { return _CarState;}
			set { _CarState = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? DrivingCertification
		{
			get { return _DrivingCertification;}
			set { _DrivingCertification = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? Registration
		{
			get { return _Registration;}
			set { _Registration = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? BuyingReceipt
		{
			get { return _BuyingReceipt;}
			set { _BuyingReceipt = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? TransferInvoice
		{
			get { return _TransferInvoice;}
			set { _TransferInvoice = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? TransferCount
		{
			get { return _TransferCount;}
			set { _TransferCount = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? ExplainBook
		{
			get { return _ExplainBook;}
			set { _ExplainBook = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? CarKeys
		{
			get { return _CarKeys;}
			set { _CarKeys = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? MaintenanceKM
		{
			get { return _MaintenanceKM;}
			set { _MaintenanceKM = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? LicenseCarStatue
		{
			get { return _LicenseCarStatue;}
			set { _LicenseCarStatue = value;}
		}

		[Description("")]
		[DataMember]
		public String CarOriginalColor
		{
			get { return _CarOriginalColor;}
			set { _CarOriginalColor = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? FuelType
		{
			get { return _FuelType;}
			set { _FuelType = value;}
		}

		[Description("")]
		[DataMember]
		public String NoticeNumber
		{
			get { return _NoticeNumber;}
			set { _NoticeNumber = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? IsRefit
		{
			get { return _IsRefit;}
			set { _IsRefit = value;}
		}

		[Description("")]
		[DataMember]
		public String RefitContent
		{
			get { return _RefitContent;}
			set { _RefitContent = value;}
		}

		[Description("")]
		[DataMember]
		public String ChairContent
		{
			get { return _ChairContent;}
			set { _ChairContent = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? CityAreaId
		{
			get { return _CityAreaId;}
			set { _CityAreaId = value;}
		}

		[Description("")]
		[DataMember]
		public String GasbagContent
		{
			get { return _GasbagContent;}
			set { _GasbagContent = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? IsHaveCarShiptax
		{
			get { return _IsHaveCarShiptax;}
			set { _IsHaveCarShiptax = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? IsNewData
		{
			get { return _IsNewData;}
			set { _IsNewData = value;}
		}

		[Description("")]
		[DataMember]
		public String Attachment
		{
			get { return _Attachment;}
			set { _Attachment = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? Turbocharger
		{
			get { return _Turbocharger;}
			set { _Turbocharger = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? IsHaveCard
		{
			get { return _IsHaveCard;}
			set { _IsHaveCard = value;}
		}

		[Description("")]
		[DataMember]
		public String CarBody
		{
			get { return _CarBody;}
			set { _CarBody = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? NewCarWarranty
		{
			get { return _NewCarWarranty;}
			set { _NewCarWarranty = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? PracticalMileage
		{
			get { return _PracticalMileage;}
			set { _PracticalMileage = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Boolean IsButlerService
		{
			get { return _IsButlerService;}
			set { _IsButlerService = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? Vehicletype
		{
			get { return _Vehicletype;}
			set { _Vehicletype = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? OwnTvaID
		{
			get { return _OwnTvaID;}
			set { _OwnTvaID = value;}
		}

		[Description("")]
		[DataMember]
		public String ConditionGrade
		{
			get { return _ConditionGrade;}
			set { _ConditionGrade = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? TaskDate
		{
			get { return _TaskDate;}
			set { _TaskDate = value;}
		}

		[Description("")]
		[DataMember]
		public String ParkingNumber
		{
			get { return _ParkingNumber;}
			set { _ParkingNumber = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? TransferType
		{
			get { return _TransferType;}
			set { _TransferType = value;}
		}

		[Description("")]
		[DataMember]
		public Decimal? Fee
		{
			get { return _Fee;}
			set { _Fee = value;}
		}

		[Description("")]
		[DataMember]
		public Decimal? DealerPrice
		{
			get { return _DealerPrice;}
			set { _DealerPrice = value;}
		}

		[Description("")]
		[DataMember]
		public String FormalitiesRetroactive
		{
			get { return _FormalitiesRetroactive;}
			set { _FormalitiesRetroactive = value;}
		}

		[Description("NewCarIdentityNumber")]
		[DataMember]
		[Required]
		public String NewCarIdentityNumber
		{
			get { return _NewCarIdentityNumber;}
			set { _NewCarIdentityNumber = value;}
		}

		[Description("NewCarOwnerName")]
		[DataMember]
		[Required]
		public String NewCarOwnerName
		{
			get { return _NewCarOwnerName;}
			set { _NewCarOwnerName = value;}
		}

		[Description("OldCarOwnerName")]
		[DataMember]
		[Required]
		public String OldCarOwnerName
		{
			get { return _OldCarOwnerName;}
			set { _OldCarOwnerName = value;}
		}

		[Description("CarLocation")]
		[DataMember]
		public Int32? CarLocation
		{
			get { return _CarLocation;}
			set { _CarLocation = value;}
		}

		[Description("ConditionGradeSmall")]
		[DataMember]
		public String ConditionGradeSmall
		{
			get { return _ConditionGradeSmall;}
			set { _ConditionGradeSmall = value;}
		}

		[Description("SelfInsurance")]
		[DataMember]
		[Required]
		public Int32 SelfInsurance
		{
			get { return _SelfInsurance;}
			set { _SelfInsurance = value;}
		}

		[Description("AnnualValidity")]
		[DataMember]
		public DateTime? AnnualValidity
		{
			get { return _AnnualValidity;}
			set { _AnnualValidity = value;}
		}

		[Description("SteeringAssistStatus")]
		[DataMember]
		[Required]
		public Int32 SteeringAssistStatus
		{
			get { return _SteeringAssistStatus;}
			set { _SteeringAssistStatus = value;}
		}

		[Description("SteeringAssistRemark")]
		[DataMember]
		public String SteeringAssistRemark
		{
			get { return _SteeringAssistRemark;}
			set { _SteeringAssistRemark = value;}
		}

		[Description("EngineOilStatus")]
		[DataMember]
		[Required]
		public Int32 EngineOilStatus
		{
			get { return _EngineOilStatus;}
			set { _EngineOilStatus = value;}
		}

		[Description("EngineOilRemark")]
		[DataMember]
		public String EngineOilRemark
		{
			get { return _EngineOilRemark;}
			set { _EngineOilRemark = value;}
		}

		[Description("AntifreezeStatus")]
		[DataMember]
		[Required]
		public Int32 AntifreezeStatus
		{
			get { return _AntifreezeStatus;}
			set { _AntifreezeStatus = value;}
		}

		[Description("AntifreezeRemark")]
		[DataMember]
		public String AntifreezeRemark
		{
			get { return _AntifreezeRemark;}
			set { _AntifreezeRemark = value;}
		}

		[Description("PresentStatus")]
		[DataMember]
		public String PresentStatus
		{
			get { return _PresentStatus;}
			set { _PresentStatus = value;}
		}

		[Description("RepairStatus")]
		[DataMember]
		public String RepairStatus
		{
			get { return _RepairStatus;}
			set { _RepairStatus = value;}
		}

		[Description("PowerOil")]
		[DataMember]
		[Required]
		public Int32 PowerOil
		{
			get { return _PowerOil;}
			set { _PowerOil = value;}
		}

		[Description("BrakeOil")]
		[DataMember]
		[Required]
		public Int32 BrakeOil
		{
			get { return _BrakeOil;}
			set { _BrakeOil = value;}
		}

		[Description("RoadTest")]
		[DataMember]
		[Required]
		public Int32 RoadTest
		{
			get { return _RoadTest;}
			set { _RoadTest = value;}
		}

		[Description("PaintRepair")]
		[DataMember]
		public String PaintRepair
		{
			get { return _PaintRepair;}
			set { _PaintRepair = value;}
		}

		[Description("PeccancyResponsible")]
		[DataMember]
		[Required]
		public Int32 PeccancyResponsible
		{
			get { return _PeccancyResponsible;}
			set { _PeccancyResponsible = value;}
		}

		[Description("PeccancysScore")]
		[DataMember]
		[Required]
		public Int32 PeccancysScore
		{
			get { return _PeccancysScore;}
			set { _PeccancysScore = value;}
		}

		[Description("PeccancysPrice")]
		[DataMember]
		[Required]
		public Int32 PeccancysPrice
		{
			get { return _PeccancysPrice;}
			set { _PeccancysPrice = value;}
		}

		[Description("PeccancysDays")]
		[DataMember]
		[Required]
		public Int32 PeccancysDays
		{
			get { return _PeccancysDays;}
			set { _PeccancysDays = value;}
		}

		[Description("SourceFrom")]
		[DataMember]
		[Required]
		public Int32 SourceFrom
		{
			get { return _SourceFrom;}
			set { _SourceFrom = value;}
		}

		[Description("IsBubbleCar")]
		[DataMember]
		[Required]
		public Int32 IsBubbleCar
		{
			get { return _IsBubbleCar;}
			set { _IsBubbleCar = value;}
		}

		[Description("LeakCheckStatus")]
		[DataMember]
		[Required]
		public Int32 LeakCheckStatus
		{
			get { return _LeakCheckStatus;}
			set { _LeakCheckStatus = value;}
		}

		[Description("LeakCheckRemark")]
		[DataMember]
		public String LeakCheckRemark
		{
			get { return _LeakCheckRemark;}
			set { _LeakCheckRemark = value;}
		}

		[Description("SmokeCheckStatus")]
		[DataMember]
		[Required]
		public Int32 SmokeCheckStatus
		{
			get { return _SmokeCheckStatus;}
			set { _SmokeCheckStatus = value;}
		}

		[Description("SmokeCheckRemark")]
		[DataMember]
		public String SmokeCheckRemark
		{
			get { return _SmokeCheckRemark;}
			set { _SmokeCheckRemark = value;}
		}

		[Description("WorkCheckStatus")]
		[DataMember]
		[Required]
		public Int32 WorkCheckStatus
		{
			get { return _WorkCheckStatus;}
			set { _WorkCheckStatus = value;}
		}

		[Description("WorkCheckRemark")]
		[DataMember]
		public String WorkCheckRemark
		{
			get { return _WorkCheckRemark;}
			set { _WorkCheckRemark = value;}
		}

		[Description("AbnormalSoundStatus")]
		[DataMember]
		[Required]
		public Int32 AbnormalSoundStatus
		{
			get { return _AbnormalSoundStatus;}
			set { _AbnormalSoundStatus = value;}
		}

		[Description("AbnormalSoundRemark")]
		[DataMember]
		public String AbnormalSoundRemark
		{
			get { return _AbnormalSoundRemark;}
			set { _AbnormalSoundRemark = value;}
		}

		[Description("ZuoGongCheckStatus")]
		[DataMember]
		[Required]
		public Int32 ZuoGongCheckStatus
		{
			get { return _ZuoGongCheckStatus;}
			set { _ZuoGongCheckStatus = value;}
		}

		[Description("ZuoGongCheckRemark")]
		[DataMember]
		public String ZuoGongCheckRemark
		{
			get { return _ZuoGongCheckRemark;}
			set { _ZuoGongCheckRemark = value;}
		}

		[Description("CoolingCheckStatus")]
		[DataMember]
		[Required]
		public Int32 CoolingCheckStatus
		{
			get { return _CoolingCheckStatus;}
			set { _CoolingCheckStatus = value;}
		}

		[Description("CoolingCheckRemark")]
		[DataMember]
		public String CoolingCheckRemark
		{
			get { return _CoolingCheckRemark;}
			set { _CoolingCheckRemark = value;}
		}

		[Description("PowerOilRemark")]
		[DataMember]
		public String PowerOilRemark
		{
			get { return _PowerOilRemark;}
			set { _PowerOilRemark = value;}
		}

		[Description("BrakeOilRemark")]
		[DataMember]
		public String BrakeOilRemark
		{
			get { return _BrakeOilRemark;}
			set { _BrakeOilRemark = value;}
		}

		[Description("XcpCarId")]
		[DataMember]
		[Required]
		public Int32 XcpCarId
		{
			get { return _XcpCarId;}
			set { _XcpCarId = value;}
		}

		[Description("CarConfigKey")]
		[DataMember]
		public String CarConfigKey
		{
			get { return _CarConfigKey;}
			set { _CarConfigKey = value;}
		}

		[Description("JqSelfInsurance")]
		[DataMember]
		[Required]
		public Int32 JqSelfInsurance
		{
			get { return _JqSelfInsurance;}
			set { _JqSelfInsurance = value;}
		}

		[Description("brandname")]
		[DataMember]
		public String brandname
		{
			get { return _brandname;}
			set { _brandname = value;}
		}

		[Description("seriesname")]
		[DataMember]
		public String seriesname
		{
			get { return _seriesname;}
			set { _seriesname = value;}
		}

		[Description("modelname")]
		[DataMember]
		public String modelname
		{
			get { return _modelname;}
			set { _modelname = value;}
		}

		[Description("DetectTvuid")]
		[DataMember]
		public Int32? DetectTvuid
		{
			get { return _DetectTvuid;}
			set { _DetectTvuid = value;}
		}

		[Description("GuideTvuid")]
		[DataMember]
		public Int32? GuideTvuid
		{
			get { return _GuideTvuid;}
			set { _GuideTvuid = value;}
		}

		[Description("GuideTel")]
		[DataMember]
		public String GuideTel
		{
			get { return _GuideTel;}
			set { _GuideTel = value;}
		}

		[Description("AppearancePaint")]
		[DataMember]
		public String AppearancePaint
		{
			get { return _AppearancePaint;}
			set { _AppearancePaint = value;}
		}

		[Description("SkeletonPaint")]
		[DataMember]
		public String SkeletonPaint
		{
			get { return _SkeletonPaint;}
			set { _SkeletonPaint = value;}
		}

		[Description("BatteryCheckStatus")]
		[DataMember]
		[Required]
		public Int32 BatteryCheckStatus
		{
			get { return _BatteryCheckStatus;}
			set { _BatteryCheckStatus = value;}
		}

		[Description("BatteryCheckRemark")]
		[DataMember]
		public String BatteryCheckRemark
		{
			get { return _BatteryCheckRemark;}
			set { _BatteryCheckRemark = value;}
		}

		[Description("BeltCheckStatus")]
		[DataMember]
		[Required]
		public Int32 BeltCheckStatus
		{
			get { return _BeltCheckStatus;}
			set { _BeltCheckStatus = value;}
		}

		[Description("BeltCheckRemark")]
		[DataMember]
		public String BeltCheckRemark
		{
			get { return _BeltCheckRemark;}
			set { _BeltCheckRemark = value;}
		}

		[Description("RedbookName")]
		[DataMember]
		public String RedbookName
		{
			get { return _RedbookName;}
			set { _RedbookName = value;}
		}

		[Description("DateType")]
		[DataMember]
		[Required]
		public Int32 DateType
		{
			get { return _DateType;}
			set { _DateType = value;}
		}

		[Description("certificatecard")]
		[DataMember]
		public Int32? certificatecard
		{
			get { return _certificatecard;}
			set { _certificatecard = value;}
		}

		[Description("factorycode")]
		[DataMember]
		public Int32? factorycode
		{
			get { return _factorycode;}
			set { _factorycode = value;}
		}

		[Description("newcarphoto")]
		[DataMember]
		public Int32? newcarphoto
		{
			get { return _newcarphoto;}
			set { _newcarphoto = value;}
		}

		[Description("maintainmanual")]
		[DataMember]
		public Int32? maintainmanual
		{
			get { return _maintainmanual;}
			set { _maintainmanual = value;}
		}

		[Description("thenewcar")]
		[DataMember]
		public Int32? thenewcar
		{
			get { return _thenewcar;}
			set { _thenewcar = value;}
		}

		[Description("ReportType")]
		[DataMember]
		public Int32? ReportType
		{
			get { return _ReportType;}
			set { _ReportType = value;}
		}

		[Description("Result")]
		[DataMember]
		public String Result
		{
			get { return _Result;}
			set { _Result = value;}
		}

		[Description("ConditionGradeApllo")]
		[DataMember]
		public String ConditionGradeApllo
		{
			get { return _ConditionGradeApllo;}
			set { _ConditionGradeApllo = value;}
		}

		[Description("RemarkApllo")]
		[DataMember]
		public String RemarkApllo
		{
			get { return _RemarkApllo;}
			set { _RemarkApllo = value;}
		}

		#endregion
	}
}
