
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_PRODUCT_CLASSIFY
    /// 创建人:Lisa
    /// 创建时间：2016-02-26
	/// </summary>
	public partial class BUY_PRODUCT_CLASSIFY:IBUY_PRODUCT_CLASSIFY
	{
		public BUY_PRODUCT_CLASSIFY()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ForeignkeyID", "BUY_PRODUCT_CLASSIFY"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ProdCode,int ForeignkeyID,string ForeignTable)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_PRODUCT_CLASSIFY");
			strSql.Append(" where ProdCode=@ProdCode and ForeignkeyID=@ForeignkeyID and ForeignTable=@ForeignTable ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@ForeignkeyID", SqlDbType.Int,4),
					new SqlParameter("@ForeignTable", SqlDbType.VarChar,64)			};
			parameters[0].Value = ProdCode;
			parameters[1].Value = ForeignkeyID;
			parameters[2].Value = ForeignTable;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_PRODUCT_CLASSIFY model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_PRODUCT_CLASSIFY(");
			strSql.Append("ProdCode,ForeignkeyID,ForeignTable,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@ProdCode,@ForeignkeyID,@ForeignTable,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@ForeignkeyID", SqlDbType.Int,4),
					new SqlParameter("@ForeignTable", SqlDbType.VarChar,64),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.ProdCode;
			parameters[1].Value = model.ForeignkeyID;
			parameters[2].Value = model.ForeignTable;
			parameters[3].Value = model.CreatedOn;
			parameters[4].Value = model.CreatedBy;
			parameters[5].Value = model.UpdatedOn;
			parameters[6].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.BUY_PRODUCT_CLASSIFY model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_PRODUCT_CLASSIFY set ");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where ProdCode=@ProdCode and ForeignkeyID=@ForeignkeyID and ForeignTable=@ForeignTable ");
			SqlParameter[] parameters = {
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@ForeignkeyID", SqlDbType.Int,4),
					new SqlParameter("@ForeignTable", SqlDbType.VarChar,64)};
			parameters[0].Value = model.CreatedOn;
			parameters[1].Value = model.CreatedBy;
			parameters[2].Value = model.UpdatedOn;
			parameters[3].Value = model.UpdatedBy;
			parameters[4].Value = model.ProdCode;
			parameters[5].Value = model.ForeignkeyID;
			parameters[6].Value = model.ForeignTable;

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
		public bool Delete(string ProdCode,int ForeignkeyID,string ForeignTable)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_PRODUCT_CLASSIFY ");
			strSql.Append(" where ProdCode=@ProdCode and ForeignkeyID=@ForeignkeyID and ForeignTable=@ForeignTable ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@ForeignkeyID", SqlDbType.Int,4),
					new SqlParameter("@ForeignTable", SqlDbType.VarChar,64)			};
			parameters[0].Value = ProdCode;
			parameters[1].Value = ForeignkeyID;
			parameters[2].Value = ForeignTable;

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
        public bool Delete(string ProdCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BUY_PRODUCT_CLASSIFY ");
            strSql.Append(" where ProdCode=@ProdCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64)		};
            parameters[0].Value = ProdCode;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
		public Edge.SVA.Model.BUY_PRODUCT_CLASSIFY GetModel(string ProdCode,int ForeignkeyID,string ForeignTable)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProdCode,ForeignkeyID,ForeignTable,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_PRODUCT_CLASSIFY ");
			strSql.Append(" where ProdCode=@ProdCode and ForeignkeyID=@ForeignkeyID and ForeignTable=@ForeignTable ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@ForeignkeyID", SqlDbType.Int,4),
					new SqlParameter("@ForeignTable", SqlDbType.VarChar,64)			};
			parameters[0].Value = ProdCode;
			parameters[1].Value = ForeignkeyID;
			parameters[2].Value = ForeignTable;

			Edge.SVA.Model.BUY_PRODUCT_CLASSIFY model=new Edge.SVA.Model.BUY_PRODUCT_CLASSIFY();
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
        /// <summary>
        /// 查询对象
        /// 创建人：Lisa
        /// 创建时间：2016-02-26
        /// </summary>
        /// <param name="ProdCode"></param>
        /// <param name="ForeignTable"></param>
        /// <returns></returns>
        public Edge.SVA.Model.BUY_PRODUCT_CLASSIFY GetPRODUCT_CLASSIFY(string ProdCode, string ForeignTable)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProdCode,ForeignkeyID,ForeignTable,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_PRODUCT_CLASSIFY ");
            strSql.Append(" where ProdCode=@ProdCode  and ForeignTable=@ForeignTable ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@ForeignTable", SqlDbType.VarChar,64)			};
            parameters[0].Value = ProdCode;
            parameters[1].Value = ForeignTable;

            Edge.SVA.Model.BUY_PRODUCT_CLASSIFY model = new Edge.SVA.Model.BUY_PRODUCT_CLASSIFY();
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
		public Edge.SVA.Model.BUY_PRODUCT_CLASSIFY DataRowToModel(DataRow row)
		{
			Edge.SVA.Model.BUY_PRODUCT_CLASSIFY model=new Edge.SVA.Model.BUY_PRODUCT_CLASSIFY();
			if (row != null)
			{
				if(row["ProdCode"]!=null)
				{
					model.ProdCode=row["ProdCode"].ToString();
				}
				if(row["ForeignkeyID"]!=null && row["ForeignkeyID"].ToString()!="")
				{
					model.ForeignkeyID=int.Parse(row["ForeignkeyID"].ToString());
				}
				if(row["ForeignTable"]!=null)
				{
					model.ForeignTable=row["ForeignTable"].ToString();
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ProdCode,ForeignkeyID,ForeignTable,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_PRODUCT_CLASSIFY ");
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
			strSql.Append(" ProdCode,ForeignkeyID,ForeignTable,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_PRODUCT_CLASSIFY ");
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
			strSql.Append("select count(1) FROM BUY_PRODUCT_CLASSIFY ");
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
				strSql.Append("order by T.ForeignTable desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_PRODUCT_CLASSIFY T ");
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
			parameters[0].Value = "BUY_PRODUCT_CLASSIFY";
			parameters[1].Value = "ForeignTable";
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

