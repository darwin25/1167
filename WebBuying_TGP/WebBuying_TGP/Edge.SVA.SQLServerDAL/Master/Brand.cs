using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Brand
    ///创建人:Lisa
    ///创建时间：2016-08-10
	/// </summary>
    public partial class Brand : IBrand
	{
        public Brand()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("StoreBrandID", "Brand"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string StoreBrandCode,int StoreBrandID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Brand");
			strSql.Append(" where StoreBrandCode=@StoreBrandCode and StoreBrandID=@StoreBrandID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreBrandCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreBrandID", SqlDbType.Int,4)			};
			parameters[0].Value = StoreBrandCode;
			parameters[1].Value = StoreBrandID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(Edge.SVA.Model.Brand model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Brand(");
			strSql.Append("StoreBrandCode,StoreBrandName1,StoreBrandName2,StoreBrandName3,StoreBrandDesc1,StoreBrandDesc2,StoreBrandDesc3,StoreBrandPicSFile,StoreBrandPicMFile,StoreBrandPicGFile,CardIssuerID,IndustryID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@StoreBrandCode,@StoreBrandName1,@StoreBrandName2,@StoreBrandName3,@StoreBrandDesc1,@StoreBrandDesc2,@StoreBrandDesc3,@StoreBrandPicSFile,@StoreBrandPicMFile,@StoreBrandPicGFile,@CardIssuerID,@IndustryID,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreBrandCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreBrandName1", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreBrandName2", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreBrandName3", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreBrandDesc1", SqlDbType.NVarChar,-1),
					new SqlParameter("@StoreBrandDesc2", SqlDbType.NVarChar,-1),
					new SqlParameter("@StoreBrandDesc3", SqlDbType.NVarChar,-1),
					new SqlParameter("@StoreBrandPicSFile", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreBrandPicMFile", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreBrandPicGFile", SqlDbType.NVarChar,512),
					new SqlParameter("@CardIssuerID", SqlDbType.Int,4),
					new SqlParameter("@IndustryID", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.StoreBrandCode;
			parameters[1].Value = model.StoreBrandName1;
			parameters[2].Value = model.StoreBrandName2;
			parameters[3].Value = model.StoreBrandName3;
			parameters[4].Value = model.StoreBrandDesc1;
			parameters[5].Value = model.StoreBrandDesc2;
			parameters[6].Value = model.StoreBrandDesc3;
			parameters[7].Value = model.StoreBrandPicSFile;
			parameters[8].Value = model.StoreBrandPicMFile;
			parameters[9].Value = model.StoreBrandPicGFile;
			parameters[10].Value = model.CardIssuerID;
			parameters[11].Value = model.IndustryID;
			parameters[12].Value = model.CreatedOn;
			parameters[13].Value = model.CreatedBy;
			parameters[14].Value = model.UpdatedOn;
			parameters[15].Value = model.UpdatedBy;

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
        public bool Update(Edge.SVA.Model.Brand model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Brand set ");
			strSql.Append("StoreBrandName1=@StoreBrandName1,");
			strSql.Append("StoreBrandName2=@StoreBrandName2,");
			strSql.Append("StoreBrandName3=@StoreBrandName3,");
			strSql.Append("StoreBrandDesc1=@StoreBrandDesc1,");
			strSql.Append("StoreBrandDesc2=@StoreBrandDesc2,");
			strSql.Append("StoreBrandDesc3=@StoreBrandDesc3,");
			strSql.Append("StoreBrandPicSFile=@StoreBrandPicSFile,");
			strSql.Append("StoreBrandPicMFile=@StoreBrandPicMFile,");
			strSql.Append("StoreBrandPicGFile=@StoreBrandPicGFile,");
			strSql.Append("CardIssuerID=@CardIssuerID,");
			strSql.Append("IndustryID=@IndustryID,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where StoreBrandID=@StoreBrandID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreBrandName1", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreBrandName2", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreBrandName3", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreBrandDesc1", SqlDbType.NVarChar,-1),
					new SqlParameter("@StoreBrandDesc2", SqlDbType.NVarChar,-1),
					new SqlParameter("@StoreBrandDesc3", SqlDbType.NVarChar,-1),
					new SqlParameter("@StoreBrandPicSFile", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreBrandPicMFile", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreBrandPicGFile", SqlDbType.NVarChar,512),
					new SqlParameter("@CardIssuerID", SqlDbType.Int,4),
					new SqlParameter("@IndustryID", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@StoreBrandID", SqlDbType.Int,4),
					new SqlParameter("@StoreBrandCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.StoreBrandName1;
			parameters[1].Value = model.StoreBrandName2;
			parameters[2].Value = model.StoreBrandName3;
			parameters[3].Value = model.StoreBrandDesc1;
			parameters[4].Value = model.StoreBrandDesc2;
			parameters[5].Value = model.StoreBrandDesc3;
			parameters[6].Value = model.StoreBrandPicSFile;
			parameters[7].Value = model.StoreBrandPicMFile;
			parameters[8].Value = model.StoreBrandPicGFile;
			parameters[9].Value = model.CardIssuerID;
			parameters[10].Value = model.IndustryID;
			parameters[11].Value = model.CreatedOn;
			parameters[12].Value = model.CreatedBy;
			parameters[13].Value = model.UpdatedOn;
			parameters[14].Value = model.UpdatedBy;
			parameters[15].Value = model.StoreBrandID;
			parameters[16].Value = model.StoreBrandCode;

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
		public bool Delete(int StoreBrandID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Brand ");
			strSql.Append(" where StoreBrandID=@StoreBrandID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreBrandID", SqlDbType.Int,4)
			};
			parameters[0].Value = StoreBrandID;

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
		public bool Delete(string StoreBrandCode,int StoreBrandID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Brand ");
			strSql.Append(" where StoreBrandCode=@StoreBrandCode and StoreBrandID=@StoreBrandID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreBrandCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreBrandID", SqlDbType.Int,4)			};
			parameters[0].Value = StoreBrandCode;
			parameters[1].Value = StoreBrandID;

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
		public bool DeleteList(string StoreBrandIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Brand ");
			strSql.Append(" where StoreBrandID in ("+StoreBrandIDlist + ")  ");
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
        public Edge.SVA.Model.Brand GetModel(int StoreBrandID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StoreBrandID,StoreBrandCode,StoreBrandName1,StoreBrandName2,StoreBrandName3,StoreBrandDesc1,StoreBrandDesc2,StoreBrandDesc3,StoreBrandPicSFile,StoreBrandPicMFile,StoreBrandPicGFile,CardIssuerID,IndustryID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from Brand ");
			strSql.Append(" where StoreBrandID=@StoreBrandID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreBrandID", SqlDbType.Int,4)
			};
			parameters[0].Value = StoreBrandID;

            Edge.SVA.Model.Brand model = new Edge.SVA.Model.Brand();
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
        public Edge.SVA.Model.Brand DataRowToModel(DataRow row)
		{
            Edge.SVA.Model.Brand model = new Edge.SVA.Model.Brand();
			if (row != null)
			{
				if(row["StoreBrandID"]!=null && row["StoreBrandID"].ToString()!="")
				{
					model.StoreBrandID=int.Parse(row["StoreBrandID"].ToString());
				}
				if(row["StoreBrandCode"]!=null)
				{
					model.StoreBrandCode=row["StoreBrandCode"].ToString();
				}
				if(row["StoreBrandName1"]!=null)
				{
					model.StoreBrandName1=row["StoreBrandName1"].ToString();
				}
				if(row["StoreBrandName2"]!=null)
				{
					model.StoreBrandName2=row["StoreBrandName2"].ToString();
				}
				if(row["StoreBrandName3"]!=null)
				{
					model.StoreBrandName3=row["StoreBrandName3"].ToString();
				}
				if(row["StoreBrandDesc1"]!=null)
				{
					model.StoreBrandDesc1=row["StoreBrandDesc1"].ToString();
				}
				if(row["StoreBrandDesc2"]!=null)
				{
					model.StoreBrandDesc2=row["StoreBrandDesc2"].ToString();
				}
				if(row["StoreBrandDesc3"]!=null)
				{
					model.StoreBrandDesc3=row["StoreBrandDesc3"].ToString();
				}
				if(row["StoreBrandPicSFile"]!=null)
				{
					model.StoreBrandPicSFile=row["StoreBrandPicSFile"].ToString();
				}
				if(row["StoreBrandPicMFile"]!=null)
				{
					model.StoreBrandPicMFile=row["StoreBrandPicMFile"].ToString();
				}
				if(row["StoreBrandPicGFile"]!=null)
				{
					model.StoreBrandPicGFile=row["StoreBrandPicGFile"].ToString();
				}
				if(row["CardIssuerID"]!=null && row["CardIssuerID"].ToString()!="")
				{
					model.CardIssuerID=int.Parse(row["CardIssuerID"].ToString());
				}
				if(row["IndustryID"]!=null && row["IndustryID"].ToString()!="")
				{
					model.IndustryID=int.Parse(row["IndustryID"].ToString());
				}
				if(row["CreatedOn"]!=null && row["CreatedOn"].ToString()!="")
				{
					model.CreatedOn=DateTime.Parse(row["CreatedOn"].ToString());
				}
				if(row["CreatedBy"]!=null && row["CreatedBy"].ToString()!="")
				{
					model.CreatedBy=int.Parse(row["CreatedBy"].ToString());
				}
				if(row["UpdatedOn"]!=null && row["UpdatedOn"].ToString()!="")
				{
					model.UpdatedOn=DateTime.Parse(row["UpdatedOn"].ToString());
				}
				if(row["UpdatedBy"]!=null && row["UpdatedBy"].ToString()!="")
				{
					model.UpdatedBy=int.Parse(row["UpdatedBy"].ToString());
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
			strSql.Append("select StoreBrandID,StoreBrandCode,StoreBrandName1,StoreBrandName2,StoreBrandName3,StoreBrandDesc1,StoreBrandDesc2,StoreBrandDesc3,StoreBrandPicSFile,StoreBrandPicMFile,StoreBrandPicGFile,CardIssuerID,IndustryID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM Brand ");
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
			strSql.Append(" StoreBrandID,StoreBrandCode,StoreBrandName1,StoreBrandName2,StoreBrandName3,StoreBrandDesc1,StoreBrandDesc2,StoreBrandDesc3,StoreBrandPicSFile,StoreBrandPicMFile,StoreBrandPicGFile,CardIssuerID,IndustryID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM Brand ");
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
			strSql.Append("select count(1) FROM Brand ");
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
				strSql.Append("order by T.StoreBrandID desc");
			}
			strSql.Append(")AS Row, T.*  from Brand T ");
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
			parameters[0].Value = "Brand";
			parameters[1].Value = "StoreBrandID";
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

