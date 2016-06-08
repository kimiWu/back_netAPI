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
	public partial class tab_sCarDetail
	{
		#region 私有变量
		private Int64 _fld_trimid;
		private String _fld_pfsp;
		private Int16? _fld_cscd;
		private Int16? _fld_cskd;
		private Int16? _fld_csgd;
		private Int16? _fld_qlj;
		private Int16? _fld_hlj;
		private Int16? _fld_qxcd;
		private Int16? _fld_hxcd;
		private Int16? _fld_zj;
		private Int16? _fld_zbzl;
		private Int16? _fld_rxzzl;
		private Byte? _fld_yxrj;
		private Int16? _fld_xlxrj;
		private Int16? _fld_xlxrjzd;
		private Decimal? _fld_fzxs;
		private Byte? _fld_cms;
		private String _fld_zws;
		private Decimal? _fld_jjj;
		private Decimal? _fld_lqj;
		private Decimal? _fld_zxldjj;
		private Decimal? _fld_zxzwzj;
		private Int16? _fld_pql;
		private String _fld_zdgl;
		private String _fld_zdnj;
		private Decimal? _fld_yhzh;
		private Byte? _fld_rllxbh;
		private String _fld_ryggfs;
		private String _fld_fdjxh;
		private String _fld_fdjzyjs;
		private String _fld_fdjms;
		private String _fld_fdjcj;
		private Byte? _fld_gtcl;
		private Byte? _fld_ggcl;
		private Byte? _fld_qgsl;
		private Byte? _fld_lqxt;
		private Byte? _fld_aqqn;
		private Byte? _fld_fdjfzfx;
		private Byte? _fld_fdjwz;
		private Decimal? _fld_gj;
		private Decimal? _fld_xc;
		private Decimal? _fld_sgl;
		private Byte? _fld_jqfs;
		private Byte? _fld_mgqms;
		private Decimal? _fld_ysb;
		private Byte? _fld_bsqxs;
		private String _fld_bsqmc;
		private String _fld_zcpt;
		private Byte? _fld_qdfs;
		private String _fld_qltgg;
		private String _fld_hltgg;
		private Int16? _fld_qdltkg;
		private Byte? _fld_qdltbpb;
		private Int16? _fld_qdltfh;
		private String _fld_qdltsdjb;
		private Byte? _fld_btsl;
		private String _fld_btgg;
		private String _fld_qxj;
		private String _fld_hxj;
		private Byte? _fld_qzd;
		private Byte? _fld_hzd;
		private String _fld_zxxs;
		private Byte? _fld_qlgcl;
		private Byte? _fld_hlgcl;
		private Byte? _fld_btlgcl;
		private Int16? _fld_qdlgzj;
		private Byte? _fld_pdwz;
		private String _fld_zdpbd;
		private Int16? _fld_zgcs;
		private Decimal? _fld_jssj;
		private Decimal? _fld_zdjl;
		private Byte? _fld_ctlx2;
		private String _fld_bxq;
		private Byte _fld_cdxs;
		private Byte _fld_cpxs;
		private Byte _fld_cpkhfs;
		private Int64 _CarDetailID;
		private Int64? _CarTrimID;
		private DateTime? _ChangeTime;
		private Int32? _NotoStatus;
		#endregion

		# region 属性方法
		[Description("fld_trimid")]
		[DataMember]
		[Required]
		public Int64 fld_trimid
		{
			get { return _fld_trimid;}
			set { _fld_trimid = value;}
		}

		[Description("fld_pfsp")]
		[DataMember]
		public String fld_pfsp
		{
			get { return _fld_pfsp;}
			set { _fld_pfsp = value;}
		}

		[Description("fld_cscd")]
		[DataMember]
		public Int16? fld_cscd
		{
			get { return _fld_cscd;}
			set { _fld_cscd = value;}
		}

		[Description("fld_cskd")]
		[DataMember]
		public Int16? fld_cskd
		{
			get { return _fld_cskd;}
			set { _fld_cskd = value;}
		}

		[Description("fld_csgd")]
		[DataMember]
		public Int16? fld_csgd
		{
			get { return _fld_csgd;}
			set { _fld_csgd = value;}
		}

		[Description("fld_qlj")]
		[DataMember]
		public Int16? fld_qlj
		{
			get { return _fld_qlj;}
			set { _fld_qlj = value;}
		}

		[Description("fld_hlj")]
		[DataMember]
		public Int16? fld_hlj
		{
			get { return _fld_hlj;}
			set { _fld_hlj = value;}
		}

		[Description("fld_qxcd")]
		[DataMember]
		public Int16? fld_qxcd
		{
			get { return _fld_qxcd;}
			set { _fld_qxcd = value;}
		}

		[Description("fld_hxcd")]
		[DataMember]
		public Int16? fld_hxcd
		{
			get { return _fld_hxcd;}
			set { _fld_hxcd = value;}
		}

		[Description("fld_zj")]
		[DataMember]
		public Int16? fld_zj
		{
			get { return _fld_zj;}
			set { _fld_zj = value;}
		}

		[Description("fld_zbzl")]
		[DataMember]
		public Int16? fld_zbzl
		{
			get { return _fld_zbzl;}
			set { _fld_zbzl = value;}
		}

		[Description("fld_rxzzl")]
		[DataMember]
		public Int16? fld_rxzzl
		{
			get { return _fld_rxzzl;}
			set { _fld_rxzzl = value;}
		}

		[Description("fld_yxrj")]
		[DataMember]
		public Byte? fld_yxrj
		{
			get { return _fld_yxrj;}
			set { _fld_yxrj = value;}
		}

		[Description("fld_xlxrj")]
		[DataMember]
		public Int16? fld_xlxrj
		{
			get { return _fld_xlxrj;}
			set { _fld_xlxrj = value;}
		}

		[Description("fld_xlxrjzd")]
		[DataMember]
		public Int16? fld_xlxrjzd
		{
			get { return _fld_xlxrjzd;}
			set { _fld_xlxrjzd = value;}
		}

		[Description("fld_fzxs")]
		[DataMember]
		public Decimal? fld_fzxs
		{
			get { return _fld_fzxs;}
			set { _fld_fzxs = value;}
		}

		[Description("fld_cms")]
		[DataMember]
		public Byte? fld_cms
		{
			get { return _fld_cms;}
			set { _fld_cms = value;}
		}

		[Description("fld_zws")]
		[DataMember]
		public String fld_zws
		{
			get { return _fld_zws;}
			set { _fld_zws = value;}
		}

		[Description("fld_jjj")]
		[DataMember]
		public Decimal? fld_jjj
		{
			get { return _fld_jjj;}
			set { _fld_jjj = value;}
		}

		[Description("fld_lqj")]
		[DataMember]
		public Decimal? fld_lqj
		{
			get { return _fld_lqj;}
			set { _fld_lqj = value;}
		}

		[Description("fld_zxldjj")]
		[DataMember]
		public Decimal? fld_zxldjj
		{
			get { return _fld_zxldjj;}
			set { _fld_zxldjj = value;}
		}

		[Description("fld_zxzwzj")]
		[DataMember]
		public Decimal? fld_zxzwzj
		{
			get { return _fld_zxzwzj;}
			set { _fld_zxzwzj = value;}
		}

		[Description("fld_pql")]
		[DataMember]
		public Int16? fld_pql
		{
			get { return _fld_pql;}
			set { _fld_pql = value;}
		}

		[Description("fld_zdgl")]
		[DataMember]
		public String fld_zdgl
		{
			get { return _fld_zdgl;}
			set { _fld_zdgl = value;}
		}

		[Description("fld_zdnj")]
		[DataMember]
		public String fld_zdnj
		{
			get { return _fld_zdnj;}
			set { _fld_zdnj = value;}
		}

		[Description("fld_yhzh")]
		[DataMember]
		public Decimal? fld_yhzh
		{
			get { return _fld_yhzh;}
			set { _fld_yhzh = value;}
		}

		[Description("fld_rllxbh")]
		[DataMember]
		public Byte? fld_rllxbh
		{
			get { return _fld_rllxbh;}
			set { _fld_rllxbh = value;}
		}

		[Description("fld_ryggfs")]
		[DataMember]
		public String fld_ryggfs
		{
			get { return _fld_ryggfs;}
			set { _fld_ryggfs = value;}
		}

		[Description("fld_fdjxh")]
		[DataMember]
		public String fld_fdjxh
		{
			get { return _fld_fdjxh;}
			set { _fld_fdjxh = value;}
		}

		[Description("fld_fdjzyjs")]
		[DataMember]
		public String fld_fdjzyjs
		{
			get { return _fld_fdjzyjs;}
			set { _fld_fdjzyjs = value;}
		}

		[Description("fld_fdjms")]
		[DataMember]
		public String fld_fdjms
		{
			get { return _fld_fdjms;}
			set { _fld_fdjms = value;}
		}

		[Description("fld_fdjcj")]
		[DataMember]
		public String fld_fdjcj
		{
			get { return _fld_fdjcj;}
			set { _fld_fdjcj = value;}
		}

		[Description("fld_gtcl")]
		[DataMember]
		public Byte? fld_gtcl
		{
			get { return _fld_gtcl;}
			set { _fld_gtcl = value;}
		}

		[Description("fld_ggcl")]
		[DataMember]
		public Byte? fld_ggcl
		{
			get { return _fld_ggcl;}
			set { _fld_ggcl = value;}
		}

		[Description("fld_qgsl")]
		[DataMember]
		public Byte? fld_qgsl
		{
			get { return _fld_qgsl;}
			set { _fld_qgsl = value;}
		}

		[Description("fld_lqxt")]
		[DataMember]
		public Byte? fld_lqxt
		{
			get { return _fld_lqxt;}
			set { _fld_lqxt = value;}
		}

		[Description("fld_aqqn")]
		[DataMember]
		public Byte? fld_aqqn
		{
			get { return _fld_aqqn;}
			set { _fld_aqqn = value;}
		}

		[Description("fld_fdjfzfx")]
		[DataMember]
		public Byte? fld_fdjfzfx
		{
			get { return _fld_fdjfzfx;}
			set { _fld_fdjfzfx = value;}
		}

		[Description("fld_fdjwz")]
		[DataMember]
		public Byte? fld_fdjwz
		{
			get { return _fld_fdjwz;}
			set { _fld_fdjwz = value;}
		}

		[Description("fld_gj")]
		[DataMember]
		public Decimal? fld_gj
		{
			get { return _fld_gj;}
			set { _fld_gj = value;}
		}

		[Description("fld_xc")]
		[DataMember]
		public Decimal? fld_xc
		{
			get { return _fld_xc;}
			set { _fld_xc = value;}
		}

		[Description("fld_sgl")]
		[DataMember]
		public Decimal? fld_sgl
		{
			get { return _fld_sgl;}
			set { _fld_sgl = value;}
		}

		[Description("fld_jqfs")]
		[DataMember]
		public Byte? fld_jqfs
		{
			get { return _fld_jqfs;}
			set { _fld_jqfs = value;}
		}

		[Description("fld_mgqms")]
		[DataMember]
		public Byte? fld_mgqms
		{
			get { return _fld_mgqms;}
			set { _fld_mgqms = value;}
		}

		[Description("fld_ysb")]
		[DataMember]
		public Decimal? fld_ysb
		{
			get { return _fld_ysb;}
			set { _fld_ysb = value;}
		}

		[Description("fld_bsqxs")]
		[DataMember]
		public Byte? fld_bsqxs
		{
			get { return _fld_bsqxs;}
			set { _fld_bsqxs = value;}
		}

		[Description("fld_bsqmc")]
		[DataMember]
		public String fld_bsqmc
		{
			get { return _fld_bsqmc;}
			set { _fld_bsqmc = value;}
		}

		[Description("fld_zcpt")]
		[DataMember]
		public String fld_zcpt
		{
			get { return _fld_zcpt;}
			set { _fld_zcpt = value;}
		}

		[Description("fld_qdfs")]
		[DataMember]
		public Byte? fld_qdfs
		{
			get { return _fld_qdfs;}
			set { _fld_qdfs = value;}
		}

		[Description("fld_qltgg")]
		[DataMember]
		public String fld_qltgg
		{
			get { return _fld_qltgg;}
			set { _fld_qltgg = value;}
		}

		[Description("fld_hltgg")]
		[DataMember]
		public String fld_hltgg
		{
			get { return _fld_hltgg;}
			set { _fld_hltgg = value;}
		}

		[Description("fld_qdltkg")]
		[DataMember]
		public Int16? fld_qdltkg
		{
			get { return _fld_qdltkg;}
			set { _fld_qdltkg = value;}
		}

		[Description("fld_qdltbpb")]
		[DataMember]
		public Byte? fld_qdltbpb
		{
			get { return _fld_qdltbpb;}
			set { _fld_qdltbpb = value;}
		}

		[Description("fld_qdltfh")]
		[DataMember]
		public Int16? fld_qdltfh
		{
			get { return _fld_qdltfh;}
			set { _fld_qdltfh = value;}
		}

		[Description("fld_qdltsdjb")]
		[DataMember]
		public String fld_qdltsdjb
		{
			get { return _fld_qdltsdjb;}
			set { _fld_qdltsdjb = value;}
		}

		[Description("fld_btsl")]
		[DataMember]
		public Byte? fld_btsl
		{
			get { return _fld_btsl;}
			set { _fld_btsl = value;}
		}

		[Description("fld_btgg")]
		[DataMember]
		public String fld_btgg
		{
			get { return _fld_btgg;}
			set { _fld_btgg = value;}
		}

		[Description("fld_qxj")]
		[DataMember]
		public String fld_qxj
		{
			get { return _fld_qxj;}
			set { _fld_qxj = value;}
		}

		[Description("fld_hxj")]
		[DataMember]
		public String fld_hxj
		{
			get { return _fld_hxj;}
			set { _fld_hxj = value;}
		}

		[Description("fld_qzd")]
		[DataMember]
		public Byte? fld_qzd
		{
			get { return _fld_qzd;}
			set { _fld_qzd = value;}
		}

		[Description("fld_hzd")]
		[DataMember]
		public Byte? fld_hzd
		{
			get { return _fld_hzd;}
			set { _fld_hzd = value;}
		}

		[Description("fld_zxxs")]
		[DataMember]
		public String fld_zxxs
		{
			get { return _fld_zxxs;}
			set { _fld_zxxs = value;}
		}

		[Description("fld_qlgcl")]
		[DataMember]
		public Byte? fld_qlgcl
		{
			get { return _fld_qlgcl;}
			set { _fld_qlgcl = value;}
		}

		[Description("fld_hlgcl")]
		[DataMember]
		public Byte? fld_hlgcl
		{
			get { return _fld_hlgcl;}
			set { _fld_hlgcl = value;}
		}

		[Description("fld_btlgcl")]
		[DataMember]
		public Byte? fld_btlgcl
		{
			get { return _fld_btlgcl;}
			set { _fld_btlgcl = value;}
		}

		[Description("fld_qdlgzj")]
		[DataMember]
		public Int16? fld_qdlgzj
		{
			get { return _fld_qdlgzj;}
			set { _fld_qdlgzj = value;}
		}

		[Description("fld_pdwz")]
		[DataMember]
		public Byte? fld_pdwz
		{
			get { return _fld_pdwz;}
			set { _fld_pdwz = value;}
		}

		[Description("fld_zdpbd")]
		[DataMember]
		public String fld_zdpbd
		{
			get { return _fld_zdpbd;}
			set { _fld_zdpbd = value;}
		}

		[Description("fld_zgcs")]
		[DataMember]
		public Int16? fld_zgcs
		{
			get { return _fld_zgcs;}
			set { _fld_zgcs = value;}
		}

		[Description("fld_jssj")]
		[DataMember]
		public Decimal? fld_jssj
		{
			get { return _fld_jssj;}
			set { _fld_jssj = value;}
		}

		[Description("fld_zdjl")]
		[DataMember]
		public Decimal? fld_zdjl
		{
			get { return _fld_zdjl;}
			set { _fld_zdjl = value;}
		}

		[Description("fld_ctlx2")]
		[DataMember]
		public Byte? fld_ctlx2
		{
			get { return _fld_ctlx2;}
			set { _fld_ctlx2 = value;}
		}

		[Description("fld_bxq")]
		[DataMember]
		public String fld_bxq
		{
			get { return _fld_bxq;}
			set { _fld_bxq = value;}
		}

		[Description("fld_cdxs")]
		[DataMember]
		[Required]
		public Byte fld_cdxs
		{
			get { return _fld_cdxs;}
			set { _fld_cdxs = value;}
		}

		[Description("fld_cpxs")]
		[DataMember]
		[Required]
		public Byte fld_cpxs
		{
			get { return _fld_cpxs;}
			set { _fld_cpxs = value;}
		}

		[Description("fld_cpkhfs")]
		[DataMember]
		[Required]
		public Byte fld_cpkhfs
		{
			get { return _fld_cpkhfs;}
			set { _fld_cpkhfs = value;}
		}

		[Description("CarDetailID")]
		[DataMember]
		[Key]
		[Required]
		public Int64 CarDetailID
		{
			get { return _CarDetailID;}
			set { _CarDetailID = value;}
		}

		[Description("CarTrimID")]
		[DataMember]
		public Int64? CarTrimID
		{
			get { return _CarTrimID;}
			set { _CarTrimID = value;}
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
