using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Edge.DBUtility;

namespace Edge.SVA.BLL.Domain.BasicInformationSetting.Notification.MsgTemplate
{
    public class MsgTemplate
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Edge.SVA.Model.MessageTemplate model, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MessageTemplate(");
            strSql.Append("MessageTemplateCode,MessageTemplateDesc,BrandID,OprID,Remark)");
            strSql.Append(" values (");
            strSql.Append("@MessageTemplateCode,@MessageTemplateDesc,@BrandID,@OprID,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MessageTemplateCode", SqlDbType.VarChar,64),
					new SqlParameter("@MessageTemplateDesc", SqlDbType.NVarChar,512),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@OprID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512)};
            parameters[0].Value = model.MessageTemplateCode;
            parameters[1].Value = model.MessageTemplateDesc;
            parameters[2].Value = model.BrandID;
            parameters[3].Value = model.OprID;
            parameters[4].Value = model.Remark;

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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Edge.SVA.Model.MessageTemplate model, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MessageTemplate set ");
            strSql.Append("MessageTemplateCode=@MessageTemplateCode,");
            strSql.Append("MessageTemplateDesc=@MessageTemplateDesc,");
            strSql.Append("BrandID=@BrandID,");
            strSql.Append("OprID=@OprID,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where MessageTemplateID=@MessageTemplateID");
            SqlParameter[] parameters = {
					new SqlParameter("@MessageTemplateCode", SqlDbType.VarChar,64),
					new SqlParameter("@MessageTemplateDesc", SqlDbType.NVarChar,512),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@OprID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@MessageTemplateID", SqlDbType.Int,4)};
            parameters[0].Value = model.MessageTemplateCode;
            parameters[1].Value = model.MessageTemplateDesc;
            parameters[2].Value = model.BrandID;
            parameters[3].Value = model.OprID;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.MessageTemplateID;

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
            strSql.Append("delete from MessageTemplate ");
            strSql.Append(" where MessageTemplateID=@MessageTemplateID");
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
