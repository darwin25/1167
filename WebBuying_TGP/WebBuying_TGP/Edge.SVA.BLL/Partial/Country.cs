using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Edge.DBUtility;
using System.Data;

namespace Edge.SVA.BLL
{
   public partial class Country
    {
       public bool Exists(string CountryCode,SqlTransaction trans)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select count(1) from Country");
           strSql.Append(" where CountryCode=@CountryCode ");
           SqlParameter[] parameters = {
					new SqlParameter("@CountryCode", SqlDbType.VarChar,64)			};
           parameters[0].Value = CountryCode;

           object id = SqlHelper.NewExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL

           if (Convert.ToInt32(id) > 0)
           {
               return true;
           }
           return false;
       }

       public int Add(Edge.SVA.Model.Country model, SqlTransaction trans)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into Country(");
           strSql.Append("CountryCode,CountryName1,CountryName2,CountryName3)");
           strSql.Append(" values (");
           strSql.Append("@CountryCode,@CountryName1,@CountryName2,@CountryName3)");
           SqlParameter[] parameters = {
					new SqlParameter("@CountryCode", SqlDbType.VarChar,64),
					new SqlParameter("@CountryName1", SqlDbType.NVarChar,512),
					new SqlParameter("@CountryName2", SqlDbType.NVarChar,512),
					new SqlParameter("@CountryName3", SqlDbType.NVarChar,512)};
           parameters[0].Value = model.CountryCode;
           parameters[1].Value = model.CountryName1;
           parameters[2].Value = model.CountryName2;
           parameters[3].Value = model.CountryName3;

           //将空值赋值为默认值
           foreach (SqlParameter parameter in parameters)
           {
               if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                   (parameter.Value == null))
               {
                   parameter.Value = DBNull.Value;
               }
           }

           //添加主表时需要返回主键ID
           object id = SqlHelper.NewExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL

           return Convert.ToInt32(id);
       }
    }
}
