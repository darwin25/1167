using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:POSSalesData
	/// </summary>
	public partial class POSSalesData:IPOSSalesData
	{
		public POSSalesData()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SN)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from POSSalesData");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,30)};
			parameters[0].Value = SN;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.POSSalesData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into POSSalesData(");
			strSql.Append("SN,TxnNo,TxnType,TxnAmount,BusDate,TxnDate,ImportDate,OriginalTxnNo,CardID,StoreId,ServerId,PosId,SVACardNum,CardType)");
			strSql.Append(" values (");
			strSql.Append("@SN,@TxnNo,@TxnType,@TxnAmount,@BusDate,@TxnDate,@ImportDate,@OriginalTxnNo,@CardID,@StoreId,@ServerId,@PosId,@SVACardNum,@CardType)");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,30),
					new SqlParameter("@TxnNo", SqlDbType.VarChar,30),
					new SqlParameter("@TxnType", SqlDbType.VarChar,20),
					new SqlParameter("@TxnAmount", SqlDbType.Float,8),
					new SqlParameter("@BusDate", SqlDbType.DateTime),
					new SqlParameter("@TxnDate", SqlDbType.DateTime),
					new SqlParameter("@ImportDate", SqlDbType.DateTime),
					new SqlParameter("@OriginalTxnNo", SqlDbType.VarChar,30),
					new SqlParameter("@CardID", SqlDbType.VarChar,60),
					new SqlParameter("@StoreId", SqlDbType.VarChar,20),
					new SqlParameter("@ServerId", SqlDbType.VarChar,20),
					new SqlParameter("@PosId", SqlDbType.VarChar,20),
					new SqlParameter("@SVACardNum", SqlDbType.VarChar,60),
					new SqlParameter("@CardType", SqlDbType.VarChar,40)};
			parameters[0].Value = model.SN;
			parameters[1].Value = model.TxnNo;
			parameters[2].Value = model.TxnType;
			parameters[3].Value = model.TxnAmount;
			parameters[4].Value = model.BusDate;
			parameters[5].Value = model.TxnDate;
			parameters[6].Value = model.ImportDate;
			parameters[7].Value = model.OriginalTxnNo;
			parameters[8].Value = model.CardID;
			parameters[9].Value = model.StoreId;
			parameters[10].Value = model.ServerId;
			parameters[11].Value = model.PosId;
			parameters[12].Value = model.SVACardNum;
			parameters[13].Value = model.CardType;

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
		public bool Update(Edge.SVA.Model.POSSalesData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update POSSalesData set ");
			strSql.Append("TxnNo=@TxnNo,");
			strSql.Append("TxnType=@TxnType,");
			strSql.Append("TxnAmount=@TxnAmount,");
			strSql.Append("BusDate=@BusDate,");
			strSql.Append("TxnDate=@TxnDate,");
			strSql.Append("ImportDate=@ImportDate,");
			strSql.Append("OriginalTxnNo=@OriginalTxnNo,");
			strSql.Append("CardID=@CardID,");
			strSql.Append("StoreId=@StoreId,");
			strSql.Append("ServerId=@ServerId,");
			strSql.Append("PosId=@PosId,");
			strSql.Append("SVACardNum=@SVACardNum,");
			strSql.Append("CardType=@CardType");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@TxnNo", SqlDbType.VarChar,30),
					new SqlParameter("@TxnType", SqlDbType.VarChar,20),
					new SqlParameter("@TxnAmount", SqlDbType.Float,8),
					new SqlParameter("@BusDate", SqlDbType.DateTime),
					new SqlParameter("@TxnDate", SqlDbType.DateTime),
					new SqlParameter("@ImportDate", SqlDbType.DateTime),
					new SqlParameter("@OriginalTxnNo", SqlDbType.VarChar,30),
					new SqlParameter("@CardID", SqlDbType.VarChar,60),
					new SqlParameter("@StoreId", SqlDbType.VarChar,20),
					new SqlParameter("@ServerId", SqlDbType.VarChar,20),
					new SqlParameter("@PosId", SqlDbType.VarChar,20),
					new SqlParameter("@SVACardNum", SqlDbType.VarChar,60),
					new SqlParameter("@CardType", SqlDbType.VarChar,40),
					new SqlParameter("@SN", SqlDbType.VarChar,30)};
			parameters[0].Value = model.TxnNo;
			parameters[1].Value = model.TxnType;
			parameters[2].Value = model.TxnAmount;
			parameters[3].Value = model.BusDate;
			parameters[4].Value = model.TxnDate;
			parameters[5].Value = model.ImportDate;
			parameters[6].Value = model.OriginalTxnNo;
			parameters[7].Value = model.CardID;
			parameters[8].Value = model.StoreId;
			parameters[9].Value = model.ServerId;
			parameters[10].Value = model.PosId;
			parameters[11].Value = model.SVACardNum;
			parameters[12].Value = model.CardType;
			parameters[13].Value = model.SN;

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
		public bool Delete(string SN)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from POSSalesData ");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,30)};
			parameters[0].Value = SN;

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
		public bool DeleteList(string SNlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from POSSalesData ");
			strSql.Append(" where SN in ("+SNlist + ")  ");
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
		public Edge.SVA.Model.POSSalesData GetModel(string SN)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SN,TxnNo,TxnType,TxnAmount,BusDate,TxnDate,ImportDate,OriginalTxnNo,CardID,StoreId,ServerId,PosId,SVACardNum,CardType from POSSalesData ");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,30)};
			parameters[0].Value = SN;

			Edge.SVA.Model.POSSalesData model=new Edge.SVA.Model.POSSalesData();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["SN"]!=null && ds.Tables[0].Rows[0]["SN"].ToString()!="")
				{
					model.SN=ds.Tables[0].Rows[0]["SN"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TxnNo"]!=null && ds.Tables[0].Rows[0]["TxnNo"].ToString()!="")
				{
					model.TxnNo=ds.Tables[0].Rows[0]["TxnNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TxnType"]!=null && ds.Tables[0].Rows[0]["TxnType"].ToString()!="")
				{
					model.TxnType=ds.Tables[0].Rows[0]["TxnType"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TxnAmount"]!=null && ds.Tables[0].Rows[0]["TxnAmount"].ToString()!="")
				{
					model.TxnAmount=decimal.Parse(ds.Tables[0].Rows[0]["TxnAmount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BusDate"]!=null && ds.Tables[0].Rows[0]["BusDate"].ToString()!="")
				{
					model.BusDate=DateTime.Parse(ds.Tables[0].Rows[0]["BusDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TxnDate"]!=null && ds.Tables[0].Rows[0]["TxnDate"].ToString()!="")
				{
					model.TxnDate=DateTime.Parse(ds.Tables[0].Rows[0]["TxnDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImportDate"]!=null && ds.Tables[0].Rows[0]["ImportDate"].ToString()!="")
				{
					model.ImportDate=DateTime.Parse(ds.Tables[0].Rows[0]["ImportDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OriginalTxnNo"]!=null && ds.Tables[0].Rows[0]["OriginalTxnNo"].ToString()!="")
				{
					model.OriginalTxnNo=ds.Tables[0].Rows[0]["OriginalTxnNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CardID"]!=null && ds.Tables[0].Rows[0]["CardID"].ToString()!="")
				{
					model.CardID=ds.Tables[0].Rows[0]["CardID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreId"]!=null && ds.Tables[0].Rows[0]["StoreId"].ToString()!="")
				{
					model.StoreId=ds.Tables[0].Rows[0]["StoreId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ServerId"]!=null && ds.Tables[0].Rows[0]["ServerId"].ToString()!="")
				{
					model.ServerId=ds.Tables[0].Rows[0]["ServerId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PosId"]!=null && ds.Tables[0].Rows[0]["PosId"].ToString()!="")
				{
					model.PosId=ds.Tables[0].Rows[0]["PosId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SVACardNum"]!=null && ds.Tables[0].Rows[0]["SVACardNum"].ToString()!="")
				{
					model.SVACardNum=ds.Tables[0].Rows[0]["SVACardNum"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CardType"]!=null && ds.Tables[0].Rows[0]["CardType"].ToString()!="")
				{
					model.CardType=ds.Tables[0].Rows[0]["CardType"].ToString();
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
			strSql.Append("select SN,TxnNo,TxnType,TxnAmount,BusDate,TxnDate,ImportDate,OriginalTxnNo,CardID,StoreId,ServerId,PosId,SVACardNum,CardType ");
			strSql.Append(" FROM POSSalesData ");
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
			strSql.Append(" SN,TxnNo,TxnType,TxnAmount,BusDate,TxnDate,ImportDate,OriginalTxnNo,CardID,StoreId,ServerId,PosId,SVACardNum,CardType ");
			strSql.Append(" FROM POSSalesData ");
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
			parameters[0].Value = "POSSalesData";
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
            sql.Append("select count(*) from POSSalesData ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

