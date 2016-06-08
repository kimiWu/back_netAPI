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
	public partial class Car_Basic
	{
		#region 私有变量
		private Int32 _Car_Id;
		private String _Car_ProduceState;
		private String _Car_SaleState;
		private Int32 _Cs_Id;
		private String _Car_Name;
		private String _SpellFirst;
		private Double? _car_ReferPrice;
		private Int32? _Car_YearType;
		private Int32 _IsState;
		private Int32 _IsLock;
		private Int64? _OLdCar_Id;
		private DateTime _CreateTime;
		private DateTime? _UpdateTime;
		private String _OldCar_Name;
		private String _AddPressType;
		#endregion

		# region 属性方法
		[Description("Car_Id")]
		[DataMember]
		[Key]
		[Required]
		public Int32 Car_Id
		{
			get { return _Car_Id;}
			set { _Car_Id = value;}
		}

		[Description("Car_ProduceState")]
		[DataMember]
		public String Car_ProduceState
		{
			get { return _Car_ProduceState;}
			set { _Car_ProduceState = value;}
		}

		[Description("Car_SaleState")]
		[DataMember]
		public String Car_SaleState
		{
			get { return _Car_SaleState;}
			set { _Car_SaleState = value;}
		}

		[Description("Cs_Id")]
		[DataMember]
		[Required]
		public Int32 Cs_Id
		{
			get { return _Cs_Id;}
			set { _Cs_Id = value;}
		}

		[Description("Car_Name")]
		[DataMember]
		[Required]
		public String Car_Name
		{
			get { return _Car_Name;}
			set { _Car_Name = value;}
		}

		[Description("SpellFirst")]
		[DataMember]
		public String SpellFirst
		{
			get { return _SpellFirst;}
			set { _SpellFirst = value;}
		}

		[Description("car_ReferPrice")]
		[DataMember]
		public Double? car_ReferPrice
		{
			get { return _car_ReferPrice;}
			set { _car_ReferPrice = value;}
		}

		[Description("Car_YearType")]
		[DataMember]
		public Int32? Car_YearType
		{
			get { return _Car_YearType;}
			set { _Car_YearType = value;}
		}

		[Description("IsState")]
		[DataMember]
		[Required]
		public Int32 IsState
		{
			get { return _IsState;}
			set { _IsState = value;}
		}

		[Description("IsLock")]
		[DataMember]
		[Required]
		public Int32 IsLock
		{
			get { return _IsLock;}
			set { _IsLock = value;}
		}

		[Description("OLdCar_Id")]
		[DataMember]
		public Int64? OLdCar_Id
		{
			get { return _OLdCar_Id;}
			set { _OLdCar_Id = value;}
		}

		[Description("CreateTime")]
		[DataMember]
		[Required]
		public DateTime CreateTime
		{
			get { return _CreateTime;}
			set { _CreateTime = value;}
		}

		[Description("UpdateTime")]
		[DataMember]
		public DateTime? UpdateTime
		{
			get { return _UpdateTime;}
			set { _UpdateTime = value;}
		}

		[Description("OldCar_Name")]
		[DataMember]
		public String OldCar_Name
		{
			get { return _OldCar_Name;}
			set { _OldCar_Name = value;}
		}

		[Description("AddPressType")]
		[DataMember]
		public String AddPressType
		{
			get { return _AddPressType;}
			set { _AddPressType = value;}
		}

		#endregion
	}
}
