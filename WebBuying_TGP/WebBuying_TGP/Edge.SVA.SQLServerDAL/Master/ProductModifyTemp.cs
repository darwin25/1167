using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:ProductModifyTemp
	/// </summary>
	public partial class ProductModifyTemp:IProductModifyTemp
	{
		public ProductModifyTemp()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ProdCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductModifyTemp");
			strSql.Append(" where ProdCode=@ProdCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = ProdCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.ProductModifyTemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductModifyTemp(");
			strSql.Append("ProdCode,IsOnlineSKU,Feature,HotSale,Price,RefPrice,Status,CreatedOn)");
			strSql.Append(" values (");
			strSql.Append("@ProdCode,@IsOnlineSKU,@Feature,@HotSale,@Price,@RefPrice,@Status,@CreatedOn)");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@IsOnlineSKU", SqlDbType.TinyInt,1),
					new SqlParameter("@Feature", SqlDbType.TinyInt,1),
					new SqlParameter("@HotSale", SqlDbType.TinyInt,1),
					new SqlParameter("@Price", SqlDbType.Money,8),
					new SqlParameter("@RefPrice", SqlDbType.Money,8),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime)};
			parameters[0].Value = model.ProdCode;
			parameters[1].Value = model.IsOnlineSKU;
			parameters[2].Value = model.Feature;
			parameters[3].Value = model.HotSale;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.RefPrice;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.CreatedOn;

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
		public bool Update(Edge.SVA.Model.ProductModifyTemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductModifyTemp set ");
			strSql.Append("IsOnlineSKU=@IsOnlineSKU,");
			strSql.Append("Feature=@Feature,");
			strSql.Append("HotSale=@HotSale,");
			strSql.Append("Price=@Price,");
			strSql.Append("RefPrice=@RefPrice,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreatedOn=@CreatedOn");
			strSql.Append(" where ProdCode=@ProdCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@IsOnlineSKU", SqlDbType.TinyInt,1),
					new SqlParameter("@Feature", SqlDbType.TinyInt,1),
					new SqlParameter("@HotSale", SqlDbType.TinyInt,1),
					new SqlParameter("@Price", SqlDbType.Money,8),
					new SqlParameter("@RefPrice", SqlDbType.Money,8),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.IsOnlineSKU;
			parameters[1].Value = model.Feature;
			parameters[2].Value = model.HotSale;
			parameters[3].Value = model.Price;
			parameters[4].Value = model.RefPrice;
			parameters[5].Value = model.Status;
			parameters[6].Value = model.CreatedOn;
			parameters[7].Value = model.ProdCode;

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
		public bool Delete(string ProdCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductModifyTemp ");
			strSql.Append(" where ProdCode=@ProdCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = ProdCode;

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
		public bool DeleteList(string ProdCodelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductModifyTemp ");
			strSql.Append(" where ProdCode in ("+ProdCodelist + ")  ");
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
		public Edge.SVA.Model.ProductModifyTemp GetModel(string ProdCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProdCode,IsOnlineSKU,Feature,HotSale,Price,RefPrice,Status,CreatedOn from ProductModifyTemp ");
			strSql.Append(" where ProdCode=@ProdCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = ProdCode;

			Edge.SVA.Model.ProductModifyTemp model=new Edge.SVA.Model.ProductModifyTemp();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProdCode"]!=null && ds.Tables[0].Rows[0]["ProdCode"].ToString()!="")
				{
					model.ProdCode=ds.Tables[0].Rows[0]["ProdCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["IsOnlineSKU"]!=null && ds.Tables[0].Rows[0]["IsOnlineSKU"].ToString()!="")
				{
					model.IsOnlineSKU=int.Parse(ds.Tables[0].Rows[0]["IsOnlineSKU"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Feature"]!=null && ds.Tables[0].Rows[0]["Feature"].ToString()!="")
				{
					model.Feature=int.Parse(ds.Tables[0].Rows[0]["Feature"].ToString());
				}
				if(ds.Tables[0].Rows[0]["HotSale"]!=null && ds.Tables[0].Rows[0]["HotSale"].ToString()!="")
				{
					model.HotSale=int.Parse(ds.Tables[0].Rows[0]["HotSale"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"]!=null && ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RefPrice"]!=null && ds.Tables[0].Rows[0]["RefPrice"].ToString()!="")
				{
					model.RefPrice=decimal.Parse(ds.Tables[0].Rows[0]["RefPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedOn"]!=null && ds.Tables[0].Rows[0]["CreatedOn"].ToString()!="")
				{
					model.CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
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
			strSql.Append("select ProdCode,IsOnlineSKU,Feature,HotSale,Price,RefPrice,Status,CreatedOn ");
			strSql.Append(" FROM ProductModifyTemp ");
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
			strSql.Append(" ProdCode,IsOnlineSKU,Feature,HotSale,Price,RefPrice,Status,CreatedOn ");
			strSql.Append(" FROM ProductModifyTemp ");
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
			strSql.Append("select count(1) FROM ProductModifyTemp ");
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
				strSql.Append("order by T.ProdCode desc");
			}
			strSql.Append(")AS Row, T.*  from ProductModifyTemp T ");
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
			parameters[0].Value = "ProductModifyTemp";
			parameters[1].Value = "ProdCode";
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

