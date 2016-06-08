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
	public partial class AspNet_SqlCacheTablesForChangeNotification
	{
		#region 私有变量
		private String _tableName;
		private DateTime _notificationCreated;
		private Int32 _changeId;
		#endregion

		# region 属性方法
		[Description("tableName")]
		[DataMember]
		[Key]
		[Required]
		public String tableName
		{
			get { return _tableName;}
			set { _tableName = value;}
		}

		[Description("notificationCreated")]
		[DataMember]
		[Required]
		public DateTime notificationCreated
		{
			get { return _notificationCreated;}
			set { _notificationCreated = value;}
		}

		[Description("changeId")]
		[DataMember]
		[Required]
		public Int32 changeId
		{
			get { return _changeId;}
			set { _changeId = value;}
		}

		#endregion
	}
}
