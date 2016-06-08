using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace YXP.API.Entity.AutosCar
{
	[Serializable]
	[DataContract]
	public partial class tab_ChangeHistory
	{
		#region 私有变量
		private Int32 _ID;
		private Int32 _RecordID;
		private Int32 _OperateID;
		private Int32 _TableID;
		private Int32? _DataID;
		private DateTime? _UpdateTime;
		private DateTime? _ChangeTime;
		private Int32? _Status;
		private String _Explanation;
		#endregion

		# region 属性方法
		[Description("ID")]
		[DataMember]
		[Required]
		public Int32 ID
		{
			get { return _ID;}
			set { _ID = value;}
		}

		[Description("RecordID")]
		[DataMember]
		[Key]
		[Required]
		public Int32 RecordID
		{
			get { return _RecordID;}
			set { _RecordID = value;}
		}

		[Description("OperateID")]
		[DataMember]
		[Required]
		public Int32 OperateID
		{
			get { return _OperateID;}
			set { _OperateID = value;}
		}

		[Description("TableID")]
		[DataMember]
		[Required]
		public Int32 TableID
		{
			get { return _TableID;}
			set { _TableID = value;}
		}

		[Description("DataID")]
		[DataMember]
		public Int32? DataID
		{
			get { return _DataID;}
			set { _DataID = value;}
		}

		[Description("UpdateTime")]
		[DataMember]
		public DateTime? UpdateTime
		{
			get { return _UpdateTime;}
			set { _UpdateTime = value;}
		}

		[Description("ChangeTime")]
		[DataMember]
		public DateTime? ChangeTime
		{
			get { return _ChangeTime;}
			set { _ChangeTime = value;}
		}

		[Description("Status")]
		[DataMember]
		public Int32? Status
		{
			get { return _Status;}
			set { _Status = value;}
		}

		[Description("Explanation")]
		[DataMember]
		public String Explanation
		{
			get { return _Explanation;}
			set { _Explanation = value;}
		}

		#endregion
	}
}
