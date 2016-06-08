using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace YXP.ADS.Entity.TranstarAuction
{
	[Serializable]
	[DataContract]
	public partial class AuctionLoginLog
	{
		#region 私有变量
		private Int32 _LogID;
		private String _LoginName;
		private Int32 _TvaID;
		private Int32 _TvuID;
		private DateTime _CreateTime;
		private String _LogType;
		private String _LoginSource;
		private String _LoginIP;
		private String _OSVersion;
		private String _WindowWH;
		private String _PhoneStatus;
		private String _SIMCardInfo;
		private Int32? _LoginCount;
		private DateTime? _PriLoginTime;
		private String _LoginCity;
		#endregion

		# region 属性方法
		[Description("")]
		[DataMember]
		[Key]
		[Required]
		public Int32 LogID
		{
			get { return _LogID;}
			set { _LogID = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String LoginName
		{
			get { return _LoginName;}
			set { _LoginName = value;}
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
		public Int32 TvuID
		{
			get { return _TvuID;}
			set { _TvuID = value;}
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
		public String LogType
		{
			get { return _LogType;}
			set { _LogType = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String LoginSource
		{
			get { return _LoginSource;}
			set { _LoginSource = value;}
		}

		[Description("")]
		[DataMember]
		public String LoginIP
		{
			get { return _LoginIP;}
			set { _LoginIP = value;}
		}

		[Description("OSVersion")]
		[DataMember]
		public String OSVersion
		{
			get { return _OSVersion;}
			set { _OSVersion = value;}
		}

		[Description("WindowWH")]
		[DataMember]
		public String WindowWH
		{
			get { return _WindowWH;}
			set { _WindowWH = value;}
		}

		[Description("PhoneStatus")]
		[DataMember]
		public String PhoneStatus
		{
			get { return _PhoneStatus;}
			set { _PhoneStatus = value;}
		}

		[Description("SIMCardInfo")]
		[DataMember]
		public String SIMCardInfo
		{
			get { return _SIMCardInfo;}
			set { _SIMCardInfo = value;}
		}

		[Description("LoginCount")]
		[DataMember]
		public Int32? LoginCount
		{
			get { return _LoginCount;}
			set { _LoginCount = value;}
		}

		[Description("PriLoginTime")]
		[DataMember]
		public DateTime? PriLoginTime
		{
			get { return _PriLoginTime;}
			set { _PriLoginTime = value;}
		}

		[Description("LoginCity")]
		[DataMember]
		public String LoginCity
		{
			get { return _LoginCity;}
			set { _LoginCity = value;}
		}

		#endregion
	}
}
