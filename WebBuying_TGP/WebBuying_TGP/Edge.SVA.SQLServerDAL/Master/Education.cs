using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Education
	/// </summary>
	public partial class Education:IEducation
	{
		public Education()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("EducationID", "Education"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int EducationID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Education");
			strSql.Append(" where EducationID=@EducationID");
			SqlParameter[] parameters = {
					new SqlParameter("@EducationID", SqlDbType.Int,4)
};
			parameters[0].Value = EducationID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.Education model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Education(");
			strSql.Append("EducationName1,EducationName2,EducationName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,EducationCode)");
			strSql.Append(" values (");
			strSql.Append("@EducationName1,@EducationName2,@EducationName3,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@EducationCode)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@EducationName1", SqlDbType.NVarChar,512),
					new SqlParameter("@EducationName2", SqlDbType.NVarChar,512),
					new SqlParameter("@EducationName3", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@EducationCode", SqlDbType.VarChar,512)};
			parameters[0].Value = model.EducationName1;
			parameters[1].Value = model.EducationName2;
			parameters[2].Value = model.EducationName3;
			parameters[3].Value = model.CreatedOn;
			parameters[4].Value = model.CreatedBy;
			parameters[5].Value = model.UpdatedOn;
			parameters[6].Value = model.UpdatedBy;
			parameters[7].Value = model.EducationCode;

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
		public bool Update(Edge.SVA.Model.Education model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Education set ");
			strSql.Append("EducationName1=@EducationName1,");
			strSql.Append("EducationName2=@EducationName2,");
			strSql.Append("EducationName3=@EducationName3,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("EducationCode=@EducationCode");
			strSql.Append(" where EducationID=@EducationID");
			SqlParameter[] parameters = {
					new SqlParameter("@EducationName1", SqlDbType.NVarChar,512),
					new SqlParameter("@EducationName2", SqlDbType.NVarChar,512),
					new SqlParameter("@EducationName3", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@EducationCode", SqlDbType.VarChar,512),
					new SqlParameter("@EducationID", SqlDbType.Int,4)};
			parameters[0].Value = model.EducationName1;
			parameters[1].Value = model.EducationName2;
			parameters[2].Value = model.EducationName3;
			parameters[3].Value = model.CreatedOn;
			parameters[4].Value = model.CreatedBy;
			parameters[5].Value = model.UpdatedOn;
			parameters[6].Value = model.UpdatedBy;
			parameters[7].Value = model.EducationCode;
			parameters[8].Value = model.EducationID;

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
		public bool Delete(int EducationID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Education ");
			strSql.Append(" where EducationID=@EducationID");
			SqlParameter[] parameters = {
					new SqlParameter("@EducationID", SqlDbType.Int,4)
};
			parameters[0].Value = EducationID;

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
		public bool DeleteList(string EducationIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Education ");
			strSql.Append(" where EducationID in ("+EducationIDlist + ")  ");
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
		public Edge.SVA.Model.Education GetModel(int EducationID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 EducationID,EducationName1,EducationName2,EducationName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,EducationCode from Education ");
			strSql.Append(" where EducationID=@EducationID");
			SqlParameter[] parameters = {
					new SqlParameter("@EducationID", SqlDbType.Int,4)
};
			parameters[0].Value = EducationID;

			Edge.SVA.Model.Education model=new Edge.SVA.Model.Education();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["EducationID"]!=null && ds.Tables[0].Rows[0]["EducationID"].ToString()!="")
				{
					model.EducationID=int.Parse(ds.Tables[0].Rows[0]["EducationID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EducationName1"]!=null && ds.Tables[0].Rows[0]["EducationName1"].ToString()!="")
				{
					model.EducationName1=ds.Tables[0].Rows[0]["EducationName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["EducationName2"]!=null && ds.Tables[0].Rows[0]["EducationName2"].ToString()!="")
				{
					model.EducationName2=ds.Tables[0].Rows[0]["EducationName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["EducationName3"]!=null && ds.Tables[0].Rows[0]["EducationName3"].ToString()!="")
				{
					model.EducationName3=ds.Tables[0].Rows[0]["EducationName3"].ToString();
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
				if(ds.Tables[0].Rows[0]["EducationCode"]!=null && ds.Tables[0].Rows[0]["EducationCode"].ToString()!="")
				{
					model.EducationCode=ds.Tables[0].Rows[0]["EducationCode"].ToString();
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
			strSql.Append("select EducationID,EducationName1,EducationName2,EducationName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,EducationCode ");
			strSql.Append(" FROM Education ");
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
			strSql.Append(" EducationID,EducationName1,EducationName2,EducationName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,EducationCode ");
			strSql.Append(" FROM Education ");
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
            parameters[0].Value = "Education";
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
            sql.Append("select count(*) from Education ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

