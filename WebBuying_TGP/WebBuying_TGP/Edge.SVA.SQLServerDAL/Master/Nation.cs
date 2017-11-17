using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Nation
	/// </summary>
	public partial class Nation:INation
	{
		public Nation()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("NationID", "Nation"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string NationCode,int NationID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Nation");
			strSql.Append(" where NationCode=@NationCode and NationID=@NationID ");
			SqlParameter[] parameters = {
					new SqlParameter("@NationCode", SqlDbType.VarChar,64),
					new SqlParameter("@NationID", SqlDbType.Int,4)};
			parameters[0].Value = NationCode;
			parameters[1].Value = NationID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.Nation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Nation(");
			strSql.Append("NationCode,CountryCode,NationName1,NationName2,NationName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@NationCode,@CountryCode,@NationName1,@NationName2,@NationName3,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NationCode", SqlDbType.VarChar,64),
					new SqlParameter("@CountryCode", SqlDbType.VarChar,64),
					new SqlParameter("@NationName1", SqlDbType.NVarChar,512),
					new SqlParameter("@NationName2", SqlDbType.NVarChar,512),
					new SqlParameter("@NationName3", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.NationCode;
			parameters[1].Value = model.CountryCode;
			parameters[2].Value = model.NationName1;
			parameters[3].Value = model.NationName2;
			parameters[4].Value = model.NationName3;
			parameters[5].Value = model.CreatedOn;
			parameters[6].Value = model.CreatedBy;
			parameters[7].Value = model.UpdatedOn;
			parameters[8].Value = model.UpdatedBy;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(Edge.SVA.Model.Nation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Nation set ");
			strSql.Append("CountryCode=@CountryCode,");
			strSql.Append("NationName1=@NationName1,");
			strSql.Append("NationName2=@NationName2,");
			strSql.Append("NationName3=@NationName3,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
            strSql.Append("NationCode=@NationCode");
			strSql.Append(" where NationID=@NationID");
			SqlParameter[] parameters = {
					new SqlParameter("@CountryCode", SqlDbType.VarChar,64),
					new SqlParameter("@NationName1", SqlDbType.NVarChar,512),
					new SqlParameter("@NationName2", SqlDbType.NVarChar,512),
					new SqlParameter("@NationName3", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@NationID", SqlDbType.Int,4),
					new SqlParameter("@NationCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.CountryCode;
			parameters[1].Value = model.NationName1;
			parameters[2].Value = model.NationName2;
			parameters[3].Value = model.NationName3;
			parameters[4].Value = model.CreatedOn;
			parameters[5].Value = model.CreatedBy;
			parameters[6].Value = model.UpdatedOn;
			parameters[7].Value = model.UpdatedBy;
			parameters[8].Value = model.NationID;
			parameters[9].Value = model.NationCode;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int NationID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Nation ");
			strSql.Append(" where NationID=@NationID");
			SqlParameter[] parameters = {
					new SqlParameter("@NationID", SqlDbType.Int,4)
};
			parameters[0].Value = NationID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(string NationCode,int NationID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Nation ");
			strSql.Append(" where NationCode=@NationCode and NationID=@NationID ");
			SqlParameter[] parameters = {
					new SqlParameter("@NationCode", SqlDbType.VarChar,64),
					new SqlParameter("@NationID", SqlDbType.Int,4)};
			parameters[0].Value = NationCode;
			parameters[1].Value = NationID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string NationIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Nation ");
			strSql.Append(" where NationID in ("+NationIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public Edge.SVA.Model.Nation GetModel(int NationID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 NationID,NationCode,CountryCode,NationName1,NationName2,NationName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from Nation ");
			strSql.Append(" where NationID=@NationID");
			SqlParameter[] parameters = {
					new SqlParameter("@NationID", SqlDbType.Int,4)
};
			parameters[0].Value = NationID;

			Edge.SVA.Model.Nation model=new Edge.SVA.Model.Nation();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["NationID"]!=null && ds.Tables[0].Rows[0]["NationID"].ToString()!="")
				{
					model.NationID=int.Parse(ds.Tables[0].Rows[0]["NationID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NationCode"]!=null && ds.Tables[0].Rows[0]["NationCode"].ToString()!="")
				{
					model.NationCode=ds.Tables[0].Rows[0]["NationCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CountryCode"]!=null && ds.Tables[0].Rows[0]["CountryCode"].ToString()!="")
				{
					model.CountryCode=ds.Tables[0].Rows[0]["CountryCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NationName1"]!=null && ds.Tables[0].Rows[0]["NationName1"].ToString()!="")
				{
					model.NationName1=ds.Tables[0].Rows[0]["NationName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NationName2"]!=null && ds.Tables[0].Rows[0]["NationName2"].ToString()!="")
				{
					model.NationName2=ds.Tables[0].Rows[0]["NationName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NationName3"]!=null && ds.Tables[0].Rows[0]["NationName3"].ToString()!="")
				{
					model.NationName3=ds.Tables[0].Rows[0]["NationName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CreatedOn"]!=null && ds.Tables[0].Rows[0]["CreatedOn"].ToString()!="")
				{
					model.CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedBy"]!=null && ds.Tables[0].Rows[0]["CreatedBy"].ToString()!="")
				{
					model.CreatedBy=int.Parse(ds.Tables[0].Rows[0]["CreatedBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedOn"]!=null && ds.Tables[0].Rows[0]["UpdatedOn"].ToString()!="")
				{
					model.UpdatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedBy"]!=null && ds.Tables[0].Rows[0]["UpdatedBy"].ToString()!="")
				{
					model.UpdatedBy=int.Parse(ds.Tables[0].Rows[0]["UpdatedBy"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select NationID,NationCode,CountryCode,NationName1,NationName2,NationName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM Nation ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" NationID,NationCode,CountryCode,NationName1,NationName2,NationName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM Nation ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@OrderfldName",SqlDbType.VarChar,255),
                    new SqlParameter("@StatfldName",SqlDbType.VarChar,255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.NText),
					};
            parameters[0].Value = "Nation";
            parameters[1].Value = "*";
            parameters[2].Value = filedOrder;
            parameters[3].Value = "";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 0;
            parameters[7].Value = 0;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPageOrder", parameters, "ds");
        }

        /// <summary>
        /// 获取行总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select count(*) from Nation ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

