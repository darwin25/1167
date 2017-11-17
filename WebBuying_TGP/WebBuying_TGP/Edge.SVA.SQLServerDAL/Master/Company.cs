using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Company
    /// 创建人:Lisa
    /// 创建时间：2016-02-25
	/// </summary>
	public partial class Company:ICompany
	{
		public Company()
		{}
		#region Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CompanyID", "Company"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CompanyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Company");
			strSql.Append(" where CompanyID=@CompanyID");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,4)
			};
			parameters[0].Value = CompanyID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.Company model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Company(");
			strSql.Append("CompanyCode,CompanyName,CompanyAddress,CompanyTelNum,CompanyFaxNum,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CompanyAddress1,CompanyAddress2,CompanyEmail,ContactPerson,ContactEmail,ContactNumber,ContactPhoneNumber,Remark,IsDefault)");
			strSql.Append(" values (");
			strSql.Append("@CompanyCode,@CompanyName,@CompanyAddress,@CompanyTelNum,@CompanyFaxNum,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@CompanyAddress1,@CompanyAddress2,@CompanyEmail,@ContactPerson,@ContactEmail,@ContactNumber,@ContactPhoneNumber,@Remark,@IsDefault)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyCode", SqlDbType.VarChar,64),
					new SqlParameter("@CompanyName", SqlDbType.NVarChar,512),
					new SqlParameter("@CompanyAddress", SqlDbType.NVarChar,512),
					new SqlParameter("@CompanyTelNum", SqlDbType.NVarChar,512),
					new SqlParameter("@CompanyFaxNum", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@CompanyAddress1", SqlDbType.NVarChar,512),
					new SqlParameter("@CompanyAddress2", SqlDbType.NVarChar,512),
					new SqlParameter("@CompanyEmail", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactPerson", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactEmail", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactNumber", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactPhoneNumber", SqlDbType.NVarChar,512),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@IsDefault", SqlDbType.Int,4)};
			parameters[0].Value = model.CompanyCode;
			parameters[1].Value = model.CompanyName;
			parameters[2].Value = model.CompanyAddress;
			parameters[3].Value = model.CompanyTelNum;
			parameters[4].Value = model.CompanyFaxNum;
			parameters[5].Value = model.CreatedOn;
			parameters[6].Value = model.CreatedBy;
			parameters[7].Value = model.UpdatedOn;
			parameters[8].Value = model.UpdatedBy;
			parameters[9].Value = model.CompanyAddress1;
			parameters[10].Value = model.CompanyAddress2;
			parameters[11].Value = model.CompanyEmail;
			parameters[12].Value = model.ContactPerson;
			parameters[13].Value = model.ContactEmail;
			parameters[14].Value = model.ContactNumber;
			parameters[15].Value = model.ContactPhoneNumber;
			parameters[16].Value = model.Remark;
			parameters[17].Value = model.IsDefault;

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
		public bool Update(Edge.SVA.Model.Company model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Company set ");
			strSql.Append("CompanyCode=@CompanyCode,");
			strSql.Append("CompanyName=@CompanyName,");
			strSql.Append("CompanyAddress=@CompanyAddress,");
			strSql.Append("CompanyTelNum=@CompanyTelNum,");
			strSql.Append("CompanyFaxNum=@CompanyFaxNum,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("CompanyAddress1=@CompanyAddress1,");
			strSql.Append("CompanyAddress2=@CompanyAddress2,");
			strSql.Append("CompanyEmail=@CompanyEmail,");
			strSql.Append("ContactPerson=@ContactPerson,");
			strSql.Append("ContactEmail=@ContactEmail,");
			strSql.Append("ContactNumber=@ContactNumber,");
			strSql.Append("ContactPhoneNumber=@ContactPhoneNumber,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("IsDefault=@IsDefault");
			strSql.Append(" where CompanyID=@CompanyID");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyCode", SqlDbType.VarChar,64),
					new SqlParameter("@CompanyName", SqlDbType.NVarChar,512),
					new SqlParameter("@CompanyAddress", SqlDbType.NVarChar,512),
					new SqlParameter("@CompanyTelNum", SqlDbType.NVarChar,512),
					new SqlParameter("@CompanyFaxNum", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@CompanyAddress1", SqlDbType.NVarChar,512),
					new SqlParameter("@CompanyAddress2", SqlDbType.NVarChar,512),
					new SqlParameter("@CompanyEmail", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactPerson", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactEmail", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactNumber", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactPhoneNumber", SqlDbType.NVarChar,512),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@IsDefault", SqlDbType.Int,4),
					new SqlParameter("@CompanyID", SqlDbType.Int,4)};
			parameters[0].Value = model.CompanyCode;
			parameters[1].Value = model.CompanyName;
			parameters[2].Value = model.CompanyAddress;
			parameters[3].Value = model.CompanyTelNum;
			parameters[4].Value = model.CompanyFaxNum;
			parameters[5].Value = model.CreatedOn;
			parameters[6].Value = model.CreatedBy;
			parameters[7].Value = model.UpdatedOn;
			parameters[8].Value = model.UpdatedBy;
			parameters[9].Value = model.CompanyAddress1;
			parameters[10].Value = model.CompanyAddress2;
			parameters[11].Value = model.CompanyEmail;
			parameters[12].Value = model.ContactPerson;
			parameters[13].Value = model.ContactEmail;
			parameters[14].Value = model.ContactNumber;
			parameters[15].Value = model.ContactPhoneNumber;
			parameters[16].Value = model.Remark;
			parameters[17].Value = model.IsDefault;
			parameters[18].Value = model.CompanyID;

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
		public bool Delete(int CompanyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Company ");
			strSql.Append(" where CompanyID=@CompanyID");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,4)
			};
			parameters[0].Value = CompanyID;

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
		public bool DeleteList(string CompanyIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Company ");
			strSql.Append(" where CompanyID in ("+CompanyIDlist + ")  ");
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
		public Edge.SVA.Model.Company GetModel(int CompanyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CompanyID,CompanyCode,CompanyName,CompanyAddress,CompanyTelNum,CompanyFaxNum,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CompanyAddress1,CompanyAddress2,CompanyEmail,ContactPerson,ContactEmail,ContactNumber,ContactPhoneNumber,Remark,IsDefault from Company ");
			strSql.Append(" where CompanyID=@CompanyID");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,4)
			};
			parameters[0].Value = CompanyID;

			Edge.SVA.Model.Company model=new Edge.SVA.Model.Company();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}
        public Edge.SVA.Model.Company GetCompanyByCode(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CompanyID,CompanyCode,CompanyName,CompanyAddress,CompanyTelNum,CompanyFaxNum,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CompanyAddress1,CompanyAddress2,CompanyEmail,ContactPerson,ContactEmail,ContactNumber,ContactPhoneNumber,Remark,IsDefault from Company ");
            strSql.Append(" where CompanyCode=@CompanyCode");
            SqlParameter[] parameters = {
					new SqlParameter("@CompanyCode", SqlDbType.VarChar,64)
			};
            parameters[0].Value = code;

            Edge.SVA.Model.Company model = new Edge.SVA.Model.Company();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Company DataRowToModel(DataRow row)
		{
			Edge.SVA.Model.Company model=new Edge.SVA.Model.Company();
			if (row != null)
			{
				if(row["CompanyID"]!=null && row["CompanyID"].ToString()!="")
				{
					model.CompanyID=int.Parse(row["CompanyID"].ToString());
				}
				if(row["CompanyCode"]!=null)
				{
					model.CompanyCode=row["CompanyCode"].ToString();
				}
				if(row["CompanyName"]!=null)
				{
					model.CompanyName=row["CompanyName"].ToString();
				}
				if(row["CompanyAddress"]!=null)
				{
					model.CompanyAddress=row["CompanyAddress"].ToString();
				}
				if(row["CompanyTelNum"]!=null)
				{
					model.CompanyTelNum=row["CompanyTelNum"].ToString();
				}
				if(row["CompanyFaxNum"]!=null)
				{
					model.CompanyFaxNum=row["CompanyFaxNum"].ToString();
				}
				if(row["CreatedOn"]!=null && row["CreatedOn"].ToString()!="")
				{
					model.CreatedOn=DateTime.Parse(row["CreatedOn"].ToString());
				}
				if(row["CreatedBy"]!=null && row["CreatedBy"].ToString()!="")
				{
					model.CreatedBy=int.Parse(row["CreatedBy"].ToString());
				}
				if(row["UpdatedOn"]!=null && row["UpdatedOn"].ToString()!="")
				{
					model.UpdatedOn=DateTime.Parse(row["UpdatedOn"].ToString());
				}
				if(row["UpdatedBy"]!=null && row["UpdatedBy"].ToString()!="")
				{
					model.UpdatedBy=int.Parse(row["UpdatedBy"].ToString());
				}
				if(row["CompanyAddress1"]!=null)
				{
					model.CompanyAddress1=row["CompanyAddress1"].ToString();
				}
				if(row["CompanyAddress2"]!=null)
				{
					model.CompanyAddress2=row["CompanyAddress2"].ToString();
				}
				if(row["CompanyEmail"]!=null)
				{
					model.CompanyEmail=row["CompanyEmail"].ToString();
				}
				if(row["ContactPerson"]!=null)
				{
					model.ContactPerson=row["ContactPerson"].ToString();
				}
				if(row["ContactEmail"]!=null)
				{
					model.ContactEmail=row["ContactEmail"].ToString();
				}
				if(row["ContactNumber"]!=null)
				{
					model.ContactNumber=row["ContactNumber"].ToString();
				}
				if(row["ContactPhoneNumber"]!=null)
				{
					model.ContactPhoneNumber=row["ContactPhoneNumber"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["IsDefault"]!=null && row["IsDefault"].ToString()!="")
				{
					model.IsDefault=int.Parse(row["IsDefault"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CompanyID,CompanyCode,CompanyName,CompanyAddress,CompanyTelNum,CompanyFaxNum,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CompanyAddress1,CompanyAddress2,CompanyEmail,ContactPerson,ContactEmail,ContactNumber,ContactPhoneNumber,Remark,IsDefault ");
			strSql.Append(" FROM Company ");
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
			strSql.Append(" CompanyID,CompanyCode,CompanyName,CompanyAddress,CompanyTelNum,CompanyFaxNum,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CompanyAddress1,CompanyAddress2,CompanyEmail,ContactPerson,ContactEmail,ContactNumber,ContactPhoneNumber,Remark,IsDefault ");
			strSql.Append(" FROM Company ");
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
			strSql.Append("select count(1) FROM Company ");
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
				strSql.Append("order by T.CompanyID desc");
			}
			strSql.Append(")AS Row, T.*  from Company T ");
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
			parameters[0].Value = "Company";
			parameters[1].Value = "CompanyID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		
	}
}

