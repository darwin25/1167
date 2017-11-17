using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_MONTHFLAG
	/// </summary>
	public partial class BUY_MONTHFLAG:IBUY_MONTHFLAG
	{
		public BUY_MONTHFLAG()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MonthFlagID", "BUY_MONTHFLAG"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string MonthFlagCode,int MonthFlagID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_MONTHFLAG");
			strSql.Append(" where MonthFlagCode=@MonthFlagCode and MonthFlagID=@MonthFlagID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MonthFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@MonthFlagID", SqlDbType.Int,4)			};
			parameters[0].Value = MonthFlagCode;
			parameters[1].Value = MonthFlagID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.BUY_MONTHFLAG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_MONTHFLAG(");
			strSql.Append("MonthFlagCode,Note,JanuaryFlag,FebruaryFlag,MarchFlag,AprilFlag,MayFlag,JuneFlag,JulyFlag,AugustFlag,SeptemberFlag,DecemberFlag,OctoberFlag,NovemberFlag)");
			strSql.Append(" values (");
			strSql.Append("@MonthFlagCode,@Note,@JanuaryFlag,@FebruaryFlag,@MarchFlag,@AprilFlag,@MayFlag,@JuneFlag,@JulyFlag,@AugustFlag,@SeptemberFlag,@DecemberFlag,@OctoberFlag,@NovemberFlag)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MonthFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@JanuaryFlag", SqlDbType.Int,4),
					new SqlParameter("@FebruaryFlag", SqlDbType.Int,4),
					new SqlParameter("@MarchFlag", SqlDbType.Int,4),
					new SqlParameter("@AprilFlag", SqlDbType.Int,4),
					new SqlParameter("@MayFlag", SqlDbType.Int,4),
					new SqlParameter("@JuneFlag", SqlDbType.Int,4),
					new SqlParameter("@JulyFlag", SqlDbType.Int,4),
					new SqlParameter("@AugustFlag", SqlDbType.Int,4),
					new SqlParameter("@SeptemberFlag", SqlDbType.Int,4),
					new SqlParameter("@DecemberFlag", SqlDbType.Int,4),
					new SqlParameter("@OctoberFlag", SqlDbType.Int,4),
					new SqlParameter("@NovemberFlag", SqlDbType.Int,4)};
			parameters[0].Value = model.MonthFlagCode;
			parameters[1].Value = model.Note;
			parameters[2].Value = model.JanuaryFlag;
			parameters[3].Value = model.FebruaryFlag;
			parameters[4].Value = model.MarchFlag;
			parameters[5].Value = model.AprilFlag;
			parameters[6].Value = model.MayFlag;
			parameters[7].Value = model.JuneFlag;
			parameters[8].Value = model.JulyFlag;
			parameters[9].Value = model.AugustFlag;
			parameters[10].Value = model.SeptemberFlag;
			parameters[11].Value = model.DecemberFlag;
			parameters[12].Value = model.OctoberFlag;
			parameters[13].Value = model.NovemberFlag;

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
		public bool Update(Edge.SVA.Model.BUY_MONTHFLAG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_MONTHFLAG set ");
			strSql.Append("Note=@Note,");
			strSql.Append("JanuaryFlag=@JanuaryFlag,");
			strSql.Append("FebruaryFlag=@FebruaryFlag,");
			strSql.Append("MarchFlag=@MarchFlag,");
			strSql.Append("AprilFlag=@AprilFlag,");
			strSql.Append("MayFlag=@MayFlag,");
			strSql.Append("JuneFlag=@JuneFlag,");
			strSql.Append("JulyFlag=@JulyFlag,");
			strSql.Append("AugustFlag=@AugustFlag,");
			strSql.Append("SeptemberFlag=@SeptemberFlag,");
			strSql.Append("DecemberFlag=@DecemberFlag,");
			strSql.Append("OctoberFlag=@OctoberFlag,");
			strSql.Append("NovemberFlag=@NovemberFlag");
			strSql.Append(" where MonthFlagID=@MonthFlagID");
			SqlParameter[] parameters = {
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@JanuaryFlag", SqlDbType.Int,4),
					new SqlParameter("@FebruaryFlag", SqlDbType.Int,4),
					new SqlParameter("@MarchFlag", SqlDbType.Int,4),
					new SqlParameter("@AprilFlag", SqlDbType.Int,4),
					new SqlParameter("@MayFlag", SqlDbType.Int,4),
					new SqlParameter("@JuneFlag", SqlDbType.Int,4),
					new SqlParameter("@JulyFlag", SqlDbType.Int,4),
					new SqlParameter("@AugustFlag", SqlDbType.Int,4),
					new SqlParameter("@SeptemberFlag", SqlDbType.Int,4),
					new SqlParameter("@DecemberFlag", SqlDbType.Int,4),
					new SqlParameter("@OctoberFlag", SqlDbType.Int,4),
					new SqlParameter("@NovemberFlag", SqlDbType.Int,4),
					new SqlParameter("@MonthFlagID", SqlDbType.Int,4),
					new SqlParameter("@MonthFlagCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.Note;
			parameters[1].Value = model.JanuaryFlag;
			parameters[2].Value = model.FebruaryFlag;
			parameters[3].Value = model.MarchFlag;
			parameters[4].Value = model.AprilFlag;
			parameters[5].Value = model.MayFlag;
			parameters[6].Value = model.JuneFlag;
			parameters[7].Value = model.JulyFlag;
			parameters[8].Value = model.AugustFlag;
			parameters[9].Value = model.SeptemberFlag;
			parameters[10].Value = model.DecemberFlag;
			parameters[11].Value = model.OctoberFlag;
			parameters[12].Value = model.NovemberFlag;
			parameters[13].Value = model.MonthFlagID;
			parameters[14].Value = model.MonthFlagCode;

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
		public bool Delete(int MonthFlagID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_MONTHFLAG ");
			strSql.Append(" where MonthFlagID=@MonthFlagID");
			SqlParameter[] parameters = {
					new SqlParameter("@MonthFlagID", SqlDbType.Int,4)
			};
			parameters[0].Value = MonthFlagID;

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
		public bool Delete(string MonthFlagCode,int MonthFlagID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_MONTHFLAG ");
			strSql.Append(" where MonthFlagCode=@MonthFlagCode and MonthFlagID=@MonthFlagID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MonthFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@MonthFlagID", SqlDbType.Int,4)			};
			parameters[0].Value = MonthFlagCode;
			parameters[1].Value = MonthFlagID;

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
		public bool DeleteList(string MonthFlagIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_MONTHFLAG ");
			strSql.Append(" where MonthFlagID in ("+MonthFlagIDlist + ")  ");
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
		public Edge.SVA.Model.BUY_MONTHFLAG GetModel(int MonthFlagID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MonthFlagID,MonthFlagCode,Note,JanuaryFlag,FebruaryFlag,MarchFlag,AprilFlag,MayFlag,JuneFlag,JulyFlag,AugustFlag,SeptemberFlag,DecemberFlag,OctoberFlag,NovemberFlag from BUY_MONTHFLAG ");
			strSql.Append(" where MonthFlagID=@MonthFlagID");
			SqlParameter[] parameters = {
					new SqlParameter("@MonthFlagID", SqlDbType.Int,4)
			};
			parameters[0].Value = MonthFlagID;

			Edge.SVA.Model.BUY_MONTHFLAG model=new Edge.SVA.Model.BUY_MONTHFLAG();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["MonthFlagID"]!=null && ds.Tables[0].Rows[0]["MonthFlagID"].ToString()!="")
				{
					model.MonthFlagID=int.Parse(ds.Tables[0].Rows[0]["MonthFlagID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MonthFlagCode"]!=null && ds.Tables[0].Rows[0]["MonthFlagCode"].ToString()!="")
				{
					model.MonthFlagCode=ds.Tables[0].Rows[0]["MonthFlagCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Note"]!=null && ds.Tables[0].Rows[0]["Note"].ToString()!="")
				{
					model.Note=ds.Tables[0].Rows[0]["Note"].ToString();
				}
				if(ds.Tables[0].Rows[0]["JanuaryFlag"]!=null && ds.Tables[0].Rows[0]["JanuaryFlag"].ToString()!="")
				{
					model.JanuaryFlag=int.Parse(ds.Tables[0].Rows[0]["JanuaryFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FebruaryFlag"]!=null && ds.Tables[0].Rows[0]["FebruaryFlag"].ToString()!="")
				{
					model.FebruaryFlag=int.Parse(ds.Tables[0].Rows[0]["FebruaryFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MarchFlag"]!=null && ds.Tables[0].Rows[0]["MarchFlag"].ToString()!="")
				{
					model.MarchFlag=int.Parse(ds.Tables[0].Rows[0]["MarchFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AprilFlag"]!=null && ds.Tables[0].Rows[0]["AprilFlag"].ToString()!="")
				{
					model.AprilFlag=int.Parse(ds.Tables[0].Rows[0]["AprilFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MayFlag"]!=null && ds.Tables[0].Rows[0]["MayFlag"].ToString()!="")
				{
					model.MayFlag=int.Parse(ds.Tables[0].Rows[0]["MayFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JuneFlag"]!=null && ds.Tables[0].Rows[0]["JuneFlag"].ToString()!="")
				{
					model.JuneFlag=int.Parse(ds.Tables[0].Rows[0]["JuneFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JulyFlag"]!=null && ds.Tables[0].Rows[0]["JulyFlag"].ToString()!="")
				{
					model.JulyFlag=int.Parse(ds.Tables[0].Rows[0]["JulyFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AugustFlag"]!=null && ds.Tables[0].Rows[0]["AugustFlag"].ToString()!="")
				{
					model.AugustFlag=int.Parse(ds.Tables[0].Rows[0]["AugustFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SeptemberFlag"]!=null && ds.Tables[0].Rows[0]["SeptemberFlag"].ToString()!="")
				{
					model.SeptemberFlag=int.Parse(ds.Tables[0].Rows[0]["SeptemberFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DecemberFlag"]!=null && ds.Tables[0].Rows[0]["DecemberFlag"].ToString()!="")
				{
					model.DecemberFlag=int.Parse(ds.Tables[0].Rows[0]["DecemberFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OctoberFlag"]!=null && ds.Tables[0].Rows[0]["OctoberFlag"].ToString()!="")
				{
					model.OctoberFlag=int.Parse(ds.Tables[0].Rows[0]["OctoberFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NovemberFlag"]!=null && ds.Tables[0].Rows[0]["NovemberFlag"].ToString()!="")
				{
					model.NovemberFlag=int.Parse(ds.Tables[0].Rows[0]["NovemberFlag"].ToString());
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
			strSql.Append("select MonthFlagID,MonthFlagCode,Note,JanuaryFlag,FebruaryFlag,MarchFlag,AprilFlag,MayFlag,JuneFlag,JulyFlag,AugustFlag,SeptemberFlag,DecemberFlag,OctoberFlag,NovemberFlag ");
			strSql.Append(" FROM BUY_MONTHFLAG ");
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
			strSql.Append(" MonthFlagID,MonthFlagCode,Note,JanuaryFlag,FebruaryFlag,MarchFlag,AprilFlag,MayFlag,JuneFlag,JulyFlag,AugustFlag,SeptemberFlag,DecemberFlag,OctoberFlag,NovemberFlag ");
			strSql.Append(" FROM BUY_MONTHFLAG ");
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
			strSql.Append("select count(1) FROM BUY_MONTHFLAG ");
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
				strSql.Append("order by T.MonthFlagID desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_MONTHFLAG T ");
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
			parameters[0].Value = "BUY_MONTHFLAG";
			parameters[1].Value = "MonthFlagID";
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

