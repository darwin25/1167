using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Edge.DBUtility;

namespace Edge.SVA.BLL.Domain.MemberManagement
{
   public class MemberMessageAccount
    {
       public void AddData(Edge.SVA.Model.MemberMessageAccount model, SqlTransaction trans)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into MemberMessageAccount(");
           strSql.Append("MemberID,MessageServiceTypeID,AccountNumber,Status,Note,IsPrefer,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,TokenUID,TokenStr,TokenUpdateDate)");
           strSql.Append(" values (");
           strSql.Append("@MemberID,@MessageServiceTypeID,@AccountNumber,@Status,@Note,@IsPrefer,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@TokenUID,@TokenStr,@TokenUpdateDate)");
           strSql.Append(";select @@IDENTITY");
           SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.Int,4),
					new SqlParameter("@MessageServiceTypeID", SqlDbType.Int,4),
					new SqlParameter("@AccountNumber", SqlDbType.NVarChar,512),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@IsPrefer", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@TokenUID", SqlDbType.VarChar,64),
					new SqlParameter("@TokenStr", SqlDbType.VarChar,512),
					new SqlParameter("@TokenUpdateDate", SqlDbType.DateTime)};
           parameters[0].Value = model.MemberID;
           parameters[1].Value = model.MessageServiceTypeID;
           parameters[2].Value = model.AccountNumber;
           parameters[3].Value = model.Status;
           parameters[4].Value = model.Note;
           parameters[5].Value = model.IsPrefer;
           parameters[6].Value = model.CreatedOn;
           parameters[7].Value = model.CreatedBy;
           parameters[8].Value = model.UpdatedOn;
           parameters[9].Value = model.UpdatedBy;
           parameters[10].Value = model.TokenUID;
           parameters[11].Value = model.TokenStr;
           parameters[12].Value = model.TokenUpdateDate;

           //将空值赋值为默认值
           foreach (SqlParameter parameter in parameters)
           {
               if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                   (parameter.Value == null))
               {
                   parameter.Value = DBNull.Value;
               }
           }

           SqlHelper.NewExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL
       }

       public void UpdateData(Edge.SVA.Model.MemberMessageAccount model, SqlTransaction trans)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update MemberMessageAccount set ");
           strSql.Append("MemberID=@MemberID,");
           strSql.Append("MessageServiceTypeID=@MessageServiceTypeID,");
           strSql.Append("AccountNumber=@AccountNumber,");
           strSql.Append("Status=@Status,");
           strSql.Append("Note=@Note,");
           strSql.Append("IsPrefer=@IsPrefer,");
           strSql.Append("CreatedOn=@CreatedOn,");
           strSql.Append("CreatedBy=@CreatedBy,");
           strSql.Append("UpdatedOn=@UpdatedOn,");
           strSql.Append("UpdatedBy=@UpdatedBy,");
           strSql.Append("TokenUID=@TokenUID,");
           strSql.Append("TokenStr=@TokenStr,");
           strSql.Append("TokenUpdateDate=@TokenUpdateDate");
           strSql.Append(" where MemberID=@MemberID and MessageServiceTypeID=@MessageServiceTypeID");
           SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.Int,4),
					new SqlParameter("@MessageServiceTypeID", SqlDbType.Int,4),
					new SqlParameter("@AccountNumber", SqlDbType.NVarChar,512),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@IsPrefer", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@TokenUID", SqlDbType.VarChar,64),
					new SqlParameter("@TokenStr", SqlDbType.VarChar,512),
					new SqlParameter("@TokenUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@MessageAccountID", SqlDbType.Int,4)};
           parameters[0].Value = model.MemberID;
           parameters[1].Value = model.MessageServiceTypeID;
           parameters[2].Value = model.AccountNumber;
           parameters[3].Value = model.Status;
           parameters[4].Value = model.Note;
           parameters[5].Value = model.IsPrefer;
           parameters[6].Value = model.CreatedOn;
           parameters[7].Value = model.CreatedBy;
           parameters[8].Value = model.UpdatedOn;
           parameters[9].Value = model.UpdatedBy;
           parameters[10].Value = model.TokenUID;
           parameters[11].Value = model.TokenStr;
           parameters[12].Value = model.TokenUpdateDate;
           parameters[13].Value = model.MessageAccountID;

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

       public void DeleteData(int MemberID, SqlTransaction trans)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from MemberMessageAccount ");
           strSql.Append(" where MemberID=@MemberID and MessageServiceTypeID in (4,5,7,8) ");
           SqlParameter[] parameters = { new SqlParameter("@MemberID", SqlDbType.Int, 4) };
           parameters[0].Value = MemberID;

           SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL
       }

       //验证是否存在记录数
       public int GetRecord(string strWhere, SqlTransaction trans)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select MessageAccountID,MemberID,MessageServiceTypeID,AccountNumber,Status,Note,IsPrefer,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,TokenUID,TokenStr,TokenUpdateDate ");
           strSql.Append(" FROM MemberMessageAccount ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           //return SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), null);
           return Convert.ToInt32(SqlHelper.NewExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), null));
       }
    }
}
