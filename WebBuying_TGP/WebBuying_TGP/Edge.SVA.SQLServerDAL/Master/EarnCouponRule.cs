using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:EarnCouponRule
	/// </summary>
	public partial class EarnCouponRule:IEarnCouponRule
	{
		public EarnCouponRule()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "EarnCouponRule"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from EarnCouponRule");
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
		public int Add(Edge.SVA.Model.EarnCouponRule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into EarnCouponRule(");
			strSql.Append("CouponTypeID,ExchangeType,ExchangeRank,ExchangeAmount,ExchangePoint,ExchangeCouponTypeID,ExchangeCouponCount,ExchangeConsumeRuleOper,ExchangeConsumeAmount,CardTypeIDLimit,CardGradeIDLimit,CardTypeBrandIDLimit,StoreBrandIDLimit,StoreGroupIDLimit,StoreIDLimit,MemberBirthdayLimit,MemberSexLimit,MemberAgeMinLimit,MemberAgeMaxLimit,StartDate,EndDate,Status,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@CouponTypeID,@ExchangeType,@ExchangeRank,@ExchangeAmount,@ExchangePoint,@ExchangeCouponTypeID,@ExchangeCouponCount,@ExchangeConsumeRuleOper,@ExchangeConsumeAmount,@CardTypeIDLimit,@CardGradeIDLimit,@CardTypeBrandIDLimit,@StoreBrandIDLimit,@StoreGroupIDLimit,@StoreIDLimit,@MemberBirthdayLimit,@MemberSexLimit,@MemberAgeMinLimit,@MemberAgeMaxLimit,@StartDate,@EndDate,@Status,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CouponTypeID", SqlDbType.Int,4),
					new SqlParameter("@ExchangeType", SqlDbType.Int,4),
					new SqlParameter("@ExchangeRank", SqlDbType.Int,4),
					new SqlParameter("@ExchangeAmount", SqlDbType.Money,8),
					new SqlParameter("@ExchangePoint", SqlDbType.Int,4),
					new SqlParameter("@ExchangeCouponTypeID", SqlDbType.Int,4),
					new SqlParameter("@ExchangeCouponCount", SqlDbType.Int,4),
					new SqlParameter("@ExchangeConsumeRuleOper", SqlDbType.Int,4),
					new SqlParameter("@ExchangeConsumeAmount", SqlDbType.Money,8),
					new SqlParameter("@CardTypeIDLimit", SqlDbType.Int,4),
					new SqlParameter("@CardGradeIDLimit", SqlDbType.Int,4),
					new SqlParameter("@CardTypeBrandIDLimit", SqlDbType.Int,4),
					new SqlParameter("@StoreBrandIDLimit", SqlDbType.Int,4),
					new SqlParameter("@StoreGroupIDLimit", SqlDbType.Int,4),
					new SqlParameter("@StoreIDLimit", SqlDbType.Int,4),
					new SqlParameter("@MemberBirthdayLimit", SqlDbType.Int,4),
					new SqlParameter("@MemberSexLimit", SqlDbType.Int,4),
					new SqlParameter("@MemberAgeMinLimit", SqlDbType.Int,4),
					new SqlParameter("@MemberAgeMaxLimit", SqlDbType.Int,4),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.CouponTypeID;
			parameters[1].Value = model.ExchangeType;
			parameters[2].Value = model.ExchangeRank;
			parameters[3].Value = model.ExchangeAmount;
			parameters[4].Value = model.ExchangePoint;
			parameters[5].Value = model.ExchangeCouponTypeID;
			parameters[6].Value = model.ExchangeCouponCount;
			parameters[7].Value = model.ExchangeConsumeRuleOper;
			parameters[8].Value = model.ExchangeConsumeAmount;
			parameters[9].Value = model.CardTypeIDLimit;
			parameters[10].Value = model.CardGradeIDLimit;
			parameters[11].Value = model.CardTypeBrandIDLimit;
			parameters[12].Value = model.StoreBrandIDLimit;
			parameters[13].Value = model.StoreGroupIDLimit;
			parameters[14].Value = model.StoreIDLimit;
			parameters[15].Value = model.MemberBirthdayLimit;
			parameters[16].Value = model.MemberSexLimit;
			parameters[17].Value = model.MemberAgeMinLimit;
			parameters[18].Value = model.MemberAgeMaxLimit;
			parameters[19].Value = model.StartDate;
			parameters[20].Value = model.EndDate;
			parameters[21].Value = model.Status;
			parameters[22].Value = model.CreatedOn;
			parameters[23].Value = model.CreatedBy;
			parameters[24].Value = model.UpdatedOn;
			parameters[25].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.EarnCouponRule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update EarnCouponRule set ");
			strSql.Append("CouponTypeID=@CouponTypeID,");
			strSql.Append("ExchangeType=@ExchangeType,");
			strSql.Append("ExchangeRank=@ExchangeRank,");
			strSql.Append("ExchangeAmount=@ExchangeAmount,");
			strSql.Append("ExchangePoint=@ExchangePoint,");
			strSql.Append("ExchangeCouponTypeID=@ExchangeCouponTypeID,");
			strSql.Append("ExchangeCouponCount=@ExchangeCouponCount,");
			strSql.Append("ExchangeConsumeRuleOper=@ExchangeConsumeRuleOper,");
			strSql.Append("ExchangeConsumeAmount=@ExchangeConsumeAmount,");
			strSql.Append("CardTypeIDLimit=@CardTypeIDLimit,");
			strSql.Append("CardGradeIDLimit=@CardGradeIDLimit,");
			strSql.Append("CardTypeBrandIDLimit=@CardTypeBrandIDLimit,");
			strSql.Append("StoreBrandIDLimit=@StoreBrandIDLimit,");
			strSql.Append("StoreGroupIDLimit=@StoreGroupIDLimit,");
			strSql.Append("StoreIDLimit=@StoreIDLimit,");
			strSql.Append("MemberBirthdayLimit=@MemberBirthdayLimit,");
			strSql.Append("MemberSexLimit=@MemberSexLimit,");
			strSql.Append("MemberAgeMinLimit=@MemberAgeMinLimit,");
			strSql.Append("MemberAgeMaxLimit=@MemberAgeMaxLimit,");
			strSql.Append("StartDate=@StartDate,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@CouponTypeID", SqlDbType.Int,4),
					new SqlParameter("@ExchangeType", SqlDbType.Int,4),
					new SqlParameter("@ExchangeRank", SqlDbType.Int,4),
					new SqlParameter("@ExchangeAmount", SqlDbType.Money,8),
					new SqlParameter("@ExchangePoint", SqlDbType.Int,4),
					new SqlParameter("@ExchangeCouponTypeID", SqlDbType.Int,4),
					new SqlParameter("@ExchangeCouponCount", SqlDbType.Int,4),
					new SqlParameter("@ExchangeConsumeRuleOper", SqlDbType.Int,4),
					new SqlParameter("@ExchangeConsumeAmount", SqlDbType.Money,8),
					new SqlParameter("@CardTypeIDLimit", SqlDbType.Int,4),
					new SqlParameter("@CardGradeIDLimit", SqlDbType.Int,4),
					new SqlParameter("@CardTypeBrandIDLimit", SqlDbType.Int,4),
					new SqlParameter("@StoreBrandIDLimit", SqlDbType.Int,4),
					new SqlParameter("@StoreGroupIDLimit", SqlDbType.Int,4),
					new SqlParameter("@StoreIDLimit", SqlDbType.Int,4),
					new SqlParameter("@MemberBirthdayLimit", SqlDbType.Int,4),
					new SqlParameter("@MemberSexLimit", SqlDbType.Int,4),
					new SqlParameter("@MemberAgeMinLimit", SqlDbType.Int,4),
					new SqlParameter("@MemberAgeMaxLimit", SqlDbType.Int,4),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.CouponTypeID;
			parameters[1].Value = model.ExchangeType;
			parameters[2].Value = model.ExchangeRank;
			parameters[3].Value = model.ExchangeAmount;
			parameters[4].Value = model.ExchangePoint;
			parameters[5].Value = model.ExchangeCouponTypeID;
			parameters[6].Value = model.ExchangeCouponCount;
			parameters[7].Value = model.ExchangeConsumeRuleOper;
			parameters[8].Value = model.ExchangeConsumeAmount;
			parameters[9].Value = model.CardTypeIDLimit;
			parameters[10].Value = model.CardGradeIDLimit;
			parameters[11].Value = model.CardTypeBrandIDLimit;
			parameters[12].Value = model.StoreBrandIDLimit;
			parameters[13].Value = model.StoreGroupIDLimit;
			parameters[14].Value = model.StoreIDLimit;
			parameters[15].Value = model.MemberBirthdayLimit;
			parameters[16].Value = model.MemberSexLimit;
			parameters[17].Value = model.MemberAgeMinLimit;
			parameters[18].Value = model.MemberAgeMaxLimit;
			parameters[19].Value = model.StartDate;
			parameters[20].Value = model.EndDate;
			parameters[21].Value = model.Status;
			parameters[22].Value = model.CreatedOn;
			parameters[23].Value = model.CreatedBy;
			parameters[24].Value = model.UpdatedOn;
			parameters[25].Value = model.UpdatedBy;
			parameters[26].Value = model.KeyID;

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
			strSql.Append("delete from EarnCouponRule ");
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
			strSql.Append("delete from EarnCouponRule ");
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
		public Edge.SVA.Model.EarnCouponRule GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,CouponTypeID,ExchangeType,ExchangeRank,ExchangeAmount,ExchangePoint,ExchangeCouponTypeID,ExchangeCouponCount,ExchangeConsumeRuleOper,ExchangeConsumeAmount,CardTypeIDLimit,CardGradeIDLimit,CardTypeBrandIDLimit,StoreBrandIDLimit,StoreGroupIDLimit,StoreIDLimit,MemberBirthdayLimit,MemberSexLimit,MemberAgeMinLimit,MemberAgeMaxLimit,StartDate,EndDate,Status,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from EarnCouponRule ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.EarnCouponRule model=new Edge.SVA.Model.EarnCouponRule();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CouponTypeID"]!=null && ds.Tables[0].Rows[0]["CouponTypeID"].ToString()!="")
				{
					model.CouponTypeID=int.Parse(ds.Tables[0].Rows[0]["CouponTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ExchangeType"]!=null && ds.Tables[0].Rows[0]["ExchangeType"].ToString()!="")
				{
					model.ExchangeType=int.Parse(ds.Tables[0].Rows[0]["ExchangeType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ExchangeRank"]!=null && ds.Tables[0].Rows[0]["ExchangeRank"].ToString()!="")
				{
					model.ExchangeRank=int.Parse(ds.Tables[0].Rows[0]["ExchangeRank"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ExchangeAmount"]!=null && ds.Tables[0].Rows[0]["ExchangeAmount"].ToString()!="")
				{
					model.ExchangeAmount=decimal.Parse(ds.Tables[0].Rows[0]["ExchangeAmount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ExchangePoint"]!=null && ds.Tables[0].Rows[0]["ExchangePoint"].ToString()!="")
				{
					model.ExchangePoint=int.Parse(ds.Tables[0].Rows[0]["ExchangePoint"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ExchangeCouponTypeID"]!=null && ds.Tables[0].Rows[0]["ExchangeCouponTypeID"].ToString()!="")
				{
					model.ExchangeCouponTypeID=int.Parse(ds.Tables[0].Rows[0]["ExchangeCouponTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ExchangeCouponCount"]!=null && ds.Tables[0].Rows[0]["ExchangeCouponCount"].ToString()!="")
				{
					model.ExchangeCouponCount=int.Parse(ds.Tables[0].Rows[0]["ExchangeCouponCount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ExchangeConsumeRuleOper"]!=null && ds.Tables[0].Rows[0]["ExchangeConsumeRuleOper"].ToString()!="")
				{
					model.ExchangeConsumeRuleOper=int.Parse(ds.Tables[0].Rows[0]["ExchangeConsumeRuleOper"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ExchangeConsumeAmount"]!=null && ds.Tables[0].Rows[0]["ExchangeConsumeAmount"].ToString()!="")
				{
					model.ExchangeConsumeAmount=decimal.Parse(ds.Tables[0].Rows[0]["ExchangeConsumeAmount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardTypeIDLimit"]!=null && ds.Tables[0].Rows[0]["CardTypeIDLimit"].ToString()!="")
				{
					model.CardTypeIDLimit=int.Parse(ds.Tables[0].Rows[0]["CardTypeIDLimit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardGradeIDLimit"]!=null && ds.Tables[0].Rows[0]["CardGradeIDLimit"].ToString()!="")
				{
					model.CardGradeIDLimit=int.Parse(ds.Tables[0].Rows[0]["CardGradeIDLimit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardTypeBrandIDLimit"]!=null && ds.Tables[0].Rows[0]["CardTypeBrandIDLimit"].ToString()!="")
				{
					model.CardTypeBrandIDLimit=int.Parse(ds.Tables[0].Rows[0]["CardTypeBrandIDLimit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StoreBrandIDLimit"]!=null && ds.Tables[0].Rows[0]["StoreBrandIDLimit"].ToString()!="")
				{
					model.StoreBrandIDLimit=int.Parse(ds.Tables[0].Rows[0]["StoreBrandIDLimit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StoreGroupIDLimit"]!=null && ds.Tables[0].Rows[0]["StoreGroupIDLimit"].ToString()!="")
				{
					model.StoreGroupIDLimit=int.Parse(ds.Tables[0].Rows[0]["StoreGroupIDLimit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StoreIDLimit"]!=null && ds.Tables[0].Rows[0]["StoreIDLimit"].ToString()!="")
				{
					model.StoreIDLimit=int.Parse(ds.Tables[0].Rows[0]["StoreIDLimit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberBirthdayLimit"]!=null && ds.Tables[0].Rows[0]["MemberBirthdayLimit"].ToString()!="")
				{
					model.MemberBirthdayLimit=int.Parse(ds.Tables[0].Rows[0]["MemberBirthdayLimit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberSexLimit"]!=null && ds.Tables[0].Rows[0]["MemberSexLimit"].ToString()!="")
				{
					model.MemberSexLimit=int.Parse(ds.Tables[0].Rows[0]["MemberSexLimit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberAgeMinLimit"]!=null && ds.Tables[0].Rows[0]["MemberAgeMinLimit"].ToString()!="")
				{
					model.MemberAgeMinLimit=int.Parse(ds.Tables[0].Rows[0]["MemberAgeMinLimit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberAgeMaxLimit"]!=null && ds.Tables[0].Rows[0]["MemberAgeMaxLimit"].ToString()!="")
				{
					model.MemberAgeMaxLimit=int.Parse(ds.Tables[0].Rows[0]["MemberAgeMaxLimit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StartDate"]!=null && ds.Tables[0].Rows[0]["StartDate"].ToString()!="")
				{
					model.StartDate=DateTime.Parse(ds.Tables[0].Rows[0]["StartDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndDate"]!=null && ds.Tables[0].Rows[0]["EndDate"].ToString()!="")
				{
					model.EndDate=DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
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
			strSql.Append("select KeyID,CouponTypeID,ExchangeType,ExchangeRank,ExchangeAmount,ExchangePoint,ExchangeCouponTypeID,ExchangeCouponCount,ExchangeConsumeRuleOper,ExchangeConsumeAmount,CardTypeIDLimit,CardGradeIDLimit,CardTypeBrandIDLimit,StoreBrandIDLimit,StoreGroupIDLimit,StoreIDLimit,MemberBirthdayLimit,MemberSexLimit,MemberAgeMinLimit,MemberAgeMaxLimit,StartDate,EndDate,Status,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM EarnCouponRule ");
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
			strSql.Append(" KeyID,CouponTypeID,ExchangeType,ExchangeRank,ExchangeAmount,ExchangePoint,ExchangeCouponTypeID,ExchangeCouponCount,ExchangeConsumeRuleOper,ExchangeConsumeAmount,CardTypeIDLimit,CardGradeIDLimit,CardTypeBrandIDLimit,StoreBrandIDLimit,StoreGroupIDLimit,StoreIDLimit,MemberBirthdayLimit,MemberSexLimit,MemberAgeMinLimit,MemberAgeMaxLimit,StartDate,EndDate,Status,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM EarnCouponRule ");
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
            parameters[0].Value = "EarnCouponRule";
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
            sql.Append("select count(*) from EarnCouponRule ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

