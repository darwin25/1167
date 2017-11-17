using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:STK_STake_H
	/// </summary>
	public partial class STK_STake01:ISTK_STake01
	{
        public STK_STake01()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID("SEQ", "STK_STake01"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string StockTakeNumber, int StoreID, string ProdCode, string SerialNo)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) from STK_STake01");
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
        public int Add(Edge.SVA.Model.STK_STAKE01 model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into STK_STake01(");
            strSql.Append("StoreID, StockTakeNumber, ProdCode, StockType, QTY, Status, SerialNo, SEQ, CreatedOn)");
			strSql.Append(" values (");
            strSql.Append("@StoreID, @StockTakeNumber, @ProdCode, @StockType, @QTY, @Status, @SerialNo, @SEQ, @CreatedOn)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
                    new SqlParameter("@StoreID", SqlDbType.Int,4),
					new SqlParameter("@StockTakeNumber", SqlDbType.VarChar,64),
                    new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
                    new SqlParameter("@StockType", SqlDbType.VarChar,64),
                    new SqlParameter("@QTY", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@SerialNo", SqlDbType.VarChar,64),
					new SqlParameter("@SEQ", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime)};
			parameters[0].Value = model.StoreID;
			parameters[1].Value = model.StockTakeNumber;
			parameters[2].Value = model.ProdCode;
			parameters[3].Value = model.StockType;
            parameters[4].Value = model.QTY;
			parameters[5].Value = model.Status;
			parameters[6].Value = model.SerialNo;
			parameters[7].Value = model.SEQ;
			parameters[8].Value = model.CreatedOn;

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
        public bool Update(Edge.SVA.Model.STK_STAKE01 model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update STK_STake01 set ");
            strSql.Append("QTY=@QTY,");
            strSql.Append("CreatedOn=@CreatedOn ");
            strSql.Append(" where StockTakeNumber = @StockTakeNumber and ProdCode = @ProdCode and StockType = @StockType and SerialNo = @SerialNo");
			
			SqlParameter[] parameters = {
					new SqlParameter("@QTY", SqlDbType.Int, 4),
                    new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@StockTakeNumber", SqlDbType.VarChar,64),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
                    new SqlParameter("@StockType", SqlDbType.VarChar,64),
				    new SqlParameter("@SerialNo", SqlDbType.VarChar,64) };
            parameters[0].Value = model.QTY;
            parameters[1].Value = model.CreatedOn;
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
			strSql.Append("delete from STK_STake01 ");
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
			strSql.Append("delete from STK_STake01 ");
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
			strSql.Append("delete from STK_STake01 ");
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
        public Edge.SVA.Model.STK_STAKE01 GetModel(string StockTakeNumber, int StoreID, string ProdCode, string StoreType, string SerialNo)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select top 1 StoreID, StockTakeNumber, ProdCode, StockType, QTY, Status, SerialNo, SEQ, CreatedOn from STK_STake01 ");
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

            Edge.SVA.Model.STK_STAKE01 model = new Edge.SVA.Model.STK_STAKE01();
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
                if (ds.Tables[0].Rows[0]["QTY"] != null && ds.Tables[0].Rows[0]["QTY"].ToString() != "")
                {
                    model.QTY = int.Parse(ds.Tables[0].Rows[0]["QTY"].ToString());
                }
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
                if (ds.Tables[0].Rows[0]["SerialNo"] != null && ds.Tables[0].Rows[0]["SerialNo"].ToString() != "")
                {
                    model.SerialNo = ds.Tables[0].Rows[0]["SerialNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SEQ"] != null && ds.Tables[0].Rows[0]["SEQ"].ToString() != "")
				{
                    model.SEQ = int.Parse(ds.Tables[0].Rows[0]["SEQ"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedOn"]!=null && ds.Tables[0].Rows[0]["CreatedOn"].ToString()!="")
				{
					model.CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
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
            strSql.Append("select StoreID, StockTakeNumber, ProdCode, StockType, QTY, Status, SerialNo, SEQ, CreatedOn ");
            strSql.Append(" FROM STK_STake01 ");
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
            strSql.Append(" StoreID, StockTakeNumber, ProdCode, StockType, QTY, Status, SerialNo, SEQ, CreatedOn  ");
            strSql.Append(" FROM STK_STake01 ");
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
            strSql.Append("select count(1) FROM STK_STake01 ");
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
            strSql.Append(")AS Row, T.*  from STK_STake01 T ");
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

