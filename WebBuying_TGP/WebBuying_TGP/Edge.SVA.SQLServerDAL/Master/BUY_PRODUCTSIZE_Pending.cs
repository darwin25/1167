using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_PRODUCTSIZE_Pending
    /// 创建人：Lisa
    /// 创建时间：2016-08-08
	/// </summary>
	public partial class BUY_PRODUCTSIZE_Pending:IBUY_PRODUCTSIZE_Pending
	{
		public BUY_PRODUCTSIZE_Pending()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ProductSizeID", "BUY_PRODUCTSIZE_Pending"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ProductSizeCode,int ProductSizeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_PRODUCTSIZE_Pending");
			strSql.Append(" where ProductSizeCode=@ProductSizeCode and ProductSizeID=@ProductSizeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductSizeCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProductSizeID", SqlDbType.Int,4)			};
			parameters[0].Value = ProductSizeCode;
			parameters[1].Value = ProductSizeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.BUY_PRODUCTSIZE_Pending model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_PRODUCTSIZE_Pending(");
			strSql.Append("ProductSizeCode,ProductSizeType,ProductSizeName1,ProductSizeName2,ProductSizeName3,ProductSizeNote)");
			strSql.Append(" values (");
			strSql.Append("@ProductSizeCode,@ProductSizeType,@ProductSizeName1,@ProductSizeName2,@ProductSizeName3,@ProductSizeNote)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductSizeCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProductSizeType", SqlDbType.VarChar,64),
					new SqlParameter("@ProductSizeName1", SqlDbType.NVarChar,512),
					new SqlParameter("@ProductSizeName2", SqlDbType.NVarChar,512),
					new SqlParameter("@ProductSizeName3", SqlDbType.NVarChar,512),
					new SqlParameter("@ProductSizeNote", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.ProductSizeCode;
			parameters[1].Value = model.ProductSizeType;
			parameters[2].Value = model.ProductSizeName1;
			parameters[3].Value = model.ProductSizeName2;
			parameters[4].Value = model.ProductSizeName3;
			parameters[5].Value = model.ProductSizeNote;

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
		public bool Update(Edge.SVA.Model.BUY_PRODUCTSIZE_Pending model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_PRODUCTSIZE_Pending set ");
			strSql.Append("ProductSizeType=@ProductSizeType,");
			strSql.Append("ProductSizeName1=@ProductSizeName1,");
			strSql.Append("ProductSizeName2=@ProductSizeName2,");
			strSql.Append("ProductSizeName3=@ProductSizeName3,");
			strSql.Append("ProductSizeNote=@ProductSizeNote");
			strSql.Append(" where ProductSizeID=@ProductSizeID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductSizeType", SqlDbType.VarChar,64),
					new SqlParameter("@ProductSizeName1", SqlDbType.NVarChar,512),
					new SqlParameter("@ProductSizeName2", SqlDbType.NVarChar,512),
					new SqlParameter("@ProductSizeName3", SqlDbType.NVarChar,512),
					new SqlParameter("@ProductSizeNote", SqlDbType.NVarChar,512),
					new SqlParameter("@ProductSizeID", SqlDbType.Int,4),
					new SqlParameter("@ProductSizeCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.ProductSizeType;
			parameters[1].Value = model.ProductSizeName1;
			parameters[2].Value = model.ProductSizeName2;
			parameters[3].Value = model.ProductSizeName3;
			parameters[4].Value = model.ProductSizeNote;
			parameters[5].Value = model.ProductSizeID;
			parameters[6].Value = model.ProductSizeCode;

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
		public bool Delete(int ProductSizeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_PRODUCTSIZE_Pending ");
			strSql.Append(" where ProductSizeID=@ProductSizeID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductSizeID", SqlDbType.Int,4)
			};
			parameters[0].Value = ProductSizeID;

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
		public bool Delete(string ProductSizeCode,int ProductSizeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_PRODUCTSIZE_Pending ");
			strSql.Append(" where ProductSizeCode=@ProductSizeCode and ProductSizeID=@ProductSizeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductSizeCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProductSizeID", SqlDbType.Int,4)			};
			parameters[0].Value = ProductSizeCode;
			parameters[1].Value = ProductSizeID;

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
		public bool DeleteList(string ProductSizeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_PRODUCTSIZE_Pending ");
			strSql.Append(" where ProductSizeID in ("+ProductSizeIDlist + ")  ");
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
		public Edge.SVA.Model.BUY_PRODUCTSIZE_Pending GetModel(int ProductSizeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProductSizeID,ProductSizeCode,ProductSizeType,ProductSizeName1,ProductSizeName2,ProductSizeName3,ProductSizeNote from BUY_PRODUCTSIZE_Pending ");
			strSql.Append(" where ProductSizeID=@ProductSizeID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductSizeID", SqlDbType.Int,4)
			};
			parameters[0].Value = ProductSizeID;

			Edge.SVA.Model.BUY_PRODUCTSIZE_Pending model=new Edge.SVA.Model.BUY_PRODUCTSIZE_Pending();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProductSizeID"]!=null && ds.Tables[0].Rows[0]["ProductSizeID"].ToString()!="")
				{
					model.ProductSizeID=int.Parse(ds.Tables[0].Rows[0]["ProductSizeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProductSizeCode"]!=null && ds.Tables[0].Rows[0]["ProductSizeCode"].ToString()!="")
				{
					model.ProductSizeCode=ds.Tables[0].Rows[0]["ProductSizeCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProductSizeType"]!=null && ds.Tables[0].Rows[0]["ProductSizeType"].ToString()!="")
				{
					model.ProductSizeType=ds.Tables[0].Rows[0]["ProductSizeType"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProductSizeName1"]!=null && ds.Tables[0].Rows[0]["ProductSizeName1"].ToString()!="")
				{
					model.ProductSizeName1=ds.Tables[0].Rows[0]["ProductSizeName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProductSizeName2"]!=null && ds.Tables[0].Rows[0]["ProductSizeName2"].ToString()!="")
				{
					model.ProductSizeName2=ds.Tables[0].Rows[0]["ProductSizeName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProductSizeName3"]!=null && ds.Tables[0].Rows[0]["ProductSizeName3"].ToString()!="")
				{
					model.ProductSizeName3=ds.Tables[0].Rows[0]["ProductSizeName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProductSizeNote"]!=null && ds.Tables[0].Rows[0]["ProductSizeNote"].ToString()!="")
				{
					model.ProductSizeNote=ds.Tables[0].Rows[0]["ProductSizeNote"].ToString();
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
			strSql.Append("select ProductSizeID,ProductSizeCode,ProductSizeType,ProductSizeName1,ProductSizeName2,ProductSizeName3,ProductSizeNote ");
			strSql.Append(" FROM BUY_PRODUCTSIZE_Pending ");
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
			strSql.Append(" ProductSizeID,ProductSizeCode,ProductSizeType,ProductSizeName1,ProductSizeName2,ProductSizeName3,ProductSizeNote ");
			strSql.Append(" FROM BUY_PRODUCTSIZE_Pending ");
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
			strSql.Append("select count(1) FROM BUY_PRODUCTSIZE_Pending ");
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
				strSql.Append("order by T.ProductSizeID desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_PRODUCTSIZE_Pending T ");
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
			parameters[0].Value = "BUY_PRODUCTSIZE_Pending";
			parameters[1].Value = "ProductSizeID";
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

