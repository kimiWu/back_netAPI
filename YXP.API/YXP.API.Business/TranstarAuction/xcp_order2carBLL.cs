﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YXP.API.DataAccess;
using YXP.API.DataAccess.TranstarAuction;
using YXP.API.Entity;
using YXP.API.Entity.TranstarAuction;
using YXP.API.Utility;

namespace YXP.API.Business.TranstarAuction
{
    public class xcp_order2carBLL
    {

        private xcp_order2carDAL dal = new xcp_order2carDAL();
        #region GET
        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public IEnumerable<xcp_order2car> GetList()
        {
            return dal.GetAll();
        }
        public  bool  Update (xcp_order2car model)
        {
            return dal.Update(model);
        }

        public bool Update(dynamic updateDict,dynamic keyDict)
        {
            return dal.Update(updateDict, keyDict);
        }

        public long Insert(xcp_order2car model)
        {
            return dal.Insert(model);
        }

        /// <summary>
        /// 不推荐用这种方式书写，1、如果修改了Entity，某处字符串里的字段没改编译不报错 2、容易sql注入
        /// </summary>
        /// <param name="exp">lambda表达式</param>
        /// <param name="orderBy">排序方式</param>
        /// <returns>数据集</returns>
        public IEnumerable<xcp_order2car> GetList(string where, string orderBy = "")
        {
            return dal.Where(where, orderBy);
        }

        /// <summary>
        /// 不推荐用这种方式书写，1、如果修改了Entity，某处字符串里的字段没改编译不报错 2、容易sql注入
        /// </summary>
        /// <param name="exp">lambda表达式</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <returns>数据集</returns>
        public IEnumerable<xcp_order2car> GetList(string where, string orderBy, int pageIndex, int pageSize)
        {
            return dal.Where(where, orderBy, pageIndex, pageSize);
        }

        /// <summary>
        /// 推荐用这种方式书写，这样修改了Entity，引用了entity的Expression的Code处就用自动报错，编译不过去
        /// </summary>
        /// <param name="exp">lambda表达式</param>
        /// <param name="orderBy">排序方式</param>
        /// <returns>数据集</returns>
        public IEnumerable<xcp_order2car> GetList(Expression<Func<xcp_order2car, bool>> exp, string orderBy = "")
        {
            return dal.Where(exp, orderBy);
        }

        /// <summary>
        /// 推荐用这种方式书写，这样修改了Entity，引用了entity的Expression的Code处就用自动报错，编译不过去
        /// </summary>
        /// <param name="exp">lambda表达式</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <returns>数据集</returns>
        public IEnumerable<xcp_order2car> GetList(Expression<Func<xcp_order2car, bool>> exp, string orderBy, int pageIndex, int pageSize)
        {
            return dal.Where(exp, orderBy, pageIndex, pageSize);
        }

        /// <summary>
        /// 通过表的主键编号获取实体类
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns>实体类</returns>
        public xcp_order2car Get(object id)
        {
            return dal.Get(id);
        }
        public int GetCount(int? xo_id, int receive_type)
        {
            return dal.GetCount(xo_id, receive_type);
        }
        #endregion

    }
}
