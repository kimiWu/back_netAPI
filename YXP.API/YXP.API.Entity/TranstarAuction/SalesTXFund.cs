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
	public partial class SalesTXFund
	{
		#region 私有变量
		private Int32 _UserId;
		private Decimal? _CurrTXFund;
		private Decimal? _CurrActiveTXFund;
		private Decimal? _CurrFreezeTXFund;
		private DateTime? _CreateTime;
		#endregion

		# region 属性方法
		[Description("UserId")]
		[DataMember]
		[Key]
		[Required]
		public Int32 UserId
		{
			get { return _UserId;}
			set { _UserId = value;}
		}

		[Description("CurrTXFund")]
		[DataMember]
		public Decimal? CurrTXFund
		{
			get { return _CurrTXFund;}
			set { _CurrTXFund = value;}
		}

		[Description("CurrActiveTXFund")]
		[DataMember]
		public Decimal? CurrActiveTXFund
		{
			get { return _CurrActiveTXFund;}
			set { _CurrActiveTXFund = value;}
		}

		[Description("CurrFreezeTXFund")]
		[DataMember]
		public Decimal? CurrFreezeTXFund
		{
			get { return _CurrFreezeTXFund;}
			set { _CurrFreezeTXFund = value;}
		}

		[Description("CreateTime")]
		[DataMember]
		public DateTime? CreateTime
		{
			get { return _CreateTime;}
			set { _CreateTime = value;}
		}

		#endregion
	}
}
