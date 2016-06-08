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
	public partial class Department
	{
		#region 私有变量
		private Int32 _DeptId;
		private String _DeptCode = "";
		private Int32? _ParentDeptId;
		private String _DeptName = "";
		private Int32? _ManagerUserId;
		private Int32? _DeptType;
		private Int16? _IsActive;
		private DateTime? _CreateTime;
		#endregion

		# region 属性方法
		[Description("DeptId")]
		[DataMember]
		[Key]
		[Required]
		public Int32 DeptId
		{
			get { return _DeptId;}
			set { _DeptId = value;}
		}

		[Description("DeptCode")]
		[DataMember]
		public String DeptCode
		{
			get { return _DeptCode;}
			set { _DeptCode = value;}
		}

		[Description("ParentDeptId")]
		[DataMember]
		public Int32? ParentDeptId
		{
			get { return _ParentDeptId;}
			set { _ParentDeptId = value;}
		}

		[Description("DeptName")]
		[DataMember]
		public String DeptName
		{
			get { return _DeptName;}
			set { _DeptName = value;}
		}

		[Description("ManagerUserId")]
		[DataMember]
		public Int32? ManagerUserId
		{
			get { return _ManagerUserId;}
			set { _ManagerUserId = value;}
		}

		[Description("DeptType")]
		[DataMember]
		public Int32? DeptType
		{
			get { return _DeptType;}
			set { _DeptType = value;}
		}

		[Description("IsActive")]
		[DataMember]
		public Int16? IsActive
		{
			get { return _IsActive;}
			set { _IsActive = value;}
		}

		[Description("CreateTime")]
		[DataMember]
		public DateTime? CreateTime
		{
			get { return _CreateTime;}
			set { _CreateTime = value;}
		}

		#endregion
	}
}
