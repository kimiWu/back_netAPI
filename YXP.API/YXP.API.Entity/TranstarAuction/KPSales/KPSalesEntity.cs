using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.Common;

namespace YXP.API.Entity.KPSales
{
  
    public class KPSalesListEntity
    {
        public int carSourceId { get; set; }   //车源id

        public int tvaId { get; set; }  //经销商id

        public int cityId { get; set; } //城市id

        public string cityName { get; set; } //城市名称

        public string vendorFullName { get; set; }  //经销商名字

        public string leftFront45 { get; set; }  //车源图片

        public int publishId { get; set; }  //拍品id

        public string brandname { get; set; }

        public string seriesName { get; set; }  //车型

        public string modelName { get; set; }  //车系

        public string licenseNumber { get; set; }  //车牌

        public string stopTime { get; set; }  //结束时间

        public string createTime { get; set; } //发拍时间

        public decimal modifyPrice { get; set; } //定价中心出价

        public decimal SWFee { get; set; }  //sw费用

        public decimal currSalesPrice { get; set; }  //销售出价

        public int UserId { get; set; }  //销售ID

        public string priceStopTime { get; set; }  //流派时间

        public string draftTime { get; set; }  //成交时间

        public string publishSerial { get; set; }  //拍品号

        public decimal SellerFee { get; set; } //卖家成交价   卖家收到的金额

        public int BidderTvaId { get; set; } //阿波罗ID

        public string EngineNum { get; set; } //发动机号

        public decimal InvestFee { get; set; } //已获得投资资金

    }
}
