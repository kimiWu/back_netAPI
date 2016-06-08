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
	public partial class tab_sConfig
	{
		#region 私有变量
		private Int64 _fld_Trimid;
		private Int64 _fld_Itemid;
		private Int64 _ConfigID;
		private Int64? _CarTrimID;
		private Int64? _ConfigItemsID;
		private DateTime? _ChangeTime;
		private Int32? _NotoStatus;
		#endregion

		# region 属性方法
		[Description("fld_Trimid")]
		[DataMember]
		[Required]
		public Int64 fld_Trimid
		{
			get { return _fld_Trimid;}
			set { _fld_Trimid = value;}
		}

		[Description("fld_Itemid")]
		[DataMember]
		[Required]
		public Int64 fld_Itemid
		{
			get { return _fld_Itemid;}
			set { _fld_Itemid = value;}
		}

		[Description("ConfigID")]
		[DataMember]
		[Key]
		[Required]
		public Int64 ConfigID
		{
			get { return _ConfigID;}
			set { _ConfigID = value;}
		}

		[Description("CarTrimID")]
		[DataMember]
		public Int64? CarTrimID
		{
			get { return _CarTrimID;}
			set { _CarTrimID = value;}
		}

		[Description("ConfigItemsID")]
		[DataMember]
		public Int64? ConfigItemsID
		{
			get { return _ConfigItemsID;}
			set { _ConfigItemsID = value;}
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
