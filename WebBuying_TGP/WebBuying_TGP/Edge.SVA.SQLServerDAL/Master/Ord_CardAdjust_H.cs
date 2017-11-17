using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Ord_CardAdjust_H
	/// </summary>
	public partial class Ord_CardAdjust_H:IOrd_CardAdjust_H
	{
		public Ord_CardAdjust_H()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CardAdjustNumber)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ord_CardAdjust_H");
			strSql.Append(" where CardAdjustNumber=@CardAdjustNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@CardAdjustNumber", SqlDbType.VarChar,512)};
			parameters[0].Value = CardAdjustNumber;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Ord_CardAdjust_H model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ord_CardAdjust_H(");
			strSql.Append("CardAdjustNumber,OprID,OriginalTxnNo,TxnDate,StoreCode,ServerCode,RegisterCode,ReasonID,Note,ActAmount,ActPoints,ActExpireDate,CardCount,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CreatedBusDate,ApproveBusDate,ApprovalCode,BrandCode)");
			strSql.Append(" values (");
			strSql.Append("@CardAdjustNumber,@OprID,@OriginalTxnNo,@TxnDate,@StoreCode,@ServerCode,@RegisterCode,@ReasonID,@Note,@ActAmount,@ActPoints,@ActExpireDate,@CardCount,@ApproveStatus,@ApproveOn,@ApproveBy,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@CreatedBusDate,@ApproveBusDate,@ApprovalCode,@BrandCode)");
			SqlParameter[] parameters = {
					new SqlParameter("@CardAdjustNumber", SqlDbType.VarChar,512),
					new SqlParameter("@OprID", SqlDbType.Int,4),
					new SqlParameter("@OriginalTxnNo", SqlDbType.VarChar,512),
					new SqlParameter("@TxnDate", SqlDbType.DateTime),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,512),
					new SqlParameter("@ServerCode", SqlDbType.VarChar,512),
					new SqlParameter("@RegisterCode", SqlDbType.VarChar,512),
					new SqlParameter("@ReasonID", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.VarChar,512),
					new SqlParameter("@ActAmount", SqlDbType.Money,8),
					new SqlParameter("@ActPoints", SqlDbType.Int,4),
					new SqlParameter("@ActExpireDate", SqlDbType.DateTime),
					new SqlParameter("@CardCount", SqlDbType.Int,4),
					new SqlParameter("@ApproveStatus", SqlDbType.Char,1),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApproveBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApprovalCode", SqlDbType.VarChar,512),
					new SqlParameter("@BrandCode", SqlDbType.VarChar,512)};
			parameters[0].Value = model.CardAdjustNumber;
			parameters[1].Value = model.OprID;
			parameters[2].Value = model.OriginalTxnNo;
			parameters[3].Value = model.TxnDate;
			parameters[4].Value = model.StoreCode;
			parameters[5].Value = model.ServerCode;
			parameters[6].Value = model.RegisterCode;
			parameters[7].Value = model.ReasonID;
			parameters[8].Value = model.Note;
			parameters[9].Value = model.ActAmount;
			parameters[10].Value = model.ActPoints;
			parameters[11].Value = model.ActExpireDate;
			parameters[12].Value = model.CardCount;
			parameters[13].Value = model.ApproveStatus;
			parameters[14].Value = model.ApproveOn;
			parameters[15].Value = model.ApproveBy;
			parameters[16].Value = model.CreatedOn;
			parameters[17].Value = model.CreatedBy;
			parameters[18].Value = model.UpdatedOn;
			parameters[19].Value = model.UpdatedBy;
			parameters[20].Value = model.CreatedBusDate;
			parameters[21].Value = model.ApproveBusDate;
			parameters[22].Value = model.ApprovalCode;
			parameters[23].Value = model.BrandCode;

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
		public bool Update(Edge.SVA.Model.Ord_CardAdjust_H model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ord_CardAdjust_H set ");
			strSql.Append("OprID=@OprID,");
			strSql.Append("OriginalTxnNo=@OriginalTxnNo,");
			strSql.Append("TxnDate=@TxnDate,");
			strSql.Append("StoreCode=@StoreCode,");
			strSql.Append("ServerCode=@ServerCode,");
			strSql.Append("RegisterCode=@RegisterCode,");
			strSql.Append("ReasonID=@ReasonID,");
			strSql.Append("Note=@Note,");
			strSql.Append("ActAmount=@ActAmount,");
			strSql.Append("ActPoints=@ActPoints,");
			strSql.Append("ActExpireDate=@ActExpireDate,");
			strSql.Append("CardCount=@CardCount,");
			strSql.Append("ApproveStatus=@ApproveStatus,");
			strSql.Append("ApproveOn=@ApproveOn,");
			strSql.Append("ApproveBy=@ApproveBy,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("CreatedBusDate=@CreatedBusDate,");
			strSql.Append("ApproveBusDate=@ApproveBusDate,");
			strSql.Append("ApprovalCode=@ApprovalCode,");
			strSql.Append("BrandCode=@BrandCode");
			strSql.Append(" where CardAdjustNumber=@CardAdjustNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@OprID", SqlDbType.Int,4),
					new SqlParameter("@OriginalTxnNo", SqlDbType.VarChar,512),
					new SqlParameter("@TxnDate", SqlDbType.DateTime),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,512),
					new SqlParameter("@ServerCode", SqlDbType.VarChar,512),
					new SqlParameter("@RegisterCode", SqlDbType.VarChar,512),
					new SqlParameter("@ReasonID", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.VarChar,512),
					new SqlParameter("@ActAmount", SqlDbType.Money,8),
					new SqlParameter("@ActPoints", SqlDbType.Int,4),
					new SqlParameter("@ActExpireDate", SqlDbType.DateTime),
					new SqlParameter("@CardCount", SqlDbType.Int,4),
					new SqlParameter("@ApproveStatus", SqlDbType.Char,1),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApproveBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApprovalCode", SqlDbType.VarChar,512),
					new SqlParameter("@BrandCode", SqlDbType.VarChar,512),
					new SqlParameter("@CardAdjustNumber", SqlDbType.VarChar,512)};
			parameters[0].Value = model.OprID;
			parameters[1].Value = model.OriginalTxnNo;
			parameters[2].Value = model.TxnDate;
			parameters[3].Value = model.StoreCode;
			parameters[4].Value = model.ServerCode;
			parameters[5].Value = model.RegisterCode;
			parameters[6].Value = model.ReasonID;
			parameters[7].Value = model.Note;
			parameters[8].Value = model.ActAmount;
			parameters[9].Value = model.ActPoints;
			parameters[10].Value = model.ActExpireDate;
			parameters[11].Value = model.CardCount;
			parameters[12].Value = model.ApproveStatus;
			parameters[13].Value = model.ApproveOn;
			parameters[14].Value = model.ApproveBy;
			parameters[15].Value = model.CreatedOn;
			parameters[16].Value = model.CreatedBy;
			parameters[17].Value = model.UpdatedOn;
			parameters[18].Value = model.UpdatedBy;
			parameters[19].Value = model.CreatedBusDate;
			parameters[20].Value = model.ApproveBusDate;
			parameters[21].Value = model.ApprovalCode;
			parameters[22].Value = model.BrandCode;
			parameters[23].Value = model.CardAdjustNumber;

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
		public bool Delete(string CardAdjustNumber)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_CardAdjust_H ");
			strSql.Append(" where CardAdjustNumber=@CardAdjustNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@CardAdjustNumber", SqlDbType.VarChar,512)};
			parameters[0].Value = CardAdjustNumber;

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
		public bool DeleteList(string CardAdjustNumberlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_CardAdjust_H ");
			strSql.Append(" where CardAdjustNumber in ("+CardAdjustNumberlist + ")  ");
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
		public Edge.SVA.Model.Ord_CardAdjust_H GetModel(string CardAdjustNumber)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CardAdjustNumber,OprID,OriginalTxnNo,TxnDate,StoreCode,ServerCode,RegisterCode,ReasonID,Note,ActAmount,ActPoints,ActExpireDate,CardCount,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CreatedBusDate,ApproveBusDate,ApprovalCode,BrandCode from Ord_CardAdjust_H ");
			strSql.Append(" where CardAdjustNumber=@CardAdjustNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@CardAdjustNumber", SqlDbType.VarChar,512)};
			parameters[0].Value = CardAdjustNumber;

			Edge.SVA.Model.Ord_CardAdjust_H model=new Edge.SVA.Model.Ord_CardAdjust_H();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CardAdjustNumber"]!=null && ds.Tables[0].Rows[0]["CardAdjustNumber"].ToString()!="")
				{
					model.CardAdjustNumber=ds.Tables[0].Rows[0]["CardAdjustNumber"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OprID"]!=null && ds.Tables[0].Rows[0]["OprID"].ToString()!="")
				{
					model.OprID=int.Parse(ds.Tables[0].Rows[0]["OprID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OriginalTxnNo"]!=null && ds.Tables[0].Rows[0]["OriginalTxnNo"].ToString()!="")
				{
					model.OriginalTxnNo=ds.Tables[0].Rows[0]["OriginalTxnNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TxnDate"]!=null && ds.Tables[0].Rows[0]["TxnDate"].ToString()!="")
				{
					model.TxnDate=DateTime.Parse(ds.Tables[0].Rows[0]["TxnDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StoreCode"]!=null && ds.Tables[0].Rows[0]["StoreCode"].ToString()!="")
				{
					model.StoreCode=ds.Tables[0].Rows[0]["StoreCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ServerCode"]!=null && ds.Tables[0].Rows[0]["ServerCode"].ToString()!="")
				{
					model.ServerCode=ds.Tables[0].Rows[0]["ServerCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RegisterCode"]!=null && ds.Tables[0].Rows[0]["RegisterCode"].ToString()!="")
				{
					model.RegisterCode=ds.Tables[0].Rows[0]["RegisterCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ReasonID"]!=null && ds.Tables[0].Rows[0]["ReasonID"].ToString()!="")
				{
					model.ReasonID=int.Parse(ds.Tables[0].Rows[0]["ReasonID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Note"]!=null && ds.Tables[0].Rows[0]["Note"].ToString()!="")
				{
					model.Note=ds.Tables[0].Rows[0]["Note"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ActAmount"]!=null && ds.Tables[0].Rows[0]["ActAmount"].ToString()!="")
				{
					model.ActAmount=decimal.Parse(ds.Tables[0].Rows[0]["ActAmount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ActPoints"]!=null && ds.Tables[0].Rows[0]["ActPoints"].ToString()!="")
				{
					model.ActPoints=int.Parse(ds.Tables[0].Rows[0]["ActPoints"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ActExpireDate"]!=null && ds.Tables[0].Rows[0]["ActExpireDate"].ToString()!="")
				{
					model.ActExpireDate=DateTime.Parse(ds.Tables[0].Rows[0]["ActExpireDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardCount"]!=null && ds.Tables[0].Rows[0]["CardCount"].ToString()!="")
				{
					model.CardCount=int.Parse(ds.Tables[0].Rows[0]["CardCount"].ToString());
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
				if(ds.Tables[0].Rows[0]["BrandCode"]!=null && ds.Tables[0].Rows[0]["BrandCode"].ToString()!="")
				{
					model.BrandCode=ds.Tables[0].Rows[0]["BrandCode"].ToString();
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
			strSql.Append("select CardAdjustNumber,OprID,OriginalTxnNo,TxnDate,StoreCode,ServerCode,RegisterCode,ReasonID,Note,ActAmount,ActPoints,ActExpireDate,CardCount,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CreatedBusDate,ApproveBusDate,ApprovalCode,BrandCode ");
			strSql.Append(" FROM Ord_CardAdjust_H ");
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
			strSql.Append(" CardAdjustNumber,OprID,OriginalTxnNo,TxnDate,StoreCode,ServerCode,RegisterCode,ReasonID,Note,ActAmount,ActPoints,ActExpireDate,CardCount,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CreatedBusDate,ApproveBusDate,ApprovalCode,BrandCode ");
			strSql.Append(" FROM Ord_CardAdjust_H ");
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
            parameters[0].Value = "Ord_CardAdjust_H";
            parameters[1].Value = "*";
            parameters[2].Value = filedOrder;
            parameters[3].Value = "";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 0;
            parameters[7].Value = 1;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPageOrder", parameters, "ds");
        }

        /// <summary>
        /// 获取行总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select count(*) from Ord_CardAdjust_H ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

