using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Edge.DBUtility;

namespace Edge.SVA.BLL
{
   public partial class BUY_MNM_D
    {
       public bool DeleteData(string MNMCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from BUY_MNM_D ");
           strSql.Append(" where MNMCode=@MNMCode");
           SqlParameter[] parameters = {
					new SqlParameter("@MNMCode", SqlDbType.VarChar,64)
			};
           parameters[0].Value = MNMCode;

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
