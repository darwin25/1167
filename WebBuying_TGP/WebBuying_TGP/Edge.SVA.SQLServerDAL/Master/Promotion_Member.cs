using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Promotion_Member
	/// </summary>
	public partial class Promotion_Member:IPromotion_Member
	{
		public Promotion_Member()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "Promotion_Member"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Promotion_Member");
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
		public int Add(Edge.SVA.Model.Promotion_Member model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Promotion_Member(");
			strSql.Append("PromotionCode,LoyaltyCardTypeID,LoyaltyCardGradeID,LoyaltyThreshold,LoyaltyBirthdayFlag)");
			strSql.Append(" values (");
			strSql.Append("@PromotionCode,@LoyaltyCardTypeID,@LoyaltyCardGradeID,@LoyaltyThreshold,@LoyaltyBirthdayFlag)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionCode", SqlDbType.VarChar,64),
					new SqlParameter("@LoyaltyCardTypeID", SqlDbType.Int,4),
					new SqlParameter("@LoyaltyCardGradeID", SqlDbType.Int,4),
					new SqlParameter("@LoyaltyThreshold", SqlDbType.Int,4),
					new SqlParameter("@LoyaltyBirthdayFlag", SqlDbType.Int,4)};
			parameters[0].Value = model.PromotionCode;
			parameters[1].Value = model.LoyaltyCardTypeID;
			parameters[2].Value = model.LoyaltyCardGradeID;
			parameters[3].Value = model.LoyaltyThreshold;
			parameters[4].Value = model.LoyaltyBirthdayFlag;

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
		public bool Update(Edge.SVA.Model.Promotion_Member model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Promotion_Member set ");
			strSql.Append("PromotionCode=@PromotionCode,");
			strSql.Append("LoyaltyCardTypeID=@LoyaltyCardTypeID,");
			strSql.Append("LoyaltyCardGradeID=@LoyaltyCardGradeID,");
			strSql.Append("LoyaltyThreshold=@LoyaltyThreshold,");
			strSql.Append("LoyaltyBirthdayFlag=@LoyaltyBirthdayFlag");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionCode", SqlDbType.VarChar,64),
					new SqlParameter("@LoyaltyCardTypeID", SqlDbType.Int,4),
					new SqlParameter("@LoyaltyCardGradeID", SqlDbType.Int,4),
					new SqlParameter("@LoyaltyThreshold", SqlDbType.Int,4),
					new SqlParameter("@LoyaltyBirthdayFlag", SqlDbType.Int,4),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.PromotionCode;
			parameters[1].Value = model.LoyaltyCardTypeID;
			parameters[2].Value = model.LoyaltyCardGradeID;
			parameters[3].Value = model.LoyaltyThreshold;
			parameters[4].Value = model.LoyaltyBirthdayFlag;
			parameters[5].Value = model.KeyID;

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
			strSql.Append("delete from Promotion_Member ");
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
			strSql.Append("delete from Promotion_Member ");
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
		public Edge.SVA.Model.Promotion_Member GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,PromotionCode,LoyaltyCardTypeID,LoyaltyCardGradeID,LoyaltyThreshold,LoyaltyBirthdayFlag from Promotion_Member ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.Promotion_Member model=new Edge.SVA.Model.Promotion_Member();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PromotionCode"]!=null && ds.Tables[0].Rows[0]["PromotionCode"].ToString()!="")
				{
					model.PromotionCode=ds.Tables[0].Rows[0]["PromotionCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LoyaltyCardTypeID"]!=null && ds.Tables[0].Rows[0]["LoyaltyCardTypeID"].ToString()!="")
				{
					model.LoyaltyCardTypeID=int.Parse(ds.Tables[0].Rows[0]["LoyaltyCardTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LoyaltyCardGradeID"]!=null && ds.Tables[0].Rows[0]["LoyaltyCardGradeID"].ToString()!="")
				{
					model.LoyaltyCardGradeID=int.Parse(ds.Tables[0].Rows[0]["LoyaltyCardGradeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LoyaltyThreshold"]!=null && ds.Tables[0].Rows[0]["LoyaltyThreshold"].ToString()!="")
				{
					model.LoyaltyThreshold=int.Parse(ds.Tables[0].Rows[0]["LoyaltyThreshold"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LoyaltyBirthdayFlag"]!=null && ds.Tables[0].Rows[0]["LoyaltyBirthdayFlag"].ToString()!="")
				{
					model.LoyaltyBirthdayFlag=int.Parse(ds.Tables[0].Rows[0]["LoyaltyBirthdayFlag"].ToString());
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
			strSql.Append("select KeyID,PromotionCode,LoyaltyCardTypeID,LoyaltyCardGradeID,LoyaltyThreshold,LoyaltyBirthdayFlag ");
			strSql.Append(" FROM Promotion_Member ");
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
			strSql.Append(" KeyID,PromotionCode,LoyaltyCardTypeID,LoyaltyCardGradeID,LoyaltyThreshold,LoyaltyBirthdayFlag ");
			strSql.Append(" FROM Promotion_Member ");
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
			strSql.Append("select count(1) FROM Promotion_Member ");
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
				strSql.Append("order by T.KeyID desc");
			}
			strSql.Append(")AS Row, T.*  from Promotion_Member T ");
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
			parameters[0].Value = "Promotion_Member";
			parameters[1].Value = "KeyID";
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

