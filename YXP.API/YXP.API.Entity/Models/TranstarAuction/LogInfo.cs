using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace YXP.API.Entity.Models.TranstarAuction
{
    [Serializable]
    [DataContract]
    public class LogInfo
    {
        #region 私有变量
        private Int32 _ID;
        private String _UserName;
        private Int32 _OrderID;
        private Int32? _OperatorType;
        private string _CreateTime;
        private String _Remark;
        #endregion

        # region 属性方法
        [Description("编号")]
        [DataMember]
        [Key]
        [Required]
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        [Description("登录名")]
        [DataMember]
        [Required]
        public String UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        [Description("订单号")]
        [DataMember]
        [Required]
        public Int32 OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }

        [Description("操作类型，1创建、2分派、3修改、4取消")]
        [DataMember]
        public Int32? OperatorType
        {
            get { return _OperatorType; }
            set { _OperatorType = value; }
        }

        [Description("更新时间")]
        [DataMember]
        public string CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }

        [Description("")]
        [DataMember]
        public String Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        #endregion
        //[Description("预计到达时间")]
        //[DataMember]
        //public string DispatchTime { get; set; }


    }
}
