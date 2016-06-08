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
	public partial class Car_Brand
	{
		#region 私有变量
		private Int32 _cb_Id;
		private Int32? _cp_Id;
		private String _cb_Name;
		private String _cb_OtherName;
		private String _cb_Country;
		private String _cb_EName;
		private String _cb_Phone;
		private String _cb_url;
		private String _cb_introduction;
		private String _cb_Logo;
		private String _spell;
		private DateTime? _CreateTime;
		private Int32 _IsState;
		private Int32? _OldCs_Id;
		private DateTime? _UpdateTime;
		private String _CbSaleState;
		private Int32? _bs_id;
		private String _allspell;
		private String _brandpic;
		#endregion

		# region 属性方法
		[Description("cb_Id")]
		[DataMember]
		[Key]
		[Required]
		public Int32 cb_Id
		{
			get { return _cb_Id;}
			set { _cb_Id = value;}
		}

		[Description("cp_Id")]
		[DataMember]
		public Int32? cp_Id
		{
			get { return _cp_Id;}
			set { _cp_Id = value;}
		}

		[Description("cb_Name")]
		[DataMember]
		public String cb_Name
		{
			get { return _cb_Name;}
			set { _cb_Name = value;}
		}

		[Description("cb_OtherName")]
		[DataMember]
		public String cb_OtherName
		{
			get { return _cb_OtherName;}
			set { _cb_OtherName = value;}
		}

		[Description("cb_Country")]
		[DataMember]
		public String cb_Country
		{
			get { return _cb_Country;}
			set { _cb_Country = value;}
		}

		[Description("cb_EName")]
		[DataMember]
		public String cb_EName
		{
			get { return _cb_EName;}
			set { _cb_EName = value;}
		}

		[Description("cb_Phone")]
		[DataMember]
		public String cb_Phone
		{
			get { return _cb_Phone;}
			set { _cb_Phone = value;}
		}

		[Description("cb_url")]
		[DataMember]
		public String cb_url
		{
			get { return _cb_url;}
			set { _cb_url = value;}
		}

		[Description("cb_introduction")]
		[DataMember]
		public String cb_introduction
		{
			get { return _cb_introduction;}
			set { _cb_introduction = value;}
		}

		[Description("cb_Logo")]
		[DataMember]
		public String cb_Logo
		{
			get { return _cb_Logo;}
			set { _cb_Logo = value;}
		}

		[Description("spell")]
		[DataMember]
		public String spell
		{
			get { return _spell;}
			set { _spell = value;}
		}

		[Description("CreateTime")]
		[DataMember]
		public DateTime? CreateTime
		{
			get { return _CreateTime;}
			set { _CreateTime = value;}
		}

		[Description("IsState")]
		[DataMember]
		[Required]
		public Int32 IsState
		{
			get { return _IsState;}
			set { _IsState = value;}
		}

		[Description("OldCs_Id")]
		[DataMember]
		public Int32? OldCs_Id
		{
			get { return _OldCs_Id;}
			set { _OldCs_Id = value;}
		}

		[Description("UpdateTime")]
		[DataMember]
		public DateTime? UpdateTime
		{
			get { return _UpdateTime;}
			set { _UpdateTime = value;}
		}

		[Description("CbSaleState")]
		[DataMember]
		public String CbSaleState
		{
			get { return _CbSaleState;}
			set { _CbSaleState = value;}
		}

		[Description("bs_id")]
		[DataMember]
		public Int32? bs_id
		{
			get { return _bs_id;}
			set { _bs_id = value;}
		}

		[Description("allspell")]
		[DataMember]
		public String allspell
		{
			get { return _allspell;}
			set { _allspell = value;}
		}

		[Description("brandpic")]
		[DataMember]
		public String brandpic
		{
			get { return _brandpic;}
			set { _brandpic = value;}
		}

		#endregion
	}
}
