using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:SVA_Transfer_H
	/// </summary>
	public partial class SVA_Transfer_H:ISVA_Transfer_H
	{
		public SVA_Transfer_H()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Number)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SVA_Transfer_H");
			strSql.Append(" where Number=@Number ");
			SqlParameter[] parameters = {
					new SqlParameter("@Number", SqlDbType.VarChar,20)};
			parameters[0].Value = Number;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.SVA_Transfer_H model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SVA_Transfer_H(");
			strSql.Append("Number,RefTxnNo,TxnDate,ShopID,ServerID,POSID,Note,Amount,TotalAmt,CardCount,FormNo,Status,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@Number,@RefTxnNo,@TxnDate,@ShopID,@ServerID,@POSID,@Note,@Amount,@TotalAmt,@CardCount,@FormNo,@Status,@ApproveOn,@ApproveBy,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@Number", SqlDbType.VarChar,20),
					new SqlParameter("@RefTxnNo", SqlDbType.VarChar,30),
					new SqlParameter("@TxnDate", SqlDbType.DateTime),
					new SqlParameter("@ShopID", SqlDbType.VarChar,8),
					new SqlParameter("@ServerID", SqlDbType.VarChar,30),
					new SqlParameter("@POSID", SqlDbType.VarChar,8),
					new SqlParameter("@Note", SqlDbType.VarChar,100),
					new SqlParameter("@Amount", SqlDbType.Money,8),
					new SqlParameter("@TotalAmt", SqlDbType.Money,8),
					new SqlParameter("@CardCount", SqlDbType.Int,4),
					new SqlParameter("@FormNo", SqlDbType.VarChar,30),
					new SqlParameter("@Status", SqlDbType.Char,1),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.VarChar,10),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.VarChar,10),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.VarChar,10)};
			parameters[0].Value = model.Number;
			parameters[1].Value = model.RefTxnNo;
			parameters[2].Value = model.TxnDate;
			parameters[3].Value = model.ShopID;
			parameters[4].Value = model.ServerID;
			parameters[5].Value = model.POSID;
			parameters[6].Value = model.Note;
			parameters[7].Value = model.Amount;
			parameters[8].Value = model.TotalAmt;
			parameters[9].Value = model.CardCount;
			parameters[10].Value = model.FormNo;
			parameters[11].Value = model.Status;
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
		public bool Update(Edge.SVA.Model.SVA_Transfer_H model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SVA_Transfer_H set ");
			strSql.Append("RefTxnNo=@RefTxnNo,");
			strSql.Append("TxnDate=@TxnDate,");
			strSql.Append("ShopID=@ShopID,");
			strSql.Append("ServerID=@ServerID,");
			strSql.Append("POSID=@POSID,");
			strSql.Append("Note=@Note,");
			strSql.Append("Amount=@Amount,");
			strSql.Append("TotalAmt=@TotalAmt,");
			strSql.Append("CardCount=@CardCount,");
			strSql.Append("FormNo=@FormNo,");
			strSql.Append("Status=@Status,");
			strSql.Append("ApproveOn=@ApproveOn,");
			strSql.Append("ApproveBy=@ApproveBy,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where Number=@Number ");
			SqlParameter[] parameters = {
					new SqlParameter("@RefTxnNo", SqlDbType.VarChar,30),
					new SqlParameter("@TxnDate", SqlDbType.DateTime),
					new SqlParameter("@ShopID", SqlDbType.VarChar,8),
					new SqlParameter("@ServerID", SqlDbType.VarChar,30),
					new SqlParameter("@POSID", SqlDbType.VarChar,8),
					new SqlParameter("@Note", SqlDbType.VarChar,100),
					new SqlParameter("@Amount", SqlDbType.Money,8),
					new SqlParameter("@TotalAmt", SqlDbType.Money,8),
					new SqlParameter("@CardCount", SqlDbType.Int,4),
					new SqlParameter("@FormNo", SqlDbType.VarChar,30),
					new SqlParameter("@Status", SqlDbType.Char,1),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.VarChar,10),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.VarChar,10),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.VarChar,10),
					new SqlParameter("@Number", SqlDbType.VarChar,20)};
			parameters[0].Value = model.RefTxnNo;
			parameters[1].Value = model.TxnDate;
			parameters[2].Value = model.ShopID;
			parameters[3].Value = model.ServerID;
			parameters[4].Value = model.POSID;
			parameters[5].Value = model.Note;
			parameters[6].Value = model.Amount;
			parameters[7].Value = model.TotalAmt;
			parameters[8].Value = model.CardCount;
			parameters[9].Value = model.FormNo;
			parameters[10].Value = model.Status;
			parameters[11].Value = model.ApproveOn;
			parameters[12].Value = model.ApproveBy;
			parameters[13].Value = model.CreatedOn;
			parameters[14].Value = model.CreatedBy;
			parameters[15].Value = model.UpdatedOn;
			parameters[16].Value = model.UpdatedBy;
			parameters[17].Value = model.Number;

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
		public bool Delete(string Number)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SVA_Transfer_H ");
			strSql.Append(" where Number=@Number ");
			SqlParameter[] parameters = {
					new SqlParameter("@Number", SqlDbType.VarChar,20)};
			parameters[0].Value = Number;

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
		public bool DeleteList(string Numberlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SVA_Transfer_H ");
			strSql.Append(" where Number in ("+Numberlist + ")  ");
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
		public Edge.SVA.Model.SVA_Transfer_H GetModel(string Number)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Number,RefTxnNo,TxnDate,ShopID,ServerID,POSID,Note,Amount,TotalAmt,CardCount,FormNo,Status,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from SVA_Transfer_H ");
			strSql.Append(" where Number=@Number ");
			SqlParameter[] parameters = {
					new SqlParameter("@Number", SqlDbType.VarChar,20)};
			parameters[0].Value = Number;

			Edge.SVA.Model.SVA_Transfer_H model=new Edge.SVA.Model.SVA_Transfer_H();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Number"]!=null && ds.Tables[0].Rows[0]["Number"].ToString()!="")
				{
					model.Number=ds.Tables[0].Rows[0]["Number"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RefTxnNo"]!=null && ds.Tables[0].Rows[0]["RefTxnNo"].ToString()!="")
				{
					model.RefTxnNo=ds.Tables[0].Rows[0]["RefTxnNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TxnDate"]!=null && ds.Tables[0].Rows[0]["TxnDate"].ToString()!="")
				{
					model.TxnDate=DateTime.Parse(ds.Tables[0].Rows[0]["TxnDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ShopID"]!=null && ds.Tables[0].Rows[0]["ShopID"].ToString()!="")
				{
					model.ShopID=ds.Tables[0].Rows[0]["ShopID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ServerID"]!=null && ds.Tables[0].Rows[0]["ServerID"].ToString()!="")
				{
					model.ServerID=ds.Tables[0].Rows[0]["ServerID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["POSID"]!=null && ds.Tables[0].Rows[0]["POSID"].ToString()!="")
				{
					model.POSID=ds.Tables[0].Rows[0]["POSID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Note"]!=null && ds.Tables[0].Rows[0]["Note"].ToString()!="")
				{
					model.Note=ds.Tables[0].Rows[0]["Note"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Amount"]!=null && ds.Tables[0].Rows[0]["Amount"].ToString()!="")
				{
					model.Amount=decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TotalAmt"]!=null && ds.Tables[0].Rows[0]["TotalAmt"].ToString()!="")
				{
					model.TotalAmt=decimal.Parse(ds.Tables[0].Rows[0]["TotalAmt"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardCount"]!=null && ds.Tables[0].Rows[0]["CardCount"].ToString()!="")
				{
					model.CardCount=int.Parse(ds.Tables[0].Rows[0]["CardCount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FormNo"]!=null && ds.Tables[0].Rows[0]["FormNo"].ToString()!="")
				{
					model.FormNo=ds.Tables[0].Rows[0]["FormNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=ds.Tables[0].Rows[0]["Status"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ApproveOn"]!=null && ds.Tables[0].Rows[0]["ApproveOn"].ToString()!="")
				{
					model.ApproveOn=DateTime.Parse(ds.Tables[0].Rows[0]["ApproveOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApproveBy"]!=null && ds.Tables[0].Rows[0]["ApproveBy"].ToString()!="")
				{
					model.ApproveBy=ds.Tables[0].Rows[0]["ApproveBy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CreatedOn"]!=null && ds.Tables[0].Rows[0]["CreatedOn"].ToString()!="")
				{
					model.CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedBy"]!=null && ds.Tables[0].Rows[0]["CreatedBy"].ToString()!="")
				{
					model.CreatedBy=ds.Tables[0].Rows[0]["CreatedBy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["UpdatedOn"]!=null && ds.Tables[0].Rows[0]["UpdatedOn"].ToString()!="")
				{
					model.UpdatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedBy"]!=null && ds.Tables[0].Rows[0]["UpdatedBy"].ToString()!="")
				{
					model.UpdatedBy=ds.Tables[0].Rows[0]["UpdatedBy"].ToString();
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
			strSql.Append("select Number,RefTxnNo,TxnDate,ShopID,ServerID,POSID,Note,Amount,TotalAmt,CardCount,FormNo,Status,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM SVA_Transfer_H ");
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
			strSql.Append(" Number,RefTxnNo,TxnDate,ShopID,ServerID,POSID,Note,Amount,TotalAmt,CardCount,FormNo,Status,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM SVA_Transfer_H ");
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
			parameters[0].Value = "SVA_Transfer_H";
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
            sql.Append("select count(*) from SVA_Transfer_H ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }
		#endregion  Method
	}
}

