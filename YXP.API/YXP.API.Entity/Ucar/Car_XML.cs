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
	public partial class Car_XML
	{
		#region 私有变量
		private Int32 _Car_ID;
		private String _XmlData;
		#endregion

		# region 属性方法
		[Description("Car_ID")]
		[DataMember]
		[Key]
		[Required]
		public Int32 Car_ID
		{
			get { return _Car_ID;}
			set { _Car_ID = value;}
		}

		[Description("XmlData")]
		[DataMember]
		[Required]
		public String XmlData
		{
			get { return _XmlData;}
			set { _XmlData = value;}
		}

		#endregion
	}
}
