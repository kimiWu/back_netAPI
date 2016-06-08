using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace YXP.API.Entity.TranstarAuction
{
	[Serializable]
	[DataContract]
	public partial class City
	{
		#region 私有变量
		private Int32 _city_Id;
		private String _city_Name = "";
		private String _city_Desc = "";
		private Int32? _pvc_Id;
		private Int32? _city_Sort;
		private Int32? _city_ZipPostId;
		private Int32? _city_Postcode;
		private String _allspell = "";
		private Int32? _BigAreaId;
		private Int32? _LevelCity;
		#endregion

		# region 属性方法
		[Description("")]
		[DataMember]
		[Key]
		[Required]
		public Int32 city_Id
		{
			get { return _city_Id;}
			set { _city_Id = value;}
		}

		[Description("")]
		[DataMember]
		public String city_Name
		{
			get { return _city_Name;}
			set { _city_Name = value;}
		}

		[Description("")]
		[DataMember]
		public String city_Desc
		{
			get { return _city_Desc;}
			set { _city_Desc = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? pvc_Id
		{
			get { return _pvc_Id;}
			set { _pvc_Id = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? city_Sort
		{
			get { return _city_Sort;}
			set { _city_Sort = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? city_ZipPostId
		{
			get { return _city_ZipPostId;}
			set { _city_ZipPostId = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? city_Postcode
		{
			get { return _city_Postcode;}
			set { _city_Postcode = value;}
		}

		[Description("")]
		[DataMember]
		public String allspell
		{
			get { return _allspell;}
			set { _allspell = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? BigAreaId
		{
			get { return _BigAreaId;}
			set { _BigAreaId = value;}
		}

		[Description("LevelCity")]
		[DataMember]
		public Int32? LevelCity
		{
			get { return _LevelCity;}
			set { _LevelCity = value;}
		}

		#endregion
	}
}
