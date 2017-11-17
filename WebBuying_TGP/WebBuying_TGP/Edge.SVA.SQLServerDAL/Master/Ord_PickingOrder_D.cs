using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
    /// 数据访问类:Ord_PickingOrder_D
	/// </summary>
	public partial class Ord_PickingOrder_D:IOrd_PickingOrder_D
	{
        public Ord_PickingOrder_D()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID("Key", "Ord_PickingOrder_D"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ord_PickingOrder_D");
			strSql.Append(" where KeyID=@KeyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
            parameters[0].Value = KeyID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.Ord_PickingOrder_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ord_PickingOrder_D(");
			strSql.Append("PickingOrderNumber,ProdCode,OrderQty,ActualQty,Remark)");
			strSql.Append(" values (");
			strSql.Append("@PickingOrderNumber,@ProdCode,@OrderQty,@ActualQty,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PickingOrderNumber", SqlDbType.VarChar,64),
                    new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@OrderQty", SqlDbType.Int,4),
                    new SqlParameter("@ActualQty", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.VarChar,512),};
			parameters[0].Value = model.PickingOrderNumber;
			parameters[1].Value = model.ProdCode;
			parameters[2].Value = model.OrderQty;
            parameters[3].Value = model.ActualQty;
            parameters[4].Value = model.Remark;

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
		public bool Update(Edge.SVA.Model.Ord_PickingOrder_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ord_PickingOrder_D set ");
			strSql.Append("PickingOrderNumber=@PickingOrderNumber,");
			strSql.Append("ProdCode=@ProdCode,");
			strSql.Append("OrderQty=@OrderQty,");
            strSql.Append("ActualQty=@ActualQty,");
            strSql.Append("Remark=@Remark");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@PickingOrderNumber", SqlDbType.VarChar,64),
                    new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@OrderQty", SqlDbType.Int,4),
                    new SqlParameter("@ActualQty", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.VarChar,512),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.PickingOrderNumber;
			parameters[1].Value = model.ProdCode;
			parameters[2].Value = model.OrderQty;
            parameters[3].Value = model.ActualQty;
            parameters[4].Value = model.Remark;
			parameters[5].Value = model.KeyID;

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
			strSql.Append("delete from Ord_PickingOrder_D ");
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
        public bool Delete(string PickingOrderNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ord_PickingOrder_D ");
            strSql.Append(" where PickingOrderNumber=@KeyID");
            SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.VarChar,64)
			};
            parameters[0].Value = PickingOrderNumber;

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
			strSql.Append("delete from Ord_PickingOrder_D ");
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
		public Edge.SVA.Model.Ord_PickingOrder_D GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,PickingOrderNumber,ProdCode,OrderQty,ActualQty,Remark from Ord_PickingOrder_D ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.Ord_PickingOrder_D model=new Edge.SVA.Model.Ord_PickingOrder_D();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PickingOrderNumber"]!=null && ds.Tables[0].Rows[0]["PickingOrderNumber"].ToString()!="")
				{
					model.PickingOrderNumber=ds.Tables[0].Rows[0]["PickingOrderNumber"].ToString();
				}
                if (ds.Tables[0].Rows[0]["ProdCode"] != null && ds.Tables[0].Rows[0]["ProdCode"].ToString() != "")
                {
                    model.ProdCode = ds.Tables[0].Rows[0]["ProdCode"].ToString();
                }
				if(ds.Tables[0].Rows[0]["OrderQty"]!=null && ds.Tables[0].Rows[0]["OrderQty"].ToString()!="")
				{
					model.OrderQty=int.Parse(ds.Tables[0].Rows[0]["OrderQty"].ToString());
				}
                if (ds.Tables[0].Rows[0]["ActualQty"] != null && ds.Tables[0].Rows[0]["ActualQty"].ToString() != "")
                {
                    model.ActualQty = int.Parse(ds.Tables[0].Rows[0]["ActualQty"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
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
            strSql.Append("select KeyID,PickingOrderNumber,ProdCode,OrderQty,ActualQty,Remark ");
			strSql.Append(" FROM Ord_PickingOrder_D ");
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
			strSql.Append(" KeyID,PickingOrderNumber,ProdCode,OrderQty,ActualQty,Remark ");
			strSql.Append(" FROM Ord_PickingOrder_D ");
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
            parameters[0].Value = "Ord_PickingOrder_D";
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
            sql.Append("select count(*) from Ord_PickingOrder_D ");
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
            strSql.Append("select count(1) FROM Ord_PickingOrder_D ");
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
                strSql.Append("order by T.PickingOrderNumber desc");
            }
            strSql.Append(")AS Row, T.*  from Ord_PickingOrder_D T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 求总库存数量
        /// 创建人：Lisa
        /// 创建时间：2016-03-18
        /// </summary>
        /// <returns></returns>
        public DataSet GetSummary(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(OrderQty) as OrderQty,sum(ActualQty)as ActualQty ");
            strSql.Append(" FROM Ord_PickingOrder_D ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
		#endregion  Method
	}
}

