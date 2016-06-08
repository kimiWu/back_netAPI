using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YXP.API.Business.StandardSale;
using YXP.API.Entity.StandardSale;

namespace YXP.API.Controllers.StandardSale
{
    public class ReplacementUsedCarsController : ApiController
    {
        private V_ExchangeNoSubmitInfoList_Infiniti_ToCSBLL vensilbll = new V_ExchangeNoSubmitInfoList_Infiniti_ToCSBLL();
        private ReadCarSourceLogBLL rcslbll = new ReadCarSourceLogBLL();
        /// <summary>
        /// 根据VIN获取置换车辆信息
        /// shj 2016-04-27
        /// </summary>
        [HttpGet]
        [ApiActionFilter]
        public CarSourceEntity GetCarsByVIN(string sVIN)
        {
            CarSourceEntity carSource = new CarSourceEntity();
            try
            {
                if (!string.IsNullOrWhiteSpace(sVIN))
                {
                    //组织数据
                    var info = vensilbll.GetCarsByVIN(sVIN);
                    if (info != null)
                    {
                        carSource.DealerCode = info.VendorCode;//经销商代码
                        carSource.DelaerName = info.VendorShortName;//经销商名称3
                        carSource.Source = info.ProductType;//资料来源
                        carSource.CustomerName = info.CustomerName;//置换客户/公司名称
                        carSource.Address = info.Address;//置换客户地址
                        carSource.PostCard = info.PostCard;//置换客户身份证号/组织机构代码证号
                        carSource.Telephone = info.Telephone;//客户手机
                        carSource.UsedCardBrand = info.BrandName;//置换二手车品牌 
                        carSource.UsedCardModel = info.ModelName;//置换二手车车型 
                        carSource.UsedCarVin = info.CarIdentityNumber;//置换二手车车架号
                        carSource.UsedCarLicense = info.LicenseNumber;//置换二手车车牌号
                        carSource.UsedCarLicenseDate = info.GetLicenseDate;//置换二手车上牌时间
                        carSource.UsedCarMileage = info.Mileage;//置换二手车里程数(公里)
                        carSource.UsedCarEvaluationPrice = info.ReservationPrice;//置换二手车经销商评估价格(元)
                        carSource.UsedCarPurchasePrice = info.PurchasePrice;//置换二手车实际收购价(元)
                        carSource.UsedCarCompletionDate = info.SellerCompleteTime;//置换二手车车辆成交日期
                        carSource.PurchaserName = info.PurchaserName;//二手车商/二手车购买者/公司名称
                        carSource.PurchaserPhone = info.PurchaserPhone;//二手车商/二手车购买者电话
                        //carSource.CarSourceId = info.CarSourceId;//
                        //carSource.TvaId = info.TvaId;//
                        //保存读取记录
                        ReadCarSourceLog rcsl = new ReadCarSourceLog();
                        rcsl.CarSourceID = info.CarSourceId;
                        rcsl.TvaID = info.TvaId;
                        rcsl.CreateTime = DateTime.Now;
                        rcsl.Type = 1;
                        rcslbll.SaveReadCarSourceLog(rcsl);
                        return carSource;
                    }
                }
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}