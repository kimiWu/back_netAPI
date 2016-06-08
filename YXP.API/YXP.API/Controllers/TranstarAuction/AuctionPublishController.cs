using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YXP.API.Business;
using YXP.API.Entity;
using YXP.API.Entity.TranstarAuction;
using YXP.API.Utility;

namespace YXP.API.Controllers.TranstarAuction
{
    public class AuctionPublishController : ApiController
    {
        AuctionPublishBLL bll = new AuctionPublishBLL();

        /// <summary>
        /// 修改拍品无底价
        /// </summary>
        /// <param name="publishId">拍品ID</param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiResultModel UpdateReservePrice(int publishid)
        {
            ApiResultModel arm = new ApiResultModel();
            AuctionPublishInfo model = new AuctionPublishInfo();
            try
            {
                model = bll.Get(publishid);
                if (model != null)
                {
                    model.StartPrice = 0;
                    model.ReservationPrice = 0;
                    model.ReservationPriceForBuyer = 0;
                    if (bll.Update(model))
                    {
                        arm.Code = 1;
                        arm.Data = true;
                        arm.Message = "更新成功";
                    }
                    else
                    {
                        arm.Code = 0;
                        arm.Data = false;
                        arm.Message = "更新失败";
                    }
                }
                else
                {
                    arm.Code = 0;
                    arm.Data = false;
                    arm.Message = "拍品不存在";
                }
            }
            catch (Exception ex)
            {
                arm.Code = -1;
                arm.Data = false;
                arm.Message = ex.Message;
            }
            return arm;
        }
    }
}
