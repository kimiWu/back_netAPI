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
	public partial class tab_sCarTrim
	{
		#region 私有变量
		private Int64 _fld_trimid;
		private String _fld_trim;
		private String _fld_cxnk;
		private String _fld_ccsj;
		private String _fld_redcode;
		private String _fld_gsnk;
		private Int64 _fld_modelid;
		private Int32 _fld_makeid;
		private Int64 _CarTrimID;
		private Int64? _CarMakeID;
		private Int64? _CarModelID;
		private DateTime? _ChangeTime;
		private Int32? _NotoStatus;
		private Int64? _SortNo;
		#endregion

		# region 属性方法
		[Description("fld_trimid")]
		[DataMember]
		[Required]
		public Int64 fld_trimid
		{
			get { return _fld_trimid;}
			set { _fld_trimid = value;}
		}

		[Description("fld_trim")]
		[DataMember]
		public String fld_trim
		{
			get { return _fld_trim;}
			set { _fld_trim = value;}
		}

		[Description("fld_cxnk")]
		[DataMember]
		public String fld_cxnk
		{
			get { return _fld_cxnk;}
			set { _fld_cxnk = value;}
		}

		[Description("fld_ccsj")]
		[DataMember]
		public String fld_ccsj
		{
			get { return _fld_ccsj;}
			set { _fld_ccsj = value;}
		}

		[Description("fld_redcode")]
		[DataMember]
		public String fld_redcode
		{
			get { return _fld_redcode;}
			set { _fld_redcode = value;}
		}

		[Description("fld_gsnk")]
		[DataMember]
		public String fld_gsnk
		{
			get { return _fld_gsnk;}
			set { _fld_gsnk = value;}
		}

		[Description("fld_modelid")]
		[DataMember]
		[Required]
		public Int64 fld_modelid
		{
			get { return _fld_modelid;}
			set { _fld_modelid = value;}
		}

		[Description("fld_makeid")]
		[DataMember]
		[Required]
		public Int32 fld_makeid
		{
			get { return _fld_makeid;}
			set { _fld_makeid = value;}
		}

		[Description("CarTrimID")]
		[DataMember]
		[Key]
		[Required]
		public Int64 CarTrimID
		{
			get { return _CarTrimID;}
			set { _CarTrimID = value;}
		}

		[Description("CarMakeID")]
		[DataMember]
		public Int64? CarMakeID
		{
			get { return _CarMakeID;}
			set { _CarMakeID = value;}
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
