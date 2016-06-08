using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using YXP.API.Business.TranstarAuction;
using YXP.API.Entity.LocaleOrder;
using YXP.API.Entity.TranstarAuction;
using YXP.API.Utility;
using YXP.KPSales.Models;
namespace YXP.KPSales.Controllers
{
    public class LocaleOrderController : WebBaseController
    {
        private xcp_orderBLL bll = new xcp_orderBLL();
        private xcp_order2carBLL carbll = new xcp_order2carBLL();
        private TranstarVendorAccountBLL transtarVendorAccountbll = new TranstarVendorAccountBLL();
        private AuctionTransferAddressBLL auctionTransferAddressbll = new AuctionTransferAddressBLL();
        private static string logPath = System.Configuration.ConfigurationManager.AppSettings["logPath"];
        private static string testUser = System.Configuration.ConfigurationManager.AppSettings["testUser"];
        private static string testConfig = System.Configuration.ConfigurationManager.AppSettings["marketConfig"];
        private static YXP.KPSales.Models.CachePool cachePool = CachePool.CreateInstance();
        LogWriter log = new LogWriter(System.Configuration.ConfigurationManager.AppSettings["logPath"].ToString());
        /// <summary>
        /// 现场下单
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            Stopwatch watch = new Stopwatch();
            watch.Start();
            var model = GetList(10, "");
            string aa = loginUser.RealName;

            ///清空缓存数据  begin
            OrderMapperOrder2Car orderMapper = null;
            orderMapper = new OrderMapperOrder2Car() { Order = new xcp_order(), Order2Car = new List<xcp_order2car>() };
            cachePool.SetValue(loginUser.UserId.ToString(), orderMapper);

            watch.Stop();
            log.WriteLine(DateTime.Now + "  " + loginUser.LoginName + "(" + loginUser.UserId + ")" + " LocaleOrder-Index/" + " 执行时间： " + watch.ElapsedMilliseconds);
            var listViewmodel = new List<ViewModelOrder>();
            if (model != null && model.Count > 0)
            {
                foreach (var item in model)
                {
                    ViewModelOrder viewModel = new ViewModelOrder();
                    viewModel.order = item;
                    viewModel.carselfcount = GetCarNumber((int)item.ID, 1);
                    viewModel.carsendcount = GetCarNumber((int)item.ID, 2);
                    listViewmodel.Add(viewModel);
                }
            }
            return View(listViewmodel);
        }
        public ActionResult CreateClient(int ID = 0)
        {
            //todo 获取场地
            //YXP.API.Business.TranstarAuction.marketBLL marketbll = new marketBLL();
            //var list = marketbll.GetList();
            //ViewData["fileds"] = list;
            //获取场地
            PHPService phps = new PHPService();
            //int dtype = CurrentUser.Vendor.ISFormal ? 2 : 1;
            int dtype = 2;
            if (testConfig == "1")  //显示所有数据
            {
                dtype = 1;
            }
            else if (testConfig == "2")  //只显示正式数据
            {
                dtype = 2;
            }
            if (testUser != "")
            {
                var userlist = testUser.Split('|').ToList();
                if (userlist.Exists(x=>x.Trim()==loginUser.LoginName))
                {
                    dtype = 1;
                }
            }

            System.Web.Script.Serialization.JavaScriptSerializer serial = new System.Web.Script.Serialization.JavaScriptSerializer();
            PhpResult result = phps.LocaleOrderField(2, dtype);

            if (result != null && (int)result.code == 1)
            {
                string fileds = serial.Serialize(result.data);
                ViewData["fileds"] = serial.Deserialize<List<Field>>(fileds);
            }
            else
            {
                ViewData["fileds"] = null;
            }


            YXP.API.Entity.TranstarAuction.xcp_order Model = null;
            List<YXP.API.Entity.TranstarAuction.xcp_order2car> carlist = null;
            OrderMapperOrder2Car orderMapper = null;
            string titleName = "";
            orderMapper = cachePool.GetValue(loginUser.UserId.ToString());
            if (ID != 0)
            {
                Model = bll.Get(ID);
                carlist = carbll.GetList(" xo_id=" + ID, "").ToList();
                orderMapper = new OrderMapperOrder2Car { Order = Model, Order2Car = carlist };
                cachePool.SetValue(loginUser.UserId.ToString(), orderMapper);
            }
            if (orderMapper.Order.ID != 0)
            {
                titleName = "修改委托单";
            }
            else
            {
                titleName = "新建委托单";
            }
            ViewData["titleName"] = titleName;
            ViewData["count_self"] = orderMapper.Order2Car.Where(x => x.receive_type == 1).ToList().Count;
            ViewData["count_send"] = orderMapper.Order2Car.Where(x => x.receive_type == 2).ToList().Count;
            return View(orderMapper);
        }



