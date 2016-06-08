using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.StandardSale;

namespace YXP.API.DataAccess.StandardSale
{
    public class V_ExchangeNoSubmitInfoList_Infiniti_ToCSDAL : BaseDAL<V_ExchangeNoSubmitInfoList_Infiniti_ToCS>
    {
        public V_ExchangeNoSubmitInfoList_Infiniti_ToCSDAL()
            : base("StandardSale")
        { 
        
        }

        public V_ExchangeNoSubmitInfoList_Infiniti_ToCS GetCarsByVIN(string sVIN)
        {
            string strSql = string.Format("select * from V_ExchangeNoSubmitInfoList_Infiniti_ToCS where CarIdentityNumber='{0}'", sVIN);
            var re = Query<V_ExchangeNoSubmitInfoList_Infiniti_ToCS>(strSql);
            return re.FirstOrDefault();
        }
    }
}
