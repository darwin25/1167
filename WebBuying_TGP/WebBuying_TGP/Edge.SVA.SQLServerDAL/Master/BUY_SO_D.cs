using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_SO_D
	/// </summary>
	public partial class BUY_SO_D:IBUY_SO_D
	{
		public BUY_SO_D()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "BUY_SO_D"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_SO_D");
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
		public int Add(Edge.SVA.Model.BUY_SO_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_SO_D(");
			strSql.Append("StoreCode,POCode,ProdCode,Cost,AverageCost,UnitCost,Qty,FreeQty,GRNQty)");
			strSql.Append(" values (");
			strSql.Append("@StoreCode,@POCode,@ProdCode,@Cost,@AverageCost,@UnitCost,@Qty,@FreeQty,@GRNQty)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@POCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@Cost", SqlDbType.Decimal,9),
					new SqlParameter("@AverageCost", SqlDbType.Decimal,9),
					new SqlParameter("@UnitCost", SqlDbType.Decimal,9),
					new SqlParameter("@Qty", SqlDbType.Decimal,9),
					new SqlParameter("@FreeQty", SqlDbType.Decimal,9),
					new SqlParameter("@GRNQty", SqlDbType.Decimal,9)};
			parameters[0].Value = model.StoreCode;
			parameters[1].Value = model.POCode;
			parameters[2].Value = model.ProdCode;
			parameters[3].Value = model.Cost;
			parameters[4].Value = model.AverageCost;
			parameters[5].Value = model.UnitCost;
			parameters[6].Value = model.Qty;
			parameters[7].Value = model.FreeQty;
			parameters[8].Value = model.GRNQty;

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
		public bool Update(Edge.SVA.Model.BUY_SO_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_SO_D set ");
			strSql.Append("StoreCode=@StoreCode,");
			strSql.Append("POCode=@POCode,");
			strSql.Append("ProdCode=@ProdCode,");
			strSql.Append("Cost=@Cost,");
			strSql.Append("AverageCost=@AverageCost,");
			strSql.Append("UnitCost=@UnitCost,");
			strSql.Append("Qty=@Qty,");
			strSql.Append("FreeQty=@FreeQty,");
			strSql.Append("GRNQty=@GRNQty");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@POCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@Cost", SqlDbType.Decimal,9),
					new SqlParameter("@AverageCost", SqlDbType.Decimal,9),
					new SqlParameter("@UnitCost", SqlDbType.Decimal,9),
					new SqlParameter("@Qty", SqlDbType.Decimal,9),
					new SqlParameter("@FreeQty", SqlDbType.Decimal,9),
					new SqlParameter("@GRNQty", SqlDbType.Decimal,9),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.StoreCode;
			parameters[1].Value = model.POCode;
			parameters[2].Value = model.ProdCode;
			parameters[3].Value = model.Cost;
			parameters[4].Value = model.AverageCost;
			parameters[5].Value = model.UnitCost;
			parameters[6].Value = model.Qty;
			parameters[7].Value = model.FreeQty;
			parameters[8].Value = model.GRNQty;
			parameters[9].Value = model.KeyID;

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
			strSql.Append("delete from BUY_SO_D ");
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
			strSql.Append("delete from BUY_SO_D ");
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
		public Edge.SVA.Model.BUY_SO_D GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,StoreCode,POCode,ProdCode,Cost,AverageCost,UnitCost,Qty,FreeQty,GRNQty from BUY_SO_D ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.BUY_SO_D model=new Edge.SVA.Model.BUY_SO_D();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StoreCode"]!=null && ds.Tables[0].Rows[0]["StoreCode"].ToString()!="")
				{
					model.StoreCode=ds.Tables[0].Rows[0]["StoreCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["POCode"]!=null && ds.Tables[0].Rows[0]["POCode"].ToString()!="")
				{
					model.POCode=ds.Tables[0].Rows[0]["POCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProdCode"]!=null && ds.Tables[0].Rows[0]["ProdCode"].ToString()!="")
				{
					model.ProdCode=ds.Tables[0].Rows[0]["ProdCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Cost"]!=null && ds.Tables[0].Rows[0]["Cost"].ToString()!="")
				{
					model.Cost=decimal.Parse(ds.Tables[0].Rows[0]["Cost"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AverageCost"]!=null && ds.Tables[0].Rows[0]["AverageCost"].ToString()!="")
				{
					model.AverageCost=decimal.Parse(ds.Tables[0].Rows[0]["AverageCost"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UnitCost"]!=null && ds.Tables[0].Rows[0]["UnitCost"].ToString()!="")
				{
					model.UnitCost=decimal.Parse(ds.Tables[0].Rows[0]["UnitCost"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Qty"]!=null && ds.Tables[0].Rows[0]["Qty"].ToString()!="")
				{
					model.Qty=decimal.Parse(ds.Tables[0].Rows[0]["Qty"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FreeQty"]!=null && ds.Tables[0].Rows[0]["FreeQty"].ToString()!="")
				{
					model.FreeQty=decimal.Parse(ds.Tables[0].Rows[0]["FreeQty"].ToString());
				}
				if(ds.Tables[0].Rows[0]["GRNQty"]!=null && ds.Tables[0].Rows[0]["GRNQty"].ToString()!="")
				{
					model.GRNQty=decimal.Parse(ds.Tables[0].Rows[0]["GRNQty"].ToString());
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
			strSql.Append("select KeyID,StoreCode,POCode,ProdCode,Cost,AverageCost,UnitCost,Qty,FreeQty,GRNQty ");
			strSql.Append(" FROM BUY_SO_D ");
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
			strSql.Append(" KeyID,StoreCode,POCode,ProdCode,Cost,AverageCost,UnitCost,Qty,FreeQty,GRNQty ");
			strSql.Append(" FROM BUY_SO_D ");
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
			strSql.Append("select count(1) FROM BUY_SO_D ");
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
			strSql.Append(")AS Row, T.*  from BUY_SO_D T ");
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
			parameters[0].Value = "BUY_SO_D";
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

