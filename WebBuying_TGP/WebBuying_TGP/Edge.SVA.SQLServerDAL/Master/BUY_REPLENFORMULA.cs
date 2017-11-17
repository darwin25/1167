using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_REPLENFORMULA
    /// 创建人：lisa
    /// 创建时间：2016-07-13
	/// </summary>
	public partial class BUY_REPLENFORMULA:IBUY_REPLENFORMULA
	{
		public BUY_REPLENFORMULA()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ReplenFormulaID", "BUY_REPLENFORMULA"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ReplenFormulaCode,int ReplenFormulaID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_REPLENFORMULA");
			strSql.Append(" where ReplenFormulaCode=@ReplenFormulaCode and ReplenFormulaID=@ReplenFormulaID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReplenFormulaCode", SqlDbType.VarChar,64),
					new SqlParameter("@ReplenFormulaID", SqlDbType.Int,4)			};
			parameters[0].Value = ReplenFormulaCode;
			parameters[1].Value = ReplenFormulaID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.BUY_REPLENFORMULA model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_REPLENFORMULA(");
			strSql.Append("ReplenFormulaCode,Description,PreDefineDOC,RunningStockDOC,OrderRoundUpQty,AVGDailySalesPeriod,Quotation,Deposited,AdvSales,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@ReplenFormulaCode,@Description,@PreDefineDOC,@RunningStockDOC,@OrderRoundUpQty,@AVGDailySalesPeriod,@Quotation,@Deposited,@AdvSales,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ReplenFormulaCode", SqlDbType.VarChar,64),
					new SqlParameter("@Description", SqlDbType.VarChar,512),
					new SqlParameter("@PreDefineDOC", SqlDbType.Int,4),
					new SqlParameter("@RunningStockDOC", SqlDbType.Int,4),
					new SqlParameter("@OrderRoundUpQty", SqlDbType.Int,4),
					new SqlParameter("@AVGDailySalesPeriod", SqlDbType.Int,4),
					new SqlParameter("@Quotation", SqlDbType.Int,4),
					new SqlParameter("@Deposited", SqlDbType.Int,4),
					new SqlParameter("@AdvSales", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.ReplenFormulaCode;
			parameters[1].Value = model.Description;
			parameters[2].Value = model.PreDefineDOC;
			parameters[3].Value = model.RunningStockDOC;
			parameters[4].Value = model.OrderRoundUpQty;
			parameters[5].Value = model.AVGDailySalesPeriod;
			parameters[6].Value = model.Quotation;
			parameters[7].Value = model.Deposited;
			parameters[8].Value = model.AdvSales;
			parameters[9].Value = model.CreatedOn;
			parameters[10].Value = model.CreatedBy;
			parameters[11].Value = model.UpdatedOn;
			parameters[12].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.BUY_REPLENFORMULA model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_REPLENFORMULA set ");
			strSql.Append("Description=@Description,");
			strSql.Append("PreDefineDOC=@PreDefineDOC,");
			strSql.Append("RunningStockDOC=@RunningStockDOC,");
			strSql.Append("OrderRoundUpQty=@OrderRoundUpQty,");
			strSql.Append("AVGDailySalesPeriod=@AVGDailySalesPeriod,");
			strSql.Append("Quotation=@Quotation,");
			strSql.Append("Deposited=@Deposited,");
			strSql.Append("AdvSales=@AdvSales,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where ReplenFormulaID=@ReplenFormulaID");
			SqlParameter[] parameters = {
					new SqlParameter("@Description", SqlDbType.VarChar,512),
					new SqlParameter("@PreDefineDOC", SqlDbType.Int,4),
					new SqlParameter("@RunningStockDOC", SqlDbType.Int,4),
					new SqlParameter("@OrderRoundUpQty", SqlDbType.Int,4),
					new SqlParameter("@AVGDailySalesPeriod", SqlDbType.Int,4),
					new SqlParameter("@Quotation", SqlDbType.Int,4),
					new SqlParameter("@Deposited", SqlDbType.Int,4),
					new SqlParameter("@AdvSales", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@ReplenFormulaID", SqlDbType.Int,4),
					new SqlParameter("@ReplenFormulaCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.Description;
			parameters[1].Value = model.PreDefineDOC;
			parameters[2].Value = model.RunningStockDOC;
			parameters[3].Value = model.OrderRoundUpQty;
			parameters[4].Value = model.AVGDailySalesPeriod;
			parameters[5].Value = model.Quotation;
			parameters[6].Value = model.Deposited;
			parameters[7].Value = model.AdvSales;
			parameters[8].Value = model.CreatedOn;
			parameters[9].Value = model.CreatedBy;
			parameters[10].Value = model.UpdatedOn;
			parameters[11].Value = model.UpdatedBy;
			parameters[12].Value = model.ReplenFormulaID;
			parameters[13].Value = model.ReplenFormulaCode;

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
		public bool Delete(int ReplenFormulaID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_REPLENFORMULA ");
			strSql.Append(" where ReplenFormulaID=@ReplenFormulaID");
			SqlParameter[] parameters = {
					new SqlParameter("@ReplenFormulaID", SqlDbType.Int,4)
			};
			parameters[0].Value = ReplenFormulaID;

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
		public bool Delete(string ReplenFormulaCode,int ReplenFormulaID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_REPLENFORMULA ");
			strSql.Append(" where ReplenFormulaCode=@ReplenFormulaCode and ReplenFormulaID=@ReplenFormulaID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReplenFormulaCode", SqlDbType.VarChar,64),
					new SqlParameter("@ReplenFormulaID", SqlDbType.Int,4)			};
			parameters[0].Value = ReplenFormulaCode;
			parameters[1].Value = ReplenFormulaID;

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
		public bool DeleteList(string ReplenFormulaIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_REPLENFORMULA ");
			strSql.Append(" where ReplenFormulaID in ("+ReplenFormulaIDlist + ")  ");
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
		public Edge.SVA.Model.BUY_REPLENFORMULA GetModel(int ReplenFormulaID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ReplenFormulaID,ReplenFormulaCode,Description,PreDefineDOC,RunningStockDOC,OrderRoundUpQty,AVGDailySalesPeriod,Quotation,Deposited,AdvSales,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_REPLENFORMULA ");
			strSql.Append(" where ReplenFormulaID=@ReplenFormulaID");
			SqlParameter[] parameters = {
					new SqlParameter("@ReplenFormulaID", SqlDbType.Int,4)
			};
			parameters[0].Value = ReplenFormulaID;

			Edge.SVA.Model.BUY_REPLENFORMULA model=new Edge.SVA.Model.BUY_REPLENFORMULA();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ReplenFormulaID"]!=null && ds.Tables[0].Rows[0]["ReplenFormulaID"].ToString()!="")
				{
					model.ReplenFormulaID=int.Parse(ds.Tables[0].Rows[0]["ReplenFormulaID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ReplenFormulaCode"]!=null && ds.Tables[0].Rows[0]["ReplenFormulaCode"].ToString()!="")
				{
					model.ReplenFormulaCode=ds.Tables[0].Rows[0]["ReplenFormulaCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Description"]!=null && ds.Tables[0].Rows[0]["Description"].ToString()!="")
				{
					model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PreDefineDOC"]!=null && ds.Tables[0].Rows[0]["PreDefineDOC"].ToString()!="")
				{
					model.PreDefineDOC=int.Parse(ds.Tables[0].Rows[0]["PreDefineDOC"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RunningStockDOC"]!=null && ds.Tables[0].Rows[0]["RunningStockDOC"].ToString()!="")
				{
					model.RunningStockDOC=int.Parse(ds.Tables[0].Rows[0]["RunningStockDOC"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrderRoundUpQty"]!=null && ds.Tables[0].Rows[0]["OrderRoundUpQty"].ToString()!="")
				{
					model.OrderRoundUpQty=int.Parse(ds.Tables[0].Rows[0]["OrderRoundUpQty"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AVGDailySalesPeriod"]!=null && ds.Tables[0].Rows[0]["AVGDailySalesPeriod"].ToString()!="")
				{
					model.AVGDailySalesPeriod=int.Parse(ds.Tables[0].Rows[0]["AVGDailySalesPeriod"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Quotation"]!=null && ds.Tables[0].Rows[0]["Quotation"].ToString()!="")
				{
					model.Quotation=int.Parse(ds.Tables[0].Rows[0]["Quotation"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Deposited"]!=null && ds.Tables[0].Rows[0]["Deposited"].ToString()!="")
				{
					model.Deposited=int.Parse(ds.Tables[0].Rows[0]["Deposited"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AdvSales"]!=null && ds.Tables[0].Rows[0]["AdvSales"].ToString()!="")
				{
					model.AdvSales=int.Parse(ds.Tables[0].Rows[0]["AdvSales"].ToString());
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
			strSql.Append("select ReplenFormulaID,ReplenFormulaCode,Description,PreDefineDOC,RunningStockDOC,OrderRoundUpQty,AVGDailySalesPeriod,Quotation,Deposited,AdvSales,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_REPLENFORMULA ");
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
			strSql.Append(" ReplenFormulaID,ReplenFormulaCode,Description,PreDefineDOC,RunningStockDOC,OrderRoundUpQty,AVGDailySalesPeriod,Quotation,Deposited,AdvSales,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_REPLENFORMULA ");
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
			strSql.Append("select count(1) FROM BUY_REPLENFORMULA ");
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
				strSql.Append("order by T.ReplenFormulaID desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_REPLENFORMULA T ");
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
			parameters[0].Value = "BUY_REPLENFORMULA";
			parameters[1].Value = "ReplenFormulaID";
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

