using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace YXP.PaiMobile.Models
{ 
    /// <summary>
    /// 调用登录接口响应参数
    /// </summary>
    [DataContract]
    public class LoginResponse :BaseResponse
    {
        private DateTime serverDate = new DateTime(0x7b2, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// 系统时间
        /// </summary>
        [DataMember(Name = "ticks")]
        public DateTime ServerDate
        {
            get { return serverDate; }
            set { serverDate = value; }
        }
        private int vendorId;

        /// <summary>
        /// 经销商ID
        /// </summary>
        [DataMember(Name = "vendorId")]
        public int VendorId
        {
            get { return vendorId; }
            set { vendorId = value; }
        }
        private string vendorName;

        /// <summary>
        /// 经销商名称
        /// </summary>
        [DataMember(Name = "vendorName")]
        public string VendorName
        {
            get { return vendorName; }
            set { vendorName = value; }
        }
        private string facePic;
        /// <summary>
        /// 头像
        /// </summary>
        [DataMember(Name = "facePic")]
        public string FacePic
        {
            get { return facePic; }
            set { facePic = value; }
        }
        private int userId;

        /// <summary>
        /// 用户ID
        /// </summary>
        [DataMember(Name = "userId")]
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private string userName;

        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember(Name = "userName")]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private int cityId;

        /// <summary>
        /// 经销商所在城市ID
        /// </summary>
        [DataMember(Name = "cityId")]
        public int CityId
        {
            get { return cityId; }
            set { cityId = value; }
        }
        private string cityName;

        /// <summary>
        /// 经销商所在城市名称
        /// </summary>
        [DataMember(Name = "cityName")]
        public string CityName
        {
            get { return cityName; }
            set { cityName = value; }
        }

        private decimal fund;

        /// <summary>
        /// 用户可用保证金
        /// </summary>
        [DataMember(Name = "fund")]
        public decimal Fund
        {
            get { return fund; }
            set { fund = value; }
        }
        private int bigAreaId;

        /// <summary>
        /// 用户所在大区ID
        /// </summary>
        [DataMember(Name = "bigAreaId")]
        public int BigAreaId
        {
            get { return bigAreaId; }
            set { bigAreaId = value; }
        }

        //private string company;

        ///// <summary>
        ///// 所属公司
        ///// </summary>
        //[DataMember]
        //public string Company
        //{
        //    get { return company; }
        //    set { company = value; }
        //}
        private string companyType;

        /// <summary>
        /// 公司身份
        /// </summary>
        [DataMember(Name = "companyType")]
        public string CompanyType
        {
            get { return companyType; }
            set { companyType = value; }
        }
        /// <summary>
        /// 保证金类型
        /// </summary>
        [DataMember(Name = "belongType")]
        public string BelongType { get; set; }

        private string sessionId;

        /// <summary>
        /// 公司身份
        /// </summary>
        [DataMember(Name = "sessionId")]
        public string SessionId
        {
            get { return sessionId; }
            set { sessionId = value; }
        }
        private string userKey;

        /// <summary>
        /// 公司身份
        /// </summary>
        [DataMember(Name = "userKey")]
        public string UserKey
        {
            get { return userKey; }
            set { userKey = value; }
        }
        private string userPhone;

        /// <summary>
        /// 用户联系电话
        /// </summary>
        [DataMember(Name = "userPhone")]
        public string UserPhone
        {
            get { return userPhone; }
            set { userPhone = value; }
        }
        private string userAddress;

        /// <summary>
        /// 用户地址
        /// </summary>
        [DataMember(Name = "userAddress")]
        public string UserAddress
        {
            get { return userAddress; }
            set { userAddress = value; }
        }
        private string levelName;

        /// <summary>
        /// 用户等级
        /// </summary>
        [DataMember(Name = "levelName")]
        public string LevelName
        {
            get { return levelName; }
            set { levelName = value; }
        }
        private int currCredits;

        /// <summary>
        /// 用户积分
        /// </summary>
        [DataMember(Name = "currCredits")]
        public int CurrCredits
        {
            get { return currCredits; }
            set { currCredits = value; }
        }
        private int currUCoins;

        /// <summary>
        /// 用户U币
        /// </summary>
        [DataMember(Name = "currUCoins")]
        public int CurrUCoins
        {
            get { return currUCoins; }
            set { currUCoins = value; }
        }
    }
}