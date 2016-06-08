using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace YXP.API.Entity
{
	[Serializable]
	[DataContract]
	public partial class TranstarVendorConfig
	{
		#region 私有变量
		private Int32 _TvaID;
		private String _ConfigKey;
		private String _ConfigValue;
		private DateTime _CreateTime;
		private DateTime _UpdateTime;
		#endregion

		# region 属性方法
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
		public String ConfigKey
		{
			get { return _ConfigKey;}
			set { _ConfigKey = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String ConfigValue
		{
			get { return _ConfigValue;}
			set { _ConfigValue = value;}
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
		public DateTime UpdateTime
		{
			get { return _UpdateTime;}
			set { _UpdateTime = value;}
		}

		#endregion
	}
}
