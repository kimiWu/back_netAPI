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
	public partial class tab_ComparetionCarID
	{
		#region 私有变量
		private Int32? _BitAuto_CarID;
		private Int32? _IAuto_CarID;
		#endregion

		# region 属性方法
		[Description("BitAuto_CarID")]
		[DataMember]
		public Int32? BitAuto_CarID
		{
			get { return _BitAuto_CarID;}
			set { _BitAuto_CarID = value;}
		}

		[Description("IAuto_CarID")]
		[DataMember]
		public Int32? IAuto_CarID
		{
			get { return _IAuto_CarID;}
			set { _IAuto_CarID = value;}
		}

		#endregion
	}
}
