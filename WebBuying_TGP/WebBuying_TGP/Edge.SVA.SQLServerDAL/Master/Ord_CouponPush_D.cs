using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Ord_CouponPush_D
	/// </summary>
	public partial class Ord_CouponPush_D:IOrd_CouponPush_D
	{
		public Ord_CouponPush_D()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "Ord_CouponPush_D"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ord_CouponPush_D");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
			parameters[0].Value = KeyID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.Ord_CouponPush_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ord_CouponPush_D(");
			strSql.Append("CouponPushNumber,CouponBrandID,CouponTypeID,CouponQty)");
			strSql.Append(" values (");
			strSql.Append("@CouponPushNumber,@CouponBrandID,@CouponTypeID,@CouponQty)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CouponPushNumber", SqlDbType.VarChar,64),
					new SqlParameter("@CouponBrandID", SqlDbType.Int,4),
					new SqlParameter("@CouponTypeID", SqlDbType.Int,4),
					new SqlParameter("@CouponQty", SqlDbType.Int,4)};
			parameters[0].Value = model.CouponPushNumber;
			parameters[1].Value = model.CouponBrandID;
			parameters[2].Value = model.CouponTypeID;
			parameters[3].Value = model.CouponQty;

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
		public bool Update(Edge.SVA.Model.Ord_CouponPush_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ord_CouponPush_D set ");
			strSql.Append("CouponPushNumber=@CouponPushNumber,");
			strSql.Append("CouponBrandID=@CouponBrandID,");
			strSql.Append("CouponTypeID=@CouponTypeID,");
			strSql.Append("CouponQty=@CouponQty");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@CouponPushNumber", SqlDbType.VarChar,64),
					new SqlParameter("@CouponBrandID", SqlDbType.Int,4),
					new SqlParameter("@CouponTypeID", SqlDbType.Int,4),
					new SqlParameter("@CouponQty", SqlDbType.Int,4),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.CouponPushNumber;
			parameters[1].Value = model.CouponBrandID;
			parameters[2].Value = model.CouponTypeID;
			parameters[3].Value = model.CouponQty;
			parameters[4].Value = model.KeyID;

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
		public bool Delete(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_CouponPush_D ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
			parameters[0].Value = KeyID;

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
		public bool DeleteList(string KeyIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_CouponPush_D ");
			strSql.Append(" where KeyID in ("+KeyIDlist + ")  ");
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
		public Edge.SVA.Model.Ord_CouponPush_D GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,CouponPushNumber,CouponBrandID,CouponTypeID,CouponQty from Ord_CouponPush_D ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.Ord_CouponPush_D model=new Edge.SVA.Model.Ord_CouponPush_D();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CouponPushNumber"]!=null && ds.Tables[0].Rows[0]["CouponPushNumber"].ToString()!="")
				{
					model.CouponPushNumber=ds.Tables[0].Rows[0]["CouponPushNumber"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CouponBrandID"]!=null && ds.Tables[0].Rows[0]["CouponBrandID"].ToString()!="")
				{
					model.CouponBrandID=int.Parse(ds.Tables[0].Rows[0]["CouponBrandID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CouponTypeID"]!=null && ds.Tables[0].Rows[0]["CouponTypeID"].ToString()!="")
				{
					model.CouponTypeID=int.Parse(ds.Tables[0].Rows[0]["CouponTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CouponQty"]!=null && ds.Tables[0].Rows[0]["CouponQty"].ToString()!="")
				{
					model.CouponQty=int.Parse(ds.Tables[0].Rows[0]["CouponQty"].ToString());
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
			strSql.Append("select KeyID,CouponPushNumber,CouponBrandID,CouponTypeID,CouponQty ");
			strSql.Append(" FROM Ord_CouponPush_D ");
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
			strSql.Append(" KeyID,CouponPushNumber,CouponBrandID,CouponTypeID,CouponQty ");
			strSql.Append(" FROM Ord_CouponPush_D ");
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
			strSql.Append("select count(1) FROM Ord_CouponPush_D ");
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
				strSql.Append("order by T.KeyID desc");
			}
			strSql.Append(")AS Row, T.*  from Ord_CouponPush_D T ");
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
			parameters[0].Value = "Ord_CouponPush_D";
			parameters[1].Value = "KeyID";
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

