using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity;
using YXP.API.Entity.Bank;

namespace YXP.API.DataAccess.Bank
{
    public class BankDal : BaseDAL<object>
    {
        public BankDal()
            : base(ConnEnum.TranstarAuctionConfigPath)
        {

        }
    }


}
