using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:DataModels
	/// </summary>
	public partial class DataModels:IDataModels
	{
		public DataModels()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("DataModelID", "DataModels"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DataModelID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DataModels");
			strSql.Append(" where DataModelID=@DataModelID");
			SqlParameter[] parameters = {
					new SqlParameter("@DataModelID", SqlDbType.Int,4)
};
			parameters[0].Value = DataModelID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.DataModels model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DataModels(");
			strSql.Append("Description,Definition,CreatedOn,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@Description,@Definition,@CreatedOn,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Description", SqlDbType.NText),
					new SqlParameter("@Definition", SqlDbType.NText),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.VarChar,30)};
			parameters[0].Value = model.Description;
			parameters[1].Value = model.Definition;
			parameters[2].Value = model.CreatedOn;
			parameters[3].Value = model.UpdatedOn;
			parameters[4].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.DataModels model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DataModels set ");
			strSql.Append("Description=@Description,");
			strSql.Append("Definition=@Definition,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where DataModelID=@DataModelID");
			SqlParameter[] parameters = {
					new SqlParameter("@Description", SqlDbType.NText),
					new SqlParameter("@Definition", SqlDbType.NText),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.VarChar,30),
					new SqlParameter("@DataModelID", SqlDbType.Int,4)};
			parameters[0].Value = model.Description;
			parameters[1].Value = model.Definition;
			parameters[2].Value = model.CreatedOn;
			parameters[3].Value = model.UpdatedOn;
			parameters[4].Value = model.UpdatedBy;
			parameters[5].Value = model.DataModelID;

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
		public bool Delete(int DataModelID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DataModels ");
			strSql.Append(" where DataModelID=@DataModelID");
			SqlParameter[] parameters = {
					new SqlParameter("@DataModelID", SqlDbType.Int,4)
};
			parameters[0].Value = DataModelID;

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
		public bool DeleteList(string DataModelIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DataModels ");
			strSql.Append(" where DataModelID in ("+DataModelIDlist + ")  ");
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
		public Edge.SVA.Model.DataModels GetModel(int DataModelID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DataModelID,Description,Definition,CreatedOn,UpdatedOn,UpdatedBy from DataModels ");
			strSql.Append(" where DataModelID=@DataModelID");
			SqlParameter[] parameters = {
					new SqlParameter("@DataModelID", SqlDbType.Int,4)
};
			parameters[0].Value = DataModelID;

			Edge.SVA.Model.DataModels model=new Edge.SVA.Model.DataModels();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["DataModelID"]!=null && ds.Tables[0].Rows[0]["DataModelID"].ToString()!="")
				{
					model.DataModelID=int.Parse(ds.Tables[0].Rows[0]["DataModelID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Description"]!=null && ds.Tables[0].Rows[0]["Description"].ToString()!="")
				{
					model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Definition"]!=null && ds.Tables[0].Rows[0]["Definition"].ToString()!="")
				{
					model.Definition=ds.Tables[0].Rows[0]["Definition"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CreatedOn"]!=null && ds.Tables[0].Rows[0]["CreatedOn"].ToString()!="")
				{
					model.CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedOn"]!=null && ds.Tables[0].Rows[0]["UpdatedOn"].ToString()!="")
				{
					model.UpdatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedBy"]!=null && ds.Tables[0].Rows[0]["UpdatedBy"].ToString()!="")
				{
					model.UpdatedBy=ds.Tables[0].Rows[0]["UpdatedBy"].ToString();
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
			strSql.Append("select DataModelID,Description,Definition,CreatedOn,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM DataModels ");
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
			strSql.Append(" DataModelID,Description,Definition,CreatedOn,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM DataModels ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@OrderfldName",SqlDbType.VarChar,255),
                    new SqlParameter("@StatfldName",SqlDbType.VarChar,255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.NText),
					};
			parameters[0].Value = "DataModels";
            parameters[1].Value = "*";
            parameters[2].Value = filedOrder;
            parameters[3].Value = "";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 0;
            parameters[7].Value = 0;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPageOrder", parameters, "ds");
        }

        /// <summary>
        /// 获取行总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select count(*) from DataModels ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }
		#endregion  Method
	}
}
