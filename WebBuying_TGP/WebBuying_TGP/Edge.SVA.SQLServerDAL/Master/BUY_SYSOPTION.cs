using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_SYSOPTION
	/// </summary>
	public partial class BUY_SYSOPTION:IBUY_SYSOPTION
	{
		public BUY_SYSOPTION()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_SYSOPTION");
			strSql.Append(" where CODE=@CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,64)			};
			parameters[0].Value = CODE;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_SYSOPTION model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_SYSOPTION(");
			strSql.Append("CODE,NOTE,LanguageID)");
			strSql.Append(" values (");
			strSql.Append("@CODE,@NOTE,@LanguageID)");
			SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,64),
					new SqlParameter("@NOTE", SqlDbType.NVarChar,512),
					new SqlParameter("@LanguageID", SqlDbType.Int,4)};
			parameters[0].Value = model.CODE;
			parameters[1].Value = model.NOTE;
			parameters[2].Value = model.LanguageID;

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
		public bool Update(Edge.SVA.Model.BUY_SYSOPTION model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_SYSOPTION set ");
			strSql.Append("NOTE=@NOTE,");
			strSql.Append("LanguageID=@LanguageID");
			strSql.Append(" where CODE=@CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@NOTE", SqlDbType.NVarChar,512),
					new SqlParameter("@LanguageID", SqlDbType.Int,4),
					new SqlParameter("@CODE", SqlDbType.VarChar,64)};
			parameters[0].Value = model.NOTE;
			parameters[1].Value = model.LanguageID;
			parameters[2].Value = model.CODE;

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
		public bool Delete(string CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_SYSOPTION ");
			strSql.Append(" where CODE=@CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,64)			};
			parameters[0].Value = CODE;

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
		public bool DeleteList(string CODElist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_SYSOPTION ");
			strSql.Append(" where CODE in ("+CODElist + ")  ");
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
		public Edge.SVA.Model.BUY_SYSOPTION GetModel(string CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CODE,NOTE,LanguageID from BUY_SYSOPTION ");
			strSql.Append(" where CODE=@CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,64)			};
			parameters[0].Value = CODE;

			Edge.SVA.Model.BUY_SYSOPTION model=new Edge.SVA.Model.BUY_SYSOPTION();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CODE"]!=null && ds.Tables[0].Rows[0]["CODE"].ToString()!="")
				{
					model.CODE=ds.Tables[0].Rows[0]["CODE"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NOTE"]!=null && ds.Tables[0].Rows[0]["NOTE"].ToString()!="")
				{
					model.NOTE=ds.Tables[0].Rows[0]["NOTE"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LanguageID"]!=null && ds.Tables[0].Rows[0]["LanguageID"].ToString()!="")
				{
					model.LanguageID=int.Parse(ds.Tables[0].Rows[0]["LanguageID"].ToString());
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
			strSql.Append("select CODE,NOTE,LanguageID ");
			strSql.Append(" FROM BUY_SYSOPTION ");
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
			strSql.Append(" CODE,NOTE,LanguageID ");
			strSql.Append(" FROM BUY_SYSOPTION ");
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
			strSql.Append("select count(1) FROM BUY_SYSOPTION ");
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
				strSql.Append("order by T.CODE desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_SYSOPTION T ");
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
			parameters[0].Value = "BUY_SYSOPTION";
			parameters[1].Value = "CODE";
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

