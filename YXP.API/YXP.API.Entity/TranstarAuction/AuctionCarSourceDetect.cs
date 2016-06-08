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
	public partial class AuctionCarSourceDetect
	{
		#region 私有变量
		private Int32 _CarSourceDetectID;
		private String _DetectItemID = "";
		private String _DetectDefectID = "";
		private String _DefectDegreeValue = "";
		private String _DefectDefreeDesc = "";
		private String _RepairTypeID = "";
		private String _DetectMark = "";
		private String _DefectPic = "";
		private String _SessionID = "";
		private Int32 _CarSourceID;
		private String _DetectItemMapID = "";
		private Int32 _DetectAreaType;
		private Int32? _DetectLevel;
		private String _Original = "";
		private String _Point = "";
		#endregion

		# region 属性方法
		[Description("")]
		[DataMember]
		[Key]
		[Required]
		public Int32 CarSourceDetectID
		{
			get { return _CarSourceDetectID;}
			set { _CarSourceDetectID = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String DetectItemID
		{
			get { return _DetectItemID;}
			set { _DetectItemID = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String DetectDefectID
		{
			get { return _DetectDefectID;}
			set { _DetectDefectID = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String DefectDegreeValue
		{
			get { return _DefectDegreeValue;}
			set { _DefectDegreeValue = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String DefectDefreeDesc
		{
			get { return _DefectDefreeDesc;}
			set { _DefectDefreeDesc = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String RepairTypeID
		{
			get { return _RepairTypeID;}
			set { _RepairTypeID = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String DetectMark
		{
			get { return _DetectMark;}
			set { _DetectMark = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String DefectPic
		{
			get { return _DefectPic;}
			set { _DefectPic = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public String SessionID
		{
			get { return _SessionID;}
			set { _SessionID = value;}
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
		public String DetectItemMapID
		{
			get { return _DetectItemMapID;}
			set { _DetectItemMapID = value;}
		}

		[Description("")]
		[DataMember]
		[Required]
		public Int32 DetectAreaType
		{
			get { return _DetectAreaType;}
			set { _DetectAreaType = value;}
		}

		[Description("")]
		[DataMember]
		public Int32? DetectLevel
		{
			get { return _DetectLevel;}
			set { _DetectLevel = value;}
		}

		[Description("Original")]
		[DataMember]
		public String Original
		{
			get { return _Original;}
			set { _Original = value;}
		}

		[Description("Point")]
		[DataMember]
		public String Point
		{
			get { return _Point;}
			set { _Point = value;}
		}

		#endregion
	}
}
