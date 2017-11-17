using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:City
	/// </summary>
	public partial class City:ICity
	{
		public City()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CityCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from City");
			strSql.Append(" where CityCode=@CityCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@CityCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = CityCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.City model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into City(");
			strSql.Append("CityCode,ProvinceCode,CityName1,CityName2,CityName3)");
			strSql.Append(" values (");
			strSql.Append("@CityCode,@ProvinceCode,@CityName1,@CityName2,@CityName3)");
			SqlParameter[] parameters = {
					new SqlParameter("@CityCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProvinceCode", SqlDbType.VarChar,64),
					new SqlParameter("@CityName1", SqlDbType.NVarChar,512),
					new SqlParameter("@CityName2", SqlDbType.NVarChar,512),
					new SqlParameter("@CityName3", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.CityCode;
			parameters[1].Value = model.ProvinceCode;
			parameters[2].Value = model.CityName1;
			parameters[3].Value = model.CityName2;
			parameters[4].Value = model.CityName3;

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
		public bool Update(Edge.SVA.Model.City model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update City set ");
			strSql.Append("ProvinceCode=@ProvinceCode,");
			strSql.Append("CityName1=@CityName1,");
			strSql.Append("CityName2=@CityName2,");
			strSql.Append("CityName3=@CityName3");
			strSql.Append(" where CityCode=@CityCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProvinceCode", SqlDbType.VarChar,64),
					new SqlParameter("@CityName1", SqlDbType.NVarChar,512),
					new SqlParameter("@CityName2", SqlDbType.NVarChar,512),
					new SqlParameter("@CityName3", SqlDbType.NVarChar,512),
					new SqlParameter("@CityCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.ProvinceCode;
			parameters[1].Value = model.CityName1;
			parameters[2].Value = model.CityName2;
			parameters[3].Value = model.CityName3;
			parameters[4].Value = model.CityCode;

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
		public bool Delete(string CityCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from City ");
			strSql.Append(" where CityCode=@CityCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@CityCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = CityCode;

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
		public bool DeleteList(string CityCodelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from City ");
			strSql.Append(" where CityCode in ("+CityCodelist + ")  ");
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
		public Edge.SVA.Model.City GetModel(string CityCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CityCode,ProvinceCode,CityName1,CityName2,CityName3 from City ");
			strSql.Append(" where CityCode=@CityCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@CityCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = CityCode;

			Edge.SVA.Model.City model=new Edge.SVA.Model.City();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CityCode"]!=null && ds.Tables[0].Rows[0]["CityCode"].ToString()!="")
				{
					model.CityCode=ds.Tables[0].Rows[0]["CityCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProvinceCode"]!=null && ds.Tables[0].Rows[0]["ProvinceCode"].ToString()!="")
				{
					model.ProvinceCode=ds.Tables[0].Rows[0]["ProvinceCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CityName1"]!=null && ds.Tables[0].Rows[0]["CityName1"].ToString()!="")
				{
					model.CityName1=ds.Tables[0].Rows[0]["CityName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CityName2"]!=null && ds.Tables[0].Rows[0]["CityName2"].ToString()!="")
				{
					model.CityName2=ds.Tables[0].Rows[0]["CityName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CityName3"]!=null && ds.Tables[0].Rows[0]["CityName3"].ToString()!="")
				{
					model.CityName3=ds.Tables[0].Rows[0]["CityName3"].ToString();
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
			strSql.Append("select CityCode,ProvinceCode,CityName1,CityName2,CityName3 ");
			strSql.Append(" FROM City ");
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
			strSql.Append(" CityCode,ProvinceCode,CityName1,CityName2,CityName3 ");
			strSql.Append(" FROM City ");
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
			strSql.Append("select count(1) FROM City ");
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
				strSql.Append("order by T.CityCode desc");
			}
			strSql.Append(")AS Row, T.*  from City T ");
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
			parameters[0].Value = "City";
			parameters[1].Value = "CityCode";
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

