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
	public partial class tab_sConfigItems
	{
		#region 私有变量
		private Int64 _fld_Itemid;
		private Int16 _fld_Index;
		private Int16 _fld_Priority;
		private String _fld_Name;
		private Int64 _fld_Classid;
		private Int16 _fld_Iautosid;
		private Int64 _fld_Configid;
		private Int64 _ConfigItemsID;
		private Int64? _ConfigIautosID;
		private Int64? _ConfigModelID;
		private DateTime? _ChangeTime;
		private Int32? _NotoStatus;
		#endregion

		# region 属性方法
		[Description("fld_Itemid")]
		[DataMember]
		[Required]
		public Int64 fld_Itemid
		{
			get { return _fld_Itemid;}
			set { _fld_Itemid = value;}
		}

		[Description("fld_Index")]
		[DataMember]
		[Required]
		public Int16 fld_Index
		{
			get { return _fld_Index;}
			set { _fld_Index = value;}
		}

		[Description("fld_Priority")]
		[DataMember]
		[Required]
		public Int16 fld_Priority
		{
			get { return _fld_Priority;}
			set { _fld_Priority = value;}
		}

		[Description("fld_Name")]
		[DataMember]
		[Required]
		public String fld_Name
		{
			get { return _fld_Name;}
			set { _fld_Name = value;}
		}

		[Description("fld_Classid")]
		[DataMember]
		[Required]
		public Int64 fld_Classid
		{
			get { return _fld_Classid;}
			set { _fld_Classid = value;}
		}

		[Description("fld_Iautosid")]
		[DataMember]
		[Required]
		public Int16 fld_Iautosid
		{
			get { return _fld_Iautosid;}
			set { _fld_Iautosid = value;}
		}

		[Description("fld_Configid")]
		[DataMember]
		[Required]
		public Int64 fld_Configid
		{
			get { return _fld_Configid;}
			set { _fld_Configid = value;}
		}

		[Description("ConfigItemsID")]
		[DataMember]
		[Key]
		[Required]
		public Int64 ConfigItemsID
		{
			get { return _ConfigItemsID;}
			set { _ConfigItemsID = value;}
		}

		[Description("ConfigIautosID")]
		[DataMember]
		public Int64? ConfigIautosID
		{
			get { return _ConfigIautosID;}
			set { _ConfigIautosID = value;}
		}

		[Description("ConfigModelID")]
		[DataMember]
		public Int64? ConfigModelID
		{
			get { return _ConfigModelID;}
			set { _ConfigModelID = value;}
		}

		[Description("ChangeTime")]
		[DataMember]
		public DateTime? ChangeTime
		{
			get { return _ChangeTime;}
			set { _ChangeTime = value;}
		}

		[Description("NotoStatus")]
		[DataMember]
		public Int32? NotoStatus
		{
			get { return _NotoStatus;}
			set { _NotoStatus = value;}
		}

		#endregion
	}
}
