using System;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using System.Collections.Generic;
using YXP.API.Entity;
using Dapper;
using DapperExtensions;
using DapperExtensions.Sql;
using DapperExtensions.Mapper;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Data.SqlClient;


namespace YXP.API.DataAccess
{
    /// <summary>
    /// 依赖TBase
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseDAL<T> : IBaseDAL<T>
        where T : class
    {
        
        private IEnumerable<ConnectionItem> clist { set; get; }

        /// <summary>
        /// state 0 （读） 1 （写） 2 （读写）
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public Database GetDB(int state = 0)
        {
            List<Database> db = new List<Database>();
            try
            {
                var tlist = clist.Count() == 1 ? clist : clist.Where(p => p.State == state);
                foreach (var item in tlist)
                {
                    var cfg = new DapperExtensionsConfiguration(typeof(AutoClassMapper<>), new List<Assembly>(), item.dBase);
                    var tdb = new Database(item.Connection, new SqlGeneratorImpl(cfg));
                    db.Add(tdb);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return GetRandomItem(db);
        }

        private K GetRandomItem<K>(IEnumerable<K> list)
        {
            //if (list == null) throw new ArgumentNullException("list");
            int count = list.Count();
            if (count == 0)
                return default(K);
            if (count == 1)
                return list.First();
            int index = new Random().Next(count);
            return list.ElementAt(index);
        }


        public BaseDAL(string connGroupName, string connName = "")
        {
            if (string.IsNullOrEmpty(connGroupName))
            {
                connGroupName = ConnEnum.lists[0].GroupName;
            }
            if (!string.IsNullOrEmpty(connName))
            {
                clist = ConnEnum.lists.Where(p => p.Name == connName);
            }
            else
            {
                clist = ConnEnum.lists.Where(p => p.GroupName == connGroupName);

            }
        }

        #region operator

        #region GET
        public T Get(dynamic id)
        {
            using (var db = GetDB(0))
            {
                return db.Get<T>(id);
            }

        }


        #endregion

        #region Insert
        public void InsertAll(params T[] objs)
        {
            using (var db = GetDB(1))
            {
                db.Insert<T>(objs);
            }
        }

        public dynamic Insert(T obj)
        {
            using (var db = GetDB(1))
            {
                return db.Insert<T>(obj);
            }
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 通过条件删除
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public bool Delete(object predicate)
        {
            using (var db = GetDB(1))
            {
                return db.Delete<T>(predicate);
            }
        }
        /// <summary>
        /// 通过类删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            using (var db = GetDB(1))
            {
                return db.Delete<T>(entity);
            }
        }
        /// <summary>
        /// 通过id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(object id)
        {
            using (var db = GetDB(1))
            {
                return db.DeleteById<T>(id);
            }
        }
        #endregion

        #region UPDATE
        public bool Update(T entity)
        {
            using (var db = GetDB(1))
            {
                return db.Update(entity);
            }
        }
        public bool Update(dynamic updateDict, dynamic keyDict)
        {
            using (var db = GetDB(1))
            {
                return db.Update<T>(updateDict, keyDict) > 0;
            }
        }
        #endregion

        #region Count
        public int Count(object predicate)
        {
            using (var db = GetDB(0))
            {
                return db.Count<T>(predicate);
            }
        }
        public int Count(string sql = null, string where = null)
        {
            using (var db = GetDB(0))
            {
                return db.Count<T>(sql, where);
            }
        }
        public int CountOrder(string sql = null, string where = null)
        {
            using (var db = GetDB(1))
            {
                return db.Count<T>(sql, where);
            }
        }
        public int Count(Expression<Func<T, bool>> predicate)
        {
            using (var db = GetDB(0))
            {
                return db.Count<T>(predicate);
            }
        }
        #endregion

        #region Exists
        public bool Exists(object predicate)
        {
            using (var db = GetDB(0))
            {
                return db.Count<T>(predicate).Equals(1);
            }
        }
        public bool Exists(string sql = null, string where = null)
        {
            using (var db = GetDB(0))
            {
                return db.Count<T>(sql, where).Equals(1);
            }
        }
        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            using (var db = GetDB(0))
            {
                return db.Count<T>(predicate).Equals(1);
            }
        }
        #endregion

        #region Where
        public IEnumerable<T> GetAll(object predicate, IList<ISort> sort, int pageIndex, int pageSize)
        {
            using (var db = GetDB(0))
            {
                return db.GetPage<T>(predicate, sort, pageIndex, pageSize);
            }
        }

        public IEnumerable<T> GetAll(object predicate = null, IList<ISort> sort = null)
        {
            using (var db = GetDB(0))
            {
                return db.GetList<T>(predicate, sort);
            }
        }
        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate, string orderBy = null)
        {
            using (var db = GetDB(0))
            {
                return db.Where<T>(predicate, orderBy);
            }
        }
        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate, string orderBy, int pageIndex, int pageSize)
        {
            using (var db = GetDB(0))
            {
                return db.Where<T>(predicate, orderBy, pageIndex, pageSize);
            }
        }
        public IEnumerable<T> Where(string where, string orderBy = null)
        {
            using (var db = GetDB(0))
            {
                return db.Where<T>(where, orderBy);
            }
        }
        public IEnumerable<T> Where(string where, string orderBy, int pageIndex, int pageSize)
        {
            using (var db = GetDB(0))
            {
                return db.Where<T>(where, orderBy, pageIndex, pageSize);
            }
        }
        #endregion

        #region Get By SQL Query
        public IEnumerable<K> Query<K>(string sql, int? timeout = null, bool buffered = true) where K : class
        {
            using (var db = GetDB(0))
            {
                return db.Query<K>(sql, CommandType.Text, timeout, buffered);
            }
        }
        public IEnumerable<K> Query<K>(string sql, string orderBy, int pageIndex, int pageSize, int? timeout = null, bool buffered = true) where K : class
        {
            using (var db = GetDB(0))
            {
                return db.Query<K>(sql, orderBy, pageIndex, pageSize, CommandType.Text, timeout, buffered);
            }
        }
        public IEnumerable<dynamic> Query(string sql, int? timeout = null, bool buffered = true)
        {
            using (var db = GetDB(0))
            {
                return db.Query(sql, CommandType.Text, timeout, buffered);
            }
        }
        public IEnumerable<dynamic> Query(string sql, string orderBy, int pageIndex, int pageSize, int? timeout = null, bool buffered = true)
        {
            using (var db = GetDB(0))
            {
                return db.Query(sql, orderBy, pageIndex, pageSize, CommandType.Text, timeout, buffered);
            }
        }
        #endregion

        #region Execute Procedure
        public dynamic Execute<K>(string pName, DynamicParameters paras = null, int state = 1)
        {
            using (var db = GetDB(state))
            {
                return db.Execute<K>(pName, paras);
            }
        }
  
        #endregion

        #endregion

    }
}
