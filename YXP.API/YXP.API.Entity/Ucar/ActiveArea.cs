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
	public partial class ActiveArea
	{
		#region 私有变量
		private Int32 _AreaId;
		private String _AreaName;
		private Int32? _AreaType;
		private Int32? _BigAreaId;
		private DateTime? _CreateTime;
		private DateTime? _ModifyTime;
		private String _allspell;
		private Int32? _AreaSort;
		#endregion

		# region 属性方法
		[Description("AreaId")]
		[DataMember]
		[Key]
		[Required]
		public Int32 AreaId
		{
			get { return _AreaId;}
			set { _AreaId = value;}
		}

		[Description("AreaName")]
		[DataMember]
		public String AreaName
		{
			get { return _AreaName;}
			set { _AreaName = value;}
		}

		[Description("AreaType")]
		[DataMember]
		public Int32? AreaType
		{
			get { return _AreaType;}
			set { _AreaType = value;}
		}

		[Description("BigAreaId")]
		[DataMember]
		public Int32? BigAreaId
		{
			get { return _BigAreaId;}
			set { _BigAreaId = value;}
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

		[Description("allspell")]
		[DataMember]
		public String allspell
		{
			get { return _allspell;}
			set { _allspell = value;}
		}

		[Description("AreaSort")]
		[DataMember]
		public Int32? AreaSort
		{
			get { return _AreaSort;}
			set { _AreaSort = value;}
		}

		#endregion
	}
}
