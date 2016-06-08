using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace YXP.PaiMobile.Models
{
    /// <summary>
    /// 平台
    /// </summary>
    [Serializable]
    public enum Platform
    {
        SamsungPad = 6
    }

    /// <summary>
    /// 登录请求
    /// </summary>
    [DataContract]
    public class LoginRequest
    {
       
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
        private string password;

        /// <summary>
        /// 密码 Des加密
        /// </summary>
        [DataMember(Name = "password")]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string platform;

        /// <summary>
        /// 平台号
        /// </summary>
        [DataMember(Name = "platform")]
        public string Platform
        {
            get { return platform; }
            set { platform = value; }
        }

        private string machineCode;

        /// <summary>
        /// 机器码
        /// </summary>
        [DataMember(Name = "machineCode")]
        public string MachineCode
        {
            get { return machineCode; }
            set { machineCode = value; }
        }

        private string networkingMode;

        /// <summary>
        /// 网络制式
        /// </summary>
        [DataMember(Name = "networkingMode")]
        public string NetworkingMode
        {
            get { return networkingMode; }
            set { networkingMode = value; }
        }

        private string version;

        /// <summary>
        /// 版本
        /// </summary>
        [DataMember(Name = "version")]
        public string Version
        {
            get { return version; }
            set { version = value; }
        }

        private string randomNum;

        /// <summary>
        /// 随机数
        /// </summary>
        [DataMember(Name = "randomNum")]
        public string RandomNum
        {
            get { return randomNum; }
            set { randomNum = value; }
        }

        private string deviceType;

        /// <summary>
        /// 设备类型
        /// </summary>
        [DataMember(Name = "deviceType")]
        public string DeviceType
        {
            get { return deviceType; }
            set { deviceType = value; }
        }
        private string deviceModel;

        /// <summary>
        /// 设备型号
        /// </summary>
        [DataMember(Name = "deviceModel")]
        public string DeviceModel
        {
            get { return deviceModel; }
            set { deviceModel = value; }
        }
        private string systemVersionName;

        /// <summary>
        /// 系统版本名称
        /// </summary>
        [DataMember(Name = "systemVersionName")]
        public string SystemVersionName
        {
            get { return systemVersionName; }
            set { systemVersionName = value; }
        }

        //private bool isNeed;

        ///// <summary>
        ///// 是否迫切需要城市列表
        ///// 如果是true，不管城市列表有没有改变都返回，
        ///// 如果是false，仅当城市列表有改变时才返回
        ///// </summary>
        //[DataMember]
        //public bool IsNeed
        //{
        //    get { return isNeed; }
        //    set { isNeed = value; }
        //}

        //private int cityVersion;

        ///// <summary>
        ///// 客户端最新的城市列表版本,如果客户端不是最新的，返回最新的城市列表和版本
        ///// </summary>
        //[DataMember]
        //public int CityVersion
        //{
        //    get { return cityVersion; }
        //    set { cityVersion = value; }
        //}

        private int mobileType;

        /// <summary>
        /// 登录来源（1表示android用户、2表示ios用户）
        /// </summary>
        [DataMember(Name = "mobileType")]
        public int MobileType
        {
            get { return mobileType; }
            set { mobileType = value; }
        }

        /// <summary>
        /// 系统版本号
        /// </summary>
        //[DataMember(Name = "version")]
        //public string Version
        //{
        //    get;
        //    set;
        //}
        /// <summary>
        /// SIM卡信息
        /// </summary>
        [DataMember(Name = "sIMCardInfo")]
        public string SIMCardInfo
        {
            get;
            set;
        }
        /// <summary>
        /// 手机状态
        /// </summary>
        [DataMember(Name = "phoneStatus")]
        public string PhoneStatus
        {
            get;
            set;
        }
        /// <summary>
        /// 屏宽
        /// </summary>
        [DataMember(Name = "windowWH")]
        public string WindowWH
        {
            get;
            set;
        }
    }
}
