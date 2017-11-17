using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Edge.DBUtility;

namespace Edge.SVA.BLL
{
   public partial class Province
   {
       public bool Exists(string ProvinceCode, SqlTransaction trans)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select count(1) from Province");
           strSql.Append(" where ProvinceCode=@ProvinceCode ");
           SqlParameter[] parameters = {
					new SqlParameter("@ProvinceCode", SqlDbType.VarChar,64)			};
           parameters[0].Value = ProvinceCode;

           object id = SqlHelper.NewExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL

           if (Convert.ToInt32(id) > 0)
           {
               return true;
           }
           return false;
       }
       public int Add(Edge.SVA.Model.Province model, SqlTransaction trans)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into Province(");
           strSql.Append("ProvinceCode,CountryCode,ProvinceName1,ProvinceName2,ProvinceName3)");
           strSql.Append(" values (");
           strSql.Append("@ProvinceCode,@CountryCode,@ProvinceName1,@ProvinceName2,@ProvinceName3)");
           SqlParameter[] parameters = {
					new SqlParameter("@ProvinceCode", SqlDbType.VarChar,64),
					new SqlParameter("@CountryCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProvinceName1", SqlDbType.NVarChar,512),
					new SqlParameter("@ProvinceName2", SqlDbType.NVarChar,512),
					new SqlParameter("@ProvinceName3", SqlDbType.NVarChar,512)};
           parameters[0].Value = model.ProvinceCode;
           parameters[1].Value = model.CountryCode;
           parameters[2].Value = model.ProvinceName1;
           parameters[3].Value = model.ProvinceName2;
           parameters[4].Value = model.ProvinceName3;

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
