using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Edge.DBUtility;

namespace Edge.SVA.BLL
{
   public partial class BUY_RPRICE_D
    {
       public bool Delete(string RPriceCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from BUY_RPRICE_D ");
           strSql.Append(" where RPriceCode=@RPriceCode");
           SqlParameter[] parameters = {
					new SqlParameter("@RPriceCode", SqlDbType.VarChar)
			};
           parameters[0].Value = RPriceCode;

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
       //public bool DeleteStr(string strWhere)
       //{
       //    StringBuilder strSql = new StringBuilder();
       //    strSql.Append("delete from BUY_RPRICE_D ");
       //    if (!string.IsNullOrEmpty(strWhere))
       //    {
       //        strSql.AppendFormat(" where {0}", strWhere);
       //    }
       //    int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
       //    if (rows > 0)
       //    {
       //        return true;
       //    }
       //    else
       //    {
       //        return false;
       //    }
       //}
    }
}
