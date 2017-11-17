using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_Product_Catalog
	/// </summary>
	public partial class BUY_Product_Catalog:IBUY_Product_Catalog
	{
		public BUY_Product_Catalog()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ProdCode,string DepartCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_Product_Catalog");
			strSql.Append(" where ProdCode=@ProdCode and DepartCode=@DepartCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@DepartCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = ProdCode;
			parameters[1].Value = DepartCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_Product_Catalog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_Product_Catalog(");
			strSql.Append("ProdCode,DepartCode,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@ProdCode,@DepartCode,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@DepartCode", SqlDbType.VarChar,64),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.ProdCode;
			parameters[1].Value = model.DepartCode;
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
		public bool Update(Edge.SVA.Model.BUY_Product_Catalog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_Product_Catalog set ");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where ProdCode=@ProdCode and DepartCode=@DepartCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@DepartCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.CreatedOn;
			parameters[1].Value = model.CreatedBy;
			parameters[2].Value = model.UpdatedOn;
			parameters[3].Value = model.UpdatedBy;
			parameters[4].Value = model.ProdCode;
			parameters[5].Value = model.DepartCode;

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
		public bool Delete(string ProdCode,string DepartCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_Product_Catalog ");
			strSql.Append(" where ProdCode=@ProdCode and DepartCode=@DepartCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@DepartCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = ProdCode;
			parameters[1].Value = DepartCode;

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
		public Edge.SVA.Model.BUY_Product_Catalog GetModel(string ProdCode,string DepartCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProdCode,DepartCode,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_Product_Catalog ");
			strSql.Append(" where ProdCode=@ProdCode and DepartCode=@DepartCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@DepartCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = ProdCode;
			parameters[1].Value = DepartCode;

			Edge.SVA.Model.BUY_Product_Catalog model=new Edge.SVA.Model.BUY_Product_Catalog();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public Edge.SVA.Model.BUY_Product_Catalog DataRowToModel(DataRow row)
		{
			Edge.SVA.Model.BUY_Product_Catalog model=new Edge.SVA.Model.BUY_Product_Catalog();
			if (row != null)
			{
				if(row["ProdCode"]!=null)
				{
					model.ProdCode=row["ProdCode"].ToString();
				}
				if(row["DepartCode"]!=null)
				{
					model.DepartCode=row["DepartCode"].ToString();
				}
				if(row["CreatedOn"]!=null && row["CreatedOn"].ToString()!="")
				{
					model.CreatedOn=DateTime.Parse(row["CreatedOn"].ToString());
				}
				if(row["CreatedBy"]!=null && row["CreatedBy"].ToString()!="")
				{
					model.CreatedBy=int.Parse(row["CreatedBy"].ToString());
				}
				if(row["UpdatedOn"]!=null && row["UpdatedOn"].ToString()!="")
				{
					model.UpdatedOn=DateTime.Parse(row["UpdatedOn"].ToString());
				}
				if(row["UpdatedBy"]!=null && row["UpdatedBy"].ToString()!="")
				{
					model.UpdatedBy=int.Parse(row["UpdatedBy"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ProdCode,DepartCode,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_Product_Catalog ");
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
			strSql.Append(" ProdCode,DepartCode,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_Product_Catalog ");
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
			strSql.Append("select count(1) FROM BUY_Product_Catalog ");
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
				strSql.Append("order by T.DepartCode desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_Product_Catalog T ");
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
			parameters[0].Value = "BUY_Product_Catalog";
			parameters[1].Value = "DepartCode";
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

