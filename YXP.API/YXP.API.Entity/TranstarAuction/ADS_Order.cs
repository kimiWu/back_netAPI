﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace YXP.API.Entity.TranstarAuction
{
    [Serializable]
    [DataContract]
    public partial class ADS_Order
    {
        #region 私有变量
        private Int32 _ID;
        private String _OrderSerial;
        private String _LinkMan;
        private String _MobileNumber;
        private String _Address;
        private Int32? _CheckCount;
        private Int32 _TvaID;
        private String _VendorFullName;
        private DateTime? _CreateTime;
        private DateTime? _UpdateTime;
        private Int32? _OrderStatus;
        private Int32 _AppraiserID;
        private String _Operator;
        private Int32? _OperatorType;
        private String _Remark;
        private DateTime? _DispatchTime;
        private String _LoginName;
        private DateTime? _CompleteTime;
        private DateTime? _CancelTime;
        private String _AppraiseName;
        private String _AppraisePhone;
        private Boolean? _IsTest;
        #endregion

        # region 属性方法
        [Description("订单号")]
        [DataMember]
        [Key]
        [Required]
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        [Description("订单序列号")]
        [DataMember]
        public String OrderSerial
        {
            get { return _OrderSerial; }
            set { _OrderSerial = value; }
        }

        [Description("联系人")]
        [DataMember]
        public String LinkMan
        {
            get { return _LinkMan; }
            set { _LinkMan = value; }
        }

        [Description("电话")]
        [DataMember]
        public String MobileNumber
        {
            get { return _MobileNumber; }
            set { _MobileNumber = value; }
        }

        [Description("地址")]
        [DataMember]
        public String Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        [Description("需测车数量")]
        [DataMember]
        public Int32? CheckCount
        {
            get { return _CheckCount; }
            set { _CheckCount = value; }
        }

        [Description("卖家TvaID")]
        [DataMember]
        [Required]
        public Int32 TvaID
        {
            get { return _TvaID; }
            set { _TvaID = value; }
        }

        [Description("经销商名称")]
        [DataMember]
        public String VendorFullName
        {
            get { return _VendorFullName; }
            set { _VendorFullName = value; }
        }

        [Description("创建时间")]
        [DataMember]
        public DateTime? CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }

        [Description("更新时间")]
        [DataMember]
        public DateTime? UpdateTime
        {
            get { return _UpdateTime; }
            set { _UpdateTime = value; }
        }

        [Description("订单状态，1已创未派、2已分派、3、已完成、4取消")]
        [DataMember]
        public Int32? OrderStatus
        {
            get { return _OrderStatus; }
            set { _OrderStatus = value; }
        }

        [Description("评估师ID")]
        [DataMember]
        [Required]
        public Int32 AppraiserID
        {
            get { return _AppraiserID; }
            set { _AppraiserID = value; }
        }

        [Description("操作人")]
        [DataMember]
        public String Operator
        {
            get { return _Operator; }
            set { _Operator = value; }
        }

        [Description("操作类型，0自助、1(400调度台)")]
        [DataMember]
        public Int32? OperatorType
        {
            get { return _OperatorType; }
            set { _OperatorType = value; }
        }

        [Description("备注")]
        [DataMember]
        public String Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        [Description("分派时间")]
        [DataMember]
        public DateTime? DispatchTime
        {
            get { return _DispatchTime; }
            set { _DispatchTime = value; }
        }

        [Description("登录名")]
        [DataMember]
        public String LoginName
        {
            get { return _LoginName; }
            set { _LoginName = value; }
        }

        [Description("CompleteTime")]
        [DataMember]
        public DateTime? CompleteTime
        {
            get { return _CompleteTime; }
            set { _CompleteTime = value; }
        }

        [Description("CancelTime")]
        [DataMember]
        public DateTime? CancelTime
        {
            get { return _CancelTime; }
            set { _CancelTime = value; }
        }

        [Description("AppraiseName")]
        [DataMember]
        public String AppraiseName
        {
            get { return _AppraiseName; }
            set { _AppraiseName = value; }
        }

        [Description("AppraisePhone")]
        [DataMember]
        public String AppraisePhone
        {
            get { return _AppraisePhone; }
            set { _AppraisePhone = value; }
        }

        [Description("IsTest")]
        [DataMember]
        public Boolean? IsTest
        {
            get { return _IsTest; }
            set { _IsTest = value; }
        }
        #endregion

        public DateTime? ArrivalTime { get; set; }
        public DateTime? DetectionTime { get; set; }
    }
}
