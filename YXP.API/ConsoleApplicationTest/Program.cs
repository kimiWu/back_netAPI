using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity;
using YXP.API.Entity.Log;
using YXP.API.Utility;

namespace ConsoleApplicationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var pm = new Program();

            //Task t1 = new Task(new Action(pm.Task1));
            //t1.ContinueWith(new Action<Task>(p =>
            //{
            //    Console.WriteLine("t1 end");
            //}));
            //t1.Start();
            //Task<int> t2 = new Task<int>(new Func<int>(pm.Task2));
            //t2.ContinueWith(new Action<Task>(p =>
            //{
            //    Console.WriteLine("t2 end");
            //}));
            //t2.Start();
            //var model = new LogRecords() { Id = 1000, CreateTime = DateTime.Now, UpdateTime = DateTime.Now, PlatformId = 2, Browser = "IE" };
            //var action = new Action<LogRecords>(pm.Task3);
            //Task t3 = new Task(() => pm.Task3(model));
            //t3.ContinueWith(new Action<Task>(p =>
            //{
            //    Console.WriteLine("t3 end");
            //}));
            //t3.Start();
             pm.test1();
            //pm.test2();
            //pm.test3();

          
            var tasks = new Task[2000];
            for (var x = 0; x < 2000; x++)
            {
                tasks[x] = Task.Factory.StartNew((index) =>
                {
                    pm.test4();
                }, x);
            }
            Task.WaitAll(tasks, 20000);
            Console.ReadLine();
        }
        HttpClientHelper client =  new HttpClientHelper("apilog", "orders");


        public async Task<string> test1()
        {
            string json = "";
            try
            {
                json = await HttpClientHelper.GetAsyncString("GetOrders3", "?platformid=2");
                Console.WriteLine(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return json;
        }

        public void test2()
        {
            try
            {
                var dict = new Dictionary<string, string>();
                dict.Add("id", "1");
                dict.Add("name", "aaa");
                dict.Add("price", "100");
                dict.Add("serial", "a0001");
                dict.Add("platformId", "2");
                var msg = HttpClientHelper.PostAsync("apilog", "orders", dict);
                Console.WriteLine(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<string> test3()
        {
            string json = "";
            try
            {
                string publishId = "1888";
                string token = EncryptHelper.Md5(publishId + "yxp" + DateTime.Now.ToString("yyyy/M/d"), 32, Encoding.UTF8);
                string query = "?bankstr=人民&platformid=1&publishId=1888&token=" + token;
                json = await HttpClientHelper.GetAsyncString("Bank", "bank", "getName", query);
                Console.WriteLine(json);
              
            }
            catch (Exception ex)
            {
                json = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return json;
        }


        public void test4()
        {
            HtmlHelper hh = new HtmlHelper();
            string s = hh.Get("http://localhost:45099/TranstarAuction/Login/Login?RandomNum=807219&PlatformId=7&WindowWH=320&password=d3acfe3e07d32ab64655d478ceebbbc3&mobileType=2&userName=ff005&Token=f29410e7bcbc27fff7bdf25c85ef28d6&publishId=ff005&version=8.3");
            Console.Write(s);
        }


        //public void Task1()
        //{
        //    var bll = new YXP.API.Business.Log.LogRecordsBLL();
        //    var lists = bll.GetAll("");
        //    Console.WriteLine("查询成功：" + lists.Count());
          
        //}

        //public int Task2()
        //{
        //    var bll = new YXP.API.Business.Log.LogRecordsBLL();
        //    var count = bll.GetCount("select count(*) from logrecords");
          
        //    return count;
        //}

        //public void Task3(LogRecords model)
        //{
        //    var bll = new YXP.API.Business.Log.LogRecordsBLL();
        //    var re = bll.Save(model);
        //    Console.WriteLine("保存成功");
            
        //}
    }


}
