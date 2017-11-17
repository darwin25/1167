using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Edge.DBUtility;

namespace Edge.SVA.BLL.Domain.BasicInformationSetting.Advertisements
{
   public class PromotionMsgType
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
       public void Add(Edge.SVA.Model.PromotionMsgType model, SqlTransaction trans)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into PromotionMsgType(");
           strSql.Append("BrandID,PromotionMsgTypeName1,PromotionMsgTypeName2,PromotionMsgTypeName3,ParentID)");
           strSql.Append(" values (");
           strSql.Append("@BrandID,@PromotionMsgTypeName1,@PromotionMsgTypeName2,@PromotionMsgTypeName3,@ParentID)");
           strSql.Append(";select @@IDENTITY");
           SqlParameter[] parameters = {
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@PromotionMsgTypeName1", SqlDbType.NVarChar,512),
					new SqlParameter("@PromotionMsgTypeName2", SqlDbType.NVarChar,512),
					new SqlParameter("@PromotionMsgTypeName3", SqlDbType.NVarChar,512),
					new SqlParameter("@ParentID", SqlDbType.Int,4)};
           parameters[0].Value = model.BrandID;
           parameters[1].Value = model.PromotionMsgTypeName1;
           parameters[2].Value = model.PromotionMsgTypeName2;
           parameters[3].Value = model.PromotionMsgTypeName3;
           parameters[4].Value = model.ParentID;

           //将空值赋值为默认值
           foreach (SqlParameter parameter in parameters)
           {
               if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                   (parameter.Value == null))
               {
                   parameter.Value = DBNull.Value;
               }
           }

           SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL
       }
        /// <summary>
        /// 更新一条数据
        /// </summary>
       public void Update(Edge.SVA.Model.PromotionMsgType model, SqlTransaction trans)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update PromotionMsgType set ");
           strSql.Append("BrandID=@BrandID,");
           strSql.Append("PromotionMsgTypeName1=@PromotionMsgTypeName1,");
           strSql.Append("PromotionMsgTypeName2=@PromotionMsgTypeName2,");
           strSql.Append("PromotionMsgTypeName3=@PromotionMsgTypeName3,");
           strSql.Append("ParentID=@ParentID");
           strSql.Append(" where PromotionMsgTypeID=@PromotionMsgTypeID");
           SqlParameter[] parameters = {
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@PromotionMsgTypeName1", SqlDbType.NVarChar,512),
					new SqlParameter("@PromotionMsgTypeName2", SqlDbType.NVarChar,512),
					new SqlParameter("@PromotionMsgTypeName3", SqlDbType.NVarChar,512),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@PromotionMsgTypeID", SqlDbType.Int,4)};
           parameters[0].Value = model.BrandID;
           parameters[1].Value = model.PromotionMsgTypeName1;
           parameters[2].Value = model.PromotionMsgTypeName2;
           parameters[3].Value = model.PromotionMsgTypeName3;
           parameters[4].Value = model.ParentID;
           parameters[5].Value = model.PromotionMsgTypeID;

           //将空值赋值为默认值
           foreach (SqlParameter parameter in parameters)
           {
               if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                   (parameter.Value == null))
               {
                   parameter.Value = DBNull.Value;
               }
           }

           SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL
       }

        /// <summary>
        /// 删除一条数据
        /// </summary>
       public void Delete(int PromotionMsgTypeID, SqlTransaction trans)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from PromotionMsgType ");
           strSql.Append(" where PromotionMsgTypeID=@PromotionMsgTypeID");
           SqlParameter[] parameters = {
					new SqlParameter("@PromotionMsgTypeID", SqlDbType.Int,4)
			};
           parameters[0].Value = PromotionMsgTypeID;

           //将空值赋值为默认值
           foreach (SqlParameter parameter in parameters)
           {
               if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                   (parameter.Value == null))
               {
                   parameter.Value = DBNull.Value;
               }
           }

           SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL
       }
    }
}
