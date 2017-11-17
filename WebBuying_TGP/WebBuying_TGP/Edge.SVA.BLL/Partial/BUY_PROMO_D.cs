using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Edge.DBUtility;

namespace Edge.SVA.BLL
{
   public partial class BUY_PROMO_D
    {
       public bool Delete(string PromotionCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from BUY_PROMO_D ");
           strSql.Append(" where PromotionCode=@PromotionCode");
           SqlParameter[] parameters = {
					new SqlParameter("@PromotionCode", SqlDbType.VarChar)
			};
           parameters[0].Value = PromotionCode;

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
