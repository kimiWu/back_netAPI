using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace YXP.API.Entity.Log
{
	[Serializable]
	[DataContract]
	public partial class CFRole
	{
		#region 私有变量
		private Int32 _RoleId;
		private String _RoleName;
		private String _RoleCode;
		private Int32? _ParentRoleId;
		private String _Notes;
		private Int16? _IsActive;
		private Boolean? _Disabled;
		private DateTime? _CreateTime;
		private Int32? _SysId;
		private Boolean? _Unmodifiable;
		private Boolean? _IsSuperRole;
		private Int32? _RoleType;
		private Byte _FunType;
		#endregion

		# region 属性方法
		[Description("RoleId")]
		[DataMember]
		[Key]
		[Required]
		public Int32 RoleId
		{
			get { return _RoleId;}
			set { _RoleId = value;}
		}

		[Description("RoleName")]
		[DataMember]
		public String RoleName
		{
			get { return _RoleName;}
			set { _RoleName = value;}
		}

		[Description("RoleCode")]
		[DataMember]
		public String RoleCode
		{
			get { return _RoleCode;}
			set { _RoleCode = value;}
		}

		[Description("ParentRoleId")]
		[DataMember]
		public Int32? ParentRoleId
		{
			get { return _ParentRoleId;}
			set { _ParentRoleId = value;}
		}

		[Description("Notes")]
		[DataMember]
		public String Notes
		{
			get { return _Notes;}
			set { _Notes = value;}
		}

		[Description("IsActive")]
		[DataMember]
		public Int16? IsActive
		{
			get { return _IsActive;}
			set { _IsActive = value;}
		}

		[Description("Disabled")]
		[DataMember]
		public Boolean? Disabled
		{
			get { return _Disabled;}
			set { _Disabled = value;}
		}

		[Description("CreateTime")]
		[DataMember]
		public DateTime? CreateTime
		{
			get { return _CreateTime;}
			set { _CreateTime = value;}
		}

		[Description("SysId")]
		[DataMember]
		public Int32? SysId
		{
			get { return _SysId;}
			set { _SysId = value;}
		}

		[Description("Unmodifiable")]
		[DataMember]
		public Boolean? Unmodifiable
		{
			get { return _Unmodifiable;}
			set { _Unmodifiable = value;}
		}

		[Description("IsSuperRole")]
		[DataMember]
		public Boolean? IsSuperRole
		{
			get { return _IsSuperRole;}
			set { _IsSuperRole = value;}
		}

		[Description("RoleType")]
		[DataMember]
		public Int32? RoleType
		{
			get { return _RoleType;}
			set { _RoleType = value;}
		}

		[Description("FunType")]
		[DataMember]
		[Required]
		public Byte FunType
		{
			get { return _FunType;}
			set { _FunType = value;}
		}

		#endregion
	}
}
