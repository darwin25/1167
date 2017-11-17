using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_SGLINK
	/// </summary>
	public partial class BUY_SGLINK:IBUY_SGLINK
	{
		public BUY_SGLINK()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string StoreGroupCode,string StoreCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_SGLINK");
			strSql.Append(" where StoreGroupCode=@StoreGroupCode and StoreCode=@StoreCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreGroupCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = StoreGroupCode;
			parameters[1].Value = StoreCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_SGLINK model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_SGLINK(");
			strSql.Append("StoreGroupCode,StoreCode,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@StoreGroupCode,@StoreCode,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreGroupCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.StoreGroupCode;
			parameters[1].Value = model.StoreCode;
			parameters[2].Value = model.CreatedOn;
			parameters[3].Value = model.CreatedBy;
			parameters[4].Value = model.UpdatedOn;
			parameters[5].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.BUY_SGLINK model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_SGLINK set ");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where StoreGroupCode=@StoreGroupCode and StoreCode=@StoreCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@StoreGroupCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.CreatedOn;
			parameters[1].Value = model.CreatedBy;
			parameters[2].Value = model.UpdatedOn;
			parameters[3].Value = model.UpdatedBy;
			parameters[4].Value = model.StoreGroupCode;
			parameters[5].Value = model.StoreCode;

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
		public bool Delete(string StoreGroupCode,string StoreCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_SGLINK ");
			strSql.Append(" where StoreGroupCode=@StoreGroupCode and StoreCode=@StoreCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreGroupCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = StoreGroupCode;
			parameters[1].Value = StoreCode;

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
		public Edge.SVA.Model.BUY_SGLINK GetModel(string StoreGroupCode,string StoreCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StoreGroupCode,StoreCode,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_SGLINK ");
			strSql.Append(" where StoreGroupCode=@StoreGroupCode and StoreCode=@StoreCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreGroupCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = StoreGroupCode;
			parameters[1].Value = StoreCode;

			Edge.SVA.Model.BUY_SGLINK model=new Edge.SVA.Model.BUY_SGLINK();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["StoreGroupCode"]!=null && ds.Tables[0].Rows[0]["StoreGroupCode"].ToString()!="")
				{
					model.StoreGroupCode=ds.Tables[0].Rows[0]["StoreGroupCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreCode"]!=null && ds.Tables[0].Rows[0]["StoreCode"].ToString()!="")
				{
					model.StoreCode=ds.Tables[0].Rows[0]["StoreCode"].ToString();
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
			strSql.Append("select StoreGroupCode,StoreCode,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_SGLINK ");
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
			strSql.Append(" StoreGroupCode,StoreCode,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_SGLINK ");
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
			strSql.Append("select count(1) FROM BUY_SGLINK ");
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
				strSql.Append("order by T.StoreCode desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_SGLINK T ");
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
			parameters[0].Value = "BUY_SGLINK";
			parameters[1].Value = "StoreCode";
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

