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
	public partial class TranstarVendorAccount
	{
		#region 私有变量
		private Int32 _TvaID;
		private Int32? _SiID;
		private String _VendorFullName;
		private String _VendorCode;
		private String _VendorShortName;
		private Int32? _CityID;
		private String _TaxAccount;
		private Boolean? _IsTaxAccountVisible;
		private String _BankAccount;
		private Boolean? _IsBankAccountVisible;
		private String _LinkMan;
		private String _TelephoneNumber;
		private String _MobilePhoneNumber;
		private String _FaxNumber;
		private String _Email;
		private String _Address;
		private String _PostCode;
		private String _VendorIntroduction;
		private String _TrafficDescription;
		private String _Image1;
		private String _Image2;
		private String _Image3;
		private String _MapImage;
		private DateTime? _CreateTime;
		private DateTime? _LastModifyTime;
		private Int32? _Status;
		private Int32? _VendorLevel;
		private String _EMapImage;
		private Int32? _oldTvaid;
		private Int32? _LoginCount;
		private DateTime? _LastLoginTime;
		private Int32? _VendorType;
		private Int32? _RecommendVendorID;
		private Int32? _VendorClass;
		private Int32? _SuperiorID;
		private Int32? _OfficialStatus;
		private Int32? _StarLevel;
		private Decimal? _QuarterPoint;
		private String _ServiceTel;
		private Byte? _HasIdentity;
		private Byte? _HasBusinessLicense;
		private Int32 _AccountType;
		private Int32 _ChargeType;
		private DateTime? _FreeBeginDate;
		private DateTime? _FreeEndDate;
		private Int32 _IsOnlinePayEnable;
		private DateTime? _FirstChargeTime;
		private String _CustomVersionNo;
		private String _SmallArea;
		private String _BigArea;
		private Int32? _IsVirtualBuyer;
		private Int32 _ManageType;
		private Int32 _SuperGroupID;
		private Int32 _UseAccountType;
		private Int32 _AgentID;
		private Int32 _CircletType;
		private DateTime? _LockTime;
		private Int32? _LockDaysType;
		private Int32 _AgentType;
		private Int32? _ZCLX;
		private Int32? _JYCD;
		private String _CLTFCD;
		private String _JYCLJGFW;
		private String _GXQCLPP;
		private String _CLCSFS;
		private Int32? _SFDK;
		private String _KHYH;
		private String _KHHM;
		private String _KHZH;
		private String _KHDH;
		private Int32? _CWSL;
		private Int32? _YJCGL;
		private Int32? _YJCSL;
		private Int32? _RYGM;
		private Int32? _ESCJYYW;
		private Int32? _IsLiveAuction;
		private Int32? _SGSGC;
		private String _GSJYCD;
		private Int32? _XYCLCL;
		private Int32? _Sex;
		private String _DBR;
		private String _DBRIdentityNum;
		private String _DBRMobilePhone;
		private String _BusinessManager;
		private String _BusinessPersonal;
		private String _BusinessLicence;
		private String _IdentityCard;
		private String _BusinessLicencePic;
		private String _IdentityCardPic;
		private DateTime? _LimitGetVoucherTime;
		private String _IdCard_Front;
		private String _IdCard_Back;
		private String _IdCard_Hand;
		private String _Org_Code;
		private String _Tax_Reg_Certificate;
		private Int32? _company_id;
		private Int32? _SupposeCityId;
		private String _Tax_Reg_CertificatePic;
		private String _Org_CodePic;
		private String _PowerOfaAttorneyPic;
		private String _ElectronicSignError;
		private Int32? _ElectronicSignStatus;
		private Int32? _VendorClassCategory;
		private String _BargainAddress;
		private DateTime? _SignAuditExpectationDate;
		private String _BargainAddressIdentity;
		private Int32? _VendorClassCategoryBefore;
		private String _VendorFullNameBefore;
		private String _CRMCustomID;
		private String _SpareMobilePhoneNumber1;
		private String _SpareMobilePhoneNumber2;
		private Int32? _CreditRating;
		#endregion

		# region 属性方法
		[Description("")]
		[DataMember]
		[Key]
		[Required]
		public Int32 TvaID
		{
			get { return _TvaID;}
			set { _TvaID = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? SiID
		{
			get { return _SiID;}
			set { _SiID = value;}
		}

		[Description("")]
		[DataMember]
		public String VendorFullName
		{
			get { return _VendorFullName;}
			set { _VendorFullName = value;}
		}

		[Description("")]
		[DataMember]
		public String VendorCode
		{
			get { return _VendorCode;}
			set { _VendorCode = value;}
		}

		[Description("")]
		[DataMember]
		public String VendorShortName
		{
			get { return _VendorShortName;}
			set { _VendorShortName = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? CityID
		{
			get { return _CityID;}
			set { _CityID = value;}
		}

		[Description("")]
		[DataMember]
		public String TaxAccount
		{
			get { return _TaxAccount;}
			set { _TaxAccount = value;}
		}

		[Description("")]
		[DataMember]
		public Boolean? IsTaxAccountVisible
		{
			get { return _IsTaxAccountVisible;}
			set { _IsTaxAccountVisible = value;}
		}

		[Description("")]
		[DataMember]
		public String BankAccount
		{
			get { return _BankAccount;}
			set { _BankAccount = value;}
		}

		[Description("")]
		[DataMember]
		public Boolean? IsBankAccountVisible
		{
			get { return _IsBankAccountVisible;}
			set { _IsBankAccountVisible = value;}
		}

		[Description("")]
		[DataMember]
		public String LinkMan
		{
			get { return _LinkMan;}
			set { _LinkMan = value;}
		}

		[Description("")]
		[DataMember]
		public String TelephoneNumber
		{
			get { return _TelephoneNumber;}
			set { _TelephoneNumber = value;}
		}

		[Description("")]
		[DataMember]
		public String MobilePhoneNumber
		{
			get { return _MobilePhoneNumber;}
			set { _MobilePhoneNumber = value;}
		}

		[Description("")]
		[DataMember]
		public String FaxNumber
		{
			get { return _FaxNumber;}
			set { _FaxNumber = value;}
		}

		[Description("")]
		[DataMember]
		public String Email
		{
			get { return _Email;}
			set { _Email = value;}
		}

		[Description("")]
		[DataMember]
		public String Address
		{
			get { return _Address;}
			set { _Address = value;}
		}

		[Description("")]
		[DataMember]
		public String PostCode
		{
			get { return _PostCode;}
			set { _PostCode = value;}
		}

		[Description("")]
		[DataMember]
		public String VendorIntroduction
		{
			get { return _VendorIntroduction;}
			set { _VendorIntroduction = value;}
		}

		[Description("")]
		[DataMember]
		public String TrafficDescription
		{
			get { return _TrafficDescription;}
			set { _TrafficDescription = value;}
		}

		[Description("")]
		[DataMember]
		public String Image1
		{
			get { return _Image1;}
			set { _Image1 = value;}
		}

		[Description("")]
		[DataMember]
		public String Image2
		{
			get { return _Image2;}
			set { _Image2 = value;}
		}

		[Description("")]
		[DataMember]
		public String Image3
		{
			get { return _Image3;}
			set { _Image3 = value;}
		}

		[Description("")]
		[DataMember]
		public String MapImage
		{
			get { return _MapImage;}
			set { _MapImage = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? CreateTime
		{
			get { return _CreateTime;}
			set { _CreateTime = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? LastModifyTime
		{
			get { return _LastModifyTime;}
			set { _LastModifyTime = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? Status
		{
			get { return _Status;}
			set { _Status = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? VendorLevel
		{
			get { return _VendorLevel;}
			set { _VendorLevel = value;}
		}

		[Description("")]
		[DataMember]
		public String EMapImage
		{
			get { return _EMapImage;}
			set { _EMapImage = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? oldTvaid
		{
			get { return _oldTvaid;}
			set { _oldTvaid = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? LoginCount
		{
			get { return _LoginCount;}
			set { _LoginCount = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? LastLoginTime
		{
			get { return _LastLoginTime;}
			set { _LastLoginTime = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? VendorType
		{
			get { return _VendorType;}
			set { _VendorType = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? RecommendVendorID
		{
			get { return _RecommendVendorID;}
			set { _RecommendVendorID = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? VendorClass
		{
			get { return _VendorClass;}
			set { _VendorClass = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? SuperiorID
		{
			get { return _SuperiorID;}
			set { _SuperiorID = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? OfficialStatus
		{
			get { return _OfficialStatus;}
			set { _OfficialStatus = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? StarLevel
		{
			get { return _StarLevel;}
			set { _StarLevel = value;}
		}

		[Description("")]
		[DataMember]
		public Decimal? QuarterPoint
		{
			get { return _QuarterPoint;}
			set { _QuarterPoint = value;}
		}

		[Description("")]
		[DataMember]
		public String ServiceTel
		{
			get { return _ServiceTel;}
			set { _ServiceTel = value;}
		}

		[Description("")]
		[DataMember]
		public Byte? HasIdentity
		{
			get { return _HasIdentity;}
			set { _HasIdentity = value;}
		}

		[Description("")]
		[DataMember]
		public Byte? HasBusinessLicense
		{
			get { return _HasBusinessLicense;}
			set { _HasBusinessLicense = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 AccountType
		{
			get { return _AccountType;}
			set { _AccountType = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 ChargeType
		{
			get { return _ChargeType;}
			set { _ChargeType = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? FreeBeginDate
		{
			get { return _FreeBeginDate;}
			set { _FreeBeginDate = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? FreeEndDate
		{
			get { return _FreeEndDate;}
			set { _FreeEndDate = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 IsOnlinePayEnable
		{
			get { return _IsOnlinePayEnable;}
			set { _IsOnlinePayEnable = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? FirstChargeTime
		{
			get { return _FirstChargeTime;}
			set { _FirstChargeTime = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String CustomVersionNo
		{
			get { return _CustomVersionNo;}
			set { _CustomVersionNo = value;}
		}

		[Description("")]
		[DataMember]
		public String SmallArea
		{
			get { return _SmallArea;}
			set { _SmallArea = value;}
		}

		[Description("")]
		[DataMember]
		public String BigArea
		{
			get { return _BigArea;}
			set { _BigArea = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? IsVirtualBuyer
		{
			get { return _IsVirtualBuyer;}
			set { _IsVirtualBuyer = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 ManageType
		{
			get { return _ManageType;}
			set { _ManageType = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 SuperGroupID
		{
			get { return _SuperGroupID;}
			set { _SuperGroupID = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 UseAccountType
		{
			get { return _UseAccountType;}
			set { _UseAccountType = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 AgentID
		{
			get { return _AgentID;}
			set { _AgentID = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 CircletType
		{
			get { return _CircletType;}
			set { _CircletType = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? LockTime
		{
			get { return _LockTime;}
			set { _LockTime = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? LockDaysType
		{
			get { return _LockDaysType;}
			set { _LockDaysType = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 AgentType
		{
			get { return _AgentType;}
			set { _AgentType = value;}
		}

		[Description("ZCLX")]
		[DataMember]
		public Int32? ZCLX
		{
			get { return _ZCLX;}
			set { _ZCLX = value;}
		}

		[Description("JYCD")]
		[DataMember]
		public Int32? JYCD
		{
			get { return _JYCD;}
			set { _JYCD = value;}
		}

		[Description("CLTFCD")]
		[DataMember]
		public String CLTFCD
		{
			get { return _CLTFCD;}
			set { _CLTFCD = value;}
		}

		[Description("JYCLJGFW")]
		[DataMember]
		public String JYCLJGFW
		{
			get { return _JYCLJGFW;}
			set { _JYCLJGFW = value;}
		}

		[Description("GXQCLPP")]
		[DataMember]
		public String GXQCLPP
		{
			get { return _GXQCLPP;}
			set { _GXQCLPP = value;}
		}

		[Description("CLCSFS")]
		[DataMember]
		public String CLCSFS
		{
			get { return _CLCSFS;}
			set { _CLCSFS = value;}
		}

		[Description("SFDK")]
		[DataMember]
		public Int32? SFDK
		{
			get { return _SFDK;}
			set { _SFDK = value;}
		}

		[Description("KHYH")]
		[DataMember]
		public String KHYH
		{
			get { return _KHYH;}
			set { _KHYH = value;}
		}

		[Description("KHHM")]
		[DataMember]
		public String KHHM
		{
			get { return _KHHM;}
			set { _KHHM = value;}
		}

		[Description("KHZH")]
		[DataMember]
		public String KHZH
		{
			get { return _KHZH;}
			set { _KHZH = value;}
		}

		[Description("KHDH")]
		[DataMember]
		public String KHDH
		{
			get { return _KHDH;}
			set { _KHDH = value;}
		}

		[Description("CWSL")]
		[DataMember]
		public Int32? CWSL
		{
			get { return _CWSL;}
			set { _CWSL = value;}
		}

		[Description("YJCGL")]
		[DataMember]
		public Int32? YJCGL
		{
			get { return _YJCGL;}
			set { _YJCGL = value;}
		}

		[Description("YJCSL")]
		[DataMember]
		public Int32? YJCSL
		{
			get { return _YJCSL;}
			set { _YJCSL = value;}
		}

		[Description("RYGM")]
		[DataMember]
		public Int32? RYGM
		{
			get { return _RYGM;}
			set { _RYGM = value;}
		}

		[Description("ESCJYYW")]
		[DataMember]
		public Int32? ESCJYYW
		{
			get { return _ESCJYYW;}
			set { _ESCJYYW = value;}
		}

		[Description("IsLiveAuction")]
		[DataMember]
		public Int32? IsLiveAuction
		{
			get { return _IsLiveAuction;}
			set { _IsLiveAuction = value;}
		}

		[Description("SGSGC")]
		[DataMember]
		public Int32? SGSGC
		{
			get { return _SGSGC;}
			set { _SGSGC = value;}
		}

		[Description("GSJYCD")]
		[DataMember]
		public String GSJYCD
		{
			get { return _GSJYCD;}
			set { _GSJYCD = value;}
		}

		[Description("XYCLCL")]
		[DataMember]
		public Int32? XYCLCL
		{
			get { return _XYCLCL;}
			set { _XYCLCL = value;}
		}

		[Description("Sex")]
		[DataMember]
		public Int32? Sex
		{
			get { return _Sex;}
			set { _Sex = value;}
		}

		[Description("DBR")]
		[DataMember]
		public String DBR
		{
			get { return _DBR;}
			set { _DBR = value;}
		}

		[Description("DBRIdentityNum")]
		[DataMember]
		public String DBRIdentityNum
		{
			get { return _DBRIdentityNum;}
			set { _DBRIdentityNum = value;}
		}

		[Description("DBRMobilePhone")]
		[DataMember]
		public String DBRMobilePhone
		{
			get { return _DBRMobilePhone;}
			set { _DBRMobilePhone = value;}
		}

		[Description("")]
		[DataMember]
		public String BusinessManager
		{
			get { return _BusinessManager;}
			set { _BusinessManager = value;}
		}

		[Description("BusinessPersonal")]
		[DataMember]
		public String BusinessPersonal
		{
			get { return _BusinessPersonal;}
			set { _BusinessPersonal = value;}
		}

		[Description("BusinessLicence")]
		[DataMember]
		public String BusinessLicence
		{
			get { return _BusinessLicence;}
			set { _BusinessLicence = value;}
		}

		[Description("IdentityCard")]
		[DataMember]
		public String IdentityCard
		{
			get { return _IdentityCard;}
			set { _IdentityCard = value;}
		}

		[Description("BusinessLicencePic")]
		[DataMember]
		public String BusinessLicencePic
		{
			get { return _BusinessLicencePic;}
			set { _BusinessLicencePic = value;}
		}

		[Description("IdentityCardPic")]
		[DataMember]
		public String IdentityCardPic
		{
			get { return _IdentityCardPic;}
			set { _IdentityCardPic = value;}
		}

		[Description("LimitGetVoucherTime")]
		[DataMember]
		public DateTime? LimitGetVoucherTime
		{
			get { return _LimitGetVoucherTime;}
			set { _LimitGetVoucherTime = value;}
		}

		[Description("IdCard_Front")]
		[DataMember]
		public String IdCard_Front
		{
			get { return _IdCard_Front;}
			set { _IdCard_Front = value;}
		}

		[Description("IdCard_Back")]
		[DataMember]
		public String IdCard_Back
		{
			get { return _IdCard_Back;}
			set { _IdCard_Back = value;}
		}

		[Description("IdCard_Hand")]
		[DataMember]
		public String IdCard_Hand
		{
			get { return _IdCard_Hand;}
			set { _IdCard_Hand = value;}
		}

		[Description("Org_Code")]
		[DataMember]
		public String Org_Code
		{
			get { return _Org_Code;}
			set { _Org_Code = value;}
		}

		[Description("Tax_Reg_Certificate")]
		[DataMember]
		public String Tax_Reg_Certificate
		{
			get { return _Tax_Reg_Certificate;}
			set { _Tax_Reg_Certificate = value;}
		}

		[Description("company_id")]
		[DataMember]
		public Int32? company_id
		{
			get { return _company_id;}
			set { _company_id = value;}
		}

		[Description("SupposeCityId")]
		[DataMember]
		public Int32? SupposeCityId
		{
			get { return _SupposeCityId;}
			set { _SupposeCityId = value;}
		}

		[Description("Tax_Reg_CertificatePic")]
		[DataMember]
		public String Tax_Reg_CertificatePic
		{
			get { return _Tax_Reg_CertificatePic;}
			set { _Tax_Reg_CertificatePic = value;}
		}

		[Description("Org_CodePic")]
		[DataMember]
		public String Org_CodePic
		{
			get { return _Org_CodePic;}
			set { _Org_CodePic = value;}
		}

		[Description("PowerOfaAttorneyPic")]
		[DataMember]
		public String PowerOfaAttorneyPic
		{
			get { return _PowerOfaAttorneyPic;}
			set { _PowerOfaAttorneyPic = value;}
		}

		[Description("ElectronicSignError")]
		[DataMember]
		public String ElectronicSignError
		{
			get { return _ElectronicSignError;}
			set { _ElectronicSignError = value;}
		}

		[Description("ElectronicSignStatus")]
		[DataMember]
		public Int32? ElectronicSignStatus
		{
			get { return _ElectronicSignStatus;}
			set { _ElectronicSignStatus = value;}
		}

		[Description("VendorClassCategory")]
		[DataMember]
		public Int32? VendorClassCategory
		{
			get { return _VendorClassCategory;}
			set { _VendorClassCategory = value;}
		}

		[Description("BargainAddress")]
		[DataMember]
		public String BargainAddress
		{
			get { return _BargainAddress;}
			set { _BargainAddress = value;}
		}

		[Description("SignAuditExpectationDate")]
		[DataMember]
		public DateTime? SignAuditExpectationDate
		{
			get { return _SignAuditExpectationDate;}
			set { _SignAuditExpectationDate = value;}
		}

		[Description("BargainAddressIdentity")]
		[DataMember]
		public String BargainAddressIdentity
		{
			get { return _BargainAddressIdentity;}
			set { _BargainAddressIdentity = value;}
		}

		[Description("VendorClassCategoryBefore")]
		[DataMember]
		public Int32? VendorClassCategoryBefore
		{
			get { return _VendorClassCategoryBefore;}
			set { _VendorClassCategoryBefore = value;}
		}

		[Description("VendorFullNameBefore")]
		[DataMember]
		public String VendorFullNameBefore
		{
			get { return _VendorFullNameBefore;}
			set { _VendorFullNameBefore = value;}
		}

		[Description("CRMCustomID")]
		[DataMember]
		public String CRMCustomID
		{
			get { return _CRMCustomID;}
			set { _CRMCustomID = value;}
		}

		[Description("SpareMobilePhoneNumber1")]
		[DataMember]
		public String SpareMobilePhoneNumber1
		{
			get { return _SpareMobilePhoneNumber1;}
			set { _SpareMobilePhoneNumber1 = value;}
		}

		[Description("SpareMobilePhoneNumber2")]
		[DataMember]
		public String SpareMobilePhoneNumber2
		{
			get { return _SpareMobilePhoneNumber2;}
			set { _SpareMobilePhoneNumber2 = value;}
		}

		[Description("CreditRating")]
		[DataMember]
		public Int32? CreditRating
		{
			get { return _CreditRating;}
			set { _CreditRating = value;}
		}
		#endregion
	}
}
