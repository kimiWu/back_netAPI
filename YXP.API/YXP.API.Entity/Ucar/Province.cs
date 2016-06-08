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
	public partial class Province
	{
		#region 私有变量
		private Int32 _pvc_Id;
		private String _pvc_Name;
		private String _pvc_Desc;
		private String _allspell;
		private Int32? _pvc_sort;
		private Int32? _BigAreaId;
		#endregion

		# region 属性方法
		[Description("pvc_Id")]
		[DataMember]
		[Key]
		[Required]
		public Int32 pvc_Id
		{
			get { return _pvc_Id;}
			set { _pvc_Id = value;}
		}

		[Description("pvc_Name")]
		[DataMember]
		public String pvc_Name
		{
			get { return _pvc_Name;}
			set { _pvc_Name = value;}
		}

		[Description("pvc_Desc")]
		[DataMember]
		public String pvc_Desc
		{
			get { return _pvc_Desc;}
			set { _pvc_Desc = value;}
		}

		[Description("allspell")]
		[DataMember]
		public String allspell
		{
			get { return _allspell;}
			set { _allspell = value;}
		}

		[Description("pvc_sort")]
		[DataMember]
		public Int32? pvc_sort
		{
			get { return _pvc_sort;}
			set { _pvc_sort = value;}
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
