using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YXP.API.Entity.TranstarAuction
{
    /// <summary>
    /// 列表接收参数
    /// </summary>
    [Serializable]
    public sealed class VendorServiceReceiveParam
    {
        /// <summary>
        /// 经销商ID
        /// </summary>
        public int TvuId { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 移动电话
        /// </summary>
        public string MobielPhone { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 真实名称
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 身份号码
        /// </summary>
        public string IdentityNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BusinessManager { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 用户真实名称
        /// </summary>
        public string UserFullName { get; set; }
        /// <summary>
        /// 移动电话
        /// </summary>
        public string MobilePhoneNumber { get; set; }
        /// <summary>
        /// 开户银行
        /// </summary>
        public string KHYH { get; set; }
        /// <summary>
        /// 开户人户名
        /// </summary>
        public string KHHM { get; set; }
        /// <summary>
        /// 开户账号
        /// </summary>
        public string KHZH { get; set; }
        /// <summary>
        /// 开户行代码
        /// </summary>
        public string BranchBankId { get; set; }
        /// <summary>
        /// 会员卡密码
        /// </summary>
        public string CardPwd { get; set; }
        /// <summary>
        /// 经销商类别
        /// 个人用户 = 1, 4S店用户 = 2,专业公司= 3,厂商= 4,其他= 5,租赁公司= 6,汽贸集团= 7,代理商= 8
        /// </summary>
        public int VendorClass { get; set; }
        /// <summary>
        /// 经销商全名
        /// </summary>
        public string VendorFullName { get; set; }
        /// <summary>
        /// 可用车位数量
        /// </summary>
        public int CWSL { get; set; }
        /// <summary>
        /// 月均采购量
        /// </summary>
        public int YJCGL { get; set; }
        /// <summary>
        /// 月均出售量
        /// </summary>
        public int YJCSL { get; set; }
        /// <summary>
        /// 人员规模
        /// </summary>
        public int RYGM { get; set; }
        /// <summary>
        /// 公司经营场地
        /// </summary>
        public string GSJYCD { get; set; }
        /// <summary>
        /// 是否收购事故车
        /// 0：否；1：是
        /// </summary>
        public int SGSGC { get; set; }
        /// <summary>
        /// 二手车业务经营
        /// 0:收购 1：销售
        /// </summary>
        public int ESCJYYW { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string CarPic { get; set; }
        /// <summary>
        /// 身份证照片
        /// </summary>
        public string IdentityPic { get; set; }

        public string Dbrqzurl { get; set; }

        public string Wtrqzurl { get; set; }

        public string DBR { get; set; }

        public string DBRMobilePhone { get; set; }
        /// <summary>
        /// 城市所属ID
        /// </summary>
        public int CityId { get; set; }
    }

    public class TranstarVendorUserAccount
    {

        #region 公司信息
        /// <summary>
        /// 公司名称
        /// </summary>
        public string VendorFullName
        {
            set;
            get;
        }

        /// <summary>
        /// 公司编号
        /// </summary>
        public string VendorCode
        {
            set;
            get;
        }

        /// <summary>
        /// 公司简称
        /// </summary>
        public string VendorShortName
        {
            set;
            get;
        }

        /// <summary>
        /// 所属城市id
        /// </summary>
        public int CityID
        {
            set;
            get;
        }




        /// <summary>
        /// 公司地址
        /// </summary>
        public string Address
        {
            set;
            get;
        }



        /// <summary>
        /// 公司类型 
        /// 个人用户 = 1, 4S店用户 = 2,专业公司= 3,厂商= 4,其他= 5,租赁公司= 6,汽贸集团= 7,代理商= 8
        /// </summary>
        public int VendorClass
        {
            set;
            get;
        }




        /// <summary>
        /// 资产类型：0：个人独资 1：多人合资
        /// </summary>
        public int ZCLX
        {
            set;
            get;
        }

        /// <summary>
        /// 是否有经营场地： 0：无 1：有
        /// </summary>
        public int JYCD
        {
            set;
            get;
        }

        /// <summary>
        /// 车辆停放场地
        /// </summary>
        public string CLTFCD
        {
            set;
            get;
        }

        /// <summary>
        /// 经营车辆价格范围：0:5万以下1:5万—10万2:10万—20万3:20万以上
        /// </summary>
        public string JYCLJGFW
        {
            set;
            get;
        }

        /// <summary>
        /// 感兴趣车辆品牌0=国产|1=德系|2=法系|3=美系|4=日系|5=韩系
        /// </summary>
        public string GXQCLPP
        {
            set;
            get;
        }

        /// <summary>
        /// 车辆出售方式：0：零售 1：批发
        /// </summary>
        public string CLCSFS
        {
            set;
            get;
        }

        /// <summary>
        /// 是否有贷款需求  0：否 1：有
        /// </summary>
        public int SFDK
        {
            set;
            get;
        }

        /// <summary>
        /// 开户银行
        /// </summary>
        public string KHYH
        {
            set;
            get;
        }

        /// <summary>
        /// 开户人户名
        /// </summary>
        public string KHHM
        {
            set;
            get;
        }

        /// <summary>
        /// 开户账号
        /// </summary>
        public string KHZH
        {
            set;
            get;
        }

        /// <summary>
        /// 开户人电话
        /// </summary>
        public string KHDH
        {
            set;
            get;
        }
        /// <summary>
        /// 可用车位数量
        /// </summary>
        public int CWSL
        {
            get;
            set;
        }

        /// <summary>
        /// 月均采购量
        /// </summary>
        public int YJCGL
        {
            get;
            set;
        }

        /// <summary>
        /// 月均出售量
        /// </summary>
        public int YJCSL
        {
            get;
            set;
        }

        /// <summary>
        /// 人员规模
        /// </summary>
        public int RYGM
        {
            get;
            set;
        }

        /// <summary>
        /// 二手车业务经营 0=收购 1=销售
        /// </summary>
        public int ESCJYYW
        {
            get;
            set;
        }
        /// <summary>
        /// 是否是现场拍经销商  0：不是 1：是 默认：0
        /// 经销商来源 0、admin 1、现场拍 2、php调用ManualBargain中CreateShortBuyer使用 3、手机注册超级入门级 4、crm系统  5、网站（没用） 6、优信二手车  
        /// </summary>
        public int IsLiveAuction { set; get; }
        /// <summary>
        /// 1：买家 2：卖家
        /// </summary>
        public int AccountType { set; get; }
        /// <summary>
        /// 是否收购事故车 0:否 1：是
        /// </summary>
        public int SGSGC { set; get; }
        /// <summary>
        /// 公司经营场地
        /// </summary>
        public string GSJYCD { set; get; }
        /// <summary>
        /// 现有车辆储量
        /// </summary>
        public int XYCLCL { set; get; }
        /// <summary>
        /// 性别：0：男 1：女
        /// </summary>
        public int Sex { set; get; }
        /// <summary>
        /// 代办人
        /// </summary>
        public string DBR { set; get; }
        /// <summary>
        /// 代办人身份证号
        /// </summary>
        public string DBRIdentityNum { set; get; }
        /// <summary>
        /// 代办人手机
        /// </summary>
        public string DBRMobilePhone { set; get; }
        public string Image1 { set; get; }
        public string Image2 { set; get; }
        public string BusinessManager { set; get; }
        #endregion



        #region  账户信息

        /// <summary>
        /// 会员id
        /// </summary>
        public int TvuID
        {
            set;
            get;
        }



        /// <summary>
        /// 经销商id
        /// </summary>
        public int TvaID
        {
            set;
            get;
        }



        /// <summary>
        /// 优信拍登陆名
        /// </summary>
        public string LoginName
        {
            set;
            get;
        }

        /// <summary>
        /// 优信拍登陆密码
        /// </summary>
        public string LoginPwd
        {
            set;
            get;
        }

        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string UserFullName
        {
            set;
            get;
        }

        /// <summary>
        /// 电话
        /// </summary>
        public string TelephoneNumber
        {
            set;
            get;
        }

        /// <summary>
        /// 手机
        /// </summary>
        public string MobilePhoneNumber
        {
            set;
            get;
        }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email
        {
            set;
            get;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime
        {
            set;
            get;
        }



        /// <summary>
        /// 会员状态 1：启用 0：禁用
        /// </summary>
        public int Status
        {
            set;
            get;
        }



        /// <summary>
        /// 身份号
        /// </summary>
        public string IdentityNum
        {
            set;
            get;
        }

        /// <summary>
        /// qq号
        /// </summary>
        public string QQ
        {
            set;
            get;
        }

        /// <summary>
        /// 会员卡卡号
        /// </summary>
        public string CardID
        {
            set;
            get;
        }

        /// <summary>
        /// 会员卡密码
        /// </summary>
        public string CardPwd
        {
            set;
            get;
        }

        /// <summary>
        /// 身份证照片
        /// </summary>
        public string IdentityPic
        {
            set;
            get;
        }

        /// <summary>
        /// 头像
        /// </summary>
        public string CarPic
        {
            set;
            get;
        }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? Birthday
        {
            set;
            get;
        }
        /// <summary>
        /// 头像
        /// </summary>
        public string FacePic
        {
            set;
            get;
        }

        /// <summary>
        /// 创建时间
        /// added by lvming 
        /// 为移动端添加 去掉时分秒
        /// </summary>
        public string MobileCreateTime
        {
            set;
            get;
        }
        #endregion



        /// <summary>
        /// 业务人员
        /// </summary>
        public string BusinessPersonal { get; set; }

        #region 会员卡信息
        /// <summary>
        /// 卡片办理人
        /// </summary>
        public int OperatorID { get; set; }
        /// <summary>
        /// 分公司
        /// </summary>
        public int company_id { get; set; }
        #endregion


        /// <summary>
        /// 经销商主体类型
        /// </summary>
        public int VendorClassCategory { get; set; }


        /// <summary>
        /// 期望购车城市
        /// </summary>
        public int SupposeCityId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int UrID { get; set; }

        /// <summary>
        /// 支行代码
        /// </summary>
        public string BranchBankId { get; set; }
    }

    /// <summary>
    /// CRM经销商&&用户处理服务的类
    /// </summary>
    public class TranstarVendorModel
    {

        #region 公共属性

        ///<summary>
        ///
        ///</summary> 
        public int TvuID
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int SiID
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int TvaID
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int UrID
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string LoginName
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string LoginPwd
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string UserFullName
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string TelephoneNumber
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string MobilePhoneNumber
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string Email
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string CreateTime
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string LastModifyTime
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int Status
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int Level
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int oldTvuid
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int LoginCount
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string LastLoginTime
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int LinkManID
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string LastPwdModifyTime
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int OfficialStatus
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int IsCompanyLinkMan
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int VendorType
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string IdentityNum
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string QQ
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string CardID
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string CardPwd
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string IdentityPic
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string CarPic
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string Birthday
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string CardCode
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int supposeCity
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string refereeCode
        {
            get;
            set;
        }

        /// <summary>
        ///  调用方 admin = 1,  youxinpai = 2, proxy = 3,apollo = 4 ,手机注册买家 = 5, 现场拍 = 6 , crm = 7
        /// </summary>

        public int ClientType
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string VendorFullName
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string VendorCode
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string VendorShortName
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int CityID
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string TaxAccount
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public bool IsTaxAccountVisible
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string BankAccount
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public bool IsBankAccountVisible
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string LinkMan
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string FaxNumber
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string Address
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string PostCode
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string VendorIntroduction
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string TrafficDescription
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string Image1
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string Image2
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string Image3
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string MapImage
        {
            get;
            set;
        }


        ///<summary>
        ///
        ///</summary>

        public int VendorLevel
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string EMapImage
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int oldTvaid
        {
            get;
            set;
        }





        ///<summary>
        ///
        ///</summary>

        public int RecommendVendorID
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int VendorClass
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int SuperiorID
        {
            get;
            set;
        }


        ///<summary>
        ///
        ///</summary>

        public string StarLevel
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public decimal QuarterPoint
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string ServiceTel
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public byte HasIdentity
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public byte HasBusinessLicense
        {
            get;
            set;
        }

        ///<summary>
        /// 1:买家，2:卖家
        ///</summary> 
        public int AccountType
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int ChargeType
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string FreeBeginDate
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string FreeEndDate
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int IsOnlinePayEnable
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string FirstChargeTime
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string CustomVersionNo
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string SmallArea
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string BigArea
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int IsVirtualBuyer
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int ManageType
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int SuperGroupID
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int UseAccountType
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int AgentID
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int CircletType
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string LockTime
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int LockDaysType
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int AgentType
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int ZCLX
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int JYCD
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string CLTFCD
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string JYCLJGFW
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string GXQCLPP
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string CLCSFS
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int SFDK
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string KHYH
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string KHHM
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string KHZH
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string KHDH
        {
            get;
            set;
        }

        public string BranchBankId
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int CWSL
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int YJCGL
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int YJCSL
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int RYGM
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int ESCJYYW
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int IsLiveAuction
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int SGSGC
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string GSJYCD
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int XYCLCL
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public int Sex
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string DBR
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string DBRIdentityNum
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string DBRMobilePhone
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string BusinessManager
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string BusinessPersonal
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string BusinessLicence
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string IdentityCard
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string BusinessLicencePic
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string IdentityCardPic
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string LimitGetVoucherTime
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string IdCard_Front
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string IdCard_Back
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string IdCard_Hand
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string Org_Code
        {
            get;
            set;
        }

        ///<summary>
        ///
        ///</summary>

        public string Tax_Reg_Certificate
        {
            get;
            set;
        }

        ///
        ///</summary>

        public int company_id
        {
            get;
            set;
        }
        #endregion




        #region 电子签添加

        /// <summary>
        /// 税务登记证照
        /// </summary>

        public string Tax_Reg_CertificatePic
        {
            get;
            set;
        }

        /// <summary>
        /// 组织机构代码证照
        /// </summary>

        public string Org_CodePic { get; set; }


        /// <summary>
        /// 授权委托书照
        /// </summary>

        public string PowerOfaAttorneyPic { get; set; }


        /// <summary>
        /// 电子签错误汇总（json串）
        /// </summary>

        public string ElectronicSignError { get; set; }


        /// <summary>
        /// 电子签过程中涉及到的状态  0 ：未签证  1：审核中 2：被拒  3：审核通过 4：签证成功  
        /// </summary>

        public int ElectronicSignStatus { get; set; }


        /// <summary>
        /// 类别分级（个人、厂商、自有、上级公司）
        /// </summary>

        public int VendorClassCategory { get; set; }


        /// <summary>
        /// 购车意向城市
        /// </summary>

        public int SupposeCityId { get; set; }


        /// <summary>
        /// 合同地址 
        /// </summary> 
        public string BargainAddress { get; set; }


        /// <summary>
        /// 审核完成时间 
        public DateTime? SignAuditExpectationDate { get; set; }


        #endregion


    }

}