        public JsonResult CacheOrder(xcp_order model)
        {

            try
            {
                string key = loginUser.UserId.ToString();
                var OrderMapper = cachePool.GetValue(key);
                //OrderMapper.Order = model;
                UpdateOrder(OrderMapper.Order, model);  //更新信息
                cachePool.SetValue(key, OrderMapper);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Status = 0,
                    Msg = "系统错误：" + ex.Message.ToString()
                });
            }
            return Json(new
            {
                Status = 1,
                Msg = "成功"
            });
        }


        public JsonResult CacheTvaId(int tvaId, string tvaName, string LinkMan, string LinkMobile, string Address)
        {

            try
            {
                string key = loginUser.UserId.ToString();
                var OrderMapper = cachePool.GetValue(key);
                OrderMapper.Order.master_id = tvaId;
                OrderMapper.Order.VendorShortName = tvaName;
                OrderMapper.Order.fetch_user = LinkMan;
                OrderMapper.Order.fetch_user_mobile = LinkMobile;
                OrderMapper.Order.price_user = LinkMan;
                OrderMapper.Order.price_user_mobile = LinkMobile;
                OrderMapper.Order.dealer_addr = Address;
                //UpdateOrder(OrderMapper.Order, model);  //更新信息
                cachePool.SetValue(key, OrderMapper);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Status = 0,
                    Msg = "系统错误：" + ex.Message.ToString()
                });
            }
            return Json(new
            {
                Status = 1,
                Msg = "成功"
            });
        }

        public JsonResult ClearCars()
        {

            try
            {
                string key = loginUser.UserId.ToString();
                var OrderMapper = cachePool.GetValue(key);
                //OrderMapper.Order = model;
                OrderMapper.Order2Car = new List<xcp_order2car>();
                cachePool.SetValue(key, OrderMapper);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Status = 0,
                    Msg = "系统错误：" + ex.Message.ToString()
                });
            }
            return Json(new
            {
                Status = 1,
                Msg = "成功"
            });
        }


        private void UpdateOrder(xcp_order objectModel, xcp_order newModel)
        {
            objectModel.market_id = newModel.market_id;
            objectModel.market_name = newModel.market_name;
            objectModel.dealer_addr = newModel.dealer_addr;
            objectModel.price_user = newModel.price_user;
            objectModel.price_user_mobile = newModel.price_user_mobile;
            objectModel.publish_time = newModel.publish_time;
            objectModel.master_id = newModel.master_id;
            objectModel.fetch_user = newModel.fetch_user;
            objectModel.fetch_user_mobile = newModel.fetch_user_mobile;
            objectModel.remark = newModel.remark;
            objectModel.VendorShortName = newModel.VendorShortName;
            objectModel.dealer_id = loginUser.UserId;
            objectModel.dealer_user = loginUser.RealName;
            objectModel.type = 9;
            objectModel.createtime = DateTime.Now;
        }

        /// <summary>
        /// 创建委托单
        /// </summary>
        /// <returns></returns>
        // client: client, address: address, contact: contact, contactPhone: contactPhone, pricePerson: pricePerson, contactPhone2: contactPhone2, selectdate: selectdate 
        public JsonResult AddOrder(xcp_order model)
        {
            OrderMapperOrder2Car orderMapper = null;
            orderMapper = cachePool.GetValue(loginUser.UserId.ToString());
            UpdateOrder(orderMapper.Order, model);  //更新信息
            PhpResult res;

            if (orderMapper.Order2Car.Count == 0)
            {
                return Json(new { code = -1, mesage = "请录入车辆信息" });
            }


            #region 通知php

            model = orderMapper.Order;
            PHPService ps = new PHPService();
            IList<xcp_order2car> cars = orderMapper.Order2Car;
            IList<LocaleCarInfo> lcars = new List<LocaleCarInfo>();
            foreach (var car in cars)
            {
                lcars.Add(new LocaleCarInfo(car, model));
            }
            //请求php
            res = ps.LocaleOrderAdd(model, lcars,loginUser.LoginName,loginUser.RealName);
            if (res == null || (int)res.code != 1)
            {
                res = ps.LocaleOrderAdd(model, lcars, loginUser.LoginName, loginUser.RealName);
            }

            if (res != null && (int)res.code == 1)
            {
                System.Web.Script.Serialization.JavaScriptSerializer serial = new System.Web.Script.Serialization.JavaScriptSerializer();
                string mstr = serial.Serialize(res.data);
                OrderCreateResult crs = serial.Deserialize<OrderCreateResult>(mstr);

                #region [插入sql数据库]
                try
                {
                    orderMapper.Order.xoid = crs.xoid;
                    var n = bll.Insert(orderMapper.Order);

                    if (n > 0 && crs.xo2cid.Count == orderMapper.Order2Car.Count)
                    {
                        for (int i = 0; i < orderMapper.Order2Car.Count; i++)
                        {
                            orderMapper.Order2Car[i].xo2cid = crs.xo2cid[i];
                            orderMapper.Order2Car[i].xcp_uucode = null;
                            orderMapper.Order2Car[i].xo_id = (int)orderMapper.Order.ID;
                            carbll.Insert(orderMapper.Order2Car[i]);
                        }
                        log.WriteLine(string.Format("{0}\r\n  现场下单--同步phpid并插入数据库 成功：请求car数量：{0},返回php-carid数量：{1}，时间：{2}", orderMapper.Order2Car.Count, crs.xo2cid.Count, DateTime.Now.ToString("yyyy-MM-dd mm:hh:ss")));
                    }
                    else
                    {
                        res.code = 0;
                        if (n <= 0)
                        {
                            res.message = "下单失败，请重新尝试！";
                            log.WriteLine(string.Format("{0}\r\n  现场下单--同步phpid并插入数据库：插入失败: ID={0} , 信息：{1}", model.ID, "插入数据为空"));
                        }
                        else
                        {
                            res.message = "数据同步错误，请重新尝试！";
                            log.WriteLine(string.Format("{0}\r\n  现场下单--同步phpid并插入数据库：同步错误: ID={0} , 信息：{1}", model.ID, "同步php返回车辆数与插入数据库数量不一致"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    res.code = 0;
                    res.message = ex.Message;
                    log.WriteLine(string.Format("{0}\r\n  现场下单--同步phpid并插入数据库：失败: ID={0} , 信息：{1}", model.ID, res.message));
                }

                #endregion
                //同步php返回的order id
                //Facde.XcpOrderProvider.Updatexoid(crs.xoid, (int)id);
                //bll.Update(new { xoid = crs.xoid }, new { ID = model.ID });

                //同步php返回的car  id
                //if (cars != null && cars.Count != 0 && crs.xo2cid.Count == cars.Count)
                //{
                //    for (int i = 0; i < cars.Count; i++)
                //    {
                //        //Facde.XcpOrderCarProvider.UpdateXo2cid(crs.xo2cid[i], (int)cars[i].ID);
                //        carbll.Update(new { xo2cid = crs.xo2cid[i] }, new { ID = cars[i].ID });
                //    }
                //}
                //else
                //{
                //    log.WriteLine(string.Format("{0}\r\n  现场下单--同步phpid：请求car数量：{0},返回php-carid数量：{1}，时间：{2}", cars.Count, crs.xo2cid.Count, DateTime.Now.ToString("yyyy-MM-dd mm:hh:ss")));
                //}

            }
            else
            {
                log.WriteLine(string.Format("{0}\r\n  现场下单--同步phpid：请求失败: ID={0} , 信息：{1}", model.ID, res == null ? "php无返回数据" : res.message));
                if (res == null)
                {
                    res = new PhpResult();
                    res.code = -1;
                    res.message = "下单失败，无法同步数据!";
                }
            }


            #endregion

            return Json(res);

        }
        /// <summary>
        /// 选择委托方
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectClient()
        {
            return View();
        }
        public ActionResult SearchDeal(string vendorName, string type, int pageSize = 20, int max = 0, int min = 0)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var model = this.GetListByVendorFullName(vendorName, pageSize, type, max, min);
            watch.Stop();
            log.WriteLine(DateTime.Now + "  " + loginUser.LoginName + "(" + loginUser.UserId + ")" + " LocaleOrder-SearchDeal 执行时间： " + watch.ElapsedMilliseconds);
            return View("/Views/LocaleOrder/SelectClient.cshtml", model);
        }

        /// <summary>
        /// 获取车辆总数
        /// </summary>
        /// <param name="xo_id">委托单号Id</param>
        /// <param name="receive_type">[1自送2代送]</param>
        /// <returns></returns>
        public static int GetCarNumber(int? xo_id, int receive_type)
        {
            if (xo_id != null && xo_id.Value > 0)
                return new xcp_order2carBLL().GetCount(xo_id, receive_type);

            else
                return 0;
        }
        [HttpPost]
        public ActionResult ListData(string type, int pageSize = 10, int max = 0, int min = 0)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var model = GetList(pageSize, type, max, min);
            var listViewmodel = new List<ViewModelOrder>();
            if (model != null && model.Count > 0)
            {
                foreach (var item in model)
                {
                    ViewModelOrder viewModel = new ViewModelOrder();
                    viewModel.order = item;
                    viewModel.carselfcount = GetCarNumber((int)item.ID, 1);
                    viewModel.carsendcount = GetCarNumber((int)item.ID, 2);
                    listViewmodel.Add(viewModel);
                }
            }
            var jsonStr = Common.Serialize(listViewmodel);
            watch.Stop();
            log.WriteLine(DateTime.Now + "  " + loginUser.LoginName + "(" + loginUser.UserId + ")" + " LocaleOrder-ListData 执行时间： " + watch.ElapsedMilliseconds);

            return Content(jsonStr);
        }
        public List<xcp_order> GetList(int pageSize = 10, string type = "", int max = 0, int min = 0)
        {
            try
            {

                if (string.IsNullOrEmpty(loginUser.UserId.ToString()))
                {
                    return null;
                }
                else
                {

                    string strWhere = string.Format(" dealer_id={0} ", loginUser.UserId);

                    var list = bll.GetList("", pageSize, max, min, type, loginUser.UserId).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                log.WriteLine(DateTime.Now + "  " + loginUser.LoginName + "(" + loginUser.UserId + ")" + " LocaleOrder-GetList 发生异常： " + ex.Message);
                return null;
            }
        }

        public List<TranstarVendorAccount> GetListByVendorFullName(string vendorFullName, int pageSize = 20, string type = "", int max = 0, int min = 0)
        {
            try
            {

                if (string.IsNullOrEmpty(loginUser.UserId.ToString()))
                {
                    return null;
                }
                else
                {

                    var list = transtarVendorAccountbll.GetListByVendorFullName("", pageSize, max, min, type, vendorFullName).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                log.WriteLine(DateTime.Now + "  " + loginUser.LoginName + "(" + loginUser.UserId + ")" + " LocaleOrder-GetListByVendorFullName 发生异常： " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 车辆列表信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stype"></param>
        /// <param name="carids"></param>
        /// <param name="Para"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public ActionResult Order_CarList(int cityId, int stType)
        {
            var model = cachePool.GetValue(loginUser.UserId.ToString());
            IList<xcp_order2car> result = null;
            result = model.Order2Car.Where(x => x.receive_type == stType).ToList();
            ViewBag.cityId = cityId;
            ViewBag.stType = stType;
            ViewBag.ID = model.Order.ID;
            return View(result);
        }

        /// <summary>
        /// 添加车辆信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Order_AddCar(int stType, string cityId = "", string uucode = "", int carId = 0, string Para = default(string), string Carids = default(string))
        {
            TranstarVendorConfigBLL configbll = new TranstarVendorConfigBLL();
            AuctionArrangeItemBLL arrangebll = new AuctionArrangeItemBLL();
            xcp_order2car obj = null;
            OrderMapperOrder2Car orderMapper = null;
            orderMapper = cachePool.GetValue(loginUser.UserId.ToString());
            var model = orderMapper.Order2Car.Where(x => x.receive_type == stType).ToList();

            if (model != null && model.Count > 0)
            {
                if (carId != 0)
                {
                    obj = model.Where(o => o.ID == carId).First();
                }
                else if (!string.IsNullOrEmpty(uucode))
                {
                    obj = model.Where(o => o.xcp_uucode == uucode).First();
                }
            }

            ViewData["stType"] = stType;// 1、自送 2、代送
            ViewData["prar"] = Para;
            ViewData["carids"] = Carids;
            ViewData["cityId"] = cityId;
            var Addresslist = auctionTransferAddressbll.GetList(cityId).ToList(); //通过cityId获取过户场地
            Addresslist.Insert(0, new AuctionTransferAddress() { SysAddressID = 0, AddressName = "无要求" });
            ViewData["AuctionTransferAddress"] = Addresslist;

            ViewData["ArrangeList"] = arrangebll.GetList();
            ViewData["AuctionFeeRange"] = configbll.GetConfigById(Convert.ToInt32(orderMapper.Order.master_id), "AuctionFeeRange");
            ViewData["TheThreeServiceBackDefaultFeeConfiguration"] = configbll.GetConfigById(Convert.ToInt32(orderMapper.Order.master_id), "TheThreeServiceBackDefaultFeeConfiguration");
            ViewData["TheThreeServiceRadioChoiceConfiguration"] = configbll.GetConfigById(Convert.ToInt32(orderMapper.Order.master_id), "TheThreeServiceRadioChoiceConfiguration");
            if (obj != null)
            {
                ViewData["isLook"] = 1;
            }
            else
            {
                ViewData["isLook"] = 0;
            }
            return View(obj);
        }


        public JsonResult DeleteCar(string code, int stType)
        {
            try
            {
                string key = loginUser.UserId.ToString();
                var OrderMapper = cachePool.GetValue(key);
                if (OrderMapper.Order2Car != null && OrderMapper.Order2Car.Count > 0)
                {
                    OrderMapper.Order2Car.Remove(OrderMapper.Order2Car.Where(o => o.xcp_uucode == code && o.receive_type == stType).First());

                }
                cachePool.SetValue(key, OrderMapper);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Status = 0,
                    Msg = "系统错误：" + ex.Message.ToString()
                });
            }
            return Json(new
            {
                Status = 1,
                Msg = "成功"
            });
        }


        private void UpdateCar(xcp_order2car objectModel, xcp_order2car newModel)
        {
            objectModel.market_id = newModel.market_id;
            objectModel.xcp_uucode = newModel.xcp_uucode;
            objectModel.xcar_name = newModel.xcar_name;
            objectModel.xcar_no = newModel.xcar_no.ToUpper();
            if (newModel.xcar_vin == null)
                newModel.xcar_vin = "";
            objectModel.xcar_vin = newModel.xcar_vin.ToUpper();
            objectModel.receive_type = newModel.receive_type;
            objectModel.dealer_price = newModel.dealer_price;
            objectModel.fee = newModel.fee;
            objectModel.fee_package = newModel.fee_package;
            objectModel.transfer_type = newModel.transfer_type;
            objectModel.transfer_addr = newModel.transfer_addr;
            objectModel.receive_type = newModel.receive_type;
            if (objectModel.receive_type == 1 && objectModel.ID == 0)    //新增时 对于自行送车的车辆  把状态都改为1  【张雷】 设定
            {
                objectModel.status = 1;
            }
            objectModel.carbodycolor = newModel.carbodycolor;
            //objectModel.carbodyoldcolor = newModel.carbodyoldcolor;
            objectModel.peccancyresponsible = newModel.peccancyresponsible;
            objectModel.certificates = newModel.certificates;
            objectModel.Remake = newModel.Remake;
            objectModel.remark = newModel.remark;
            objectModel.LoseProcedures = 1;

        }




        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult Order_Add_Car(xcp_order2car model)
        {
            object result;
            int stType = 0;
            try
            {
                stType = (int)model.receive_type;
                string key = loginUser.UserId.ToString();
                var OrderMapper = cachePool.GetValue(key);
                var items = OrderMapper.Order2Car.ToList();


                if (model.ID != 0)
                {
                    if (items != null && items.Count > 0)
                    {
                        var dbitem = carbll.Get(model.ID);
                        var objectitem = items.Where(o => o.ID == model.ID).First();
                        if (dbitem.status != -1 && dbitem.status != 1)
                        {
                            result = new
                            {
                                Code = -1,
                                Msg = "外检已完成，无法修改车辆信息！"
                            };
                            return Json(result);
                        }
                        UpdateCar(dbitem, model);

                        #region 通知php

                        PHPService ps = new PHPService();
                        xcp_order2car car = dbitem;
                        LocaleCarInfo lcar;
                        lcar = new LocaleCarInfo(dbitem, OrderMapper.Order);
                        //请求php
                        PhpResult res = ps.LocaleOrderUpdateCar(Convert.ToInt32(dbitem.xo2cid), lcar);
                        //if ((int)res.code != 1)
                        //{
                        //    res = ps.LocaleOrderAdd(model, lcars);
                        //}

                        if (res != null && (int)res.code == 2)
                        {
                            if (!carbll.Update(dbitem))
                            {
                                result = new
                                {
                                    Code = -1,
                                    Msg = "数据修改失败，请重试！"
                                };
                                return Json(result);
                            }

                            UpdateCar(objectitem, dbitem);
                            log.WriteLine(string.Format("{0}\r\n  现场下单--修改车辆信息：car phpId：{0},返回结果：{1}，时间：{2}", dbitem.xo2cid, res.message, DateTime.Now.ToString("yyyy-MM-dd mm:hh:ss")));


                        }
                        else
                        {
                            log.WriteLine(string.Format("{0}\r\n  现场下单--修改车辆信息：请求失败: ID={0} , 信息：{1}", dbitem.xo2cid, res.message));
                            result = new
                            {
                                Code = -1,
                                Msg = res.message.ToString()
                            };
                            return Json(result);
                        }


                        #endregion


                    }
                }
                else if (!string.IsNullOrEmpty(model.xcp_uucode))
                {

                    if (items != null && items.Count > 0)
                    {
                        //items.Remove(items.Where(o => o.xcp_uucode == model.xcp_uucode && o.receive_type == stType).First());
                        var objectitem = items.Where(o => o.xcp_uucode == model.xcp_uucode && o.receive_type == stType).First();
                        if (objectitem != null)
                        {
                            UpdateCar(objectitem, model);
                        }
                    }
                    //items.Add(model);
                }
                else
                {
                    model.xcp_uucode = GuidTo16String();
                    //把返回的车辆信息写到cac
                    if (items == null)
                    {
                        items = new List<xcp_order2car>();
                    }
                    items.Insert(0, model);
                }

                var newOrderMapper = new OrderMapperOrder2Car { Order = OrderMapper.Order, Order2Car = items };
                cachePool.SetValue(key, newOrderMapper);
            }
            catch (Exception ex)
            {
                result = new
                {
                    Code = -1,
                    Msg = ex.Message
                };
                return Json(result);
            }

            result = new
            {
                Code = 1,
                Msg = "成功"
            };
            return Json(result);


        }


        public static string GuidTo16String()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
                i *= ((int)b + 1);
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

    }

    public class Field
    {
        public int marketid { get; set; }//	场地id
        public int cityid { get; set; }//场地所在城市ID

        public string marketname { get; set; }		//场地名称

    }

}