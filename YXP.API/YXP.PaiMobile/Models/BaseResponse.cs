using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace YXP.PaiMobile.Models
{
    /// <summary>
    /// 响应参数的基类
    /// </summary>
    [DataContract]
    public class BaseResponse
    {
        private int result;
        /// <summary>
        /// 执行结果是否成功
        /// </summary>
        [DataMember(Name = "result")]
        public int Result
        {
            get { return result; }
            set { result = value; }
        }

        private string message;
        /// <summary>
        /// 描述信息
        /// </summary>
        [DataMember(Name = "data")]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }
}