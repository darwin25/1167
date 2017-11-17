using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:StoreGroup
	/// </summary>
	public partial class StoreGroup:IStoreGroup
	{
		public StoreGroup()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("StoreGroupID", "StoreGroup"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StoreGroupID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StoreGroup");
			strSql.Append(" where StoreGroupID=@StoreGroupID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreGroupID", SqlDbType.Int,4)
};
			parameters[0].Value = StoreGroupID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.StoreGroup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StoreGroup(");
			strSql.Append("StoreGroupName1,StoreGroupName2,StoreGroupName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,StoreGroupCode)");
			strSql.Append(" values (");
			strSql.Append("@StoreGroupName1,@StoreGroupName2,@StoreGroupName3,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@StoreGroupCode)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreGroupName1", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreGroupName2", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreGroupName3", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@StoreGroupCode", SqlDbType.VarChar,512)};
			parameters[0].Value = model.StoreGroupName1;
			parameters[1].Value = model.StoreGroupName2;
			parameters[2].Value = model.StoreGroupName3;
			parameters[3].Value = model.CreatedOn;
			parameters[4].Value = model.CreatedBy;
			parameters[5].Value = model.UpdatedOn;
			parameters[6].Value = model.UpdatedBy;
			parameters[7].Value = model.StoreGroupCode;

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
		public bool Update(Edge.SVA.Model.StoreGroup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StoreGroup set ");
			strSql.Append("StoreGroupName1=@StoreGroupName1,");
			strSql.Append("StoreGroupName2=@StoreGroupName2,");
			strSql.Append("StoreGroupName3=@StoreGroupName3,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("StoreGroupCode=@StoreGroupCode");
			strSql.Append(" where StoreGroupID=@StoreGroupID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreGroupName1", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreGroupName2", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreGroupName3", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@StoreGroupCode", SqlDbType.VarChar,512),
					new SqlParameter("@StoreGroupID", SqlDbType.Int,4)};
			parameters[0].Value = model.StoreGroupName1;
			parameters[1].Value = model.StoreGroupName2;
			parameters[2].Value = model.StoreGroupName3;
			parameters[3].Value = model.CreatedOn;
			parameters[4].Value = model.CreatedBy;
			parameters[5].Value = model.UpdatedOn;
			parameters[6].Value = model.UpdatedBy;
			parameters[7].Value = model.StoreGroupCode;
			parameters[8].Value = model.StoreGroupID;

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
		public bool Delete(int StoreGroupID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreGroup ");
			strSql.Append(" where StoreGroupID=@StoreGroupID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreGroupID", SqlDbType.Int,4)
};
			parameters[0].Value = StoreGroupID;

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
		public bool DeleteList(string StoreGroupIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreGroup ");
			strSql.Append(" where StoreGroupID in ("+StoreGroupIDlist + ")  ");
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
		public Edge.SVA.Model.StoreGroup GetModel(int StoreGroupID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StoreGroupID,StoreGroupName1,StoreGroupName2,StoreGroupName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,StoreGroupCode from StoreGroup ");
			strSql.Append(" where StoreGroupID=@StoreGroupID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreGroupID", SqlDbType.Int,4)
};
			parameters[0].Value = StoreGroupID;

			Edge.SVA.Model.StoreGroup model=new Edge.SVA.Model.StoreGroup();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["StoreGroupID"]!=null && ds.Tables[0].Rows[0]["StoreGroupID"].ToString()!="")
				{
					model.StoreGroupID=int.Parse(ds.Tables[0].Rows[0]["StoreGroupID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StoreGroupName1"]!=null && ds.Tables[0].Rows[0]["StoreGroupName1"].ToString()!="")
				{
					model.StoreGroupName1=ds.Tables[0].Rows[0]["StoreGroupName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreGroupName2"]!=null && ds.Tables[0].Rows[0]["StoreGroupName2"].ToString()!="")
				{
					model.StoreGroupName2=ds.Tables[0].Rows[0]["StoreGroupName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreGroupName3"]!=null && ds.Tables[0].Rows[0]["StoreGroupName3"].ToString()!="")
				{
					model.StoreGroupName3=ds.Tables[0].Rows[0]["StoreGroupName3"].ToString();
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
				if(ds.Tables[0].Rows[0]["StoreGroupCode"]!=null && ds.Tables[0].Rows[0]["StoreGroupCode"].ToString()!="")
				{
					model.StoreGroupCode=ds.Tables[0].Rows[0]["StoreGroupCode"].ToString();
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
			strSql.Append("select StoreGroupID,StoreGroupName1,StoreGroupName2,StoreGroupName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,StoreGroupCode ");
			strSql.Append(" FROM StoreGroup ");
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
			strSql.Append(" StoreGroupID,StoreGroupName1,StoreGroupName2,StoreGroupName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,StoreGroupCode ");
			strSql.Append(" FROM StoreGroup ");
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
            int OrderType = 0;
            string OrderField = filedOrder;
            if (filedOrder.ToLower().EndsWith(" desc"))
            {
                OrderType = 1;
                OrderField = filedOrder.Substring(0, filedOrder.ToLower().IndexOf(" desc"));
            }
            else if (filedOrder.ToLower().EndsWith(" asc"))
            {
                OrderField = filedOrder.Substring(0, filedOrder.ToLower().IndexOf(" asc"));
            }
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
            parameters[0].Value = "StoreGroup";
            parameters[1].Value = "*";
            parameters[2].Value = OrderField;
            parameters[3].Value = "";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 0;
            parameters[7].Value = OrderType;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPageOrder", parameters, "ds");
        }

        /// <summary>
        /// 获取行总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select count(*) from StoreGroup ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

