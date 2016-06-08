using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.DataAccess;
using YXP.API.DataAccess.TranstarAuction;
using YXP.API.Entity;
using YXP.API.Entity.TranstarAuction;

namespace YXP.API.Business
{
   public class AuctionPublishBLL
    {
       AuctionPublishDAL dal = new AuctionPublishDAL();
       public AuctionPublishInfo Get(int id)
       {
           var entity = dal.Get(id);
           return entity;
       }

       public bool Update(AuctionPublishInfo model)
       {
           var re = dal.Update(model);
           return re;
       }

       public bool Update(dynamic d1, dynamic d2)
       {
           var re = dal.Update(d1,d2);
           return re;
       }
    }
}
