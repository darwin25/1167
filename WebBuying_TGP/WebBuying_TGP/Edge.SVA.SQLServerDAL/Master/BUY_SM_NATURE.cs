using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_SM_NATURE
	/// </summary>
	public partial class BUY_SM_NATURE:IBUY_SM_NATURE
	{
		public BUY_SM_NATURE()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("TransType", "BUY_SM_NATURE"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TransType)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_SM_NATURE");
			strSql.Append(" where TransType=@TransType ");
			SqlParameter[] parameters = {
					new SqlParameter("@TransType", SqlDbType.Int,4)			};
			parameters[0].Value = TransType;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_SM_NATURE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_SM_NATURE(");
			strSql.Append("TransType,TransTypeName1,TransTypeName2,TransTypeName3,Nature)");
			strSql.Append(" values (");
			strSql.Append("@TransType,@TransTypeName1,@TransTypeName2,@TransTypeName3,@Nature)");
			SqlParameter[] parameters = {
					new SqlParameter("@TransType", SqlDbType.Int,4),
					new SqlParameter("@TransTypeName1", SqlDbType.NVarChar,512),
					new SqlParameter("@TransTypeName2", SqlDbType.NVarChar,512),
					new SqlParameter("@TransTypeName3", SqlDbType.NVarChar,512),
					new SqlParameter("@Nature", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.TransType;
			parameters[1].Value = model.TransTypeName1;
			parameters[2].Value = model.TransTypeName2;
			parameters[3].Value = model.TransTypeName3;
			parameters[4].Value = model.Nature;

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
		public bool Update(Edge.SVA.Model.BUY_SM_NATURE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_SM_NATURE set ");
			strSql.Append("TransTypeName1=@TransTypeName1,");
			strSql.Append("TransTypeName2=@TransTypeName2,");
			strSql.Append("TransTypeName3=@TransTypeName3,");
			strSql.Append("Nature=@Nature");
			strSql.Append(" where TransType=@TransType ");
			SqlParameter[] parameters = {
					new SqlParameter("@TransTypeName1", SqlDbType.NVarChar,512),
					new SqlParameter("@TransTypeName2", SqlDbType.NVarChar,512),
					new SqlParameter("@TransTypeName3", SqlDbType.NVarChar,512),
					new SqlParameter("@Nature", SqlDbType.NVarChar,512),
					new SqlParameter("@TransType", SqlDbType.Int,4)};
			parameters[0].Value = model.TransTypeName1;
			parameters[1].Value = model.TransTypeName2;
			parameters[2].Value = model.TransTypeName3;
			parameters[3].Value = model.Nature;
			parameters[4].Value = model.TransType;

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
		public bool Delete(int TransType)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_SM_NATURE ");
			strSql.Append(" where TransType=@TransType ");
			SqlParameter[] parameters = {
					new SqlParameter("@TransType", SqlDbType.Int,4)			};
			parameters[0].Value = TransType;

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
		public bool DeleteList(string TransTypelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_SM_NATURE ");
			strSql.Append(" where TransType in ("+TransTypelist + ")  ");
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
		public Edge.SVA.Model.BUY_SM_NATURE GetModel(int TransType)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TransType,TransTypeName1,TransTypeName2,TransTypeName3,Nature from BUY_SM_NATURE ");
			strSql.Append(" where TransType=@TransType ");
			SqlParameter[] parameters = {
					new SqlParameter("@TransType", SqlDbType.Int,4)			};
			parameters[0].Value = TransType;

			Edge.SVA.Model.BUY_SM_NATURE model=new Edge.SVA.Model.BUY_SM_NATURE();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["TransType"]!=null && ds.Tables[0].Rows[0]["TransType"].ToString()!="")
				{
					model.TransType=int.Parse(ds.Tables[0].Rows[0]["TransType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TransTypeName1"]!=null && ds.Tables[0].Rows[0]["TransTypeName1"].ToString()!="")
				{
					model.TransTypeName1=ds.Tables[0].Rows[0]["TransTypeName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TransTypeName2"]!=null && ds.Tables[0].Rows[0]["TransTypeName2"].ToString()!="")
				{
					model.TransTypeName2=ds.Tables[0].Rows[0]["TransTypeName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TransTypeName3"]!=null && ds.Tables[0].Rows[0]["TransTypeName3"].ToString()!="")
				{
					model.TransTypeName3=ds.Tables[0].Rows[0]["TransTypeName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Nature"]!=null && ds.Tables[0].Rows[0]["Nature"].ToString()!="")
				{
					model.Nature=ds.Tables[0].Rows[0]["Nature"].ToString();
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
			strSql.Append("select TransType,TransTypeName1,TransTypeName2,TransTypeName3,Nature ");
			strSql.Append(" FROM BUY_SM_NATURE ");
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
			strSql.Append(" TransType,TransTypeName1,TransTypeName2,TransTypeName3,Nature ");
			strSql.Append(" FROM BUY_SM_NATURE ");
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
			strSql.Append("select count(1) FROM BUY_SM_NATURE ");
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
				strSql.Append("order by T.TransType desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_SM_NATURE T ");
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
			parameters[0].Value = "BUY_SM_NATURE";
			parameters[1].Value = "TransType";
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

