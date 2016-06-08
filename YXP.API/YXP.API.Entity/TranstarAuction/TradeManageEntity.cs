using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YXP.API.Entity.TranstarAuction
{
    public class TradeManageEntity
    {
        public int totalPage { get; set; }

        public int totalCount { get; set; }

        public List<VCarTradeList> children { get; set; }
    }

    public class VCarTradeList
    {
        public int publishId { get; set; }

        public int carSourceId { get; set; }  //车辆编号

        public string draftTime { get; set; }  //成交时间

        public string cityName { get; set; } //地区
        [JsonIgnore]
        public string masterBrandName { get; set; } //车品牌
        [JsonIgnore]
        public string brandName { get; set; }  //车型
        [JsonIgnore]
        public string carTypeName { get; set; }  //车系

        public string carName { get; set; }  //车辆名字

        public string conditionGrade { get; set; } //车辆等级

        public string carBodyColor { get; set; }  //颜色

        public decimal dealPrice { get; set; }  //成交价

        public string licenseDate { get; set; }  //首次上牌时间

        public string mileage { get; set; }  //表显里程（万公里）

        public string transmission { get; set; } //变速类型

        public string carUseType { get; set; }  //适用类型

    }
}
