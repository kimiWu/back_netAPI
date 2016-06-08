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
    public class ReadCarSourceLog
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CarSourceID { get; set; }
        [DataMember]
        public int TvaID { get; set; }
        [DataMember]
        public DateTime CreateTime { get; set; }
        [DataMember]
        public int Type { get; set; }  
    }
}
