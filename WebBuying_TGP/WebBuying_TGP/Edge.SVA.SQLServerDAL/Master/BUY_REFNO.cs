using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_REFNO
	/// </summary>
	public partial class BUY_REFNO:IBUY_REFNO
	{
		public BUY_REFNO()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Code)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_REFNO");
			strSql.Append(" where Code=@Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,6)			};
			parameters[0].Value = Code;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_REFNO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_REFNO(");
			strSql.Append("Code,RefDesc,Header,Seq,Length,Auto,Active)");
			strSql.Append(" values (");
			strSql.Append("@Code,@RefDesc,@Header,@Seq,@Length,@Auto,@Active)");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,6),
					new SqlParameter("@RefDesc", SqlDbType.VarChar,512),
					new SqlParameter("@Header", SqlDbType.VarChar,6),
					new SqlParameter("@Seq", SqlDbType.Int,4),
					new SqlParameter("@Length", SqlDbType.Int,4),
					new SqlParameter("@Auto", SqlDbType.Char,1),
					new SqlParameter("@Active", SqlDbType.Int,4)};
			parameters[0].Value = model.Code;
			parameters[1].Value = model.RefDesc;
			parameters[2].Value = model.Header;
			parameters[3].Value = model.Seq;
			parameters[4].Value = model.Length;
			parameters[5].Value = model.Auto;
			parameters[6].Value = model.Active;

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
		public bool Update(Edge.SVA.Model.BUY_REFNO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_REFNO set ");
			strSql.Append("RefDesc=@RefDesc,");
			strSql.Append("Header=@Header,");
			strSql.Append("Seq=@Seq,");
			strSql.Append("Length=@Length,");
			strSql.Append("Auto=@Auto,");
			strSql.Append("Active=@Active");
			strSql.Append(" where Code=@Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@RefDesc", SqlDbType.VarChar,512),
					new SqlParameter("@Header", SqlDbType.VarChar,6),
					new SqlParameter("@Seq", SqlDbType.Int,4),
					new SqlParameter("@Length", SqlDbType.Int,4),
					new SqlParameter("@Auto", SqlDbType.Char,1),
					new SqlParameter("@Active", SqlDbType.Int,4),
					new SqlParameter("@Code", SqlDbType.VarChar,6)};
			parameters[0].Value = model.RefDesc;
			parameters[1].Value = model.Header;
			parameters[2].Value = model.Seq;
			parameters[3].Value = model.Length;
			parameters[4].Value = model.Auto;
			parameters[5].Value = model.Active;
			parameters[6].Value = model.Code;

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
		public bool Delete(string Code)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_REFNO ");
			strSql.Append(" where Code=@Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,6)			};
			parameters[0].Value = Code;

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
		public bool DeleteList(string Codelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_REFNO ");
			strSql.Append(" where Code in ("+Codelist + ")  ");
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
		public Edge.SVA.Model.BUY_REFNO GetModel(string Code)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Code,RefDesc,Header,Seq,Length,Auto,Active from BUY_REFNO ");
			strSql.Append(" where Code=@Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,6)			};
			parameters[0].Value = Code;

			Edge.SVA.Model.BUY_REFNO model=new Edge.SVA.Model.BUY_REFNO();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Code"]!=null && ds.Tables[0].Rows[0]["Code"].ToString()!="")
				{
					model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RefDesc"]!=null && ds.Tables[0].Rows[0]["RefDesc"].ToString()!="")
				{
					model.RefDesc=ds.Tables[0].Rows[0]["RefDesc"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Header"]!=null && ds.Tables[0].Rows[0]["Header"].ToString()!="")
				{
					model.Header=ds.Tables[0].Rows[0]["Header"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Seq"]!=null && ds.Tables[0].Rows[0]["Seq"].ToString()!="")
				{
					model.Seq=int.Parse(ds.Tables[0].Rows[0]["Seq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Length"]!=null && ds.Tables[0].Rows[0]["Length"].ToString()!="")
				{
					model.Length=int.Parse(ds.Tables[0].Rows[0]["Length"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Auto"]!=null && ds.Tables[0].Rows[0]["Auto"].ToString()!="")
				{
					model.Auto=ds.Tables[0].Rows[0]["Auto"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Active"]!=null && ds.Tables[0].Rows[0]["Active"].ToString()!="")
				{
					model.Active=int.Parse(ds.Tables[0].Rows[0]["Active"].ToString());
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
			strSql.Append("select Code,RefDesc,Header,Seq,Length,Auto,Active ");
			strSql.Append(" FROM BUY_REFNO ");
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
			strSql.Append(" Code,RefDesc,Header,Seq,Length,Auto,Active ");
			strSql.Append(" FROM BUY_REFNO ");
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
			strSql.Append("select count(1) FROM BUY_REFNO ");
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
				strSql.Append("order by T.Code desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_REFNO T ");
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
			parameters[0].Value = "BUY_REFNO";
			parameters[1].Value = "Code";
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

