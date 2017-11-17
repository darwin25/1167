using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Country
	/// </summary>
	public partial class Country:ICountry
	{
		public Country()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CountryCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Country");
			strSql.Append(" where CountryCode=@CountryCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@CountryCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = CountryCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Country model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Country(");
			strSql.Append("CountryCode,CountryName1,CountryName2,CountryName3)");
			strSql.Append(" values (");
			strSql.Append("@CountryCode,@CountryName1,@CountryName2,@CountryName3)");
			SqlParameter[] parameters = {
					new SqlParameter("@CountryCode", SqlDbType.VarChar,64),
					new SqlParameter("@CountryName1", SqlDbType.NVarChar,512),
					new SqlParameter("@CountryName2", SqlDbType.NVarChar,512),
					new SqlParameter("@CountryName3", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.CountryCode;
			parameters[1].Value = model.CountryName1;
			parameters[2].Value = model.CountryName2;
			parameters[3].Value = model.CountryName3;

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
		public bool Update(Edge.SVA.Model.Country model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Country set ");
			strSql.Append("CountryName1=@CountryName1,");
			strSql.Append("CountryName2=@CountryName2,");
			strSql.Append("CountryName3=@CountryName3");
			strSql.Append(" where CountryCode=@CountryCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@CountryName1", SqlDbType.NVarChar,512),
					new SqlParameter("@CountryName2", SqlDbType.NVarChar,512),
					new SqlParameter("@CountryName3", SqlDbType.NVarChar,512),
					new SqlParameter("@CountryCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.CountryName1;
			parameters[1].Value = model.CountryName2;
			parameters[2].Value = model.CountryName3;
			parameters[3].Value = model.CountryCode;

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
		public bool Delete(string CountryCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Country ");
			strSql.Append(" where CountryCode=@CountryCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@CountryCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = CountryCode;

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
		public bool DeleteList(string CountryCodelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Country ");
			strSql.Append(" where CountryCode in ("+CountryCodelist + ")  ");
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
		public Edge.SVA.Model.Country GetModel(string CountryCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CountryCode,CountryName1,CountryName2,CountryName3 from Country ");
			strSql.Append(" where CountryCode=@CountryCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@CountryCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = CountryCode;

			Edge.SVA.Model.Country model=new Edge.SVA.Model.Country();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CountryCode"]!=null && ds.Tables[0].Rows[0]["CountryCode"].ToString()!="")
				{
					model.CountryCode=ds.Tables[0].Rows[0]["CountryCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CountryName1"]!=null && ds.Tables[0].Rows[0]["CountryName1"].ToString()!="")
				{
					model.CountryName1=ds.Tables[0].Rows[0]["CountryName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CountryName2"]!=null && ds.Tables[0].Rows[0]["CountryName2"].ToString()!="")
				{
					model.CountryName2=ds.Tables[0].Rows[0]["CountryName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CountryName3"]!=null && ds.Tables[0].Rows[0]["CountryName3"].ToString()!="")
				{
					model.CountryName3=ds.Tables[0].Rows[0]["CountryName3"].ToString();
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
			strSql.Append("select CountryCode,CountryName1,CountryName2,CountryName3 ");
			strSql.Append(" FROM Country ");
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
			strSql.Append(" CountryCode,CountryName1,CountryName2,CountryName3 ");
			strSql.Append(" FROM Country ");
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
			strSql.Append("select count(1) FROM Country ");
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
				strSql.Append("order by T.CountryCode desc");
			}
			strSql.Append(")AS Row, T.*  from Country T ");
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
			parameters[0].Value = "Country";
			parameters[1].Value = "CountryCode";
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

