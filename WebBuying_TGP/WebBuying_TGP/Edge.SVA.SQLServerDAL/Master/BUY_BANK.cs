using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_BANK
	/// </summary>
	public partial class BUY_BANK:IBUY_BANK
	{
		public BUY_BANK()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("BankID", "BUY_BANK"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string BankCode,int BankID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_BANK");
			strSql.Append(" where BankCode=@BankCode and BankID=@BankID ");
			SqlParameter[] parameters = {
					new SqlParameter("@BankCode", SqlDbType.VarChar,64),
					new SqlParameter("@BankID", SqlDbType.Int,4)			};
			parameters[0].Value = BankCode;
			parameters[1].Value = BankID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.BUY_BANK model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_BANK(");
			strSql.Append("BankCode,BankName1,BankName2,BankName3,Commissionrate,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@BankCode,@BankName1,@BankName2,@BankName3,@Commissionrate,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BankCode", SqlDbType.VarChar,64),
					new SqlParameter("@BankName1", SqlDbType.NVarChar,512),
					new SqlParameter("@BankName2", SqlDbType.NVarChar,512),
					new SqlParameter("@BankName3", SqlDbType.NVarChar,512),
					new SqlParameter("@Commissionrate", SqlDbType.Decimal,9),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.BankCode;
			parameters[1].Value = model.BankName1;
			parameters[2].Value = model.BankName2;
			parameters[3].Value = model.BankName3;
			parameters[4].Value = model.Commissionrate;
			parameters[5].Value = model.CreatedOn;
			parameters[6].Value = model.CreatedBy;
			parameters[7].Value = model.UpdatedOn;
			parameters[8].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.BUY_BANK model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_BANK set ");
			strSql.Append("BankName1=@BankName1,");
			strSql.Append("BankName2=@BankName2,");
			strSql.Append("BankName3=@BankName3,");
			strSql.Append("Commissionrate=@Commissionrate,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where BankID=@BankID");
			SqlParameter[] parameters = {
					new SqlParameter("@BankName1", SqlDbType.NVarChar,512),
					new SqlParameter("@BankName2", SqlDbType.NVarChar,512),
					new SqlParameter("@BankName3", SqlDbType.NVarChar,512),
					new SqlParameter("@Commissionrate", SqlDbType.Decimal,9),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@BankCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.BankName1;
			parameters[1].Value = model.BankName2;
			parameters[2].Value = model.BankName3;
			parameters[3].Value = model.Commissionrate;
			parameters[4].Value = model.CreatedOn;
			parameters[5].Value = model.CreatedBy;
			parameters[6].Value = model.UpdatedOn;
			parameters[7].Value = model.UpdatedBy;
			parameters[8].Value = model.BankID;
			parameters[9].Value = model.BankCode;

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
		public bool Delete(int BankID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_BANK ");
			strSql.Append(" where BankID=@BankID");
			SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.Int,4)
			};
			parameters[0].Value = BankID;

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
		public bool Delete(string BankCode,int BankID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_BANK ");
			strSql.Append(" where BankCode=@BankCode and BankID=@BankID ");
			SqlParameter[] parameters = {
					new SqlParameter("@BankCode", SqlDbType.VarChar,64),
					new SqlParameter("@BankID", SqlDbType.Int,4)			};
			parameters[0].Value = BankCode;
			parameters[1].Value = BankID;

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
		public bool DeleteList(string BankIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_BANK ");
			strSql.Append(" where BankID in ("+BankIDlist + ")  ");
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
		public Edge.SVA.Model.BUY_BANK GetModel(int BankID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 BankID,BankCode,BankName1,BankName2,BankName3,Commissionrate,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_BANK ");
			strSql.Append(" where BankID=@BankID");
			SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.Int,4)
			};
			parameters[0].Value = BankID;

			Edge.SVA.Model.BUY_BANK model=new Edge.SVA.Model.BUY_BANK();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["BankID"]!=null && ds.Tables[0].Rows[0]["BankID"].ToString()!="")
				{
					model.BankID=int.Parse(ds.Tables[0].Rows[0]["BankID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BankCode"]!=null && ds.Tables[0].Rows[0]["BankCode"].ToString()!="")
				{
					model.BankCode=ds.Tables[0].Rows[0]["BankCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BankName1"]!=null && ds.Tables[0].Rows[0]["BankName1"].ToString()!="")
				{
					model.BankName1=ds.Tables[0].Rows[0]["BankName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BankName2"]!=null && ds.Tables[0].Rows[0]["BankName2"].ToString()!="")
				{
					model.BankName2=ds.Tables[0].Rows[0]["BankName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BankName3"]!=null && ds.Tables[0].Rows[0]["BankName3"].ToString()!="")
				{
					model.BankName3=ds.Tables[0].Rows[0]["BankName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Commissionrate"]!=null && ds.Tables[0].Rows[0]["Commissionrate"].ToString()!="")
				{
					model.Commissionrate=decimal.Parse(ds.Tables[0].Rows[0]["Commissionrate"].ToString());
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
			strSql.Append("select BankID,BankCode,BankName1,BankName2,BankName3,Commissionrate,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_BANK ");
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
			strSql.Append(" BankID,BankCode,BankName1,BankName2,BankName3,Commissionrate,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_BANK ");
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
			strSql.Append("select count(1) FROM BUY_BANK ");
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
				strSql.Append("order by T.BankID desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_BANK T ");
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
			parameters[0].Value = "BUY_BANK";
			parameters[1].Value = "BankID";
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

