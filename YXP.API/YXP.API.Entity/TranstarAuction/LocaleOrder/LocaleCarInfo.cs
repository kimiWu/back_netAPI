using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YXP.API.Entity.TranstarAuction;

namespace YXP.API.Entity.LocaleOrder
{

    /// <summary>
    /// 现场下单 车辆信息
    /// </summary>
    public class LocaleCarInfo
    {
        /// <summary>
        ///提车方式[1自送2代送]
        /// </summary>
        public int receive_type { get; set; }

        /// <summary>
        /// 车辆vin码
        /// </summary>
        public string vin { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string no { get; set; }

        /// <summary>
        /// 是否带牌销售[1是0否]
        /// </summary>
        public int license_no { get; set; }
        /// <summary>
        /// 车身颜色
        /// </summary>
        public string color { get; set; }
        /// <summary>
        /// 车身原色
        /// </summary>
        public string original_color { get; set; }

        /// <summary>
        /// 车辆名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 整备费
        /// </summary>
        public float fee { get; set; }

        /// <summary>
        /// 装备费套餐[0:无 1:A套餐 2:B套餐 3:A+B]
        /// </summary>
        //public int fee_package { get; set; }

        /// <summary>
        /// 收购价（万元）
        /// </summary>
        public float purchase_price { get; set; }

        /// <summary>
        /// 代理拍卖服务费
        /// </summary>
        public float agent_fee { get; set; }

        /// <summary>
        /// 保留价
        /// </summary>
        public float dealer_price { get; set; }
        /// <summary>
        /// 过户类型[1本户2外地3无要求]
        /// </summary>
        public int transfer_type { get; set; }

        /// <summary>
        /// 车辆加装、改装、影响正常过户[1卖方责任2买方]
        /// </summary>
        public int blame { get; set; }

        /// <summary>
        /// 违章责任方[0卖1买]
        /// </summary>
        public int law_less_blame { get; set; }

        /// <summary>
        /// 过户市场
        /// </summary>
        public int transfer_marketid { get; set; }

        /// <summary>
        /// 预计到达时间
        /// </summary>
        public string predict_time { get; set; }

        /// <summary>
        /// 参拍场次时间
        /// </summary>
        public string scene_time { get; set; }

        /// <summary>
        /// 丢失的手续责任方[1卖2买]
        /// </summary>
        public int formalities_blame { get; set; }

        /// <summary>
        /// 发牌场地ID
        /// </summary>
        public int market_id { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 价格联系人
        /// </summary>
        public string price_user { get; set; }

        /// <summary>
        /// 价格联系人手机
        /// </summary>
        public string price_user_mobile { get; set; }


        /// <summary>
        /// 提车地址
        /// </summary>
        public string address { get; set; }


        /// <summary>
        /// 证件手续[1,随车提交，2,提车后1日，3,提车后两日] 
        /// </summary>
        public int formalities_with { get; set; }

        /// <summary>
        /// 违章责任方X日内处理完毕 
        /// </summary>
        public int law_less_blame_day { get; set; }

        /// <summary>
        /// 联系人 
        /// </summary>
        public string dealer_user { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string dealer_mobile { get; set; }


        /// <summary>
        /// 是否分账
        /// </summary>
        public int is_ledger { get; set; }

        /// <summary>
        /// 总保留价
        /// </summary>
        public float dealer_price_total { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="carInfo"></param>
        /// <param name="market_id">发拍场地</param>
        public LocaleCarInfo(xcp_order2car carInfo, xcp_order model)
        {
            //int market_id, string price_User, string price_User_Mobile, string dealer_Address,string dealer_user,string dealer_mobile
            //model.market_id, model.price_user, model.price_user_mobile, model.dealer_addr, model.fetch_user, model.fetch_user_mobile
            this.receive_type = Convert.ToInt32(carInfo.receive_type);
            this.vin = carInfo.xcar_vin;
            this.no = carInfo.xcar_no;
            this.license_no = 0;
            this.color = string.IsNullOrWhiteSpace(carInfo.carbodycolor) ? "" : carInfo.carbodycolor + "色";
            this.original_color = string.IsNullOrWhiteSpace(carInfo.carbodyoldcolor) ? "" : carInfo.carbodyoldcolor + "色";
            this.name = carInfo.xcar_name;
            this.fee = Convert.ToSingle(carInfo.fee);
            // this.fee_package = (int)carInfo.fee_package;
            this.dealer_price = Convert.ToSingle(carInfo.dealer_price);
            this.purchase_price = Convert.ToSingle(carInfo.purchase_price);
            this.agent_fee = Convert.ToInt32(carInfo.ProxyFee);
            this.transfer_type = Convert.ToInt32(carInfo.transfer_type);
            this.blame = Convert.ToInt32(carInfo.Remake);
            this.law_less_blame = carInfo.peccancyresponsible == 1 ? 0 : 1;
            this.transfer_marketid = Convert.ToInt32(carInfo.market_id); //过户场地id
            this.market_id = Convert.ToInt32(model.market_id);//发拍场地id 
            this.predict_time = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");//carInfo.predict_market_time.Value.ToString("yyyy-MM-dd");
            this.scene_time = carInfo.scene_time;
            this.formalities_blame = Convert.ToInt32(carInfo.LoseProcedures);
            this.dealer_user = model.fetch_user;// 联系人 
            this.dealer_mobile = model.fetch_user_mobile;//联系方式

            this.remark = carInfo.remark;
            this.price_user = model.price_user;
            this.price_user_mobile = model.price_user_mobile;
            this.address = model.dealer_addr;

            this.is_ledger = Convert.ToInt32(model.isPayProxy);
            this.dealer_price_total = Convert.ToSingle(carInfo.total_Price);

            this.formalities_with = Convert.ToInt32(carInfo.certificates);
            this.law_less_blame_day = Convert.ToInt32(carInfo.peccancyresponsibleDay);
        }
    }


    public class Field
    {
        public int marketid { get; set; }//	场地id
        public int cityid { get; set; }//场地所在城市ID

        public string marketname { get; set; }		//场地名称

    }



    public class OrderCreateResult
    {
        /// <summary>
        /// 现场拍委托单id  
        /// </summary>
        public int xoid { get; set; }

        /// <summary>
        /// 现场拍车源ID，与下单时传入的carlist一一对应
        /// </summary>
        public List<int> xo2cid { get; set; }

    }

}
