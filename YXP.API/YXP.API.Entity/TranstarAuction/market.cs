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
	public partial class market
	{
		#region 私有变量
		private Int32 _marketid;
		private Int32 _dealer_id;
		private Int32 _bigareaid;
		private Int32 _cityid;
		private String _nc_company_id = "";
		private String _marketname = "";
		private String _lng = "";
		private String _lat = "";
		private String _linkman = "";
		private String _mobile = "";
		private String _address = "";
		private DateTime? _updatetime;
		private DateTime? _createtime;
		private Byte _level;
		private Byte _market_type;
		#endregion

		# region 属性方法
		[Description("")]
		[DataMember]
		[Key]
		[Required]
		public Int32 marketid
		{
			get { return _marketid;}
			set { _marketid = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 dealer_id
		{
			get { return _dealer_id;}
			set { _dealer_id = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 bigareaid
		{
			get { return _bigareaid;}
			set { _bigareaid = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 cityid
		{
			get { return _cityid;}
			set { _cityid = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String nc_company_id
		{
			get { return _nc_company_id;}
			set { _nc_company_id = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String marketname
		{
			get { return _marketname;}
			set { _marketname = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String lng
		{
			get { return _lng;}
			set { _lng = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String lat
		{
			get { return _lat;}
			set { _lat = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String linkman
		{
			get { return _linkman;}
			set { _linkman = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String mobile
		{
			get { return _mobile;}
			set { _mobile = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String address
		{
			get { return _address;}
			set { _address = value;}
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
		public DateTime? createtime
		{
			get { return _createtime;}
			set { _createtime = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Byte level
		{
			get { return _level;}
			set { _level = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Byte market_type
		{
			get { return _market_type;}
			set { _market_type = value;}
		}

		#endregion
	}
}
