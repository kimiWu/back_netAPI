using DapperExtensions.Sql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YXP.API.DataAccess
{
    /// <summary>
    /// 连接串枚举类，方便扩展多数据源
    /// </summary>
    public class ConnEnum
    {
        #region 兼容老的写法
        public static string TranstarAuctionConfigPath
        {
            get
            {
                return "TranstarAuctionConfigPath";
            }
        }
        public static string TranstarAuction2011ConfigPath
        {
            get
            {
                return "TranstarAuction2011ConfigPath";
            }
        }
        

        public static string UcarRead
        {
            get
            {
                return "UcarRead";
            }
        }

        public static string AutosCarRead
        {
            get
            {
                return "AutosCarRead";
            }
        }

        public static string ApiLogConfigPath
        {
            get
            {
                return "ApiLogConfigPath";
            }
        }

        #endregion

        public static List<ConnectionItem> lists = new List<ConnectionItem>();

        /// <summary>
        /// State 0为读，1为写，2为读写
        /// Flag  0为SQLServer，1为MySQL，2为SQLite
        /// </summary>
        static ConnEnum()
        {
            lists.Add(new ConnectionItem() { Name = "SqlMapConfigPath", GroupName = "SqlMapConfigPath", State = 2 }); //读写库
            lists.Add(new ConnectionItem() { Name = "ApiLogConfigPath", GroupName = "ApiLogConfigPath", State = 2 });//读写库
            lists.Add(new ConnectionItem() { Name = "AuctionResourcesPath", GroupName = "AuctionResourcesPath", State = 2 });//读写库
            lists.Add(new ConnectionItem() { Name = "CarResourcePath", GroupName = "CarResourcePath", State = 2 });//读写库
            lists.Add(new ConnectionItem() { Name = "TranstarAuctionConfigPathRead", GroupName = "TranstarAuctionConfigPath", State = 0 });//读库
            lists.Add(new ConnectionItem() { Name = "TranstarAuctionConfigPathWrite", GroupName = "TranstarAuctionConfigPath", State = 1 });//写库
            lists.Add(new ConnectionItem() { Name = "AutosCarRead", GroupName = "AutosCarRead", State = 0 }); //读库
            lists.Add(new ConnectionItem() { Name = "UcarRead", GroupName = "UcarRead", State = 0 }); //读库
            lists.Add(new ConnectionItem() { Name = "OPFramework", GroupName = "OPFramework", State = 0 }); //读库
            lists.Add(new ConnectionItem() { Name = "MySqlTest", GroupName = "MySqlTest", State = 2, Flag = 1 }); //读写库 -MySQL
            lists.Add(new ConnectionItem() { Name = "StandardSale", GroupName = "StandardSale", State = 2 }); //读写库
            lists.Add(new ConnectionItem() { Name = "TranstarAuction2011ConfigPath", GroupName = "TranstarAuction2011ConfigPath", State = 1 });
        }
    }
    public class ConnectionItem
    {
        public string GroupName { get; set; }

        public string Name { get; set; }

        public int Flag { get; set; }

        public int State { get; set; }

        public SqlDialectBase dBase
        {
            get
            {
                SqlDialectBase mybase = null;
                switch (Flag)
                {
                    case 0:
                        mybase = new SqlServerDialect();
                        break;
                    case 1:
                        mybase = new MySqlDialect();
                        break;

                }
                return mybase;
            }
        }

        public DbConnection Connection
        {
            get
            {
                var cs = ConfigurationManager.ConnectionStrings[Name].ConnectionString;
                DbConnection conn = null;
                switch (Flag)
                {
                    case 0:
                        conn = new SqlConnection(cs);
                        break;
                    case 1:
                        conn = new MySqlConnection(cs);
                        break;

                }
                //if (conn != null && conn.State != System.Data.ConnectionState.Open)
                //{
                //    conn.Open();
                //}
                return conn;
            }
        }
    }


}
