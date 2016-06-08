using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace YXP.PaiMobile.Models
{
    [DataContract]
    [Serializable]
    public class AuctionListSearchEntity
    {
        /// <summary>
        /// 通道id 0为全国所有通道
        /// </summary>
        [DataMember(Name = "channelID")]
        public int ChannelID { get; set; }

        /// <summary>
        /// 搜索类型 0:全部 1：关注  
        /// </summary>
        [DataMember(Name = "attentionSearch")]
        public int AttentionSearch { get; set; }

        /// <summary>
        /// 搜索类型 0:非伙伴 1：伙伴  
        /// </summary>
        [DataMember(Name = "partnerSearch")]
        public int PartnerSearch { get; set; }

        public List<int> _CitySearch = new List<int>();

        /// <summary>
        /// 城市列表 
        /// </summary>
        [DataMember(Name = "citySearch")]
        public List<int> CitySearch { get { return _CitySearch; } set { _CitySearch = value; } }


        public List<long> _BrandSearch = new List<long>();

        /// <summary>
        /// 车型 车型id(主品牌id)
        /// </summary>
        [DataMember(Name = "brandSearch")]
        public List<long> BrandSearch { get { return _BrandSearch; } set { _BrandSearch = value; } }


        public List<long> _SerialSearch = new List<long>();

        /// <summary>
        /// 车系id
        /// </summary>
        [DataMember(Name = "serialSearch")]
        public List<long> SerialSearch { get { return _SerialSearch; } set { _SerialSearch = value; } }


        public List<int> _YearSearch = new List<int>();
        /// <summary>
        /// 年限 2年以内：1    2-6年  2   6-10年  3   10年以上 4
        /// </summary>
        [DataMember(Name = "yearSearch")]
        public List<int> YearSearch { get { return _YearSearch; } set { _YearSearch = value; } }

        public List<int> _MoneySearch = new List<int>();
        /// <summary>
        /// 价格 小于3万：1     3-5万 ：2       5-10万：3     10-20万 4  20以上 5
        /// </summary>
        [DataMember(Name = "moneySearch")]
        public List<int> MoneySearch { get { return _MoneySearch; } set { _MoneySearch = value; } }

        public List<string> _ConditionSearch = new List<string>();

        /// <summary>
        /// 需看车:有评级
        /// </summary>
        [DataMember(Name = "conditionSearch")]
        public List<string> ConditionSearch { get { return _ConditionSearch; } set { _ConditionSearch = value; } }

        public List<string> _GradeSearch = new List<string>();
        /// <summary>
        /// A:B:C:D
        /// </summary>
        [DataMember(Name = "gradeSearch")]
        public List<string> GradeSearch { get { return _GradeSearch; } set { _GradeSearch = value; } }
        /// <summary>
        /// 排序 1:竞价开始时间 2:价格最低 3:价格最高 4:车龄最短 5:车龄最长 6:车况最好 7:车况最差 8:优惠最大 9:优惠最小 10:最近竞价 11:最晚竞价 12:最感兴趣
        /// </summary>
        [DataMember(Name = "orderNum")]
        public List<int> OrderNum { get; set; }

        public int _CurrentPage = 0;
        /// <summary>
        /// 当前页 1:第一页
        /// </summary>
        [DataMember(Name = "currentPage")]
        public int CurrentPage { get { return _CurrentPage; } set { _CurrentPage = value; } }


        public int _PageSize = 20;
        /// <summary>
        /// 每页记录条数 默认 20条 按通道时返回所有搜索数据，不受分页影响
        /// </summary>
        [DataMember(Name = "pageSize")]
        public int PageSize { get { return _PageSize; } set { _PageSize = value; } }


        /// <summary>
        /// 最后一条数据拍品id，每页返回时会带上最后一个id，把它做参数传过来，首次为0
        /// </summary>
        [DataMember(Name = "lastPublishID")]
        public long LastPublishID { get; set; }
        /// <summary>
        /// 当前拍品id
        /// </summary>
        [DataMember(Name = "currentPublishID")]
        public long CurrentPublishID { get; set; }

        public List<int> _OnLineSearch = new List<int>();
        /// <summary>
        /// 全部 0，在线 1  现场  2    快拍 3
        /// </summary>
        [DataMember(Name = "onLineSearch")]
        public List<int> OnLineSearch { get { return _OnLineSearch; } set { _OnLineSearch = value; } }

        /// <summary>
        /// 是否是调试 0:正式 1:调试,缺省值为0
        /// </summary>
        [DataMember(Name = "IsDebug")]
        public int IsDebug { get; set; }

        public List<int> _StandardSearch = new List<int>();
        /// <summary>
        /// 全部 0，国2及以下：1  国3：2  国4：3  国5：4
        /// </summary>
        [DataMember(Name = "standardSearch")]
        public List<int> StandardSearch { get { return _StandardSearch; } set { _StandardSearch = value; } }
        /// <summary>
        /// 是否心愿搜索 0:非 1:心愿搜索
        /// </summary>
        [DataMember(Name = "IsWish")]
        public int IsWish { get; set; }

        /// <summary>
        /// 待排序标识 0排序 1待排序
        /// </summary>
        [DataMember(Name = "isWait")]
        public int IsWait { get; set; }

        public List<string> _LicenseSearch = new List<string>();
        /// <summary>
        /// 车牌搜素（京A，京B）(京全部回传京牌)
        /// </summary>
        [DataMember(Name = "licenseSearch")]
        public List<string> LicenseSearch { get { return _LicenseSearch; } set { _LicenseSearch = value; } }
    }
}