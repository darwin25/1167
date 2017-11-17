using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Edge.DBUtility;

namespace Edge.SVA.BLL
{
   public partial class BUY_CPRICE_M
    {
       public bool Delete(string ProdCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from BUY_CPRICE_M ");
           strSql.Append(" where ProdCode=@ProdCode");
           SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar)
			};
           parameters[0].Value = ProdCode;

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
