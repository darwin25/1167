using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:RelationRoleBrand
	/// </summary>
	public partial class RelationRoleBrand:IRelationRoleBrand
	{
		public RelationRoleBrand()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("RoleID", "RelationRoleBrand"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RoleID,int BrandID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from RelationRoleBrand");
			strSql.Append(" where RoleID=@RoleID and BrandID=@BrandID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@BrandID", SqlDbType.Int,4)};
			parameters[0].Value = RoleID;
			parameters[1].Value = BrandID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.RelationRoleBrand model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RelationRoleBrand(");
			strSql.Append("RoleID,BrandID)");
			strSql.Append(" values (");
			strSql.Append("@RoleID,@BrandID)");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@BrandID", SqlDbType.Int,4)};
			parameters[0].Value = model.RoleID;
			parameters[1].Value = model.BrandID;

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
		public bool Update(Edge.SVA.Model.RelationRoleBrand model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RelationRoleBrand set ");
 
			strSql.Append("RoleID=@RoleID,");
			strSql.Append("BrandID=@BrandID");
			strSql.Append(" where RoleID=@RoleID and BrandID=@BrandID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@BrandID", SqlDbType.Int,4)};
			parameters[0].Value = model.RoleID;
			parameters[1].Value = model.BrandID;

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
		public bool Delete(int RoleID,int BrandID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RelationRoleBrand ");
			strSql.Append(" where RoleID=@RoleID and BrandID=@BrandID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@BrandID", SqlDbType.Int,4)};
			parameters[0].Value = RoleID;
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
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.RelationRoleBrand GetModel(int RoleID,int BrandID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RoleID,BrandID from RelationRoleBrand ");
			strSql.Append(" where RoleID=@RoleID and BrandID=@BrandID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@BrandID", SqlDbType.Int,4)};
			parameters[0].Value = RoleID;
			parameters[1].Value = BrandID;

			Edge.SVA.Model.RelationRoleBrand model=new Edge.SVA.Model.RelationRoleBrand();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["RoleID"]!=null && ds.Tables[0].Rows[0]["RoleID"].ToString()!="")
				{
					model.RoleID=int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
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
			strSql.Append("select RoleID,BrandID ");
			strSql.Append(" FROM RelationRoleBrand ");
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
			strSql.Append(" RoleID,BrandID ");
			strSql.Append(" FROM RelationRoleBrand ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
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
			parameters[0].Value = "RelationRoleBrand";
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

