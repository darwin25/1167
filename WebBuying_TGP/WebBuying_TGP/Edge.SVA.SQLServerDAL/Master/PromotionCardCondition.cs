using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:PromotionCardCondition
	/// </summary>
	public partial class PromotionCardCondition:IPromotionCardCondition
	{
		public PromotionCardCondition()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PromotionMsgID", "PromotionCardCondition"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PromotionMsgID,int CardGradeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PromotionCardCondition");
			strSql.Append(" where PromotionMsgID=@PromotionMsgID and CardGradeID=@CardGradeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionMsgID", SqlDbType.Int,4),
					new SqlParameter("@CardGradeID", SqlDbType.Int,4)			};
			parameters[0].Value = PromotionMsgID;
			parameters[1].Value = CardGradeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.PromotionCardCondition model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PromotionCardCondition(");
			strSql.Append("PromotionMsgID,CardGradeID)");
			strSql.Append(" values (");
			strSql.Append("@PromotionMsgID,@CardGradeID)");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionMsgID", SqlDbType.Int,4),
					new SqlParameter("@CardGradeID", SqlDbType.Int,4)};
			parameters[0].Value = model.PromotionMsgID;
			parameters[1].Value = model.CardGradeID;

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
		public bool Update(Edge.SVA.Model.PromotionCardCondition model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PromotionCardCondition set ");
 
			strSql.Append("PromotionMsgID=@PromotionMsgID,");
			strSql.Append("CardGradeID=@CardGradeID");
			strSql.Append(" where PromotionMsgID=@PromotionMsgID and CardGradeID=@CardGradeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionMsgID", SqlDbType.Int,4),
					new SqlParameter("@CardGradeID", SqlDbType.Int,4)};
			parameters[0].Value = model.PromotionMsgID;
			parameters[1].Value = model.CardGradeID;

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
		public bool Delete(int PromotionMsgID,int CardGradeID)
		{
            if (CardGradeID == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from PromotionCardCondition ");
                strSql.Append(" where PromotionMsgID=@PromotionMsgID ");
                SqlParameter[] parameters = {
					new SqlParameter("@PromotionMsgID", SqlDbType.Int,4)		};
                parameters[0].Value = PromotionMsgID;

                int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from PromotionCardCondition ");
                strSql.Append(" where PromotionMsgID=@PromotionMsgID and CardGradeID=@CardGradeID ");
                SqlParameter[] parameters = {
					new SqlParameter("@PromotionMsgID", SqlDbType.Int,4),
					new SqlParameter("@CardGradeID", SqlDbType.Int,4)			};
                parameters[0].Value = PromotionMsgID;
                parameters[1].Value = CardGradeID;

                int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
			
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.PromotionCardCondition GetModel(int PromotionMsgID,int CardGradeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PromotionMsgID,CardGradeID from PromotionCardCondition ");
			strSql.Append(" where PromotionMsgID=@PromotionMsgID and CardGradeID=@CardGradeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionMsgID", SqlDbType.Int,4),
					new SqlParameter("@CardGradeID", SqlDbType.Int,4)			};
			parameters[0].Value = PromotionMsgID;
			parameters[1].Value = CardGradeID;

			Edge.SVA.Model.PromotionCardCondition model=new Edge.SVA.Model.PromotionCardCondition();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PromotionMsgID"]!=null && ds.Tables[0].Rows[0]["PromotionMsgID"].ToString()!="")
				{
					model.PromotionMsgID=int.Parse(ds.Tables[0].Rows[0]["PromotionMsgID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardGradeID"]!=null && ds.Tables[0].Rows[0]["CardGradeID"].ToString()!="")
				{
					model.CardGradeID=int.Parse(ds.Tables[0].Rows[0]["CardGradeID"].ToString());
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
			strSql.Append("select PromotionMsgID,CardGradeID ");
			strSql.Append(" FROM PromotionCardCondition ");
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
			strSql.Append(" PromotionMsgID,CardGradeID ");
			strSql.Append(" FROM PromotionCardCondition ");
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
			strSql.Append("select count(1) FROM PromotionCardCondition ");
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
				strSql.Append("order by T.CardGradeID desc");
			}
			strSql.Append(")AS Row, T.*  from PromotionCardCondition T ");
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
			parameters[0].Value = "PromotionCardCondition";
			parameters[1].Value = "CardGradeID";
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

