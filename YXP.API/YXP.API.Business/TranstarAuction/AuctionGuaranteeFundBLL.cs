using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.DataAccess.TranstarAuction;
using YXP.API.Entity;
using YXP.API.Entity.TranstarAuction;

namespace YXP.API.Business.TranstarAuction
{
    public class AuctionGuaranteeFundBLL
    {
      

        public AuctionGuaranteeFund GetFundByTvaId(int id)
        {
            AuctionGuaranteeFundDAL dal = new AuctionGuaranteeFundDAL();
            string sql = @"SELECT  TvaId
                      ,CurrBalance
                      ,CurrActiveBalance
                      ,CurrFreeze
                      ,TotalBalance
                      ,TotalPunish
                      ,TotalDraw
                      ,TotalBalanceOnline
                      ,TotalBalanceOffline
                      ,TotalBalanceVirtual
                      ,BelongType
                      ,TotalGet
                      ,CurrCreditBalance
                      ,FreezeCreditBalance
                      ,CreditLimit
                      ,CreditLimitFreeze
                      FROM AuctionGuaranteeFund";

            sql += " where TvaId=" + id;
            return dal.Query<AuctionGuaranteeFund>(sql).FirstOrDefault();
        }
    }
}
