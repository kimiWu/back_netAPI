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
	public partial class CarAdminOffice
	{
		#region 私有变量
		private Int64 _ID;
		private Int32 _CityId;
		private String _CityName;
		private String _Name;
		private String _Address;
		private String _Phone;
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
		public String CityName
		{
			get { return _CityName;}
			set { _CityName = value;}
		}

		[Description("Name")]
		[DataMember]
		public String Name
		{
			get { return _Name;}
			set { _Name = value;}
		}

		[Description("Address")]
		[DataMember]
		public String Address
		{
			get { return _Address;}
			set { _Address = value;}
		}

		[Description("Phone")]
		[DataMember]
		public String Phone
		{
			get { return _Phone;}
			set { _Phone = value;}
		}

		#endregion
	}
}
