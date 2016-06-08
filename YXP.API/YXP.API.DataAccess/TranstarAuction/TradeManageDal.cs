using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.TranstarAuction;
using YXP.API.Utility;

namespace YXP.API.DataAccess.TranstarAuction
{
    public class TradeManageDal : BaseDAL<VCarTradeList>
    {
        private static string logPath = System.Configuration.ConfigurationManager.AppSettings["logPath"];
        LogWriter log = new LogWriter(System.Configuration.ConfigurationManager.AppSettings["logPath"].ToString());
        public TradeManageDal()
            : base(ConnEnum.TranstarAuctionConfigPath)
        {

        }
        public TradeManageEntity GetList(string where, string orderBy, int pageSize, int currPage)
        {
            var item = new TradeManageEntity();
            var sql = new StringBuilder();
            try
            {
                sql.AppendLine(" select count(0) as count ");
                sql.AppendLine(" from  AuctionPublishInfo t1 left join TranstarAuctionCarSource t2 on t1.CarSourceId=t2.CarSourceId left join AuctionTstOrder t3 on t1.PublishId=t3.PublishID");
                if (!string.IsNullOrEmpty(where))
                {
                    sql.AppendLine(" where " + where);
                }
                sql.AppendLine(" and  t2.CarStatus = 6 AND t1.AuditStatus=1 AND  t1.IsActive=1");
                sql.AppendLine(" AND (t1.TvaID NOT IN( ");
                sql.AppendLine(" SELECT     Tvaid FROM dbo.TestAccountInfo   ");
                sql.AppendLine(" UNION   all ");
                sql.AppendLine(" SELECT   tva.TvaID  ");
                sql.AppendLine(" FROM     dbo.TranstarVendorAccount tva  ");
                sql.AppendLine(" LEFT JOIN dbo.TranstarVendorConfig tvc ON tva.TvaID = tvc.TvaID  ");
                sql.AppendLine(" WHERE    tva.CityID IN ( 201, 2501, 2401, 2601, 501,502,1201,3001 ) --北京，成都，上海，天津，广州 ");
                sql.AppendLine(" AND AccountType = 2 ");
                sql.AppendLine(" AND tvc.ConfigKey ='AuctionDisableSet' ");
                sql.AppendLine(" AND tvc.ConfigValue = 0  ");
                sql.AppendLine(" )) ");
                var totalCount = Count(sql.ToString());
                if (totalCount > 0)
                {
                    sql = new StringBuilder();
                    sql.AppendLine(" select t1.PublishId as publishId,t2.CarSourceId as carSourceId, ");
                    sql.AppendLine(" t3.DraftTime as draftTime,t4.city_Name as cityName,t2.brandname as masterBrandName,t2.seriesname as carTypeName,");
                    sql.AppendLine(" t2.modelname as brandName,t2.brandname+' '+t2.seriesname+' '+t2.modelname as carName,t2.ConditionGrade as conditionGrade,t2.CarBodyColor as carBodyColor,t3.BuyerFee as dealPrice,t2.GetLicenseDate as licenseDate,");
                    sql.AppendLine(" t2.Mileage as mileage,");
                    sql.AppendLine(" case t2.Transmission when 1 then '手动' when 2 then '自动' when 3 then '手自一体' when 4 then '无极变速' when 5 then '双离合' else '' end as transmission,");
                    sql.AppendLine(" case t2.CarUseType when 0 then '非营运' when 1 then '营运' when 2 then '营转非' when 3 then '租赁' when 4 then '租赁公司非营运' else '' end as carUseType");
                    sql.AppendLine(" from  AuctionPublishInfo t1 left join TranstarAuctionCarSource t2 on t1.CarSourceId=t2.CarSourceId left join AuctionTstOrder t3 on t1.PublishId=t3.PublishID");
                    sql.AppendLine(" left join City t4 on t2.CityId=t4.city_Id");
                    if (!string.IsNullOrEmpty(where))
                    {
                        sql.AppendLine(" where " + where);
                    }
                    sql.AppendLine(" and  t2.CarStatus = 6 AND t1.AuditStatus=1 AND  t1.IsActive=1");
                    sql.AppendLine(" AND (t1.TvaID NOT IN( ");
                    sql.AppendLine(" SELECT     Tvaid FROM dbo.TestAccountInfo   ");
                    sql.AppendLine(" UNION   all ");
                    sql.AppendLine(" SELECT   tva.TvaID  ");
                    sql.AppendLine(" FROM     dbo.TranstarVendorAccount tva  ");
                    sql.AppendLine(" LEFT JOIN dbo.TranstarVendorConfig tvc ON tva.TvaID = tvc.TvaID  ");
                    sql.AppendLine(" WHERE    tva.CityID IN ( 201, 2501, 2401, 2601, 501,502,1201,3001 ) --北京，成都，上海，天津，广州 ");
                    sql.AppendLine(" AND AccountType = 2 ");
                    sql.AppendLine(" AND tvc.ConfigKey ='AuctionDisableSet' ");
                    sql.AppendLine(" AND tvc.ConfigValue = 0  ");
                    sql.AppendLine(" )) ");
                    var list = Query<VCarTradeList>(sql.ToString(), orderBy, currPage, pageSize);
                    item.totalCount = totalCount;
                    item.totalPage = (totalCount + pageSize - 1) / pageSize;
                    item.children = list as List<VCarTradeList>;
                }

            }
            catch (Exception ex)
            {
                item = null;
                log.Write("TradeManageDal-GetList发生异常：" + ex.Message);
            }
            return item;
        }
    }
}
