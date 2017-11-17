using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:MemberSNSAccount
	/// </summary>
	public partial class MemberSNSAccount:IMemberSNSAccount
	{
		public MemberSNSAccount()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SNSAccountID", "MemberSNSAccount"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SNSAccountID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MemberSNSAccount");
			strSql.Append(" where SNSAccountID=@SNSAccountID");
			SqlParameter[] parameters = {
					new SqlParameter("@SNSAccountID", SqlDbType.Int,4)
};
			parameters[0].Value = SNSAccountID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.MemberSNSAccount model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MemberSNSAccount(");
			strSql.Append("MemberID,SNSTypeID,AccountNumber,Status,Note,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@MemberID,@SNSTypeID,@AccountNumber,@Status,@Note,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.Int,4),
					new SqlParameter("@SNSTypeID", SqlDbType.Int,4),
					new SqlParameter("@AccountNumber", SqlDbType.NVarChar,512),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.MemberID;
			parameters[1].Value = model.SNSTypeID;
			parameters[2].Value = model.AccountNumber;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.Note;
			parameters[5].Value = model.CreatedOn;
			parameters[6].Value = model.CreatedBy;
			parameters[7].Value = model.UpdatedOn;
			parameters[8].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.MemberSNSAccount model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MemberSNSAccount set ");
			strSql.Append("MemberID=@MemberID,");
			strSql.Append("SNSTypeID=@SNSTypeID,");
			strSql.Append("AccountNumber=@AccountNumber,");
			strSql.Append("Status=@Status,");
			strSql.Append("Note=@Note,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where SNSAccountID=@SNSAccountID");
			SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.Int,4),
					new SqlParameter("@SNSTypeID", SqlDbType.Int,4),
					new SqlParameter("@AccountNumber", SqlDbType.NVarChar,512),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@SNSAccountID", SqlDbType.Int,4)};
			parameters[0].Value = model.MemberID;
			parameters[1].Value = model.SNSTypeID;
			parameters[2].Value = model.AccountNumber;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.Note;
			parameters[5].Value = model.CreatedOn;
			parameters[6].Value = model.CreatedBy;
			parameters[7].Value = model.UpdatedOn;
			parameters[8].Value = model.UpdatedBy;
			parameters[9].Value = model.SNSAccountID;

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
		public bool Delete(int SNSAccountID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MemberSNSAccount ");
			strSql.Append(" where SNSAccountID=@SNSAccountID");
			SqlParameter[] parameters = {
					new SqlParameter("@SNSAccountID", SqlDbType.Int,4)
};
			parameters[0].Value = SNSAccountID;

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
		public bool DeleteList(string SNSAccountIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MemberSNSAccount ");
			strSql.Append(" where SNSAccountID in ("+SNSAccountIDlist + ")  ");
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
		public Edge.SVA.Model.MemberSNSAccount GetModel(int SNSAccountID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SNSAccountID,MemberID,SNSTypeID,AccountNumber,Status,Note,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from MemberSNSAccount ");
			strSql.Append(" where SNSAccountID=@SNSAccountID");
			SqlParameter[] parameters = {
					new SqlParameter("@SNSAccountID", SqlDbType.Int,4)
};
			parameters[0].Value = SNSAccountID;

			Edge.SVA.Model.MemberSNSAccount model=new Edge.SVA.Model.MemberSNSAccount();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["SNSAccountID"]!=null && ds.Tables[0].Rows[0]["SNSAccountID"].ToString()!="")
				{
					model.SNSAccountID=int.Parse(ds.Tables[0].Rows[0]["SNSAccountID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberID"]!=null && ds.Tables[0].Rows[0]["MemberID"].ToString()!="")
				{
					model.MemberID=int.Parse(ds.Tables[0].Rows[0]["MemberID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SNSTypeID"]!=null && ds.Tables[0].Rows[0]["SNSTypeID"].ToString()!="")
				{
					model.SNSTypeID=int.Parse(ds.Tables[0].Rows[0]["SNSTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AccountNumber"]!=null && ds.Tables[0].Rows[0]["AccountNumber"].ToString()!="")
				{
					model.AccountNumber=ds.Tables[0].Rows[0]["AccountNumber"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Note"]!=null && ds.Tables[0].Rows[0]["Note"].ToString()!="")
				{
					model.Note=ds.Tables[0].Rows[0]["Note"].ToString();
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
			strSql.Append("select SNSAccountID,MemberID,SNSTypeID,AccountNumber,Status,Note,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM MemberSNSAccount ");
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
			strSql.Append(" SNSAccountID,MemberID,SNSTypeID,AccountNumber,Status,Note,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM MemberSNSAccount ");
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
            parameters[0].Value = "MemberSNSAccount";
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
            sql.Append("select count(*) from MemberSNSAccount ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

