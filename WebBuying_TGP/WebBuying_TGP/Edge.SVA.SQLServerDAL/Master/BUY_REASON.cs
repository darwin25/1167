using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_REASON
	/// </summary>
	public partial class BUY_REASON:IBUY_REASON
	{
		public BUY_REASON()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ReasonID", "BUY_REASON"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ReasonCode,int ReasonID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_REASON");
			strSql.Append(" where ReasonCode=@ReasonCode and ReasonID=@ReasonID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReasonCode", SqlDbType.VarChar,64),
					new SqlParameter("@ReasonID", SqlDbType.Int,4)			};
			parameters[0].Value = ReasonCode;
			parameters[1].Value = ReasonID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.BUY_REASON model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_REASON(");
			strSql.Append("ReasonCode,Description1,Description2,Description3,UpdatedOn,UpdatedBy,CreatedOn,CreatedBy)");
			strSql.Append(" values (");
			strSql.Append("@ReasonCode,@Description1,@Description2,@Description3,@UpdatedOn,@UpdatedBy,@CreatedOn,@CreatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ReasonCode", SqlDbType.VarChar,64),
					new SqlParameter("@Description1", SqlDbType.NVarChar,512),
					new SqlParameter("@Description2", SqlDbType.NVarChar,512),
					new SqlParameter("@Description3", SqlDbType.NVarChar,512),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.ReasonCode;
			parameters[1].Value = model.Description1;
			parameters[2].Value = model.Description2;
			parameters[3].Value = model.Description3;
			parameters[4].Value = model.UpdatedOn;
			parameters[5].Value = model.UpdatedBy;
			parameters[6].Value = model.CreatedOn;
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
		public bool Update(Edge.SVA.Model.BUY_REASON model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_REASON set ");
			strSql.Append("Description1=@Description1,");
			strSql.Append("Description2=@Description2,");
			strSql.Append("Description3=@Description3,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy");
			strSql.Append(" where ReasonID=@ReasonID");
			SqlParameter[] parameters = {
					new SqlParameter("@Description1", SqlDbType.NVarChar,512),
					new SqlParameter("@Description2", SqlDbType.NVarChar,512),
					new SqlParameter("@Description3", SqlDbType.NVarChar,512),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@ReasonID", SqlDbType.Int,4),
					new SqlParameter("@ReasonCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.Description1;
			parameters[1].Value = model.Description2;
			parameters[2].Value = model.Description3;
			parameters[3].Value = model.UpdatedOn;
			parameters[4].Value = model.UpdatedBy;
			parameters[5].Value = model.CreatedOn;
			parameters[6].Value = model.CreatedBy;
			parameters[7].Value = model.ReasonID;
			parameters[8].Value = model.ReasonCode;

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
			strSql.Append("delete from BUY_REASON ");
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ReasonCode,int ReasonID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_REASON ");
			strSql.Append(" where ReasonCode=@ReasonCode and ReasonID=@ReasonID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReasonCode", SqlDbType.VarChar,64),
					new SqlParameter("@ReasonID", SqlDbType.Int,4)			};
			parameters[0].Value = ReasonCode;
			parameters[1].Value = ReasonID;

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
			strSql.Append("delete from BUY_REASON ");
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
		public Edge.SVA.Model.BUY_REASON GetModel(int ReasonID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ReasonID,ReasonCode,Description1,Description2,Description3,UpdatedOn,UpdatedBy,CreatedOn,CreatedBy from BUY_REASON ");
			strSql.Append(" where ReasonID=@ReasonID");
			SqlParameter[] parameters = {
					new SqlParameter("@ReasonID", SqlDbType.Int,4)
			};
			parameters[0].Value = ReasonID;

			Edge.SVA.Model.BUY_REASON model=new Edge.SVA.Model.BUY_REASON();
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
				if(ds.Tables[0].Rows[0]["Description1"]!=null && ds.Tables[0].Rows[0]["Description1"].ToString()!="")
				{
					model.Description1=ds.Tables[0].Rows[0]["Description1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Description2"]!=null && ds.Tables[0].Rows[0]["Description2"].ToString()!="")
				{
					model.Description2=ds.Tables[0].Rows[0]["Description2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Description3"]!=null && ds.Tables[0].Rows[0]["Description3"].ToString()!="")
				{
					model.Description3=ds.Tables[0].Rows[0]["Description3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["UpdatedOn"]!=null && ds.Tables[0].Rows[0]["UpdatedOn"].ToString()!="")
				{
					model.UpdatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedOn"].ToString());
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
			strSql.Append("select ReasonID,ReasonCode,Description1,Description2,Description3,UpdatedOn,UpdatedBy,CreatedOn,CreatedBy ");
			strSql.Append(" FROM BUY_REASON ");
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
			strSql.Append(" ReasonID,ReasonCode,Description1,Description2,Description3,UpdatedOn,UpdatedBy,CreatedOn,CreatedBy ");
			strSql.Append(" FROM BUY_REASON ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM BUY_REASON ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ReasonID desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_REASON T ");
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
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "BUY_REASON";
			parameters[1].Value = "ReasonID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

