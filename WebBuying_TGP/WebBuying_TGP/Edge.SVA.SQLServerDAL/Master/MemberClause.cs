using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:MemberClause
	/// </summary>
	public partial class MemberClause:IMemberClause
	{
		public MemberClause()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MemberClauseID", "MemberClause"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MemberClauseID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MemberClause");
			strSql.Append(" where MemberClauseID=@MemberClauseID");
			SqlParameter[] parameters = {
					new SqlParameter("@MemberClauseID", SqlDbType.Int,4)
			};
			parameters[0].Value = MemberClauseID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.MemberClause model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MemberClause(");
			strSql.Append("ClauseTypeCode,ClauseSubCode,ClauseName,MemberClauseDesc1,MemberClauseDesc2,MemberClauseDesc3,BrandID)");
			strSql.Append(" values (");
			strSql.Append("@ClauseTypeCode,@ClauseSubCode,@ClauseName,@MemberClauseDesc1,@MemberClauseDesc2,@MemberClauseDesc3,@BrandID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ClauseTypeCode", SqlDbType.VarChar,512),
					new SqlParameter("@ClauseSubCode", SqlDbType.VarChar,512),
					new SqlParameter("@ClauseName", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberClauseDesc1", SqlDbType.NVarChar),
					new SqlParameter("@MemberClauseDesc2", SqlDbType.NVarChar),
					new SqlParameter("@MemberClauseDesc3", SqlDbType.NVarChar),
					new SqlParameter("@BrandID", SqlDbType.Int,4)};
			parameters[0].Value = model.ClauseTypeCode;
			parameters[1].Value = model.ClauseSubCode;
			parameters[2].Value = model.ClauseName;
			parameters[3].Value = model.MemberClauseDesc1;
			parameters[4].Value = model.MemberClauseDesc2;
			parameters[5].Value = model.MemberClauseDesc3;
			parameters[6].Value = model.BrandID;

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
		public bool Update(Edge.SVA.Model.MemberClause model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MemberClause set ");
			strSql.Append("ClauseTypeCode=@ClauseTypeCode,");
			strSql.Append("ClauseSubCode=@ClauseSubCode,");
			strSql.Append("ClauseName=@ClauseName,");
			strSql.Append("MemberClauseDesc1=@MemberClauseDesc1,");
			strSql.Append("MemberClauseDesc2=@MemberClauseDesc2,");
			strSql.Append("MemberClauseDesc3=@MemberClauseDesc3,");
			strSql.Append("BrandID=@BrandID");
			strSql.Append(" where MemberClauseID=@MemberClauseID");
			SqlParameter[] parameters = {
					new SqlParameter("@ClauseTypeCode", SqlDbType.VarChar,512),
					new SqlParameter("@ClauseSubCode", SqlDbType.VarChar,512),
					new SqlParameter("@ClauseName", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberClauseDesc1", SqlDbType.NVarChar),
					new SqlParameter("@MemberClauseDesc2", SqlDbType.NVarChar),
					new SqlParameter("@MemberClauseDesc3", SqlDbType.NVarChar),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@MemberClauseID", SqlDbType.Int,4)};
			parameters[0].Value = model.ClauseTypeCode;
			parameters[1].Value = model.ClauseSubCode;
			parameters[2].Value = model.ClauseName;
			parameters[3].Value = model.MemberClauseDesc1;
			parameters[4].Value = model.MemberClauseDesc2;
			parameters[5].Value = model.MemberClauseDesc3;
			parameters[6].Value = model.BrandID;
			parameters[7].Value = model.MemberClauseID;

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
		public bool Delete(int MemberClauseID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MemberClause ");
			strSql.Append(" where MemberClauseID=@MemberClauseID");
			SqlParameter[] parameters = {
					new SqlParameter("@MemberClauseID", SqlDbType.Int,4)
			};
			parameters[0].Value = MemberClauseID;

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
		public bool DeleteList(string MemberClauseIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MemberClause ");
			strSql.Append(" where MemberClauseID in ("+MemberClauseIDlist + ")  ");
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
		public Edge.SVA.Model.MemberClause GetModel(int MemberClauseID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MemberClauseID,ClauseTypeCode,ClauseSubCode,ClauseName,MemberClauseDesc1,MemberClauseDesc2,MemberClauseDesc3,BrandID from MemberClause ");
			strSql.Append(" where MemberClauseID=@MemberClauseID");
			SqlParameter[] parameters = {
					new SqlParameter("@MemberClauseID", SqlDbType.Int,4)
			};
			parameters[0].Value = MemberClauseID;

			Edge.SVA.Model.MemberClause model=new Edge.SVA.Model.MemberClause();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["MemberClauseID"]!=null && ds.Tables[0].Rows[0]["MemberClauseID"].ToString()!="")
				{
					model.MemberClauseID=int.Parse(ds.Tables[0].Rows[0]["MemberClauseID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ClauseTypeCode"]!=null && ds.Tables[0].Rows[0]["ClauseTypeCode"].ToString()!="")
				{
					model.ClauseTypeCode=ds.Tables[0].Rows[0]["ClauseTypeCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ClauseSubCode"]!=null && ds.Tables[0].Rows[0]["ClauseSubCode"].ToString()!="")
				{
					model.ClauseSubCode=ds.Tables[0].Rows[0]["ClauseSubCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ClauseName"]!=null && ds.Tables[0].Rows[0]["ClauseName"].ToString()!="")
				{
					model.ClauseName=ds.Tables[0].Rows[0]["ClauseName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemberClauseDesc1"]!=null && ds.Tables[0].Rows[0]["MemberClauseDesc1"].ToString()!="")
				{
					model.MemberClauseDesc1=ds.Tables[0].Rows[0]["MemberClauseDesc1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemberClauseDesc2"]!=null && ds.Tables[0].Rows[0]["MemberClauseDesc2"].ToString()!="")
				{
					model.MemberClauseDesc2=ds.Tables[0].Rows[0]["MemberClauseDesc2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemberClauseDesc3"]!=null && ds.Tables[0].Rows[0]["MemberClauseDesc3"].ToString()!="")
				{
					model.MemberClauseDesc3=ds.Tables[0].Rows[0]["MemberClauseDesc3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BrandID"]!=null && ds.Tables[0].Rows[0]["BrandID"].ToString()!="")
				{
					model.BrandID=int.Parse(ds.Tables[0].Rows[0]["BrandID"].ToString());
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
			strSql.Append("select MemberClauseID,ClauseTypeCode,ClauseSubCode,ClauseName,MemberClauseDesc1,MemberClauseDesc2,MemberClauseDesc3,BrandID ");
			strSql.Append(" FROM MemberClause ");
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
			strSql.Append(" MemberClauseID,ClauseTypeCode,ClauseSubCode,ClauseName,MemberClauseDesc1,MemberClauseDesc2,MemberClauseDesc3,BrandID ");
			strSql.Append(" FROM MemberClause ");
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
			strSql.Append("select count(1) FROM MemberClause ");
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
				strSql.Append("order by T.MemberClauseID desc");
			}
			strSql.Append(")AS Row, T.*  from MemberClause T ");
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
			parameters[0].Value = "MemberClause";
			parameters[1].Value = "MemberClauseID";
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

