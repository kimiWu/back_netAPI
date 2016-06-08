using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.Entity.OPFramework;
using YXP.API.Utility;

namespace YXP.API.DataAccess.OPFramework
{
    public partial class AuthorityResourceDAL : BaseDAL<AuthorityResource>
    {

        private static string logPath = System.Configuration.ConfigurationManager.AppSettings["logPath"];
        LogWriter log = new LogWriter(System.Configuration.ConfigurationManager.AppSettings["logPath"].ToString());

        public AuthorityResourceDAL()
         : base("OPFramework")
        {
        }

        public IEnumerable<string> GetList(string ParentCode, int UserID)
        {

            var sqlStr = new StringBuilder();

            sqlStr.AppendLine(" select ar.ResourceCode from RoleUser with(nolock)");
            sqlStr.AppendLine(" inner join RoleResourceMap with(nolock) on RoleUser.RoleId=RoleResourceMap.RoleId and IsActive=1 ");
            sqlStr.AppendLine(" inner join AuthorityResource ar with(nolock) on RoleResourceMap.ResourceId=ar.AuthorResourceId and ar.IsActive=1");
            sqlStr.AppendLine(" where ar.ParentResourceId=(select AuthorResourceId from AuthorityResource where ResourceCode='" + ParentCode + "') and RoleUser.UserId=" + UserID);

            //log.Write("sqlStr：" + sqlStr.ToString());
            try
            {
                var list = Query<string>(sqlStr.ToString());
                return list;
            }
            catch (Exception ex)
            {
                log.Write("GetList发生异常：" + ex.Message);
                return null;
            }
        }
    }



}

