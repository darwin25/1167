using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_STOCKTYPE
	/// </summary>
	public partial class BUY_STOCKTYPE:IBUY_STOCKTYPE
	{
		public BUY_STOCKTYPE()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("StockTypeID", "BUY_STOCKTYPE"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string StockTypeCode,int StockTypeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_STOCKTYPE");
			strSql.Append(" where StockTypeCode=@StockTypeCode and StockTypeID=@StockTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StockTypeCode", SqlDbType.VarChar,64),
					new SqlParameter("@StockTypeID", SqlDbType.Int,4)			};
			parameters[0].Value = StockTypeCode;
			parameters[1].Value = StockTypeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.BUY_STOCKTYPE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_STOCKTYPE(");
			strSql.Append("StockTypeCode,StockTypeName1,StockTypeName2,StockTypeName3,NeedSerialno,SubInvSuffix,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@StockTypeCode,@StockTypeName1,@StockTypeName2,@StockTypeName3,@NeedSerialno,@SubInvSuffix,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@StockTypeCode", SqlDbType.VarChar,64),
					new SqlParameter("@StockTypeName1", SqlDbType.NVarChar,512),
					new SqlParameter("@StockTypeName2", SqlDbType.NVarChar,512),
					new SqlParameter("@StockTypeName3", SqlDbType.NVarChar,512),
					new SqlParameter("@NeedSerialno", SqlDbType.Int,4),
					new SqlParameter("@SubInvSuffix", SqlDbType.VarChar,64),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.StockTypeCode;
			parameters[1].Value = model.StockTypeName1;
			parameters[2].Value = model.StockTypeName2;
			parameters[3].Value = model.StockTypeName3;
			parameters[4].Value = model.NeedSerialno;
			parameters[5].Value = model.SubInvSuffix;
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
		public bool Update(Edge.SVA.Model.BUY_STOCKTYPE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_STOCKTYPE set ");
			strSql.Append("StockTypeName1=@StockTypeName1,");
			strSql.Append("StockTypeName2=@StockTypeName2,");
			strSql.Append("StockTypeName3=@StockTypeName3,");
			strSql.Append("NeedSerialno=@NeedSerialno,");
			strSql.Append("SubInvSuffix=@SubInvSuffix,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where StockTypeID=@StockTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@StockTypeName1", SqlDbType.NVarChar,512),
					new SqlParameter("@StockTypeName2", SqlDbType.NVarChar,512),
					new SqlParameter("@StockTypeName3", SqlDbType.NVarChar,512),
					new SqlParameter("@NeedSerialno", SqlDbType.Int,4),
					new SqlParameter("@SubInvSuffix", SqlDbType.VarChar,64),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@StockTypeID", SqlDbType.Int,4),
					new SqlParameter("@StockTypeCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.StockTypeName1;
			parameters[1].Value = model.StockTypeName2;
			parameters[2].Value = model.StockTypeName3;
			parameters[3].Value = model.NeedSerialno;
			parameters[4].Value = model.SubInvSuffix;
			parameters[5].Value = model.CreatedOn;
			parameters[6].Value = model.CreatedBy;
			parameters[7].Value = model.UpdatedOn;
			parameters[8].Value = model.UpdatedBy;
			parameters[9].Value = model.StockTypeID;
			parameters[10].Value = model.StockTypeCode;

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
		public bool Delete(int StockTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_STOCKTYPE ");
			strSql.Append(" where StockTypeID=@StockTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@StockTypeID", SqlDbType.Int,4)
			};
			parameters[0].Value = StockTypeID;

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
		public bool Delete(string StockTypeCode,int StockTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_STOCKTYPE ");
			strSql.Append(" where StockTypeCode=@StockTypeCode and StockTypeID=@StockTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StockTypeCode", SqlDbType.VarChar,64),
					new SqlParameter("@StockTypeID", SqlDbType.Int,4)			};
			parameters[0].Value = StockTypeCode;
			parameters[1].Value = StockTypeID;

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
		public bool DeleteList(string StockTypeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_STOCKTYPE ");
			strSql.Append(" where StockTypeID in ("+StockTypeIDlist + ")  ");
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
		public Edge.SVA.Model.BUY_STOCKTYPE GetModel(int StockTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StockTypeID,StockTypeCode,StockTypeName1,StockTypeName2,StockTypeName3,NeedSerialno,SubInvSuffix,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_STOCKTYPE ");
			strSql.Append(" where StockTypeID=@StockTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@StockTypeID", SqlDbType.Int,4)
			};
			parameters[0].Value = StockTypeID;

			Edge.SVA.Model.BUY_STOCKTYPE model=new Edge.SVA.Model.BUY_STOCKTYPE();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["StockTypeID"]!=null && ds.Tables[0].Rows[0]["StockTypeID"].ToString()!="")
				{
					model.StockTypeID=int.Parse(ds.Tables[0].Rows[0]["StockTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StockTypeCode"]!=null && ds.Tables[0].Rows[0]["StockTypeCode"].ToString()!="")
				{
					model.StockTypeCode=ds.Tables[0].Rows[0]["StockTypeCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StockTypeName1"]!=null && ds.Tables[0].Rows[0]["StockTypeName1"].ToString()!="")
				{
					model.StockTypeName1=ds.Tables[0].Rows[0]["StockTypeName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StockTypeName2"]!=null && ds.Tables[0].Rows[0]["StockTypeName2"].ToString()!="")
				{
					model.StockTypeName2=ds.Tables[0].Rows[0]["StockTypeName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StockTypeName3"]!=null && ds.Tables[0].Rows[0]["StockTypeName3"].ToString()!="")
				{
					model.StockTypeName3=ds.Tables[0].Rows[0]["StockTypeName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NeedSerialno"]!=null && ds.Tables[0].Rows[0]["NeedSerialno"].ToString()!="")
				{
					model.NeedSerialno=int.Parse(ds.Tables[0].Rows[0]["NeedSerialno"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SubInvSuffix"]!=null && ds.Tables[0].Rows[0]["SubInvSuffix"].ToString()!="")
				{
					model.SubInvSuffix=ds.Tables[0].Rows[0]["SubInvSuffix"].ToString();
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
			strSql.Append("select StockTypeID,StockTypeCode,StockTypeName1,StockTypeName2,StockTypeName3,NeedSerialno,SubInvSuffix,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_STOCKTYPE ");
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
			strSql.Append(" StockTypeID,StockTypeCode,StockTypeName1,StockTypeName2,StockTypeName3,NeedSerialno,SubInvSuffix,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_STOCKTYPE ");
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
			strSql.Append("select count(1) FROM BUY_STOCKTYPE ");
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
				strSql.Append("order by T.StockTypeID desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_STOCKTYPE T ");
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
			parameters[0].Value = "BUY_STOCKTYPE";
			parameters[1].Value = "StockTypeID";
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

