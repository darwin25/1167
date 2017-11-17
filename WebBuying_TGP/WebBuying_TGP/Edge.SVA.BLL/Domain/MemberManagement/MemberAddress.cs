using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Edge.DBUtility;

namespace Edge.SVA.BLL.Domain.MemberManagement
{
    public class MemberAddress
    {
        public void AddData(Edge.SVA.Model.MemberAddress model, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MemberAddress(");
            strSql.Append("MemberID,MemberFirstAddr,AddressCountry,AddressProvince,AddressCity,AddressDistrict,AddressDetail,AddressFullDetail,AddressZipCode,Contact,ContactPhone,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
            strSql.Append(" values (");
            strSql.Append("@MemberID,@MemberFirstAddr,@AddressCountry,@AddressProvince,@AddressCity,@AddressDistrict,@AddressDetail,@AddressFullDetail,@AddressZipCode,@Contact,@ContactPhone,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.Int,4),
					new SqlParameter("@MemberFirstAddr", SqlDbType.Int,4),
					new SqlParameter("@AddressCountry", SqlDbType.VarChar,64),
					new SqlParameter("@AddressProvince", SqlDbType.VarChar,64),
					new SqlParameter("@AddressCity", SqlDbType.VarChar,64),
					new SqlParameter("@AddressDistrict", SqlDbType.VarChar,64),
					new SqlParameter("@AddressDetail", SqlDbType.NVarChar,512),
					new SqlParameter("@AddressFullDetail", SqlDbType.NVarChar,512),
					new SqlParameter("@AddressZipCode", SqlDbType.VarChar,512),
					new SqlParameter("@Contact", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactPhone", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
            parameters[0].Value = model.MemberID;
            parameters[1].Value = model.MemberFirstAddr;
            parameters[2].Value = model.AddressCountry;
            parameters[3].Value = model.AddressProvince;
            parameters[4].Value = model.AddressCity;
            parameters[5].Value = model.AddressDistrict;
            parameters[6].Value = model.AddressDetail;
            parameters[7].Value = model.AddressFullDetail;
            parameters[8].Value = model.AddressZipCode;
            parameters[9].Value = model.Contact;
            parameters[10].Value = model.ContactPhone;
            parameters[11].Value = model.CreatedOn;
            parameters[12].Value = model.CreatedBy;
            parameters[13].Value = model.UpdatedOn;
            parameters[14].Value = model.UpdatedBy;

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

        public void UpdateData(Edge.SVA.Model.MemberAddress model, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MemberAddress set ");
            strSql.Append("MemberID=@MemberID,");
            strSql.Append("MemberFirstAddr=@MemberFirstAddr,");
            strSql.Append("AddressCountry=@AddressCountry,");
            strSql.Append("AddressProvince=@AddressProvince,");
            strSql.Append("AddressCity=@AddressCity,");
            strSql.Append("AddressDistrict=@AddressDistrict,");
            strSql.Append("AddressDetail=@AddressDetail,");
            strSql.Append("AddressFullDetail=@AddressFullDetail,");
            strSql.Append("AddressZipCode=@AddressZipCode,");
            strSql.Append("Contact=@Contact,");
            strSql.Append("ContactPhone=@ContactPhone,");
            strSql.Append("CreatedOn=@CreatedOn,");
            strSql.Append("CreatedBy=@CreatedBy,");
            strSql.Append("UpdatedOn=@UpdatedOn,");
            strSql.Append("UpdatedBy=@UpdatedBy");
            strSql.Append(" where AddressID=@AddressID");
            SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.Int,4),
					new SqlParameter("@MemberFirstAddr", SqlDbType.Int,4),
					new SqlParameter("@AddressCountry", SqlDbType.VarChar,64),
					new SqlParameter("@AddressProvince", SqlDbType.VarChar,64),
					new SqlParameter("@AddressCity", SqlDbType.VarChar,64),
					new SqlParameter("@AddressDistrict", SqlDbType.VarChar,64),
					new SqlParameter("@AddressDetail", SqlDbType.NVarChar,512),
					new SqlParameter("@AddressFullDetail", SqlDbType.NVarChar,512),
					new SqlParameter("@AddressZipCode", SqlDbType.VarChar,512),
					new SqlParameter("@Contact", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactPhone", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@AddressID", SqlDbType.Int,4)};
            parameters[0].Value = model.MemberID;
            parameters[1].Value = model.MemberFirstAddr;
            parameters[2].Value = model.AddressCountry;
            parameters[3].Value = model.AddressProvince;
            parameters[4].Value = model.AddressCity;
            parameters[5].Value = model.AddressDistrict;
            parameters[6].Value = model.AddressDetail;
            parameters[7].Value = model.AddressFullDetail;
            parameters[8].Value = model.AddressZipCode;
            parameters[9].Value = model.Contact;
            parameters[10].Value = model.ContactPhone;
            parameters[11].Value = model.CreatedOn;
            parameters[12].Value = model.CreatedBy;
            parameters[13].Value = model.UpdatedOn;
            parameters[14].Value = model.UpdatedBy;
            parameters[15].Value = model.AddressID;

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
            strSql.Append("delete from MemberAddress ");
            strSql.Append(" where MemberID=@MemberID");
            SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.Int,4)
			};
            parameters[0].Value = MemberID;
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

        //验证是否存在记录数
        public int GetRecord(string strWhere,SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AddressID,MemberID,MemberFirstAddr,AddressCountry,AddressProvince,AddressCity,AddressDistrict,AddressDetail,AddressFullDetail,AddressZipCode,Contact,ContactPhone,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
            strSql.Append(" FROM MemberAddress ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            //return SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), null);
            return Convert.ToInt32(SqlHelper.NewExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), null));
        }
    }
}
