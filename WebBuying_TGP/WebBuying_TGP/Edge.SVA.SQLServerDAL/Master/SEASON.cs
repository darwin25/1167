using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:SEASON
	/// </summary>
	public partial class SEASON:ISEASON
	{
		public SEASON()
		{}
		#region Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SeasonID", "SEASON"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SeasonID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SEASON");
			strSql.Append(" where SeasonID=@SeasonID");
			SqlParameter[] parameters = {
					new SqlParameter("@SeasonID", SqlDbType.Int,4)
			};
			parameters[0].Value = SeasonID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.SEASON model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SEASON(");
            strSql.Append("SeasonCode,SeasonCode,SeasonName2,SeasonName3,SeasonName1)");
			strSql.Append(" values (");
            strSql.Append("@SeasonCode,@SeasonName2,@SeasonName3,@SeasonName1)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SeasonCode", SqlDbType.VarChar,64),
					new SqlParameter("@SeasonName2", SqlDbType.VarChar,512),
					new SqlParameter("@SeasonName3", SqlDbType.VarChar,512),
					new SqlParameter("@SeasonName1", SqlDbType.VarChar,512)};
			parameters[0].Value = model.SeasonCode;
			parameters[1].Value = model.SeasonName2;
            parameters[2].Value = model.SeasonName3;
            parameters[3].Value = model.SeasonName1;

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
		public bool Update(Edge.SVA.Model.SEASON model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SEASON set ");
			strSql.Append("SeasonCode=@SeasonCode,");
            strSql.Append("SeasonName2=@SeasonName2,");
            strSql.Append("SeasonName3=@SeasonName3,");
            strSql.Append("SeasonName1=@SeasonName1");
			strSql.Append(" where SeasonID=@SeasonID");
			SqlParameter[] parameters = {
					new SqlParameter("@SeasonCode", SqlDbType.VarChar,64),
					new SqlParameter("@SeasonName2", SqlDbType.VarChar,512),
					new SqlParameter("@SeasonName3", SqlDbType.VarChar,512),
					new SqlParameter("@SeasonName1", SqlDbType.VarChar,512),
					new SqlParameter("@SeasonID", SqlDbType.Int,4)};
			parameters[0].Value = model.SeasonCode;
			parameters[1].Value = model.SeasonName2;
            parameters[2].Value = model.SeasonName3;
            parameters[3].Value = model.SeasonName1;
			parameters[4].Value = model.SeasonID;

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
		public bool Delete(int SeasonID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SEASON ");
			strSql.Append(" where SeasonID=@SeasonID");
			SqlParameter[] parameters = {
					new SqlParameter("@SeasonID", SqlDbType.Int,4)
			};
			parameters[0].Value = SeasonID;

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
		public bool DeleteList(string SeasonIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SEASON ");
			strSql.Append(" where SeasonID in ("+SeasonIDlist + ")  ");
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
		public Edge.SVA.Model.SEASON GetModel(int SeasonID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 SeasonID,SeasonCode,SeasonName2,SeasonName3,SeasonName1 from SEASON ");
			strSql.Append(" where SeasonID=@SeasonID");
			SqlParameter[] parameters = {
					new SqlParameter("@SeasonID", SqlDbType.Int,4)
			};
			parameters[0].Value = SeasonID;

			Edge.SVA.Model.SEASON model=new Edge.SVA.Model.SEASON();
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
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.SEASON DataRowToModel(DataRow row)
		{
			Edge.SVA.Model.SEASON model=new Edge.SVA.Model.SEASON();
			if (row != null)
			{
				if(row["SeasonID"]!=null && row["SeasonID"].ToString()!="")
				{
					model.SeasonID=int.Parse(row["SeasonID"].ToString());
				}
				if(row["SeasonCode"]!=null)
				{
					model.SeasonCode=row["SeasonCode"].ToString();
				}
                if (row["SeasonName2"] != null)
				{
                    model.SeasonName2 = row["SeasonName2"].ToString();
				}
                if (row["SeasonName3"] != null)
				{
                    model.SeasonName3 = row["SeasonName3"].ToString();
				}
                if (row["SeasonName1"] != null)
				{
                    model.SeasonName1 = row["SeasonName1"].ToString();
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
            strSql.Append("select SeasonID,SeasonCode,SeasonName2,SeasonName3,SeasonName1 ");
			strSql.Append(" FROM SEASON ");
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
            strSql.Append(" SeasonID,SeasonCode,SeasonCode,SeasonName2,SeasonName3,SeasonName1 ");
			strSql.Append(" FROM SEASON ");
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
			strSql.Append("select count(1) FROM SEASON ");
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
				strSql.Append("order by T.SeasonID desc");
			}
			strSql.Append(")AS Row, T.*  from SEASON T ");
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
			parameters[0].Value = "SEASON";
			parameters[1].Value = "SeasonID";
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

