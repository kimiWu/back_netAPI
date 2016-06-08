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
	public partial class tab_sConfigModel
	{
		#region 私有变量
		private Int64 _fld_Configid;
		private String _fld_Name;
		private Int32 _fld_Modelid;
		private Int64 _ConfigModelID;
		private Int64? _CarModelID;
		private DateTime? _ChangeTime;
		private Int32? _NotoStatus;
		#endregion

		# region 属性方法
		[Description("fld_Configid")]
		[DataMember]
		[Required]
		public Int64 fld_Configid
		{
			get { return _fld_Configid;}
			set { _fld_Configid = value;}
		}

		[Description("fld_Name")]
		[DataMember]
		[Required]
		public String fld_Name
		{
			get { return _fld_Name;}
			set { _fld_Name = value;}
		}

		[Description("fld_Modelid")]
		[DataMember]
		[Required]
		public Int32 fld_Modelid
		{
			get { return _fld_Modelid;}
			set { _fld_Modelid = value;}
		}

		[Description("ConfigModelID")]
		[DataMember]
		[Key]
		[Required]
		public Int64 ConfigModelID
		{
			get { return _ConfigModelID;}
			set { _ConfigModelID = value;}
		}

		[Description("CarModelID")]
		[DataMember]
		public Int64? CarModelID
		{
			get { return _CarModelID;}
			set { _CarModelID = value;}
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
