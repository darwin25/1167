using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:STK_STakeVAR
	/// </summary>
	public partial class STK_STakeVAR:ISTK_STakeVAR
	{
        public STK_STakeVAR()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID("ProdCode", "STK_STakeVAR"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string StockTakeNumber, int StoreID, string ProdCode, string SerialNo)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) from STK_STakeVAR");
            strSql.Append(" where StockTakeNumber=@StockTakeNumber and StoreID=@StoreID and ProdCode = @ProdCode and SerialNo = @SerialNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@StockTakeNumber", SqlDbType.VarChar,64),
					new SqlParameter("@StoreID", SqlDbType.Int,4),	
				    new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@SerialNo", SqlDbType.VarChar,64) };
			parameters[0].Value = StockTakeNumber;
			parameters[1].Value = StoreID;
            parameters[2].Value = ProdCode;
            parameters[3].Value = SerialNo;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(Edge.SVA.Model.STK_STAKEVAR model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into STK_STakeVAR(");
            strSql.Append("StoreID, StockTakeNumber, ProdCode, StockType, VARQTY, SerialNo)");
			strSql.Append(" values (");
            strSql.Append("@StoreID, @StockTakeNumber, @ProdCode, @StockType, @VARQTY, @SerialNo)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
                    new SqlParameter("@StoreID", SqlDbType.Int,4),
					new SqlParameter("@StockTakeNumber", SqlDbType.VarChar,64),
                    new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
                    new SqlParameter("@StockType", SqlDbType.VarChar,64),
					new SqlParameter("@VARQTY", SqlDbType.Int,4),
                    new SqlParameter("@SerialNo", SqlDbType.VarChar,64)};
			parameters[0].Value = model.StoreID;
			parameters[1].Value = model.StockTakeNumber;
			parameters[2].Value = model.ProdCode;
			parameters[3].Value = model.StockType;
            parameters[4].Value = model.VARQTY;
			parameters[5].Value = model.SerialNo;

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
        public bool Update(Edge.SVA.Model.STK_STAKEVAR model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update STK_STakeVAR set ");
            strSql.Append("VARQTY=@VARQTY");
            strSql.Append(" where StockTakeNumber = @StockTakeNumber and ProdCode = @ProdCode and StockType = @StockType and SerialNo = @SerialNo");
			
			SqlParameter[] parameters = {
					new SqlParameter("@VARQTY", SqlDbType.Int, 4),
					new SqlParameter("@StockTakeNumber", SqlDbType.VarChar,64),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
                    new SqlParameter("@StockType", SqlDbType.VarChar,64),
				    new SqlParameter("@SerialNo", SqlDbType.VarChar,64) };
            parameters[0].Value = model.VARQTY;
            parameters[2].Value = model.StockTakeNumber;
            parameters[3].Value = model.ProdCode;
            parameters[4].Value = model.StockType;
            parameters[5].Value = model.SerialNo;

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
        public bool Delete(string StockTakeNumber, int StoreID, string ProdCode, string StoreType, string SerialNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from STK_STakeVAR ");
            strSql.Append(" where StoreID=@StoreID and StockTakeNumber = @StockTakeNumber and ProdCode = @ProdCode and StockType = @StockType and SerialNo = @SerialNo");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreID", SqlDbType.Int,4),
					new SqlParameter("@StockTakeNumber", SqlDbType.VarChar,64),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
                    new SqlParameter("@StockType", SqlDbType.VarChar,64),
				    new SqlParameter("@SerialNo", SqlDbType.VarChar,64)
			};
            parameters[0].Value = StoreID;
            parameters[1].Value = StockTakeNumber;
            parameters[2].Value = ProdCode;
            parameters[3].Value = StoreType;
            parameters[4].Value = SerialNo;

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
        public bool Delete(string StockTakeNumber)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from STK_STakeVAR ");
            strSql.Append(" where StockTakeNumber=@StockTakeNumber");
			SqlParameter[] parameters = {
					new SqlParameter("@StockTakeNumber", SqlDbType.VarChar,64)};
			parameters[0].Value = StockTakeNumber;

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
        public bool DeleteList(string StockTakeNumber)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from STK_STakeVAR ");
            strSql.Append(" where StockTakeNumber = '" + StockTakeNumber + "'");
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
        public Edge.SVA.Model.STK_STAKEVAR GetModel(string StockTakeNumber, int StoreID, string ProdCode, string StoreType, string SerialNo)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select top 1 StoreID, StockTakeNumber, ProdCode, StockType, VARQTY, SerialNo from STK_STakeVAR ");
            strSql.Append(" where StoreID=@StoreID and StockTakeNumber = @StockTakeNumber and ProdCode = @ProdCode and StockType = @StockType and SerialNo = @SerialNo");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreID", SqlDbType.Int,4),
					new SqlParameter("@StockTakeNumber", SqlDbType.VarChar,64),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
                    new SqlParameter("@StockType", SqlDbType.VarChar,64),
				    new SqlParameter("@SerialNo", SqlDbType.VarChar,64)
			};
            parameters[0].Value = StoreID;
            parameters[1].Value = StockTakeNumber;
            parameters[2].Value = ProdCode;
            parameters[3].Value = StoreType;
            parameters[4].Value = SerialNo;

            Edge.SVA.Model.STK_STAKEVAR model = new Edge.SVA.Model.STK_STAKEVAR();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
                if (ds.Tables[0].Rows[0]["StoreID"] != null && ds.Tables[0].Rows[0]["StoreID"].ToString() != "")
                {
                    model.StoreID = int.Parse(ds.Tables[0].Rows[0]["StoreID"].ToString());
                }
				if(ds.Tables[0].Rows[0]["StockTakeNumber"]!=null && ds.Tables[0].Rows[0]["StockTakeNumber"].ToString()!="")
				{
					model.StockTakeNumber=ds.Tables[0].Rows[0]["StockTakeNumber"].ToString();
				}
                if (ds.Tables[0].Rows[0]["ProdCode"] != null && ds.Tables[0].Rows[0]["ProdCode"].ToString() != "")
                {
                    model.ProdCode = ds.Tables[0].Rows[0]["ProdCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StockType"] != null && ds.Tables[0].Rows[0]["StockType"].ToString() != "")
                {
                    model.StockType = ds.Tables[0].Rows[0]["StockType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["VARQTY"] != null && ds.Tables[0].Rows[0]["VARQTY"].ToString() != "")
                {
                    model.VARQTY = int.Parse(ds.Tables[0].Rows[0]["VARQTY"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SerialNo"] != null && ds.Tables[0].Rows[0]["SerialNo"].ToString() != "")
                {
                    model.SerialNo = ds.Tables[0].Rows[0]["SerialNo"].ToString();
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
            strSql.Append("select StoreID, StockTakeNumber, ProdCode, StockType, VARQTY, SerialNo ");
            strSql.Append(" FROM STK_STakeVAR ");
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
            strSql.Append(" StoreID, StockTakeNumber, ProdCode, StockType, VARQTY, SerialNo ");
            strSql.Append(" FROM STK_STakeVAR ");
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
            strSql.Append("select count(1) FROM STK_STakeVAR ");
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
				strSql.Append("order by T.ProdCode desc");
			}
            strSql.Append(")AS Row, T.*  from STK_STakeVAR T ");
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
			parameters[0].Value = "STK_STake_H";
			parameters[1].Value = "StockTakeID";
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

