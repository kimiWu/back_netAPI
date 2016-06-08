using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity;
using YXP.API.DataAccess.TranstarAuction;
using YXP.API.Entity.TranstarAuction;
namespace YXP.API.Business
{
    public sealed class AuctionApolloOrderBLL
    {
        AuctionApolloOrderDAL dal = new AuctionApolloOrderDAL();
        public bool SetApolloOrderISDispose(int pid, int cid,out string msg)
        {
            bool bResult = false;
            msg = string.Empty;
            AuctionApolloOrder model = dal.GetApolloOrder(pid, cid);
            if (model != null && model.ID > 0)
            {
                model.ISDispose = 1;
                try
                {
                    bResult = dal.UpdateApolloOrder(model);
                }
                catch (Exception ex)
                {
                    msg = string.Format("更新出现异常，{0}", ex);
                }
            }
            else
            {
                msg = "根据拍品ID和车源ID未能查询到相关订单信息";
            }
            return bResult;
        }
    }
}
