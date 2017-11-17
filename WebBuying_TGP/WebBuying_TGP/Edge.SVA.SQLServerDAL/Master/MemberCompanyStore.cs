using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:MemberCompanyStore
	/// </summary>
	public partial class MemberCompanyStore:IMemberCompanyStore
	{
		public MemberCompanyStore()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string StoreCode,string CompanyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MemberCompanyStore");
			strSql.Append(" where StoreCode=@StoreCode and CompanyID=@CompanyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreCode", SqlDbType.NVarChar,10),
					new SqlParameter("@CompanyID", SqlDbType.VarChar,36)};
			parameters[0].Value = StoreCode;
			parameters[1].Value = CompanyID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.MemberCompanyStore model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MemberCompanyStore(");
			strSql.Append("StoreCode,StoreName,CompanyID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@StoreCode,@StoreName,@CompanyID,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreCode", SqlDbType.NVarChar,10),
					new SqlParameter("@StoreName", SqlDbType.NVarChar,50),
					new SqlParameter("@CompanyID", SqlDbType.VarChar,36),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.VarChar,10),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.VarChar,10)};
			parameters[0].Value = model.StoreCode;
			parameters[1].Value = model.StoreName;
			parameters[2].Value = model.CompanyID;
			parameters[3].Value = model.CreatedOn;
			parameters[4].Value = model.CreatedBy;
			parameters[5].Value = model.UpdatedOn;
			parameters[6].Value = model.UpdatedBy;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.MemberCompanyStore model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MemberCompanyStore set ");
			strSql.Append("StoreName=@StoreName,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where StoreCode=@StoreCode and CompanyID=@CompanyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.VarChar,10),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.VarChar,10),
					new SqlParameter("@StoreCode", SqlDbType.NVarChar,10),
					new SqlParameter("@CompanyID", SqlDbType.VarChar,36)};
			parameters[0].Value = model.StoreName;
			parameters[1].Value = model.CreatedOn;
			parameters[2].Value = model.CreatedBy;
			parameters[3].Value = model.UpdatedOn;
			parameters[4].Value = model.UpdatedBy;
			parameters[5].Value = model.StoreCode;
			parameters[6].Value = model.CompanyID;

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
		public bool Delete(string StoreCode,string CompanyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MemberCompanyStore ");
			strSql.Append(" where StoreCode=@StoreCode and CompanyID=@CompanyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreCode", SqlDbType.NVarChar,10),
					new SqlParameter("@CompanyID", SqlDbType.VarChar,36)};
			parameters[0].Value = StoreCode;
			parameters[1].Value = CompanyID;

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
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.MemberCompanyStore GetModel(string StoreCode,string CompanyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StoreCode,StoreName,CompanyID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from MemberCompanyStore ");
			strSql.Append(" where StoreCode=@StoreCode and CompanyID=@CompanyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreCode", SqlDbType.NVarChar,10),
					new SqlParameter("@CompanyID", SqlDbType.VarChar,36)};
			parameters[0].Value = StoreCode;
			parameters[1].Value = CompanyID;

			Edge.SVA.Model.MemberCompanyStore model=new Edge.SVA.Model.MemberCompanyStore();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["StoreCode"]!=null && ds.Tables[0].Rows[0]["StoreCode"].ToString()!="")
				{
					model.StoreCode=ds.Tables[0].Rows[0]["StoreCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreName"]!=null && ds.Tables[0].Rows[0]["StoreName"].ToString()!="")
				{
					model.StoreName=ds.Tables[0].Rows[0]["StoreName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CompanyID"]!=null && ds.Tables[0].Rows[0]["CompanyID"].ToString()!="")
				{
					model.CompanyID=ds.Tables[0].Rows[0]["CompanyID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CreatedOn"]!=null && ds.Tables[0].Rows[0]["CreatedOn"].ToString()!="")
				{
					model.CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedBy"]!=null && ds.Tables[0].Rows[0]["CreatedBy"].ToString()!="")
				{
					model.CreatedBy=ds.Tables[0].Rows[0]["CreatedBy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["UpdatedOn"]!=null && ds.Tables[0].Rows[0]["UpdatedOn"].ToString()!="")
				{
					model.UpdatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedBy"]!=null && ds.Tables[0].Rows[0]["UpdatedBy"].ToString()!="")
				{
					model.UpdatedBy=ds.Tables[0].Rows[0]["UpdatedBy"].ToString();
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
			strSql.Append("select StoreCode,StoreName,CompanyID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM MemberCompanyStore ");
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
			strSql.Append(" StoreCode,StoreName,CompanyID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM MemberCompanyStore ");
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
			parameters[0].Value = "MemberCompanyStore";
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
            sql.Append("select count(*) from MemberCompanyStore ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }
		#endregion  Method
	}
} 