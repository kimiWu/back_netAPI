using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
namespace YXP.API.DataAccess
{
    public interface IBaseDAL<T>
    {
        int Count(Expression<Func<T, bool>> predicate);
        int Count(object predicate);
        int Count(string sql = null, string where = null);
        bool Delete(object predicate);
        bool Delete(T entity);
        bool DeleteById(object id);
        bool Exists(Expression<Func<T, bool>> predicate);
        bool Exists(object predicate);
        bool Exists(string sql = null, string where = null);
        T Get(dynamic id);
        IEnumerable<T> GetAll(object predicate = null, IList<ISort> sort = null);
        IEnumerable<T> GetAll(object predicate, IList<ISort> sort, int pageIndex, int pageSize);
        dynamic Insert(T obj);
        void InsertAll(params T[] objs);
        IEnumerable<dynamic> Query(string sql, int? timeout = null, bool buffered = true);
        IEnumerable<dynamic> Query(string sql, string orderBy, int pageIndex, int pageSize, int? timeout = null, bool buffered = true);
        IEnumerable<K> Query<K>(string sql, int? timeout = null, bool buffered = true) where K : class;
        IEnumerable<K> Query<K>(string sql, string orderBy, int pageIndex, int pageSize, int? timeout = null, bool buffered = true) where K : class;
        bool Update(dynamic updateDict, dynamic keyDict);
        bool Update(T entity);
        IEnumerable<T> Where(Expression<Func<T, bool>> predicate, string orderBy = null);
        IEnumerable<T> Where(Expression<Func<T, bool>> predicate, string orderBy, int pageIndex, int pageSize);
        IEnumerable<T> Where(string where, string orderBy = null);
        IEnumerable<T> Where(string where, string orderBy, int pageIndex, int pageSize);

    }
}
