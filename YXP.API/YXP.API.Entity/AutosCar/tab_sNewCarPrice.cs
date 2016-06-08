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
	public partial class tab_sNewCarPrice
	{
		#region 私有变量
		private Int32 _fld_trimid;
		private Double? _fld_price;
		private Int64? _CarTrimID;
		private DateTime? _ChangeTime;
		private String _NotoStatus;
		#endregion

		# region 属性方法
		[Description("fld_trimid")]
		[DataMember]
		[Key]
		[Required]
		public Int32 fld_trimid
		{
			get { return _fld_trimid;}
			set { _fld_trimid = value;}
		}

		[Description("fld_price")]
		[DataMember]
		public Double? fld_price
		{
			get { return _fld_price;}
			set { _fld_price = value;}
		}

		[Description("CarTrimID")]
		[DataMember]
		public Int64? CarTrimID
		{
			get { return _CarTrimID;}
			set { _CarTrimID = value;}
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
		public String NotoStatus
		{
			get { return _NotoStatus;}
			set { _NotoStatus = value;}
		}

		#endregion
	}
}
