using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_PRODUCTPACKAGE_Pending
    /// 创建人：Lisa
    /// 创建时间：2016-08-08
	/// </summary>
	public partial class BUY_PRODUCTPACKAGE_Pending:IBUY_PRODUCTPACKAGE_Pending
	{
		public BUY_PRODUCTPACKAGE_Pending()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PackageSizeID", "BUY_PRODUCTPACKAGE_Pending"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PackageSizeCode,int PackageSizeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_PRODUCTPACKAGE_Pending");
			strSql.Append(" where PackageSizeCode=@PackageSizeCode and PackageSizeID=@PackageSizeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PackageSizeCode", SqlDbType.VarChar,64),
					new SqlParameter("@PackageSizeID", SqlDbType.Int,4)			};
			parameters[0].Value = PackageSizeCode;
			parameters[1].Value = PackageSizeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.BUY_PRODUCTPACKAGE_Pending model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_PRODUCTPACKAGE_Pending(");
			strSql.Append("PackageSizeCode,PackageSizeDesc1,PackageSizeDesc2,PackageSizeDesc3,PackageSizeType,PackageSizeUnit,PackageSizeQty)");
			strSql.Append(" values (");
			strSql.Append("@PackageSizeCode,@PackageSizeDesc1,@PackageSizeDesc2,@PackageSizeDesc3,@PackageSizeType,@PackageSizeUnit,@PackageSizeQty)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PackageSizeCode", SqlDbType.VarChar,64),
					new SqlParameter("@PackageSizeDesc1", SqlDbType.VarChar,512),
					new SqlParameter("@PackageSizeDesc2", SqlDbType.VarChar,512),
					new SqlParameter("@PackageSizeDesc3", SqlDbType.VarChar,512),
					new SqlParameter("@PackageSizeType", SqlDbType.Int,4),
					new SqlParameter("@PackageSizeUnit", SqlDbType.VarChar,64),
					new SqlParameter("@PackageSizeQty", SqlDbType.Int,4)};
			parameters[0].Value = model.PackageSizeCode;
			parameters[1].Value = model.PackageSizeDesc1;
			parameters[2].Value = model.PackageSizeDesc2;
			parameters[3].Value = model.PackageSizeDesc3;
			parameters[4].Value = model.PackageSizeType;
			parameters[5].Value = model.PackageSizeUnit;
			parameters[6].Value = model.PackageSizeQty;

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
		public bool Update(Edge.SVA.Model.BUY_PRODUCTPACKAGE_Pending model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_PRODUCTPACKAGE_Pending set ");
			strSql.Append("PackageSizeDesc1=@PackageSizeDesc1,");
			strSql.Append("PackageSizeDesc2=@PackageSizeDesc2,");
			strSql.Append("PackageSizeDesc3=@PackageSizeDesc3,");
			strSql.Append("PackageSizeType=@PackageSizeType,");
			strSql.Append("PackageSizeUnit=@PackageSizeUnit,");
			strSql.Append("PackageSizeQty=@PackageSizeQty");
			strSql.Append(" where PackageSizeID=@PackageSizeID");
			SqlParameter[] parameters = {
					new SqlParameter("@PackageSizeDesc1", SqlDbType.VarChar,512),
					new SqlParameter("@PackageSizeDesc2", SqlDbType.VarChar,512),
					new SqlParameter("@PackageSizeDesc3", SqlDbType.VarChar,512),
					new SqlParameter("@PackageSizeType", SqlDbType.Int,4),
					new SqlParameter("@PackageSizeUnit", SqlDbType.VarChar,64),
					new SqlParameter("@PackageSizeQty", SqlDbType.Int,4),
					new SqlParameter("@PackageSizeID", SqlDbType.Int,4),
					new SqlParameter("@PackageSizeCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.PackageSizeDesc1;
			parameters[1].Value = model.PackageSizeDesc2;
			parameters[2].Value = model.PackageSizeDesc3;
			parameters[3].Value = model.PackageSizeType;
			parameters[4].Value = model.PackageSizeUnit;
			parameters[5].Value = model.PackageSizeQty;
			parameters[6].Value = model.PackageSizeID;
			parameters[7].Value = model.PackageSizeCode;

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
		public bool Delete(int PackageSizeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_PRODUCTPACKAGE_Pending ");
			strSql.Append(" where PackageSizeID=@PackageSizeID");
			SqlParameter[] parameters = {
					new SqlParameter("@PackageSizeID", SqlDbType.Int,4)
			};
			parameters[0].Value = PackageSizeID;

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
		public bool Delete(string PackageSizeCode,int PackageSizeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_PRODUCTPACKAGE_Pending ");
			strSql.Append(" where PackageSizeCode=@PackageSizeCode and PackageSizeID=@PackageSizeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PackageSizeCode", SqlDbType.VarChar,64),
					new SqlParameter("@PackageSizeID", SqlDbType.Int,4)			};
			parameters[0].Value = PackageSizeCode;
			parameters[1].Value = PackageSizeID;

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
		public bool DeleteList(string PackageSizeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_PRODUCTPACKAGE_Pending ");
			strSql.Append(" where PackageSizeID in ("+PackageSizeIDlist + ")  ");
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
		public Edge.SVA.Model.BUY_PRODUCTPACKAGE_Pending GetModel(int PackageSizeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PackageSizeID,PackageSizeCode,PackageSizeDesc1,PackageSizeDesc2,PackageSizeDesc3,PackageSizeType,PackageSizeUnit,PackageSizeQty from BUY_PRODUCTPACKAGE_Pending ");
			strSql.Append(" where PackageSizeID=@PackageSizeID");
			SqlParameter[] parameters = {
					new SqlParameter("@PackageSizeID", SqlDbType.Int,4)
			};
			parameters[0].Value = PackageSizeID;

			Edge.SVA.Model.BUY_PRODUCTPACKAGE_Pending model=new Edge.SVA.Model.BUY_PRODUCTPACKAGE_Pending();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PackageSizeID"]!=null && ds.Tables[0].Rows[0]["PackageSizeID"].ToString()!="")
				{
					model.PackageSizeID=int.Parse(ds.Tables[0].Rows[0]["PackageSizeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PackageSizeCode"]!=null && ds.Tables[0].Rows[0]["PackageSizeCode"].ToString()!="")
				{
					model.PackageSizeCode=ds.Tables[0].Rows[0]["PackageSizeCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PackageSizeDesc1"]!=null && ds.Tables[0].Rows[0]["PackageSizeDesc1"].ToString()!="")
				{
					model.PackageSizeDesc1=ds.Tables[0].Rows[0]["PackageSizeDesc1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PackageSizeDesc2"]!=null && ds.Tables[0].Rows[0]["PackageSizeDesc2"].ToString()!="")
				{
					model.PackageSizeDesc2=ds.Tables[0].Rows[0]["PackageSizeDesc2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PackageSizeDesc3"]!=null && ds.Tables[0].Rows[0]["PackageSizeDesc3"].ToString()!="")
				{
					model.PackageSizeDesc3=ds.Tables[0].Rows[0]["PackageSizeDesc3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PackageSizeType"]!=null && ds.Tables[0].Rows[0]["PackageSizeType"].ToString()!="")
				{
					model.PackageSizeType=int.Parse(ds.Tables[0].Rows[0]["PackageSizeType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PackageSizeUnit"]!=null && ds.Tables[0].Rows[0]["PackageSizeUnit"].ToString()!="")
				{
					model.PackageSizeUnit=ds.Tables[0].Rows[0]["PackageSizeUnit"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PackageSizeQty"]!=null && ds.Tables[0].Rows[0]["PackageSizeQty"].ToString()!="")
				{
					model.PackageSizeQty=int.Parse(ds.Tables[0].Rows[0]["PackageSizeQty"].ToString());
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
			strSql.Append("select PackageSizeID,PackageSizeCode,PackageSizeDesc1,PackageSizeDesc2,PackageSizeDesc3,PackageSizeType,PackageSizeUnit,PackageSizeQty ");
			strSql.Append(" FROM BUY_PRODUCTPACKAGE_Pending ");
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
			strSql.Append(" PackageSizeID,PackageSizeCode,PackageSizeDesc1,PackageSizeDesc2,PackageSizeDesc3,PackageSizeType,PackageSizeUnit,PackageSizeQty ");
			strSql.Append(" FROM BUY_PRODUCTPACKAGE_Pending ");
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
			strSql.Append("select count(1) FROM BUY_PRODUCTPACKAGE_Pending ");
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
				strSql.Append("order by T.PackageSizeID desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_PRODUCTPACKAGE_Pending T ");
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
			parameters[0].Value = "BUY_PRODUCTPACKAGE_Pending";
			parameters[1].Value = "PackageSizeID";
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

