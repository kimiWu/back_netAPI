using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.DataAccess.StandardSale;
using YXP.API.Entity.StandardSale;

namespace YXP.API.Business.StandardSale
{
    public class V_ExchangeNoSubmitInfoList_Infiniti_ToCSBLL
    {
        private V_ExchangeNoSubmitInfoList_Infiniti_ToCSDAL dal = new V_ExchangeNoSubmitInfoList_Infiniti_ToCSDAL();

        public V_ExchangeNoSubmitInfoList_Infiniti_ToCS GetCarsByVIN(string sVIN)
        {
            //return dal.Where(p => p.CarIdentityNumber == sVIN).First();
            return dal.GetCarsByVIN(sVIN);
        }
    }
}
