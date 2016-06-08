using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity;
using YXP.API.Entity.KPSales;
using YXP.API.Utility;

namespace YXP.API.DataAccess.KPSales
{
    public class KPSalesDal : BaseDAL<KPSalesListEntity>
    {
        private static string logPath = System.Configuration.ConfigurationManager.AppSettings["logPath"];
        private static string cityLimit = System.Configuration.ConfigurationManager.AppSettings["cityLimit"];
        LogWriter log = new LogWriter(System.Configuration.ConfigurationManager.AppSettings["logPath"].ToString());
        //LogWriter log = new LogWriter(logPath);
        public KPSalesDal()
            : base(ConnEnum.TranstarAuctionConfigPath)
        {

        }

        public IEnumerable<KPSalesListEntity> GetList(string tvaIds, string order, int pageSize, int maxId, int minId, int state, string type, int UserId)
        {
            if (string.IsNullOrEmpty(order))
            {
                order = "AuctionPublishInfo.CreateTime desc,AuctionPublishInfo.PublishId desc";
            }
            var sqlStr = new StringBuilder();

            sqlStr.AppendLine(" select top " + pageSize + " AuctionPublishInfo.CarSourceId,AuctionPublishInfo.TvaId,TranstarVendorAccount.VendorFullName,TranstarAuctionCarSource.LeftFront45,AuctionPublishInfo.PublishId,TranstarAuctionCarSource.seriesname,TranstarAuctionCarSource.modelname,TranstarAuctionCarSource.EngineNum,TranstarAuctionCarSource.LicenseNumber,AuctionPublishInfo.StopTime as StopTime,AuctionPublishInfo.AuctionStatus,AuctionPublishInfo.PriceStatus,AuctionPublishInfo.CreateTime,TranstarAuctionCarSource.CityId,City.city_Name cityName,TranstarAuctionCarSource.brandname");
            sqlStr.AppendLine(" ,AuctionPublishInfo.pricestoptime,AuctionPublishInfo.PublishSerial from dbo.AuctionPublishInfo with(nolock) ");
            sqlStr.AppendLine(" left join dbo.TranstarAuctionCarSource with(nolock) on TranstarAuctionCarSource.CarSourceId = AuctionPublishInfo.CarSourceID");
            sqlStr.AppendLine(" left join dbo.TranstarVendorAccount with(nolock) on TranstarVendorAccount.TvaID = AuctionPublishInfo.TvaId");
            sqlStr.AppendLine(" left join dbo.City with(nolock) on City.city_Id=TranstarAuctionCarSource.CityId");
            if (state != 2)
            {
                sqlStr.AppendLine(" left join dbo.UserPublishId with(nolock) on AuctionPublishInfo.PublishId=UserPublishId.PublishId");
            }
            sqlStr.AppendLine(" where 1=1 ");
            sqlStr.Append(" and AuctionPublishInfo.DateType=3 and AuctionPublishInfo.AuctionType!=3 and AuctionPublishInfo.CreateTime>'2016-04-25 22:00:00'"); //快拍车辆
            if (!string.IsNullOrEmpty(type))
            {
                //if (type == "down" && maxId != 0)
                //{
                //    sqlStr.Append("and AuctionPublishInfo.PublishId>" + maxId);
                //}
                if (type == "up" && minId != 0)
                {
                    sqlStr.Append("and AuctionPublishInfo.PublishId<" + minId);
                }
            }
            sqlStr.Append(GetCondition(tvaIds, state, UserId));
            sqlStr.AppendLine(" order by " + order);
            //log.Write("sqlStr：" + sqlStr.ToString());
            try
            {
                var list = Query<KPSalesListEntity>(sqlStr.ToString());
                return list;
            }
            catch (Exception ex)
            {
                log.Write("GetList发生异常：" + ex.Message);
                return null;
            }
        }

