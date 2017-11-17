using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_CPRICE_M
	/// </summary>
	public partial class BUY_CPRICE_M:IBUY_CPRICE_M
	{
		public BUY_CPRICE_M()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "BUY_CPRICE_M"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_CPRICE_M");
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
		public int Add(Edge.SVA.Model.BUY_CPRICE_M model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_CPRICE_M(");
			strSql.Append("CPriceCode,ProdCode,VendorCode,StoreCode,StoreGroupCode,CurrencyCode,StartDate,EndDate,CPriceGrossCost,CPriceNetCost,CPriceDisc1,CPriceDisc2,CPriceDisc3,CPriceDisc4,CPriceBuy,CPriceGet,Status,ApproveOn,ApproveBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@CPriceCode,@ProdCode,@VendorCode,@StoreCode,@StoreGroupCode,@CurrencyCode,@StartDate,@EndDate,@CPriceGrossCost,@CPriceNetCost,@CPriceDisc1,@CPriceDisc2,@CPriceDisc3,@CPriceDisc4,@CPriceBuy,@CPriceGet,@Status,@ApproveOn,@ApproveBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CPriceCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@VendorCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreGroupCode", SqlDbType.VarChar,64),
					new SqlParameter("@CurrencyCode", SqlDbType.VarChar,64),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@CPriceGrossCost", SqlDbType.Decimal,9),
					new SqlParameter("@CPriceNetCost", SqlDbType.Decimal,9),
					new SqlParameter("@CPriceDisc1", SqlDbType.Decimal,9),
					new SqlParameter("@CPriceDisc2", SqlDbType.Decimal,9),
					new SqlParameter("@CPriceDisc3", SqlDbType.Decimal,9),
					new SqlParameter("@CPriceDisc4", SqlDbType.Decimal,9),
					new SqlParameter("@CPriceBuy", SqlDbType.Decimal,9),
					new SqlParameter("@CPriceGet", SqlDbType.Decimal,9),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.CPriceCode;
			parameters[1].Value = model.ProdCode;
			parameters[2].Value = model.VendorCode;
			parameters[3].Value = model.StoreCode;
			parameters[4].Value = model.StoreGroupCode;
			parameters[5].Value = model.CurrencyCode;
			parameters[6].Value = model.StartDate;
			parameters[7].Value = model.EndDate;
			parameters[8].Value = model.CPriceGrossCost;
			parameters[9].Value = model.CPriceNetCost;
			parameters[10].Value = model.CPriceDisc1;
			parameters[11].Value = model.CPriceDisc2;
			parameters[12].Value = model.CPriceDisc3;
			parameters[13].Value = model.CPriceDisc4;
			parameters[14].Value = model.CPriceBuy;
			parameters[15].Value = model.CPriceGet;
			parameters[16].Value = model.Status;
			parameters[17].Value = model.ApproveOn;
			parameters[18].Value = model.ApproveBy;
			parameters[19].Value = model.UpdatedOn;
			parameters[20].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.BUY_CPRICE_M model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_CPRICE_M set ");
			strSql.Append("CPriceCode=@CPriceCode,");
			strSql.Append("ProdCode=@ProdCode,");
			strSql.Append("VendorCode=@VendorCode,");
			strSql.Append("StoreCode=@StoreCode,");
			strSql.Append("StoreGroupCode=@StoreGroupCode,");
			strSql.Append("CurrencyCode=@CurrencyCode,");
			strSql.Append("StartDate=@StartDate,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("CPriceGrossCost=@CPriceGrossCost,");
			strSql.Append("CPriceNetCost=@CPriceNetCost,");
			strSql.Append("CPriceDisc1=@CPriceDisc1,");
			strSql.Append("CPriceDisc2=@CPriceDisc2,");
			strSql.Append("CPriceDisc3=@CPriceDisc3,");
			strSql.Append("CPriceDisc4=@CPriceDisc4,");
			strSql.Append("CPriceBuy=@CPriceBuy,");
			strSql.Append("CPriceGet=@CPriceGet,");
			strSql.Append("Status=@Status,");
			strSql.Append("ApproveOn=@ApproveOn,");
			strSql.Append("ApproveBy=@ApproveBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@CPriceCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@VendorCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreGroupCode", SqlDbType.VarChar,64),
					new SqlParameter("@CurrencyCode", SqlDbType.VarChar,64),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@CPriceGrossCost", SqlDbType.Decimal,9),
					new SqlParameter("@CPriceNetCost", SqlDbType.Decimal,9),
					new SqlParameter("@CPriceDisc1", SqlDbType.Decimal,9),
					new SqlParameter("@CPriceDisc2", SqlDbType.Decimal,9),
					new SqlParameter("@CPriceDisc3", SqlDbType.Decimal,9),
					new SqlParameter("@CPriceDisc4", SqlDbType.Decimal,9),
					new SqlParameter("@CPriceBuy", SqlDbType.Decimal,9),
					new SqlParameter("@CPriceGet", SqlDbType.Decimal,9),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.CPriceCode;
			parameters[1].Value = model.ProdCode;
			parameters[2].Value = model.VendorCode;
			parameters[3].Value = model.StoreCode;
			parameters[4].Value = model.StoreGroupCode;
			parameters[5].Value = model.CurrencyCode;
			parameters[6].Value = model.StartDate;
			parameters[7].Value = model.EndDate;
			parameters[8].Value = model.CPriceGrossCost;
			parameters[9].Value = model.CPriceNetCost;
			parameters[10].Value = model.CPriceDisc1;
			parameters[11].Value = model.CPriceDisc2;
			parameters[12].Value = model.CPriceDisc3;
			parameters[13].Value = model.CPriceDisc4;
			parameters[14].Value = model.CPriceBuy;
			parameters[15].Value = model.CPriceGet;
			parameters[16].Value = model.Status;
			parameters[17].Value = model.ApproveOn;
			parameters[18].Value = model.ApproveBy;
			parameters[19].Value = model.UpdatedOn;
			parameters[20].Value = model.UpdatedBy;
			parameters[21].Value = model.KeyID;

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
			strSql.Append("delete from BUY_CPRICE_M ");
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
			strSql.Append("delete from BUY_CPRICE_M ");
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
		public Edge.SVA.Model.BUY_CPRICE_M GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,CPriceCode,ProdCode,VendorCode,StoreCode,StoreGroupCode,CurrencyCode,StartDate,EndDate,CPriceGrossCost,CPriceNetCost,CPriceDisc1,CPriceDisc2,CPriceDisc3,CPriceDisc4,CPriceBuy,CPriceGet,Status,ApproveOn,ApproveBy,UpdatedOn,UpdatedBy from BUY_CPRICE_M ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.BUY_CPRICE_M model=new Edge.SVA.Model.BUY_CPRICE_M();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CPriceCode"]!=null && ds.Tables[0].Rows[0]["CPriceCode"].ToString()!="")
				{
					model.CPriceCode=ds.Tables[0].Rows[0]["CPriceCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProdCode"]!=null && ds.Tables[0].Rows[0]["ProdCode"].ToString()!="")
				{
					model.ProdCode=ds.Tables[0].Rows[0]["ProdCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["VendorCode"]!=null && ds.Tables[0].Rows[0]["VendorCode"].ToString()!="")
				{
					model.VendorCode=ds.Tables[0].Rows[0]["VendorCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreCode"]!=null && ds.Tables[0].Rows[0]["StoreCode"].ToString()!="")
				{
					model.StoreCode=ds.Tables[0].Rows[0]["StoreCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreGroupCode"]!=null && ds.Tables[0].Rows[0]["StoreGroupCode"].ToString()!="")
				{
					model.StoreGroupCode=ds.Tables[0].Rows[0]["StoreGroupCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CurrencyCode"]!=null && ds.Tables[0].Rows[0]["CurrencyCode"].ToString()!="")
				{
					model.CurrencyCode=ds.Tables[0].Rows[0]["CurrencyCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StartDate"]!=null && ds.Tables[0].Rows[0]["StartDate"].ToString()!="")
				{
					model.StartDate=DateTime.Parse(ds.Tables[0].Rows[0]["StartDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndDate"]!=null && ds.Tables[0].Rows[0]["EndDate"].ToString()!="")
				{
					model.EndDate=DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CPriceGrossCost"]!=null && ds.Tables[0].Rows[0]["CPriceGrossCost"].ToString()!="")
				{
					model.CPriceGrossCost=decimal.Parse(ds.Tables[0].Rows[0]["CPriceGrossCost"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CPriceNetCost"]!=null && ds.Tables[0].Rows[0]["CPriceNetCost"].ToString()!="")
				{
					model.CPriceNetCost=decimal.Parse(ds.Tables[0].Rows[0]["CPriceNetCost"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CPriceDisc1"]!=null && ds.Tables[0].Rows[0]["CPriceDisc1"].ToString()!="")
				{
					model.CPriceDisc1=decimal.Parse(ds.Tables[0].Rows[0]["CPriceDisc1"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CPriceDisc2"]!=null && ds.Tables[0].Rows[0]["CPriceDisc2"].ToString()!="")
				{
					model.CPriceDisc2=decimal.Parse(ds.Tables[0].Rows[0]["CPriceDisc2"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CPriceDisc3"]!=null && ds.Tables[0].Rows[0]["CPriceDisc3"].ToString()!="")
				{
					model.CPriceDisc3=decimal.Parse(ds.Tables[0].Rows[0]["CPriceDisc3"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CPriceDisc4"]!=null && ds.Tables[0].Rows[0]["CPriceDisc4"].ToString()!="")
				{
					model.CPriceDisc4=decimal.Parse(ds.Tables[0].Rows[0]["CPriceDisc4"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CPriceBuy"]!=null && ds.Tables[0].Rows[0]["CPriceBuy"].ToString()!="")
				{
					model.CPriceBuy=decimal.Parse(ds.Tables[0].Rows[0]["CPriceBuy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CPriceGet"]!=null && ds.Tables[0].Rows[0]["CPriceGet"].ToString()!="")
				{
					model.CPriceGet=decimal.Parse(ds.Tables[0].Rows[0]["CPriceGet"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApproveOn"]!=null && ds.Tables[0].Rows[0]["ApproveOn"].ToString()!="")
				{
					model.ApproveOn=DateTime.Parse(ds.Tables[0].Rows[0]["ApproveOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApproveBy"]!=null && ds.Tables[0].Rows[0]["ApproveBy"].ToString()!="")
				{
					model.ApproveBy=int.Parse(ds.Tables[0].Rows[0]["ApproveBy"].ToString());
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
			strSql.Append("select KeyID,CPriceCode,ProdCode,VendorCode,StoreCode,StoreGroupCode,CurrencyCode,StartDate,EndDate,CPriceGrossCost,CPriceNetCost,CPriceDisc1,CPriceDisc2,CPriceDisc3,CPriceDisc4,CPriceBuy,CPriceGet,Status,ApproveOn,ApproveBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_CPRICE_M ");
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
			strSql.Append(" KeyID,CPriceCode,ProdCode,VendorCode,StoreCode,StoreGroupCode,CurrencyCode,StartDate,EndDate,CPriceGrossCost,CPriceNetCost,CPriceDisc1,CPriceDisc2,CPriceDisc3,CPriceDisc4,CPriceBuy,CPriceGet,Status,ApproveOn,ApproveBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_CPRICE_M ");
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
			strSql.Append("select count(1) FROM BUY_CPRICE_M ");
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
			strSql.Append(")AS Row, T.*  from BUY_CPRICE_M T ");
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
			parameters[0].Value = "BUY_CPRICE_M";
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

