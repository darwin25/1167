using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_SETTLEMENT
	/// </summary>
	public partial class BUY_SETTLEMENT:IBUY_SETTLEMENT
	{
		public BUY_SETTLEMENT()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SettlementCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_SETTLEMENT");
			strSql.Append(" where SettlementCode=@SettlementCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@SettlementCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = SettlementCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_SETTLEMENT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_SETTLEMENT(");
			strSql.Append("SettlementCode,SettlementDate,SettlementTotal,SettlementNetTotal,NoOfTxn,BankInDate,Status,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@SettlementCode,@SettlementDate,@SettlementTotal,@SettlementNetTotal,@NoOfTxn,@BankInDate,@Status,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@SettlementCode", SqlDbType.VarChar,64),
					new SqlParameter("@SettlementDate", SqlDbType.DateTime),
					new SqlParameter("@SettlementTotal", SqlDbType.Decimal,9),
					new SqlParameter("@SettlementNetTotal", SqlDbType.Decimal,9),
					new SqlParameter("@NoOfTxn", SqlDbType.Int,4),
					new SqlParameter("@BankInDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.SettlementCode;
			parameters[1].Value = model.SettlementDate;
			parameters[2].Value = model.SettlementTotal;
			parameters[3].Value = model.SettlementNetTotal;
			parameters[4].Value = model.NoOfTxn;
			parameters[5].Value = model.BankInDate;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.CreatedOn;
			parameters[8].Value = model.CreatedBy;
			parameters[9].Value = model.UpdatedOn;
			parameters[10].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.BUY_SETTLEMENT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_SETTLEMENT set ");
			strSql.Append("SettlementDate=@SettlementDate,");
			strSql.Append("SettlementTotal=@SettlementTotal,");
			strSql.Append("SettlementNetTotal=@SettlementNetTotal,");
			strSql.Append("NoOfTxn=@NoOfTxn,");
			strSql.Append("BankInDate=@BankInDate,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where SettlementCode=@SettlementCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@SettlementDate", SqlDbType.DateTime),
					new SqlParameter("@SettlementTotal", SqlDbType.Decimal,9),
					new SqlParameter("@SettlementNetTotal", SqlDbType.Decimal,9),
					new SqlParameter("@NoOfTxn", SqlDbType.Int,4),
					new SqlParameter("@BankInDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@SettlementCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.SettlementDate;
			parameters[1].Value = model.SettlementTotal;
			parameters[2].Value = model.SettlementNetTotal;
			parameters[3].Value = model.NoOfTxn;
			parameters[4].Value = model.BankInDate;
			parameters[5].Value = model.Status;
			parameters[6].Value = model.CreatedOn;
			parameters[7].Value = model.CreatedBy;
			parameters[8].Value = model.UpdatedOn;
			parameters[9].Value = model.UpdatedBy;
			parameters[10].Value = model.SettlementCode;

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
		public bool Delete(string SettlementCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_SETTLEMENT ");
			strSql.Append(" where SettlementCode=@SettlementCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@SettlementCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = SettlementCode;

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
		public bool DeleteList(string SettlementCodelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_SETTLEMENT ");
			strSql.Append(" where SettlementCode in ("+SettlementCodelist + ")  ");
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
		public Edge.SVA.Model.BUY_SETTLEMENT GetModel(string SettlementCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SettlementCode,SettlementDate,SettlementTotal,SettlementNetTotal,NoOfTxn,BankInDate,Status,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_SETTLEMENT ");
			strSql.Append(" where SettlementCode=@SettlementCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@SettlementCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = SettlementCode;

			Edge.SVA.Model.BUY_SETTLEMENT model=new Edge.SVA.Model.BUY_SETTLEMENT();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["SettlementCode"]!=null && ds.Tables[0].Rows[0]["SettlementCode"].ToString()!="")
				{
					model.SettlementCode=ds.Tables[0].Rows[0]["SettlementCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SettlementDate"]!=null && ds.Tables[0].Rows[0]["SettlementDate"].ToString()!="")
				{
					model.SettlementDate=DateTime.Parse(ds.Tables[0].Rows[0]["SettlementDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SettlementTotal"]!=null && ds.Tables[0].Rows[0]["SettlementTotal"].ToString()!="")
				{
					model.SettlementTotal=decimal.Parse(ds.Tables[0].Rows[0]["SettlementTotal"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SettlementNetTotal"]!=null && ds.Tables[0].Rows[0]["SettlementNetTotal"].ToString()!="")
				{
					model.SettlementNetTotal=decimal.Parse(ds.Tables[0].Rows[0]["SettlementNetTotal"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NoOfTxn"]!=null && ds.Tables[0].Rows[0]["NoOfTxn"].ToString()!="")
				{
					model.NoOfTxn=int.Parse(ds.Tables[0].Rows[0]["NoOfTxn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BankInDate"]!=null && ds.Tables[0].Rows[0]["BankInDate"].ToString()!="")
				{
					model.BankInDate=DateTime.Parse(ds.Tables[0].Rows[0]["BankInDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
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
			strSql.Append("select SettlementCode,SettlementDate,SettlementTotal,SettlementNetTotal,NoOfTxn,BankInDate,Status,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_SETTLEMENT ");
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
			strSql.Append(" SettlementCode,SettlementDate,SettlementTotal,SettlementNetTotal,NoOfTxn,BankInDate,Status,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_SETTLEMENT ");
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
			strSql.Append("select count(1) FROM BUY_SETTLEMENT ");
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
				strSql.Append("order by T.SettlementCode desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_SETTLEMENT T ");
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
			parameters[0].Value = "BUY_SETTLEMENT";
			parameters[1].Value = "SettlementCode";
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

