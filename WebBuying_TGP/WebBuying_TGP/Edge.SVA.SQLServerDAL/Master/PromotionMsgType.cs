using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:PromotionMsgType
	/// </summary>
	public partial class PromotionMsgType:IPromotionMsgType
	{
		public PromotionMsgType()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PromotionMsgTypeID", "PromotionMsgType"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PromotionMsgTypeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PromotionMsgType");
			strSql.Append(" where PromotionMsgTypeID=@PromotionMsgTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionMsgTypeID", SqlDbType.Int,4)
			};
			parameters[0].Value = PromotionMsgTypeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.PromotionMsgType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PromotionMsgType(");
			strSql.Append("BrandID,PromotionMsgTypeName1,PromotionMsgTypeName2,PromotionMsgTypeName3,ParentID)");
			strSql.Append(" values (");
			strSql.Append("@BrandID,@PromotionMsgTypeName1,@PromotionMsgTypeName2,@PromotionMsgTypeName3,@ParentID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@PromotionMsgTypeName1", SqlDbType.NVarChar,512),
					new SqlParameter("@PromotionMsgTypeName2", SqlDbType.NVarChar,512),
					new SqlParameter("@PromotionMsgTypeName3", SqlDbType.NVarChar,512),
					new SqlParameter("@ParentID", SqlDbType.Int,4)};
			parameters[0].Value = model.BrandID;
			parameters[1].Value = model.PromotionMsgTypeName1;
			parameters[2].Value = model.PromotionMsgTypeName2;
			parameters[3].Value = model.PromotionMsgTypeName3;
			parameters[4].Value = model.ParentID;

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
		public bool Update(Edge.SVA.Model.PromotionMsgType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PromotionMsgType set ");
			strSql.Append("BrandID=@BrandID,");
			strSql.Append("PromotionMsgTypeName1=@PromotionMsgTypeName1,");
			strSql.Append("PromotionMsgTypeName2=@PromotionMsgTypeName2,");
			strSql.Append("PromotionMsgTypeName3=@PromotionMsgTypeName3,");
			strSql.Append("ParentID=@ParentID");
			strSql.Append(" where PromotionMsgTypeID=@PromotionMsgTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@PromotionMsgTypeName1", SqlDbType.NVarChar,512),
					new SqlParameter("@PromotionMsgTypeName2", SqlDbType.NVarChar,512),
					new SqlParameter("@PromotionMsgTypeName3", SqlDbType.NVarChar,512),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@PromotionMsgTypeID", SqlDbType.Int,4)};
			parameters[0].Value = model.BrandID;
			parameters[1].Value = model.PromotionMsgTypeName1;
			parameters[2].Value = model.PromotionMsgTypeName2;
			parameters[3].Value = model.PromotionMsgTypeName3;
			parameters[4].Value = model.ParentID;
			parameters[5].Value = model.PromotionMsgTypeID;

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
		public bool Delete(int PromotionMsgTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PromotionMsgType ");
			strSql.Append(" where PromotionMsgTypeID=@PromotionMsgTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionMsgTypeID", SqlDbType.Int,4)
			};
			parameters[0].Value = PromotionMsgTypeID;

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
		public bool DeleteList(string PromotionMsgTypeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PromotionMsgType ");
			strSql.Append(" where PromotionMsgTypeID in ("+PromotionMsgTypeIDlist + ")  ");
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
		public Edge.SVA.Model.PromotionMsgType GetModel(int PromotionMsgTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PromotionMsgTypeID,BrandID,PromotionMsgTypeName1,PromotionMsgTypeName2,PromotionMsgTypeName3,ParentID from PromotionMsgType ");
			strSql.Append(" where PromotionMsgTypeID=@PromotionMsgTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionMsgTypeID", SqlDbType.Int,4)
			};
			parameters[0].Value = PromotionMsgTypeID;

			Edge.SVA.Model.PromotionMsgType model=new Edge.SVA.Model.PromotionMsgType();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PromotionMsgTypeID"]!=null && ds.Tables[0].Rows[0]["PromotionMsgTypeID"].ToString()!="")
				{
					model.PromotionMsgTypeID=int.Parse(ds.Tables[0].Rows[0]["PromotionMsgTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BrandID"]!=null && ds.Tables[0].Rows[0]["BrandID"].ToString()!="")
				{
					model.BrandID=int.Parse(ds.Tables[0].Rows[0]["BrandID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PromotionMsgTypeName1"]!=null && ds.Tables[0].Rows[0]["PromotionMsgTypeName1"].ToString()!="")
				{
					model.PromotionMsgTypeName1=ds.Tables[0].Rows[0]["PromotionMsgTypeName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PromotionMsgTypeName2"]!=null && ds.Tables[0].Rows[0]["PromotionMsgTypeName2"].ToString()!="")
				{
					model.PromotionMsgTypeName2=ds.Tables[0].Rows[0]["PromotionMsgTypeName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PromotionMsgTypeName3"]!=null && ds.Tables[0].Rows[0]["PromotionMsgTypeName3"].ToString()!="")
				{
					model.PromotionMsgTypeName3=ds.Tables[0].Rows[0]["PromotionMsgTypeName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ParentID"]!=null && ds.Tables[0].Rows[0]["ParentID"].ToString()!="")
				{
					model.ParentID=int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
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
			strSql.Append("select PromotionMsgTypeID,BrandID,PromotionMsgTypeName1,PromotionMsgTypeName2,PromotionMsgTypeName3,ParentID ");
			strSql.Append(" FROM PromotionMsgType ");
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
			strSql.Append(" PromotionMsgTypeID,BrandID,PromotionMsgTypeName1,PromotionMsgTypeName2,PromotionMsgTypeName3,ParentID ");
			strSql.Append(" FROM PromotionMsgType ");
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
			strSql.Append("select count(1) FROM PromotionMsgType ");
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
				strSql.Append("order by T.PromotionMsgTypeID desc");
			}
			strSql.Append(")AS Row, T.*  from PromotionMsgType T ");
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
			parameters[0].Value = "PromotionMsgType";
			parameters[1].Value = "PromotionMsgTypeID";
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

