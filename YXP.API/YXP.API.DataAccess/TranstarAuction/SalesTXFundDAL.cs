using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.TranstarAuction;
using YXP.API.Utility;

namespace YXP.API.DataAccess.TranstarAuction
{
	public partial class SalesTXFundDAL : BaseDAL<SalesTXFund>
	{
        private static string logPath = System.Configuration.ConfigurationManager.AppSettings["logPath"];
        LogWriter log = new LogWriter(logPath);

        public SalesTXFundDAL()
		 : base(ConnEnum.TranstarAuctionConfigPath)
		{

		}
        public dynamic Commit(long PublishID, decimal CurrSalesPrice, decimal SWFee, int UserID)
        {
            DynamicParameters paras = new DynamicParameters();
            paras.Add("@PublishId", PublishID);
            paras.Add("@CurrSalesPrice", CurrSalesPrice);
            paras.Add("@SWFee", SWFee);
            paras.Add("@UserId", UserID);
            //paras.Add("@res", ParameterDirection.Output);
            var entity = Execute<Test>("VirtualBidRecordUpdate", paras);
            log.WriteLine(string.Format("{4}  --提交报价参数--拍品号PublishID:{0},销售报价CurrSalesPrice:{1},商务费SWFee:{2},销售账号UserID:{3}  --返回结果--  {5}",PublishID,CurrSalesPrice,SWFee,UserID,DateTime.Now, YXP.API.Utility.Common.Serialize(entity)));
            return entity;
        }

    }
    public class Test
    {
        public int suc { get; set; }
    }
}

