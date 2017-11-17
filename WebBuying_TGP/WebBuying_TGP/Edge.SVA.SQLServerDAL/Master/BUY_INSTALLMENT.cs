using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_INSTALLMENT
	/// </summary>
	public partial class BUY_INSTALLMENT:IBUY_INSTALLMENT
	{
		public BUY_INSTALLMENT()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("InstallmentID", "BUY_INSTALLMENT"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string InstallmentCode,int InstallmentID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_INSTALLMENT");
			strSql.Append(" where InstallmentCode=@InstallmentCode and InstallmentID=@InstallmentID ");
			SqlParameter[] parameters = {
					new SqlParameter("@InstallmentCode", SqlDbType.VarChar,64),
					new SqlParameter("@InstallmentID", SqlDbType.Int,4)			};
			parameters[0].Value = InstallmentCode;
			parameters[1].Value = InstallmentID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.BUY_INSTALLMENT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_INSTALLMENT(");
			strSql.Append("InstallmentCode,BankID,InstallmentName1,InstallmentName2,InstallmentName3,NoOfLast,PAInterest,StartDate,EndDate,Note,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@InstallmentCode,@BankID,@InstallmentName1,@InstallmentName2,@InstallmentName3,@NoOfLast,@PAInterest,@StartDate,@EndDate,@Note,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@InstallmentCode", SqlDbType.VarChar,64),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@InstallmentName1", SqlDbType.NVarChar,512),
					new SqlParameter("@InstallmentName2", SqlDbType.NVarChar,512),
					new SqlParameter("@InstallmentName3", SqlDbType.NVarChar,512),
					new SqlParameter("@NoOfLast", SqlDbType.Int,4),
					new SqlParameter("@PAInterest", SqlDbType.Decimal,9),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.InstallmentCode;
			parameters[1].Value = model.BankID;
			parameters[2].Value = model.InstallmentName1;
			parameters[3].Value = model.InstallmentName2;
			parameters[4].Value = model.InstallmentName3;
			parameters[5].Value = model.NoOfLast;
			parameters[6].Value = model.PAInterest;
			parameters[7].Value = model.StartDate;
			parameters[8].Value = model.EndDate;
			parameters[9].Value = model.Note;
			parameters[10].Value = model.CreatedOn;
			parameters[11].Value = model.CreatedBy;
			parameters[12].Value = model.UpdatedOn;
			parameters[13].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.BUY_INSTALLMENT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_INSTALLMENT set ");
			strSql.Append("BankID=@BankID,");
			strSql.Append("InstallmentName1=@InstallmentName1,");
			strSql.Append("InstallmentName2=@InstallmentName2,");
			strSql.Append("InstallmentName3=@InstallmentName3,");
			strSql.Append("NoOfLast=@NoOfLast,");
			strSql.Append("PAInterest=@PAInterest,");
			strSql.Append("StartDate=@StartDate,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("Note=@Note,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where InstallmentID=@InstallmentID");
			SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@InstallmentName1", SqlDbType.NVarChar,512),
					new SqlParameter("@InstallmentName2", SqlDbType.NVarChar,512),
					new SqlParameter("@InstallmentName3", SqlDbType.NVarChar,512),
					new SqlParameter("@NoOfLast", SqlDbType.Int,4),
					new SqlParameter("@PAInterest", SqlDbType.Decimal,9),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@InstallmentID", SqlDbType.Int,4),
					new SqlParameter("@InstallmentCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.BankID;
			parameters[1].Value = model.InstallmentName1;
			parameters[2].Value = model.InstallmentName2;
			parameters[3].Value = model.InstallmentName3;
			parameters[4].Value = model.NoOfLast;
			parameters[5].Value = model.PAInterest;
			parameters[6].Value = model.StartDate;
			parameters[7].Value = model.EndDate;
			parameters[8].Value = model.Note;
			parameters[9].Value = model.CreatedOn;
			parameters[10].Value = model.CreatedBy;
			parameters[11].Value = model.UpdatedOn;
			parameters[12].Value = model.UpdatedBy;
			parameters[13].Value = model.InstallmentID;
			parameters[14].Value = model.InstallmentCode;

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
		public bool Delete(int InstallmentID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_INSTALLMENT ");
			strSql.Append(" where InstallmentID=@InstallmentID");
			SqlParameter[] parameters = {
					new SqlParameter("@InstallmentID", SqlDbType.Int,4)
			};
			parameters[0].Value = InstallmentID;

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
		public bool Delete(string InstallmentCode,int InstallmentID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_INSTALLMENT ");
			strSql.Append(" where InstallmentCode=@InstallmentCode and InstallmentID=@InstallmentID ");
			SqlParameter[] parameters = {
					new SqlParameter("@InstallmentCode", SqlDbType.VarChar,64),
					new SqlParameter("@InstallmentID", SqlDbType.Int,4)			};
			parameters[0].Value = InstallmentCode;
			parameters[1].Value = InstallmentID;

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
		public bool DeleteList(string InstallmentIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_INSTALLMENT ");
			strSql.Append(" where InstallmentID in ("+InstallmentIDlist + ")  ");
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
		public Edge.SVA.Model.BUY_INSTALLMENT GetModel(int InstallmentID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 InstallmentID,InstallmentCode,BankID,InstallmentName1,InstallmentName2,InstallmentName3,NoOfLast,PAInterest,StartDate,EndDate,Note,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_INSTALLMENT ");
			strSql.Append(" where InstallmentID=@InstallmentID");
			SqlParameter[] parameters = {
					new SqlParameter("@InstallmentID", SqlDbType.Int,4)
			};
			parameters[0].Value = InstallmentID;

			Edge.SVA.Model.BUY_INSTALLMENT model=new Edge.SVA.Model.BUY_INSTALLMENT();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["InstallmentID"]!=null && ds.Tables[0].Rows[0]["InstallmentID"].ToString()!="")
				{
					model.InstallmentID=int.Parse(ds.Tables[0].Rows[0]["InstallmentID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["InstallmentCode"]!=null && ds.Tables[0].Rows[0]["InstallmentCode"].ToString()!="")
				{
					model.InstallmentCode=ds.Tables[0].Rows[0]["InstallmentCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BankID"]!=null && ds.Tables[0].Rows[0]["BankID"].ToString()!="")
				{
					model.BankID=int.Parse(ds.Tables[0].Rows[0]["BankID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["InstallmentName1"]!=null && ds.Tables[0].Rows[0]["InstallmentName1"].ToString()!="")
				{
					model.InstallmentName1=ds.Tables[0].Rows[0]["InstallmentName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["InstallmentName2"]!=null && ds.Tables[0].Rows[0]["InstallmentName2"].ToString()!="")
				{
					model.InstallmentName2=ds.Tables[0].Rows[0]["InstallmentName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["InstallmentName3"]!=null && ds.Tables[0].Rows[0]["InstallmentName3"].ToString()!="")
				{
					model.InstallmentName3=ds.Tables[0].Rows[0]["InstallmentName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NoOfLast"]!=null && ds.Tables[0].Rows[0]["NoOfLast"].ToString()!="")
				{
					model.NoOfLast=int.Parse(ds.Tables[0].Rows[0]["NoOfLast"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PAInterest"]!=null && ds.Tables[0].Rows[0]["PAInterest"].ToString()!="")
				{
					model.PAInterest=decimal.Parse(ds.Tables[0].Rows[0]["PAInterest"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StartDate"]!=null && ds.Tables[0].Rows[0]["StartDate"].ToString()!="")
				{
					model.StartDate=DateTime.Parse(ds.Tables[0].Rows[0]["StartDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndDate"]!=null && ds.Tables[0].Rows[0]["EndDate"].ToString()!="")
				{
					model.EndDate=DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Note"]!=null && ds.Tables[0].Rows[0]["Note"].ToString()!="")
				{
					model.Note=ds.Tables[0].Rows[0]["Note"].ToString();
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
			strSql.Append("select InstallmentID,InstallmentCode,BankID,InstallmentName1,InstallmentName2,InstallmentName3,NoOfLast,PAInterest,StartDate,EndDate,Note,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_INSTALLMENT ");
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
			strSql.Append(" InstallmentID,InstallmentCode,BankID,InstallmentName1,InstallmentName2,InstallmentName3,NoOfLast,PAInterest,StartDate,EndDate,Note,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_INSTALLMENT ");
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
			strSql.Append("select count(1) FROM BUY_INSTALLMENT ");
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
				strSql.Append("order by T.InstallmentID desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_INSTALLMENT T ");
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
			parameters[0].Value = "BUY_INSTALLMENT";
			parameters[1].Value = "InstallmentID";
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

