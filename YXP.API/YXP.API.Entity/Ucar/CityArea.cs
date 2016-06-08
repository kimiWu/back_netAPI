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
	public partial class CityArea
	{
		#region 私有变量
		private Int32 _cityarea_Id;
		private String _cityarea_Name;
		private Int32? _city_Id;
		private String _allspell;
		#endregion

		# region 属性方法
		[Description("cityarea_Id")]
		[DataMember]
		[Key]
		[Required]
		public Int32 cityarea_Id
		{
			get { return _cityarea_Id;}
			set { _cityarea_Id = value;}
		}

		[Description("cityarea_Name")]
		[DataMember]
		public String cityarea_Name
		{
			get { return _cityarea_Name;}
			set { _cityarea_Name = value;}
		}

		[Description("city_Id")]
		[DataMember]
		public Int32? city_Id
		{
			get { return _city_Id;}
			set { _city_Id = value;}
		}

		[Description("allspell")]
		[DataMember]
		public String allspell
		{
			get { return _allspell;}
			set { _allspell = value;}
		}

		#endregion
	}
}
