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
	public partial class MSpeer_originatorid_history
	{
		#region 私有变量
		private String _originator_publication;
		private Int32 _originator_id;
		private String _originator_node;
		private String _originator_db;
		private Int32 _originator_db_version;
		private Int32 _originator_version;
		private DateTime _inserted_date;
		#endregion

		# region 属性方法
		[Description("originator_publication")]
		[DataMember]
		[Required]
		public String originator_publication
		{
			get { return _originator_publication;}
			set { _originator_publication = value;}
		}

		[Description("originator_id")]
		[DataMember]
		[Required]
		public Int32 originator_id
		{
			get { return _originator_id;}
			set { _originator_id = value;}
		}

		[Description("originator_node")]
		[DataMember]
		[Required]
		public String originator_node
		{
			get { return _originator_node;}
			set { _originator_node = value;}
		}

		[Description("originator_db")]
		[DataMember]
		[Required]
		public String originator_db
		{
			get { return _originator_db;}
			set { _originator_db = value;}
		}

		[Description("originator_db_version")]
		[DataMember]
		[Required]
		public Int32 originator_db_version
		{
			get { return _originator_db_version;}
			set { _originator_db_version = value;}
		}

		[Description("originator_version")]
		[DataMember]
		[Required]
		public Int32 originator_version
		{
			get { return _originator_version;}
			set { _originator_version = value;}
		}

		[Description("inserted_date")]
		[DataMember]
		[Required]
		public DateTime inserted_date
		{
			get { return _inserted_date;}
			set { _inserted_date = value;}
		}

		#endregion
	}
}
