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

namespace YXP.API.Business.TranstarAuction
{
	public class ProvinceBLL
	{
		private ProvinceDAL dal = new ProvinceDAL();

		#region GET
		/// <summary>
		/// 获取所有记录
		/// </summary>
		/// <returns>结果集</returns>
        public IEnumerable<Province> GetList()
		{
			return dal.GetAll();
		}

 

		/// <summary>
		/// 推荐用这种方式书写，这样修改了Entity，引用了entity的Expression的Code处就用自动报错，编译不过去
		/// </summary>
		/// <param name="exp">lambda表达式</param>
		/// <param name="orderBy">排序方式</param>
		/// <returns>数据集</returns>
		public IEnumerable<Province> GetList(Expression<Func<Province, bool>> exp, string orderBy = "")
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
		public IEnumerable<Province> GetList(Expression<Func<Province, bool>> exp, string orderBy, int pageIndex, int pageSize)
		{
			return dal.Where(exp, orderBy, pageIndex, pageSize);
		}

		/// <summary>
		/// 通过表的主键编号获取实体类
		/// </summary>
		/// <param name="id">主键编号</param>
		/// <returns>实体类</returns>
		public Province Get(object id)
		{
			return dal.Get(id);
		}

		#endregion

	}
}
