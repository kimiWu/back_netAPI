using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace YXP.API.Entity.StandardSale
{
    [Serializable]
    [DataContract]
    public class CarSourceEntity
    {
        [Description("经销商代码")]
        [DataMember]
        public string DealerCode { get; set; }
        [Description("经销商名称")]
        [DataMember]
        public string DelaerName { get; set; }
        [Description("资料来源")]
        [DataMember]
        public string Source { get; set; }
        [Description("置换客户/公司名称")]
        [DataMember]
        public string CustomerName { get; set; }
        [Description("置换客户地址")]
        [DataMember]
        public string Address { get; set; }
        [Description("置换客户身份证号/组织机构代码证号")]
        [DataMember]
        public string PostCard { get; set; }
        [Description("客户手机")]
        [DataMember]
        public string Telephone { get; set; }
        [Description("置换二手车品牌")]
        [DataMember]
        public string UsedCardBrand { get; set; }
        [Description("置换二手车车型")]
        [DataMember]
        public string UsedCardModel { get; set; }
        [Description("置换二手车车架号")]
        [DataMember]
        public string UsedCarVin { get; set; }
        [Description("置换二手车车牌号")]
        [DataMember]
        public string UsedCarLicense { get; set; }
        [Description("置换二手车上牌时间")]
        [DataMember]
        public DateTime UsedCarLicenseDate { get; set; }
        [Description("置换二手车里程数(公里)")]
        [DataMember]
        public decimal UsedCarMileage { get; set; }
        [Description("置换二手车经销商评估价格(元)")]
        [DataMember]
        public decimal UsedCarEvaluationPrice { get; set; }
        [Description("置换二手车实际收购价(元)")]
        [DataMember]
        public decimal UsedCarPurchasePrice { get; set; }
        [Description("置换二手车车辆成交日期")]
        [DataMember]
        public DateTime UsedCarCompletionDate { get; set; }
        [Description("二手车商/二手车购买者/公司名称")]
        [DataMember]
        public string PurchaserName { get; set; }
        [Description("二手车商/二手车购买者电话")]
        [DataMember]
        public string PurchaserPhone { get; set; }
        //[Description("CarSourceId")]
        //[DataMember]
        //public int CarSourceId { get; set; }
        //[Description("TvaId")]
        //[DataMember]
        //public int TvaId { get; set; }
    }
}
