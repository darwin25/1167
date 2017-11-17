using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Edge.DBUtility;

namespace Edge.SVA.BLL.Domain.BasicInformationSetting.Notification.MsgTemplate
{
   public class MessageTemplateDetail
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Edge.SVA.Model.MessageTemplateDetail model,SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MessageTemplateDetail(");
            strSql.Append("MessageTemplateID,MessageServiceTypeID,status,MessageTitle1,MessageTitle3,MessageTitle2,TemplateContent1,TemplateContent2,TemplateContent3)");
            strSql.Append(" values (");
            strSql.Append("@MessageTemplateID,@MessageServiceTypeID,@status,@MessageTitle1,@MessageTitle3,@MessageTitle2,@TemplateContent1,@TemplateContent2,@TemplateContent3)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MessageTemplateID", SqlDbType.Int,4),
					new SqlParameter("@MessageServiceTypeID", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@MessageTitle1", SqlDbType.NVarChar,512),
					new SqlParameter("@MessageTitle3", SqlDbType.NVarChar,512),
					new SqlParameter("@MessageTitle2", SqlDbType.NVarChar,512),
					new SqlParameter("@TemplateContent1", SqlDbType.NVarChar),
					new SqlParameter("@TemplateContent2", SqlDbType.NVarChar),
					new SqlParameter("@TemplateContent3", SqlDbType.NVarChar)};
            parameters[0].Value = model.MessageTemplateID;
            parameters[1].Value = model.MessageServiceTypeID;
            parameters[2].Value = model.status;
            parameters[3].Value = model.MessageTitle1;
            parameters[4].Value = model.MessageTitle3;
            parameters[5].Value = model.MessageTitle2;
            parameters[6].Value = model.TemplateContent1;
            parameters[7].Value = model.TemplateContent2;
            parameters[8].Value = model.TemplateContent3;

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
        public void Update(Edge.SVA.Model.MessageTemplateDetail model,SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MessageTemplateDetail set ");
            strSql.Append("MessageTemplateID=@MessageTemplateID,");
            strSql.Append("MessageServiceTypeID=@MessageServiceTypeID,");
            strSql.Append("status=@status,");
            strSql.Append("MessageTitle1=@MessageTitle1,");
            strSql.Append("MessageTitle3=@MessageTitle3,");
            strSql.Append("MessageTitle2=@MessageTitle2,");
            strSql.Append("TemplateContent1=@TemplateContent1,");
            strSql.Append("TemplateContent2=@TemplateContent2,");
            strSql.Append("TemplateContent3=@TemplateContent3");
            strSql.Append(" where KeyID=@KeyID");
            SqlParameter[] parameters = {
					new SqlParameter("@MessageTemplateID", SqlDbType.Int,4),
					new SqlParameter("@MessageServiceTypeID", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@MessageTitle1", SqlDbType.NVarChar,512),
					new SqlParameter("@MessageTitle3", SqlDbType.NVarChar,512),
					new SqlParameter("@MessageTitle2", SqlDbType.NVarChar,512),
					new SqlParameter("@TemplateContent1", SqlDbType.NVarChar),
					new SqlParameter("@TemplateContent2", SqlDbType.NVarChar),
					new SqlParameter("@TemplateContent3", SqlDbType.NVarChar),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
            parameters[0].Value = model.MessageTemplateID;
            parameters[1].Value = model.MessageServiceTypeID;
            parameters[2].Value = model.status;
            parameters[3].Value = model.MessageTitle1;
            parameters[4].Value = model.MessageTitle3;
            parameters[5].Value = model.MessageTitle2;
            parameters[6].Value = model.TemplateContent1;
            parameters[7].Value = model.TemplateContent2;
            parameters[8].Value = model.TemplateContent3;
            parameters[9].Value = model.KeyID;

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
        public void Delete(int MessageTemplateID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MessageTemplateDetail ");
            strSql.Append(" where MessageTemplateID = @MessageTemplateID");
            SqlParameter[] parameters = {
					new SqlParameter("@MessageTemplateID", SqlDbType.Int,4)
			};
            parameters[0].Value = MessageTemplateID;

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
