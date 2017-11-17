using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:StoreType
	/// </summary>
	public partial class StoreType:IStoreType
	{
		public StoreType()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("StoreTypeID", "StoreType"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StoreTypeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StoreType");
			strSql.Append(" where StoreTypeID=@StoreTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreTypeID", SqlDbType.Int,4)
};
			parameters[0].Value = StoreTypeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.StoreType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StoreType(");
			strSql.Append("StoreTypeName1,StoreTypeName2,StoreTypeName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,StoreTypeCode)");
			strSql.Append(" values (");
			strSql.Append("@StoreTypeName1,@StoreTypeName2,@StoreTypeName3,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@StoreTypeCode)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreTypeName1", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreTypeName2", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreTypeName3", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@StoreTypeCode", SqlDbType.VarChar,512)};
			parameters[0].Value = model.StoreTypeName1;
			parameters[1].Value = model.StoreTypeName2;
			parameters[2].Value = model.StoreTypeName3;
			parameters[3].Value = model.CreatedOn;
			parameters[4].Value = model.CreatedBy;
			parameters[5].Value = model.UpdatedOn;
			parameters[6].Value = model.UpdatedBy;
			parameters[7].Value = model.StoreTypeCode;

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
		public bool Update(Edge.SVA.Model.StoreType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StoreType set ");
			strSql.Append("StoreTypeName1=@StoreTypeName1,");
			strSql.Append("StoreTypeName2=@StoreTypeName2,");
			strSql.Append("StoreTypeName3=@StoreTypeName3,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("StoreTypeCode=@StoreTypeCode");
			strSql.Append(" where StoreTypeID=@StoreTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreTypeName1", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreTypeName2", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreTypeName3", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@StoreTypeCode", SqlDbType.VarChar,512),
					new SqlParameter("@StoreTypeID", SqlDbType.Int,4)};
			parameters[0].Value = model.StoreTypeName1;
			parameters[1].Value = model.StoreTypeName2;
			parameters[2].Value = model.StoreTypeName3;
			parameters[3].Value = model.CreatedOn;
			parameters[4].Value = model.CreatedBy;
			parameters[5].Value = model.UpdatedOn;
			parameters[6].Value = model.UpdatedBy;
			parameters[7].Value = model.StoreTypeCode;
			parameters[8].Value = model.StoreTypeID;

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
		public bool Delete(int StoreTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreType ");
			strSql.Append(" where StoreTypeID=@StoreTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreTypeID", SqlDbType.Int,4)
};
			parameters[0].Value = StoreTypeID;

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
		public bool DeleteList(string StoreTypeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreType ");
			strSql.Append(" where StoreTypeID in ("+StoreTypeIDlist + ")  ");
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
		public Edge.SVA.Model.StoreType GetModel(int StoreTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StoreTypeID,StoreTypeName1,StoreTypeName2,StoreTypeName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,StoreTypeCode from StoreType ");
			strSql.Append(" where StoreTypeID=@StoreTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreTypeID", SqlDbType.Int,4)
};
			parameters[0].Value = StoreTypeID;

			Edge.SVA.Model.StoreType model=new Edge.SVA.Model.StoreType();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["StoreTypeID"]!=null && ds.Tables[0].Rows[0]["StoreTypeID"].ToString()!="")
				{
					model.StoreTypeID=int.Parse(ds.Tables[0].Rows[0]["StoreTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StoreTypeName1"]!=null && ds.Tables[0].Rows[0]["StoreTypeName1"].ToString()!="")
				{
					model.StoreTypeName1=ds.Tables[0].Rows[0]["StoreTypeName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreTypeName2"]!=null && ds.Tables[0].Rows[0]["StoreTypeName2"].ToString()!="")
				{
					model.StoreTypeName2=ds.Tables[0].Rows[0]["StoreTypeName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreTypeName3"]!=null && ds.Tables[0].Rows[0]["StoreTypeName3"].ToString()!="")
				{
					model.StoreTypeName3=ds.Tables[0].Rows[0]["StoreTypeName3"].ToString();
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
				if(ds.Tables[0].Rows[0]["StoreTypeCode"]!=null && ds.Tables[0].Rows[0]["StoreTypeCode"].ToString()!="")
				{
					model.StoreTypeCode=ds.Tables[0].Rows[0]["StoreTypeCode"].ToString();
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
			strSql.Append("select StoreTypeID,StoreTypeName1,StoreTypeName2,StoreTypeName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,StoreTypeCode ");
			strSql.Append(" FROM StoreType ");
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
			strSql.Append(" StoreTypeID,StoreTypeName1,StoreTypeName2,StoreTypeName3,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,StoreTypeCode ");
			strSql.Append(" FROM StoreType ");
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
            parameters[0].Value = "StoreType";
            parameters[1].Value = "*";
            parameters[2].Value = OrderField;
            parameters[3].Value = "";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 0;
            parameters[7].Value = 0;
            parameters[8].Value = OrderType;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPageOrder", parameters, "ds");
        }

        /// <summary>
        /// 获取行总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select count(*) from StoreType ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

