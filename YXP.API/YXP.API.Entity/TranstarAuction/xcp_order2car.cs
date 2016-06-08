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
	public partial class xcp_order2car
	{
		#region 私有变量
		private Int64 _ID;
		private Int32? _xo2cid;
		private Int32? _xo_id;
		private Int32? _xcp_uuid;
		private String _xcp_uucode = "";
		private Int32? _bigarea_id;
		private Int32? _market_id;
		private Int32? _hy_carid;
		private Int32? _xcar_id;
		private String _xcar_name = "";
		private String _xcar_no = "";
		private String _xcar_vin = "";
		private Int16? _receive_type;
		private Int16? _return_status;
		private Decimal? _dealer_price;
		private Decimal? _purchase_price;
		private Decimal? _price;
		private Decimal? _fee;
		private Int16? _fee_package;
		private Int16? _ischange_fee;
		private Int16? _isbargain;
		private Int16? _transfer_type;
		private String _transfer_addr = "";
		private Int16? _status;
		private String _scene_time = "";
		private DateTime? _predict_dealer_time;
		private DateTime? _predict_market_time;
		private Int32? _first_tid;
		private DateTime? _first_time;
		private String _first_pic = "";
		private String _first_d_pic = "";
		private Int32? _recheck_tid;
		private DateTime? _recheck_time;
		private Int32? _assign_tester_id;
		private Int32? _assign_tester_time;
		private Int32? _tester_id;
		private DateTime? _test_time;
		private DateTime? _test_stime;
		private Int16? _test_status;
		private Int32? _master_id;
		private DateTime? _master_time;
		private DateTime? _updatetime;
		private Int32? _finance_status;
		private Decimal? _finance_amount;
		private DateTime? _finance_updatetime;
		private String _xcar_fullname = "";
		private String _parkingnumber = "";
		private Int16? _ismajorcity;
		private DateTime? _in_time;
		private Int16? _in_status;
		private Int32? _driverid;
		private String _carbodycolor = "";
		private String _carbodyoldcolor = "";
		private Int32? _peccancyresponsible;
		private Int32? _ProxyFee;
		private String _remark = "";
		private Int32? _LoseProcedures;
		private Int32? _Remake;
		private Int32? _peccancyresponsibleDay;
		private Int32? _certificates;
		private Decimal? _total_Price;
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
		public Int32? xo2cid
		{
			get { return _xo2cid;}
			set { _xo2cid = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? xo_id
		{
			get { return _xo_id;}
			set { _xo_id = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? xcp_uuid
		{
			get { return _xcp_uuid;}
			set { _xcp_uuid = value;}
		}

		[Description("")]
		[DataMember]
		public String xcp_uucode
		{
			get { return _xcp_uucode;}
			set { _xcp_uucode = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? bigarea_id
		{
			get { return _bigarea_id;}
			set { _bigarea_id = value;}
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
		public Int32? hy_carid
		{
			get { return _hy_carid;}
			set { _hy_carid = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? xcar_id
		{
			get { return _xcar_id;}
			set { _xcar_id = value;}
		}

		[Description("")]
		[DataMember]
		public String xcar_name
		{
			get { return _xcar_name;}
			set { _xcar_name = value;}
		}

		[Description("")]
		[DataMember]
		public String xcar_no
		{
			get { return _xcar_no;}
			set { _xcar_no = value;}
		}

		[Description("")]
		[DataMember]
		public String xcar_vin
		{
			get { return _xcar_vin;}
			set { _xcar_vin = value;}
		}

		[Description("")]
		[DataMember]
		public Int16? receive_type
		{
			get { return _receive_type;}
			set { _receive_type = value;}
		}

		[Description("")]
		[DataMember]
		public Int16? return_status
		{
			get { return _return_status;}
			set { _return_status = value;}
		}

		[Description("")]
		[DataMember]
		public Decimal? dealer_price
		{
			get { return _dealer_price;}
			set { _dealer_price = value;}
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
		public Decimal? price
		{
			get { return _price;}
			set { _price = value;}
		}

		[Description("")]
		[DataMember]
		public Decimal? fee
		{
			get { return _fee;}
			set { _fee = value;}
		}

		[Description("")]
		[DataMember]
		public Int16? fee_package
		{
			get { return _fee_package;}
			set { _fee_package = value;}
		}

		[Description("")]
		[DataMember]
		public Int16? ischange_fee
		{
			get { return _ischange_fee;}
			set { _ischange_fee = value;}
		}

		[Description("")]
		[DataMember]
		public Int16? isbargain
		{
			get { return _isbargain;}
			set { _isbargain = value;}
		}

		[Description("")]
		[DataMember]
		public Int16? transfer_type
		{
			get { return _transfer_type;}
			set { _transfer_type = value;}
		}

		[Description("")]
		[DataMember]
		public String transfer_addr
		{
			get { return _transfer_addr;}
			set { _transfer_addr = value;}
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
		public String scene_time
		{
			get { return _scene_time;}
			set { _scene_time = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? predict_dealer_time
		{
			get { return _predict_dealer_time;}
			set { _predict_dealer_time = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? predict_market_time
		{
			get { return _predict_market_time;}
			set { _predict_market_time = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? first_tid
		{
			get { return _first_tid;}
			set { _first_tid = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? first_time
		{
			get { return _first_time;}
			set { _first_time = value;}
		}

		[Description("")]
		[DataMember]
		public String first_pic
		{
			get { return _first_pic;}
			set { _first_pic = value;}
		}

		[Description("")]
		[DataMember]
		public String first_d_pic
		{
			get { return _first_d_pic;}
			set { _first_d_pic = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? recheck_tid
		{
			get { return _recheck_tid;}
			set { _recheck_tid = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? recheck_time
		{
			get { return _recheck_time;}
			set { _recheck_time = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? assign_tester_id
		{
			get { return _assign_tester_id;}
			set { _assign_tester_id = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? assign_tester_time
		{
			get { return _assign_tester_time;}
			set { _assign_tester_time = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? tester_id
		{
			get { return _tester_id;}
			set { _tester_id = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? test_time
		{
			get { return _test_time;}
			set { _test_time = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? test_stime
		{
			get { return _test_stime;}
			set { _test_stime = value;}
		}

		[Description("")]
		[DataMember]
		public Int16? test_status
		{
			get { return _test_status;}
			set { _test_status = value;}
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
		public DateTime? master_time
		{
			get { return _master_time;}
			set { _master_time = value;}
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
		public Int32? finance_status
		{
			get { return _finance_status;}
			set { _finance_status = value;}
		}

		[Description("")]
		[DataMember]
		public Decimal? finance_amount
		{
			get { return _finance_amount;}
			set { _finance_amount = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? finance_updatetime
		{
			get { return _finance_updatetime;}
			set { _finance_updatetime = value;}
		}

		[Description("")]
		[DataMember]
		public String xcar_fullname
		{
			get { return _xcar_fullname;}
			set { _xcar_fullname = value;}
		}

		[Description("")]
		[DataMember]
		public String parkingnumber
		{
			get { return _parkingnumber;}
			set { _parkingnumber = value;}
		}

		[Description("")]
		[DataMember]
		public Int16? ismajorcity
		{
			get { return _ismajorcity;}
			set { _ismajorcity = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? in_time
		{
			get { return _in_time;}
			set { _in_time = value;}
		}

		[Description("")]
		[DataMember]
		public Int16? in_status
		{
			get { return _in_status;}
			set { _in_status = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? driverid
		{
			get { return _driverid;}
			set { _driverid = value;}
		}

		[Description("")]
		[DataMember]
		public String carbodycolor
		{
			get { return _carbodycolor;}
			set { _carbodycolor = value;}
		}

		[Description("")]
		[DataMember]
		public String carbodyoldcolor
		{
			get { return _carbodyoldcolor;}
			set { _carbodyoldcolor = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? peccancyresponsible
		{
			get { return _peccancyresponsible;}
			set { _peccancyresponsible = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? ProxyFee
		{
			get { return _ProxyFee;}
			set { _ProxyFee = value;}
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
		public Int32? LoseProcedures
		{
			get { return _LoseProcedures;}
			set { _LoseProcedures = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? Remake
		{
			get { return _Remake;}
			set { _Remake = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? peccancyresponsibleDay
		{
			get { return _peccancyresponsibleDay;}
			set { _peccancyresponsibleDay = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? certificates
		{
			get { return _certificates;}
			set { _certificates = value;}
		}

		[Description("")]
		[DataMember]
		public Decimal? total_Price
		{
			get { return _total_Price;}
			set { _total_Price = value;}
		}

		#endregion
	}
}
