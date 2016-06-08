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
	public partial class tab_serial
	{
		#region 私有变量
		private Int32 _fld_serialid;
		private String _fld_serial;
		private String _fld_country;
		private String _allspell;
		private DateTime? _UpdateTime;
		private Int64? _SortNo;
		#endregion

		# region 属性方法
		[Description("fld_serialid")]
		[DataMember]
		[Key]
		[Required]
		public Int32 fld_serialid
		{
			get { return _fld_serialid;}
			set { _fld_serialid = value;}
		}

		[Description("fld_serial")]
		[DataMember]
		[Required]
		public String fld_serial
		{
			get { return _fld_serial;}
			set { _fld_serial = value;}
		}

		[Description("fld_country")]
		[DataMember]
		public String fld_country
		{
			get { return _fld_country;}
			set { _fld_country = value;}
		}

		[Description("allspell")]
		[DataMember]
		public String allspell
		{
			get { return _allspell;}
			set { _allspell = value;}
		}

		[Description("UpdateTime")]
		[DataMember]
		public DateTime? UpdateTime
		{
			get { return _UpdateTime;}
			set { _UpdateTime = value;}
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
