using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace YXP.API.Entity.Ucar
{
	[Serializable]
	[DataContract]
	public partial class BigArea
	{
		#region 私有变量
		private Int32 _BigAreaId;
		private String _BigAreaName;
		private DateTime? _CreateTime;
		private DateTime? _ModifyTime;
		#endregion

		# region 属性方法
		[Description("BigAreaId")]
		[DataMember]
		[Key]
		[Required]
		public Int32 BigAreaId
		{
			get { return _BigAreaId;}
			set { _BigAreaId = value;}
		}

		[Description("BigAreaName")]
		[DataMember]
		public String BigAreaName
		{
			get { return _BigAreaName;}
			set { _BigAreaName = value;}
		}

		[Description("CreateTime")]
		[DataMember]
		public DateTime? CreateTime
		{
			get { return _CreateTime;}
			set { _CreateTime = value;}
		}

		[Description("ModifyTime")]
		[DataMember]
		public DateTime? ModifyTime
		{
			get { return _ModifyTime;}
			set { _ModifyTime = value;}
		}

		#endregion
	}
}
