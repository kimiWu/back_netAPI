using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YXP.API.DataAccess.Bank;

namespace YXP.API.Business.Bank
{
    public class BankBll
    {

        public IEnumerable<string> GetBankName(string bankstr = null)
        {

            BankDal bankDal = new BankDal();
            string sqlstr = " select Bankname from bankdict_bank ";
            if (!string.IsNullOrEmpty(bankstr))
            {
                sqlstr += "where bankname like '%" + bankstr + "%'";
            }
            var banklist = bankDal.Query<string>(" select Bankname from bankdict_bank where bankname like '%" + bankstr + "%'");
            return banklist;


        }

        //BankDal branchDal = new BankDal();
        public IEnumerable<dynamic> GetBranch(string bankname, string branchstr=null)
        {
            BankDal bankDal = new BankDal();
            string sql = @" SELECT TOP 100 aa.bankcode,aa.bankfullname FROM  bankdict_code aa  LEFT JOIN bankdict_bank bb ON bb.bankid=aa.bankid WHERE bb.bankname='" + bankname + "'";
            if (!string.IsNullOrEmpty(branchstr))
            {
                sql += " AND aa.bankfullname LIKE '%" + branchstr + "%'";
            }
            var branchlist = bankDal.Query<dynamic>(sql);
            return branchlist;
        }

        
    }
}
