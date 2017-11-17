using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Reason
	/// </summary>
	public partial class Reason:IReason
	{
		public Reason()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ReasonID", "Reason"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ReasonID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Reason");
			strSql.Append(" where ReasonID=@ReasonID");
			SqlParameter[] parameters = {
					new SqlParameter("@ReasonID", SqlDbType.Int,4)
};
			parameters[0].Value = ReasonID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.Reason model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Reason(");
			strSql.Append("ReasonCode,ReasonDesc1,ReasonDesc2,ReasonDesc3,CreatedOn,UpdatedOn,UpdatedBy,CreatedBy)");
			strSql.Append(" values (");
			strSql.Append("@ReasonCode,@ReasonDesc1,@ReasonDesc2,@ReasonDesc3,@CreatedOn,@UpdatedOn,@UpdatedBy,@CreatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ReasonCode", SqlDbType.VarChar,512),
					new SqlParameter("@ReasonDesc1", SqlDbType.NVarChar,512),
					new SqlParameter("@ReasonDesc2", SqlDbType.NVarChar,512),
					new SqlParameter("@ReasonDesc3", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.ReasonCode;
			parameters[1].Value = model.ReasonDesc1;
			parameters[2].Value = model.ReasonDesc2;
			parameters[3].Value = model.ReasonDesc3;
			parameters[4].Value = model.CreatedOn;
			parameters[5].Value = model.UpdatedOn;
			parameters[6].Value = model.UpdatedBy;
			parameters[7].Value = model.CreatedBy;

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
		public bool Update(Edge.SVA.Model.Reason model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Reason set ");
			strSql.Append("ReasonCode=@ReasonCode,");
			strSql.Append("ReasonDesc1=@ReasonDesc1,");
			strSql.Append("ReasonDesc2=@ReasonDesc2,");
			strSql.Append("ReasonDesc3=@ReasonDesc3,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("CreatedBy=@CreatedBy");
			strSql.Append(" where ReasonID=@ReasonID");
			SqlParameter[] parameters = {
					new SqlParameter("@ReasonCode", SqlDbType.VarChar,512),
					new SqlParameter("@ReasonDesc1", SqlDbType.NVarChar,512),
					new SqlParameter("@ReasonDesc2", SqlDbType.NVarChar,512),
					new SqlParameter("@ReasonDesc3", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@ReasonID", SqlDbType.Int,4)};
			parameters[0].Value = model.ReasonCode;
			parameters[1].Value = model.ReasonDesc1;
			parameters[2].Value = model.ReasonDesc2;
			parameters[3].Value = model.ReasonDesc3;
			parameters[4].Value = model.CreatedOn;
			parameters[5].Value = model.UpdatedOn;
			parameters[6].Value = model.UpdatedBy;
			parameters[7].Value = model.CreatedBy;
			parameters[8].Value = model.ReasonID;

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
		public bool Delete(int ReasonID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Reason ");
			strSql.Append(" where ReasonID=@ReasonID");
			SqlParameter[] parameters = {
					new SqlParameter("@ReasonID", SqlDbType.Int,4)
};
			parameters[0].Value = ReasonID;

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
		public bool DeleteList(string ReasonIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Reason ");
			strSql.Append(" where ReasonID in ("+ReasonIDlist + ")  ");
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
		public Edge.SVA.Model.Reason GetModel(int ReasonID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ReasonID,ReasonCode,ReasonDesc1,ReasonDesc2,ReasonDesc3,CreatedOn,UpdatedOn,UpdatedBy,CreatedBy from Reason ");
			strSql.Append(" where ReasonID=@ReasonID");
			SqlParameter[] parameters = {
					new SqlParameter("@ReasonID", SqlDbType.Int,4)
};
			parameters[0].Value = ReasonID;

			Edge.SVA.Model.Reason model=new Edge.SVA.Model.Reason();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ReasonID"]!=null && ds.Tables[0].Rows[0]["ReasonID"].ToString()!="")
				{
					model.ReasonID=int.Parse(ds.Tables[0].Rows[0]["ReasonID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ReasonCode"]!=null && ds.Tables[0].Rows[0]["ReasonCode"].ToString()!="")
				{
					model.ReasonCode=ds.Tables[0].Rows[0]["ReasonCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ReasonDesc1"]!=null && ds.Tables[0].Rows[0]["ReasonDesc1"].ToString()!="")
				{
					model.ReasonDesc1=ds.Tables[0].Rows[0]["ReasonDesc1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ReasonDesc2"]!=null && ds.Tables[0].Rows[0]["ReasonDesc2"].ToString()!="")
				{
					model.ReasonDesc2=ds.Tables[0].Rows[0]["ReasonDesc2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ReasonDesc3"]!=null && ds.Tables[0].Rows[0]["ReasonDesc3"].ToString()!="")
				{
					model.ReasonDesc3=ds.Tables[0].Rows[0]["ReasonDesc3"].ToString();
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
					model.UpdatedBy=int.Parse(ds.Tables[0].Rows[0]["UpdatedBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedBy"]!=null && ds.Tables[0].Rows[0]["CreatedBy"].ToString()!="")
				{
					model.CreatedBy=int.Parse(ds.Tables[0].Rows[0]["CreatedBy"].ToString());
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
			strSql.Append("select ReasonID,ReasonCode,ReasonDesc1,ReasonDesc2,ReasonDesc3,CreatedOn,UpdatedOn,UpdatedBy,CreatedBy ");
			strSql.Append(" FROM Reason ");
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
			strSql.Append(" ReasonID,ReasonCode,ReasonDesc1,ReasonDesc2,ReasonDesc3,CreatedOn,UpdatedOn,UpdatedBy,CreatedBy ");
			strSql.Append(" FROM Reason ");
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
            parameters[0].Value = "Reason";
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
            sql.Append("select count(*) from Reason ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

