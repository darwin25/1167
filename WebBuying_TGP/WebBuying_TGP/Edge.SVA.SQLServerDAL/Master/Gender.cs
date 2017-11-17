using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Gender
	/// </summary>
	public partial class Gender:IGender
	{
		public Gender()
		{}
		#region Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("GenderID", "Gender"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int GenderID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Gender");
			strSql.Append(" where GenderID=@GenderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@GenderID", SqlDbType.Int,4)			};
			parameters[0].Value = GenderID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Gender model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Gender(");
			strSql.Append("GenderID,GenderCode,GenderDesc1,GenderDesc2,GenderDesc3)");
			strSql.Append(" values (");
			strSql.Append("@GenderID,@GenderCode,@GenderDesc1,@GenderDesc2,@GenderDesc3)");
			SqlParameter[] parameters = {
					new SqlParameter("@GenderID", SqlDbType.Int,4),
					new SqlParameter("@GenderCode", SqlDbType.VarChar,64),
					new SqlParameter("@GenderDesc1", SqlDbType.VarChar,64),
					new SqlParameter("@GenderDesc2", SqlDbType.VarChar,64),
					new SqlParameter("@GenderDesc3", SqlDbType.VarChar,64)};
			parameters[0].Value = model.GenderID;
			parameters[1].Value = model.GenderCode;
			parameters[2].Value = model.GenderDesc1;
			parameters[3].Value = model.GenderDesc2;
			parameters[4].Value = model.GenderDesc3;

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
		public bool Update(Edge.SVA.Model.Gender model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Gender set ");
			strSql.Append("GenderCode=@GenderCode,");
			strSql.Append("GenderDesc1=@GenderDesc1,");
			strSql.Append("GenderDesc2=@GenderDesc2,");
			strSql.Append("GenderDesc3=@GenderDesc3");
			strSql.Append(" where GenderID=@GenderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@GenderCode", SqlDbType.VarChar,64),
					new SqlParameter("@GenderDesc1", SqlDbType.VarChar,64),
					new SqlParameter("@GenderDesc2", SqlDbType.VarChar,64),
					new SqlParameter("@GenderDesc3", SqlDbType.VarChar,64),
					new SqlParameter("@GenderID", SqlDbType.Int,4)};
			parameters[0].Value = model.GenderCode;
			parameters[1].Value = model.GenderDesc1;
			parameters[2].Value = model.GenderDesc2;
			parameters[3].Value = model.GenderDesc3;
			parameters[4].Value = model.GenderID;

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
		public bool Delete(int GenderID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Gender ");
			strSql.Append(" where GenderID=@GenderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@GenderID", SqlDbType.Int,4)			};
			parameters[0].Value = GenderID;

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
		public bool DeleteList(string GenderIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Gender ");
			strSql.Append(" where GenderID in ("+GenderIDlist + ")  ");
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
		public Edge.SVA.Model.Gender GetModel(int GenderID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 GenderID,GenderCode,GenderDesc1,GenderDesc2,GenderDesc3 from Gender ");
			strSql.Append(" where GenderID=@GenderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@GenderID", SqlDbType.Int,4)			};
			parameters[0].Value = GenderID;

			Edge.SVA.Model.Gender model=new Edge.SVA.Model.Gender();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Gender DataRowToModel(DataRow row)
		{
			Edge.SVA.Model.Gender model=new Edge.SVA.Model.Gender();
			if (row != null)
			{
				if(row["GenderID"]!=null && row["GenderID"].ToString()!="")
				{
					model.GenderID=int.Parse(row["GenderID"].ToString());
				}
				if(row["GenderCode"]!=null)
				{
					model.GenderCode=row["GenderCode"].ToString();
				}
				if(row["GenderDesc1"]!=null)
				{
					model.GenderDesc1=row["GenderDesc1"].ToString();
				}
				if(row["GenderDesc2"]!=null)
				{
					model.GenderDesc2=row["GenderDesc2"].ToString();
				}
				if(row["GenderDesc3"]!=null)
				{
					model.GenderDesc3=row["GenderDesc3"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select GenderID,GenderCode,GenderDesc1,GenderDesc2,GenderDesc3 ");
			strSql.Append(" FROM Gender ");
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
			strSql.Append(" GenderID,GenderCode,GenderDesc1,GenderDesc2,GenderDesc3 ");
			strSql.Append(" FROM Gender ");
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
			strSql.Append("select count(1) FROM Gender ");
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
				strSql.Append("order by T.GenderID desc");
			}
			strSql.Append(")AS Row, T.*  from Gender T ");
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
			parameters[0].Value = "Gender";
			parameters[1].Value = "GenderID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod

	}
}

