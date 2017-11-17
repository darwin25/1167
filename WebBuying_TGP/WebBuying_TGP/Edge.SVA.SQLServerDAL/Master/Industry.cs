using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Industry
	/// </summary>
	public partial class Industry:IIndustry
	{
		public Industry()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("IndustryID", "Industry"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int IndustryID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Industry");
			strSql.Append(" where IndustryID=@IndustryID");
			SqlParameter[] parameters = {
					new SqlParameter("@IndustryID", SqlDbType.Int,4)
};
			parameters[0].Value = IndustryID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.Industry model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Industry(");
			strSql.Append("IndustryName1,IndustryName2,IndustryName3,UpdatedBy,CreatedOn,CreatedBy,UpdatedOn,IndustryCode)");
			strSql.Append(" values (");
			strSql.Append("@IndustryName1,@IndustryName2,@IndustryName3,@UpdatedBy,@CreatedOn,@CreatedBy,@UpdatedOn,@IndustryCode)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@IndustryName1", SqlDbType.NVarChar,512),
					new SqlParameter("@IndustryName2", SqlDbType.NVarChar,512),
					new SqlParameter("@IndustryName3", SqlDbType.NVarChar,512),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@IndustryCode", SqlDbType.VarChar,512)};
			parameters[0].Value = model.IndustryName1;
			parameters[1].Value = model.IndustryName2;
			parameters[2].Value = model.IndustryName3;
			parameters[3].Value = model.UpdatedBy;
			parameters[4].Value = model.CreatedOn;
			parameters[5].Value = model.CreatedBy;
			parameters[6].Value = model.UpdatedOn;
			parameters[7].Value = model.IndustryCode;

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
		public bool Update(Edge.SVA.Model.Industry model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Industry set ");
			strSql.Append("IndustryName1=@IndustryName1,");
			strSql.Append("IndustryName2=@IndustryName2,");
			strSql.Append("IndustryName3=@IndustryName3,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("IndustryCode=@IndustryCode");
			strSql.Append(" where IndustryID=@IndustryID");
			SqlParameter[] parameters = {
					new SqlParameter("@IndustryName1", SqlDbType.NVarChar,512),
					new SqlParameter("@IndustryName2", SqlDbType.NVarChar,512),
					new SqlParameter("@IndustryName3", SqlDbType.NVarChar,512),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@IndustryCode", SqlDbType.VarChar,512),
					new SqlParameter("@IndustryID", SqlDbType.Int,4)};
			parameters[0].Value = model.IndustryName1;
			parameters[1].Value = model.IndustryName2;
			parameters[2].Value = model.IndustryName3;
			parameters[3].Value = model.UpdatedBy;
			parameters[4].Value = model.CreatedOn;
			parameters[5].Value = model.CreatedBy;
			parameters[6].Value = model.UpdatedOn;
			parameters[7].Value = model.IndustryCode;
			parameters[8].Value = model.IndustryID;

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
		public bool Delete(int IndustryID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Industry ");
			strSql.Append(" where IndustryID=@IndustryID");
			SqlParameter[] parameters = {
					new SqlParameter("@IndustryID", SqlDbType.Int,4)
};
			parameters[0].Value = IndustryID;

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
		public bool DeleteList(string IndustryIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Industry ");
			strSql.Append(" where IndustryID in ("+IndustryIDlist + ")  ");
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
		public Edge.SVA.Model.Industry GetModel(int IndustryID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 IndustryID,IndustryName1,IndustryName2,IndustryName3,UpdatedBy,CreatedOn,CreatedBy,UpdatedOn,IndustryCode from Industry ");
			strSql.Append(" where IndustryID=@IndustryID");
			SqlParameter[] parameters = {
					new SqlParameter("@IndustryID", SqlDbType.Int,4)
};
			parameters[0].Value = IndustryID;

			Edge.SVA.Model.Industry model=new Edge.SVA.Model.Industry();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["IndustryID"]!=null && ds.Tables[0].Rows[0]["IndustryID"].ToString()!="")
				{
					model.IndustryID=int.Parse(ds.Tables[0].Rows[0]["IndustryID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IndustryName1"]!=null && ds.Tables[0].Rows[0]["IndustryName1"].ToString()!="")
				{
					model.IndustryName1=ds.Tables[0].Rows[0]["IndustryName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["IndustryName2"]!=null && ds.Tables[0].Rows[0]["IndustryName2"].ToString()!="")
				{
					model.IndustryName2=ds.Tables[0].Rows[0]["IndustryName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["IndustryName3"]!=null && ds.Tables[0].Rows[0]["IndustryName3"].ToString()!="")
				{
					model.IndustryName3=ds.Tables[0].Rows[0]["IndustryName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["UpdatedBy"]!=null && ds.Tables[0].Rows[0]["UpdatedBy"].ToString()!="")
				{
					model.UpdatedBy=int.Parse(ds.Tables[0].Rows[0]["UpdatedBy"].ToString());
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
				if(ds.Tables[0].Rows[0]["IndustryCode"]!=null && ds.Tables[0].Rows[0]["IndustryCode"].ToString()!="")
				{
					model.IndustryCode=ds.Tables[0].Rows[0]["IndustryCode"].ToString();
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
			strSql.Append("select IndustryID,IndustryName1,IndustryName2,IndustryName3,UpdatedBy,CreatedOn,CreatedBy,UpdatedOn,IndustryCode ");
			strSql.Append(" FROM Industry ");
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
			strSql.Append(" IndustryID,IndustryName1,IndustryName2,IndustryName3,UpdatedBy,CreatedOn,CreatedBy,UpdatedOn,IndustryCode ");
			strSql.Append(" FROM Industry ");
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
            parameters[0].Value = "Industry";
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
            sql.Append("select count(*) from Industry ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

