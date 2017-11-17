using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_STOCKSET
	/// </summary>
	public partial class BUY_STOCKSET:IBUY_STOCKSET
	{
		public BUY_STOCKSET()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "BUY_STOCKSET"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_STOCKSET");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
			parameters[0].Value = KeyID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.BUY_STOCKSET model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_STOCKSET(");
			strSql.Append("ProdCode,StoreCode,ReOrder,MaxReOrder,StockHolding)");
			strSql.Append(" values (");
			strSql.Append("@ProdCode,@StoreCode,@ReOrder,@MaxReOrder,@StockHolding)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@ReOrder", SqlDbType.Decimal,9),
					new SqlParameter("@MaxReOrder", SqlDbType.Decimal,9),
					new SqlParameter("@StockHolding", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ProdCode;
			parameters[1].Value = model.StoreCode;
			parameters[2].Value = model.ReOrder;
			parameters[3].Value = model.MaxReOrder;
			parameters[4].Value = model.StockHolding;

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
		public bool Update(Edge.SVA.Model.BUY_STOCKSET model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_STOCKSET set ");
			strSql.Append("ProdCode=@ProdCode,");
			strSql.Append("StoreCode=@StoreCode,");
			strSql.Append("ReOrder=@ReOrder,");
			strSql.Append("MaxReOrder=@MaxReOrder,");
			strSql.Append("StockHolding=@StockHolding");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@ReOrder", SqlDbType.Decimal,9),
					new SqlParameter("@MaxReOrder", SqlDbType.Decimal,9),
					new SqlParameter("@StockHolding", SqlDbType.Decimal,9),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.ProdCode;
			parameters[1].Value = model.StoreCode;
			parameters[2].Value = model.ReOrder;
			parameters[3].Value = model.MaxReOrder;
			parameters[4].Value = model.StockHolding;
			parameters[5].Value = model.KeyID;

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
		public bool Delete(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_STOCKSET ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
			parameters[0].Value = KeyID;

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
		public bool DeleteList(string KeyIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_STOCKSET ");
			strSql.Append(" where KeyID in ("+KeyIDlist + ")  ");
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
		public Edge.SVA.Model.BUY_STOCKSET GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,ProdCode,StoreCode,ReOrder,MaxReOrder,StockHolding from BUY_STOCKSET ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.BUY_STOCKSET model=new Edge.SVA.Model.BUY_STOCKSET();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProdCode"]!=null && ds.Tables[0].Rows[0]["ProdCode"].ToString()!="")
				{
					model.ProdCode=ds.Tables[0].Rows[0]["ProdCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreCode"]!=null && ds.Tables[0].Rows[0]["StoreCode"].ToString()!="")
				{
					model.StoreCode=ds.Tables[0].Rows[0]["StoreCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ReOrder"]!=null && ds.Tables[0].Rows[0]["ReOrder"].ToString()!="")
				{
					model.ReOrder=decimal.Parse(ds.Tables[0].Rows[0]["ReOrder"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MaxReOrder"]!=null && ds.Tables[0].Rows[0]["MaxReOrder"].ToString()!="")
				{
					model.MaxReOrder=decimal.Parse(ds.Tables[0].Rows[0]["MaxReOrder"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StockHolding"]!=null && ds.Tables[0].Rows[0]["StockHolding"].ToString()!="")
				{
					model.StockHolding=decimal.Parse(ds.Tables[0].Rows[0]["StockHolding"].ToString());
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
			strSql.Append("select KeyID,ProdCode,StoreCode,ReOrder,MaxReOrder,StockHolding ");
			strSql.Append(" FROM BUY_STOCKSET ");
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
			strSql.Append(" KeyID,ProdCode,StoreCode,ReOrder,MaxReOrder,StockHolding ");
			strSql.Append(" FROM BUY_STOCKSET ");
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
			strSql.Append("select count(1) FROM BUY_STOCKSET ");
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
				strSql.Append("order by T.KeyID desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_STOCKSET T ");
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
			parameters[0].Value = "BUY_STOCKSET";
			parameters[1].Value = "KeyID";
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

