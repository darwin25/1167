using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_FULFILLMENTHOUSE
	/// </summary>
	public partial class BUY_FULFILLMENTHOUSE:IBUY_FULFILLMENTHOUSE
	{
		public BUY_FULFILLMENTHOUSE()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("FulfillmentHouseID", "BUY_FULFILLMENTHOUSE"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string FulfillmentHouseCode,int FulfillmentHouseID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_FULFILLMENTHOUSE");
			strSql.Append(" where FulfillmentHouseCode=@FulfillmentHouseCode and FulfillmentHouseID=@FulfillmentHouseID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FulfillmentHouseCode", SqlDbType.VarChar,64),
					new SqlParameter("@FulfillmentHouseID", SqlDbType.Int,4)			};
			parameters[0].Value = FulfillmentHouseCode;
			parameters[1].Value = FulfillmentHouseID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.BUY_FULFILLMENTHOUSE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_FULFILLMENTHOUSE(");
			strSql.Append("FulfillmentHouseCode,FulfillmentHouseName1,FulfillmentHouseName2,FulfillmentHouseName3,Phone,Email,Priority,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@FulfillmentHouseCode,@FulfillmentHouseName1,@FulfillmentHouseName2,@FulfillmentHouseName3,@Phone,@Email,@Priority,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FulfillmentHouseCode", SqlDbType.VarChar,64),
					new SqlParameter("@FulfillmentHouseName1", SqlDbType.NVarChar,512),
					new SqlParameter("@FulfillmentHouseName2", SqlDbType.NVarChar,512),
					new SqlParameter("@FulfillmentHouseName3", SqlDbType.NVarChar,512),
					new SqlParameter("@Phone", SqlDbType.NVarChar,512),
					new SqlParameter("@Email", SqlDbType.NVarChar,512),
					new SqlParameter("@Priority", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.FulfillmentHouseCode;
			parameters[1].Value = model.FulfillmentHouseName1;
			parameters[2].Value = model.FulfillmentHouseName2;
			parameters[3].Value = model.FulfillmentHouseName3;
			parameters[4].Value = model.Phone;
			parameters[5].Value = model.Email;
			parameters[6].Value = model.Priority;
			parameters[7].Value = model.CreatedOn;
			parameters[8].Value = model.CreatedBy;
			parameters[9].Value = model.UpdatedOn;
			parameters[10].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.BUY_FULFILLMENTHOUSE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_FULFILLMENTHOUSE set ");
			strSql.Append("FulfillmentHouseName1=@FulfillmentHouseName1,");
			strSql.Append("FulfillmentHouseName2=@FulfillmentHouseName2,");
			strSql.Append("FulfillmentHouseName3=@FulfillmentHouseName3,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Email=@Email,");
			strSql.Append("Priority=@Priority,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where FulfillmentHouseID=@FulfillmentHouseID");
			SqlParameter[] parameters = {
					new SqlParameter("@FulfillmentHouseName1", SqlDbType.NVarChar,512),
					new SqlParameter("@FulfillmentHouseName2", SqlDbType.NVarChar,512),
					new SqlParameter("@FulfillmentHouseName3", SqlDbType.NVarChar,512),
					new SqlParameter("@Phone", SqlDbType.NVarChar,512),
					new SqlParameter("@Email", SqlDbType.NVarChar,512),
					new SqlParameter("@Priority", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@FulfillmentHouseID", SqlDbType.Int,4),
					new SqlParameter("@FulfillmentHouseCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.FulfillmentHouseName1;
			parameters[1].Value = model.FulfillmentHouseName2;
			parameters[2].Value = model.FulfillmentHouseName3;
			parameters[3].Value = model.Phone;
			parameters[4].Value = model.Email;
			parameters[5].Value = model.Priority;
			parameters[6].Value = model.CreatedOn;
			parameters[7].Value = model.CreatedBy;
			parameters[8].Value = model.UpdatedOn;
			parameters[9].Value = model.UpdatedBy;
			parameters[10].Value = model.FulfillmentHouseID;
			parameters[11].Value = model.FulfillmentHouseCode;

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
		public bool Delete(int FulfillmentHouseID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_FULFILLMENTHOUSE ");
			strSql.Append(" where FulfillmentHouseID=@FulfillmentHouseID");
			SqlParameter[] parameters = {
					new SqlParameter("@FulfillmentHouseID", SqlDbType.Int,4)
			};
			parameters[0].Value = FulfillmentHouseID;

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
		public bool Delete(string FulfillmentHouseCode,int FulfillmentHouseID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_FULFILLMENTHOUSE ");
			strSql.Append(" where FulfillmentHouseCode=@FulfillmentHouseCode and FulfillmentHouseID=@FulfillmentHouseID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FulfillmentHouseCode", SqlDbType.VarChar,64),
					new SqlParameter("@FulfillmentHouseID", SqlDbType.Int,4)			};
			parameters[0].Value = FulfillmentHouseCode;
			parameters[1].Value = FulfillmentHouseID;

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
		public bool DeleteList(string FulfillmentHouseIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_FULFILLMENTHOUSE ");
			strSql.Append(" where FulfillmentHouseID in ("+FulfillmentHouseIDlist + ")  ");
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
		public Edge.SVA.Model.BUY_FULFILLMENTHOUSE GetModel(int FulfillmentHouseID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FulfillmentHouseID,FulfillmentHouseCode,FulfillmentHouseName1,FulfillmentHouseName2,FulfillmentHouseName3,Phone,Email,Priority,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_FULFILLMENTHOUSE ");
			strSql.Append(" where FulfillmentHouseID=@FulfillmentHouseID");
			SqlParameter[] parameters = {
					new SqlParameter("@FulfillmentHouseID", SqlDbType.Int,4)
			};
			parameters[0].Value = FulfillmentHouseID;

			Edge.SVA.Model.BUY_FULFILLMENTHOUSE model=new Edge.SVA.Model.BUY_FULFILLMENTHOUSE();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["FulfillmentHouseID"]!=null && ds.Tables[0].Rows[0]["FulfillmentHouseID"].ToString()!="")
				{
					model.FulfillmentHouseID=int.Parse(ds.Tables[0].Rows[0]["FulfillmentHouseID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FulfillmentHouseCode"]!=null && ds.Tables[0].Rows[0]["FulfillmentHouseCode"].ToString()!="")
				{
					model.FulfillmentHouseCode=ds.Tables[0].Rows[0]["FulfillmentHouseCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["FulfillmentHouseName1"]!=null && ds.Tables[0].Rows[0]["FulfillmentHouseName1"].ToString()!="")
				{
					model.FulfillmentHouseName1=ds.Tables[0].Rows[0]["FulfillmentHouseName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["FulfillmentHouseName2"]!=null && ds.Tables[0].Rows[0]["FulfillmentHouseName2"].ToString()!="")
				{
					model.FulfillmentHouseName2=ds.Tables[0].Rows[0]["FulfillmentHouseName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["FulfillmentHouseName3"]!=null && ds.Tables[0].Rows[0]["FulfillmentHouseName3"].ToString()!="")
				{
					model.FulfillmentHouseName3=ds.Tables[0].Rows[0]["FulfillmentHouseName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Phone"]!=null && ds.Tables[0].Rows[0]["Phone"].ToString()!="")
				{
					model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Email"]!=null && ds.Tables[0].Rows[0]["Email"].ToString()!="")
				{
					model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Priority"]!=null && ds.Tables[0].Rows[0]["Priority"].ToString()!="")
				{
					model.Priority=int.Parse(ds.Tables[0].Rows[0]["Priority"].ToString());
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
			strSql.Append("select FulfillmentHouseID,FulfillmentHouseCode,FulfillmentHouseName1,FulfillmentHouseName2,FulfillmentHouseName3,Phone,Email,Priority,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_FULFILLMENTHOUSE ");
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
			strSql.Append(" FulfillmentHouseID,FulfillmentHouseCode,FulfillmentHouseName1,FulfillmentHouseName2,FulfillmentHouseName3,Phone,Email,Priority,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_FULFILLMENTHOUSE ");
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
			strSql.Append("select count(1) FROM BUY_FULFILLMENTHOUSE ");
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
				strSql.Append("order by T.FulfillmentHouseID desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_FULFILLMENTHOUSE T ");
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
			parameters[0].Value = "BUY_FULFILLMENTHOUSE";
			parameters[1].Value = "FulfillmentHouseID";
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

