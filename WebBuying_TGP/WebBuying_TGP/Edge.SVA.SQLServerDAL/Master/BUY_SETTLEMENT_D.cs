using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_SETTLEMENT_D
	/// </summary>
	public partial class BUY_SETTLEMENT_D:IBUY_SETTLEMENT_D
	{
		public BUY_SETTLEMENT_D()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "BUY_SETTLEMENT_D"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_SETTLEMENT_D");
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
		public int Add(Edge.SVA.Model.BUY_SETTLEMENT_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_SETTLEMENT_D(");
			strSql.Append("SettlementCode,TransNum,SeqNum,StoreCode,Amount,NetAmount,CardNo,CardType,ApprovalCode,BankCode,Status,SettleDate,SettleBy,Installment)");
			strSql.Append(" values (");
			strSql.Append("@SettlementCode,@TransNum,@SeqNum,@StoreCode,@Amount,@NetAmount,@CardNo,@CardType,@ApprovalCode,@BankCode,@Status,@SettleDate,@SettleBy,@Installment)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SettlementCode", SqlDbType.VarChar,64),
					new SqlParameter("@TransNum", SqlDbType.VarChar,64),
					new SqlParameter("@SeqNum", SqlDbType.Int,4),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@NetAmount", SqlDbType.Decimal,9),
					new SqlParameter("@CardNo", SqlDbType.VarChar,64),
					new SqlParameter("@CardType", SqlDbType.VarChar,64),
					new SqlParameter("@ApprovalCode", SqlDbType.VarChar,64),
					new SqlParameter("@BankCode", SqlDbType.VarChar,64),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@SettleDate", SqlDbType.DateTime),
					new SqlParameter("@SettleBy", SqlDbType.Char,8),
					new SqlParameter("@Installment", SqlDbType.Int,4)};
			parameters[0].Value = model.SettlementCode;
			parameters[1].Value = model.TransNum;
			parameters[2].Value = model.SeqNum;
			parameters[3].Value = model.StoreCode;
			parameters[4].Value = model.Amount;
			parameters[5].Value = model.NetAmount;
			parameters[6].Value = model.CardNo;
			parameters[7].Value = model.CardType;
			parameters[8].Value = model.ApprovalCode;
			parameters[9].Value = model.BankCode;
			parameters[10].Value = model.Status;
			parameters[11].Value = model.SettleDate;
			parameters[12].Value = model.SettleBy;
			parameters[13].Value = model.Installment;

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
		public bool Update(Edge.SVA.Model.BUY_SETTLEMENT_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_SETTLEMENT_D set ");
			strSql.Append("SettlementCode=@SettlementCode,");
			strSql.Append("TransNum=@TransNum,");
			strSql.Append("SeqNum=@SeqNum,");
			strSql.Append("StoreCode=@StoreCode,");
			strSql.Append("Amount=@Amount,");
			strSql.Append("NetAmount=@NetAmount,");
			strSql.Append("CardNo=@CardNo,");
			strSql.Append("CardType=@CardType,");
			strSql.Append("ApprovalCode=@ApprovalCode,");
			strSql.Append("BankCode=@BankCode,");
			strSql.Append("Status=@Status,");
			strSql.Append("SettleDate=@SettleDate,");
			strSql.Append("SettleBy=@SettleBy,");
			strSql.Append("Installment=@Installment");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@SettlementCode", SqlDbType.VarChar,64),
					new SqlParameter("@TransNum", SqlDbType.VarChar,64),
					new SqlParameter("@SeqNum", SqlDbType.Int,4),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@NetAmount", SqlDbType.Decimal,9),
					new SqlParameter("@CardNo", SqlDbType.VarChar,64),
					new SqlParameter("@CardType", SqlDbType.VarChar,64),
					new SqlParameter("@ApprovalCode", SqlDbType.VarChar,64),
					new SqlParameter("@BankCode", SqlDbType.VarChar,64),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@SettleDate", SqlDbType.DateTime),
					new SqlParameter("@SettleBy", SqlDbType.Char,8),
					new SqlParameter("@Installment", SqlDbType.Int,4),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.SettlementCode;
			parameters[1].Value = model.TransNum;
			parameters[2].Value = model.SeqNum;
			parameters[3].Value = model.StoreCode;
			parameters[4].Value = model.Amount;
			parameters[5].Value = model.NetAmount;
			parameters[6].Value = model.CardNo;
			parameters[7].Value = model.CardType;
			parameters[8].Value = model.ApprovalCode;
			parameters[9].Value = model.BankCode;
			parameters[10].Value = model.Status;
			parameters[11].Value = model.SettleDate;
			parameters[12].Value = model.SettleBy;
			parameters[13].Value = model.Installment;
			parameters[14].Value = model.KeyID;

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
			strSql.Append("delete from BUY_SETTLEMENT_D ");
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
			strSql.Append("delete from BUY_SETTLEMENT_D ");
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
		public Edge.SVA.Model.BUY_SETTLEMENT_D GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,SettlementCode,TransNum,SeqNum,StoreCode,Amount,NetAmount,CardNo,CardType,ApprovalCode,BankCode,Status,SettleDate,SettleBy,Installment from BUY_SETTLEMENT_D ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.BUY_SETTLEMENT_D model=new Edge.SVA.Model.BUY_SETTLEMENT_D();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SettlementCode"]!=null && ds.Tables[0].Rows[0]["SettlementCode"].ToString()!="")
				{
					model.SettlementCode=ds.Tables[0].Rows[0]["SettlementCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TransNum"]!=null && ds.Tables[0].Rows[0]["TransNum"].ToString()!="")
				{
					model.TransNum=ds.Tables[0].Rows[0]["TransNum"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SeqNum"]!=null && ds.Tables[0].Rows[0]["SeqNum"].ToString()!="")
				{
					model.SeqNum=int.Parse(ds.Tables[0].Rows[0]["SeqNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StoreCode"]!=null && ds.Tables[0].Rows[0]["StoreCode"].ToString()!="")
				{
					model.StoreCode=ds.Tables[0].Rows[0]["StoreCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Amount"]!=null && ds.Tables[0].Rows[0]["Amount"].ToString()!="")
				{
					model.Amount=decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NetAmount"]!=null && ds.Tables[0].Rows[0]["NetAmount"].ToString()!="")
				{
					model.NetAmount=decimal.Parse(ds.Tables[0].Rows[0]["NetAmount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardNo"]!=null && ds.Tables[0].Rows[0]["CardNo"].ToString()!="")
				{
					model.CardNo=ds.Tables[0].Rows[0]["CardNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CardType"]!=null && ds.Tables[0].Rows[0]["CardType"].ToString()!="")
				{
					model.CardType=ds.Tables[0].Rows[0]["CardType"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ApprovalCode"]!=null && ds.Tables[0].Rows[0]["ApprovalCode"].ToString()!="")
				{
					model.ApprovalCode=ds.Tables[0].Rows[0]["ApprovalCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BankCode"]!=null && ds.Tables[0].Rows[0]["BankCode"].ToString()!="")
				{
					model.BankCode=ds.Tables[0].Rows[0]["BankCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SettleDate"]!=null && ds.Tables[0].Rows[0]["SettleDate"].ToString()!="")
				{
					model.SettleDate=DateTime.Parse(ds.Tables[0].Rows[0]["SettleDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SettleBy"]!=null && ds.Tables[0].Rows[0]["SettleBy"].ToString()!="")
				{
					model.SettleBy=ds.Tables[0].Rows[0]["SettleBy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Installment"]!=null && ds.Tables[0].Rows[0]["Installment"].ToString()!="")
				{
					model.Installment=int.Parse(ds.Tables[0].Rows[0]["Installment"].ToString());
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
			strSql.Append("select KeyID,SettlementCode,TransNum,SeqNum,StoreCode,Amount,NetAmount,CardNo,CardType,ApprovalCode,BankCode,Status,SettleDate,SettleBy,Installment ");
			strSql.Append(" FROM BUY_SETTLEMENT_D ");
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
			strSql.Append(" KeyID,SettlementCode,TransNum,SeqNum,StoreCode,Amount,NetAmount,CardNo,CardType,ApprovalCode,BankCode,Status,SettleDate,SettleBy,Installment ");
			strSql.Append(" FROM BUY_SETTLEMENT_D ");
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
			strSql.Append("select count(1) FROM BUY_SETTLEMENT_D ");
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
			strSql.Append(")AS Row, T.*  from BUY_SETTLEMENT_D T ");
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
			parameters[0].Value = "BUY_SETTLEMENT_D";
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

