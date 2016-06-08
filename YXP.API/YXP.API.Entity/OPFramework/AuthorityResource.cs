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
	public partial class AuthorityResource
	{
		#region 私有变量
		private Int32 _AuthorResourceId;
		private String _ResourceName = "";
		private String _ResourceCode = "";
		private Int16? _ResourceType;
		private Int32? _ParentResourceId;
		private String _ResourcePath = "";
		private Int16? _IsActive;
		private DateTime? _CreateTime;
		private String _Description = "";
		private String _ResourceUrl = "";
		private Int32? _OrderIdx;
		private Int32? _SysId;
		#endregion

		# region 属性方法
		[Description("AuthorResourceId")]
		[DataMember]
		[Key]
		[Required]
		public Int32 AuthorResourceId
		{
			get { return _AuthorResourceId;}
			set { _AuthorResourceId = value;}
		}

		[Description("ResourceName")]
		[DataMember]
		public String ResourceName
		{
			get { return _ResourceName;}
			set { _ResourceName = value;}
		}

		[Description("ResourceCode")]
		[DataMember]
		public String ResourceCode
		{
			get { return _ResourceCode;}
			set { _ResourceCode = value;}
		}

		[Description("ResourceType")]
		[DataMember]
		public Int16? ResourceType
		{
			get { return _ResourceType;}
			set { _ResourceType = value;}
		}

		[Description("ParentResourceId")]
		[DataMember]
		public Int32? ParentResourceId
		{
			get { return _ParentResourceId;}
			set { _ParentResourceId = value;}
		}

		[Description("ResourcePath")]
		[DataMember]
		public String ResourcePath
		{
			get { return _ResourcePath;}
			set { _ResourcePath = value;}
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

		[Description("Description")]
		[DataMember]
		public String Description
		{
			get { return _Description;}
			set { _Description = value;}
		}

		[Description("ResourceUrl")]
		[DataMember]
		public String ResourceUrl
		{
			get { return _ResourceUrl;}
			set { _ResourceUrl = value;}
		}

		[Description("OrderIdx")]
		[DataMember]
		public Int32? OrderIdx
		{
			get { return _OrderIdx;}
			set { _OrderIdx = value;}
		}

		[Description("SysId")]
		[DataMember]
		public Int32? SysId
		{
			get { return _SysId;}
			set { _SysId = value;}
		}

		#endregion
	}
}
