using Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.DataAccess;
using YXP.API.DataAccess.Log;
using YXP.API.Entity.Log;



namespace YXP.API.Business.Log
{
    public class OrdersBLL
    {
        OrdersDAL dal = new OrdersDAL();
        public OrdersBLL()
        {
            //
            //var list = dal.GetAll(predicate, new List<ISort>() { new Sort { PropertyName = "Name", Ascending = false } }, 0, 5);
        }

        public int Add(Orders entity)
        {
            return dal.Insert(entity);
        }
        public bool Delete(int id)
        {
            var predicate = Predicates.Field<Orders>(f => f.Price, Operator.Eq, id);
            var re = dal.Delete(predicate);
            return re;
        }
        public bool DeleteById(int id)
        {
            var re = dal.DeleteById(id);
            return re;
        }
        public bool Update(Orders entity)
        {
            var re = dal.Update(entity);
            return re;
        }
        public bool Update(dynamic o1, dynamic o2)
        {
            var re = dal.Update(o1, o2);
            return re;
        }
        public int Count()
        {
            var entity = dal.Count();

            return entity;
        }

        public dynamic Test()
        {
            DynamicParameters paras = new DynamicParameters();
            paras.Add("@UId", 1);
            //paras.Add("@res", ParameterDirection.Output);
            var entity = dal.Execute<ViewTest>("Pro_TestView", paras);
            return entity;
        }

        public Orders Get(int id)
        {
            var entity = dal.Get(id);

            return entity;
        }
        public IEnumerable<Orders> GetList1()
        {
            var list3 = dal.Query<Orders>("select * from orders where price>10");
            return list3;
        }
        public IEnumerable<Orders> GetList11()
        {
            int count = 10;
            var list3 = dal.Where(p => p.Price > count);
            return list3;
        }
        public IEnumerable<dynamic> GetList2()
        {
            var list2 = dal.Query("select a.Id,a.Name,b.Price from Urls a inner join orders b on a.id = b.UId", "Price desc", 0, 5);
            return list2;
        }
        public IEnumerable<Demo> GetList3()
        {
            var list3 = dal.Query<Demo>("select a.Id,a.Name,b.Price from Urls a inner join orders b on a.id = b.UId");
            return list3;
        }

        public bool Save()
        {
            return new OrdersDAL().Save();
        }
    }
    public class ViewTest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

    }

}
