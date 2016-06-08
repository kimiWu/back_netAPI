using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace YXP.API.Entity.TranstarAuction
{
	[Serializable]
	[DataContract]
	public partial class Province
	{
		#region 私有变量
		private Int32 _ProvinceId;
		private String _ProvinceName = "";
		private String _ProvinceDesc = "";
		private String _AllSpell = "";
		private Int32? _Sort;
		private Int32? _BigAreaId;
		#endregion

		# region 属性方法
		[Description("ProvinceId")]
		[DataMember]
		[Key]
		[Required]
		public Int32 ProvinceId
		{
			get { return _ProvinceId;}
			set { _ProvinceId = value;}
		}

		[Description("ProvinceName")]
		[DataMember]
		public String ProvinceName
		{
			get { return _ProvinceName;}
			set { _ProvinceName = value;}
		}

		[Description("ProvinceDesc")]
		[DataMember]
		public String ProvinceDesc
		{
			get { return _ProvinceDesc;}
			set { _ProvinceDesc = value;}
		}

		[Description("AllSpell")]
		[DataMember]
		public String AllSpell
		{
			get { return _AllSpell;}
			set { _AllSpell = value;}
		}

		[Description("Sort")]
		[DataMember]
		public Int32? Sort
		{
			get { return _Sort;}
			set { _Sort = value;}
		}

		[Description("BigAreaId")]
		[DataMember]
		public Int32? BigAreaId
		{
			get { return _BigAreaId;}
			set { _BigAreaId = value;}
		}

		#endregion
	}
}
