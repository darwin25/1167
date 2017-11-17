using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_CURRENCY
	/// </summary>
	public partial class BUY_CURRENCY:IBUY_CURRENCY
	{
		public BUY_CURRENCY()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CurrencyID", "BUY_CURRENCY"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CurrencyCode,int CurrencyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_CURRENCY");
			strSql.Append(" where CurrencyCode=@CurrencyCode and CurrencyID=@CurrencyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CurrencyCode", SqlDbType.VarChar,64),
					new SqlParameter("@CurrencyID", SqlDbType.Int,4)			};
			parameters[0].Value = CurrencyCode;
			parameters[1].Value = CurrencyID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.BUY_CURRENCY model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_CURRENCY(");
			strSql.Append("CurrencyCode,CurrencyName1,CurrencyName2,CurrencyName3,Rate,TenderType,Status,CashSale,CouponValue,Base,MinAmt,MaxAmt,CardType,CardBegin,CardEnd,CardLen,AccountCode,ContraCode,PayTransfer,Refund_Type,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@CurrencyCode,@CurrencyName1,@CurrencyName2,@CurrencyName3,@Rate,@TenderType,@Status,@CashSale,@CouponValue,@Base,@MinAmt,@MaxAmt,@CardType,@CardBegin,@CardEnd,@CardLen,@AccountCode,@ContraCode,@PayTransfer,@Refund_Type,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CurrencyCode", SqlDbType.VarChar,64),
					new SqlParameter("@CurrencyName1", SqlDbType.NVarChar,512),
					new SqlParameter("@CurrencyName2", SqlDbType.NVarChar,512),
					new SqlParameter("@CurrencyName3", SqlDbType.NVarChar,512),
					new SqlParameter("@Rate", SqlDbType.Decimal,9),
					new SqlParameter("@TenderType", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CashSale", SqlDbType.Int,4),
					new SqlParameter("@CouponValue", SqlDbType.Int,4),
					new SqlParameter("@Base", SqlDbType.Decimal,9),
					new SqlParameter("@MinAmt", SqlDbType.Decimal,9),
					new SqlParameter("@MaxAmt", SqlDbType.Decimal,9),
					new SqlParameter("@CardType", SqlDbType.VarChar,64),
					new SqlParameter("@CardBegin", SqlDbType.VarChar,64),
					new SqlParameter("@CardEnd", SqlDbType.VarChar,64),
					new SqlParameter("@CardLen", SqlDbType.Int,4),
					new SqlParameter("@AccountCode", SqlDbType.VarChar,64),
					new SqlParameter("@ContraCode", SqlDbType.VarChar,64),
					new SqlParameter("@PayTransfer", SqlDbType.Int,4),
					new SqlParameter("@Refund_Type", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.CurrencyCode;
			parameters[1].Value = model.CurrencyName1;
			parameters[2].Value = model.CurrencyName2;
			parameters[3].Value = model.CurrencyName3;
			parameters[4].Value = model.Rate;
			parameters[5].Value = model.TenderType;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.CashSale;
			parameters[8].Value = model.CouponValue;
			parameters[9].Value = model.Base;
			parameters[10].Value = model.MinAmt;
			parameters[11].Value = model.MaxAmt;
			parameters[12].Value = model.CardType;
			parameters[13].Value = model.CardBegin;
			parameters[14].Value = model.CardEnd;
			parameters[15].Value = model.CardLen;
			parameters[16].Value = model.AccountCode;
			parameters[17].Value = model.ContraCode;
			parameters[18].Value = model.PayTransfer;
			parameters[19].Value = model.Refund_Type;
			parameters[20].Value = model.CreatedOn;
			parameters[21].Value = model.CreatedBy;
			parameters[22].Value = model.UpdatedOn;
			parameters[23].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.BUY_CURRENCY model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_CURRENCY set ");
			strSql.Append("CurrencyName1=@CurrencyName1,");
			strSql.Append("CurrencyName2=@CurrencyName2,");
			strSql.Append("CurrencyName3=@CurrencyName3,");
			strSql.Append("Rate=@Rate,");
			strSql.Append("TenderType=@TenderType,");
			strSql.Append("Status=@Status,");
			strSql.Append("CashSale=@CashSale,");
			strSql.Append("CouponValue=@CouponValue,");
			strSql.Append("Base=@Base,");
			strSql.Append("MinAmt=@MinAmt,");
			strSql.Append("MaxAmt=@MaxAmt,");
			strSql.Append("CardType=@CardType,");
			strSql.Append("CardBegin=@CardBegin,");
			strSql.Append("CardEnd=@CardEnd,");
			strSql.Append("CardLen=@CardLen,");
			strSql.Append("AccountCode=@AccountCode,");
			strSql.Append("ContraCode=@ContraCode,");
			strSql.Append("PayTransfer=@PayTransfer,");
			strSql.Append("Refund_Type=@Refund_Type,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where CurrencyID=@CurrencyID");
			SqlParameter[] parameters = {
					new SqlParameter("@CurrencyName1", SqlDbType.NVarChar,512),
					new SqlParameter("@CurrencyName2", SqlDbType.NVarChar,512),
					new SqlParameter("@CurrencyName3", SqlDbType.NVarChar,512),
					new SqlParameter("@Rate", SqlDbType.Decimal,9),
					new SqlParameter("@TenderType", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CashSale", SqlDbType.Int,4),
					new SqlParameter("@CouponValue", SqlDbType.Int,4),
					new SqlParameter("@Base", SqlDbType.Decimal,9),
					new SqlParameter("@MinAmt", SqlDbType.Decimal,9),
					new SqlParameter("@MaxAmt", SqlDbType.Decimal,9),
					new SqlParameter("@CardType", SqlDbType.VarChar,64),
					new SqlParameter("@CardBegin", SqlDbType.VarChar,64),
					new SqlParameter("@CardEnd", SqlDbType.VarChar,64),
					new SqlParameter("@CardLen", SqlDbType.Int,4),
					new SqlParameter("@AccountCode", SqlDbType.VarChar,64),
					new SqlParameter("@ContraCode", SqlDbType.VarChar,64),
					new SqlParameter("@PayTransfer", SqlDbType.Int,4),
					new SqlParameter("@Refund_Type", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@CurrencyID", SqlDbType.Int,4),
					new SqlParameter("@CurrencyCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.CurrencyName1;
			parameters[1].Value = model.CurrencyName2;
			parameters[2].Value = model.CurrencyName3;
			parameters[3].Value = model.Rate;
			parameters[4].Value = model.TenderType;
			parameters[5].Value = model.Status;
			parameters[6].Value = model.CashSale;
			parameters[7].Value = model.CouponValue;
			parameters[8].Value = model.Base;
			parameters[9].Value = model.MinAmt;
			parameters[10].Value = model.MaxAmt;
			parameters[11].Value = model.CardType;
			parameters[12].Value = model.CardBegin;
			parameters[13].Value = model.CardEnd;
			parameters[14].Value = model.CardLen;
			parameters[15].Value = model.AccountCode;
			parameters[16].Value = model.ContraCode;
			parameters[17].Value = model.PayTransfer;
			parameters[18].Value = model.Refund_Type;
			parameters[19].Value = model.CreatedOn;
			parameters[20].Value = model.CreatedBy;
			parameters[21].Value = model.UpdatedOn;
			parameters[22].Value = model.UpdatedBy;
			parameters[23].Value = model.CurrencyID;
			parameters[24].Value = model.CurrencyCode;

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
		public bool Delete(int CurrencyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_CURRENCY ");
			strSql.Append(" where CurrencyID=@CurrencyID");
			SqlParameter[] parameters = {
					new SqlParameter("@CurrencyID", SqlDbType.Int,4)
			};
			parameters[0].Value = CurrencyID;

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
		public bool Delete(string CurrencyCode,int CurrencyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_CURRENCY ");
			strSql.Append(" where CurrencyCode=@CurrencyCode and CurrencyID=@CurrencyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CurrencyCode", SqlDbType.VarChar,64),
					new SqlParameter("@CurrencyID", SqlDbType.Int,4)			};
			parameters[0].Value = CurrencyCode;
			parameters[1].Value = CurrencyID;

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
		public bool DeleteList(string CurrencyIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_CURRENCY ");
			strSql.Append(" where CurrencyID in ("+CurrencyIDlist + ")  ");
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
		public Edge.SVA.Model.BUY_CURRENCY GetModel(int CurrencyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CurrencyID,CurrencyCode,CurrencyName1,CurrencyName2,CurrencyName3,Rate,TenderType,Status,CashSale,CouponValue,Base,MinAmt,MaxAmt,CardType,CardBegin,CardEnd,CardLen,AccountCode,ContraCode,PayTransfer,Refund_Type,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_CURRENCY ");
			strSql.Append(" where CurrencyID=@CurrencyID");
			SqlParameter[] parameters = {
					new SqlParameter("@CurrencyID", SqlDbType.Int,4)
			};
			parameters[0].Value = CurrencyID;

			Edge.SVA.Model.BUY_CURRENCY model=new Edge.SVA.Model.BUY_CURRENCY();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CurrencyID"]!=null && ds.Tables[0].Rows[0]["CurrencyID"].ToString()!="")
				{
					model.CurrencyID=int.Parse(ds.Tables[0].Rows[0]["CurrencyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CurrencyCode"]!=null && ds.Tables[0].Rows[0]["CurrencyCode"].ToString()!="")
				{
					model.CurrencyCode=ds.Tables[0].Rows[0]["CurrencyCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CurrencyName1"]!=null && ds.Tables[0].Rows[0]["CurrencyName1"].ToString()!="")
				{
					model.CurrencyName1=ds.Tables[0].Rows[0]["CurrencyName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CurrencyName2"]!=null && ds.Tables[0].Rows[0]["CurrencyName2"].ToString()!="")
				{
					model.CurrencyName2=ds.Tables[0].Rows[0]["CurrencyName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CurrencyName3"]!=null && ds.Tables[0].Rows[0]["CurrencyName3"].ToString()!="")
				{
					model.CurrencyName3=ds.Tables[0].Rows[0]["CurrencyName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Rate"]!=null && ds.Tables[0].Rows[0]["Rate"].ToString()!="")
				{
					model.Rate=decimal.Parse(ds.Tables[0].Rows[0]["Rate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TenderType"]!=null && ds.Tables[0].Rows[0]["TenderType"].ToString()!="")
				{
					model.TenderType=int.Parse(ds.Tables[0].Rows[0]["TenderType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CashSale"]!=null && ds.Tables[0].Rows[0]["CashSale"].ToString()!="")
				{
					model.CashSale=int.Parse(ds.Tables[0].Rows[0]["CashSale"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CouponValue"]!=null && ds.Tables[0].Rows[0]["CouponValue"].ToString()!="")
				{
					model.CouponValue=int.Parse(ds.Tables[0].Rows[0]["CouponValue"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Base"]!=null && ds.Tables[0].Rows[0]["Base"].ToString()!="")
				{
					model.Base=decimal.Parse(ds.Tables[0].Rows[0]["Base"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MinAmt"]!=null && ds.Tables[0].Rows[0]["MinAmt"].ToString()!="")
				{
					model.MinAmt=decimal.Parse(ds.Tables[0].Rows[0]["MinAmt"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MaxAmt"]!=null && ds.Tables[0].Rows[0]["MaxAmt"].ToString()!="")
				{
					model.MaxAmt=decimal.Parse(ds.Tables[0].Rows[0]["MaxAmt"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardType"]!=null && ds.Tables[0].Rows[0]["CardType"].ToString()!="")
				{
					model.CardType=ds.Tables[0].Rows[0]["CardType"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CardBegin"]!=null && ds.Tables[0].Rows[0]["CardBegin"].ToString()!="")
				{
					model.CardBegin=ds.Tables[0].Rows[0]["CardBegin"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CardEnd"]!=null && ds.Tables[0].Rows[0]["CardEnd"].ToString()!="")
				{
					model.CardEnd=ds.Tables[0].Rows[0]["CardEnd"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CardLen"]!=null && ds.Tables[0].Rows[0]["CardLen"].ToString()!="")
				{
					model.CardLen=int.Parse(ds.Tables[0].Rows[0]["CardLen"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AccountCode"]!=null && ds.Tables[0].Rows[0]["AccountCode"].ToString()!="")
				{
					model.AccountCode=ds.Tables[0].Rows[0]["AccountCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ContraCode"]!=null && ds.Tables[0].Rows[0]["ContraCode"].ToString()!="")
				{
					model.ContraCode=ds.Tables[0].Rows[0]["ContraCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PayTransfer"]!=null && ds.Tables[0].Rows[0]["PayTransfer"].ToString()!="")
				{
					model.PayTransfer=int.Parse(ds.Tables[0].Rows[0]["PayTransfer"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Refund_Type"]!=null && ds.Tables[0].Rows[0]["Refund_Type"].ToString()!="")
				{
					model.Refund_Type=int.Parse(ds.Tables[0].Rows[0]["Refund_Type"].ToString());
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

        public Edge.SVA.Model.BUY_CURRENCY GetCurrencyByType(int Type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CurrencyID,CurrencyCode,CurrencyName1,CurrencyName2,CurrencyName3,Rate,TenderType,Status,CashSale,CouponValue,Base,MinAmt,MaxAmt,CardType,CardBegin,CardEnd,CardLen,AccountCode,ContraCode,PayTransfer,Refund_Type,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_CURRENCY ");
            strSql.Append(" where TenderType=@TenderType");
            SqlParameter[] parameters = {
					new SqlParameter("@TenderType", SqlDbType.Int,4)
			};
            parameters[0].Value = Type;
            Edge.SVA.Model.BUY_CURRENCY model = new Edge.SVA.Model.BUY_CURRENCY();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CurrencyID"] != null && ds.Tables[0].Rows[0]["CurrencyID"].ToString() != "")
                {
                    model.CurrencyID = int.Parse(ds.Tables[0].Rows[0]["CurrencyID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CurrencyCode"] != null && ds.Tables[0].Rows[0]["CurrencyCode"].ToString() != "")
                {
                    model.CurrencyCode = ds.Tables[0].Rows[0]["CurrencyCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CurrencyName1"] != null && ds.Tables[0].Rows[0]["CurrencyName1"].ToString() != "")
                {
                    model.CurrencyName1 = ds.Tables[0].Rows[0]["CurrencyName1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CurrencyName2"] != null && ds.Tables[0].Rows[0]["CurrencyName2"].ToString() != "")
                {
                    model.CurrencyName2 = ds.Tables[0].Rows[0]["CurrencyName2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CurrencyName3"] != null && ds.Tables[0].Rows[0]["CurrencyName3"].ToString() != "")
                {
                    model.CurrencyName3 = ds.Tables[0].Rows[0]["CurrencyName3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Rate"] != null && ds.Tables[0].Rows[0]["Rate"].ToString() != "")
                {
                    model.Rate = decimal.Parse(ds.Tables[0].Rows[0]["Rate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TenderType"] != null && ds.Tables[0].Rows[0]["TenderType"].ToString() != "")
                {
                    model.TenderType = int.Parse(ds.Tables[0].Rows[0]["TenderType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CashSale"] != null && ds.Tables[0].Rows[0]["CashSale"].ToString() != "")
                {
                    model.CashSale = int.Parse(ds.Tables[0].Rows[0]["CashSale"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CouponValue"] != null && ds.Tables[0].Rows[0]["CouponValue"].ToString() != "")
                {
                    model.CouponValue = int.Parse(ds.Tables[0].Rows[0]["CouponValue"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Base"] != null && ds.Tables[0].Rows[0]["Base"].ToString() != "")
                {
                    model.Base = decimal.Parse(ds.Tables[0].Rows[0]["Base"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MinAmt"] != null && ds.Tables[0].Rows[0]["MinAmt"].ToString() != "")
                {
                    model.MinAmt = decimal.Parse(ds.Tables[0].Rows[0]["MinAmt"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MaxAmt"] != null && ds.Tables[0].Rows[0]["MaxAmt"].ToString() != "")
                {
                    model.MaxAmt = decimal.Parse(ds.Tables[0].Rows[0]["MaxAmt"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CardType"] != null && ds.Tables[0].Rows[0]["CardType"].ToString() != "")
                {
                    model.CardType = ds.Tables[0].Rows[0]["CardType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CardBegin"] != null && ds.Tables[0].Rows[0]["CardBegin"].ToString() != "")
                {
                    model.CardBegin = ds.Tables[0].Rows[0]["CardBegin"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CardEnd"] != null && ds.Tables[0].Rows[0]["CardEnd"].ToString() != "")
                {
                    model.CardEnd = ds.Tables[0].Rows[0]["CardEnd"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CardLen"] != null && ds.Tables[0].Rows[0]["CardLen"].ToString() != "")
                {
                    model.CardLen = int.Parse(ds.Tables[0].Rows[0]["CardLen"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AccountCode"] != null && ds.Tables[0].Rows[0]["AccountCode"].ToString() != "")
                {
                    model.AccountCode = ds.Tables[0].Rows[0]["AccountCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContraCode"] != null && ds.Tables[0].Rows[0]["ContraCode"].ToString() != "")
                {
                    model.ContraCode = ds.Tables[0].Rows[0]["ContraCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PayTransfer"] != null && ds.Tables[0].Rows[0]["PayTransfer"].ToString() != "")
                {
                    model.PayTransfer = int.Parse(ds.Tables[0].Rows[0]["PayTransfer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Refund_Type"] != null && ds.Tables[0].Rows[0]["Refund_Type"].ToString() != "")
                {
                    model.Refund_Type = int.Parse(ds.Tables[0].Rows[0]["Refund_Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedOn"] != null && ds.Tables[0].Rows[0]["CreatedOn"].ToString() != "")
                {
                    model.CreatedOn = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedBy"] != null && ds.Tables[0].Rows[0]["CreatedBy"].ToString() != "")
                {
                    model.CreatedBy = int.Parse(ds.Tables[0].Rows[0]["CreatedBy"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdatedOn"] != null && ds.Tables[0].Rows[0]["UpdatedOn"].ToString() != "")
                {
                    model.UpdatedOn = DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdatedBy"] != null && ds.Tables[0].Rows[0]["UpdatedBy"].ToString() != "")
                {
                    model.UpdatedBy = int.Parse(ds.Tables[0].Rows[0]["UpdatedBy"].ToString());
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
			strSql.Append("select CurrencyID,CurrencyCode,CurrencyName1,CurrencyName2,CurrencyName3,Rate,TenderType,Status,CashSale,CouponValue,Base,MinAmt,MaxAmt,CardType,CardBegin,CardEnd,CardLen,AccountCode,ContraCode,PayTransfer,Refund_Type,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_CURRENCY ");
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
			strSql.Append(" CurrencyID,CurrencyCode,CurrencyName1,CurrencyName2,CurrencyName3,Rate,TenderType,Status,CashSale,CouponValue,Base,MinAmt,MaxAmt,CardType,CardBegin,CardEnd,CardLen,AccountCode,ContraCode,PayTransfer,Refund_Type,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_CURRENCY ");
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
			strSql.Append("select count(1) FROM BUY_CURRENCY ");
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
				strSql.Append("order by T.CurrencyID desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_CURRENCY T ");
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
			parameters[0].Value = "BUY_CURRENCY";
			parameters[1].Value = "CurrencyID";
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

