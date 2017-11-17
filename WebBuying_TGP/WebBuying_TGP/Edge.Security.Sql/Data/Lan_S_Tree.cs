using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Edge.Security.Data
{
	/// <summary>
	/// 数据访问类:Lan_S_Tree
	/// </summary>
	public partial class Lan_S_Tree
	{
		public Lan_S_Tree()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.Security.Model.Lan_S_Tree model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Lan_S_Tree(");
			strSql.Append("NodeID,Text,Lan)");
			strSql.Append(" values (");
			strSql.Append("@NodeID,@Text,@Lan)");
			SqlParameter[] parameters = {
					new SqlParameter("@NodeID", SqlDbType.Int,4),
					new SqlParameter("@Text", SqlDbType.NVarChar,255),
					new SqlParameter("@Lan", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.NodeID;
			parameters[1].Value = model.Text;
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
		public bool Update(Edge.Security.Model.Lan_S_Tree model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Lan_S_Tree set ");
			strSql.Append("Text=@Text ");
            strSql.Append(" where NodeID=@NodeID and Lan=@Lan ");
			SqlParameter[] parameters = {
					new SqlParameter("@NodeID", SqlDbType.Int,4),
					new SqlParameter("@Text", SqlDbType.NVarChar,255),
					new SqlParameter("@Lan", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.NodeID;
			parameters[1].Value = model.Text;
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
        public bool Delete(Edge.Security.Model.Lan_S_Tree model)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Lan_S_Tree ");
            strSql.Append(" where NodeID=@NodeID and Lan=@Lan and Text=@Text ");
            SqlParameter[] parameters = {
					new SqlParameter("@NodeID", SqlDbType.Int,4),
					new SqlParameter("@Text", SqlDbType.NVarChar,255),
					new SqlParameter("@Lan", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.NodeID;
            parameters[1].Value = model.Text;
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
		public Edge.Security.Model.Lan_S_Tree GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 NodeID,Text,Lan from Lan_S_Tree ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
};

			Edge.Security.Model.Lan_S_Tree model=new Edge.Security.Model.Lan_S_Tree();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["NodeID"]!=null && ds.Tables[0].Rows[0]["NodeID"].ToString()!="")
				{
					model.NodeID=int.Parse(ds.Tables[0].Rows[0]["NodeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Text"]!=null && ds.Tables[0].Rows[0]["Text"].ToString()!="")
				{
					model.Text=ds.Tables[0].Rows[0]["Text"].ToString();
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
			strSql.Append("select NodeID,Text,Lan ");
			strSql.Append(" FROM Lan_S_Tree ");
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
			strSql.Append(" NodeID,Text,Lan ");
			strSql.Append(" FROM Lan_S_Tree ");
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
            sql.Append("select count(1) from Lan_S_Tree ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

