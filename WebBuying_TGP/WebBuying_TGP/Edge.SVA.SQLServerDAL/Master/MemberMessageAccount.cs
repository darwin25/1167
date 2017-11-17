using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:MemberMessageAccount
	/// </summary>
	public partial class MemberMessageAccount:IMemberMessageAccount
	{
		public MemberMessageAccount()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MessageAccountID", "MemberMessageAccount"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MessageAccountID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MemberMessageAccount");
			strSql.Append(" where MessageAccountID=@MessageAccountID");
			SqlParameter[] parameters = {
					new SqlParameter("@MessageAccountID", SqlDbType.Int,4)
			};
			parameters[0].Value = MessageAccountID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.MemberMessageAccount model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MemberMessageAccount(");
			strSql.Append("MemberID,MessageServiceTypeID,AccountNumber,Status,Note,IsPrefer,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,TokenUID,TokenStr,TokenUpdateDate)");
			strSql.Append(" values (");
			strSql.Append("@MemberID,@MessageServiceTypeID,@AccountNumber,@Status,@Note,@IsPrefer,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@TokenUID,@TokenStr,@TokenUpdateDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.Int,4),
					new SqlParameter("@MessageServiceTypeID", SqlDbType.Int,4),
					new SqlParameter("@AccountNumber", SqlDbType.NVarChar,512),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@IsPrefer", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@TokenUID", SqlDbType.VarChar,64),
					new SqlParameter("@TokenStr", SqlDbType.VarChar,512),
					new SqlParameter("@TokenUpdateDate", SqlDbType.DateTime)};
			parameters[0].Value = model.MemberID;
			parameters[1].Value = model.MessageServiceTypeID;
			parameters[2].Value = model.AccountNumber;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.Note;
			parameters[5].Value = model.IsPrefer;
			parameters[6].Value = model.CreatedOn;
			parameters[7].Value = model.CreatedBy;
			parameters[8].Value = model.UpdatedOn;
			parameters[9].Value = model.UpdatedBy;
			parameters[10].Value = model.TokenUID;
			parameters[11].Value = model.TokenStr;
			parameters[12].Value = model.TokenUpdateDate;

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
		public bool Update(Edge.SVA.Model.MemberMessageAccount model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MemberMessageAccount set ");
			strSql.Append("MemberID=@MemberID,");
			strSql.Append("MessageServiceTypeID=@MessageServiceTypeID,");
			strSql.Append("AccountNumber=@AccountNumber,");
			strSql.Append("Status=@Status,");
			strSql.Append("Note=@Note,");
			strSql.Append("IsPrefer=@IsPrefer,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("TokenUID=@TokenUID,");
			strSql.Append("TokenStr=@TokenStr,");
			strSql.Append("TokenUpdateDate=@TokenUpdateDate");
			strSql.Append(" where MessageAccountID=@MessageAccountID");
			SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.Int,4),
					new SqlParameter("@MessageServiceTypeID", SqlDbType.Int,4),
					new SqlParameter("@AccountNumber", SqlDbType.NVarChar,512),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@IsPrefer", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@TokenUID", SqlDbType.VarChar,64),
					new SqlParameter("@TokenStr", SqlDbType.VarChar,512),
					new SqlParameter("@TokenUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@MessageAccountID", SqlDbType.Int,4)};
			parameters[0].Value = model.MemberID;
			parameters[1].Value = model.MessageServiceTypeID;
			parameters[2].Value = model.AccountNumber;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.Note;
			parameters[5].Value = model.IsPrefer;
			parameters[6].Value = model.CreatedOn;
			parameters[7].Value = model.CreatedBy;
			parameters[8].Value = model.UpdatedOn;
			parameters[9].Value = model.UpdatedBy;
			parameters[10].Value = model.TokenUID;
			parameters[11].Value = model.TokenStr;
			parameters[12].Value = model.TokenUpdateDate;
			parameters[13].Value = model.MessageAccountID;

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
		public bool Delete(int MessageAccountID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MemberMessageAccount ");
			strSql.Append(" where MessageAccountID=@MessageAccountID");
			SqlParameter[] parameters = {
					new SqlParameter("@MessageAccountID", SqlDbType.Int,4)
			};
			parameters[0].Value = MessageAccountID;

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
		public bool DeleteList(string MessageAccountIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MemberMessageAccount ");
			strSql.Append(" where MessageAccountID in ("+MessageAccountIDlist + ")  ");
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
		public Edge.SVA.Model.MemberMessageAccount GetModel(int MessageAccountID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MessageAccountID,MemberID,MessageServiceTypeID,AccountNumber,Status,Note,IsPrefer,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,TokenUID,TokenStr,TokenUpdateDate from MemberMessageAccount ");
			strSql.Append(" where MessageAccountID=@MessageAccountID");
			SqlParameter[] parameters = {
					new SqlParameter("@MessageAccountID", SqlDbType.Int,4)
			};
			parameters[0].Value = MessageAccountID;

			Edge.SVA.Model.MemberMessageAccount model=new Edge.SVA.Model.MemberMessageAccount();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["MessageAccountID"]!=null && ds.Tables[0].Rows[0]["MessageAccountID"].ToString()!="")
				{
					model.MessageAccountID=int.Parse(ds.Tables[0].Rows[0]["MessageAccountID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberID"]!=null && ds.Tables[0].Rows[0]["MemberID"].ToString()!="")
				{
					model.MemberID=int.Parse(ds.Tables[0].Rows[0]["MemberID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MessageServiceTypeID"]!=null && ds.Tables[0].Rows[0]["MessageServiceTypeID"].ToString()!="")
				{
					model.MessageServiceTypeID=int.Parse(ds.Tables[0].Rows[0]["MessageServiceTypeID"].ToString());
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
				if(ds.Tables[0].Rows[0]["IsPrefer"]!=null && ds.Tables[0].Rows[0]["IsPrefer"].ToString()!="")
				{
					model.IsPrefer=int.Parse(ds.Tables[0].Rows[0]["IsPrefer"].ToString());
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
				if(ds.Tables[0].Rows[0]["TokenUID"]!=null && ds.Tables[0].Rows[0]["TokenUID"].ToString()!="")
				{
					model.TokenUID=ds.Tables[0].Rows[0]["TokenUID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TokenStr"]!=null && ds.Tables[0].Rows[0]["TokenStr"].ToString()!="")
				{
					model.TokenStr=ds.Tables[0].Rows[0]["TokenStr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TokenUpdateDate"]!=null && ds.Tables[0].Rows[0]["TokenUpdateDate"].ToString()!="")
				{
					model.TokenUpdateDate=DateTime.Parse(ds.Tables[0].Rows[0]["TokenUpdateDate"].ToString());
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
			strSql.Append("select MessageAccountID,MemberID,MessageServiceTypeID,AccountNumber,Status,Note,IsPrefer,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,TokenUID,TokenStr,TokenUpdateDate ");
			strSql.Append(" FROM MemberMessageAccount ");
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
			strSql.Append(" MessageAccountID,MemberID,MessageServiceTypeID,AccountNumber,Status,Note,IsPrefer,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,TokenUID,TokenStr,TokenUpdateDate ");
			strSql.Append(" FROM MemberMessageAccount ");
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
			strSql.Append("select count(1) FROM MemberMessageAccount ");
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
				strSql.Append("order by T.MessageAccountID desc");
			}
			strSql.Append(")AS Row, T.*  from MemberMessageAccount T ");
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
			parameters[0].Value = "MemberMessageAccount";
			parameters[1].Value = "MessageAccountID";
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

