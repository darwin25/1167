using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Edge.DBUtility;

namespace Edge.SVA.BLL
{
   public partial class BUY_CPRICE_D
    {
       public bool Delete(string CPriceCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from BUY_CPRICE_D ");
           strSql.Append(" where CPriceCode=@CPriceCode");
           SqlParameter[] parameters = {
					new SqlParameter("@CPriceCode", SqlDbType.VarChar)
			};
           parameters[0].Value = CPriceCode;

           int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
           if (rows > 0)
           {
               return true;
           }
           else
           {
               return false;
           }
       }
    }
}
