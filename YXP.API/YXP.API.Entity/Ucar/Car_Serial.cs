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
	public partial class Car_Serial
	{
		#region 私有变量
		private Int32 _cs_Id;
		private Int32? _cb_Id;
		private String _cs_Name;
		private String _cs_OtherName;
		private String _cs_EName;
		private String _cs_Url;
		private String _cs_Phone;
		private String _cs_Introduction;
		private String _cs_Tag;
		private String _cs_photo;
		private String _cs_Virtues;
		private String _cs_Defect;
		private String _spell;
		private DateTime? _CreateTime;
		private String _cs_CarType;
		private String _cs_Cliques;
		private String _prototypeCar;
		private String _cs_CarLevel;
		private Int32 _IsState;
		private Int32? _OldCb_Id;
		private DateTime? _UpdateTime;
		private String _CsSaleState;
		private String _cs_ShowName;
		private String _allspell;
		private String _csbodyform;
		#endregion

		# region 属性方法
		[Description("cs_Id")]
		[DataMember]
		[Key]
		[Required]
		public Int32 cs_Id
		{
			get { return _cs_Id;}
			set { _cs_Id = value;}
		}

		[Description("cb_Id")]
		[DataMember]
		public Int32? cb_Id
		{
			get { return _cb_Id;}
			set { _cb_Id = value;}
		}

		[Description("cs_Name")]
		[DataMember]
		public String cs_Name
		{
			get { return _cs_Name;}
			set { _cs_Name = value;}
		}

		[Description("cs_OtherName")]
		[DataMember]
		public String cs_OtherName
		{
			get { return _cs_OtherName;}
			set { _cs_OtherName = value;}
		}

		[Description("cs_EName")]
		[DataMember]
		public String cs_EName
		{
			get { return _cs_EName;}
			set { _cs_EName = value;}
		}

		[Description("cs_Url")]
		[DataMember]
		public String cs_Url
		{
			get { return _cs_Url;}
			set { _cs_Url = value;}
		}

		[Description("cs_Phone")]
		[DataMember]
		public String cs_Phone
		{
			get { return _cs_Phone;}
			set { _cs_Phone = value;}
		}

		[Description("cs_Introduction")]
		[DataMember]
		public String cs_Introduction
		{
			get { return _cs_Introduction;}
			set { _cs_Introduction = value;}
		}

		[Description("cs_Tag")]
		[DataMember]
		public String cs_Tag
		{
			get { return _cs_Tag;}
			set { _cs_Tag = value;}
		}

		[Description("cs_photo")]
		[DataMember]
		public String cs_photo
		{
			get { return _cs_photo;}
			set { _cs_photo = value;}
		}

		[Description("cs_Virtues")]
		[DataMember]
		public String cs_Virtues
		{
			get { return _cs_Virtues;}
			set { _cs_Virtues = value;}
		}

		[Description("cs_Defect")]
		[DataMember]
		public String cs_Defect
		{
			get { return _cs_Defect;}
			set { _cs_Defect = value;}
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

		[Description("cs_CarType")]
		[DataMember]
		public String cs_CarType
		{
			get { return _cs_CarType;}
			set { _cs_CarType = value;}
		}

		[Description("cs_Cliques")]
		[DataMember]
		public String cs_Cliques
		{
			get { return _cs_Cliques;}
			set { _cs_Cliques = value;}
		}

		[Description("prototypeCar")]
		[DataMember]
		public String prototypeCar
		{
			get { return _prototypeCar;}
			set { _prototypeCar = value;}
		}

		[Description("cs_CarLevel")]
		[DataMember]
		public String cs_CarLevel
		{
			get { return _cs_CarLevel;}
			set { _cs_CarLevel = value;}
		}

		[Description("IsState")]
		[DataMember]
		[Required]
		public Int32 IsState
		{
			get { return _IsState;}
			set { _IsState = value;}
		}

		[Description("OldCb_Id")]
		[DataMember]
		public Int32? OldCb_Id
		{
			get { return _OldCb_Id;}
			set { _OldCb_Id = value;}
		}

		[Description("UpdateTime")]
		[DataMember]
		public DateTime? UpdateTime
		{
			get { return _UpdateTime;}
			set { _UpdateTime = value;}
		}

		[Description("CsSaleState")]
		[DataMember]
		public String CsSaleState
		{
			get { return _CsSaleState;}
			set { _CsSaleState = value;}
		}

		[Description("cs_ShowName")]
		[DataMember]
		public String cs_ShowName
		{
			get { return _cs_ShowName;}
			set { _cs_ShowName = value;}
		}

		[Description("allspell")]
		[DataMember]
		public String allspell
		{
			get { return _allspell;}
			set { _allspell = value;}
		}

		[Description("csbodyform")]
		[DataMember]
		public String csbodyform
		{
			get { return _csbodyform;}
			set { _csbodyform = value;}
		}

		#endregion
	}
}
