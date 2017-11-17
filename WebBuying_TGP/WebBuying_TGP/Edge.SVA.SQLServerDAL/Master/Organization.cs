using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Organization
	/// </summary>
	public partial class Organization:IOrganization
	{
		public Organization()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("OrganizationID", "Organization"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int OrganizationID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Organization");
			strSql.Append(" where OrganizationID=@OrganizationID");
			SqlParameter[] parameters = {
					new SqlParameter("@OrganizationID", SqlDbType.Int,4)
			};
			parameters[0].Value = OrganizationID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.Organization model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Organization(");
			strSql.Append("OrganizationName1,OrganizationName2,OrganizationName3,OrganizationNote,CardNumber,CumulativePoints,CumulativeAmt,OrganizationType,OrganizationPicFile,CallInterface,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,OrganizationCode,OrganizationDesc1,OrganizationDesc2,OrganizationDesc3)");
			strSql.Append(" values (");
			strSql.Append("@OrganizationName1,@OrganizationName2,@OrganizationName3,@OrganizationNote,@CardNumber,@CumulativePoints,@CumulativeAmt,@OrganizationType,@OrganizationPicFile,@CallInterface,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@OrganizationCode,@OrganizationDesc1,@OrganizationDesc2,@OrganizationDesc3)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OrganizationName1", SqlDbType.NVarChar,512),
					new SqlParameter("@OrganizationName2", SqlDbType.NVarChar,512),
					new SqlParameter("@OrganizationName3", SqlDbType.NVarChar,512),
					new SqlParameter("@OrganizationNote", SqlDbType.NVarChar),
					new SqlParameter("@CardNumber", SqlDbType.VarChar,512),
					new SqlParameter("@CumulativePoints", SqlDbType.Int,4),
					new SqlParameter("@CumulativeAmt", SqlDbType.Money,8),
					new SqlParameter("@OrganizationType", SqlDbType.Int,4),
					new SqlParameter("@OrganizationPicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@CallInterface", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@OrganizationCode", SqlDbType.VarChar,64),
					new SqlParameter("@OrganizationDesc1", SqlDbType.NVarChar),
					new SqlParameter("@OrganizationDesc2", SqlDbType.NVarChar),
					new SqlParameter("@OrganizationDesc3", SqlDbType.NVarChar)};
			parameters[0].Value = model.OrganizationName1;
			parameters[1].Value = model.OrganizationName2;
			parameters[2].Value = model.OrganizationName3;
			parameters[3].Value = model.OrganizationNote;
			parameters[4].Value = model.CardNumber;
			parameters[5].Value = model.CumulativePoints;
			parameters[6].Value = model.CumulativeAmt;
			parameters[7].Value = model.OrganizationType;
			parameters[8].Value = model.OrganizationPicFile;
			parameters[9].Value = model.CallInterface;
			parameters[10].Value = model.CreatedOn;
			parameters[11].Value = model.CreatedBy;
			parameters[12].Value = model.UpdatedOn;
			parameters[13].Value = model.UpdatedBy;
			parameters[14].Value = model.OrganizationCode;
			parameters[15].Value = model.OrganizationDesc1;
			parameters[16].Value = model.OrganizationDesc2;
			parameters[17].Value = model.OrganizationDesc3;

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
		public bool Update(Edge.SVA.Model.Organization model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Organization set ");
			strSql.Append("OrganizationName1=@OrganizationName1,");
			strSql.Append("OrganizationName2=@OrganizationName2,");
			strSql.Append("OrganizationName3=@OrganizationName3,");
			strSql.Append("OrganizationNote=@OrganizationNote,");
			strSql.Append("CardNumber=@CardNumber,");
			strSql.Append("CumulativePoints=@CumulativePoints,");
			strSql.Append("CumulativeAmt=@CumulativeAmt,");
			strSql.Append("OrganizationType=@OrganizationType,");
			strSql.Append("OrganizationPicFile=@OrganizationPicFile,");
			strSql.Append("CallInterface=@CallInterface,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("OrganizationCode=@OrganizationCode,");
			strSql.Append("OrganizationDesc1=@OrganizationDesc1,");
			strSql.Append("OrganizationDesc2=@OrganizationDesc2,");
			strSql.Append("OrganizationDesc3=@OrganizationDesc3");
			strSql.Append(" where OrganizationID=@OrganizationID");
			SqlParameter[] parameters = {
					new SqlParameter("@OrganizationName1", SqlDbType.NVarChar,512),
					new SqlParameter("@OrganizationName2", SqlDbType.NVarChar,512),
					new SqlParameter("@OrganizationName3", SqlDbType.NVarChar,512),
					new SqlParameter("@OrganizationNote", SqlDbType.NVarChar),
					new SqlParameter("@CardNumber", SqlDbType.VarChar,512),
					new SqlParameter("@CumulativePoints", SqlDbType.Int,4),
					new SqlParameter("@CumulativeAmt", SqlDbType.Money,8),
					new SqlParameter("@OrganizationType", SqlDbType.Int,4),
					new SqlParameter("@OrganizationPicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@CallInterface", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@OrganizationCode", SqlDbType.VarChar,64),
					new SqlParameter("@OrganizationDesc1", SqlDbType.NVarChar),
					new SqlParameter("@OrganizationDesc2", SqlDbType.NVarChar),
					new SqlParameter("@OrganizationDesc3", SqlDbType.NVarChar),
					new SqlParameter("@OrganizationID", SqlDbType.Int,4)};
			parameters[0].Value = model.OrganizationName1;
			parameters[1].Value = model.OrganizationName2;
			parameters[2].Value = model.OrganizationName3;
			parameters[3].Value = model.OrganizationNote;
			parameters[4].Value = model.CardNumber;
			parameters[5].Value = model.CumulativePoints;
			parameters[6].Value = model.CumulativeAmt;
			parameters[7].Value = model.OrganizationType;
			parameters[8].Value = model.OrganizationPicFile;
			parameters[9].Value = model.CallInterface;
			parameters[10].Value = model.CreatedOn;
			parameters[11].Value = model.CreatedBy;
			parameters[12].Value = model.UpdatedOn;
			parameters[13].Value = model.UpdatedBy;
			parameters[14].Value = model.OrganizationCode;
			parameters[15].Value = model.OrganizationDesc1;
			parameters[16].Value = model.OrganizationDesc2;
			parameters[17].Value = model.OrganizationDesc3;
			parameters[18].Value = model.OrganizationID;

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
		public bool Delete(int OrganizationID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Organization ");
			strSql.Append(" where OrganizationID=@OrganizationID");
			SqlParameter[] parameters = {
					new SqlParameter("@OrganizationID", SqlDbType.Int,4)
			};
			parameters[0].Value = OrganizationID;

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
		public bool DeleteList(string OrganizationIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Organization ");
			strSql.Append(" where OrganizationID in ("+OrganizationIDlist + ")  ");
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
		public Edge.SVA.Model.Organization GetModel(int OrganizationID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 OrganizationID,OrganizationName1,OrganizationName2,OrganizationName3,OrganizationNote,CardNumber,CumulativePoints,CumulativeAmt,OrganizationType,OrganizationPicFile,CallInterface,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,OrganizationCode,OrganizationDesc1,OrganizationDesc2,OrganizationDesc3 from Organization ");
			strSql.Append(" where OrganizationID=@OrganizationID");
			SqlParameter[] parameters = {
					new SqlParameter("@OrganizationID", SqlDbType.Int,4)
			};
			parameters[0].Value = OrganizationID;

			Edge.SVA.Model.Organization model=new Edge.SVA.Model.Organization();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["OrganizationID"]!=null && ds.Tables[0].Rows[0]["OrganizationID"].ToString()!="")
				{
					model.OrganizationID=int.Parse(ds.Tables[0].Rows[0]["OrganizationID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrganizationName1"]!=null && ds.Tables[0].Rows[0]["OrganizationName1"].ToString()!="")
				{
					model.OrganizationName1=ds.Tables[0].Rows[0]["OrganizationName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OrganizationName2"]!=null && ds.Tables[0].Rows[0]["OrganizationName2"].ToString()!="")
				{
					model.OrganizationName2=ds.Tables[0].Rows[0]["OrganizationName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OrganizationName3"]!=null && ds.Tables[0].Rows[0]["OrganizationName3"].ToString()!="")
				{
					model.OrganizationName3=ds.Tables[0].Rows[0]["OrganizationName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OrganizationNote"]!=null && ds.Tables[0].Rows[0]["OrganizationNote"].ToString()!="")
				{
					model.OrganizationNote=ds.Tables[0].Rows[0]["OrganizationNote"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CardNumber"]!=null && ds.Tables[0].Rows[0]["CardNumber"].ToString()!="")
				{
					model.CardNumber=ds.Tables[0].Rows[0]["CardNumber"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CumulativePoints"]!=null && ds.Tables[0].Rows[0]["CumulativePoints"].ToString()!="")
				{
					model.CumulativePoints=int.Parse(ds.Tables[0].Rows[0]["CumulativePoints"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CumulativeAmt"]!=null && ds.Tables[0].Rows[0]["CumulativeAmt"].ToString()!="")
				{
					model.CumulativeAmt=decimal.Parse(ds.Tables[0].Rows[0]["CumulativeAmt"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrganizationType"]!=null && ds.Tables[0].Rows[0]["OrganizationType"].ToString()!="")
				{
					model.OrganizationType=int.Parse(ds.Tables[0].Rows[0]["OrganizationType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrganizationPicFile"]!=null && ds.Tables[0].Rows[0]["OrganizationPicFile"].ToString()!="")
				{
					model.OrganizationPicFile=ds.Tables[0].Rows[0]["OrganizationPicFile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CallInterface"]!=null && ds.Tables[0].Rows[0]["CallInterface"].ToString()!="")
				{
					model.CallInterface=int.Parse(ds.Tables[0].Rows[0]["CallInterface"].ToString());
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
				if(ds.Tables[0].Rows[0]["OrganizationCode"]!=null && ds.Tables[0].Rows[0]["OrganizationCode"].ToString()!="")
				{
					model.OrganizationCode=ds.Tables[0].Rows[0]["OrganizationCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OrganizationDesc1"]!=null && ds.Tables[0].Rows[0]["OrganizationDesc1"].ToString()!="")
				{
					model.OrganizationDesc1=ds.Tables[0].Rows[0]["OrganizationDesc1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OrganizationDesc2"]!=null && ds.Tables[0].Rows[0]["OrganizationDesc2"].ToString()!="")
				{
					model.OrganizationDesc2=ds.Tables[0].Rows[0]["OrganizationDesc2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OrganizationDesc3"]!=null && ds.Tables[0].Rows[0]["OrganizationDesc3"].ToString()!="")
				{
					model.OrganizationDesc3=ds.Tables[0].Rows[0]["OrganizationDesc3"].ToString();
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
			strSql.Append("select OrganizationID,OrganizationName1,OrganizationName2,OrganizationName3,OrganizationNote,CardNumber,CumulativePoints,CumulativeAmt,OrganizationType,OrganizationPicFile,CallInterface,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,OrganizationCode,OrganizationDesc1,OrganizationDesc2,OrganizationDesc3 ");
			strSql.Append(" FROM Organization ");
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
			strSql.Append(" OrganizationID,OrganizationName1,OrganizationName2,OrganizationName3,OrganizationNote,CardNumber,CumulativePoints,CumulativeAmt,OrganizationType,OrganizationPicFile,CallInterface,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,OrganizationCode,OrganizationDesc1,OrganizationDesc2,OrganizationDesc3 ");
			strSql.Append(" FROM Organization ");
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
			strSql.Append("select count(1) FROM Organization ");
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
				strSql.Append("order by T.OrganizationID desc");
			}
			strSql.Append(")AS Row, T.*  from Organization T ");
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
			parameters[0].Value = "Organization";
			parameters[1].Value = "OrganizationID";
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

