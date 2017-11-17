using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Province
	/// </summary>
	public partial class Province:IProvince
	{
		public Province()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ProvinceCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Province");
			strSql.Append(" where ProvinceCode=@ProvinceCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProvinceCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = ProvinceCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Province model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Province(");
			strSql.Append("ProvinceCode,CountryCode,ProvinceName1,ProvinceName2,ProvinceName3)");
			strSql.Append(" values (");
			strSql.Append("@ProvinceCode,@CountryCode,@ProvinceName1,@ProvinceName2,@ProvinceName3)");
			SqlParameter[] parameters = {
					new SqlParameter("@ProvinceCode", SqlDbType.VarChar,64),
					new SqlParameter("@CountryCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProvinceName1", SqlDbType.NVarChar,512),
					new SqlParameter("@ProvinceName2", SqlDbType.NVarChar,512),
					new SqlParameter("@ProvinceName3", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.ProvinceCode;
			parameters[1].Value = model.CountryCode;
			parameters[2].Value = model.ProvinceName1;
			parameters[3].Value = model.ProvinceName2;
			parameters[4].Value = model.ProvinceName3;

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
		public bool Update(Edge.SVA.Model.Province model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Province set ");
			strSql.Append("CountryCode=@CountryCode,");
			strSql.Append("ProvinceName1=@ProvinceName1,");
			strSql.Append("ProvinceName2=@ProvinceName2,");
			strSql.Append("ProvinceName3=@ProvinceName3");
			strSql.Append(" where ProvinceCode=@ProvinceCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@CountryCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProvinceName1", SqlDbType.NVarChar,512),
					new SqlParameter("@ProvinceName2", SqlDbType.NVarChar,512),
					new SqlParameter("@ProvinceName3", SqlDbType.NVarChar,512),
					new SqlParameter("@ProvinceCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.CountryCode;
			parameters[1].Value = model.ProvinceName1;
			parameters[2].Value = model.ProvinceName2;
			parameters[3].Value = model.ProvinceName3;
			parameters[4].Value = model.ProvinceCode;

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
		public bool Delete(string ProvinceCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Province ");
			strSql.Append(" where ProvinceCode=@ProvinceCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProvinceCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = ProvinceCode;

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
		public bool DeleteList(string ProvinceCodelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Province ");
			strSql.Append(" where ProvinceCode in ("+ProvinceCodelist + ")  ");
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
		public Edge.SVA.Model.Province GetModel(string ProvinceCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProvinceCode,CountryCode,ProvinceName1,ProvinceName2,ProvinceName3 from Province ");
			strSql.Append(" where ProvinceCode=@ProvinceCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProvinceCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = ProvinceCode;

			Edge.SVA.Model.Province model=new Edge.SVA.Model.Province();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProvinceCode"]!=null && ds.Tables[0].Rows[0]["ProvinceCode"].ToString()!="")
				{
					model.ProvinceCode=ds.Tables[0].Rows[0]["ProvinceCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CountryCode"]!=null && ds.Tables[0].Rows[0]["CountryCode"].ToString()!="")
				{
					model.CountryCode=ds.Tables[0].Rows[0]["CountryCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProvinceName1"]!=null && ds.Tables[0].Rows[0]["ProvinceName1"].ToString()!="")
				{
					model.ProvinceName1=ds.Tables[0].Rows[0]["ProvinceName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProvinceName2"]!=null && ds.Tables[0].Rows[0]["ProvinceName2"].ToString()!="")
				{
					model.ProvinceName2=ds.Tables[0].Rows[0]["ProvinceName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProvinceName3"]!=null && ds.Tables[0].Rows[0]["ProvinceName3"].ToString()!="")
				{
					model.ProvinceName3=ds.Tables[0].Rows[0]["ProvinceName3"].ToString();
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
			strSql.Append("select ProvinceCode,CountryCode,ProvinceName1,ProvinceName2,ProvinceName3 ");
			strSql.Append(" FROM Province ");
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
			strSql.Append(" ProvinceCode,CountryCode,ProvinceName1,ProvinceName2,ProvinceName3 ");
			strSql.Append(" FROM Province ");
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
			strSql.Append("select count(1) FROM Province ");
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
				strSql.Append("order by T.ProvinceCode desc");
			}
			strSql.Append(")AS Row, T.*  from Province T ");
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
			parameters[0].Value = "Province";
			parameters[1].Value = "ProvinceCode";
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

