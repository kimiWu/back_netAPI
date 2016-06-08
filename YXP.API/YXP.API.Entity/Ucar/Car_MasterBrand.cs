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
	public partial class Car_MasterBrand
	{
		#region 私有变量
		private Int32 _bs_Id;
		private String _bs_Name;
		private String _bs_OtherName;
		private String _bs_Country;
		private String _bs_EName;
		private String _bs_Logo;
		private String _bs_Logo_2;
		private String _bs_LogoInfo;
		private String _spell;
		private DateTime? _CreateTime;
		private Int32 _IsState;
		private DateTime? _UpdateTime;
		private Int32? _IsLock;
		private String _urlspell;
		private String _bs_introduction;
		private String _bs_seoname;
		#endregion

		# region 属性方法
		[Description("bs_Id")]
		[DataMember]
		[Key]
		[Required]
		public Int32 bs_Id
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

		[Description("bs_OtherName")]
		[DataMember]
		public String bs_OtherName
		{
			get { return _bs_OtherName;}
			set { _bs_OtherName = value;}
		}

		[Description("bs_Country")]
		[DataMember]
		public String bs_Country
		{
			get { return _bs_Country;}
			set { _bs_Country = value;}
		}

		[Description("bs_EName")]
		[DataMember]
		public String bs_EName
		{
			get { return _bs_EName;}
			set { _bs_EName = value;}
		}

		[Description("bs_Logo")]
		[DataMember]
		public String bs_Logo
		{
			get { return _bs_Logo;}
			set { _bs_Logo = value;}
		}

		[Description("bs_Logo_2")]
		[DataMember]
		public String bs_Logo_2
		{
			get { return _bs_Logo_2;}
			set { _bs_Logo_2 = value;}
		}

		[Description("bs_LogoInfo")]
		[DataMember]
		public String bs_LogoInfo
		{
			get { return _bs_LogoInfo;}
			set { _bs_LogoInfo = value;}
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

		[Description("UpdateTime")]
		[DataMember]
		public DateTime? UpdateTime
		{
			get { return _UpdateTime;}
			set { _UpdateTime = value;}
		}

		[Description("IsLock")]
		[DataMember]
		public Int32? IsLock
		{
			get { return _IsLock;}
			set { _IsLock = value;}
		}

		[Description("urlspell")]
		[DataMember]
		public String urlspell
		{
			get { return _urlspell;}
			set { _urlspell = value;}
		}

		[Description("bs_introduction")]
		[DataMember]
		public String bs_introduction
		{
			get { return _bs_introduction;}
			set { _bs_introduction = value;}
		}

		[Description("bs_seoname")]
		[DataMember]
		public String bs_seoname
		{
			get { return _bs_seoname;}
			set { _bs_seoname = value;}
		}

		#endregion
	}
}
