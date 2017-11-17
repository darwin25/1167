using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
    /// 数据访问类:Ord_StoreOrder_D
	/// </summary>
	public partial class Ord_StoreOrder_D:IOrd_StoreOrder_D
	{
        public Ord_StoreOrder_D()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID("Key", "Ord_StoreOrder_D"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ord_StoreOrder_D");
			strSql.Append(" where KeyID=@KeyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
            parameters[0].Value = KeyID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.Ord_StoreOrder_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ord_StoreOrder_D(");
			strSql.Append("StoreOrderNumber,ProdCode,OrderQty)");
			strSql.Append(" values (");
			strSql.Append("@StoreOrderNumber,@ProdCode,@OrderQty)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreOrderNumber", SqlDbType.VarChar,64),
                    new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@OrderQty", SqlDbType.Int,4)};
			parameters[0].Value = model.StoreOrderNumber;
			parameters[1].Value = model.ProdCode;
			parameters[2].Value = model.OrderQty;

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
		public bool Update(Edge.SVA.Model.Ord_StoreOrder_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ord_StoreOrder_D set ");
			strSql.Append("StoreOrderNumber=@StoreOrderNumber,");
			strSql.Append("ProdCode=@ProdCode,");
			strSql.Append("OrderQty=@OrderQty");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreOrderNumber", SqlDbType.VarChar,64),
                    new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@OrderQty", SqlDbType.Int,4),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.StoreOrderNumber;
			parameters[1].Value = model.ProdCode;
			parameters[2].Value = model.OrderQty;
			parameters[3].Value = model.KeyID;

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
			strSql.Append("delete from Ord_StoreOrder_D ");
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
        /// 按单号删除数据
        /// </summary>
        public bool Delete(string StoreOrderNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ord_StoreOrder_D ");
            strSql.Append(" where StoreOrderNumber=@KeyID");
            SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.VarChar,64)
			};
            parameters[0].Value = StoreOrderNumber;

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
			strSql.Append("delete from Ord_StoreOrder_D ");
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
		public Edge.SVA.Model.Ord_StoreOrder_D GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,StoreOrderNumber,ProdCode,OrderQty from Ord_StoreOrder_D ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.Ord_StoreOrder_D model=new Edge.SVA.Model.Ord_StoreOrder_D();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StoreOrderNumber"]!=null && ds.Tables[0].Rows[0]["StoreOrderNumber"].ToString()!="")
				{
					model.StoreOrderNumber=ds.Tables[0].Rows[0]["StoreOrderNumber"].ToString();
				}
                if (ds.Tables[0].Rows[0]["ProdCode"] != null && ds.Tables[0].Rows[0]["ProdCode"].ToString() != "")
                {
                    model.ProdCode = ds.Tables[0].Rows[0]["ProdCode"].ToString();
                }
				if(ds.Tables[0].Rows[0]["OrderQty"]!=null && ds.Tables[0].Rows[0]["OrderQty"].ToString()!="")
				{
					model.OrderQty=int.Parse(ds.Tables[0].Rows[0]["OrderQty"].ToString());
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
            strSql.Append("select KeyID,StoreOrderNumber,d.ProdCode,OrderQty,BUY_RPRICE_M.Price,OrderQty*Price as TotalPrice ");
            strSql.Append(" FROM Ord_StoreOrder_D D ");
            strSql.Append("inner join BUY_PRODUCT P on D.ProdCode=P.ProdCode ");
            strSql.Append("LEFT JOIN (SELECT ProdCode, Price FROM BUY_RPRICE_M ");
            strSql.Append("WHERE Status = 1 AND KeyID IN (SELECT max(KeyID) as KeyID FROM BUY_RPRICE_M Group by ProdCode) ");
            strSql.Append("AND StartDate <= GETDATE() AND EndDate >= GETDATE()) BUY_RPRICE_M on P.ProdCode = BUY_RPRICE_M.ProdCode ");
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
            strSql.Append(" KeyID,StoreOrderNumber,d.ProdCode,OrderQty ");
            strSql.Append(" FROM Ord_StoreOrder_D  ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@OrderfldName",SqlDbType.VarChar,255),
                    new SqlParameter("@StatfldName",SqlDbType.VarChar,255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.NText),
					};
            parameters[0].Value = "Ord_StoreOrder_D";
            parameters[1].Value = "*";
            parameters[2].Value = filedOrder;
            parameters[3].Value = "";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 0;
            parameters[7].Value = 1;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPageOrder", parameters, "ds");
        }

        /// <summary>
        /// 获取行总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select count(*) from Ord_StoreOrder_D ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Ord_StoreOrder_D ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.StoreOrderNumber desc");
            }
            strSql.Append(")AS Row, T.*  from Ord_StoreOrder_D T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 求总库存和总金额
        /// 创建人：Lisa
        /// 创建时间：2016-02-23
        /// </summary>
        /// <returns></returns>
        public DataSet GetSummary(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(isnull(OrderQty,0))as OrderQty,sum(isnull(BUY_RPRICE_M.Price,0)) as Price,sum(isnull(OrderQty*BUY_RPRICE_M.Price,0))as TotalPrice");
            strSql.Append(" FROM Ord_StoreOrder_D D ");
            strSql.Append("inner join BUY_PRODUCT P on D.ProdCode=P.ProdCode ");
            strSql.Append("LEFT JOIN (SELECT ProdCode, Price FROM BUY_RPRICE_M ");
            strSql.Append("WHERE Status = 1 AND KeyID IN (SELECT max(KeyID) as KeyID FROM BUY_RPRICE_M Group by ProdCode) ");
            strSql.Append("AND StartDate <= GETDATE() AND EndDate >= GETDATE()) BUY_RPRICE_M on P.ProdCode = BUY_RPRICE_M.ProdCode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
		#endregion  Method
	}
}

