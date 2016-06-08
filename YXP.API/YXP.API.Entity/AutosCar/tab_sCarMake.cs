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
	public partial class tab_sCarMake
	{
		#region 私有变量
		private Int32 _fld_makeid;
		private String _fld_make;
		private String _fld_country;
		private Int64 _CarMakeID;
		private DateTime? _ChangeTime;
		private Int32? _NotoStatus;
		#endregion

		# region 属性方法
		[Description("fld_makeid")]
		[DataMember]
		[Required]
		public Int32 fld_makeid
		{
			get { return _fld_makeid;}
			set { _fld_makeid = value;}
		}

		[Description("fld_make")]
		[DataMember]
		[Required]
		public String fld_make
		{
			get { return _fld_make;}
			set { _fld_make = value;}
		}

		[Description("fld_country")]
		[DataMember]
		[Required]
		public String fld_country
		{
			get { return _fld_country;}
			set { _fld_country = value;}
		}

		[Description("CarMakeID")]
		[DataMember]
		[Key]
		[Required]
		public Int64 CarMakeID
		{
			get { return _CarMakeID;}
			set { _CarMakeID = value;}
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
