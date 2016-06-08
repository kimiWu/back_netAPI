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
	public partial class tab_sCarModel
	{
		#region 私有变量
		private Int64 _fld_modelid;
		private String _fld_model;
		private String _fld_serial;
		private Int32 _fld_makeid;
		private Byte _fld_type;
		private Int64 _CarModelID;
		private Int32? _fld_serialid;
		private Int64? _CarMakeID;
		private DateTime? _ChangeTime;
		private Int32? _NotoStatus;
		private Int64? _SortNo;
		#endregion

		# region 属性方法
		[Description("fld_modelid")]
		[DataMember]
		[Required]
		public Int64 fld_modelid
		{
			get { return _fld_modelid;}
			set { _fld_modelid = value;}
		}

		[Description("fld_model")]
		[DataMember]
		[Required]
		public String fld_model
		{
			get { return _fld_model;}
			set { _fld_model = value;}
		}

		[Description("fld_serial")]
		[DataMember]
		[Required]
		public String fld_serial
		{
			get { return _fld_serial;}
			set { _fld_serial = value;}
		}

		[Description("fld_makeid")]
		[DataMember]
		[Required]
		public Int32 fld_makeid
		{
			get { return _fld_makeid;}
			set { _fld_makeid = value;}
		}

		[Description("fld_type")]
		[DataMember]
		[Required]
		public Byte fld_type
		{
			get { return _fld_type;}
			set { _fld_type = value;}
		}

		[Description("CarModelID")]
		[DataMember]
		[Key]
		[Required]
		public Int64 CarModelID
		{
			get { return _CarModelID;}
			set { _CarModelID = value;}
		}

		[Description("fld_serialid")]
		[DataMember]
		public Int32? fld_serialid
		{
			get { return _fld_serialid;}
			set { _fld_serialid = value;}
		}

		[Description("CarMakeID")]
		[DataMember]
		public Int64? CarMakeID
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

		[Description("SortNo")]
		[DataMember]
		public Int64? SortNo
		{
			get { return _SortNo;}
			set { _SortNo = value;}
		}

		#endregion
	}
}
