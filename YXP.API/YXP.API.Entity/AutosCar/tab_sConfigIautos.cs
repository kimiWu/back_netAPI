using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace YXP.API.Entity.AutosCar
{
	[Serializable]
	[DataContract]
	public partial class tab_sConfigIautos
	{
		#region 私有变量
		private Int16 _fld_Iautosid;
		private String _fld_Classes;
		private String _fld_SubClasses;
		private String _fld_FineClasses;
		private Int64 _ConfigIautosID;
		private DateTime? _ChangeTime;
		private Int32? _NotoStatus;
		#endregion

		# region 属性方法
		[Description("fld_Iautosid")]
		[DataMember]
		[Required]
		public Int16 fld_Iautosid
		{
			get { return _fld_Iautosid;}
			set { _fld_Iautosid = value;}
		}

		[Description("fld_Classes")]
		[DataMember]
		[Required]
		public String fld_Classes
		{
			get { return _fld_Classes;}
			set { _fld_Classes = value;}
		}

		[Description("fld_SubClasses")]
		[DataMember]
		[Required]
		public String fld_SubClasses
		{
			get { return _fld_SubClasses;}
			set { _fld_SubClasses = value;}
		}

		[Description("fld_FineClasses")]
		[DataMember]
		public String fld_FineClasses
		{
			get { return _fld_FineClasses;}
			set { _fld_FineClasses = value;}
		}

		[Description("ConfigIautosID")]
		[DataMember]
		[Key]
		[Required]
		public Int64 ConfigIautosID
		{
			get { return _ConfigIautosID;}
			set { _ConfigIautosID = value;}
		}

		[Description("ChangeTime")]
		[DataMember]
		public DateTime? ChangeTime
		{
			get { return _ChangeTime;}
			set { _ChangeTime = value;}
		}

		[Description("NotoStatus")]
		[DataMember]
		public Int32? NotoStatus
		{
			get { return _NotoStatus;}
			set { _NotoStatus = value;}
		}

		#endregion
	}
}
