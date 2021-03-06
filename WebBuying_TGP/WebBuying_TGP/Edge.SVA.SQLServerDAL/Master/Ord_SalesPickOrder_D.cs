﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Ord_SalesPickOrder_D
    /// 创建者：Lisa
    /// 创建时间：2016-06-01
	/// </summary>
	public partial class Ord_SalesPickOrder_D:IOrd_SalesPickOrder_D
	{
		public Ord_SalesPickOrder_D()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "Ord_SalesPickOrder_D"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ord_SalesPickOrder_D");
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
		public int Add(Edge.SVA.Model.Ord_SalesPickOrder_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ord_SalesPickOrder_D(");
			strSql.Append("SalesPickOrderNumber,ProdCode,OrderQty,ActualQty,StockTypeCode,Remark)");
			strSql.Append(" values (");
			strSql.Append("@SalesPickOrderNumber,@ProdCode,@OrderQty,@ActualQty,@StockTypeCode,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SalesPickOrderNumber", SqlDbType.VarChar,64),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@OrderQty", SqlDbType.Int,4),
					new SqlParameter("@ActualQty", SqlDbType.Int,4),
					new SqlParameter("@StockTypeCode", SqlDbType.VarChar,64),
					new SqlParameter("@Remark", SqlDbType.VarChar,512)};
			parameters[0].Value = model.SalesPickOrderNumber;
			parameters[1].Value = model.ProdCode;
			parameters[2].Value = model.OrderQty;
			parameters[3].Value = model.ActualQty;
			parameters[4].Value = model.StockTypeCode;
			parameters[5].Value = model.Remark;

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
		public bool Update(Edge.SVA.Model.Ord_SalesPickOrder_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ord_SalesPickOrder_D set ");
			strSql.Append("SalesPickOrderNumber=@SalesPickOrderNumber,");
			strSql.Append("ProdCode=@ProdCode,");
			strSql.Append("OrderQty=@OrderQty,");
			strSql.Append("ActualQty=@ActualQty,");
			strSql.Append("StockTypeCode=@StockTypeCode,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@SalesPickOrderNumber", SqlDbType.VarChar,64),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@OrderQty", SqlDbType.Int,4),
					new SqlParameter("@ActualQty", SqlDbType.Int,4),
					new SqlParameter("@StockTypeCode", SqlDbType.VarChar,64),
					new SqlParameter("@Remark", SqlDbType.VarChar,512),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.SalesPickOrderNumber;
			parameters[1].Value = model.ProdCode;
			parameters[2].Value = model.OrderQty;
			parameters[3].Value = model.ActualQty;
			parameters[4].Value = model.StockTypeCode;
			parameters[5].Value = model.Remark;
			parameters[6].Value = model.KeyID;

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
			strSql.Append("delete from Ord_SalesPickOrder_D ");
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

        public bool Delete(string SalesPickOrderNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ord_SalesPickOrder_D ");
            strSql.Append(" where SalesPickOrderNumber=@SalesPickOrderNumber");
            SqlParameter[] parameters = {
					new SqlParameter("@SalesPickOrderNumber", SqlDbType.VarChar,64)
			};
            parameters[0].Value = SalesPickOrderNumber;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
			strSql.Append("delete from Ord_SalesPickOrder_D ");
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
		public Edge.SVA.Model.Ord_SalesPickOrder_D GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,SalesPickOrderNumber,ProdCode,OrderQty,ActualQty,StockTypeCode,Remark from Ord_SalesPickOrder_D ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.Ord_SalesPickOrder_D model=new Edge.SVA.Model.Ord_SalesPickOrder_D();
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
		public Edge.SVA.Model.Ord_SalesPickOrder_D DataRowToModel(DataRow row)
		{
			Edge.SVA.Model.Ord_SalesPickOrder_D model=new Edge.SVA.Model.Ord_SalesPickOrder_D();
			if (row != null)
			{
				if(row["KeyID"]!=null && row["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(row["KeyID"].ToString());
				}
				if(row["SalesPickOrderNumber"]!=null)
				{
					model.SalesPickOrderNumber=row["SalesPickOrderNumber"].ToString();
				}
				if(row["ProdCode"]!=null)
				{
					model.ProdCode=row["ProdCode"].ToString();
				}
				if(row["OrderQty"]!=null && row["OrderQty"].ToString()!="")
				{
					model.OrderQty=int.Parse(row["OrderQty"].ToString());
				}
				if(row["ActualQty"]!=null && row["ActualQty"].ToString()!="")
				{
					model.ActualQty=int.Parse(row["ActualQty"].ToString());
				}
				if(row["StockTypeCode"]!=null)
				{
					model.StockTypeCode=row["StockTypeCode"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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
			strSql.Append("select KeyID,SalesPickOrderNumber,ProdCode,OrderQty,ActualQty,StockTypeCode,Remark ");
			strSql.Append(" FROM Ord_SalesPickOrder_D ");
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
			strSql.Append(" KeyID,SalesPickOrderNumber,ProdCode,OrderQty,ActualQty,StockTypeCode,Remark ");
			strSql.Append(" FROM Ord_SalesPickOrder_D ");
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
			strSql.Append("select count(1) FROM Ord_SalesPickOrder_D ");
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
			strSql.Append(")AS Row, T.*  from Ord_SalesPickOrder_D T ");
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
			parameters[0].Value = "Ord_SalesPickOrder_D";
			parameters[1].Value = "KeyID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        /// <summary>
        /// 求总库存数量
        /// 创建人：Lisa
        /// 创建时间：2016-06-02
        /// </summary>
        /// <returns></returns>
        public DataSet GetSummary(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(OrderQty) as OrderQty,sum(ActualQty)as ActualQty ");
            strSql.Append(" FROM Ord_SalesPickOrder_D ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
		#endregion  BasicMethod
	}
}

