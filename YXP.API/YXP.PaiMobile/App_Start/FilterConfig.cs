using System.Web;
using System.Web.Mvc;
using YXP.PaiMobile.filter;

namespace YXP.PaiMobile
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new WebHandleErrorAttribute(), 1);
            filters.Add(new HandleErrorAttribute(), 2);
        }
    }
}