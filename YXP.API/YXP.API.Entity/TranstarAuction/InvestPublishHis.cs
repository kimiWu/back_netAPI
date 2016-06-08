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
	public partial class InvestPublishHis
	{
		#region 私有变量
		private Int64 _ID;
		private Int32 _UserId;
		private Decimal? _CurrSalesPrice;
		private Decimal? _SWFee;
		private Int32? _InvestorUserId;
		private Decimal? _CurrInvestFund;
		private Decimal? _CompetitorPrice;
		private Decimal? _InvestMaxFee;
		private Int64? _PublishId;
		private Int32? _IsSuccess;
		private DateTime? _UpdateTime;
		private DateTime? _CreateTime;
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

		[Description("UserId")]
		[DataMember]
		[Required]
		public Int32 UserId
		{
			get { return _UserId;}
			set { _UserId = value;}
		}

		[Description("CurrSalesPrice")]
		[DataMember]
		public Decimal? CurrSalesPrice
		{
			get { return _CurrSalesPrice;}
			set { _CurrSalesPrice = value;}
		}

		[Description("SWFee")]
		[DataMember]
		public Decimal? SWFee
		{
			get { return _SWFee;}
			set { _SWFee = value;}
		}

		[Description("InvestorUserId")]
		[DataMember]
		public Int32? InvestorUserId
		{
			get { return _InvestorUserId;}
			set { _InvestorUserId = value;}
		}

		[Description("CurrInvestFund")]
		[DataMember]
		public Decimal? CurrInvestFund
		{
			get { return _CurrInvestFund;}
			set { _CurrInvestFund = value;}
		}

		[Description("CompetitorPrice")]
		[DataMember]
		public Decimal? CompetitorPrice
		{
			get { return _CompetitorPrice;}
			set { _CompetitorPrice = value;}
		}

		[Description("InvestMaxFee")]
		[DataMember]
		public Decimal? InvestMaxFee
		{
			get { return _InvestMaxFee;}
			set { _InvestMaxFee = value;}
		}

		[Description("PublishId")]
		[DataMember]
		public Int64? PublishId
		{
			get { return _PublishId;}
			set { _PublishId = value;}
		}

		[Description("IsSuccess")]
		[DataMember]
		public Int32? IsSuccess
		{
			get { return _IsSuccess;}
			set { _IsSuccess = value;}
		}

		[Description("UpdateTime")]
		[DataMember]
		public DateTime? UpdateTime
		{
			get { return _UpdateTime;}
			set { _UpdateTime = value;}
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
