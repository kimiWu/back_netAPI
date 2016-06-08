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
	public partial class tab_Control
	{
		#region 私有变量
		private Int64? _fld_serialid;
		private String _fld_serial;
		private Int64? _CarMakeID;
		private String _fld_make;
		private Int64? _CarModelID;
		private String _fld_model;
		private Int32? _bs_Id;
		private String _bs_Name;
		private Int32? _cb_Id;
		private String _cb_Name;
		private Int32? _cs_Id;
		private String _cs_Name;
		#endregion

		# region 属性方法
		[Description("fld_serialid")]
		[DataMember]
		public Int64? fld_serialid
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

		[Description("CarMakeID")]
		[DataMember]
		public Int64? CarMakeID
		{
			get { return _CarMakeID;}
			set { _CarMakeID = value;}
		}

		[Description("fld_make")]
		[DataMember]
		public String fld_make
		{
			get { return _fld_make;}
			set { _fld_make = value;}
		}

		[Description("CarModelID")]
		[DataMember]
		public Int64? CarModelID
		{
			get { return _CarModelID;}
			set { _CarModelID = value;}
		}

		[Description("fld_model")]
		[DataMember]
		public String fld_model
		{
			get { return _fld_model;}
			set { _fld_model = value;}
		}

		[Description("bs_Id")]
		[DataMember]
		public Int32? bs_Id
		{
			get { return _bs_Id;}
			set { _bs_Id = value;}
		}

		[Description("bs_Name")]
		[DataMember]
		public String bs_Name
		{
			get { return _bs_Name;}
			set { _bs_Name = value;}
		}

		[Description("cb_Id")]
		[DataMember]
		public Int32? cb_Id
		{
			get { return _cb_Id;}
			set { _cb_Id = value;}
		}

		[Description("cb_Name")]
		[DataMember]
		public String cb_Name
		{
			get { return _cb_Name;}
			set { _cb_Name = value;}
		}

		[Description("cs_Id")]
		[DataMember]
		public Int32? cs_Id
		{
			get { return _cs_Id;}
			set { _cs_Id = value;}
		}

		[Description("cs_Name")]
		[DataMember]
		public String cs_Name
		{
			get { return _cs_Name;}
			set { _cs_Name = value;}
		}

		#endregion
	}
}
