using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:SNSType
	/// </summary>
	public partial class SNSType:ISNSType
	{
		public SNSType()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SNSTypeID", "SNSType"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SNSTypeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SNSType");
			strSql.Append(" where SNSTypeID=@SNSTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@SNSTypeID", SqlDbType.Int,4)
};
			parameters[0].Value = SNSTypeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.SNSType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SNSType(");
			strSql.Append("SNSTypeName1,SNSTypeName2,SNSTypeName3,SNSTypeURL,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@SNSTypeName1,@SNSTypeName2,@SNSTypeName3,@SNSTypeURL,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SNSTypeName1", SqlDbType.NVarChar,512),
					new SqlParameter("@SNSTypeName2", SqlDbType.NVarChar,512),
					new SqlParameter("@SNSTypeName3", SqlDbType.NVarChar,512),
					new SqlParameter("@SNSTypeURL", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.SNSTypeName1;
			parameters[1].Value = model.SNSTypeName2;
			parameters[2].Value = model.SNSTypeName3;
			parameters[3].Value = model.SNSTypeURL;
			parameters[4].Value = model.CreatedOn;
			parameters[5].Value = model.CreatedBy;
			parameters[6].Value = model.UpdatedOn;
			parameters[7].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.SNSType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SNSType set ");
			strSql.Append("SNSTypeName1=@SNSTypeName1,");
			strSql.Append("SNSTypeName2=@SNSTypeName2,");
			strSql.Append("SNSTypeName3=@SNSTypeName3,");
			strSql.Append("SNSTypeURL=@SNSTypeURL,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where SNSTypeID=@SNSTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@SNSTypeName1", SqlDbType.NVarChar,512),
					new SqlParameter("@SNSTypeName2", SqlDbType.NVarChar,512),
					new SqlParameter("@SNSTypeName3", SqlDbType.NVarChar,512),
					new SqlParameter("@SNSTypeURL", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@SNSTypeID", SqlDbType.Int,4)};
			parameters[0].Value = model.SNSTypeName1;
			parameters[1].Value = model.SNSTypeName2;
			parameters[2].Value = model.SNSTypeName3;
			parameters[3].Value = model.SNSTypeURL;
			parameters[4].Value = model.CreatedOn;
			parameters[5].Value = model.CreatedBy;
			parameters[6].Value = model.UpdatedOn;
			parameters[7].Value = model.UpdatedBy;
			parameters[8].Value = model.SNSTypeID;

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
		public bool Delete(int SNSTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNSType ");
			strSql.Append(" where SNSTypeID=@SNSTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@SNSTypeID", SqlDbType.Int,4)
};
			parameters[0].Value = SNSTypeID;

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
		public bool DeleteList(string SNSTypeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNSType ");
			strSql.Append(" where SNSTypeID in ("+SNSTypeIDlist + ")  ");
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
		public Edge.SVA.Model.SNSType GetModel(int SNSTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SNSTypeID,SNSTypeName1,SNSTypeName2,SNSTypeName3,SNSTypeURL,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from SNSType ");
			strSql.Append(" where SNSTypeID=@SNSTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@SNSTypeID", SqlDbType.Int,4)
};
			parameters[0].Value = SNSTypeID;

			Edge.SVA.Model.SNSType model=new Edge.SVA.Model.SNSType();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["SNSTypeID"]!=null && ds.Tables[0].Rows[0]["SNSTypeID"].ToString()!="")
				{
					model.SNSTypeID=int.Parse(ds.Tables[0].Rows[0]["SNSTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SNSTypeName1"]!=null && ds.Tables[0].Rows[0]["SNSTypeName1"].ToString()!="")
				{
					model.SNSTypeName1=ds.Tables[0].Rows[0]["SNSTypeName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SNSTypeName2"]!=null && ds.Tables[0].Rows[0]["SNSTypeName2"].ToString()!="")
				{
					model.SNSTypeName2=ds.Tables[0].Rows[0]["SNSTypeName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SNSTypeName3"]!=null && ds.Tables[0].Rows[0]["SNSTypeName3"].ToString()!="")
				{
					model.SNSTypeName3=ds.Tables[0].Rows[0]["SNSTypeName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SNSTypeURL"]!=null && ds.Tables[0].Rows[0]["SNSTypeURL"].ToString()!="")
				{
					model.SNSTypeURL=ds.Tables[0].Rows[0]["SNSTypeURL"].ToString();
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
			strSql.Append("select SNSTypeID,SNSTypeName1,SNSTypeName2,SNSTypeName3,SNSTypeURL,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM SNSType ");
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
			strSql.Append(" SNSTypeID,SNSTypeName1,SNSTypeName2,SNSTypeName3,SNSTypeURL,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM SNSType ");
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
            parameters[0].Value = "SNSType";
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
            sql.Append("select count(*) from SNSType ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

