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
	public partial class TranstarVendorUser
	{
		#region 私有变量
		private Int32 _TvuID;
		private Int32? _SiID;
		private Int32? _TvaID;
		private Int32? _UrID;
		private String _LoginName;
		private String _LoginPwd;
		private String _UserFullName;
		private String _TelephoneNumber;
		private String _MobilePhoneNumber;
		private String _Email;
		private DateTime? _CreateTime;
		private DateTime? _LastModifyTime;
		private Int32? _Status;
		private Int32? _Level;
		private Int32? _oldTvuid;
		private Int32? _LoginCount;
		private DateTime? _LastLoginTime;
		private Int32? _LinkManID;
		private DateTime? _LastPwdModifyTime;
		private Int32? _OfficialStatus;
		private Int32? _IsCompanyLinkMan;
		private Int32? _VendorType;
		private String _IdentityNum;
		private String _QQ;
		private String _CardID;
		private String _CardPwd;
		private String _IdentityPic;
		private String _CarPic;
		private DateTime? _Birthday;
		private String _FacePic;
		private String _CardCode;
		private Int32? _supposeCity;
		private String _refereeCode;
		#endregion

		# region 属性方法
		[Description("")]
		[DataMember]
		[Key]
		[Required]
		public Int32 TvuID
		{
			get { return _TvuID;}
			set { _TvuID = value;}
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
		public Int32? TvaID
		{
			get { return _TvaID;}
			set { _TvaID = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? UrID
		{
			get { return _UrID;}
			set { _UrID = value;}
		}

		[Description("")]
		[DataMember]
		public String LoginName
		{
			get { return _LoginName;}
			set { _LoginName = value;}
		}

		[Description("")]
		[DataMember]
		public String LoginPwd
		{
			get { return _LoginPwd;}
			set { _LoginPwd = value;}
		}

		[Description("")]
		[DataMember]
		public String UserFullName
		{
			get { return _UserFullName;}
			set { _UserFullName = value;}
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
		public String Email
		{
			get { return _Email;}
			set { _Email = value;}
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
		public Int32? Level
		{
			get { return _Level;}
			set { _Level = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? oldTvuid
		{
			get { return _oldTvuid;}
			set { _oldTvuid = value;}
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
		public Int32? LinkManID
		{
			get { return _LinkManID;}
			set { _LinkManID = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? LastPwdModifyTime
		{
			get { return _LastPwdModifyTime;}
			set { _LastPwdModifyTime = value;}
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
		public Int32? IsCompanyLinkMan
		{
			get { return _IsCompanyLinkMan;}
			set { _IsCompanyLinkMan = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? VendorType
		{
			get { return _VendorType;}
			set { _VendorType = value;}
		}

		[Description("IdentityNum")]
		[DataMember]
		public String IdentityNum
		{
			get { return _IdentityNum;}
			set { _IdentityNum = value;}
		}

		[Description("QQ")]
		[DataMember]
		public String QQ
		{
			get { return _QQ;}
			set { _QQ = value;}
		}

		[Description("CardID")]
		[DataMember]
		public String CardID
		{
			get { return _CardID;}
			set { _CardID = value;}
		}

		[Description("CardPwd")]
		[DataMember]
		public String CardPwd
		{
			get { return _CardPwd;}
			set { _CardPwd = value;}
		}

		[Description("IdentityPic")]
		[DataMember]
		public String IdentityPic
		{
			get { return _IdentityPic;}
			set { _IdentityPic = value;}
		}

		[Description("CarPic")]
		[DataMember]
		public String CarPic
		{
			get { return _CarPic;}
			set { _CarPic = value;}
		}

		[Description("Birthday")]
		[DataMember]
		public DateTime? Birthday
		{
			get { return _Birthday;}
			set { _Birthday = value;}
		}

		[Description("FacePic")]
		[DataMember]
		public String FacePic
		{
			get { return _FacePic;}
			set { _FacePic = value;}
		}

		[Description("CardCode")]
		[DataMember]
		public String CardCode
		{
			get { return _CardCode;}
			set { _CardCode = value;}
		}

		[Description("supposeCity")]
		[DataMember]
		public Int32? supposeCity
		{
			get { return _supposeCity;}
			set { _supposeCity = value;}
		}

		[Description("refereeCode")]
		[DataMember]
		public String refereeCode
		{
			get { return _refereeCode;}
			set { _refereeCode = value;}
		}

		#endregion
	}
}
