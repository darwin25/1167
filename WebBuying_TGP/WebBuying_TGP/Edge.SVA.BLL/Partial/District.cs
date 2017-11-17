using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Edge.DBUtility;

namespace Edge.SVA.BLL
{
   public partial class District
   {
       public bool Exists(string DistrictCode, SqlTransaction trans)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select count(1) from District");
           strSql.Append(" where DistrictCode=@DistrictCode ");
           SqlParameter[] parameters = {
					new SqlParameter("@DistrictCode", SqlDbType.VarChar,64)			};
           parameters[0].Value = DistrictCode;

           object id = SqlHelper.NewExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL

           if (Convert.ToInt32(id) > 0)
           {
               return true;
           }
           return false;
       }

       public int Add(Edge.SVA.Model.District model, SqlTransaction trans)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into District(");
           strSql.Append("DistrictCode,CityCode,DistrictName1,DistrictName2,DistrictName3)");
           strSql.Append(" values (");
           strSql.Append("@DistrictCode,@CityCode,@DistrictName1,@DistrictName2,@DistrictName3)");
           SqlParameter[] parameters = {
					new SqlParameter("@DistrictCode", SqlDbType.VarChar,64),
					new SqlParameter("@CityCode", SqlDbType.VarChar,64),
					new SqlParameter("@DistrictName1", SqlDbType.NVarChar,512),
					new SqlParameter("@DistrictName2", SqlDbType.NVarChar,512),
					new SqlParameter("@DistrictName3", SqlDbType.NVarChar,512)};
           parameters[0].Value = model.DistrictCode;
           parameters[1].Value = model.CityCode;
           parameters[2].Value = model.DistrictName1;
           parameters[3].Value = model.DistrictName2;
           parameters[4].Value = model.DistrictName3;

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
