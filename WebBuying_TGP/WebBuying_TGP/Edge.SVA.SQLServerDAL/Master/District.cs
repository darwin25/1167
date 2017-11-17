﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:District
	/// </summary>
	public partial class District:IDistrict
	{
		public District()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string DistrictCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from District");
			strSql.Append(" where DistrictCode=@DistrictCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = DistrictCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.District model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into District(");
			strSql.Append("DistrictCode,CityCode,DistrictName1,DistrictName2,DistrictName3)");
			strSql.Append(" values (");
			strSql.Append("@DistrictCode,@CityCode,@DistrictName1,@DistrictName2,@DistrictName3)");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictCode", SqlDbType.VarChar,64),
					new SqlParameter("@CityCode", SqlDbType.VarChar,64),
					new SqlParameter("@DistrictName1", SqlDbType.NVarChar,512),
					new SqlParameter("@DistrictName2", SqlDbType.NVarChar,512),
					new SqlParameter("@DistrictName3", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.DistrictCode;
			parameters[1].Value = model.CityCode;
			parameters[2].Value = model.DistrictName1;
			parameters[3].Value = model.DistrictName2;
			parameters[4].Value = model.DistrictName3;

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
		public bool Update(Edge.SVA.Model.District model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update District set ");
			strSql.Append("CityCode=@CityCode,");
			strSql.Append("DistrictName1=@DistrictName1,");
			strSql.Append("DistrictName2=@DistrictName2,");
			strSql.Append("DistrictName3=@DistrictName3");
			strSql.Append(" where DistrictCode=@DistrictCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@CityCode", SqlDbType.VarChar,64),
					new SqlParameter("@DistrictName1", SqlDbType.NVarChar,512),
					new SqlParameter("@DistrictName2", SqlDbType.NVarChar,512),
					new SqlParameter("@DistrictName3", SqlDbType.NVarChar,512),
					new SqlParameter("@DistrictCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.CityCode;
			parameters[1].Value = model.DistrictName1;
			parameters[2].Value = model.DistrictName2;
			parameters[3].Value = model.DistrictName3;
			parameters[4].Value = model.DistrictCode;

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
		public bool Delete(string DistrictCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from District ");
			strSql.Append(" where DistrictCode=@DistrictCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = DistrictCode;

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
		public bool DeleteList(string DistrictCodelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from District ");
			strSql.Append(" where DistrictCode in ("+DistrictCodelist + ")  ");
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
		public Edge.SVA.Model.District GetModel(string DistrictCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DistrictCode,CityCode,DistrictName1,DistrictName2,DistrictName3 from District ");
			strSql.Append(" where DistrictCode=@DistrictCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = DistrictCode;

			Edge.SVA.Model.District model=new Edge.SVA.Model.District();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["DistrictCode"]!=null && ds.Tables[0].Rows[0]["DistrictCode"].ToString()!="")
				{
					model.DistrictCode=ds.Tables[0].Rows[0]["DistrictCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CityCode"]!=null && ds.Tables[0].Rows[0]["CityCode"].ToString()!="")
				{
					model.CityCode=ds.Tables[0].Rows[0]["CityCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DistrictName1"]!=null && ds.Tables[0].Rows[0]["DistrictName1"].ToString()!="")
				{
					model.DistrictName1=ds.Tables[0].Rows[0]["DistrictName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DistrictName2"]!=null && ds.Tables[0].Rows[0]["DistrictName2"].ToString()!="")
				{
					model.DistrictName2=ds.Tables[0].Rows[0]["DistrictName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DistrictName3"]!=null && ds.Tables[0].Rows[0]["DistrictName3"].ToString()!="")
				{
					model.DistrictName3=ds.Tables[0].Rows[0]["DistrictName3"].ToString();
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
			strSql.Append("select DistrictCode,CityCode,DistrictName1,DistrictName2,DistrictName3 ");
			strSql.Append(" FROM District ");
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
			strSql.Append(" DistrictCode,CityCode,DistrictName1,DistrictName2,DistrictName3 ");
			strSql.Append(" FROM District ");
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
			strSql.Append("select count(1) FROM District ");
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
				strSql.Append("order by T.DistrictCode desc");
			}
			strSql.Append(")AS Row, T.*  from District T ");
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
					new SqlParameter("@strWhere", SqlDbType.NText),
					};
			parameters[0].Value = "District";
			parameters[1].Value = "DistrictCode";
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

