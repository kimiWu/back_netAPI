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
	public partial class AuctionTransferAddress
	{
		#region 私有变量
		private Int32 _SysAddressID;
		private Int32 _BelongCityId;
		private String _AddressName = "";
		private Decimal _AgentTransferFee;
		private Int32 _Remark;
		private Int32 _TransferType;
		private String _LinkManName = "";
		private String _LinkManPhoneNumber = "";
		#endregion

		# region 属性方法
		[Description("过户市场id")]
		[DataMember]
		[Key]
		[Required]
		public Int32 SysAddressID
		{
			get { return _SysAddressID;}
			set { _SysAddressID = value;}
		}

		[Description("城市id")]
		[DataMember]
		[Required]
		public Int32 BelongCityId
		{
			get { return _BelongCityId;}
			set { _BelongCityId = value;}
		}

		[Description("过户市场名称")]
		[DataMember]
		public String AddressName
		{
			get { return _AddressName;}
			set { _AddressName = value;}
		}

		[Description("代理费")]
		[DataMember]
		[Required]
		public Decimal AgentTransferFee
		{
			get { return _AgentTransferFee;}
			set { _AgentTransferFee = value;}
		}

		[Description("是否启用：1=启用 0=禁用")]
		[DataMember]
		[Required]
		public Int32 Remark
		{
			get { return _Remark;}
			set { _Remark = value;}
		}

		[Description("过户方式：1=本市 2=外迁")]
		[DataMember]
		[Required]
		public Int32 TransferType
		{
			get { return _TransferType;}
			set { _TransferType = value;}
		}

		[Description("过户市场联系人")]
		[DataMember]
		public String LinkManName
		{
			get { return _LinkManName;}
			set { _LinkManName = value;}
		}

		[Description("过户市场联系电话")]
		[DataMember]
		public String LinkManPhoneNumber
		{
			get { return _LinkManPhoneNumber;}
			set { _LinkManPhoneNumber = value;}
		}

		#endregion
	}
}
