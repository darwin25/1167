using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:MATERIAL_IN
    /// 创建人:Lisa
    /// 创建时间：2016-02-25
	/// </summary>
	public partial class MATERIAL_IN:IMATERIAL_IN
	{
		public MATERIAL_IN()
		{}
		#region  Method
		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MATERIALID", "MATERIAL_IN"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MATERIALID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MATERIAL_IN");
			strSql.Append(" where MATERIALID=@MATERIALID");
			SqlParameter[] parameters = {
					new SqlParameter("@MATERIALID", SqlDbType.Int,4)
			};
			parameters[0].Value = MATERIALID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.MATERIAL_IN model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MATERIAL_IN(");
			strSql.Append("MATERIALCode,MATERIALName1,MATERIALName2,MATERIALName3)");
			strSql.Append(" values (");
			strSql.Append("@MATERIALCode,@MATERIALName1,@MATERIALName2,@MATERIALName3)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MATERIALCode", SqlDbType.VarChar,64),
					new SqlParameter("@MATERIALName1", SqlDbType.VarChar,512),
					new SqlParameter("@MATERIALName2", SqlDbType.VarChar,512),
					new SqlParameter("@MATERIALName3", SqlDbType.VarChar,512)};
			parameters[0].Value = model.MATERIALCode;
			parameters[1].Value = model.MATERIALName1;
			parameters[2].Value = model.MATERIALName2;
			parameters[3].Value = model.MATERIALName3;

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
		public bool Update(Edge.SVA.Model.MATERIAL_IN model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MATERIAL_IN set ");
			strSql.Append("MATERIALCode=@MATERIALCode,");
			strSql.Append("MATERIALName1=@MATERIALName1,");
			strSql.Append("MATERIALName2=@MATERIALName2,");
			strSql.Append("MATERIALName3=@MATERIALName3");
			strSql.Append(" where MATERIALID=@MATERIALID");
			SqlParameter[] parameters = {
					new SqlParameter("@MATERIALCode", SqlDbType.VarChar,64),
					new SqlParameter("@MATERIALName1", SqlDbType.VarChar,512),
					new SqlParameter("@MATERIALName2", SqlDbType.VarChar,512),
					new SqlParameter("@MATERIALName3", SqlDbType.VarChar,512),
					new SqlParameter("@MATERIALID", SqlDbType.Int,4)};
			parameters[0].Value = model.MATERIALCode;
			parameters[1].Value = model.MATERIALName1;
			parameters[2].Value = model.MATERIALName2;
			parameters[3].Value = model.MATERIALName3;
			parameters[4].Value = model.MATERIALID;

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
		public bool Delete(int MATERIALID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MATERIAL_IN ");
			strSql.Append(" where MATERIALID=@MATERIALID");
			SqlParameter[] parameters = {
					new SqlParameter("@MATERIALID", SqlDbType.Int,4)
			};
			parameters[0].Value = MATERIALID;

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
		public bool DeleteList(string MATERIALIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MATERIAL_IN ");
			strSql.Append(" where MATERIALID in ("+MATERIALIDlist + ")  ");
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
		public Edge.SVA.Model.MATERIAL_IN GetModel(int MATERIALID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MATERIALID,MATERIALCode,MATERIALName1,MATERIALName2,MATERIALName3 from MATERIAL_IN ");
			strSql.Append(" where MATERIALID=@MATERIALID");
			SqlParameter[] parameters = {
					new SqlParameter("@MATERIALID", SqlDbType.Int,4)
			};
			parameters[0].Value = MATERIALID;

			Edge.SVA.Model.MATERIAL_IN model=new Edge.SVA.Model.MATERIAL_IN();
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
		public Edge.SVA.Model.MATERIAL_IN DataRowToModel(DataRow row)
		{
			Edge.SVA.Model.MATERIAL_IN model=new Edge.SVA.Model.MATERIAL_IN();
			if (row != null)
			{
				if(row["MATERIALID"]!=null && row["MATERIALID"].ToString()!="")
				{
					model.MATERIALID=int.Parse(row["MATERIALID"].ToString());
				}
				if(row["MATERIALCode"]!=null)
				{
					model.MATERIALCode=row["MATERIALCode"].ToString();
				}
				if(row["MATERIALName1"]!=null)
				{
					model.MATERIALName1=row["MATERIALName1"].ToString();
				}
				if(row["MATERIALName2"]!=null)
				{
					model.MATERIALName2=row["MATERIALName2"].ToString();
				}
				if(row["MATERIALName3"]!=null)
				{
					model.MATERIALName3=row["MATERIALName3"].ToString();
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
			strSql.Append("select MATERIALID,MATERIALCode,MATERIALName1,MATERIALName2,MATERIALName3 ");
			strSql.Append(" FROM MATERIAL_IN ");
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
			strSql.Append(" MATERIALID,MATERIALCode,MATERIALName1,MATERIALName2,MATERIALName3 ");
			strSql.Append(" FROM MATERIAL_IN ");
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
			strSql.Append("select count(1) FROM MATERIAL_IN ");
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
				strSql.Append("order by T.MATERIALID desc");
			}
			strSql.Append(")AS Row, T.*  from MATERIAL_IN T ");
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
			parameters[0].Value = "MATERIAL_IN";
			parameters[1].Value = "MATERIALID";
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

