using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace YXP.PaiMobile.Models
{
    /// <summary>
    /// 提供给3.0大报告 返回车辆所需信息，供页面或接口使用
    /// </summary>
    public class AuctionDetailFor3ReportResponse
    {

        /// <summary>
        /// 拍品ID
        /// </summary>
        public long PublishId { get; set; }
        /// <summary>
        /// 车款等级
        /// </summary>
        public string ConditionGrade { get; set; }
        /// <summary>
        /// 车位号
        /// </summary>
        public string ParkingNumber { get; set; }
        /// <summary>
        /// 名称信息
        /// </summary>
        public string nameInfo { get; set; }
        /// <summary>
        /// 车况摘要
        /// </summary>
        public string[] Summary { get; set; }
        /// <summary>
        /// 默认图片
        /// </summary>
        public CarPicsInfo defaultPic { get; set; }
        /// <summary>
        /// 车辆配置图片
        /// </summary>
        public List<CarPicsInfo> carConfigPicsInfo { get; set; }
        /// <summary>
        /// 车俩手续图片
        /// </summary>
        public List<CarPicsInfo> carProcedurePicsInfo { get; set; }
        /// <summary>
        /// 车况图片
        /// </summary>
        public List<CarPicsInfo> carConditionPicInfo { get; set; }
        /// <summary>
        /// 车辆信息
        /// </summary>
        public AuctionCarDetail Detail { get; set; }

        /// <summary>
        /// 车辆原色  
        /// </summary>
        public string originalColor { get; set; }

        /// <summary>
        /// 维修保养记录
        /// </summary>
        public string maintainRecord { get; set; }
        ///// <summary>
        ///// 车辆原始VIN码
        ///// </summary>
        //public int CarIdentityNumber { get; set; }

        ///// <summary>
        /////  提供判断 1 ==>显示OldCarDate { get; set; }//原始购车发票
        ///// 否则显示：  TransferInvoice {get;set;}//过户票
        ///// </summary>
        //public int IsNewCar { get; set; }

        ///// <summary>
        ///// 1:老数据 2：新数据
        ///// </summary>
        //public int IsNewData { get; set; }

        ///// <summary>
        ///// 是否显示查客数据（控制 SkeletonRepair，BodyRepair 数据显示）
        ///// </summary>
        //public bool IsShowckData { get; set; }
        ///// <summary>
        ///// 骨架修复历史
        ///// </summary>
        ////public List<CarSourceDetect> SkeletonRepair { get; set; }

        ///// <summary>
        ///// 车身修复历史
        ////public List<CarSourceDetect> BodyRepair { get; set; }
        ///// <summary>
        ///// 可见损伤概况
        ///// </summary>
        ////public CarDetectInfo DetectInfo { get; set; }

        /////// <summary>
        /////// 损伤详情列表
        /////// </summary>
        ////[DataMember(Name = "")]
        ////public List<CarDetecDetail> CarDetecList { get; set; }
        ///// <summary>
        ///// 损伤情况缩略图
        ///// </summary>
        //public List<string> DetectFivePic { get; set; }

        ///// <summary>
        ///// 是否显示行车电脑数据
        ///// </summary>
        //public bool IsShowckxcData { get; set; }
        ///// <summary>
        ///// 行车电脑
        ///// </summary>
        //public Dictionary<string, string> DefectGridHtml { get; set; }
        /// <summary>
        /// 是否是大报告数据 0：否 1：是
        /// </summary>
        public int isBigReportData { get; set; }
        /// <summary>
        /// 车源ID
        /// </summary>
        public int CarSourceId { get; set; }
    }
    public class AuctionDetailFor3ReportResponseExt : AuctionDetailFor3ReportResponse
    {
        /// <summary>
        /// 维修保养记录
        /// </summary>
        public CarMaintenanceRecordRep carMaintenanceRecord { get; set; }
    }

    /// <summary>
    /// 车辆图片信息
    /// </summary>
    public class CarPicsInfo
    {
        private string fileName;
        private int fileType;
        private string picDes;
        private int isEmptyPic;
        /// <summary>
        /// 图片路径
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        /// <summary>
        /// 图片类型 , 当图片为瑕疵类型时， 0代表一般损伤，1代表重要损伤 ,2代表合成瑕疵图("外观"和"漆面隐形损伤" ) 
        /// </summary>
        public int FileType
        {
            get { return fileType; }
            set { fileType = value; }
        }
        /// <summary>
        /// 图片描述 例如 左前45度-有瑕疵,有瑕疵,有瑕疵
        /// </summary>
        public string PicDes
        {
            get { return picDes; }
            set { picDes = value; }
        }
        /// <summary>
        /// 是否有图 0：无图 ----  1：有图
        /// </summary>
        public int IsEmptyPic
        {
            set { isEmptyPic = value; }
            get { return isEmptyPic; }
        }
        /// <summary>
        /// 瑕疵点坐标  格式：x1,y1|x2,y2|x3,y3
        /// </summary>
        public string Point { get; set; }
        /// <summary>
        /// 描述的标签位置  L,R,L" --解释：L左 R右
        /// </summary>
        public string tag { get; set; }
        /// <summary>
        /// 瑕疵类型 0：轻微；1：严重 0,1,0
        /// </summary>
        public string color { get; set; }
    }

    public class ConfigKeyList
    {
        public int type { get; set; }
        public string key { get; set; }
    }

    public class CarMaintenanceRecord
    {
        public string result_status { get; set; }
        public string result_description { get; set; }
        public int notify_id { get; set; }
        public string result_images { get; set; }
        public int result_imagesCount { get; set; }
        public List<ResultContentRecordSub> result_content { get; set; }
        public List<string> result_report { get; set; }
    }
    public class ResultContentRecordSub
    {
        public string date { get; set; }
        public List<string> images { get; set; }
        public string kilometers { get; set; }
        public string type { get; set; }
        public string content { get; set; }
        public string status { get; set; }
    }
    public class CarMaintenanceRecordRep
    {
        public string result_status { get; set; }
        public string result_description { get; set; }
        public int notify_id { get; set; }
        public int result_imagesCount { get; set; }
        public List<string> result_images { get; set; }
        public List<ResultContentRecordSub> result_content { get; set; }
        public List<string> result_report { get; set; }
    }
    /// <summary>
    /// 车辆基本信息
    /// </summary>
    public class AuctionCarDetail
    {
        #region  车辆登记信息
        /// <summary>
        /// 车源ID
        /// </summary>
        public int CarSourceId { get; set; }
        /// <summary>
        /// 车辆信息
        /// </summary>
        public string CarName { get; set; }
        /// <summary>
        /// 表显里程
        /// </summary>
        public string Mileage { get; set; }
        /// <summary>
        /// 车辆库存地
        /// </summary>
        public string CarCity { get; set; }
        /// <summary>
        /// 出厂日期
        /// </summary>
        public string RegistDate { get; set; }
        /// <summary>
        /// 注册日期
        /// </summary>
        public string LicenseDate { get; set; }
        /// <summary>
        /// 使用性质
        /// </summary>
        public string CarUseType { get; set; }
        /// <summary>
        /// 车辆所有人性质
        /// </summary>
        public string CarOwner { get; set; }
        /// <summary>
        /// 新车质保
        /// </summary>
        public string NewCarWarranty { get; set; }
        /// <summary>
        /// 年审有效期
        /// </summary>
        public string AnnualDetectionDate { get; set; }
        /// <summary>
        /// 商业险
        /// </summary>
        public string ComInsurance { get; set; }
        /// <summary>
        /// 交强险到期日
        /// </summary>
        public string FoInsuranceDate { get; set; }
        /// <summary>
        /// 是否一手车
        /// </summary>
        public string IsFirstHand { get; set; }
        /// <summary>
        /// 保养手册记录
        /// </summary>
        public string MaintainRecord { get; set; }
        /// <summary>
        /// 车船税到期日
        /// </summary>
        public string CarShipTaxExpireDate { get; set; }
        /// <summary>
        /// 车辆标准配置
        /// </summary>
        public string CarConfigInfo { get; set; }
        /// <summary>
        /// 车主个性化配置
        /// </summary>
        public string PersonalityInfo { get; set; }
        /// <summary>
        /// 燃油类型
        /// </summary>
        public string FuelType { get; set; }
        /// <summary>
        /// 发动机号
        /// </summary>
        public string EngineNum { get; set; }
        /// <summary>
        /// 车辆VIN码
        /// </summary>
        public string CarIdentityNumber { get; set; }
        /// <summary>
        /// 车牌号码
        /// </summary>
        public string LicenseNumber { get; set; }
        /// <summary>
        /// 车辆原色
        /// </summary>
        public string CarOriginalColor { get; set; }
        /// <summary>
        /// 车辆是否改装 -- 改装说明
        /// </summary>
        public string EfitContent { get; set; }
        /// <summary>
        /// 车牌状态
        /// </summary>
        public string IsHaveCard { get; set; }
        /// <summary>
        /// 环保标准
        /// </summary>
        public string EffluentYellow { get; set; }

        /// <summary>
        /// 微型 = 1,
        /// 小型 = 2,
        /// 中型 = 3,
        /// 大型 = 4
        /// </summary>
        public int Vehicletype { get; set; }
        /// <summary>
        /// 保险是否和车辆所有人一致  [-1未填写1是2否]
        /// </summary>
        public int? SelfInsurance { get; set; }

        /// <summary>
        /// 年检有效期
        /// </summary>
        public DateTime? AnnualValidity { get; set; }
        #endregion

        #region 车辆手续信息
        /// <summary>
        /// 登记证
        /// </summary>
        public string Register { get; set; }
        /// <summary>
        /// 行驶本
        /// </summary>
        public string DrivingCertification { get; set; }
        /// <summary>
        /// 过户票
        /// </summary>
        public string TransferInvoice { get; set; }
        /// <summary>
        /// 原始购车发票
        /// </summary>
        public string OldCarDate { get; set; }
        /// <summary>
        /// 购置税
        /// </summary>
        public string PurchaseTax { get; set; }
        /// <summary>
        /// 说明书
        /// </summary>
        public string ExplainBook { get; set; }
        /// <summary>
        /// 补办手续费用
        /// </summary>
        public string FormalitiesSide { get; set; }
        /// <summary>
        /// 车钥匙
        /// </summary>
        public string CarKeys { get; set; }
        /// <summary>
        /// 补充说明
        /// </summary>
        public string AdditionDesc { get; set; }
        #endregion

        #region 工况及附件说明
        /// <summary>
        /// 起动机检查
        /// </summary>
        public string Starter { get; set; }
        /// <summary>
        /// 车身灯具
        /// </summary>
        public string BodyLamps { get; set; }
        /// <summary>
        /// 发动机检查
        /// </summary>
        public string Engine { get; set; }
        /// <summary>
        /// 工具
        /// </summary>
        public string ToolStatus { get; set; }
        /// <summary>
        /// 变速箱检查
        /// </summary>
        public string Transmission { get; set; }
        /// <summary>
        /// 变速器
        /// </summary>
        public string TransmissionType { get; set; }
        /// <summary>
        /// 备胎
        /// </summary>
        public string SpareTireState { get; set; }
        /// <summary>
        /// 避震器
        /// </summary>
        public string ShockAbsorbers { get; set; }
        /// <summary>
        /// 门手
        /// </summary>
        public string Tode { get; set; }
        /// <summary>
        /// 底盘/行驶
        /// </summary>
        public string Chassis { get; set; }
        /// <summary>
        /// 车钥匙
        /// </summary>
        public string CKeys { get; set; }
        /// <summary>
        /// 制动器
        /// </summary>
        public string Brake { get; set; }
        /// <summary>
        /// 附件补充说明
        /// </summary>
        public string AttachmentRemark { get; set; }
        /// <summary>
        /// 排气系统
        /// </summary>
        public string ExhaustSystem { get; set; }
        /// <summary>
        /// 电器系统 -- 内控电器
        /// </summary>
        public string ElectricalSystem { get; set; }
        /// <summary>
        /// 工况补充说明
        /// </summary>
        public string ConditionsRemark { get; set; }
        /// <summary>
        /// 转向助力异常说明
        /// </summary>
        public string SteeringAssistRemark { get; set; }
        /// <summary>
        /// 机油检查说明
        /// </summary>
        public string EngineOilRemark { get; set; }
        /// <summary>
        /// 防冻液检查说明
        /// </summary>
        public string AntifreezeRemark { get; set; }
        /// <summary>
        /// 当前状况说明
        /// </summary>
        public string PresentStatus { get; set; }
        /// <summary>
        /// 修复整备说明
        /// </summary>
        public string RepairStatus { get; set; }
        /// <summary>
        /// 助力油检查 [1 油液正常 2 严重亏液]
        /// </summary>
        public string PowerOil { get; set; }
        /// <summary>
        /// 刹车油检查 [1 油液正常 2严重亏液]
        /// </summary>
        public string BrakeOil { get; set; }
        /// <summary>
        /// 是否路试[1 是 0否]
        /// </summary>
        public string RoadTest { get; set; }
        /// <summary>
        /// 漆面修复历史说明
        /// </summary>
        public string PaintRepair { get; set; }
        /// <summary>
        /// 违章说明
        /// </summary>
        public string obeyRuleDes { get; set; }
        /// <summary>
        /// 是否是水泡车  0否  1是
        /// </summary>
        public string isWaterCar { get; set; }
        /// <summary>
        /// 滴漏检查说明
        /// </summary>
        public string LeakCheckRemark { get; set; }
        /// <summary>
        /// 排烟检查说明
        /// </summary>
        public string SmokeCheckRemark { get; set; }
        /// <summary>
        /// 运转检查说明
        /// </summary>
        public string WorkCheckRemark { get; set; }
        /// <summary>
        /// 异响检查说明
        /// </summary>
        public string AbnormalSoundRemark { get; set; }
        /// <summary>
        /// 抖动检查说明
        /// </summary>
        public string ZuoGongCheckRemark { get; set; }
        /// <summary>
        /// 冷却检查说明
        /// </summary>
        public string CoolingCheckRemark { get; set; }
        /// <summary>
        /// 交强险是否和车辆所有人一致 [-1未填写1是2否]
        /// </summary>
        public int JqSelfInsurance { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        public int MasterBrandId { get; set; }
        /// <summary>
        /// 车型
        /// </summary>
        public int BrandId { get; set; }
        /// <summary>
        /// 车系
        /// </summary>
        public int CarTypeId { get; set; }
        /// <summary>
        /// 车辆大品牌名称
        /// </summary>
        public string MasterBrandName { get; set; }
        /// <summary>
        /// 车型名称
        /// </summary>
        public string BrandName { get; set; }
        /// <summary>
        /// 车系名称
        /// </summary>
        public string CarTypeName { get; set; }
        /// <summary>
        /// 电池检查说明
        /// </summary>
        public string BatteryCheckRemark { get; set; }
        /// <summary>
        /// 皮带检查说明
        /// </summary>
        public string BeltCheckRemark { get; set; }
        /// <summary>
        /// 维修保养记录JSON
        /// </summary>
        public string maintainRecord { get; set; }
        #endregion
    }
}