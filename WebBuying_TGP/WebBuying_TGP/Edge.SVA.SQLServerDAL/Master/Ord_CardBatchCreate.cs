using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Ord_CardBatchCreate
	/// </summary>
	public partial class Ord_CardBatchCreate:IOrd_CardBatchCreate
	{
		public Ord_CardBatchCreate()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CardCreateNumber)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ord_CardBatchCreate");
			strSql.Append(" where CardCreateNumber=@CardCreateNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@CardCreateNumber", SqlDbType.VarChar,512)};
			parameters[0].Value = CardCreateNumber;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Ord_CardBatchCreate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ord_CardBatchCreate(");
			strSql.Append("CardCreateNumber,CardGradeID,CardCount,Note,IssuedDate,ExpiryDate,InitAmount,InitPoints,RandomPWD,InitPassword,BatchCardID,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CreatedBusDate,ApproveBusDate)");
			strSql.Append(" values (");
			strSql.Append("@CardCreateNumber,@CardGradeID,@CardCount,@Note,@IssuedDate,@ExpiryDate,@InitAmount,@InitPoints,@RandomPWD,@InitPassword,@BatchCardID,@ApprovalCode,@ApproveStatus,@ApproveOn,@ApproveBy,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@CreatedBusDate,@ApproveBusDate)");
			SqlParameter[] parameters = {
					new SqlParameter("@CardCreateNumber", SqlDbType.VarChar,512),
					new SqlParameter("@CardGradeID", SqlDbType.Int,4),
					new SqlParameter("@CardCount", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@IssuedDate", SqlDbType.DateTime),
					new SqlParameter("@ExpiryDate", SqlDbType.DateTime),
					new SqlParameter("@InitAmount", SqlDbType.Money,8),
					new SqlParameter("@InitPoints", SqlDbType.Int,4),
					new SqlParameter("@RandomPWD", SqlDbType.Int,4),
					new SqlParameter("@InitPassword", SqlDbType.VarChar,512),
					new SqlParameter("@BatchCardID", SqlDbType.Int,4),
					new SqlParameter("@ApprovalCode", SqlDbType.VarChar,512),
					new SqlParameter("@ApproveStatus", SqlDbType.Char,1),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApproveBusDate", SqlDbType.DateTime)};
			parameters[0].Value = model.CardCreateNumber;
			parameters[1].Value = model.CardGradeID;
			parameters[2].Value = model.CardCount;
			parameters[3].Value = model.Note;
			parameters[4].Value = model.IssuedDate;
			parameters[5].Value = model.ExpiryDate;
			parameters[6].Value = model.InitAmount;
			parameters[7].Value = model.InitPoints;
			parameters[8].Value = model.RandomPWD;
			parameters[9].Value = model.InitPassword;
			parameters[10].Value = model.BatchCardID;
			parameters[11].Value = model.ApprovalCode;
			parameters[12].Value = model.ApproveStatus;
			parameters[13].Value = model.ApproveOn;
			parameters[14].Value = model.ApproveBy;
			parameters[15].Value = model.CreatedOn;
			parameters[16].Value = model.CreatedBy;
			parameters[17].Value = model.UpdatedOn;
			parameters[18].Value = model.UpdatedBy;
			parameters[19].Value = model.CreatedBusDate;
			parameters[20].Value = model.ApproveBusDate;

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
		public bool Update(Edge.SVA.Model.Ord_CardBatchCreate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ord_CardBatchCreate set ");
			strSql.Append("CardGradeID=@CardGradeID,");
			strSql.Append("CardCount=@CardCount,");
			strSql.Append("Note=@Note,");
			strSql.Append("IssuedDate=@IssuedDate,");
			strSql.Append("ExpiryDate=@ExpiryDate,");
			strSql.Append("InitAmount=@InitAmount,");
			strSql.Append("InitPoints=@InitPoints,");
			strSql.Append("RandomPWD=@RandomPWD,");
			strSql.Append("InitPassword=@InitPassword,");
			strSql.Append("BatchCardID=@BatchCardID,");
			strSql.Append("ApprovalCode=@ApprovalCode,");
			strSql.Append("ApproveStatus=@ApproveStatus,");
			strSql.Append("ApproveOn=@ApproveOn,");
			strSql.Append("ApproveBy=@ApproveBy,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("CreatedBusDate=@CreatedBusDate,");
			strSql.Append("ApproveBusDate=@ApproveBusDate");
			strSql.Append(" where CardCreateNumber=@CardCreateNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@CardGradeID", SqlDbType.Int,4),
					new SqlParameter("@CardCount", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@IssuedDate", SqlDbType.DateTime),
					new SqlParameter("@ExpiryDate", SqlDbType.DateTime),
					new SqlParameter("@InitAmount", SqlDbType.Money,8),
					new SqlParameter("@InitPoints", SqlDbType.Int,4),
					new SqlParameter("@RandomPWD", SqlDbType.Int,4),
					new SqlParameter("@InitPassword", SqlDbType.VarChar,512),
					new SqlParameter("@BatchCardID", SqlDbType.Int,4),
					new SqlParameter("@ApprovalCode", SqlDbType.VarChar,512),
					new SqlParameter("@ApproveStatus", SqlDbType.Char,1),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApproveBusDate", SqlDbType.DateTime),
					new SqlParameter("@CardCreateNumber", SqlDbType.VarChar,512)};
			parameters[0].Value = model.CardGradeID;
			parameters[1].Value = model.CardCount;
			parameters[2].Value = model.Note;
			parameters[3].Value = model.IssuedDate;
			parameters[4].Value = model.ExpiryDate;
			parameters[5].Value = model.InitAmount;
			parameters[6].Value = model.InitPoints;
			parameters[7].Value = model.RandomPWD;
			parameters[8].Value = model.InitPassword;
			parameters[9].Value = model.BatchCardID;
			parameters[10].Value = model.ApprovalCode;
			parameters[11].Value = model.ApproveStatus;
			parameters[12].Value = model.ApproveOn;
			parameters[13].Value = model.ApproveBy;
			parameters[14].Value = model.CreatedOn;
			parameters[15].Value = model.CreatedBy;
			parameters[16].Value = model.UpdatedOn;
			parameters[17].Value = model.UpdatedBy;
			parameters[18].Value = model.CreatedBusDate;
			parameters[19].Value = model.ApproveBusDate;
			parameters[20].Value = model.CardCreateNumber;

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
		public bool Delete(string CardCreateNumber)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_CardBatchCreate ");
			strSql.Append(" where CardCreateNumber=@CardCreateNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@CardCreateNumber", SqlDbType.VarChar,512)};
			parameters[0].Value = CardCreateNumber;

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
		public bool DeleteList(string CardCreateNumberlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_CardBatchCreate ");
			strSql.Append(" where CardCreateNumber in ("+CardCreateNumberlist + ")  ");
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
		public Edge.SVA.Model.Ord_CardBatchCreate GetModel(string CardCreateNumber)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CardCreateNumber,CardGradeID,CardCount,Note,IssuedDate,ExpiryDate,InitAmount,InitPoints,RandomPWD,InitPassword,BatchCardID,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CreatedBusDate,ApproveBusDate from Ord_CardBatchCreate ");
			strSql.Append(" where CardCreateNumber=@CardCreateNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@CardCreateNumber", SqlDbType.VarChar,512)};
			parameters[0].Value = CardCreateNumber;

			Edge.SVA.Model.Ord_CardBatchCreate model=new Edge.SVA.Model.Ord_CardBatchCreate();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CardCreateNumber"]!=null && ds.Tables[0].Rows[0]["CardCreateNumber"].ToString()!="")
				{
					model.CardCreateNumber=ds.Tables[0].Rows[0]["CardCreateNumber"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CardGradeID"]!=null && ds.Tables[0].Rows[0]["CardGradeID"].ToString()!="")
				{
					model.CardGradeID=int.Parse(ds.Tables[0].Rows[0]["CardGradeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardCount"]!=null && ds.Tables[0].Rows[0]["CardCount"].ToString()!="")
				{
					model.CardCount=int.Parse(ds.Tables[0].Rows[0]["CardCount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Note"]!=null && ds.Tables[0].Rows[0]["Note"].ToString()!="")
				{
					model.Note=ds.Tables[0].Rows[0]["Note"].ToString();
				}
				if(ds.Tables[0].Rows[0]["IssuedDate"]!=null && ds.Tables[0].Rows[0]["IssuedDate"].ToString()!="")
				{
					model.IssuedDate=DateTime.Parse(ds.Tables[0].Rows[0]["IssuedDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ExpiryDate"]!=null && ds.Tables[0].Rows[0]["ExpiryDate"].ToString()!="")
				{
					model.ExpiryDate=DateTime.Parse(ds.Tables[0].Rows[0]["ExpiryDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["InitAmount"]!=null && ds.Tables[0].Rows[0]["InitAmount"].ToString()!="")
				{
					model.InitAmount=decimal.Parse(ds.Tables[0].Rows[0]["InitAmount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["InitPoints"]!=null && ds.Tables[0].Rows[0]["InitPoints"].ToString()!="")
				{
					model.InitPoints=int.Parse(ds.Tables[0].Rows[0]["InitPoints"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RandomPWD"]!=null && ds.Tables[0].Rows[0]["RandomPWD"].ToString()!="")
				{
					model.RandomPWD=int.Parse(ds.Tables[0].Rows[0]["RandomPWD"].ToString());
				}
				if(ds.Tables[0].Rows[0]["InitPassword"]!=null && ds.Tables[0].Rows[0]["InitPassword"].ToString()!="")
				{
					model.InitPassword=ds.Tables[0].Rows[0]["InitPassword"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BatchCardID"]!=null && ds.Tables[0].Rows[0]["BatchCardID"].ToString()!="")
				{
					model.BatchCardID=int.Parse(ds.Tables[0].Rows[0]["BatchCardID"].ToString());
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
				if(ds.Tables[0].Rows[0]["CreatedBusDate"]!=null && ds.Tables[0].Rows[0]["CreatedBusDate"].ToString()!="")
				{
					model.CreatedBusDate=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedBusDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApproveBusDate"]!=null && ds.Tables[0].Rows[0]["ApproveBusDate"].ToString()!="")
				{
					model.ApproveBusDate=DateTime.Parse(ds.Tables[0].Rows[0]["ApproveBusDate"].ToString());
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
			strSql.Append("select CardCreateNumber,CardGradeID,CardCount,Note,IssuedDate,ExpiryDate,InitAmount,InitPoints,RandomPWD,InitPassword,BatchCardID,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CreatedBusDate,ApproveBusDate ");
			strSql.Append(" FROM Ord_CardBatchCreate ");
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
			strSql.Append(" CardCreateNumber,CardGradeID,CardCount,Note,IssuedDate,ExpiryDate,InitAmount,InitPoints,RandomPWD,InitPassword,BatchCardID,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CreatedBusDate,ApproveBusDate ");
			strSql.Append(" FROM Ord_CardBatchCreate ");
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
            int OrderType = 1;
            string OrderField = filedOrder;
            if (filedOrder.ToLower().EndsWith(" desc"))
            {
                OrderField = filedOrder.Substring(0, filedOrder.ToLower().IndexOf(" desc"));
            }
            else if (filedOrder.ToLower().EndsWith(" asc"))
            {
                OrderType = 0;
                OrderField = filedOrder.Substring(0, filedOrder.ToLower().IndexOf(" asc"));
            }
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
            parameters[0].Value = "Ord_CardBatchCreate";
            parameters[1].Value = "*";
            parameters[2].Value = OrderField;
            parameters[3].Value = "";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 0;
            parameters[7].Value = OrderType;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPageOrder", parameters, "ds");
        }

        /// <summary>
        /// 获取行总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select count(*) from Ord_CardBatchCreate ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

