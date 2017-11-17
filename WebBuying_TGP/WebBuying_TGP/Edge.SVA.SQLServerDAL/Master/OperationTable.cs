using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:OperationTable
	/// </summary>
	public partial class OperationTable:IOperationTable
	{
		public OperationTable()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("OprID", "OperationTable"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int OprID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OperationTable");
			strSql.Append(" where OprID=@OprID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OprID", SqlDbType.Int,4)			};
			parameters[0].Value = OprID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.OperationTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OperationTable(");
			strSql.Append("OprID,OprIDDesc1,OprIDDesc2,OprIDDesc3,Remark)");
			strSql.Append(" values (");
			strSql.Append("@OprID,@OprIDDesc1,@OprIDDesc2,@OprIDDesc3,@Remark)");
			SqlParameter[] parameters = {
					new SqlParameter("@OprID", SqlDbType.Int,4),
					new SqlParameter("@OprIDDesc1", SqlDbType.NVarChar,512),
					new SqlParameter("@OprIDDesc2", SqlDbType.NVarChar,512),
					new SqlParameter("@OprIDDesc3", SqlDbType.NVarChar,512),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.OprID;
			parameters[1].Value = model.OprIDDesc1;
			parameters[2].Value = model.OprIDDesc2;
			parameters[3].Value = model.OprIDDesc3;
			parameters[4].Value = model.Remark;

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
		public bool Update(Edge.SVA.Model.OperationTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OperationTable set ");
			strSql.Append("OprIDDesc1=@OprIDDesc1,");
			strSql.Append("OprIDDesc2=@OprIDDesc2,");
			strSql.Append("OprIDDesc3=@OprIDDesc3,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where OprID=@OprID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OprIDDesc1", SqlDbType.NVarChar,512),
					new SqlParameter("@OprIDDesc2", SqlDbType.NVarChar,512),
					new SqlParameter("@OprIDDesc3", SqlDbType.NVarChar,512),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@OprID", SqlDbType.Int,4)};
			parameters[0].Value = model.OprIDDesc1;
			parameters[1].Value = model.OprIDDesc2;
			parameters[2].Value = model.OprIDDesc3;
			parameters[3].Value = model.Remark;
			parameters[4].Value = model.OprID;

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
		public bool Delete(int OprID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OperationTable ");
			strSql.Append(" where OprID=@OprID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OprID", SqlDbType.Int,4)			};
			parameters[0].Value = OprID;

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
		public bool DeleteList(string OprIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OperationTable ");
			strSql.Append(" where OprID in ("+OprIDlist + ")  ");
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
		public Edge.SVA.Model.OperationTable GetModel(int OprID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 OprID,OprIDDesc1,OprIDDesc2,OprIDDesc3,Remark from OperationTable ");
			strSql.Append(" where OprID=@OprID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OprID", SqlDbType.Int,4)			};
			parameters[0].Value = OprID;

			Edge.SVA.Model.OperationTable model=new Edge.SVA.Model.OperationTable();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["OprID"]!=null && ds.Tables[0].Rows[0]["OprID"].ToString()!="")
				{
					model.OprID=int.Parse(ds.Tables[0].Rows[0]["OprID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OprIDDesc1"]!=null && ds.Tables[0].Rows[0]["OprIDDesc1"].ToString()!="")
				{
					model.OprIDDesc1=ds.Tables[0].Rows[0]["OprIDDesc1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OprIDDesc2"]!=null && ds.Tables[0].Rows[0]["OprIDDesc2"].ToString()!="")
				{
					model.OprIDDesc2=ds.Tables[0].Rows[0]["OprIDDesc2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OprIDDesc3"]!=null && ds.Tables[0].Rows[0]["OprIDDesc3"].ToString()!="")
				{
					model.OprIDDesc3=ds.Tables[0].Rows[0]["OprIDDesc3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Remark"]!=null && ds.Tables[0].Rows[0]["Remark"].ToString()!="")
				{
					model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
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
			strSql.Append("select OprID,OprIDDesc1,OprIDDesc2,OprIDDesc3,Remark ");
			strSql.Append(" FROM OperationTable ");
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
			strSql.Append(" OprID,OprIDDesc1,OprIDDesc2,OprIDDesc3,Remark ");
			strSql.Append(" FROM OperationTable ");
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
			strSql.Append("select count(1) FROM OperationTable ");
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
				strSql.Append("order by T.OprID desc");
			}
			strSql.Append(")AS Row, T.*  from OperationTable T ");
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
			parameters[0].Value = "OperationTable";
			parameters[1].Value = "OprID";
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

