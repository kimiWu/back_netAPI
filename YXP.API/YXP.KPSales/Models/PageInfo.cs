using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YXP.KPSales.Models
{
    public class PageInfo
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int pageIndex { get; set; }

        /// <summary>
        /// 每一页显示的数据
        /// </summary>
        public int pageSize { get; set; }


        /// <summary>
        /// 总的数据条数
        /// </summary>
        public int sumItem { get; set; }


        /// <summary>
        /// 页数
        /// </summary>
        public int pageCount
        {
            get
            {

                if (sumItem == 0)
                {
                    return 0;
                }
                if (pageSize == 0)
                {
                    return 0;
                }

                return sumItem % pageSize == 0 ? sumItem / pageSize : sumItem / pageSize + 1;

            }
        }


    }
}