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
	public partial class MSpeer_lsns
	{
		#region 私有变量
		private Int32 _id;
		private DateTime? _last_updated;
		private String _originator;
		private String _originator_db;
		private String _originator_publication;
		private Int32? _originator_publication_id;
		private Int32? _originator_db_version;
		private Byte[] _originator_lsn;
		private Int32? _originator_version;
		private Int32? _originator_id;
		#endregion

		# region 属性方法
		[Description("id")]
		[DataMember]
		[Required]
		public Int32 id
		{
			get { return _id;}
			set { _id = value;}
		}

		[Description("last_updated")]
		[DataMember]
		public DateTime? last_updated
		{
			get { return _last_updated;}
			set { _last_updated = value;}
		}

		[Description("originator")]
		[DataMember]
		[Required]
		public String originator
		{
			get { return _originator;}
			set { _originator = value;}
		}

		[Description("originator_db")]
		[DataMember]
		[Required]
		public String originator_db
		{
			get { return _originator_db;}
			set { _originator_db = value;}
		}

		[Description("originator_publication")]
		[DataMember]
		[Required]
		public String originator_publication
		{
			get { return _originator_publication;}
			set { _originator_publication = value;}
		}

		[Description("originator_publication_id")]
		[DataMember]
		public Int32? originator_publication_id
		{
			get { return _originator_publication_id;}
			set { _originator_publication_id = value;}
		}

		[Description("originator_db_version")]
		[DataMember]
		public Int32? originator_db_version
		{
			get { return _originator_db_version;}
			set { _originator_db_version = value;}
		}

		[Description("originator_lsn")]
		[DataMember]
		public Byte[] originator_lsn
		{
			get { return _originator_lsn;}
			set { _originator_lsn = value;}
		}

		[Description("originator_version")]
		[DataMember]
		public Int32? originator_version
		{
			get { return _originator_version;}
			set { _originator_version = value;}
		}

		[Description("originator_id")]
		[DataMember]
		public Int32? originator_id
		{
			get { return _originator_id;}
			set { _originator_id = value;}
		}

		#endregion
	}
}
