using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Edge.Security.Data
{
	/// <summary>
	/// 数据访问类:Lan_Accounts_PermissionCategories
	/// </summary>
	public partial class Lan_Accounts_PermissionCategories
	{
		public Lan_Accounts_PermissionCategories()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.Security.Model.Lan_Accounts_PermissionCategories model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Lan_Accounts_PermissionCategories(");
			strSql.Append("CategoryID,Description,Lan)");
			strSql.Append(" values (");
			strSql.Append("@CategoryID,@Description,@Lan)");
			SqlParameter[] parameters = {
					new SqlParameter("@CategoryID", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,255),
					new SqlParameter("@Lan", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.CategoryID;
			parameters[1].Value = model.Description;
			parameters[2].Value = model.Lan;

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
		public bool Update(Edge.Security.Model.Lan_Accounts_PermissionCategories model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Lan_Accounts_PermissionCategories set ");
			strSql.Append("Description=@Description ");
            strSql.Append(" where CategoryID=@CategoryID and Lan=@Lan ");
			SqlParameter[] parameters = {
					new SqlParameter("@CategoryID", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,255),
					new SqlParameter("@Lan", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.CategoryID;
			parameters[1].Value = model.Description;
			parameters[2].Value = model.Lan;

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
        public bool Delete(Edge.Security.Model.Lan_Accounts_PermissionCategories model)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Lan_Accounts_PermissionCategories ");
            strSql.Append(" where CategoryID=@CategoryID and Lan=@Lan and Description=@Description ");
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryID", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,255),
					new SqlParameter("@Lan", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.CategoryID;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.Lan;

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
		public Edge.Security.Model.Lan_Accounts_PermissionCategories GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CategoryID,Description,Lan from Lan_Accounts_PermissionCategories ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
};

			Edge.Security.Model.Lan_Accounts_PermissionCategories model=new Edge.Security.Model.Lan_Accounts_PermissionCategories();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CategoryID"]!=null && ds.Tables[0].Rows[0]["CategoryID"].ToString()!="")
				{
					model.CategoryID=int.Parse(ds.Tables[0].Rows[0]["CategoryID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Description"]!=null && ds.Tables[0].Rows[0]["Description"].ToString()!="")
				{
					model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Lan"]!=null && ds.Tables[0].Rows[0]["Lan"].ToString()!="")
				{
					model.Lan=ds.Tables[0].Rows[0]["Lan"].ToString();
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
			strSql.Append("select CategoryID,Description,Lan ");
			strSql.Append(" FROM Lan_Accounts_PermissionCategories ");
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
			strSql.Append(" CategoryID,Description,Lan ");
			strSql.Append(" FROM Lan_Accounts_PermissionCategories ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获取行总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select count(1) from Lan_Accounts_PermissionCategories ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

