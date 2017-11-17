using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Edge.DBUtility;

namespace Edge.SVA.BLL
{
   public partial class City
    {
       public bool Exists(string CityCode, SqlTransaction trans)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select count(1) from City");
           strSql.Append(" where CityCode=@CityCode ");
           SqlParameter[] parameters = {
					new SqlParameter("@CityCode", SqlDbType.VarChar,64)			};
           parameters[0].Value = CityCode;

           object id = SqlHelper.NewExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL

           if (Convert.ToInt32(id) > 0)
           {
               return true;
           }
           return false;
       }
       public int Add(Edge.SVA.Model.City model, SqlTransaction trans)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into City(");
           strSql.Append("CityCode,ProvinceCode,CityName1,CityName2,CityName3)");
           strSql.Append(" values (");
           strSql.Append("@CityCode,@ProvinceCode,@CityName1,@CityName2,@CityName3)");
           SqlParameter[] parameters = {
					new SqlParameter("@CityCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProvinceCode", SqlDbType.VarChar,64),
					new SqlParameter("@CityName1", SqlDbType.NVarChar,512),
					new SqlParameter("@CityName2", SqlDbType.NVarChar,512),
					new SqlParameter("@CityName3", SqlDbType.NVarChar,512)};
           parameters[0].Value = model.CityCode;
           parameters[1].Value = model.ProvinceCode;
           parameters[2].Value = model.CityName1;
           parameters[3].Value = model.CityName2;
           parameters[4].Value = model.CityName3;

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
