using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_LEASECODE
	/// </summary>
	public partial class BUY_LEASECODE:IBUY_LEASECODE
	{
		public BUY_LEASECODE()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string LeaseCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_LEASECODE");
			strSql.Append(" where LeaseCode=@LeaseCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@LeaseCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = LeaseCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_LEASECODE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_LEASECODE(");
			strSql.Append("LeaseCode,LeaseName1,LeaseName2,LeaseName3,LeaseAddress1,LeaseAddress2,LeaseAddress3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@LeaseCode,@LeaseName1,@LeaseName2,@LeaseName3,@LeaseAddress1,@LeaseAddress2,@LeaseAddress3,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@LeaseCode", SqlDbType.VarChar,64),
					new SqlParameter("@LeaseName1", SqlDbType.NVarChar,512),
					new SqlParameter("@LeaseName2", SqlDbType.NVarChar,512),
					new SqlParameter("@LeaseName3", SqlDbType.NVarChar,512),
					new SqlParameter("@LeaseAddress1", SqlDbType.NVarChar,512),
					new SqlParameter("@LeaseAddress2", SqlDbType.NVarChar,512),
					new SqlParameter("@LeaseAddress3", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.LeaseCode;
			parameters[1].Value = model.LeaseName1;
			parameters[2].Value = model.LeaseName2;
			parameters[3].Value = model.LeaseName3;
			parameters[4].Value = model.LeaseAddress1;
			parameters[5].Value = model.LeaseAddress2;
			parameters[6].Value = model.LeaseAddress3;
			parameters[7].Value = model.CreatedOn;
			parameters[8].Value = model.CreatedBy;
			parameters[9].Value = model.UpdatedOn;
			parameters[10].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.BUY_LEASECODE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_LEASECODE set ");
			strSql.Append("LeaseName1=@LeaseName1,");
			strSql.Append("LeaseName2=@LeaseName2,");
			strSql.Append("LeaseName3=@LeaseName3,");
			strSql.Append("LeaseAddress1=@LeaseAddress1,");
			strSql.Append("LeaseAddress2=@LeaseAddress2,");
			strSql.Append("LeaseAddress3=@LeaseAddress3,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where LeaseCode=@LeaseCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@LeaseName1", SqlDbType.NVarChar,512),
					new SqlParameter("@LeaseName2", SqlDbType.NVarChar,512),
					new SqlParameter("@LeaseName3", SqlDbType.NVarChar,512),
					new SqlParameter("@LeaseAddress1", SqlDbType.NVarChar,512),
					new SqlParameter("@LeaseAddress2", SqlDbType.NVarChar,512),
					new SqlParameter("@LeaseAddress3", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@LeaseCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.LeaseName1;
			parameters[1].Value = model.LeaseName2;
			parameters[2].Value = model.LeaseName3;
			parameters[3].Value = model.LeaseAddress1;
			parameters[4].Value = model.LeaseAddress2;
			parameters[5].Value = model.LeaseAddress3;
			parameters[6].Value = model.CreatedOn;
			parameters[7].Value = model.CreatedBy;
			parameters[8].Value = model.UpdatedOn;
			parameters[9].Value = model.UpdatedBy;
			parameters[10].Value = model.LeaseCode;

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
		public bool Delete(string LeaseCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_LEASECODE ");
			strSql.Append(" where LeaseCode=@LeaseCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@LeaseCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = LeaseCode;

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
		public bool DeleteList(string LeaseCodelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_LEASECODE ");
			strSql.Append(" where LeaseCode in ("+LeaseCodelist + ")  ");
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
		public Edge.SVA.Model.BUY_LEASECODE GetModel(string LeaseCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LeaseCode,LeaseName1,LeaseName2,LeaseName3,LeaseAddress1,LeaseAddress2,LeaseAddress3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_LEASECODE ");
			strSql.Append(" where LeaseCode=@LeaseCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@LeaseCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = LeaseCode;

			Edge.SVA.Model.BUY_LEASECODE model=new Edge.SVA.Model.BUY_LEASECODE();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["LeaseCode"]!=null && ds.Tables[0].Rows[0]["LeaseCode"].ToString()!="")
				{
					model.LeaseCode=ds.Tables[0].Rows[0]["LeaseCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LeaseName1"]!=null && ds.Tables[0].Rows[0]["LeaseName1"].ToString()!="")
				{
					model.LeaseName1=ds.Tables[0].Rows[0]["LeaseName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LeaseName2"]!=null && ds.Tables[0].Rows[0]["LeaseName2"].ToString()!="")
				{
					model.LeaseName2=ds.Tables[0].Rows[0]["LeaseName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LeaseName3"]!=null && ds.Tables[0].Rows[0]["LeaseName3"].ToString()!="")
				{
					model.LeaseName3=ds.Tables[0].Rows[0]["LeaseName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LeaseAddress1"]!=null && ds.Tables[0].Rows[0]["LeaseAddress1"].ToString()!="")
				{
					model.LeaseAddress1=ds.Tables[0].Rows[0]["LeaseAddress1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LeaseAddress2"]!=null && ds.Tables[0].Rows[0]["LeaseAddress2"].ToString()!="")
				{
					model.LeaseAddress2=ds.Tables[0].Rows[0]["LeaseAddress2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LeaseAddress3"]!=null && ds.Tables[0].Rows[0]["LeaseAddress3"].ToString()!="")
				{
					model.LeaseAddress3=ds.Tables[0].Rows[0]["LeaseAddress3"].ToString();
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
			strSql.Append("select LeaseCode,LeaseName1,LeaseName2,LeaseName3,LeaseAddress1,LeaseAddress2,LeaseAddress3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_LEASECODE ");
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
			strSql.Append(" LeaseCode,LeaseName1,LeaseName2,LeaseName3,LeaseAddress1,LeaseAddress2,LeaseAddress3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_LEASECODE ");
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
			strSql.Append("select count(1) FROM BUY_LEASECODE ");
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
				strSql.Append("order by T.LeaseCode desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_LEASECODE T ");
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
			parameters[0].Value = "BUY_LEASECODE";
			parameters[1].Value = "LeaseCode";
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

