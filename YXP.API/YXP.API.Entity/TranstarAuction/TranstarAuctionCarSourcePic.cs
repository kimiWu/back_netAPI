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
	public partial class TranstarAuctionCarSourcePic
	{
		#region 私有变量
		private Int64 _CarSourcePicID;
		private Int32 _CarSourceID;
		private String _PicPath = "";
		private Int32 _PicType;
		private Int32 _OrderIndex;
		private String _PicTitle = "";
		private String _PicDesc = "";
		#endregion

		# region 属性方法
		[Description("")]
		[DataMember]
		[Key]
		[Required]
		public Int64 CarSourcePicID
		{
			get { return _CarSourcePicID;}
			set { _CarSourcePicID = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 CarSourceID
		{
			get { return _CarSourceID;}
			set { _CarSourceID = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String PicPath
		{
			get { return _PicPath;}
			set { _PicPath = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 PicType
		{
			get { return _PicType;}
			set { _PicType = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 OrderIndex
		{
			get { return _OrderIndex;}
			set { _OrderIndex = value;}
		}

		[Description("")]
		[DataMember]
		public String PicTitle
		{
			get { return _PicTitle;}
			set { _PicTitle = value;}
		}

		[Description("")]
		[DataMember]
		public String PicDesc
		{
			get { return _PicDesc;}
			set { _PicDesc = value;}
		}

		#endregion
	}
}
