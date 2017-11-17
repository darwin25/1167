using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Profession
	/// </summary>
	public partial class Profession:IProfession
	{
		public Profession()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ProfessionID", "Profession"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ProfessionID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Profession");
			strSql.Append(" where ProfessionID=@ProfessionID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProfessionID", SqlDbType.Int,4)
};
			parameters[0].Value = ProfessionID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.Profession model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Profession(");
			strSql.Append("ProfessionName1,ProfessionName2,ProfessionName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,ProfessionCode)");
			strSql.Append(" values (");
			strSql.Append("@ProfessionName1,@ProfessionName2,@ProfessionName3,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@ProfessionCode)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProfessionName1", SqlDbType.NVarChar,512),
					new SqlParameter("@ProfessionName2", SqlDbType.NVarChar,512),
					new SqlParameter("@ProfessionName3", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@ProfessionCode", SqlDbType.VarChar,512)};
			parameters[0].Value = model.ProfessionName1;
			parameters[1].Value = model.ProfessionName2;
			parameters[2].Value = model.ProfessionName3;
			parameters[3].Value = model.CreatedOn;
			parameters[4].Value = model.CreatedBy;
			parameters[5].Value = model.UpdatedOn;
			parameters[6].Value = model.UpdatedBy;
			parameters[7].Value = model.ProfessionCode;

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
		public bool Update(Edge.SVA.Model.Profession model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Profession set ");
			strSql.Append("ProfessionName1=@ProfessionName1,");
			strSql.Append("ProfessionName2=@ProfessionName2,");
			strSql.Append("ProfessionName3=@ProfessionName3,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("ProfessionCode=@ProfessionCode");
			strSql.Append(" where ProfessionID=@ProfessionID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProfessionName1", SqlDbType.NVarChar,512),
					new SqlParameter("@ProfessionName2", SqlDbType.NVarChar,512),
					new SqlParameter("@ProfessionName3", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@ProfessionCode", SqlDbType.VarChar,512),
					new SqlParameter("@ProfessionID", SqlDbType.Int,4)};
			parameters[0].Value = model.ProfessionName1;
			parameters[1].Value = model.ProfessionName2;
			parameters[2].Value = model.ProfessionName3;
			parameters[3].Value = model.CreatedOn;
			parameters[4].Value = model.CreatedBy;
			parameters[5].Value = model.UpdatedOn;
			parameters[6].Value = model.UpdatedBy;
			parameters[7].Value = model.ProfessionCode;
			parameters[8].Value = model.ProfessionID;

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
		public bool Delete(int ProfessionID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Profession ");
			strSql.Append(" where ProfessionID=@ProfessionID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProfessionID", SqlDbType.Int,4)
};
			parameters[0].Value = ProfessionID;

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
		public bool DeleteList(string ProfessionIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Profession ");
			strSql.Append(" where ProfessionID in ("+ProfessionIDlist + ")  ");
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
		public Edge.SVA.Model.Profession GetModel(int ProfessionID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProfessionID,ProfessionName1,ProfessionName2,ProfessionName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,ProfessionCode from Profession ");
			strSql.Append(" where ProfessionID=@ProfessionID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProfessionID", SqlDbType.Int,4)
};
			parameters[0].Value = ProfessionID;

			Edge.SVA.Model.Profession model=new Edge.SVA.Model.Profession();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProfessionID"]!=null && ds.Tables[0].Rows[0]["ProfessionID"].ToString()!="")
				{
					model.ProfessionID=int.Parse(ds.Tables[0].Rows[0]["ProfessionID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProfessionName1"]!=null && ds.Tables[0].Rows[0]["ProfessionName1"].ToString()!="")
				{
					model.ProfessionName1=ds.Tables[0].Rows[0]["ProfessionName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProfessionName2"]!=null && ds.Tables[0].Rows[0]["ProfessionName2"].ToString()!="")
				{
					model.ProfessionName2=ds.Tables[0].Rows[0]["ProfessionName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProfessionName3"]!=null && ds.Tables[0].Rows[0]["ProfessionName3"].ToString()!="")
				{
					model.ProfessionName3=ds.Tables[0].Rows[0]["ProfessionName3"].ToString();
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
				if(ds.Tables[0].Rows[0]["ProfessionCode"]!=null && ds.Tables[0].Rows[0]["ProfessionCode"].ToString()!="")
				{
					model.ProfessionCode=ds.Tables[0].Rows[0]["ProfessionCode"].ToString();
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
			strSql.Append("select ProfessionID,ProfessionName1,ProfessionName2,ProfessionName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,ProfessionCode ");
			strSql.Append(" FROM Profession ");
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
			strSql.Append(" ProfessionID,ProfessionName1,ProfessionName2,ProfessionName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,ProfessionCode ");
			strSql.Append(" FROM Profession ");
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
            parameters[0].Value = "Profession";
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
            sql.Append("select count(*) from Profession ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }
		#endregion  Method
	}
}

