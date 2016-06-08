using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.DataAccess.TranstarAuction;
using YXP.API.Entity;

namespace YXP.API.Business.TranstarAuction
{
    public class ChaKeCarSyncToYxpLogBLL
    {
        public IEnumerable<dynamic> InsertTaskId(int taskId)
        {
            ChaKeCarSyncToYxpLogDAL dal = new ChaKeCarSyncToYxpLogDAL();
            string sql = @"SELECT COUNT(taskId) FROM ChaKeCarSyncToYxp WHERE taskId=" + taskId;

            if (dal.Count(sql) == 0)
            {
                sql = string.Format("INSERT INTO ChaKeCarSyncToYxp(taskId,carSourceID,syncStatus,createTime)VALUES({0},0,1,'{1}')", taskId, DateTime.Now);
            }
            else
            {
                sql = string.Format("UPDATE ChaKeCarSyncToYxp SET syncStatus=2 WHERE taskId={0};", taskId);
            }
            IEnumerable<dynamic> result = dal.Query(sql);
            return result;
        }
    }
}
