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
	public partial class Car_Producer
	{
		#region 私有变量
		private Int32 _Cp_Id;
		private String _Cp_Name;
		private String _Cp_ShortName;
		private String _Cp_Byname;
		private String _Cp_EName;
		private String _Cp_Country;
		private String _Cp_Url;
		private String _Cp_Phone;
		private DateTime? _CreateTime;
		private String _Spell;
		private String _Cp_Introduction;
		private String _Cp_LogoUrl;
		private Int32 _IsState;
		private DateTime? _UpdateTime;
		private Int32? _OldCp_Id;
		#endregion

		# region 属性方法
		[Description("Cp_Id")]
		[DataMember]
		[Key]
		[Required]
		public Int32 Cp_Id
		{
			get { return _Cp_Id;}
			set { _Cp_Id = value;}
		}

		[Description("Cp_Name")]
		[DataMember]
		public String Cp_Name
		{
			get { return _Cp_Name;}
			set { _Cp_Name = value;}
		}

		[Description("Cp_ShortName")]
		[DataMember]
		public String Cp_ShortName
		{
			get { return _Cp_ShortName;}
			set { _Cp_ShortName = value;}
		}

		[Description("Cp_Byname")]
		[DataMember]
		public String Cp_Byname
		{
			get { return _Cp_Byname;}
			set { _Cp_Byname = value;}
		}

		[Description("Cp_EName")]
		[DataMember]
		public String Cp_EName
		{
			get { return _Cp_EName;}
			set { _Cp_EName = value;}
		}

		[Description("Cp_Country")]
		[DataMember]
		public String Cp_Country
		{
			get { return _Cp_Country;}
			set { _Cp_Country = value;}
		}

		[Description("Cp_Url")]
		[DataMember]
		public String Cp_Url
		{
			get { return _Cp_Url;}
			set { _Cp_Url = value;}
		}

		[Description("Cp_Phone")]
		[DataMember]
		public String Cp_Phone
		{
			get { return _Cp_Phone;}
			set { _Cp_Phone = value;}
		}

		[Description("CreateTime")]
		[DataMember]
		public DateTime? CreateTime
		{
			get { return _CreateTime;}
			set { _CreateTime = value;}
		}

		[Description("Spell")]
		[DataMember]
		public String Spell
		{
			get { return _Spell;}
			set { _Spell = value;}
		}

		[Description("Cp_Introduction")]
		[DataMember]
		public String Cp_Introduction
		{
			get { return _Cp_Introduction;}
			set { _Cp_Introduction = value;}
		}

		[Description("Cp_LogoUrl")]
		[DataMember]
		public String Cp_LogoUrl
		{
			get { return _Cp_LogoUrl;}
			set { _Cp_LogoUrl = value;}
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

		[Description("OldCp_Id")]
		[DataMember]
		public Int32? OldCp_Id
		{
			get { return _OldCp_Id;}
			set { _OldCp_Id = value;}
		}

		#endregion
	}
}
