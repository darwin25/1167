using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Edge.DBUtility;

namespace Edge.SVA.BLL.Domain.BasicInformationSetting.Advertisements
{
   public class PromotionCardCondition
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
       public void Add(Edge.SVA.Model.PromotionCardCondition model, SqlTransaction trans)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into PromotionCardCondition(");
           strSql.Append("PromotionMsgID,CardGradeID)");
           strSql.Append(" values (");
           strSql.Append("@PromotionMsgID,@CardGradeID)");
           SqlParameter[] parameters = {
					new SqlParameter("@PromotionMsgID", SqlDbType.Int,4),
					new SqlParameter("@CardGradeID", SqlDbType.Int,4)};
           parameters[0].Value = model.PromotionMsgID;
           parameters[1].Value = model.CardGradeID;

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
       public void Update(Edge.SVA.Model.PromotionCardCondition model, SqlTransaction trans)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update PromotionCardCondition set ");

           strSql.Append("PromotionMsgID=@PromotionMsgID,");
           strSql.Append("CardGradeID=@CardGradeID");
           strSql.Append(" where PromotionMsgID=@PromotionMsgID and CardGradeID=@CardGradeID ");
           SqlParameter[] parameters = {
					new SqlParameter("@PromotionMsgID", SqlDbType.Int,4),
					new SqlParameter("@CardGradeID", SqlDbType.Int,4)};
           parameters[0].Value = model.PromotionMsgID;
           parameters[1].Value = model.CardGradeID;

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
       public void Delete(int PromotionMsgID, int CardGradeID, SqlTransaction trans)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from PromotionCardCondition ");
           SqlParameter[] parameters = {
					new SqlParameter("@PromotionMsgID", SqlDbType.Int,4),
					new SqlParameter("@CardGradeID", SqlDbType.Int,4)			};
           if (CardGradeID == 0)
           {
               strSql.Append(" where PromotionMsgID=@PromotionMsgID ");
               parameters[0].Value = PromotionMsgID;
           }
           else
           {
               strSql.Append(" where PromotionMsgID=@PromotionMsgID and CardGradeID=@CardGradeID ");
               parameters[0].Value = PromotionMsgID;
               parameters[1].Value = CardGradeID;
           }

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
