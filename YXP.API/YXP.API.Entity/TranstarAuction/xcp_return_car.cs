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
	public partial class xcp_return_car
	{
		#region 私有变量
		private Int64 _ID;
		private Int32? _xcar_id;
		private Int16? _status;
		private String _formalities = "";
		private Int16? _pick_car;
		private String _pick_car_pic = "";
		private String _pick_car_remark = "";
		private Int32? _proposer;
		private DateTime? _apply_time;
		private String _reason = "";
		private Int16? _return_type;
		private DateTime? _predict_return_time;
		private DateTime? _predict_arrive_time;
		private DateTime? _arrive_time;
		private Int32? _return_tid;
		private DateTime? _assign_time;
		private Int32? _assign_tid;
		private String _dealer_pic = "";
		private String _op_pic = "";
		private String _pic = "";
		private String _remark = "";
		private DateTime? _createtime;
		private DateTime? _updatetime;
		private Int32? _driverid;
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
		public Int32? xcar_id
		{
			get { return _xcar_id;}
			set { _xcar_id = value;}
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
		public String formalities
		{
			get { return _formalities;}
			set { _formalities = value;}
		}

		[Description("")]
		[DataMember]
		public Int16? pick_car
		{
			get { return _pick_car;}
			set { _pick_car = value;}
		}

		[Description("")]
		[DataMember]
		public String pick_car_pic
		{
			get { return _pick_car_pic;}
			set { _pick_car_pic = value;}
		}

		[Description("")]
		[DataMember]
		public String pick_car_remark
		{
			get { return _pick_car_remark;}
			set { _pick_car_remark = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? proposer
		{
			get { return _proposer;}
			set { _proposer = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? apply_time
		{
			get { return _apply_time;}
			set { _apply_time = value;}
		}

		[Description("")]
		[DataMember]
		public String reason
		{
			get { return _reason;}
			set { _reason = value;}
		}

		[Description("")]
		[DataMember]
		public Int16? return_type
		{
			get { return _return_type;}
			set { _return_type = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? predict_return_time
		{
			get { return _predict_return_time;}
			set { _predict_return_time = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? predict_arrive_time
		{
			get { return _predict_arrive_time;}
			set { _predict_arrive_time = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? arrive_time
		{
			get { return _arrive_time;}
			set { _arrive_time = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? return_tid
		{
			get { return _return_tid;}
			set { _return_tid = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? assign_time
		{
			get { return _assign_time;}
			set { _assign_time = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? assign_tid
		{
			get { return _assign_tid;}
			set { _assign_tid = value;}
		}

		[Description("")]
		[DataMember]
		public String dealer_pic
		{
			get { return _dealer_pic;}
			set { _dealer_pic = value;}
		}

		[Description("")]
		[DataMember]
		public String op_pic
		{
			get { return _op_pic;}
			set { _op_pic = value;}
		}

		[Description("")]
		[DataMember]
		public String pic
		{
			get { return _pic;}
			set { _pic = value;}
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
		public Int32? driverid
		{
			get { return _driverid;}
			set { _driverid = value;}
		}

		#endregion
	}
}
