using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_RPRICE_M
	/// </summary>
	public partial class BUY_RPRICE_M:IBUY_RPRICE_M
	{
		public BUY_RPRICE_M()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "BUY_RPRICE_M"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_RPRICE_M");
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
		public int Add(Edge.SVA.Model.BUY_RPRICE_M model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_RPRICE_M(");
			strSql.Append("RPriceCode,ProdCode,RPriceTypeCode,RefPrice,Price,StoreCode,StoreGroupCode,StartDate,EndDate,Status,ApproveOn,ApproveBy,UpdatedOn,UpdatedBy,PromotionPrice,MemberPrice)");
			strSql.Append(" values (");
			strSql.Append("@RPriceCode,@ProdCode,@RPriceTypeCode,@RefPrice,@Price,@StoreCode,@StoreGroupCode,@StartDate,@EndDate,@Status,@ApproveOn,@ApproveBy,@UpdatedOn,@UpdatedBy,@PromotionPrice,@MemberPrice)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@RPriceCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@RPriceTypeCode", SqlDbType.VarChar,64),
					new SqlParameter("@RefPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreGroupCode", SqlDbType.VarChar,64),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@PromotionPrice", SqlDbType.Decimal,9),
					new SqlParameter("@MemberPrice", SqlDbType.Decimal,9)};
			parameters[0].Value = model.RPriceCode;
			parameters[1].Value = model.ProdCode;
			parameters[2].Value = model.RPriceTypeCode;
			parameters[3].Value = model.RefPrice;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.StoreCode;
			parameters[6].Value = model.StoreGroupCode;
			parameters[7].Value = model.StartDate;
			parameters[8].Value = model.EndDate;
			parameters[9].Value = model.Status;
			parameters[10].Value = model.ApproveOn;
			parameters[11].Value = model.ApproveBy;
			parameters[12].Value = model.UpdatedOn;
			parameters[13].Value = model.UpdatedBy;
			parameters[14].Value = model.PromotionPrice;
			parameters[15].Value = model.MemberPrice;

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
		public bool Update(Edge.SVA.Model.BUY_RPRICE_M model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_RPRICE_M set ");
			strSql.Append("RPriceCode=@RPriceCode,");
			strSql.Append("ProdCode=@ProdCode,");
			strSql.Append("RPriceTypeCode=@RPriceTypeCode,");
			strSql.Append("RefPrice=@RefPrice,");
			strSql.Append("Price=@Price,");
			strSql.Append("StoreCode=@StoreCode,");
			strSql.Append("StoreGroupCode=@StoreGroupCode,");
			strSql.Append("StartDate=@StartDate,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("Status=@Status,");
			strSql.Append("ApproveOn=@ApproveOn,");
			strSql.Append("ApproveBy=@ApproveBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("PromotionPrice=@PromotionPrice,");
			strSql.Append("MemberPrice=@MemberPrice");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@RPriceCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@RPriceTypeCode", SqlDbType.VarChar,64),
					new SqlParameter("@RefPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreGroupCode", SqlDbType.VarChar,64),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@PromotionPrice", SqlDbType.Decimal,9),
					new SqlParameter("@MemberPrice", SqlDbType.Decimal,9),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.RPriceCode;
			parameters[1].Value = model.ProdCode;
			parameters[2].Value = model.RPriceTypeCode;
			parameters[3].Value = model.RefPrice;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.StoreCode;
			parameters[6].Value = model.StoreGroupCode;
			parameters[7].Value = model.StartDate;
			parameters[8].Value = model.EndDate;
			parameters[9].Value = model.Status;
			parameters[10].Value = model.ApproveOn;
			parameters[11].Value = model.ApproveBy;
			parameters[12].Value = model.UpdatedOn;
			parameters[13].Value = model.UpdatedBy;
			parameters[14].Value = model.PromotionPrice;
			parameters[15].Value = model.MemberPrice;
			parameters[16].Value = model.KeyID;

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
			strSql.Append("delete from BUY_RPRICE_M ");
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
			strSql.Append("delete from BUY_RPRICE_M ");
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
		public Edge.SVA.Model.BUY_RPRICE_M GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,RPriceCode,ProdCode,RPriceTypeCode,RefPrice,Price,StoreCode,StoreGroupCode,StartDate,EndDate,Status,ApproveOn,ApproveBy,UpdatedOn,UpdatedBy,PromotionPrice,MemberPrice from BUY_RPRICE_M ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.BUY_RPRICE_M model=new Edge.SVA.Model.BUY_RPRICE_M();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RPriceCode"]!=null && ds.Tables[0].Rows[0]["RPriceCode"].ToString()!="")
				{
					model.RPriceCode=ds.Tables[0].Rows[0]["RPriceCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProdCode"]!=null && ds.Tables[0].Rows[0]["ProdCode"].ToString()!="")
				{
					model.ProdCode=ds.Tables[0].Rows[0]["ProdCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RPriceTypeCode"]!=null && ds.Tables[0].Rows[0]["RPriceTypeCode"].ToString()!="")
				{
					model.RPriceTypeCode=ds.Tables[0].Rows[0]["RPriceTypeCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RefPrice"]!=null && ds.Tables[0].Rows[0]["RefPrice"].ToString()!="")
				{
					model.RefPrice=decimal.Parse(ds.Tables[0].Rows[0]["RefPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"]!=null && ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StoreCode"]!=null && ds.Tables[0].Rows[0]["StoreCode"].ToString()!="")
				{
					model.StoreCode=ds.Tables[0].Rows[0]["StoreCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreGroupCode"]!=null && ds.Tables[0].Rows[0]["StoreGroupCode"].ToString()!="")
				{
					model.StoreGroupCode=ds.Tables[0].Rows[0]["StoreGroupCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StartDate"]!=null && ds.Tables[0].Rows[0]["StartDate"].ToString()!="")
				{
					model.StartDate=DateTime.Parse(ds.Tables[0].Rows[0]["StartDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndDate"]!=null && ds.Tables[0].Rows[0]["EndDate"].ToString()!="")
				{
					model.EndDate=DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
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
				if(ds.Tables[0].Rows[0]["PromotionPrice"]!=null && ds.Tables[0].Rows[0]["PromotionPrice"].ToString()!="")
				{
					model.PromotionPrice=decimal.Parse(ds.Tables[0].Rows[0]["PromotionPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberPrice"]!=null && ds.Tables[0].Rows[0]["MemberPrice"].ToString()!="")
				{
					model.MemberPrice=decimal.Parse(ds.Tables[0].Rows[0]["MemberPrice"].ToString());
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
			strSql.Append("select KeyID,RPriceCode,ProdCode,RPriceTypeCode,RefPrice,Price,StoreCode,StoreGroupCode,StartDate,EndDate,Status,ApproveOn,ApproveBy,UpdatedOn,UpdatedBy,PromotionPrice,MemberPrice ");
			strSql.Append(" FROM BUY_RPRICE_M ");
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
			strSql.Append(" KeyID,RPriceCode,ProdCode,RPriceTypeCode,RefPrice,Price,StoreCode,StoreGroupCode,StartDate,EndDate,Status,ApproveOn,ApproveBy,UpdatedOn,UpdatedBy,PromotionPrice,MemberPrice ");
			strSql.Append(" FROM BUY_RPRICE_M ");
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
			strSql.Append("select count(1) FROM BUY_RPRICE_M ");
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
			strSql.Append(")AS Row, T.*  from BUY_RPRICE_M T ");
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
			parameters[0].Value = "BUY_RPRICE_M";
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

