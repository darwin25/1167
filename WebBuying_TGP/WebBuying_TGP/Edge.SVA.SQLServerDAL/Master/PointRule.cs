using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:PointRule
	/// </summary>
	public partial class PointRule:IPointRule
	{
		public PointRule()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PointRuleID", "PointRule"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PointRuleID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PointRule");
			strSql.Append(" where PointRuleID=@PointRuleID");
			SqlParameter[] parameters = {
					new SqlParameter("@PointRuleID", SqlDbType.Int,4)
};
			parameters[0].Value = PointRuleID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.PointRule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PointRule(");
			strSql.Append("CardTypeID,CardGradeID,PointRuleSeqNo,PointRuleOper,PointRuleAmount,PointRulePoints,StartDate,EndDate,CreatedOn,UpdatedOn,CreatedBy,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@CardTypeID,@CardGradeID,@PointRuleSeqNo,@PointRuleOper,@PointRuleAmount,@PointRulePoints,@StartDate,@EndDate,@CreatedOn,@UpdatedOn,@CreatedBy,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CardTypeID", SqlDbType.Int,4),
					new SqlParameter("@CardGradeID", SqlDbType.Int,4),
					new SqlParameter("@PointRuleSeqNo", SqlDbType.Int,4),
					new SqlParameter("@PointRuleOper", SqlDbType.Int,4),
					new SqlParameter("@PointRuleAmount", SqlDbType.Money,8),
					new SqlParameter("@PointRulePoints", SqlDbType.Int,4),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.CardTypeID;
			parameters[1].Value = model.CardGradeID;
			parameters[2].Value = model.PointRuleSeqNo;
			parameters[3].Value = model.PointRuleOper;
			parameters[4].Value = model.PointRuleAmount;
			parameters[5].Value = model.PointRulePoints;
			parameters[6].Value = model.StartDate;
			parameters[7].Value = model.EndDate;
			parameters[8].Value = model.CreatedOn;
			parameters[9].Value = model.UpdatedOn;
			parameters[10].Value = model.CreatedBy;
			parameters[11].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.PointRule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PointRule set ");
			strSql.Append("CardTypeID=@CardTypeID,");
			strSql.Append("CardGradeID=@CardGradeID,");
			strSql.Append("PointRuleSeqNo=@PointRuleSeqNo,");
			strSql.Append("PointRuleOper=@PointRuleOper,");
			strSql.Append("PointRuleAmount=@PointRuleAmount,");
			strSql.Append("PointRulePoints=@PointRulePoints,");
			strSql.Append("StartDate=@StartDate,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where PointRuleID=@PointRuleID");
			SqlParameter[] parameters = {
					new SqlParameter("@CardTypeID", SqlDbType.Int,4),
					new SqlParameter("@CardGradeID", SqlDbType.Int,4),
					new SqlParameter("@PointRuleSeqNo", SqlDbType.Int,4),
					new SqlParameter("@PointRuleOper", SqlDbType.Int,4),
					new SqlParameter("@PointRuleAmount", SqlDbType.Money,8),
					new SqlParameter("@PointRulePoints", SqlDbType.Int,4),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@PointRuleID", SqlDbType.Int,4)};
			parameters[0].Value = model.CardTypeID;
			parameters[1].Value = model.CardGradeID;
			parameters[2].Value = model.PointRuleSeqNo;
			parameters[3].Value = model.PointRuleOper;
			parameters[4].Value = model.PointRuleAmount;
			parameters[5].Value = model.PointRulePoints;
			parameters[6].Value = model.StartDate;
			parameters[7].Value = model.EndDate;
			parameters[8].Value = model.CreatedOn;
			parameters[9].Value = model.UpdatedOn;
			parameters[10].Value = model.CreatedBy;
			parameters[11].Value = model.UpdatedBy;
			parameters[12].Value = model.PointRuleID;

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
		public bool Delete(int PointRuleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PointRule ");
			strSql.Append(" where PointRuleID=@PointRuleID");
			SqlParameter[] parameters = {
					new SqlParameter("@PointRuleID", SqlDbType.Int,4)
};
			parameters[0].Value = PointRuleID;

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
		public bool DeleteList(string PointRuleIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PointRule ");
			strSql.Append(" where PointRuleID in ("+PointRuleIDlist + ")  ");
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
		public Edge.SVA.Model.PointRule GetModel(int PointRuleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PointRuleID,CardTypeID,CardGradeID,PointRuleSeqNo,PointRuleOper,PointRuleAmount,PointRulePoints,StartDate,EndDate,CreatedOn,UpdatedOn,CreatedBy,UpdatedBy from PointRule ");
			strSql.Append(" where PointRuleID=@PointRuleID");
			SqlParameter[] parameters = {
					new SqlParameter("@PointRuleID", SqlDbType.Int,4)
};
			parameters[0].Value = PointRuleID;

			Edge.SVA.Model.PointRule model=new Edge.SVA.Model.PointRule();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PointRuleID"]!=null && ds.Tables[0].Rows[0]["PointRuleID"].ToString()!="")
				{
					model.PointRuleID=int.Parse(ds.Tables[0].Rows[0]["PointRuleID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardTypeID"]!=null && ds.Tables[0].Rows[0]["CardTypeID"].ToString()!="")
				{
					model.CardTypeID=int.Parse(ds.Tables[0].Rows[0]["CardTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardGradeID"]!=null && ds.Tables[0].Rows[0]["CardGradeID"].ToString()!="")
				{
					model.CardGradeID=int.Parse(ds.Tables[0].Rows[0]["CardGradeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PointRuleSeqNo"]!=null && ds.Tables[0].Rows[0]["PointRuleSeqNo"].ToString()!="")
				{
					model.PointRuleSeqNo=int.Parse(ds.Tables[0].Rows[0]["PointRuleSeqNo"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PointRuleOper"]!=null && ds.Tables[0].Rows[0]["PointRuleOper"].ToString()!="")
				{
					model.PointRuleOper=int.Parse(ds.Tables[0].Rows[0]["PointRuleOper"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PointRuleAmount"]!=null && ds.Tables[0].Rows[0]["PointRuleAmount"].ToString()!="")
				{
					model.PointRuleAmount=decimal.Parse(ds.Tables[0].Rows[0]["PointRuleAmount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PointRulePoints"]!=null && ds.Tables[0].Rows[0]["PointRulePoints"].ToString()!="")
				{
					model.PointRulePoints=int.Parse(ds.Tables[0].Rows[0]["PointRulePoints"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StartDate"]!=null && ds.Tables[0].Rows[0]["StartDate"].ToString()!="")
				{
					model.StartDate=DateTime.Parse(ds.Tables[0].Rows[0]["StartDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndDate"]!=null && ds.Tables[0].Rows[0]["EndDate"].ToString()!="")
				{
					model.EndDate=DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedOn"]!=null && ds.Tables[0].Rows[0]["CreatedOn"].ToString()!="")
				{
					model.CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedOn"]!=null && ds.Tables[0].Rows[0]["UpdatedOn"].ToString()!="")
				{
					model.UpdatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedBy"]!=null && ds.Tables[0].Rows[0]["CreatedBy"].ToString()!="")
				{
					model.CreatedBy=int.Parse(ds.Tables[0].Rows[0]["CreatedBy"].ToString());
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
			strSql.Append("select PointRuleID,CardTypeID,CardGradeID,PointRuleSeqNo,PointRuleOper,PointRuleAmount,PointRulePoints,StartDate,EndDate,CreatedOn,UpdatedOn,CreatedBy,UpdatedBy ");
			strSql.Append(" FROM PointRule ");
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
			strSql.Append(" PointRuleID,CardTypeID,CardGradeID,PointRuleSeqNo,PointRuleOper,PointRuleAmount,PointRulePoints,StartDate,EndDate,CreatedOn,UpdatedOn,CreatedBy,UpdatedBy ");
			strSql.Append(" FROM PointRule ");
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
            parameters[0].Value = "PointRule";
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
            sql.Append("select count(*) from PointRule ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }


		#endregion  Method
	}
}

