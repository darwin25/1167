using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Department
	/// </summary>
	public partial class Department:IDepartment
	{
		public Department()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string DepartCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Department");
			strSql.Append(" where DepartCode=@DepartCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = DepartCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Department model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Department(");
			strSql.Append("DepartCode,BrandID,DepartName1,DepartName2,DepartName3,DepartPicFile,DepartNote,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,DepartPicFile2,DepartPicFile3)");
			strSql.Append(" values (");
			strSql.Append("@DepartCode,@BrandID,@DepartName1,@DepartName2,@DepartName3,@DepartPicFile,@DepartNote,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@DepartPicFile2,@DepartPicFile3)");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartCode", SqlDbType.VarChar,64),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@DepartName1", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartName2", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartName3", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartPicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartNote", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@DepartPicFile2", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartPicFile3", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.DepartCode;
			parameters[1].Value = model.BrandID;
			parameters[2].Value = model.DepartName1;
			parameters[3].Value = model.DepartName2;
			parameters[4].Value = model.DepartName3;
			parameters[5].Value = model.DepartPicFile;
			parameters[6].Value = model.DepartNote;
			parameters[7].Value = model.CreatedOn;
			parameters[8].Value = model.CreatedBy;
			parameters[9].Value = model.UpdatedOn;
			parameters[10].Value = model.UpdatedBy;
			parameters[11].Value = model.DepartPicFile2;
			parameters[12].Value = model.DepartPicFile3;

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
		public bool Update(Edge.SVA.Model.Department model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Department set ");
			strSql.Append("BrandID=@BrandID,");
			strSql.Append("DepartName1=@DepartName1,");
			strSql.Append("DepartName2=@DepartName2,");
			strSql.Append("DepartName3=@DepartName3,");
			strSql.Append("DepartPicFile=@DepartPicFile,");
			strSql.Append("DepartNote=@DepartNote,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("DepartPicFile2=@DepartPicFile2,");
			strSql.Append("DepartPicFile3=@DepartPicFile3");
			strSql.Append(" where DepartCode=@DepartCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@DepartName1", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartName2", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartName3", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartPicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartNote", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@DepartPicFile2", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartPicFile3", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.BrandID;
			parameters[1].Value = model.DepartName1;
			parameters[2].Value = model.DepartName2;
			parameters[3].Value = model.DepartName3;
			parameters[4].Value = model.DepartPicFile;
			parameters[5].Value = model.DepartNote;
			parameters[6].Value = model.CreatedOn;
			parameters[7].Value = model.CreatedBy;
			parameters[8].Value = model.UpdatedOn;
			parameters[9].Value = model.UpdatedBy;
			parameters[10].Value = model.DepartPicFile2;
			parameters[11].Value = model.DepartPicFile3;
			parameters[12].Value = model.DepartCode;

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
		public bool Delete(string DepartCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Department ");
			strSql.Append(" where DepartCode=@DepartCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = DepartCode;

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
		public bool DeleteList(string DepartCodelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Department ");
			strSql.Append(" where DepartCode in ("+DepartCodelist + ")  ");
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
		public Edge.SVA.Model.Department GetModel(string DepartCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DepartCode,BrandID,DepartName1,DepartName2,DepartName3,DepartPicFile,DepartNote,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,DepartPicFile2,DepartPicFile3 from Department ");
			strSql.Append(" where DepartCode=@DepartCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = DepartCode;

			Edge.SVA.Model.Department model=new Edge.SVA.Model.Department();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["DepartCode"]!=null && ds.Tables[0].Rows[0]["DepartCode"].ToString()!="")
				{
					model.DepartCode=ds.Tables[0].Rows[0]["DepartCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BrandID"]!=null && ds.Tables[0].Rows[0]["BrandID"].ToString()!="")
				{
					model.BrandID=int.Parse(ds.Tables[0].Rows[0]["BrandID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DepartName1"]!=null && ds.Tables[0].Rows[0]["DepartName1"].ToString()!="")
				{
					model.DepartName1=ds.Tables[0].Rows[0]["DepartName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DepartName2"]!=null && ds.Tables[0].Rows[0]["DepartName2"].ToString()!="")
				{
					model.DepartName2=ds.Tables[0].Rows[0]["DepartName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DepartName3"]!=null && ds.Tables[0].Rows[0]["DepartName3"].ToString()!="")
				{
					model.DepartName3=ds.Tables[0].Rows[0]["DepartName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DepartPicFile"]!=null && ds.Tables[0].Rows[0]["DepartPicFile"].ToString()!="")
				{
					model.DepartPicFile=ds.Tables[0].Rows[0]["DepartPicFile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DepartNote"]!=null && ds.Tables[0].Rows[0]["DepartNote"].ToString()!="")
				{
					model.DepartNote=ds.Tables[0].Rows[0]["DepartNote"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CreatedOn"]!=null && ds.Tables[0].Rows[0]["CreatedOn"].ToString()!="")
				{
					model.CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedBy"]!=null && ds.Tables[0].Rows[0]["CreatedBy"].ToString()!="")
				{
					model.CreatedBy=int.Parse(ds.Tables[0].Rows[0]["CreatedBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedOn"]!=null && ds.Tables[0].Rows[0]["UpdatedOn"].ToString()!="")
				{
					model.UpdatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedBy"]!=null && ds.Tables[0].Rows[0]["UpdatedBy"].ToString()!="")
				{
					model.UpdatedBy=int.Parse(ds.Tables[0].Rows[0]["UpdatedBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DepartPicFile2"]!=null && ds.Tables[0].Rows[0]["DepartPicFile2"].ToString()!="")
				{
					model.DepartPicFile2=ds.Tables[0].Rows[0]["DepartPicFile2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DepartPicFile3"]!=null && ds.Tables[0].Rows[0]["DepartPicFile3"].ToString()!="")
				{
					model.DepartPicFile3=ds.Tables[0].Rows[0]["DepartPicFile3"].ToString();
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
			strSql.Append("select DepartCode,BrandID,DepartName1,DepartName2,DepartName3,DepartPicFile,DepartNote,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,DepartPicFile2,DepartPicFile3 ");
			strSql.Append(" FROM Department ");
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
			strSql.Append(" DepartCode,BrandID,DepartName1,DepartName2,DepartName3,DepartPicFile,DepartNote,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,DepartPicFile2,DepartPicFile3 ");
			strSql.Append(" FROM Department ");
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
			strSql.Append("select count(1) FROM Department ");
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
				strSql.Append("order by T.DepartCode desc");
			}
			strSql.Append(")AS Row, T.*  from Department T ");
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
			parameters[0].Value = "Department";
			parameters[1].Value = "DepartCode";
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

