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
	public partial class AuctionGuaranteeFund
	{
		#region 私有变量
		private Int32 _TvaId;
		private Decimal _CurrBalance;
		private Decimal _CurrActiveBalance;
		private Decimal _CurrFreeze;
		private Decimal _TotalBalance;
		private Decimal _TotalPunish;
		private Decimal _TotalDraw;
		private Decimal _TotalBalanceOnline;
		private Decimal _TotalBalanceOffline;
		private Decimal _TotalBalanceVirtual;
		private Int32 _BelongType;
		private Decimal? _TotalGet;
		private Decimal _CurrCreditBalance;
		private Decimal _FreezeCreditBalance;
		private Int32 _CreditLimit;
		private Int32 _CreditLimitFreeze;
		#endregion

		# region 属性方法
		[Description("")]
		[DataMember]
		[Key]
		[Required]
		public Int32 TvaId
		{
			get { return _TvaId;}
			set { _TvaId = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Decimal CurrBalance
		{
			get { return _CurrBalance;}
			set { _CurrBalance = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Decimal CurrActiveBalance
		{
			get { return _CurrActiveBalance;}
			set { _CurrActiveBalance = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Decimal CurrFreeze
		{
			get { return _CurrFreeze;}
			set { _CurrFreeze = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Decimal TotalBalance
		{
			get { return _TotalBalance;}
			set { _TotalBalance = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Decimal TotalPunish
		{
			get { return _TotalPunish;}
			set { _TotalPunish = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Decimal TotalDraw
		{
			get { return _TotalDraw;}
			set { _TotalDraw = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Decimal TotalBalanceOnline
		{
			get { return _TotalBalanceOnline;}
			set { _TotalBalanceOnline = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Decimal TotalBalanceOffline
		{
			get { return _TotalBalanceOffline;}
			set { _TotalBalanceOffline = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Decimal TotalBalanceVirtual
		{
			get { return _TotalBalanceVirtual;}
			set { _TotalBalanceVirtual = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 BelongType
		{
			get { return _BelongType;}
			set { _BelongType = value;}
		}

		[Description("TotalGet")]
		[DataMember]
		public Decimal? TotalGet
		{
			get { return _TotalGet;}
			set { _TotalGet = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Decimal CurrCreditBalance
		{
			get { return _CurrCreditBalance;}
			set { _CurrCreditBalance = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Decimal FreezeCreditBalance
		{
			get { return _FreezeCreditBalance;}
			set { _FreezeCreditBalance = value;}
		}

		[Description("CreditLimit")]
		[DataMember]
		[Required]
		public Int32 CreditLimit
		{
			get { return _CreditLimit;}
			set { _CreditLimit = value;}
		}

		[Description("CreditLimitFreeze")]
		[DataMember]
		[Required]
		public Int32 CreditLimitFreeze
		{
			get { return _CreditLimitFreeze;}
			set { _CreditLimitFreeze = value;}
		}

		#endregion
	}
}
