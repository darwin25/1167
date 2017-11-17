using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_PRODUCTCLASS_Pending
    /// 创建人：Lisa
    /// 创建时间：2016-08-08
	/// </summary>
	public partial class BUY_PRODUCTCLASS_Pending:IBUY_PRODUCTCLASS_Pending
	{
		public BUY_PRODUCTCLASS_Pending()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ProdClassID", "BUY_PRODUCTCLASS_Pending"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ProdClassCode,int ProdClassID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_PRODUCTCLASS_Pending");
			strSql.Append(" where ProdClassCode=@ProdClassCode and ProdClassID=@ProdClassID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdClassCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdClassID", SqlDbType.Int,4)			};
			parameters[0].Value = ProdClassCode;
			parameters[1].Value = ProdClassID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.BUY_PRODUCTCLASS_Pending model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_PRODUCTCLASS_Pending(");
			strSql.Append("ProdClassCode,ParentID,ProductSizeType,ProdClassDesc1,ProdClassDesc2,ProdClassDesc3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@ProdClassCode,@ParentID,@ProductSizeType,@ProdClassDesc1,@ProdClassDesc2,@ProdClassDesc3,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdClassCode", SqlDbType.VarChar,64),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@ProductSizeType", SqlDbType.VarChar,64),
					new SqlParameter("@ProdClassDesc1", SqlDbType.VarChar,100),
					new SqlParameter("@ProdClassDesc2", SqlDbType.VarChar,100),
					new SqlParameter("@ProdClassDesc3", SqlDbType.VarChar,100),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.ProdClassCode;
			parameters[1].Value = model.ParentID;
			parameters[2].Value = model.ProductSizeType;
			parameters[3].Value = model.ProdClassDesc1;
			parameters[4].Value = model.ProdClassDesc2;
			parameters[5].Value = model.ProdClassDesc3;
			parameters[6].Value = model.CreatedOn;
			parameters[7].Value = model.CreatedBy;
			parameters[8].Value = model.UpdatedOn;
			parameters[9].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.BUY_PRODUCTCLASS_Pending model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_PRODUCTCLASS_Pending set ");
			strSql.Append("ParentID=@ParentID,");
			strSql.Append("ProductSizeType=@ProductSizeType,");
			strSql.Append("ProdClassDesc1=@ProdClassDesc1,");
			strSql.Append("ProdClassDesc2=@ProdClassDesc2,");
			strSql.Append("ProdClassDesc3=@ProdClassDesc3,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where ProdClassID=@ProdClassID");
			SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@ProductSizeType", SqlDbType.VarChar,64),
					new SqlParameter("@ProdClassDesc1", SqlDbType.VarChar,100),
					new SqlParameter("@ProdClassDesc2", SqlDbType.VarChar,100),
					new SqlParameter("@ProdClassDesc3", SqlDbType.VarChar,100),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@ProdClassID", SqlDbType.Int,4),
					new SqlParameter("@ProdClassCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.ParentID;
			parameters[1].Value = model.ProductSizeType;
			parameters[2].Value = model.ProdClassDesc1;
			parameters[3].Value = model.ProdClassDesc2;
			parameters[4].Value = model.ProdClassDesc3;
			parameters[5].Value = model.CreatedOn;
			parameters[6].Value = model.CreatedBy;
			parameters[7].Value = model.UpdatedOn;
			parameters[8].Value = model.UpdatedBy;
			parameters[9].Value = model.ProdClassID;
			parameters[10].Value = model.ProdClassCode;

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
		public bool Delete(int ProdClassID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_PRODUCTCLASS_Pending ");
			strSql.Append(" where ProdClassID=@ProdClassID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdClassID", SqlDbType.Int,4)
			};
			parameters[0].Value = ProdClassID;

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
		public bool Delete(string ProdClassCode,int ProdClassID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_PRODUCTCLASS_Pending ");
			strSql.Append(" where ProdClassCode=@ProdClassCode and ProdClassID=@ProdClassID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdClassCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdClassID", SqlDbType.Int,4)			};
			parameters[0].Value = ProdClassCode;
			parameters[1].Value = ProdClassID;

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
		public bool DeleteList(string ProdClassIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_PRODUCTCLASS_Pending ");
			strSql.Append(" where ProdClassID in ("+ProdClassIDlist + ")  ");
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
		public Edge.SVA.Model.BUY_PRODUCTCLASS_Pending GetModel(int ProdClassID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProdClassID,ProdClassCode,ParentID,ProductSizeType,ProdClassDesc1,ProdClassDesc2,ProdClassDesc3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_PRODUCTCLASS_Pending ");
			strSql.Append(" where ProdClassID=@ProdClassID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdClassID", SqlDbType.Int,4)
			};
			parameters[0].Value = ProdClassID;

			Edge.SVA.Model.BUY_PRODUCTCLASS_Pending model=new Edge.SVA.Model.BUY_PRODUCTCLASS_Pending();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProdClassID"]!=null && ds.Tables[0].Rows[0]["ProdClassID"].ToString()!="")
				{
					model.ProdClassID=int.Parse(ds.Tables[0].Rows[0]["ProdClassID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProdClassCode"]!=null && ds.Tables[0].Rows[0]["ProdClassCode"].ToString()!="")
				{
					model.ProdClassCode=ds.Tables[0].Rows[0]["ProdClassCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ParentID"]!=null && ds.Tables[0].Rows[0]["ParentID"].ToString()!="")
				{
					model.ParentID=int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProductSizeType"]!=null && ds.Tables[0].Rows[0]["ProductSizeType"].ToString()!="")
				{
					model.ProductSizeType=ds.Tables[0].Rows[0]["ProductSizeType"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProdClassDesc1"]!=null && ds.Tables[0].Rows[0]["ProdClassDesc1"].ToString()!="")
				{
					model.ProdClassDesc1=ds.Tables[0].Rows[0]["ProdClassDesc1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProdClassDesc2"]!=null && ds.Tables[0].Rows[0]["ProdClassDesc2"].ToString()!="")
				{
					model.ProdClassDesc2=ds.Tables[0].Rows[0]["ProdClassDesc2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProdClassDesc3"]!=null && ds.Tables[0].Rows[0]["ProdClassDesc3"].ToString()!="")
				{
					model.ProdClassDesc3=ds.Tables[0].Rows[0]["ProdClassDesc3"].ToString();
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
			strSql.Append("select ProdClassID,ProdClassCode,ParentID,ProductSizeType,ProdClassDesc1,ProdClassDesc2,ProdClassDesc3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_PRODUCTCLASS_Pending ");
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
			strSql.Append(" ProdClassID,ProdClassCode,ParentID,ProductSizeType,ProdClassDesc1,ProdClassDesc2,ProdClassDesc3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_PRODUCTCLASS_Pending ");
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
			strSql.Append("select count(1) FROM BUY_PRODUCTCLASS_Pending ");
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
				strSql.Append("order by T.ProdClassID desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_PRODUCTCLASS_Pending T ");
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
			parameters[0].Value = "BUY_PRODUCTCLASS_Pending";
			parameters[1].Value = "ProdClassID";
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

