using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_WEEKFLAG
	/// </summary>
	public partial class BUY_WEEKFLAG:IBUY_WEEKFLAG
	{
		public BUY_WEEKFLAG()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("WeekFlagID", "BUY_WEEKFLAG"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string WeekFlagCode,int WeekFlagID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_WEEKFLAG");
			strSql.Append(" where WeekFlagCode=@WeekFlagCode and WeekFlagID=@WeekFlagID ");
			SqlParameter[] parameters = {
					new SqlParameter("@WeekFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@WeekFlagID", SqlDbType.Int,4)			};
			parameters[0].Value = WeekFlagCode;
			parameters[1].Value = WeekFlagID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.BUY_WEEKFLAG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_WEEKFLAG(");
			strSql.Append("WeekFlagCode,Note,SundayFlag,MondayFlag,TuesdayFlag,WednesdayFlag,ThursdayFlag,FridayFlag,SaturdayFlag)");
			strSql.Append(" values (");
			strSql.Append("@WeekFlagCode,@Note,@SundayFlag,@MondayFlag,@TuesdayFlag,@WednesdayFlag,@ThursdayFlag,@FridayFlag,@SaturdayFlag)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@WeekFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@SundayFlag", SqlDbType.Int,4),
					new SqlParameter("@MondayFlag", SqlDbType.Int,4),
					new SqlParameter("@TuesdayFlag", SqlDbType.Int,4),
					new SqlParameter("@WednesdayFlag", SqlDbType.Int,4),
					new SqlParameter("@ThursdayFlag", SqlDbType.Int,4),
					new SqlParameter("@FridayFlag", SqlDbType.Int,4),
					new SqlParameter("@SaturdayFlag", SqlDbType.Int,4)};
			parameters[0].Value = model.WeekFlagCode;
			parameters[1].Value = model.Note;
			parameters[2].Value = model.SundayFlag;
			parameters[3].Value = model.MondayFlag;
			parameters[4].Value = model.TuesdayFlag;
			parameters[5].Value = model.WednesdayFlag;
			parameters[6].Value = model.ThursdayFlag;
			parameters[7].Value = model.FridayFlag;
			parameters[8].Value = model.SaturdayFlag;

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
		public bool Update(Edge.SVA.Model.BUY_WEEKFLAG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_WEEKFLAG set ");
			strSql.Append("Note=@Note,");
			strSql.Append("SundayFlag=@SundayFlag,");
			strSql.Append("MondayFlag=@MondayFlag,");
			strSql.Append("TuesdayFlag=@TuesdayFlag,");
			strSql.Append("WednesdayFlag=@WednesdayFlag,");
			strSql.Append("ThursdayFlag=@ThursdayFlag,");
			strSql.Append("FridayFlag=@FridayFlag,");
			strSql.Append("SaturdayFlag=@SaturdayFlag");
			strSql.Append(" where WeekFlagID=@WeekFlagID");
			SqlParameter[] parameters = {
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@SundayFlag", SqlDbType.Int,4),
					new SqlParameter("@MondayFlag", SqlDbType.Int,4),
					new SqlParameter("@TuesdayFlag", SqlDbType.Int,4),
					new SqlParameter("@WednesdayFlag", SqlDbType.Int,4),
					new SqlParameter("@ThursdayFlag", SqlDbType.Int,4),
					new SqlParameter("@FridayFlag", SqlDbType.Int,4),
					new SqlParameter("@SaturdayFlag", SqlDbType.Int,4),
					new SqlParameter("@WeekFlagID", SqlDbType.Int,4),
					new SqlParameter("@WeekFlagCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.Note;
			parameters[1].Value = model.SundayFlag;
			parameters[2].Value = model.MondayFlag;
			parameters[3].Value = model.TuesdayFlag;
			parameters[4].Value = model.WednesdayFlag;
			parameters[5].Value = model.ThursdayFlag;
			parameters[6].Value = model.FridayFlag;
			parameters[7].Value = model.SaturdayFlag;
			parameters[8].Value = model.WeekFlagID;
			parameters[9].Value = model.WeekFlagCode;

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
		public bool Delete(int WeekFlagID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_WEEKFLAG ");
			strSql.Append(" where WeekFlagID=@WeekFlagID");
			SqlParameter[] parameters = {
					new SqlParameter("@WeekFlagID", SqlDbType.Int,4)
			};
			parameters[0].Value = WeekFlagID;

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
		public bool Delete(string WeekFlagCode,int WeekFlagID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_WEEKFLAG ");
			strSql.Append(" where WeekFlagCode=@WeekFlagCode and WeekFlagID=@WeekFlagID ");
			SqlParameter[] parameters = {
					new SqlParameter("@WeekFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@WeekFlagID", SqlDbType.Int,4)			};
			parameters[0].Value = WeekFlagCode;
			parameters[1].Value = WeekFlagID;

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
		public bool DeleteList(string WeekFlagIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_WEEKFLAG ");
			strSql.Append(" where WeekFlagID in ("+WeekFlagIDlist + ")  ");
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
		public Edge.SVA.Model.BUY_WEEKFLAG GetModel(int WeekFlagID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 WeekFlagID,WeekFlagCode,Note,SundayFlag,MondayFlag,TuesdayFlag,WednesdayFlag,ThursdayFlag,FridayFlag,SaturdayFlag from BUY_WEEKFLAG ");
			strSql.Append(" where WeekFlagID=@WeekFlagID");
			SqlParameter[] parameters = {
					new SqlParameter("@WeekFlagID", SqlDbType.Int,4)
			};
			parameters[0].Value = WeekFlagID;

			Edge.SVA.Model.BUY_WEEKFLAG model=new Edge.SVA.Model.BUY_WEEKFLAG();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["WeekFlagID"]!=null && ds.Tables[0].Rows[0]["WeekFlagID"].ToString()!="")
				{
					model.WeekFlagID=int.Parse(ds.Tables[0].Rows[0]["WeekFlagID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["WeekFlagCode"]!=null && ds.Tables[0].Rows[0]["WeekFlagCode"].ToString()!="")
				{
					model.WeekFlagCode=ds.Tables[0].Rows[0]["WeekFlagCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Note"]!=null && ds.Tables[0].Rows[0]["Note"].ToString()!="")
				{
					model.Note=ds.Tables[0].Rows[0]["Note"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SundayFlag"]!=null && ds.Tables[0].Rows[0]["SundayFlag"].ToString()!="")
				{
					model.SundayFlag=int.Parse(ds.Tables[0].Rows[0]["SundayFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MondayFlag"]!=null && ds.Tables[0].Rows[0]["MondayFlag"].ToString()!="")
				{
					model.MondayFlag=int.Parse(ds.Tables[0].Rows[0]["MondayFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TuesdayFlag"]!=null && ds.Tables[0].Rows[0]["TuesdayFlag"].ToString()!="")
				{
					model.TuesdayFlag=int.Parse(ds.Tables[0].Rows[0]["TuesdayFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["WednesdayFlag"]!=null && ds.Tables[0].Rows[0]["WednesdayFlag"].ToString()!="")
				{
					model.WednesdayFlag=int.Parse(ds.Tables[0].Rows[0]["WednesdayFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ThursdayFlag"]!=null && ds.Tables[0].Rows[0]["ThursdayFlag"].ToString()!="")
				{
					model.ThursdayFlag=int.Parse(ds.Tables[0].Rows[0]["ThursdayFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FridayFlag"]!=null && ds.Tables[0].Rows[0]["FridayFlag"].ToString()!="")
				{
					model.FridayFlag=int.Parse(ds.Tables[0].Rows[0]["FridayFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SaturdayFlag"]!=null && ds.Tables[0].Rows[0]["SaturdayFlag"].ToString()!="")
				{
					model.SaturdayFlag=int.Parse(ds.Tables[0].Rows[0]["SaturdayFlag"].ToString());
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
			strSql.Append("select WeekFlagID,WeekFlagCode,Note,SundayFlag,MondayFlag,TuesdayFlag,WednesdayFlag,ThursdayFlag,FridayFlag,SaturdayFlag ");
			strSql.Append(" FROM BUY_WEEKFLAG ");
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
			strSql.Append(" WeekFlagID,WeekFlagCode,Note,SundayFlag,MondayFlag,TuesdayFlag,WednesdayFlag,ThursdayFlag,FridayFlag,SaturdayFlag ");
			strSql.Append(" FROM BUY_WEEKFLAG ");
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
			strSql.Append("select count(1) FROM BUY_WEEKFLAG ");
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
				strSql.Append("order by T.WeekFlagID desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_WEEKFLAG T ");
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
			parameters[0].Value = "BUY_WEEKFLAG";
			parameters[1].Value = "WeekFlagID";
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

