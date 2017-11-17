using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:PasswordRule
	/// </summary>
	public partial class PasswordRule:IPasswordRule
	{
		public PasswordRule()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PasswordRuleID", "PasswordRule"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PasswordRuleID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PasswordRule");
			strSql.Append(" where PasswordRuleID=@PasswordRuleID");
			SqlParameter[] parameters = {
					new SqlParameter("@PasswordRuleID", SqlDbType.Int,4)
};
			parameters[0].Value = PasswordRuleID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.PasswordRule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PasswordRule(");
			strSql.Append("PWDMinLength,PWDMaxLength,PWDSecurityLevel,PWDStructure,PWDValidDays,PWDValidDaysUnit,ResetPWDDays,MemberPWDRule,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,PasswordRuleCode,Name1,Name2,Name3)");
			strSql.Append(" values (");
			strSql.Append("@PWDMinLength,@PWDMaxLength,@PWDSecurityLevel,@PWDStructure,@PWDValidDays,@PWDValidDaysUnit,@ResetPWDDays,@MemberPWDRule,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@PasswordRuleCode,@Name1,@Name2,@Name3)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PWDMinLength", SqlDbType.Int,4),
					new SqlParameter("@PWDMaxLength", SqlDbType.Int,4),
					new SqlParameter("@PWDSecurityLevel", SqlDbType.Int,4),
					new SqlParameter("@PWDStructure", SqlDbType.Int,4),
					new SqlParameter("@PWDValidDays", SqlDbType.Int,4),
					new SqlParameter("@PWDValidDaysUnit", SqlDbType.Int,4),
					new SqlParameter("@ResetPWDDays", SqlDbType.Int,4),
					new SqlParameter("@MemberPWDRule", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@PasswordRuleCode", SqlDbType.NVarChar,512),
					new SqlParameter("@Name1", SqlDbType.NVarChar,512),
					new SqlParameter("@Name2", SqlDbType.NVarChar,512),
					new SqlParameter("@Name3", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.PWDMinLength;
			parameters[1].Value = model.PWDMaxLength;
			parameters[2].Value = model.PWDSecurityLevel;
			parameters[3].Value = model.PWDStructure;
			parameters[4].Value = model.PWDValidDays;
			parameters[5].Value = model.PWDValidDaysUnit;
			parameters[6].Value = model.ResetPWDDays;
			parameters[7].Value = model.MemberPWDRule;
			parameters[8].Value = model.CreatedOn;
			parameters[9].Value = model.CreatedBy;
			parameters[10].Value = model.UpdatedOn;
			parameters[11].Value = model.UpdatedBy;
			parameters[12].Value = model.PasswordRuleCode;
			parameters[13].Value = model.Name1;
			parameters[14].Value = model.Name2;
			parameters[15].Value = model.Name3;

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
		public bool Update(Edge.SVA.Model.PasswordRule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PasswordRule set ");
			strSql.Append("PWDMinLength=@PWDMinLength,");
			strSql.Append("PWDMaxLength=@PWDMaxLength,");
			strSql.Append("PWDSecurityLevel=@PWDSecurityLevel,");
			strSql.Append("PWDStructure=@PWDStructure,");
			strSql.Append("PWDValidDays=@PWDValidDays,");
			strSql.Append("PWDValidDaysUnit=@PWDValidDaysUnit,");
			strSql.Append("ResetPWDDays=@ResetPWDDays,");
			strSql.Append("MemberPWDRule=@MemberPWDRule,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("PasswordRuleCode=@PasswordRuleCode,");
			strSql.Append("Name1=@Name1,");
			strSql.Append("Name2=@Name2,");
			strSql.Append("Name3=@Name3");
			strSql.Append(" where PasswordRuleID=@PasswordRuleID");
			SqlParameter[] parameters = {
					new SqlParameter("@PWDMinLength", SqlDbType.Int,4),
					new SqlParameter("@PWDMaxLength", SqlDbType.Int,4),
					new SqlParameter("@PWDSecurityLevel", SqlDbType.Int,4),
					new SqlParameter("@PWDStructure", SqlDbType.Int,4),
					new SqlParameter("@PWDValidDays", SqlDbType.Int,4),
					new SqlParameter("@PWDValidDaysUnit", SqlDbType.Int,4),
					new SqlParameter("@ResetPWDDays", SqlDbType.Int,4),
					new SqlParameter("@MemberPWDRule", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@PasswordRuleCode", SqlDbType.NVarChar,512),
					new SqlParameter("@Name1", SqlDbType.NVarChar,512),
					new SqlParameter("@Name2", SqlDbType.NVarChar,512),
					new SqlParameter("@Name3", SqlDbType.NVarChar,512),
					new SqlParameter("@PasswordRuleID", SqlDbType.Int,4)};
			parameters[0].Value = model.PWDMinLength;
			parameters[1].Value = model.PWDMaxLength;
			parameters[2].Value = model.PWDSecurityLevel;
			parameters[3].Value = model.PWDStructure;
			parameters[4].Value = model.PWDValidDays;
			parameters[5].Value = model.PWDValidDaysUnit;
			parameters[6].Value = model.ResetPWDDays;
			parameters[7].Value = model.MemberPWDRule;
			parameters[8].Value = model.CreatedOn;
			parameters[9].Value = model.CreatedBy;
			parameters[10].Value = model.UpdatedOn;
			parameters[11].Value = model.UpdatedBy;
			parameters[12].Value = model.PasswordRuleCode;
			parameters[13].Value = model.Name1;
			parameters[14].Value = model.Name2;
			parameters[15].Value = model.Name3;
			parameters[16].Value = model.PasswordRuleID;

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
		public bool Delete(int PasswordRuleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PasswordRule ");
			strSql.Append(" where PasswordRuleID=@PasswordRuleID");
			SqlParameter[] parameters = {
					new SqlParameter("@PasswordRuleID", SqlDbType.Int,4)
};
			parameters[0].Value = PasswordRuleID;

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
		public bool DeleteList(string PasswordRuleIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PasswordRule ");
			strSql.Append(" where PasswordRuleID in ("+PasswordRuleIDlist + ")  ");
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
		public Edge.SVA.Model.PasswordRule GetModel(int PasswordRuleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PasswordRuleID,PWDMinLength,PWDMaxLength,PWDSecurityLevel,PWDStructure,PWDValidDays,PWDValidDaysUnit,ResetPWDDays,MemberPWDRule,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,PasswordRuleCode,Name1,Name2,Name3 from PasswordRule ");
			strSql.Append(" where PasswordRuleID=@PasswordRuleID");
			SqlParameter[] parameters = {
					new SqlParameter("@PasswordRuleID", SqlDbType.Int,4)
};
			parameters[0].Value = PasswordRuleID;

			Edge.SVA.Model.PasswordRule model=new Edge.SVA.Model.PasswordRule();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PasswordRuleID"]!=null && ds.Tables[0].Rows[0]["PasswordRuleID"].ToString()!="")
				{
					model.PasswordRuleID=int.Parse(ds.Tables[0].Rows[0]["PasswordRuleID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PWDMinLength"]!=null && ds.Tables[0].Rows[0]["PWDMinLength"].ToString()!="")
				{
					model.PWDMinLength=int.Parse(ds.Tables[0].Rows[0]["PWDMinLength"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PWDMaxLength"]!=null && ds.Tables[0].Rows[0]["PWDMaxLength"].ToString()!="")
				{
					model.PWDMaxLength=int.Parse(ds.Tables[0].Rows[0]["PWDMaxLength"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PWDSecurityLevel"]!=null && ds.Tables[0].Rows[0]["PWDSecurityLevel"].ToString()!="")
				{
					model.PWDSecurityLevel=int.Parse(ds.Tables[0].Rows[0]["PWDSecurityLevel"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PWDStructure"]!=null && ds.Tables[0].Rows[0]["PWDStructure"].ToString()!="")
				{
					model.PWDStructure=int.Parse(ds.Tables[0].Rows[0]["PWDStructure"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PWDValidDays"]!=null && ds.Tables[0].Rows[0]["PWDValidDays"].ToString()!="")
				{
					model.PWDValidDays=int.Parse(ds.Tables[0].Rows[0]["PWDValidDays"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PWDValidDaysUnit"]!=null && ds.Tables[0].Rows[0]["PWDValidDaysUnit"].ToString()!="")
				{
					model.PWDValidDaysUnit=int.Parse(ds.Tables[0].Rows[0]["PWDValidDaysUnit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ResetPWDDays"]!=null && ds.Tables[0].Rows[0]["ResetPWDDays"].ToString()!="")
				{
					model.ResetPWDDays=int.Parse(ds.Tables[0].Rows[0]["ResetPWDDays"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberPWDRule"]!=null && ds.Tables[0].Rows[0]["MemberPWDRule"].ToString()!="")
				{
					model.MemberPWDRule=int.Parse(ds.Tables[0].Rows[0]["MemberPWDRule"].ToString());
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
				if(ds.Tables[0].Rows[0]["PasswordRuleCode"]!=null && ds.Tables[0].Rows[0]["PasswordRuleCode"].ToString()!="")
				{
					model.PasswordRuleCode=ds.Tables[0].Rows[0]["PasswordRuleCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Name1"]!=null && ds.Tables[0].Rows[0]["Name1"].ToString()!="")
				{
					model.Name1=ds.Tables[0].Rows[0]["Name1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Name2"]!=null && ds.Tables[0].Rows[0]["Name2"].ToString()!="")
				{
					model.Name2=ds.Tables[0].Rows[0]["Name2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Name3"]!=null && ds.Tables[0].Rows[0]["Name3"].ToString()!="")
				{
					model.Name3=ds.Tables[0].Rows[0]["Name3"].ToString();
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
			strSql.Append("select PasswordRuleID,PWDMinLength,PWDMaxLength,PWDSecurityLevel,PWDStructure,PWDValidDays,PWDValidDaysUnit,ResetPWDDays,MemberPWDRule,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,PasswordRuleCode,Name1,Name2,Name3 ");
			strSql.Append(" FROM PasswordRule ");
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
			strSql.Append(" PasswordRuleID,PWDMinLength,PWDMaxLength,PWDSecurityLevel,PWDStructure,PWDValidDays,PWDValidDaysUnit,ResetPWDDays,MemberPWDRule,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,PasswordRuleCode,Name1,Name2,Name3 ");
			strSql.Append(" FROM PasswordRule ");
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
            parameters[0].Value = "PasswordRule";
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
            sql.Append("select count(*) from PasswordRule ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }
		#endregion  Method
	}
}

