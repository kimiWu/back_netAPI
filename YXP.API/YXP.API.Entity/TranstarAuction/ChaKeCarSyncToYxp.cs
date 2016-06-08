using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace YXP.ADS.Entity
{
	[Serializable]
	[DataContract]
	public partial class ChaKeCarSyncToYxp
	{
		#region 私有变量
		private Int32 _id;
		private Int32? _taskId;
		private Int32? _carSourceID;
		private Int32? _syncStatus;
		private String _syncMessage;
		private DateTime? _createTime;
		#endregion

		# region 属性方法
		[Description("")]
		[DataMember]
		[Key]
		[Required]
		public Int32 id
		{
			get { return _id;}
			set { _id = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? taskId
		{
			get { return _taskId;}
			set { _taskId = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? carSourceID
		{
			get { return _carSourceID;}
			set { _carSourceID = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? syncStatus
		{
			get { return _syncStatus;}
			set { _syncStatus = value;}
		}

		[Description("")]
		[DataMember]
		public String syncMessage
		{
			get { return _syncMessage;}
			set { _syncMessage = value;}
		}

		[Description("")]
		[DataMember]
		public DateTime? createTime
		{
			get { return _createTime;}
			set { _createTime = value;}
		}

		#endregion
	}
}
