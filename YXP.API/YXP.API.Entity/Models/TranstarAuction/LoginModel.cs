using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YXP.API.Entity.Models.TranstarAuction
{
    public class LoginModel
    {
        public int TvuID { get; set; }
        public string LoginName { get; set; }
        public string LoginPwd { get; set; }
        public string UserFullName { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string AccountType { get; set; }
        public string Address { get; set; }
        public int CityID { get; set; }
        public int TvaID { get; set; }
        public string VendorFullName { get; set; }
        public string SessionId { get; set; }
    }
}
