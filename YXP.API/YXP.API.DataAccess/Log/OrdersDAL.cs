using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity;
using YXP.API.Entity.Log;

namespace YXP.API.DataAccess.Log
{

    public class OrdersDAL : BaseDAL<Orders>
    {

        public OrdersDAL()
            : base(ConnEnum.ApiLogConfigPath)
        {
            
        }

        public bool Save()
        {
            var db = GetDB(1);
            try
            {
                Urls m1 = new Urls() { Id = 10, Name = "360", Url = "http://www.so.com" };
                Orders m2 = new Orders() { Id = 22, Name = "demo", Price = 1000, Serial = "d2001" };

                db.BeginTransaction();//可以设置读不锁

                db.Insert<Urls>(m1);
                db.Insert<Orders>(m2);

                db.Commit();
                return true;
            }
            catch (Exception ex)
            {
                //一定要加回滚，要不然死锁
                db.Rollback();
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
    }

}
