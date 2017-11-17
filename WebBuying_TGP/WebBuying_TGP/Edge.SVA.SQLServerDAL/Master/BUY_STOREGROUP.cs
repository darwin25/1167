using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_STOREGROUP
	/// </summary>
	public partial class BUY_STOREGROUP:IBUY_STOREGROUP
	{
		public BUY_STOREGROUP()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("StoreGroupID", "BUY_STOREGROUP"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StoreGroupID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_STOREGROUP");
			strSql.Append(" where StoreGroupID=@StoreGroupID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreGroupID", SqlDbType.Int,4)
			};
			parameters[0].Value = StoreGroupID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.BUY_STOREGROUP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_STOREGROUP(");
            strSql.Append("StoreGroupCode,StoreGroupName1,StoreGroupName2,StoreGroupName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,StoreBrandCode)");
			strSql.Append(" values (");
            strSql.Append("@StoreGroupCode,@StoreGroupName1,@StoreGroupName2,@StoreGroupName3,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@StoreBrandCode)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreGroupCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreGroupName1", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreGroupName2", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreGroupName3", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
                    new SqlParameter("@StoreBrandCode",SqlDbType.VarChar,64)
                                        };
			parameters[0].Value = model.StoreGroupCode;
			parameters[1].Value = model.StoreGroupName1;
			parameters[2].Value = model.StoreGroupName2;
			parameters[3].Value = model.StoreGroupName3;
			parameters[4].Value = model.CreatedOn;
			parameters[5].Value = model.CreatedBy;
			parameters[6].Value = model.UpdatedOn;
			parameters[7].Value = model.UpdatedBy;
            parameters[8].Value = model.StoreBrandCode;
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
		public bool Update(Edge.SVA.Model.BUY_STOREGROUP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_STOREGROUP set ");
			strSql.Append("StoreGroupCode=@StoreGroupCode,");
			strSql.Append("StoreGroupName1=@StoreGroupName1,");
			strSql.Append("StoreGroupName2=@StoreGroupName2,");
			strSql.Append("StoreGroupName3=@StoreGroupName3,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
            strSql.Append("StoreBrandCode=@StoreBrandCode");
			strSql.Append(" where StoreGroupID=@StoreGroupID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreGroupCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreGroupName1", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreGroupName2", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreGroupName3", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
                    new SqlParameter("@StoreBrandCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreGroupID", SqlDbType.Int,4)};
			parameters[0].Value = model.StoreGroupCode;
			parameters[1].Value = model.StoreGroupName1;
			parameters[2].Value = model.StoreGroupName2;
			parameters[3].Value = model.StoreGroupName3;
			parameters[4].Value = model.CreatedOn;
			parameters[5].Value = model.CreatedBy;
			parameters[6].Value = model.UpdatedOn;
			parameters[7].Value = model.UpdatedBy;
            parameters[8].Value = model.StoreBrandCode;
			parameters[9].Value = model.StoreGroupID;

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
		public bool Delete(int StoreGroupID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_STOREGROUP ");
			strSql.Append(" where StoreGroupID=@StoreGroupID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreGroupID", SqlDbType.Int,4)
			};
			parameters[0].Value = StoreGroupID;

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
		public bool DeleteList(string StoreGroupIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_STOREGROUP ");
			strSql.Append(" where StoreGroupID in ("+StoreGroupIDlist + ")  ");
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
		public Edge.SVA.Model.BUY_STOREGROUP GetModel(int StoreGroupID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StoreGroupID,StoreGroupCode,StoreGroupName1,StoreGroupName2,StoreGroupName3,");
            strSql.Append("CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,StoreBrandCode from BUY_STOREGROUP ");
			strSql.Append(" where StoreGroupID=@StoreGroupID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreGroupID", SqlDbType.Int,4)
			};
			parameters[0].Value = StoreGroupID;

			Edge.SVA.Model.BUY_STOREGROUP model=new Edge.SVA.Model.BUY_STOREGROUP();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["StoreGroupID"]!=null && ds.Tables[0].Rows[0]["StoreGroupID"].ToString()!="")
				{
					model.StoreGroupID=int.Parse(ds.Tables[0].Rows[0]["StoreGroupID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StoreGroupCode"]!=null && ds.Tables[0].Rows[0]["StoreGroupCode"].ToString()!="")
				{
					model.StoreGroupCode=ds.Tables[0].Rows[0]["StoreGroupCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreGroupName1"]!=null && ds.Tables[0].Rows[0]["StoreGroupName1"].ToString()!="")
				{
					model.StoreGroupName1=ds.Tables[0].Rows[0]["StoreGroupName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreGroupName2"]!=null && ds.Tables[0].Rows[0]["StoreGroupName2"].ToString()!="")
				{
					model.StoreGroupName2=ds.Tables[0].Rows[0]["StoreGroupName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreGroupName3"]!=null && ds.Tables[0].Rows[0]["StoreGroupName3"].ToString()!="")
				{
					model.StoreGroupName3=ds.Tables[0].Rows[0]["StoreGroupName3"].ToString();
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
                if (ds.Tables[0].Rows[0]["StoreBrandCode"] != null && ds.Tables[0].Rows[0]["StoreBrandCode"].ToString() != "")
                {
                    model.StoreBrandCode = ds.Tables[0].Rows[0]["StoreBrandCode"].ToString();
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
            strSql.Append("select StoreGroupID,StoreGroupCode,StoreGroupName1,StoreGroupName2,StoreGroupName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,StoreBrandCode ");
			strSql.Append(" FROM BUY_STOREGROUP ");
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
            strSql.Append(" StoreGroupID,StoreGroupCode,StoreGroupName1,StoreGroupName2,StoreGroupName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,StoreBrandCode ");
			strSql.Append(" FROM BUY_STOREGROUP ");
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
			strSql.Append("select count(1) FROM BUY_STOREGROUP ");
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
				strSql.Append("order by T.StoreGroupID desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_STOREGROUP T ");
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
			parameters[0].Value = "BUY_STOREGROUP";
			parameters[1].Value = "StoreGroupID";
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

