using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_CPRICE_H
	/// </summary>
	public partial class BUY_CPRICE_H:IBUY_CPRICE_H
	{
		public BUY_CPRICE_H()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CPriceCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_CPRICE_H");
			strSql.Append(" where CPriceCode=@CPriceCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@CPriceCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = CPriceCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_CPRICE_H model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_CPRICE_H(");
			strSql.Append("CPriceCode,StoreCode,StoreGroupCode,VendorCode,StartDate,EndDate,CurrencyCode,Note,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@CPriceCode,@StoreCode,@StoreGroupCode,@VendorCode,@StartDate,@EndDate,@CurrencyCode,@Note,@CreatedBusDate,@ApproveBusDate,@ApprovalCode,@ApproveStatus,@ApproveOn,@ApproveBy,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@CPriceCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreGroupCode", SqlDbType.VarChar,64),
					new SqlParameter("@VendorCode", SqlDbType.VarChar,64),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@CurrencyCode", SqlDbType.VarChar,64),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApproveBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApprovalCode", SqlDbType.VarChar,64),
					new SqlParameter("@ApproveStatus", SqlDbType.Char,1),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.CPriceCode;
			parameters[1].Value = model.StoreCode;
			parameters[2].Value = model.StoreGroupCode;
			parameters[3].Value = model.VendorCode;
			parameters[4].Value = model.StartDate;
			parameters[5].Value = model.EndDate;
			parameters[6].Value = model.CurrencyCode;
			parameters[7].Value = model.Note;
			parameters[8].Value = model.CreatedBusDate;
			parameters[9].Value = model.ApproveBusDate;
			parameters[10].Value = model.ApprovalCode;
			parameters[11].Value = model.ApproveStatus;
			parameters[12].Value = model.ApproveOn;
			parameters[13].Value = model.ApproveBy;
			parameters[14].Value = model.CreatedOn;
			parameters[15].Value = model.CreatedBy;
			parameters[16].Value = model.UpdatedOn;
			parameters[17].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.BUY_CPRICE_H model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_CPRICE_H set ");
			strSql.Append("StoreCode=@StoreCode,");
			strSql.Append("StoreGroupCode=@StoreGroupCode,");
			strSql.Append("VendorCode=@VendorCode,");
			strSql.Append("StartDate=@StartDate,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("CurrencyCode=@CurrencyCode,");
			strSql.Append("Note=@Note,");
			strSql.Append("CreatedBusDate=@CreatedBusDate,");
			strSql.Append("ApproveBusDate=@ApproveBusDate,");
			strSql.Append("ApprovalCode=@ApprovalCode,");
			strSql.Append("ApproveStatus=@ApproveStatus,");
			strSql.Append("ApproveOn=@ApproveOn,");
			strSql.Append("ApproveBy=@ApproveBy,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where CPriceCode=@CPriceCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreGroupCode", SqlDbType.VarChar,64),
					new SqlParameter("@VendorCode", SqlDbType.VarChar,64),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@CurrencyCode", SqlDbType.VarChar,64),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApproveBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApprovalCode", SqlDbType.VarChar,64),
					new SqlParameter("@ApproveStatus", SqlDbType.Char,1),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@CPriceCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.StoreCode;
			parameters[1].Value = model.StoreGroupCode;
			parameters[2].Value = model.VendorCode;
			parameters[3].Value = model.StartDate;
			parameters[4].Value = model.EndDate;
			parameters[5].Value = model.CurrencyCode;
			parameters[6].Value = model.Note;
			parameters[7].Value = model.CreatedBusDate;
			parameters[8].Value = model.ApproveBusDate;
			parameters[9].Value = model.ApprovalCode;
			parameters[10].Value = model.ApproveStatus;
			parameters[11].Value = model.ApproveOn;
			parameters[12].Value = model.ApproveBy;
			parameters[13].Value = model.CreatedOn;
			parameters[14].Value = model.CreatedBy;
			parameters[15].Value = model.UpdatedOn;
			parameters[16].Value = model.UpdatedBy;
			parameters[17].Value = model.CPriceCode;

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
		public bool Delete(string CPriceCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_CPRICE_H ");
			strSql.Append(" where CPriceCode=@CPriceCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@CPriceCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = CPriceCode;

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
		public bool DeleteList(string CPriceCodelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_CPRICE_H ");
			strSql.Append(" where CPriceCode in ("+CPriceCodelist + ")  ");
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
		public Edge.SVA.Model.BUY_CPRICE_H GetModel(string CPriceCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CPriceCode,StoreCode,StoreGroupCode,VendorCode,StartDate,EndDate,CurrencyCode,Note,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_CPRICE_H ");
			strSql.Append(" where CPriceCode=@CPriceCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@CPriceCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = CPriceCode;

			Edge.SVA.Model.BUY_CPRICE_H model=new Edge.SVA.Model.BUY_CPRICE_H();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CPriceCode"]!=null && ds.Tables[0].Rows[0]["CPriceCode"].ToString()!="")
				{
					model.CPriceCode=ds.Tables[0].Rows[0]["CPriceCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreCode"]!=null && ds.Tables[0].Rows[0]["StoreCode"].ToString()!="")
				{
					model.StoreCode=ds.Tables[0].Rows[0]["StoreCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreGroupCode"]!=null && ds.Tables[0].Rows[0]["StoreGroupCode"].ToString()!="")
				{
					model.StoreGroupCode=ds.Tables[0].Rows[0]["StoreGroupCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["VendorCode"]!=null && ds.Tables[0].Rows[0]["VendorCode"].ToString()!="")
				{
					model.VendorCode=ds.Tables[0].Rows[0]["VendorCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StartDate"]!=null && ds.Tables[0].Rows[0]["StartDate"].ToString()!="")
				{
					model.StartDate=DateTime.Parse(ds.Tables[0].Rows[0]["StartDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndDate"]!=null && ds.Tables[0].Rows[0]["EndDate"].ToString()!="")
				{
					model.EndDate=DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CurrencyCode"]!=null && ds.Tables[0].Rows[0]["CurrencyCode"].ToString()!="")
				{
					model.CurrencyCode=ds.Tables[0].Rows[0]["CurrencyCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Note"]!=null && ds.Tables[0].Rows[0]["Note"].ToString()!="")
				{
					model.Note=ds.Tables[0].Rows[0]["Note"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CreatedBusDate"]!=null && ds.Tables[0].Rows[0]["CreatedBusDate"].ToString()!="")
				{
					model.CreatedBusDate=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedBusDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApproveBusDate"]!=null && ds.Tables[0].Rows[0]["ApproveBusDate"].ToString()!="")
				{
					model.ApproveBusDate=DateTime.Parse(ds.Tables[0].Rows[0]["ApproveBusDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApprovalCode"]!=null && ds.Tables[0].Rows[0]["ApprovalCode"].ToString()!="")
				{
					model.ApprovalCode=ds.Tables[0].Rows[0]["ApprovalCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ApproveStatus"]!=null && ds.Tables[0].Rows[0]["ApproveStatus"].ToString()!="")
				{
					model.ApproveStatus=ds.Tables[0].Rows[0]["ApproveStatus"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ApproveOn"]!=null && ds.Tables[0].Rows[0]["ApproveOn"].ToString()!="")
				{
					model.ApproveOn=DateTime.Parse(ds.Tables[0].Rows[0]["ApproveOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApproveBy"]!=null && ds.Tables[0].Rows[0]["ApproveBy"].ToString()!="")
				{
					model.ApproveBy=int.Parse(ds.Tables[0].Rows[0]["ApproveBy"].ToString());
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
			strSql.Append("select CPriceCode,StoreCode,StoreGroupCode,VendorCode,StartDate,EndDate,CurrencyCode,Note,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_CPRICE_H ");
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
			strSql.Append(" CPriceCode,StoreCode,StoreGroupCode,VendorCode,StartDate,EndDate,CurrencyCode,Note,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_CPRICE_H ");
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
			strSql.Append("select count(1) FROM BUY_CPRICE_H ");
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
				strSql.Append("order by T.CPriceCode desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_CPRICE_H T ");
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
			parameters[0].Value = "BUY_CPRICE_H";
			parameters[1].Value = "CPriceCode";
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

