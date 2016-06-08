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
	public partial class CityEmissionStander
	{
		#region 私有变量
		private Int64 _ID;
		private Int32 _CityId;
		private String _CityName;
		private String _ProvinceName;
		private String _EmissionStander;
		#endregion

		# region 属性方法
		[Description("ID")]
		[DataMember]
		[Key]
		[Required]
		public Int64 ID
		{
			get { return _ID;}
			set { _ID = value;}
		}

		[Description("CityId")]
		[DataMember]
		[Required]
		public Int32 CityId
		{
			get { return _CityId;}
			set { _CityId = value;}
		}

		[Description("CityName")]
		[DataMember]
		[Required]
		public String CityName
		{
			get { return _CityName;}
			set { _CityName = value;}
		}

		[Description("ProvinceName")]
		[DataMember]
		public String ProvinceName
		{
			get { return _ProvinceName;}
			set { _ProvinceName = value;}
		}

		[Description("EmissionStander")]
		[DataMember]
		public String EmissionStander
		{
			get { return _EmissionStander;}
			set { _EmissionStander = value;}
		}

		#endregion
	}
}
