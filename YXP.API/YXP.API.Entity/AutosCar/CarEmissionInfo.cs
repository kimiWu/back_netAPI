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
	public partial class CarEmissionInfo
	{
		#region 私有变量
		private Int64 _ID;
		private String _RedCode;
		private String _Enterprise;
		private String _CarName;
		private String _EngineCode;
		private String _EngineFacatory;
		private String _Brand;
		private String _EmissionStander;
		private String _CarType;
		private String _ProductDate;
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

		[Description("RedCode")]
		[DataMember]
		public String RedCode
		{
			get { return _RedCode;}
			set { _RedCode = value;}
		}

		[Description("Enterprise")]
		[DataMember]
		public String Enterprise
		{
			get { return _Enterprise;}
			set { _Enterprise = value;}
		}

		[Description("CarName")]
		[DataMember]
		public String CarName
		{
			get { return _CarName;}
			set { _CarName = value;}
		}

		[Description("EngineCode")]
		[DataMember]
		public String EngineCode
		{
			get { return _EngineCode;}
			set { _EngineCode = value;}
		}

		[Description("EngineFacatory")]
		[DataMember]
		public String EngineFacatory
		{
			get { return _EngineFacatory;}
			set { _EngineFacatory = value;}
		}

		[Description("Brand")]
		[DataMember]
		public String Brand
		{
			get { return _Brand;}
			set { _Brand = value;}
		}

		[Description("EmissionStander")]
		[DataMember]
		public String EmissionStander
		{
			get { return _EmissionStander;}
			set { _EmissionStander = value;}
		}

		[Description("CarType")]
		[DataMember]
		public String CarType
		{
			get { return _CarType;}
			set { _CarType = value;}
		}

		[Description("ProductDate")]
		[DataMember]
		public String ProductDate
		{
			get { return _ProductDate;}
			set { _ProductDate = value;}
		}

		#endregion
	}
}
