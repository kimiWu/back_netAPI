using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace YXP.API.Entity.OPFramework
{
	[Serializable]
	[DataContract]
	public partial class AreaUserRoleMap
	{
		#region 私有变量
		private Int32 _ID;
		private Int32 _TvaID;
		private Int32 _UserId;
		private Int32 _IsActive;
		private DateTime _CreatTime;
		#endregion

		# region 属性方法
		[Description("ID")]
		[DataMember]
		[Key]
		[Required]
		public Int32 ID
		{
			get { return _ID;}
			set { _ID = value;}
		}

		[Description("TvaID")]
		[DataMember]
		[Required]
		public Int32 TvaID
		{
			get { return _TvaID;}
			set { _TvaID = value;}
		}

		[Description("UserId")]
		[DataMember]
		[Required]
		public Int32 UserId
		{
			get { return _UserId;}
			set { _UserId = value;}
		}

		[Description("IsActive")]
		[DataMember]
		[Required]
		public Int32 IsActive
		{
			get { return _IsActive;}
			set { _IsActive = value;}
		}

		[Description("CreatTime")]
		[DataMember]
		[Required]
		public DateTime CreatTime
		{
			get { return _CreatTime;}
			set { _CreatTime = value;}
		}

		#endregion
	}
}
