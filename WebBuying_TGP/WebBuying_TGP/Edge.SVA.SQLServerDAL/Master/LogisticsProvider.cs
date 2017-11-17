using System;
using System.Collections.Generic;
using System.Text;
using Edge.DBUtility;
using System.Data.SqlClient;
using System.Data;
using Edge.SVA.IDAL;

namespace Edge.SVA.SQLServerDAL
{
    /// <summary>
    /// 物流供应商
    /// 创建人：Lisa
    /// 创建时间：2015-12-31
    public class LogisticsProvider : ILogisticsProvider
    {
        public LogisticsProvider(){ }

        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("LogisticsProviderID", "LogisticsProvider");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int LogisticsProviderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LogisticsProvider");
            strSql.Append(" where LogisticsProviderID=@LogisticsProviderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LogisticsProviderID", SqlDbType.Int,4)			};
            parameters[0].Value = LogisticsProviderID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Edge.SVA.Model.LogisticsProvider model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LogisticsProvider(");
            strSql.Append("LogisticsProviderCode,ProviderName1,ProviderName2,ProviderName3,ProviderContactTel,ProviderContact,");
            strSql.Append("ProviderContactEmail,OrdQueryAddr,Remark,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
            strSql.Append(" values (");
            strSql.Append("@LogisticsProviderCode,@ProviderName1,@ProviderName2,@ProviderName3,@ProviderContactTel,@ProviderContact,");
            strSql.Append("@ProviderContactEmail,@OrdQueryAddr,@Remark,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@LogisticsProviderCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProviderName1", SqlDbType.NVarChar,512),
					new SqlParameter("@ProviderName2", SqlDbType.NVarChar,512),
					new SqlParameter("@ProviderName3", SqlDbType.NVarChar,512),
					new SqlParameter("@ProviderContactTel", SqlDbType.VarChar,64),
					new SqlParameter("@ProviderContact", SqlDbType.VarChar,64),
					new SqlParameter("@ProviderContactEmail", SqlDbType.VarChar,64),
					new SqlParameter("@OrdQueryAddr", SqlDbType.NVarChar,512),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
            parameters[0].Value = model.LogisticsProviderCode;
            parameters[1].Value = model.ProviderName1;
            parameters[2].Value = model.ProviderName2;
            parameters[3].Value = model.ProviderName3;
            parameters[4].Value = model.ProviderContactTel;
            parameters[5].Value = model.ProviderContact;
            parameters[6].Value = model.ProviderContactEmail;
            parameters[7].Value = model.OrdQueryAddr;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.CreatedOn;
            parameters[10].Value = model.CreatedBy;
            parameters[11].Value = model.UpdatedOn;
            parameters[12].Value = model.UpdatedBy;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Edge.SVA.Model.LogisticsProvider model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LogisticsProvider set ");
            strSql.Append("ProviderName1=@ProviderName1,");
            strSql.Append("ProviderName2=@ProviderName2,");
            strSql.Append("ProviderName3=@ProviderName3,");
            strSql.Append("ProviderContactTel=@ProviderContactTel,");
            strSql.Append("ProviderContact=@ProviderContact,");
            strSql.Append("ProviderContactEmail=@ProviderContactEmail,");
            strSql.Append("OrdQueryAddr=@OrdQueryAddr,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("CreatedOn=@CreatedOn,");
            strSql.Append("CreatedBy=@CreatedBy,");
            strSql.Append("UpdatedOn=@UpdatedOn,");
            strSql.Append("UpdatedBy=@UpdatedBy,");
            strSql.Append("LogisticsProviderCode=@LogisticsProviderCode");
            strSql.Append(" where LogisticsProviderID=@LogisticsProviderID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProviderName1", SqlDbType.NVarChar,512),
					new SqlParameter("@ProviderName2", SqlDbType.NVarChar,512),
					new SqlParameter("@ProviderName3", SqlDbType.NVarChar,512),
					new SqlParameter("@ProviderContactTel", SqlDbType.VarChar,64),
					new SqlParameter("@ProviderContact", SqlDbType.VarChar,64),
					new SqlParameter("@ProviderContactEmail", SqlDbType.VarChar,64),
					new SqlParameter("@OrdQueryAddr", SqlDbType.NVarChar,512),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
                    new SqlParameter("@LogisticsProviderCode", SqlDbType.VarChar,64),
					new SqlParameter("@LogisticsProviderID", SqlDbType.Int,4)
					};
            parameters[0].Value = model.ProviderName1;
            parameters[1].Value = model.ProviderName2;
            parameters[2].Value = model.ProviderName3;
            parameters[3].Value = model.ProviderContactTel;
            parameters[4].Value = model.ProviderContact;
            parameters[5].Value = model.ProviderContactEmail;
            parameters[6].Value = model.OrdQueryAddr;
            parameters[7].Value = model.Remark;
            parameters[8].Value = model.CreatedOn;
            parameters[9].Value = model.CreatedBy;
            parameters[10].Value = model.UpdatedOn;
            parameters[11].Value = model.UpdatedBy;
            parameters[12].Value = model.LogisticsProviderCode;
            parameters[13].Value = model.LogisticsProviderID;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int LogisticsProviderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LogisticsProvider ");
            strSql.Append(" where LogisticsProviderID=@LogisticsProviderID");
            SqlParameter[] parameters = {
					new SqlParameter("@LogisticsProviderID", SqlDbType.Int,4)
			};
            parameters[0].Value = LogisticsProviderID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string LogisticsProviderCode, int LogisticsProviderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LogisticsProvider ");
            strSql.Append(" where LogisticsProviderID=@LogisticsProviderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LogisticsProviderID", SqlDbType.Int,4)			};
            parameters[0].Value = LogisticsProviderID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string LogisticsProviderIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LogisticsProvider ");
            strSql.Append(" where LogisticsProviderID in (" + LogisticsProviderIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Edge.SVA.Model.LogisticsProvider GetModel(int LogisticsProviderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LogisticsProviderID,LogisticsProviderCode,ProviderName1,ProviderName2,ProviderName3,ProviderContactTel,ProviderContact,");
            strSql.Append("ProviderContactEmail,OrdQueryAddr,Remark,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from LogisticsProvider ");
            strSql.Append(" where LogisticsProviderID=@LogisticsProviderID");
            SqlParameter[] parameters = {
					new SqlParameter("@LogisticsProviderID", SqlDbType.Int,4)
			};
            parameters[0].Value = LogisticsProviderID;

            Edge.SVA.Model.LogisticsProvider model = new Edge.SVA.Model.LogisticsProvider();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Edge.SVA.Model.LogisticsProvider DataRowToModel(DataRow row)
        {
            Edge.SVA.Model.LogisticsProvider model = new Edge.SVA.Model.LogisticsProvider();
            if (row != null)
            {
                if (row["LogisticsProviderID"] != null && row["LogisticsProviderID"].ToString() != "")
                {
                    model.LogisticsProviderID = int.Parse(row["LogisticsProviderID"].ToString());
                }
                if (row["LogisticsProviderCode"] != null)
                {
                    model.LogisticsProviderCode = row["LogisticsProviderCode"].ToString();
                }
                if (row["ProviderName1"] != null)
                {
                    model.ProviderName1 = row["ProviderName1"].ToString();
                }
                if (row["ProviderName2"] != null)
                {
                    model.ProviderName2 = row["ProviderName2"].ToString();
                }
                if (row["ProviderName3"] != null)
                {
                    model.ProviderName3 = row["ProviderName3"].ToString();
                }
                if (row["ProviderContactTel"] != null)
                {
                    model.ProviderContactTel = row["ProviderContactTel"].ToString();
                }
                if (row["ProviderContact"] != null)
                {
                    model.ProviderContact = row["ProviderContact"].ToString();
                }
                if (row["ProviderContactEmail"] != null)
                {
                    model.ProviderContactEmail = row["ProviderContactEmail"].ToString();
                }
                if (row["OrdQueryAddr"] != null)
                {
                    model.OrdQueryAddr = row["OrdQueryAddr"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["CreatedOn"] != null && row["CreatedOn"].ToString() != "")
                {
                    model.CreatedOn = DateTime.Parse(row["CreatedOn"].ToString());
                }
                if (row["CreatedBy"] != null && row["CreatedBy"].ToString() != "")
                {
                    model.CreatedBy = int.Parse(row["CreatedBy"].ToString());
                }
                if (row["UpdatedOn"] != null && row["UpdatedOn"].ToString() != "")
                {
                    model.UpdatedOn = DateTime.Parse(row["UpdatedOn"].ToString());
                }
                if (row["UpdatedBy"] != null && row["UpdatedBy"].ToString() != "")
                {
                    model.UpdatedBy = int.Parse(row["UpdatedBy"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LogisticsProviderID,LogisticsProviderCode,ProviderName1,ProviderName2,ProviderName3,ProviderContactTel,ProviderContact,");
            strSql.Append("ProviderContactEmail,OrdQueryAddr,Remark,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
            strSql.Append(" FROM LogisticsProvider ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" LogisticsProviderID,LogisticsProviderCode,ProviderName1,ProviderName2,ProviderName3,ProviderContactTel,ProviderContact,");
            strSql.Append("ProviderContactEmail,OrdQueryAddr,Remark,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
            strSql.Append(" FROM LogisticsProvider ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM LogisticsProvider ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.LogisticsProviderID desc");
            }
            strSql.Append(")AS Row, T.*  from LogisticsProvider T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("SQL2012fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("SQL2012PageSize", SqlDbType.Int),
                    new SqlParameter("SQL2012PageIndex", SqlDbType.Int),
                    new SqlParameter("SQL2012IsReCount", SqlDbType.Bit),
                    new SqlParameter("SQL2012OrderType", SqlDbType.Bit),
                    new SqlParameter("SQL2012strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "LogisticsProvider";
            parameters[1].Value = "LogisticsProviderID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
    }
}
