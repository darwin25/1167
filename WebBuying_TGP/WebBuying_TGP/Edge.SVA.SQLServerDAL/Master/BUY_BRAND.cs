using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_BRAND
	/// </summary>
	public partial class BUY_BRAND:IBUY_BRAND
	{
		public BUY_BRAND()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("BrandID", "BUY_BRAND"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string BrandCode,int BrandID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_BRAND");
			strSql.Append(" where BrandCode=@BrandCode and BrandID=@BrandID ");
			SqlParameter[] parameters = {
					new SqlParameter("@BrandCode", SqlDbType.VarChar,64),
					new SqlParameter("@BrandID", SqlDbType.Int,4)			};
			parameters[0].Value = BrandCode;
			parameters[1].Value = BrandID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.BUY_BRAND model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_BRAND(");
			strSql.Append("BrandCode,BrandName1,BrandName2,BrandName3,BrandDesc1,BrandDesc2,BrandDesc3,BrandPicSFile,BrandPicMFile,BrandPicGFile,CardIssuerID,IndustryID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@BrandCode,@BrandName1,@BrandName2,@BrandName3,@BrandDesc1,@BrandDesc2,@BrandDesc3,@BrandPicSFile,@BrandPicMFile,@BrandPicGFile,@CardIssuerID,@IndustryID,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BrandCode", SqlDbType.VarChar,64),
					new SqlParameter("@BrandName1", SqlDbType.NVarChar,512),
					new SqlParameter("@BrandName2", SqlDbType.NVarChar,512),
					new SqlParameter("@BrandName3", SqlDbType.NVarChar,512),
					new SqlParameter("@BrandDesc1", SqlDbType.NVarChar),
					new SqlParameter("@BrandDesc2", SqlDbType.NVarChar),
					new SqlParameter("@BrandDesc3", SqlDbType.NVarChar),
					new SqlParameter("@BrandPicSFile", SqlDbType.NVarChar,512),
					new SqlParameter("@BrandPicMFile", SqlDbType.NVarChar,512),
					new SqlParameter("@BrandPicGFile", SqlDbType.NVarChar,512),
					new SqlParameter("@CardIssuerID", SqlDbType.Int,4),
					new SqlParameter("@IndustryID", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.BrandCode;
			parameters[1].Value = model.BrandName1;
			parameters[2].Value = model.BrandName2;
			parameters[3].Value = model.BrandName3;
			parameters[4].Value = model.BrandDesc1;
			parameters[5].Value = model.BrandDesc2;
			parameters[6].Value = model.BrandDesc3;
			parameters[7].Value = model.BrandPicSFile;
			parameters[8].Value = model.BrandPicMFile;
			parameters[9].Value = model.BrandPicGFile;
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
		public bool Update(Edge.SVA.Model.BUY_BRAND model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_BRAND set ");
			strSql.Append("BrandName1=@BrandName1,");
			strSql.Append("BrandName2=@BrandName2,");
			strSql.Append("BrandName3=@BrandName3,");
			strSql.Append("BrandDesc1=@BrandDesc1,");
			strSql.Append("BrandDesc2=@BrandDesc2,");
			strSql.Append("BrandDesc3=@BrandDesc3,");
			strSql.Append("BrandPicSFile=@BrandPicSFile,");
			strSql.Append("BrandPicMFile=@BrandPicMFile,");
			strSql.Append("BrandPicGFile=@BrandPicGFile,");
			strSql.Append("CardIssuerID=@CardIssuerID,");
			strSql.Append("IndustryID=@IndustryID,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where BrandID=@BrandID");
			SqlParameter[] parameters = {
					new SqlParameter("@BrandName1", SqlDbType.NVarChar,512),
					new SqlParameter("@BrandName2", SqlDbType.NVarChar,512),
					new SqlParameter("@BrandName3", SqlDbType.NVarChar,512),
					new SqlParameter("@BrandDesc1", SqlDbType.NVarChar),
					new SqlParameter("@BrandDesc2", SqlDbType.NVarChar),
					new SqlParameter("@BrandDesc3", SqlDbType.NVarChar),
					new SqlParameter("@BrandPicSFile", SqlDbType.NVarChar,512),
					new SqlParameter("@BrandPicMFile", SqlDbType.NVarChar,512),
					new SqlParameter("@BrandPicGFile", SqlDbType.NVarChar,512),
					new SqlParameter("@CardIssuerID", SqlDbType.Int,4),
					new SqlParameter("@IndustryID", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@BrandCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.BrandName1;
			parameters[1].Value = model.BrandName2;
			parameters[2].Value = model.BrandName3;
			parameters[3].Value = model.BrandDesc1;
			parameters[4].Value = model.BrandDesc2;
			parameters[5].Value = model.BrandDesc3;
			parameters[6].Value = model.BrandPicSFile;
			parameters[7].Value = model.BrandPicMFile;
			parameters[8].Value = model.BrandPicGFile;
			parameters[9].Value = model.CardIssuerID;
			parameters[10].Value = model.IndustryID;
			parameters[11].Value = model.CreatedOn;
			parameters[12].Value = model.CreatedBy;
			parameters[13].Value = model.UpdatedOn;
			parameters[14].Value = model.UpdatedBy;
			parameters[15].Value = model.BrandID;
			parameters[16].Value = model.BrandCode;

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
		public bool Delete(int BrandID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_BRAND ");
			strSql.Append(" where BrandID=@BrandID");
			SqlParameter[] parameters = {
					new SqlParameter("@BrandID", SqlDbType.Int,4)
			};
			parameters[0].Value = BrandID;

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
		public bool Delete(string BrandCode,int BrandID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_BRAND ");
			strSql.Append(" where BrandCode=@BrandCode and BrandID=@BrandID ");
			SqlParameter[] parameters = {
					new SqlParameter("@BrandCode", SqlDbType.VarChar,64),
					new SqlParameter("@BrandID", SqlDbType.Int,4)			};
			parameters[0].Value = BrandCode;
			parameters[1].Value = BrandID;

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
		public bool DeleteList(string BrandIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_BRAND ");
			strSql.Append(" where BrandID in ("+BrandIDlist + ")  ");
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
		public Edge.SVA.Model.BUY_BRAND GetModel(int BrandID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 BrandID,BrandCode,BrandName1,BrandName2,BrandName3,BrandDesc1,BrandDesc2,BrandDesc3,BrandPicSFile,BrandPicMFile,BrandPicGFile,CardIssuerID,IndustryID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_BRAND ");
			strSql.Append(" where BrandID=@BrandID");
			SqlParameter[] parameters = {
					new SqlParameter("@BrandID", SqlDbType.Int,4)
			};
			parameters[0].Value = BrandID;

			Edge.SVA.Model.BUY_BRAND model=new Edge.SVA.Model.BUY_BRAND();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["BrandID"]!=null && ds.Tables[0].Rows[0]["BrandID"].ToString()!="")
				{
					model.BrandID=int.Parse(ds.Tables[0].Rows[0]["BrandID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BrandCode"]!=null && ds.Tables[0].Rows[0]["BrandCode"].ToString()!="")
				{
					model.BrandCode=ds.Tables[0].Rows[0]["BrandCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BrandName1"]!=null && ds.Tables[0].Rows[0]["BrandName1"].ToString()!="")
				{
					model.BrandName1=ds.Tables[0].Rows[0]["BrandName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BrandName2"]!=null && ds.Tables[0].Rows[0]["BrandName2"].ToString()!="")
				{
					model.BrandName2=ds.Tables[0].Rows[0]["BrandName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BrandName3"]!=null && ds.Tables[0].Rows[0]["BrandName3"].ToString()!="")
				{
					model.BrandName3=ds.Tables[0].Rows[0]["BrandName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BrandDesc1"]!=null && ds.Tables[0].Rows[0]["BrandDesc1"].ToString()!="")
				{
					model.BrandDesc1=ds.Tables[0].Rows[0]["BrandDesc1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BrandDesc2"]!=null && ds.Tables[0].Rows[0]["BrandDesc2"].ToString()!="")
				{
					model.BrandDesc2=ds.Tables[0].Rows[0]["BrandDesc2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BrandDesc3"]!=null && ds.Tables[0].Rows[0]["BrandDesc3"].ToString()!="")
				{
					model.BrandDesc3=ds.Tables[0].Rows[0]["BrandDesc3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BrandPicSFile"]!=null && ds.Tables[0].Rows[0]["BrandPicSFile"].ToString()!="")
				{
					model.BrandPicSFile=ds.Tables[0].Rows[0]["BrandPicSFile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BrandPicMFile"]!=null && ds.Tables[0].Rows[0]["BrandPicMFile"].ToString()!="")
				{
					model.BrandPicMFile=ds.Tables[0].Rows[0]["BrandPicMFile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BrandPicGFile"]!=null && ds.Tables[0].Rows[0]["BrandPicGFile"].ToString()!="")
				{
					model.BrandPicGFile=ds.Tables[0].Rows[0]["BrandPicGFile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CardIssuerID"]!=null && ds.Tables[0].Rows[0]["CardIssuerID"].ToString()!="")
				{
					model.CardIssuerID=int.Parse(ds.Tables[0].Rows[0]["CardIssuerID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IndustryID"]!=null && ds.Tables[0].Rows[0]["IndustryID"].ToString()!="")
				{
					model.IndustryID=int.Parse(ds.Tables[0].Rows[0]["IndustryID"].ToString());
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
			strSql.Append("select BrandID,BrandCode,BrandName1,BrandName2,BrandName3,BrandDesc1,BrandDesc2,BrandDesc3,BrandPicSFile,BrandPicMFile,BrandPicGFile,CardIssuerID,IndustryID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_BRAND ");
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
			strSql.Append(" BrandID,BrandCode,BrandName1,BrandName2,BrandName3,BrandDesc1,BrandDesc2,BrandDesc3,BrandPicSFile,BrandPicMFile,BrandPicGFile,CardIssuerID,IndustryID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_BRAND ");
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
			strSql.Append("select count(1) FROM BUY_BRAND ");
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
				strSql.Append("order by T.BrandID desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_BRAND T ");
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
			parameters[0].Value = "BUY_BRAND";
			parameters[1].Value = "BrandID";
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