        public int GetCount(string tvaIds, int state,int UserId)
        {
            var sqlStr = new StringBuilder();
            sqlStr.AppendLine(" select count(0) as totalCount");
            sqlStr.AppendLine(" from dbo.AuctionPublishInfo with(nolock) ");
            sqlStr.AppendLine(" left join dbo.TranstarAuctionCarSource with(nolock) on TranstarAuctionCarSource.CarSourceId = AuctionPublishInfo.CarSourceID"); ;
            sqlStr.AppendLine(" where 1=1 ");
            sqlStr.Append(GetCondition(tvaIds, state,UserId));
            try
            {
                return Count(sqlStr.ToString());
            }
            catch (Exception ex)
            {
                log.Write("GetCount发生异常：" + ex.Message);
                return 0;
            }
        }

        private string GetCondition(string tvaIds, int state, int UserId)
        {
            var str = new StringBuilder();

            if (state == 1)  //等待成交
            {
                if (!string.IsNullOrEmpty(tvaIds))
                {
                    str.Append(" and (( AuctionPublishInfo.TvaId in (" + tvaIds + ") and UserPublishId.UserId is null ) or UserPublishId.UserId=" + UserId + ")");
                }
                else
                {
                    str.Append(" and  UserPublishId.UserId=" + UserId);
                }
                str.Append(" and (AuctionPublishInfo.AuctionStatus=1 and AuctionPublishInfo.PriceStatus=2)");
            }
            else if (state == 2)  //正在投标
            {
                if (!string.IsNullOrEmpty(tvaIds))
                {
                    str.Append(" and AuctionPublishInfo.TvaId in (" + tvaIds + ")");
                }
                
                str.Append(" and (AuctionPublishInfo.AuctionStatus=1 and AuctionPublishInfo.TenderCount in (0,-1) and AuctionPublishInfo.PriceStatus!=2)");
            }
            else if (state == 3)//成交
            {

                str.Append(" and  UserPublishId.UserId=" + UserId);

                str.Append(" and (AuctionPublishInfo.AuctionStatus in (3,4,5))");
            }
            else if (state == 4)//流拍
            {
                str.Append(" and  UserPublishId.UserId=" + UserId);

                str.Append(" and (AuctionPublishInfo.AuctionStatus=2)");
            }
            if (state != 2)  //考虑换账号的情况
            {
                //str.Append(" and AuctionPublishInfo.CarSourceId in (select CarSourceId from AuctionVirtualBidRecordLog where 1=1 and BidderTvaId in (" + tvaIds + "))");
            }
            if (cityLimit != "-1")
            {
                str.Append(" and TranstarVendorAccount.CityId in (" + cityLimit + ")");
            }
            return str.ToString();
        }
        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public KPSalesListEntity GetModel(int id)
        {
            var sqlStr = new StringBuilder();
            sqlStr.AppendLine(" select AuctionPublishInfo.CarSourceId,AuctionPublishInfo.TvaId,TranstarVendorAccount.VendorFullName,TranstarAuctionCarSource.LeftFront45,AuctionPublishInfo.PublishId,TranstarAuctionCarSource.seriesname,TranstarAuctionCarSource.modelname,TranstarAuctionCarSource.LicenseNumber,AuctionPublishInfo.StopTime as StopTime,AuctionPublishInfo.AuctionStatus,AuctionPublishInfo.PriceStatus,AuctionPublishInfo.CreateTime,TranstarAuctionCarSource.CityId,City.city_Name cityName,AuctionVirtualBidRecord.ModifyPrice,AuctionVirtualBidRecord.SWFee,AuctionVirtualBidRecord.CurrSalesPrice,AuctionVirtualBidRecord.UserId,AuctionTstOrder.SellerFee,AuctionVirtualBidRecord.BidderTvaId");
            sqlStr.AppendLine(" ,AuctionPublishInfo.pricestoptime,TranstarAuctionCarSource.EngineNum,AuctionPublishInfo.PublishSerial,AuctionTstOrder.DraftTime,TranstarAuctionCarSource.brandname,AuctionVirtualBidRecord.InvestFee from dbo.AuctionPublishInfo with(nolock) ");
            sqlStr.AppendLine(" left join dbo.TranstarAuctionCarSource with(nolock) on TranstarAuctionCarSource.CarSourceId = AuctionPublishInfo.CarSourceID");
            sqlStr.AppendLine(" left join dbo.TranstarVendorAccount with(nolock) on TranstarVendorAccount.TvaID = AuctionPublishInfo.TvaId");
            sqlStr.AppendLine(" left join dbo.AuctionVirtualBidRecord with(nolock) on AuctionVirtualBidRecord.PublishId = AuctionPublishInfo.PublishId");
            sqlStr.AppendLine(" left join dbo.AuctionTstOrder with(nolock) on AuctionTstOrder.PublishId = AuctionPublishInfo.PublishId");
            sqlStr.AppendLine(" left join dbo.City with(nolock) on City.city_Id=TranstarAuctionCarSource.CityId");
            sqlStr.AppendLine(" where AuctionPublishInfo.PublishId=" + id);
            try
            {
                return Query<KPSalesListEntity>(sqlStr.ToString()).First();
            }
            catch (Exception ex)
            {
                log.Write("GetModel发生异常：" + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="publishId"></param>
        /// <param name="auctionStatus"></param>
        /// <returns></returns>
        public dynamic VirtualBidRecordResult(int publishId, int auctionStatus)
        {
            DynamicParameters paras = new DynamicParameters();
            try
            {
                paras.Add("@PublishId", publishId);
                paras.Add("@AuctionStatus", auctionStatus);
                var entity = Execute<int>("VirtualBidRecordResultTX", paras);
                return entity[0];
            }
            catch (Exception ex)
            {
                log.Write("VirtualBidRecordResult发生异常：" + ex.Message);
                throw;
            }
        }


        public dynamic ApplyInvest(long PublishID, decimal CurrSalesPrice, decimal SWFee, int UserID,decimal CompetitorPrice,decimal InvestMaxFee,int Sgn)
        {
            DynamicParameters paras = new DynamicParameters();
            paras.Add("@PublishId", PublishID);
            paras.Add("@CurrSalesPrice", CurrSalesPrice);
            paras.Add("@SWFee", SWFee);
            paras.Add("@CompetitorPrice", CompetitorPrice);
            paras.Add("@InvestMaxFee", InvestMaxFee);
            paras.Add("@UserId", UserID);
            paras.Add("@Sgn", Sgn);
            //paras.Add("@res", ParameterDirection.Output);
            var entity = Execute<Test>("VirtualInvestAdd", paras);
            var Msg = "";
            if (Sgn == 0)
            {
                Msg = "申请投资";
            }
            else
            {
                Msg = "取消申请投资";
            }
            log.WriteLine(string.Format("{4}  --{6}--拍品号PublishID:{0},销售报价CurrSalesPrice:{1},商务费SWFee:{2},销售账号UserID:{3},对手报价CompetitorPrice:{7},申请额度InvestMaxFee:{8}  --返回结果--  {5}", PublishID, CurrSalesPrice, SWFee, UserID, DateTime.Now, YXP.API.Utility.Common.Serialize(entity),Msg,CompetitorPrice,InvestMaxFee));
            return entity;
        }

        //public dynamic ExecVirtualBid(int publishId, int auctionStatus)
        //{
        //    DynamicParameters paras = new DynamicParameters();
        //    paras.Add("@PublishId", publishId);
        //    paras.Add("@AuctionStatus", auctionStatus);
        //    var entity = Execute<int>("VirtualBidRecordResultTX", paras, 1);
        //    return entity[0];
        //}
    }

    public class Test
    {
        public int suc { get; set; }
    }
}
