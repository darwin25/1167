using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:ReceiveTxn
	/// </summary>
	public partial class ReceiveTxn:IReceiveTxn
	{
		public ReceiveTxn()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "ReceiveTxn"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ReceiveTxn");
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
		public int Add(Edge.SVA.Model.ReceiveTxn model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ReceiveTxn(");
			strSql.Append("StoreCode,ServerCode,RegisterCode,TxnNoSN,TxnNo,BusDate,TxnDate,CardNumber,OprID,Amount,Points,Status,VoidKeyID,VoidTxnNo,TenderID,Additional,ApproveStatus,Remark,SecurityCode,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy,Approvedby,ApprovedDate)");
			strSql.Append(" values (");
			strSql.Append("@StoreCode,@ServerCode,@RegisterCode,@TxnNoSN,@TxnNo,@BusDate,@TxnDate,@CardNumber,@OprID,@Amount,@Points,@Status,@VoidKeyID,@VoidTxnNo,@TenderID,@Additional,@ApproveStatus,@Remark,@SecurityCode,@CreatedDate,@UpdatedDate,@CreatedBy,@UpdatedBy,@Approvedby,@ApprovedDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreCode", SqlDbType.VarChar,512),
					new SqlParameter("@ServerCode", SqlDbType.VarChar,512),
					new SqlParameter("@RegisterCode", SqlDbType.VarChar,512),
					new SqlParameter("@TxnNoSN", SqlDbType.VarChar,512),
					new SqlParameter("@TxnNo", SqlDbType.VarChar,512),
					new SqlParameter("@BusDate", SqlDbType.DateTime),
					new SqlParameter("@TxnDate", SqlDbType.DateTime),
					new SqlParameter("@CardNumber", SqlDbType.VarChar,512),
					new SqlParameter("@OprID", SqlDbType.Int,4),
					new SqlParameter("@Amount", SqlDbType.Money,8),
					new SqlParameter("@Points", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@VoidKeyID", SqlDbType.Int,4),
					new SqlParameter("@VoidTxnNo", SqlDbType.VarChar,512),
					new SqlParameter("@TenderID", SqlDbType.Int,4),
					new SqlParameter("@Additional", SqlDbType.VarChar,512),
					new SqlParameter("@ApproveStatus", SqlDbType.Char,1),
					new SqlParameter("@Remark", SqlDbType.VarChar,512),
					new SqlParameter("@SecurityCode", SqlDbType.VarChar,512),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.VarChar,512),
					new SqlParameter("@UpdatedBy", SqlDbType.VarChar,512),
					new SqlParameter("@Approvedby", SqlDbType.VarChar,512),
					new SqlParameter("@ApprovedDate", SqlDbType.DateTime)};
			parameters[0].Value = model.StoreCode;
			parameters[1].Value = model.ServerCode;
			parameters[2].Value = model.RegisterCode;
			parameters[3].Value = model.TxnNoSN;
			parameters[4].Value = model.TxnNo;
			parameters[5].Value = model.BusDate;
			parameters[6].Value = model.TxnDate;
			parameters[7].Value = model.CardNumber;
			parameters[8].Value = model.OprID;
			parameters[9].Value = model.Amount;
			parameters[10].Value = model.Points;
			parameters[11].Value = model.Status;
			parameters[12].Value = model.VoidKeyID;
			parameters[13].Value = model.VoidTxnNo;
			parameters[14].Value = model.TenderID;
			parameters[15].Value = model.Additional;
			parameters[16].Value = model.ApproveStatus;
			parameters[17].Value = model.Remark;
			parameters[18].Value = model.SecurityCode;
			parameters[19].Value = model.CreatedDate;
			parameters[20].Value = model.UpdatedDate;
			parameters[21].Value = model.CreatedBy;
			parameters[22].Value = model.UpdatedBy;
			parameters[23].Value = model.Approvedby;
			parameters[24].Value = model.ApprovedDate;

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
		public bool Update(Edge.SVA.Model.ReceiveTxn model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ReceiveTxn set ");
			strSql.Append("StoreCode=@StoreCode,");
			strSql.Append("ServerCode=@ServerCode,");
			strSql.Append("RegisterCode=@RegisterCode,");
			strSql.Append("TxnNoSN=@TxnNoSN,");
			strSql.Append("TxnNo=@TxnNo,");
			strSql.Append("BusDate=@BusDate,");
			strSql.Append("TxnDate=@TxnDate,");
			strSql.Append("CardNumber=@CardNumber,");
			strSql.Append("OprID=@OprID,");
			strSql.Append("Amount=@Amount,");
			strSql.Append("Points=@Points,");
			strSql.Append("Status=@Status,");
			strSql.Append("VoidKeyID=@VoidKeyID,");
			strSql.Append("VoidTxnNo=@VoidTxnNo,");
			strSql.Append("TenderID=@TenderID,");
			strSql.Append("Additional=@Additional,");
			strSql.Append("ApproveStatus=@ApproveStatus,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("SecurityCode=@SecurityCode,");
			strSql.Append("CreatedDate=@CreatedDate,");
			strSql.Append("UpdatedDate=@UpdatedDate,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("Approvedby=@Approvedby,");
			strSql.Append("ApprovedDate=@ApprovedDate");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreCode", SqlDbType.VarChar,512),
					new SqlParameter("@ServerCode", SqlDbType.VarChar,512),
					new SqlParameter("@RegisterCode", SqlDbType.VarChar,512),
					new SqlParameter("@TxnNoSN", SqlDbType.VarChar,512),
					new SqlParameter("@TxnNo", SqlDbType.VarChar,512),
					new SqlParameter("@BusDate", SqlDbType.DateTime),
					new SqlParameter("@TxnDate", SqlDbType.DateTime),
					new SqlParameter("@CardNumber", SqlDbType.VarChar,512),
					new SqlParameter("@OprID", SqlDbType.Int,4),
					new SqlParameter("@Amount", SqlDbType.Money,8),
					new SqlParameter("@Points", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@VoidKeyID", SqlDbType.Int,4),
					new SqlParameter("@VoidTxnNo", SqlDbType.VarChar,512),
					new SqlParameter("@TenderID", SqlDbType.Int,4),
					new SqlParameter("@Additional", SqlDbType.VarChar,512),
					new SqlParameter("@ApproveStatus", SqlDbType.Char,1),
					new SqlParameter("@Remark", SqlDbType.VarChar,512),
					new SqlParameter("@SecurityCode", SqlDbType.VarChar,512),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.VarChar,512),
					new SqlParameter("@UpdatedBy", SqlDbType.VarChar,512),
					new SqlParameter("@Approvedby", SqlDbType.VarChar,512),
					new SqlParameter("@ApprovedDate", SqlDbType.DateTime),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.StoreCode;
			parameters[1].Value = model.ServerCode;
			parameters[2].Value = model.RegisterCode;
			parameters[3].Value = model.TxnNoSN;
			parameters[4].Value = model.TxnNo;
			parameters[5].Value = model.BusDate;
			parameters[6].Value = model.TxnDate;
			parameters[7].Value = model.CardNumber;
			parameters[8].Value = model.OprID;
			parameters[9].Value = model.Amount;
			parameters[10].Value = model.Points;
			parameters[11].Value = model.Status;
			parameters[12].Value = model.VoidKeyID;
			parameters[13].Value = model.VoidTxnNo;
			parameters[14].Value = model.TenderID;
			parameters[15].Value = model.Additional;
			parameters[16].Value = model.ApproveStatus;
			parameters[17].Value = model.Remark;
			parameters[18].Value = model.SecurityCode;
			parameters[19].Value = model.CreatedDate;
			parameters[20].Value = model.UpdatedDate;
			parameters[21].Value = model.CreatedBy;
			parameters[22].Value = model.UpdatedBy;
			parameters[23].Value = model.Approvedby;
			parameters[24].Value = model.ApprovedDate;
			parameters[25].Value = model.KeyID;

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
			strSql.Append("delete from ReceiveTxn ");
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
			strSql.Append("delete from ReceiveTxn ");
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
		public Edge.SVA.Model.ReceiveTxn GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,StoreCode,ServerCode,RegisterCode,TxnNoSN,TxnNo,BusDate,TxnDate,CardNumber,OprID,Amount,Points,Status,VoidKeyID,VoidTxnNo,TenderID,Additional,ApproveStatus,Remark,SecurityCode,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy,Approvedby,ApprovedDate from ReceiveTxn ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.ReceiveTxn model=new Edge.SVA.Model.ReceiveTxn();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
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
				if(ds.Tables[0].Rows[0]["TxnNoSN"]!=null && ds.Tables[0].Rows[0]["TxnNoSN"].ToString()!="")
				{
					model.TxnNoSN=ds.Tables[0].Rows[0]["TxnNoSN"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TxnNo"]!=null && ds.Tables[0].Rows[0]["TxnNo"].ToString()!="")
				{
					model.TxnNo=ds.Tables[0].Rows[0]["TxnNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BusDate"]!=null && ds.Tables[0].Rows[0]["BusDate"].ToString()!="")
				{
					model.BusDate=DateTime.Parse(ds.Tables[0].Rows[0]["BusDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TxnDate"]!=null && ds.Tables[0].Rows[0]["TxnDate"].ToString()!="")
				{
					model.TxnDate=DateTime.Parse(ds.Tables[0].Rows[0]["TxnDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardNumber"]!=null && ds.Tables[0].Rows[0]["CardNumber"].ToString()!="")
				{
					model.CardNumber=ds.Tables[0].Rows[0]["CardNumber"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OprID"]!=null && ds.Tables[0].Rows[0]["OprID"].ToString()!="")
				{
					model.OprID=int.Parse(ds.Tables[0].Rows[0]["OprID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Amount"]!=null && ds.Tables[0].Rows[0]["Amount"].ToString()!="")
				{
					model.Amount=decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Points"]!=null && ds.Tables[0].Rows[0]["Points"].ToString()!="")
				{
					model.Points=int.Parse(ds.Tables[0].Rows[0]["Points"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["VoidKeyID"]!=null && ds.Tables[0].Rows[0]["VoidKeyID"].ToString()!="")
				{
					model.VoidKeyID=int.Parse(ds.Tables[0].Rows[0]["VoidKeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["VoidTxnNo"]!=null && ds.Tables[0].Rows[0]["VoidTxnNo"].ToString()!="")
				{
					model.VoidTxnNo=ds.Tables[0].Rows[0]["VoidTxnNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TenderID"]!=null && ds.Tables[0].Rows[0]["TenderID"].ToString()!="")
				{
					model.TenderID=int.Parse(ds.Tables[0].Rows[0]["TenderID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Additional"]!=null && ds.Tables[0].Rows[0]["Additional"].ToString()!="")
				{
					model.Additional=ds.Tables[0].Rows[0]["Additional"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ApproveStatus"]!=null && ds.Tables[0].Rows[0]["ApproveStatus"].ToString()!="")
				{
					model.ApproveStatus=ds.Tables[0].Rows[0]["ApproveStatus"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Remark"]!=null && ds.Tables[0].Rows[0]["Remark"].ToString()!="")
				{
					model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SecurityCode"]!=null && ds.Tables[0].Rows[0]["SecurityCode"].ToString()!="")
				{
					model.SecurityCode=ds.Tables[0].Rows[0]["SecurityCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CreatedDate"]!=null && ds.Tables[0].Rows[0]["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedDate"]!=null && ds.Tables[0].Rows[0]["UpdatedDate"].ToString()!="")
				{
					model.UpdatedDate=DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedBy"]!=null && ds.Tables[0].Rows[0]["CreatedBy"].ToString()!="")
				{
					model.CreatedBy=ds.Tables[0].Rows[0]["CreatedBy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["UpdatedBy"]!=null && ds.Tables[0].Rows[0]["UpdatedBy"].ToString()!="")
				{
					model.UpdatedBy=ds.Tables[0].Rows[0]["UpdatedBy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Approvedby"]!=null && ds.Tables[0].Rows[0]["Approvedby"].ToString()!="")
				{
					model.Approvedby=ds.Tables[0].Rows[0]["Approvedby"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ApprovedDate"]!=null && ds.Tables[0].Rows[0]["ApprovedDate"].ToString()!="")
				{
					model.ApprovedDate=DateTime.Parse(ds.Tables[0].Rows[0]["ApprovedDate"].ToString());
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
			strSql.Append("select KeyID,StoreCode,ServerCode,RegisterCode,TxnNoSN,TxnNo,BusDate,TxnDate,CardNumber,OprID,Amount,Points,Status,VoidKeyID,VoidTxnNo,TenderID,Additional,ApproveStatus,Remark,SecurityCode,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy,Approvedby,ApprovedDate ");
			strSql.Append(" FROM ReceiveTxn ");
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
			strSql.Append(" KeyID,StoreCode,ServerCode,RegisterCode,TxnNoSN,TxnNo,BusDate,TxnDate,CardNumber,OprID,Amount,Points,Status,VoidKeyID,VoidTxnNo,TenderID,Additional,ApproveStatus,Remark,SecurityCode,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy,Approvedby,ApprovedDate ");
			strSql.Append(" FROM ReceiveTxn ");
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
            parameters[0].Value = "ReceiveTxn";
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
            sql.Append("select count(*) from ReceiveTxn ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

