using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:TENDER
	/// </summary>
	public partial class TENDER:ITENDER
	{
		public TENDER()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("TenderID", "TENDER"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string TenderCode,int TenderID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TENDER");
			strSql.Append(" where TenderCode=@TenderCode and TenderID=@TenderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TenderCode", SqlDbType.VarChar,512),
					new SqlParameter("@TenderID", SqlDbType.Int,4)};
			parameters[0].Value = TenderCode;
			parameters[1].Value = TenderID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.TENDER model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TENDER(");
			strSql.Append("TenderCode,TenderTyep,TenderName1,TenderName2,TenderName3,CashSale,Status,Base,Rate,MinAmount,MaxAmount,CardBegin,CardEnd,CardLen,Additional,BankID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@TenderCode,@TenderTyep,@TenderName1,@TenderName2,@TenderName3,@CashSale,@Status,@Base,@Rate,@MinAmount,@MaxAmount,@CardBegin,@CardEnd,@CardLen,@Additional,@BankID,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@TenderCode", SqlDbType.VarChar,512),
					new SqlParameter("@TenderTyep", SqlDbType.Int,4),
					new SqlParameter("@TenderName1", SqlDbType.NVarChar,512),
					new SqlParameter("@TenderName2", SqlDbType.NVarChar,512),
					new SqlParameter("@TenderName3", SqlDbType.NVarChar,512),
					new SqlParameter("@CashSale", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Base", SqlDbType.Decimal,9),
					new SqlParameter("@Rate", SqlDbType.Decimal,9),
					new SqlParameter("@MinAmount", SqlDbType.Float,8),
					new SqlParameter("@MaxAmount", SqlDbType.Float,8),
					new SqlParameter("@CardBegin", SqlDbType.VarChar,512),
					new SqlParameter("@CardEnd", SqlDbType.VarChar,512),
					new SqlParameter("@CardLen", SqlDbType.Int,4),
					new SqlParameter("@Additional", SqlDbType.VarChar,512),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.TenderCode;
			parameters[1].Value = model.TenderTyep;
			parameters[2].Value = model.TenderName1;
			parameters[3].Value = model.TenderName2;
			parameters[4].Value = model.TenderName3;
			parameters[5].Value = model.CashSale;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.Base;
			parameters[8].Value = model.Rate;
			parameters[9].Value = model.MinAmount;
			parameters[10].Value = model.MaxAmount;
			parameters[11].Value = model.CardBegin;
			parameters[12].Value = model.CardEnd;
			parameters[13].Value = model.CardLen;
			parameters[14].Value = model.Additional;
			parameters[15].Value = model.BankID;
			parameters[16].Value = model.CreatedOn;
			parameters[17].Value = model.CreatedBy;
			parameters[18].Value = model.UpdatedOn;
			parameters[19].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.TENDER model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TENDER set ");
			strSql.Append("TenderTyep=@TenderTyep,");
			strSql.Append("TenderName1=@TenderName1,");
			strSql.Append("TenderName2=@TenderName2,");
			strSql.Append("TenderName3=@TenderName3,");
			strSql.Append("CashSale=@CashSale,");
			strSql.Append("Status=@Status,");
			strSql.Append("Base=@Base,");
			strSql.Append("Rate=@Rate,");
			strSql.Append("MinAmount=@MinAmount,");
			strSql.Append("MaxAmount=@MaxAmount,");
			strSql.Append("CardBegin=@CardBegin,");
			strSql.Append("CardEnd=@CardEnd,");
			strSql.Append("CardLen=@CardLen,");
			strSql.Append("Additional=@Additional,");
			strSql.Append("BankID=@BankID,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where TenderID=@TenderID");
			SqlParameter[] parameters = {
					new SqlParameter("@TenderTyep", SqlDbType.Int,4),
					new SqlParameter("@TenderName1", SqlDbType.NVarChar,512),
					new SqlParameter("@TenderName2", SqlDbType.NVarChar,512),
					new SqlParameter("@TenderName3", SqlDbType.NVarChar,512),
					new SqlParameter("@CashSale", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Base", SqlDbType.Decimal,9),
					new SqlParameter("@Rate", SqlDbType.Decimal,9),
					new SqlParameter("@MinAmount", SqlDbType.Float,8),
					new SqlParameter("@MaxAmount", SqlDbType.Float,8),
					new SqlParameter("@CardBegin", SqlDbType.VarChar,512),
					new SqlParameter("@CardEnd", SqlDbType.VarChar,512),
					new SqlParameter("@CardLen", SqlDbType.Int,4),
					new SqlParameter("@Additional", SqlDbType.VarChar,512),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@TenderID", SqlDbType.Int,4),
					new SqlParameter("@TenderCode", SqlDbType.VarChar,512)};
			parameters[0].Value = model.TenderTyep;
			parameters[1].Value = model.TenderName1;
			parameters[2].Value = model.TenderName2;
			parameters[3].Value = model.TenderName3;
			parameters[4].Value = model.CashSale;
			parameters[5].Value = model.Status;
			parameters[6].Value = model.Base;
			parameters[7].Value = model.Rate;
			parameters[8].Value = model.MinAmount;
			parameters[9].Value = model.MaxAmount;
			parameters[10].Value = model.CardBegin;
			parameters[11].Value = model.CardEnd;
			parameters[12].Value = model.CardLen;
			parameters[13].Value = model.Additional;
			parameters[14].Value = model.BankID;
			parameters[15].Value = model.CreatedOn;
			parameters[16].Value = model.CreatedBy;
			parameters[17].Value = model.UpdatedOn;
			parameters[18].Value = model.UpdatedBy;
			parameters[19].Value = model.TenderID;
			parameters[20].Value = model.TenderCode;

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
		public bool Delete(int TenderID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TENDER ");
			strSql.Append(" where TenderID=@TenderID");
			SqlParameter[] parameters = {
					new SqlParameter("@TenderID", SqlDbType.Int,4)
};
			parameters[0].Value = TenderID;

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
		public bool Delete(string TenderCode,int TenderID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TENDER ");
			strSql.Append(" where TenderCode=@TenderCode and TenderID=@TenderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TenderCode", SqlDbType.VarChar,512),
					new SqlParameter("@TenderID", SqlDbType.Int,4)};
			parameters[0].Value = TenderCode;
			parameters[1].Value = TenderID;

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
		public bool DeleteList(string TenderIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TENDER ");
			strSql.Append(" where TenderID in ("+TenderIDlist + ")  ");
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
		public Edge.SVA.Model.TENDER GetModel(int TenderID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TenderID,TenderCode,TenderTyep,TenderName1,TenderName2,TenderName3,CashSale,Status,Base,Rate,MinAmount,MaxAmount,CardBegin,CardEnd,CardLen,Additional,BankID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from TENDER ");
			strSql.Append(" where TenderID=@TenderID");
			SqlParameter[] parameters = {
					new SqlParameter("@TenderID", SqlDbType.Int,4)
};
			parameters[0].Value = TenderID;

			Edge.SVA.Model.TENDER model=new Edge.SVA.Model.TENDER();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["TenderID"]!=null && ds.Tables[0].Rows[0]["TenderID"].ToString()!="")
				{
					model.TenderID=int.Parse(ds.Tables[0].Rows[0]["TenderID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TenderCode"]!=null && ds.Tables[0].Rows[0]["TenderCode"].ToString()!="")
				{
					model.TenderCode=ds.Tables[0].Rows[0]["TenderCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TenderTyep"]!=null && ds.Tables[0].Rows[0]["TenderTyep"].ToString()!="")
				{
					model.TenderTyep=int.Parse(ds.Tables[0].Rows[0]["TenderTyep"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TenderName1"]!=null && ds.Tables[0].Rows[0]["TenderName1"].ToString()!="")
				{
					model.TenderName1=ds.Tables[0].Rows[0]["TenderName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TenderName2"]!=null && ds.Tables[0].Rows[0]["TenderName2"].ToString()!="")
				{
					model.TenderName2=ds.Tables[0].Rows[0]["TenderName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TenderName3"]!=null && ds.Tables[0].Rows[0]["TenderName3"].ToString()!="")
				{
					model.TenderName3=ds.Tables[0].Rows[0]["TenderName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CashSale"]!=null && ds.Tables[0].Rows[0]["CashSale"].ToString()!="")
				{
					model.CashSale=int.Parse(ds.Tables[0].Rows[0]["CashSale"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Base"]!=null && ds.Tables[0].Rows[0]["Base"].ToString()!="")
				{
					model.Base=decimal.Parse(ds.Tables[0].Rows[0]["Base"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rate"]!=null && ds.Tables[0].Rows[0]["Rate"].ToString()!="")
				{
					model.Rate=decimal.Parse(ds.Tables[0].Rows[0]["Rate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MinAmount"]!=null && ds.Tables[0].Rows[0]["MinAmount"].ToString()!="")
				{
					model.MinAmount=decimal.Parse(ds.Tables[0].Rows[0]["MinAmount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MaxAmount"]!=null && ds.Tables[0].Rows[0]["MaxAmount"].ToString()!="")
				{
					model.MaxAmount=decimal.Parse(ds.Tables[0].Rows[0]["MaxAmount"].ToString());
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
				if(ds.Tables[0].Rows[0]["Additional"]!=null && ds.Tables[0].Rows[0]["Additional"].ToString()!="")
				{
					model.Additional=ds.Tables[0].Rows[0]["Additional"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BankID"]!=null && ds.Tables[0].Rows[0]["BankID"].ToString()!="")
				{
					model.BankID=int.Parse(ds.Tables[0].Rows[0]["BankID"].ToString());
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
			strSql.Append("select TenderID,TenderCode,TenderTyep,TenderName1,TenderName2,TenderName3,CashSale,Status,Base,Rate,MinAmount,MaxAmount,CardBegin,CardEnd,CardLen,Additional,BankID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM TENDER ");
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
			strSql.Append(" TenderID,TenderCode,TenderTyep,TenderName1,TenderName2,TenderName3,CashSale,Status,Base,Rate,MinAmount,MaxAmount,CardBegin,CardEnd,CardLen,Additional,BankID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM TENDER ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@OrderfldName",SqlDbType.VarChar,255),
                    new SqlParameter("@StatfldName",SqlDbType.VarChar,255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.NText),
					};
            parameters[0].Value = "TENDER";
            parameters[1].Value = "*";
            parameters[2].Value = filedOrder;
            parameters[3].Value = "";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 0;
            parameters[7].Value = 0;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPageOrder", parameters, "ds");
        }

        /// <summary>
        /// 获取行总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select count(*) from TENDER ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

