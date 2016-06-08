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
	public partial class AuctionArrangeItem
	{
		#region 私有变量
		private Int32 _ID;
		private String _ArrangeItem = "";
		private Int32? _ArrangeFee;
		private String _ArrangeItemRemark = "";
		private DateTime? _CreateTime;
		#endregion

		# region 属性方法
		[Description("")]
		[DataMember]
		[Key]
		[Required]
		public Int32 ID
		{
			get { return _ID;}
			set { _ID = value;}
		}

		[Description("")]
		[DataMember]
		public String ArrangeItem
		{
			get { return _ArrangeItem;}
			set { _ArrangeItem = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? ArrangeFee
		{
			get { return _ArrangeFee;}
			set { _ArrangeFee = value;}
		}

		[Description("")]
		[DataMember]
		public String ArrangeItemRemark
		{
			get { return _ArrangeItemRemark;}
			set { _ArrangeItemRemark = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? CreateTime
		{
			get { return _CreateTime;}
			set { _CreateTime = value;}
		}

		#endregion
	}
}
