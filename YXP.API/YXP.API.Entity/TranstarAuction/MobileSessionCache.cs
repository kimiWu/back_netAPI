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
	public partial class MobileSessionCache
	{
		#region 私有变量
		private Int32 _SID;
		private String _SessionID;
		private String _UserKey;
		private String _PhoneType;
		private Int32? _tvuid;
		private Int32? _tvaid;
		private DateTime? _UpdateTime;
		private DateTime? _CreateTime;
		private String _Data;
		private String _DeviceModel;
		private Int32 _Siteid;
		private Int32 _SourceType;
		#endregion

		# region 属性方法
		[Description("SID")]
		[DataMember]
		[Key]
		[Required]
		public Int32 SID
		{
			get { return _SID;}
			set { _SID = value;}
		}

		[Description("SessionID")]
		[DataMember]
		public String SessionID
		{
			get { return _SessionID;}
			set { _SessionID = value;}
		}

		[Description("UserKey")]
		[DataMember]
		public String UserKey
		{
			get { return _UserKey;}
			set { _UserKey = value;}
		}

		[Description("PhoneType")]
		[DataMember]
		public String PhoneType
		{
			get { return _PhoneType;}
			set { _PhoneType = value;}
		}

		[Description("tvuid")]
		[DataMember]
		public Int32? tvuid
		{
			get { return _tvuid;}
			set { _tvuid = value;}
		}

		[Description("tvaid")]
		[DataMember]
		public Int32? tvaid
		{
			get { return _tvaid;}
			set { _tvaid = value;}
		}

		[Description("UpdateTime")]
		[DataMember]
		public DateTime? UpdateTime
		{
			get { return _UpdateTime;}
			set { _UpdateTime = value;}
		}

		[Description("CreateTime")]
		[DataMember]
		public DateTime? CreateTime
		{
			get { return _CreateTime;}
			set { _CreateTime = value;}
		}

		[Description("Data")]
		[DataMember]
		public String Data
		{
			get { return _Data;}
			set { _Data = value;}
		}

		[Description("DeviceModel")]
		[DataMember]
		public String DeviceModel
		{
			get { return _DeviceModel;}
			set { _DeviceModel = value;}
		}

		[Description("Siteid")]
		[DataMember]
		[Required]
		public Int32 Siteid
		{
			get { return _Siteid;}
			set { _Siteid = value;}
		}

		[Description("SourceType")]
		[DataMember]
		[Required]
		public Int32 SourceType
		{
			get { return _SourceType;}
			set { _SourceType = value;}
		}

		#endregion
	}
}
