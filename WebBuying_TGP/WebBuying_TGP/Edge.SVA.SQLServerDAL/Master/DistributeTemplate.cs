using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:DistributeTemplate
	/// </summary>
	public partial class DistributeTemplate:IDistributeTemplate
	{
		public DistributeTemplate()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("DistributionID", "DistributeTemplate"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string DistributionCode,int DistributionID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DistributeTemplate");
			strSql.Append(" where DistributionCode=@DistributionCode and DistributionID=@DistributionID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DistributionCode", SqlDbType.VarChar,512),
					new SqlParameter("@DistributionID", SqlDbType.Int,4)};
			parameters[0].Value = DistributionCode;
			parameters[1].Value = DistributionID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.DistributeTemplate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DistributeTemplate(");
			strSql.Append("DistributionCode,DistributionDesc1,DistributionDesc2,DistributionDesc3,TemplateFile,Remark,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@DistributionCode,@DistributionDesc1,@DistributionDesc2,@DistributionDesc3,@TemplateFile,@Remark,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DistributionCode", SqlDbType.VarChar,512),
					new SqlParameter("@DistributionDesc1", SqlDbType.NVarChar,512),
					new SqlParameter("@DistributionDesc2", SqlDbType.NVarChar,512),
					new SqlParameter("@DistributionDesc3", SqlDbType.NVarChar,512),
					new SqlParameter("@TemplateFile", SqlDbType.NVarChar,512),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.DistributionCode;
			parameters[1].Value = model.DistributionDesc1;
			parameters[2].Value = model.DistributionDesc2;
			parameters[3].Value = model.DistributionDesc3;
			parameters[4].Value = model.TemplateFile;
			parameters[5].Value = model.Remark;
			parameters[6].Value = model.CreatedOn;
			parameters[7].Value = model.CreatedBy;
			parameters[8].Value = model.UpdatedOn;
			parameters[9].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.DistributeTemplate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DistributeTemplate set ");
			strSql.Append("DistributionDesc1=@DistributionDesc1,");
			strSql.Append("DistributionDesc2=@DistributionDesc2,");
			strSql.Append("DistributionDesc3=@DistributionDesc3,");
			strSql.Append("TemplateFile=@TemplateFile,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
            strSql.Append("DistributionCode=@DistributionCode");
			strSql.Append(" where DistributionID=@DistributionID");
			SqlParameter[] parameters = {
					new SqlParameter("@DistributionDesc1", SqlDbType.NVarChar,512),
					new SqlParameter("@DistributionDesc2", SqlDbType.NVarChar,512),
					new SqlParameter("@DistributionDesc3", SqlDbType.NVarChar,512),
					new SqlParameter("@TemplateFile", SqlDbType.NVarChar,512),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@DistributionID", SqlDbType.Int,4),
					new SqlParameter("@DistributionCode", SqlDbType.VarChar,512)};
			parameters[0].Value = model.DistributionDesc1;
			parameters[1].Value = model.DistributionDesc2;
			parameters[2].Value = model.DistributionDesc3;
			parameters[3].Value = model.TemplateFile;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.CreatedOn;
			parameters[6].Value = model.CreatedBy;
			parameters[7].Value = model.UpdatedOn;
			parameters[8].Value = model.UpdatedBy;
			parameters[9].Value = model.DistributionID;
			parameters[10].Value = model.DistributionCode;

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
		public bool Delete(int DistributionID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DistributeTemplate ");
			strSql.Append(" where DistributionID=@DistributionID");
			SqlParameter[] parameters = {
					new SqlParameter("@DistributionID", SqlDbType.Int,4)
};
			parameters[0].Value = DistributionID;

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
		public bool Delete(string DistributionCode,int DistributionID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DistributeTemplate ");
			strSql.Append(" where DistributionCode=@DistributionCode and DistributionID=@DistributionID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DistributionCode", SqlDbType.VarChar,512),
					new SqlParameter("@DistributionID", SqlDbType.Int,4)};
			parameters[0].Value = DistributionCode;
			parameters[1].Value = DistributionID;

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
		public bool DeleteList(string DistributionIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DistributeTemplate ");
			strSql.Append(" where DistributionID in ("+DistributionIDlist + ")  ");
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
		public Edge.SVA.Model.DistributeTemplate GetModel(int DistributionID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DistributionID,DistributionCode,DistributionDesc1,DistributionDesc2,DistributionDesc3,TemplateFile,Remark,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from DistributeTemplate ");
			strSql.Append(" where DistributionID=@DistributionID");
			SqlParameter[] parameters = {
					new SqlParameter("@DistributionID", SqlDbType.Int,4)
};
			parameters[0].Value = DistributionID;

			Edge.SVA.Model.DistributeTemplate model=new Edge.SVA.Model.DistributeTemplate();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["DistributionID"]!=null && ds.Tables[0].Rows[0]["DistributionID"].ToString()!="")
				{
					model.DistributionID=int.Parse(ds.Tables[0].Rows[0]["DistributionID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DistributionCode"]!=null && ds.Tables[0].Rows[0]["DistributionCode"].ToString()!="")
				{
					model.DistributionCode=ds.Tables[0].Rows[0]["DistributionCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DistributionDesc1"]!=null && ds.Tables[0].Rows[0]["DistributionDesc1"].ToString()!="")
				{
					model.DistributionDesc1=ds.Tables[0].Rows[0]["DistributionDesc1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DistributionDesc2"]!=null && ds.Tables[0].Rows[0]["DistributionDesc2"].ToString()!="")
				{
					model.DistributionDesc2=ds.Tables[0].Rows[0]["DistributionDesc2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DistributionDesc3"]!=null && ds.Tables[0].Rows[0]["DistributionDesc3"].ToString()!="")
				{
					model.DistributionDesc3=ds.Tables[0].Rows[0]["DistributionDesc3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TemplateFile"]!=null && ds.Tables[0].Rows[0]["TemplateFile"].ToString()!="")
				{
					model.TemplateFile=ds.Tables[0].Rows[0]["TemplateFile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Remark"]!=null && ds.Tables[0].Rows[0]["Remark"].ToString()!="")
				{
					model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
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
			strSql.Append("select DistributionID,DistributionCode,DistributionDesc1,DistributionDesc2,DistributionDesc3,TemplateFile,Remark,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM DistributeTemplate ");
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
			strSql.Append(" DistributionID,DistributionCode,DistributionDesc1,DistributionDesc2,DistributionDesc3,TemplateFile,Remark,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM DistributeTemplate ");
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
            int OrderType = 0;
            string OrderField = filedOrder;
            if (filedOrder.ToLower().EndsWith(" desc"))
            {
                OrderType = 1;
                OrderField = filedOrder.Substring(0, filedOrder.ToLower().IndexOf(" desc"));
            }
            else if (filedOrder.ToLower().EndsWith(" asc"))
            {
                OrderField = filedOrder.Substring(0, filedOrder.ToLower().IndexOf(" asc"));
            }
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
            parameters[0].Value = "DistributeTemplate";
            parameters[1].Value = "*";
            parameters[2].Value = OrderField;
            parameters[3].Value = "";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 0;
            parameters[7].Value = OrderType;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPageOrder", parameters, "ds");
        }

        /// <summary>
        /// 获取行总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select count(*) from DistributeTemplate ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

