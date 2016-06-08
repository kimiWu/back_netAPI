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
	public partial class LogRecords
	{
		#region 私有变量
		private Int64? _Id;
		private Int32? _PlatformId;
		private String _Url;
		private String _Params;
		private DateTime? _CreateTime;
		private DateTime? _UpdateTime;
		private String _Browser;
		private Int32? _Flag;
		private Int32? _ActionTime;
		private Int32? _RenderTime;
		#endregion

		# region 属性方法
		[Description("Id")]
		[DataMember]
		public Int64? Id
		{
			get { return _Id;}
			set { _Id = value;}
		}

		[Description("PlatformId")]
		[DataMember]
		public Int32? PlatformId
		{
			get { return _PlatformId;}
			set { _PlatformId = value;}
		}

		[Description("Url")]
		[DataMember]
		public String Url
		{
			get { return _Url;}
			set { _Url = value;}
		}

		[Description("Params")]
		[DataMember]
		public String Params
		{
			get { return _Params;}
			set { _Params = value;}
		}

		[Description("CreateTime")]
		[DataMember]
		public DateTime? CreateTime
		{
			get { return _CreateTime;}
			set { _CreateTime = value;}
		}

		[Description("UpdateTime")]
		[DataMember]
		public DateTime? UpdateTime
		{
			get { return _UpdateTime;}
			set { _UpdateTime = value;}
		}

		[Description("Browser")]
		[DataMember]
		public String Browser
		{
			get { return _Browser;}
			set { _Browser = value;}
		}

		[Description("Flag")]
		[DataMember]
		public Int32? Flag
		{
			get { return _Flag;}
			set { _Flag = value;}
		}

		[Description("ActionTime")]
		[DataMember]
		public Int32? ActionTime
		{
			get { return _ActionTime;}
			set { _ActionTime = value;}
		}

		[Description("RenderTime")]
		[DataMember]
		public Int32? RenderTime
		{
			get { return _RenderTime;}
            set { _RenderTime = value; }
		}

		#endregion
	}
}
