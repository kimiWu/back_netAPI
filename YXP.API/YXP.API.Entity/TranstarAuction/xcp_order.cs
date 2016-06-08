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
	public partial class xcp_order
	{
		#region 私有变量
		private Int64 _ID;
		private Int32? _xoid;
		private Int32? _market_id;
		private String _market_name = "";
		private Int32? _dealer_id;
		private String _dealer_user = "";
		private String _dealer_mobile = "";
		private String _dealer_addr = "";
		private Int32? _dealer_type;
		private Int32? _price_uid;
		private String _price_user = "";
		private String _price_user_mobile = "";
		private Int32? _car_self;
		private DateTime? _car_self_time;
		private Int32? _car_self_real;
		private Int32? _car_self_assign;
		private Int32? _car_agent;
		private DateTime? _car_agent_time;
		private Int32? _car_agent_real;
		private DateTime? _publish_time;
		private Int16? _status;
		private Int16? _type;
		private Int32? _assign_id;
		private Int32? _master_id;
		private DateTime? _createtime;
		private DateTime? _updatetime;
		private Decimal? _purchase_price;
		private String _fetch_user = "";
		private String _fetch_user_mobile = "";
		private String _remark = "";
		private String _VendorShortName = "";
		private Int32? _isPayProxy;
		#endregion

		# region 属性方法
		[Description("")]
		[DataMember]
		[Key]
		[Required]
		public Int64 ID
		{
			get { return _ID;}
			set { _ID = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? xoid
		{
			get { return _xoid;}
			set { _xoid = value;}
		}


		[Description("")]
		[DataMember]
		public Int32? market_id
		{
			get { return _market_id;}
			set { _market_id = value;}
		}

		[Description("")]
		[DataMember]
		public String market_name
		{
			get { return _market_name;}
			set { _market_name = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? dealer_id
		{
			get { return _dealer_id;}
			set { _dealer_id = value;}
		}

		[Description("")]
		[DataMember]
		public String dealer_user
		{
			get { return _dealer_user;}
			set { _dealer_user = value;}
		}

		[Description("")]
		[DataMember]
		public String dealer_mobile
		{
			get { return _dealer_mobile;}
			set { _dealer_mobile = value;}
		}

		[Description("")]
		[DataMember]
		public String dealer_addr
		{
			get { return _dealer_addr;}
			set { _dealer_addr = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? dealer_type
		{
			get { return _dealer_type;}
			set { _dealer_type = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? price_uid
		{
			get { return _price_uid;}
			set { _price_uid = value;}
		}

		[Description("")]
		[DataMember]
		public String price_user
		{
			get { return _price_user;}
			set { _price_user = value;}
		}

		[Description("")]
		[DataMember]
		public String price_user_mobile
		{
			get { return _price_user_mobile;}
			set { _price_user_mobile = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? car_self
		{
			get { return _car_self;}
			set { _car_self = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? car_self_time
		{
			get { return _car_self_time;}
			set { _car_self_time = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? car_self_real
		{
			get { return _car_self_real;}
			set { _car_self_real = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? car_self_assign
		{
			get { return _car_self_assign;}
			set { _car_self_assign = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? car_agent
		{
			get { return _car_agent;}
			set { _car_agent = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? car_agent_time
		{
			get { return _car_agent_time;}
			set { _car_agent_time = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? car_agent_real
		{
			get { return _car_agent_real;}
			set { _car_agent_real = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? publish_time
		{
			get { return _publish_time;}
			set { _publish_time = value;}
		}

		[Description("")]
		[DataMember]
		public Int16? status
		{
			get { return _status;}
			set { _status = value;}
		}

		[Description("")]
		[DataMember]
		public Int16? type
		{
			get { return _type;}
			set { _type = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? assign_id
		{
			get { return _assign_id;}
			set { _assign_id = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? master_id
		{
			get { return _master_id;}
			set { _master_id = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? createtime
		{
			get { return _createtime;}
			set { _createtime = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? updatetime
		{
			get { return _updatetime;}
			set { _updatetime = value;}
		}

		[Description("")]
		[DataMember]
		public Decimal? purchase_price
		{
			get { return _purchase_price;}
			set { _purchase_price = value;}
		}

		[Description("")]
		[DataMember]
		public String fetch_user
		{
			get { return _fetch_user;}
			set { _fetch_user = value;}
		}

		[Description("")]
		[DataMember]
		public String fetch_user_mobile
		{
			get { return _fetch_user_mobile;}
			set { _fetch_user_mobile = value;}
		}

		[Description("")]
		[DataMember]
		public String remark
		{
			get { return _remark;}
			set { _remark = value;}
		}

		[Description("")]
		[DataMember]
		public String VendorShortName
		{
			get { return _VendorShortName;}
			set { _VendorShortName = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? isPayProxy
		{
			get { return _isPayProxy;}
			set { _isPayProxy = value;}
		}

		#endregion
	}
}
