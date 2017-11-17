using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Ord_CouponBatchCreate
	/// </summary>
	public partial class Ord_CouponBatchCreate:IOrd_CouponBatchCreate
	{
		public Ord_CouponBatchCreate()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CouponCreateNumber)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ord_CouponBatchCreate");
			strSql.Append(" where CouponCreateNumber=@CouponCreateNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@CouponCreateNumber", SqlDbType.VarChar,512)};
			parameters[0].Value = CouponCreateNumber;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.Ord_CouponBatchCreate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ord_CouponBatchCreate(");
			strSql.Append("CouponCreateNumber,CouponTypeID,CouponCount,Note,IssuedDate,ExpiryDate,InitAmount,InitPoints,RandomPWD,InitPassword,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CreatedBusDate,ApproveBusDate,ApprovalCode)");
			strSql.Append(" values (");
			strSql.Append("@CouponCreateNumber,@CouponTypeID,@CouponCount,@Note,@IssuedDate,@ExpiryDate,@InitAmount,@InitPoints,@RandomPWD,@InitPassword,@ApproveStatus,@ApproveOn,@ApproveBy,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@CreatedBusDate,@ApproveBusDate,@ApprovalCode)");
			SqlParameter[] parameters = {
					new SqlParameter("@CouponCreateNumber", SqlDbType.VarChar,512),
					new SqlParameter("@CouponTypeID", SqlDbType.Int,4),
					new SqlParameter("@CouponCount", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@IssuedDate", SqlDbType.DateTime),
					new SqlParameter("@ExpiryDate", SqlDbType.DateTime),
					new SqlParameter("@InitAmount", SqlDbType.Money,8),
					new SqlParameter("@InitPoints", SqlDbType.Int,4),
					new SqlParameter("@RandomPWD", SqlDbType.Int,4),
					new SqlParameter("@InitPassword", SqlDbType.VarChar,512),
					new SqlParameter("@ApproveStatus", SqlDbType.Char,1),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApproveBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApprovalCode", SqlDbType.VarChar,512)};
			parameters[0].Value = model.CouponCreateNumber;
			parameters[1].Value = model.CouponTypeID;
			parameters[2].Value = model.CouponCount;
			parameters[3].Value = model.Note;
			parameters[4].Value = model.IssuedDate;
			parameters[5].Value = model.ExpiryDate;
			parameters[6].Value = model.InitAmount;
			parameters[7].Value = model.InitPoints;
			parameters[8].Value = model.RandomPWD;
			parameters[9].Value = model.InitPassword;
			parameters[10].Value = model.ApproveStatus;
			parameters[11].Value = model.ApproveOn;
			parameters[12].Value = model.ApproveBy;
			parameters[13].Value = model.CreatedOn;
			parameters[14].Value = model.CreatedBy;
			parameters[15].Value = model.UpdatedOn;
			parameters[16].Value = model.UpdatedBy;
			parameters[17].Value = model.CreatedBusDate;
			parameters[18].Value = model.ApproveBusDate;
			parameters[19].Value = model.ApprovalCode;

			//object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
            object obj = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
		public bool Update(Edge.SVA.Model.Ord_CouponBatchCreate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ord_CouponBatchCreate set ");
			strSql.Append("CouponTypeID=@CouponTypeID,");
			strSql.Append("CouponCount=@CouponCount,");
			strSql.Append("Note=@Note,");
			strSql.Append("IssuedDate=@IssuedDate,");
			strSql.Append("ExpiryDate=@ExpiryDate,");
			strSql.Append("InitAmount=@InitAmount,");
			strSql.Append("InitPoints=@InitPoints,");
			strSql.Append("RandomPWD=@RandomPWD,");
			strSql.Append("InitPassword=@InitPassword,");
			strSql.Append("ApproveStatus=@ApproveStatus,");
			strSql.Append("ApproveOn=@ApproveOn,");
			strSql.Append("ApproveBy=@ApproveBy,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("CreatedBusDate=@CreatedBusDate,");
			strSql.Append("ApproveBusDate=@ApproveBusDate,");
			strSql.Append("ApprovalCode=@ApprovalCode");
            strSql.Append(" where CouponCreateNumber=@CouponCreateNumber");
			SqlParameter[] parameters = {
					new SqlParameter("@CouponTypeID", SqlDbType.Int,4),
					new SqlParameter("@CouponCount", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@IssuedDate", SqlDbType.DateTime),
					new SqlParameter("@ExpiryDate", SqlDbType.DateTime),
					new SqlParameter("@InitAmount", SqlDbType.Money,8),
					new SqlParameter("@InitPoints", SqlDbType.Int,4),
					new SqlParameter("@RandomPWD", SqlDbType.Int,4),
					new SqlParameter("@InitPassword", SqlDbType.VarChar,512),
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
					new SqlParameter("@CouponCreateNumber", SqlDbType.VarChar,512),
					new SqlParameter("@BatchCouponID", SqlDbType.Int,4)};
			parameters[0].Value = model.CouponTypeID;
			parameters[1].Value = model.CouponCount;
			parameters[2].Value = model.Note;
			parameters[3].Value = model.IssuedDate;
			parameters[4].Value = model.ExpiryDate;
			parameters[5].Value = model.InitAmount;
			parameters[6].Value = model.InitPoints;
			parameters[7].Value = model.RandomPWD;
			parameters[8].Value = model.InitPassword;
			parameters[9].Value = model.ApproveStatus;
			parameters[10].Value = model.ApproveOn;
			parameters[11].Value = model.ApproveBy;
			parameters[12].Value = model.CreatedOn;
			parameters[13].Value = model.CreatedBy;
			parameters[14].Value = model.UpdatedOn;
			parameters[15].Value = model.UpdatedBy;
			parameters[16].Value = model.CreatedBusDate;
			parameters[17].Value = model.ApproveBusDate;
			parameters[18].Value = model.ApprovalCode;
			parameters[19].Value = model.CouponCreateNumber;
			parameters[20].Value = model.BatchCouponID;

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
		public bool Delete(string CouponCreateNumber)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_CouponBatchCreate ");
			strSql.Append(" where CouponCreateNumber=@CouponCreateNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@CouponCreateNumber", SqlDbType.VarChar,512)};
			parameters[0].Value = CouponCreateNumber;

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
		public bool DeleteList(string BatchCouponIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_CouponBatchCreate ");
			strSql.Append(" where BatchCouponID in ("+BatchCouponIDlist + ")  ");
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
        public Edge.SVA.Model.Ord_CouponBatchCreate GetModel(string CouponCreateNumber)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CouponCreateNumber,CouponTypeID,CouponCount,Note,IssuedDate,ExpiryDate,InitAmount,InitPoints,RandomPWD,InitPassword,ApproveStatus,BatchCouponID,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CreatedBusDate,ApproveBusDate,ApprovalCode from Ord_CouponBatchCreate ");
            strSql.Append(" where CouponCreateNumber=@CouponCreateNumber");
			SqlParameter[] parameters = {
					new SqlParameter("@CouponCreateNumber", SqlDbType.VarChar,512)
};
            parameters[0].Value = CouponCreateNumber;

			Edge.SVA.Model.Ord_CouponBatchCreate model=new Edge.SVA.Model.Ord_CouponBatchCreate();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CouponCreateNumber"]!=null && ds.Tables[0].Rows[0]["CouponCreateNumber"].ToString()!="")
				{
					model.CouponCreateNumber=ds.Tables[0].Rows[0]["CouponCreateNumber"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CouponTypeID"]!=null && ds.Tables[0].Rows[0]["CouponTypeID"].ToString()!="")
				{
					model.CouponTypeID=int.Parse(ds.Tables[0].Rows[0]["CouponTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CouponCount"]!=null && ds.Tables[0].Rows[0]["CouponCount"].ToString()!="")
				{
					model.CouponCount=int.Parse(ds.Tables[0].Rows[0]["CouponCount"].ToString());
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
				if(ds.Tables[0].Rows[0]["ApproveStatus"]!=null && ds.Tables[0].Rows[0]["ApproveStatus"].ToString()!="")
				{
					model.ApproveStatus=ds.Tables[0].Rows[0]["ApproveStatus"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BatchCouponID"]!=null && ds.Tables[0].Rows[0]["BatchCouponID"].ToString()!="")
				{
					model.BatchCouponID=int.Parse(ds.Tables[0].Rows[0]["BatchCouponID"].ToString());
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
			strSql.Append("select CouponCreateNumber,CouponTypeID,CouponCount,Note,IssuedDate,ExpiryDate,InitAmount,InitPoints,RandomPWD,InitPassword,ApproveStatus,BatchCouponID,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CreatedBusDate,ApproveBusDate,ApprovalCode ");
			strSql.Append(" FROM Ord_CouponBatchCreate ");
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
			strSql.Append(" CouponCreateNumber,CouponTypeID,CouponCount,Note,IssuedDate,ExpiryDate,InitAmount,InitPoints,RandomPWD,InitPassword,ApproveStatus,BatchCouponID,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CreatedBusDate,ApproveBusDate,ApprovalCode ");
			strSql.Append(" FROM Ord_CouponBatchCreate ");
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
            parameters[0].Value = "Ord_CouponBatchCreate";
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
            sql.Append("select count(*) from Ord_CouponBatchCreate ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }


		#endregion  Method
	}
}

