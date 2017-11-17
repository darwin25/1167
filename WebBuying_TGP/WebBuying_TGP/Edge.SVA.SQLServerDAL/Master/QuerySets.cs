using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:QuerySets
	/// </summary>
	public partial class QuerySets:IQuerySets
	{
		public QuerySets()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("QueryID", "QuerySets"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int QueryID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from QuerySets");
			strSql.Append(" where QueryID=@QueryID ");
			SqlParameter[] parameters = {
					new SqlParameter("@QueryID", SqlDbType.Int,4)};
			parameters[0].Value = QueryID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.QuerySets model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into QuerySets(");
			strSql.Append("QueryID,DataModelID,QueryGroup,Description,Definition,ChangeParams,DistinctQuery,CreatedOn,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@QueryID,@DataModelID,@QueryGroup,@Description,@Definition,@ChangeParams,@DistinctQuery,@CreatedOn,@UpdatedOn,@UpdatedBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@QueryID", SqlDbType.Int,4),
					new SqlParameter("@DataModelID", SqlDbType.Int,4),
					new SqlParameter("@QueryGroup", SqlDbType.VarChar,30),
					new SqlParameter("@Description", SqlDbType.NText),
					new SqlParameter("@Definition", SqlDbType.NText),
					new SqlParameter("@ChangeParams", SqlDbType.TinyInt,1),
					new SqlParameter("@DistinctQuery", SqlDbType.TinyInt,1),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.VarChar,30)};
			parameters[0].Value = model.QueryID;
			parameters[1].Value = model.DataModelID;
			parameters[2].Value = model.QueryGroup;
			parameters[3].Value = model.Description;
			parameters[4].Value = model.Definition;
			parameters[5].Value = model.ChangeParams;
			parameters[6].Value = model.DistinctQuery;
			parameters[7].Value = model.CreatedOn;
			parameters[8].Value = model.UpdatedOn;
			parameters[9].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.QuerySets model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update QuerySets set ");
			strSql.Append("DataModelID=@DataModelID,");
			strSql.Append("QueryGroup=@QueryGroup,");
			strSql.Append("Description=@Description,");
			strSql.Append("Definition=@Definition,");
			strSql.Append("ChangeParams=@ChangeParams,");
			strSql.Append("DistinctQuery=@DistinctQuery,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where QueryID=@QueryID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DataModelID", SqlDbType.Int,4),
					new SqlParameter("@QueryGroup", SqlDbType.VarChar,30),
					new SqlParameter("@Description", SqlDbType.NText),
					new SqlParameter("@Definition", SqlDbType.NText),
					new SqlParameter("@ChangeParams", SqlDbType.TinyInt,1),
					new SqlParameter("@DistinctQuery", SqlDbType.TinyInt,1),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.VarChar,30),
					new SqlParameter("@QueryID", SqlDbType.Int,4)};
			parameters[0].Value = model.DataModelID;
			parameters[1].Value = model.QueryGroup;
			parameters[2].Value = model.Description;
			parameters[3].Value = model.Definition;
			parameters[4].Value = model.ChangeParams;
			parameters[5].Value = model.DistinctQuery;
			parameters[6].Value = model.CreatedOn;
			parameters[7].Value = model.UpdatedOn;
			parameters[8].Value = model.UpdatedBy;
			parameters[9].Value = model.QueryID;

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
		public bool Delete(int QueryID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from QuerySets ");
			strSql.Append(" where QueryID=@QueryID ");
			SqlParameter[] parameters = {
					new SqlParameter("@QueryID", SqlDbType.Int,4)};
			parameters[0].Value = QueryID;

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
		public bool DeleteList(string QueryIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from QuerySets ");
			strSql.Append(" where QueryID in ("+QueryIDlist + ")  ");
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
		public Edge.SVA.Model.QuerySets GetModel(int QueryID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 QueryID,DataModelID,QueryGroup,Description,Definition,ChangeParams,DistinctQuery,CreatedOn,UpdatedOn,UpdatedBy from QuerySets ");
			strSql.Append(" where QueryID=@QueryID ");
			SqlParameter[] parameters = {
					new SqlParameter("@QueryID", SqlDbType.Int,4)};
			parameters[0].Value = QueryID;

			Edge.SVA.Model.QuerySets model=new Edge.SVA.Model.QuerySets();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["QueryID"]!=null && ds.Tables[0].Rows[0]["QueryID"].ToString()!="")
				{
					model.QueryID=int.Parse(ds.Tables[0].Rows[0]["QueryID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DataModelID"]!=null && ds.Tables[0].Rows[0]["DataModelID"].ToString()!="")
				{
					model.DataModelID=int.Parse(ds.Tables[0].Rows[0]["DataModelID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["QueryGroup"]!=null && ds.Tables[0].Rows[0]["QueryGroup"].ToString()!="")
				{
					model.QueryGroup=ds.Tables[0].Rows[0]["QueryGroup"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Description"]!=null && ds.Tables[0].Rows[0]["Description"].ToString()!="")
				{
					model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Definition"]!=null && ds.Tables[0].Rows[0]["Definition"].ToString()!="")
				{
					model.Definition=ds.Tables[0].Rows[0]["Definition"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ChangeParams"]!=null && ds.Tables[0].Rows[0]["ChangeParams"].ToString()!="")
				{
					model.ChangeParams=int.Parse(ds.Tables[0].Rows[0]["ChangeParams"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DistinctQuery"]!=null && ds.Tables[0].Rows[0]["DistinctQuery"].ToString()!="")
				{
					model.DistinctQuery=int.Parse(ds.Tables[0].Rows[0]["DistinctQuery"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedOn"]!=null && ds.Tables[0].Rows[0]["CreatedOn"].ToString()!="")
				{
					model.CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
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
			strSql.Append("select QueryID,DataModelID,QueryGroup,Description,Definition,ChangeParams,DistinctQuery,CreatedOn,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM QuerySets ");
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
			strSql.Append(" QueryID,DataModelID,QueryGroup,Description,Definition,ChangeParams,DistinctQuery,CreatedOn,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM QuerySets ");
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
			parameters[0].Value = "QuerySets";
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
            sql.Append("select count(*) from QuerySets ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

