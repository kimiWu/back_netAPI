using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using YXP.API.Entity.TranstarAuction;
using YXP.API.Utility;
using System.Runtime.Caching;
namespace YXP.KPSales.Models
{
    public class CommonUtils
    {
        private static HtmlHelper helper = new HtmlHelper();
        private static string apiUrl = System.Configuration.ConfigurationManager.AppSettings["apiWebsite"].ToString();
        private static string cypUrl = System.Configuration.ConfigurationManager.AppSettings["CYPUrl"].ToString();
       
        private static string query { get; set; }

        public static List<City> GetAll()
        {
            var token = EncryptHelper.Md5("yxp_zjhhl" + DateTime.Now.ToString("yyyy/M/d"), 32, System.Text.Encoding.UTF8);

            //var json = helper.Get(apiUrl + "/TranstarAuction/city/getall?platformid=8888");

            var json = helper.Get(apiUrl + "/TranstarAuction/city/getall?platformid=8&token=" + token);

            return Common.Deserialize<List<City>>(json);
        }

        public static string GetCYPData(string EngineNum)
        {
            var str = helper.Get(cypUrl + "/cgi-bin/che_yi_pai/get_cheyipai_bid_info.pl?Enum=" + EngineNum);
            return str;
        }
    }
    public class CachePool
    {
        WebApi.OutputCache.Core.Cache.IApiOutputCache cacheRedis = YXP.API.Cache.CacheHelper.Instance;
        private readonly string key = "hulu.youxinpai.com";
        private volatile static CachePool _instance = null;
        private static readonly object lockHelper = new object();
        private CachePool() { }
        public static CachePool CreateInstance()
        {
            if (_instance == null)
            {
                lock (lockHelper)
                {
                    if (_instance == null)
                        _instance = new CachePool();
                }
            }
            return _instance;
        }
        public OrderMapperOrder2Car GetValue(string cacheKey)
        {
            cacheKey = key + "_" + cacheKey;
           var orderMapper = cacheRedis.Get<OrderMapperOrder2Car>(cacheKey);
           if (orderMapper != null)
               return orderMapper;
            else
                return new OrderMapperOrder2Car() { Order = new xcp_order(), Order2Car = new List<xcp_order2car>() };
        }
        public void SetValue(string cacheKey, OrderMapperOrder2Car orderMapper)
        {
            cacheKey = key + "_" + cacheKey;
            cacheRedis.Add(cacheKey, orderMapper, DateTimeOffset.UtcNow.AddHours(1));
        }


    }
    public class OrderMapperOrder2Car
    {

        /// <summary>
        /// 委托单
        /// </summary>
        public xcp_order Order { get; set; }
        /// <summary>
        /// 提车1 自行送车2
        /// </summary>
        public List<xcp_order2car> Order2Car
        {
            get;
            set;
        }
    }
    public class ViewModelOrder 
    {
        private Int32? _carselfcount;
        private Int32? _carsendcount;

        public Int32? carselfcount
        {
            get { return _carselfcount; }
            set { _carselfcount = value; }
        }
        public Int32? carsendcount
        {
            get { return _carsendcount; }
            set { _carsendcount = value; }
        }

        public xcp_order order
        {
            get;
            set;
        }

    }
    public class Resource
    {
        [XmlAttribute("ID")]
        public string ID;

        [XmlAttribute("Name")]
        public string Name;

        [XmlAttribute("Url")]
        public string Url;

        [XmlAttribute("ControllerName")]
        public string ControllerName;

        [XmlAttribute("Style")]
        public string Style;

        [XmlAttribute("Sort")]
        public string Sort;

        public bool Enable = false;
    }

    public class Resources
    {
        [XmlAttribute("ID")]
        public string ID;

        [XmlAttribute("Name")]
        public string Name;

        [XmlAttribute("Enable")]
        public bool Enable;

        [XmlArrayItem("Resource")]
        public List<Resource> ResourceList;
    }


}