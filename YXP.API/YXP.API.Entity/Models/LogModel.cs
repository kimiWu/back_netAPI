using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YXP.API.Entity.Models
{
    public class LogModel
    {
        public int PlatformId { get; set; }
        public string Url { get; set; }
        public string Browser { get; set; }
        public int Flag { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ActionTime { get; set; }

        public DateTime RenderTime { get; set; }
    }
}