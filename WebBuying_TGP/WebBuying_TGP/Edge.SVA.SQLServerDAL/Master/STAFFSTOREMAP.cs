using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:STAFFSTOREMAP
	/// </summary>
	public partial class STAFFSTOREMAP:ISTAFFSTOREMAP
	{
		public STAFFSTOREMAP()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StaffID,int StoreID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from STAFFSTOREMAP");
			strSql.Append(" where StaffID=@StaffID and StoreID=@StoreID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@StoreID", SqlDbType.Int,4)			};
			parameters[0].Value = StaffID;
			parameters[1].Value = StoreID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.STAFFSTOREMAP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into STAFFSTOREMAP(");
			strSql.Append("StaffID,StoreID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@StaffID,@StoreID,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@StoreID", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.StaffID;
			parameters[1].Value = model.StoreID;
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
		public bool Update(Edge.SVA.Model.STAFFSTOREMAP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update STAFFSTOREMAP set ");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where StaffID=@StaffID and StoreID=@StoreID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@StoreID", SqlDbType.Int,4)};
			parameters[0].Value = model.CreatedOn;
			parameters[1].Value = model.CreatedBy;
			parameters[2].Value = model.UpdatedOn;
			parameters[3].Value = model.UpdatedBy;
			parameters[4].Value = model.StaffID;
			parameters[5].Value = model.StoreID;

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
		public bool Delete(int StaffID,int StoreID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from STAFFSTOREMAP ");
			strSql.Append(" where StaffID=@StaffID and StoreID=@StoreID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@StoreID", SqlDbType.Int,4)			};
			parameters[0].Value = StaffID;
			parameters[1].Value = StoreID;

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
		public Edge.SVA.Model.STAFFSTOREMAP GetModel(int StaffID,int StoreID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StaffID,StoreID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from STAFFSTOREMAP ");
			strSql.Append(" where StaffID=@StaffID and StoreID=@StoreID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@StoreID", SqlDbType.Int,4)			};
			parameters[0].Value = StaffID;
			parameters[1].Value = StoreID;

			Edge.SVA.Model.STAFFSTOREMAP model=new Edge.SVA.Model.STAFFSTOREMAP();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["StaffID"]!=null && ds.Tables[0].Rows[0]["StaffID"].ToString()!="")
				{
					model.StaffID=int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StoreID"]!=null && ds.Tables[0].Rows[0]["StoreID"].ToString()!="")
				{
					model.StoreID=int.Parse(ds.Tables[0].Rows[0]["StoreID"].ToString());
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
			strSql.Append("select StaffID,StoreID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM STAFFSTOREMAP ");
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
			strSql.Append(" StaffID,StoreID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM STAFFSTOREMAP ");
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
			strSql.Append("select count(1) FROM STAFFSTOREMAP ");
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
				strSql.Append("order by T.StoreID desc");
			}
			strSql.Append(")AS Row, T.*  from STAFFSTOREMAP T ");
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
			parameters[0].Value = "STAFFSTOREMAP";
			parameters[1].Value = "StoreID";
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

