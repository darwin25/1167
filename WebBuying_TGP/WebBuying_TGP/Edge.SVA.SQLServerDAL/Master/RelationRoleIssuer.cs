using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references

namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:RelationRoleIssuer
	/// </summary>
	public partial class RelationRoleIssuer:IRelationRoleIssuer
	{
		public RelationRoleIssuer()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("RoleID", "RelationRoleIssuer"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RoleID,int CardIssuerID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from RelationRoleIssuer");
			strSql.Append(" where RoleID=@RoleID and CardIssuerID=@CardIssuerID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@CardIssuerID", SqlDbType.Int,4)			};
			parameters[0].Value = RoleID;
			parameters[1].Value = CardIssuerID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.RelationRoleIssuer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RelationRoleIssuer(");
			strSql.Append("RoleID,CardIssuerID)");
			strSql.Append(" values (");
			strSql.Append("@RoleID,@CardIssuerID)");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@CardIssuerID", SqlDbType.Int,4)};
			parameters[0].Value = model.RoleID;
			parameters[1].Value = model.CardIssuerID;

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
		public bool Update(Edge.SVA.Model.RelationRoleIssuer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RelationRoleIssuer set ");
			strSql.Append("RoleID=@RoleID,");
			strSql.Append("CardIssuerID=@CardIssuerID");
			strSql.Append(" where RoleID=@RoleID and CardIssuerID=@CardIssuerID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@CardIssuerID", SqlDbType.Int,4)};
			parameters[0].Value = model.RoleID;
			parameters[1].Value = model.CardIssuerID;

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
		public bool Delete(int RoleID,int CardIssuerID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RelationRoleIssuer ");
			strSql.Append(" where RoleID=@RoleID and CardIssuerID=@CardIssuerID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@CardIssuerID", SqlDbType.Int,4)			};
			parameters[0].Value = RoleID;
			parameters[1].Value = CardIssuerID;

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
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.RelationRoleIssuer GetModel(int RoleID,int CardIssuerID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RoleID,CardIssuerID from RelationRoleIssuer ");
			strSql.Append(" where RoleID=@RoleID and CardIssuerID=@CardIssuerID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@CardIssuerID", SqlDbType.Int,4)			};
			parameters[0].Value = RoleID;
			parameters[1].Value = CardIssuerID;

			Edge.SVA.Model.RelationRoleIssuer model=new Edge.SVA.Model.RelationRoleIssuer();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["RoleID"]!=null && ds.Tables[0].Rows[0]["RoleID"].ToString()!="")
				{
					model.RoleID=int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardIssuerID"]!=null && ds.Tables[0].Rows[0]["CardIssuerID"].ToString()!="")
				{
					model.CardIssuerID=int.Parse(ds.Tables[0].Rows[0]["CardIssuerID"].ToString());
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
			strSql.Append("select RoleID,CardIssuerID ");
			strSql.Append(" FROM RelationRoleIssuer ");
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
			strSql.Append(" RoleID,CardIssuerID ");
			strSql.Append(" FROM RelationRoleIssuer ");
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
			strSql.Append("select count(1) FROM RelationRoleIssuer ");
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
				strSql.Append("order by T.CardIssuerID desc");
			}
			strSql.Append(")AS Row, T.*  from RelationRoleIssuer T ");
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
					new SqlParameter("@strWhere", SqlDbType.NText),
					};
			parameters[0].Value = "RelationRoleIssuer";
			parameters[1].Value = "CardIssuerID";
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

