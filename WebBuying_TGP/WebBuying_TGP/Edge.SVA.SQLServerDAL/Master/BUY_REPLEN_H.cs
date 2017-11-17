using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:BUY_REPLEN_H
    /// 创建人：lisa
    /// 创建时间：2016-07-13
    /// </summary>
    public partial class BUY_REPLEN_H : IBUY_REPLEN_H
    {
        public BUY_REPLEN_H()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ReplenCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BUY_REPLEN_H");
            strSql.Append(" where ReplenCode=@ReplenCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@ReplenCode", SqlDbType.VarChar,64)			};
            parameters[0].Value = ReplenCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Edge.SVA.Model.BUY_REPLEN_H model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BUY_REPLEN_H(");
            strSql.Append("ReplenCode,UseReplenFormula,StoreID,TargetType,OrderTargetID,StartDate,EndDate,Status,Priority,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,ReplenFormulaID)");
            strSql.Append(" values (");
            strSql.Append("@ReplenCode,@UseReplenFormula,@StoreID,@TargetType,@OrderTargetID,@StartDate,@EndDate,@Status,@Priority,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@ReplenFormulaID)");
            SqlParameter[] parameters = {
					new SqlParameter("@ReplenCode", SqlDbType.VarChar,64),
					new SqlParameter("@UseReplenFormula", SqlDbType.Int,4),
					new SqlParameter("@StoreID", SqlDbType.Int,4),
					new SqlParameter("@TargetType", SqlDbType.Int,4),
					new SqlParameter("@OrderTargetID", SqlDbType.Int,4),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Priority", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
                    new SqlParameter("@ReplenFormulaID", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.ReplenCode;
            parameters[1].Value = model.UseReplenFormula;
            parameters[2].Value = model.StoreID;
            parameters[3].Value = model.TargetType;
            parameters[4].Value = model.OrderTargetID;
            parameters[5].Value = model.StartDate;
            parameters[6].Value = model.EndDate;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.Priority;
            parameters[9].Value = model.CreatedOn;
            parameters[10].Value = model.CreatedBy;
            parameters[11].Value = model.UpdatedOn;
            parameters[12].Value = model.UpdatedBy;
            parameters[13].Value = model.ReplenFormulaID;
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
        /// 更新一条数据
        /// </summary>
        public bool Update(Edge.SVA.Model.BUY_REPLEN_H model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BUY_REPLEN_H set ");
            strSql.Append("UseReplenFormula=@UseReplenFormula,");
            strSql.Append("StoreID=@StoreID,");
            strSql.Append("TargetType=@TargetType,");
            strSql.Append("OrderTargetID=@OrderTargetID,");
            strSql.Append("StartDate=@StartDate,");
            strSql.Append("EndDate=@EndDate,");
            strSql.Append("Status=@Status,");
            strSql.Append("Priority=@Priority,");
            strSql.Append("CreatedOn=@CreatedOn,");
            strSql.Append("CreatedBy=@CreatedBy,");
            strSql.Append("UpdatedOn=@UpdatedOn,");
            strSql.Append("UpdatedBy=@UpdatedBy,");
            strSql.Append("ReplenFormulaID=@ReplenFormulaID");
            strSql.Append(" where ReplenCode=@ReplenCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@UseReplenFormula", SqlDbType.Int,4),
					new SqlParameter("@StoreID", SqlDbType.Int,4),
					new SqlParameter("@TargetType", SqlDbType.Int,4),
					new SqlParameter("@OrderTargetID", SqlDbType.Int,4),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Priority", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
                    new SqlParameter("@ReplenFormulaID", SqlDbType.Int,4),
					new SqlParameter("@ReplenCode", SqlDbType.VarChar,64)};
            parameters[0].Value = model.UseReplenFormula;
            parameters[1].Value = model.StoreID;
            parameters[2].Value = model.TargetType;
            parameters[3].Value = model.OrderTargetID;
            parameters[4].Value = model.StartDate;
            parameters[5].Value = model.EndDate;
            parameters[6].Value = model.Status;
            parameters[7].Value = model.Priority;
            parameters[8].Value = model.CreatedOn;
            parameters[9].Value = model.CreatedBy;
            parameters[10].Value = model.UpdatedOn;
            parameters[11].Value = model.UpdatedBy;
            parameters[12].Value = model.ReplenFormulaID;
            parameters[13].Value = model.ReplenCode;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ReplenCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BUY_REPLEN_H ");
            strSql.Append(" where ReplenCode=@ReplenCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@ReplenCode", SqlDbType.VarChar,64)			};
            parameters[0].Value = ReplenCode;

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
        public bool DeleteList(string ReplenCodelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BUY_REPLEN_H ");
            strSql.Append(" where ReplenCode in (" + ReplenCodelist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Edge.SVA.Model.BUY_REPLEN_H GetModel(string ReplenCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ReplenCode,UseReplenFormula,ReplenFormulaID,StoreID,TargetType,OrderTargetID,StartDate,EndDate,Status,Priority,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_REPLEN_H ");
            strSql.Append(" where ReplenCode=@ReplenCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@ReplenCode", SqlDbType.VarChar,64)			};
            parameters[0].Value = ReplenCode;

            Edge.SVA.Model.BUY_REPLEN_H model = new Edge.SVA.Model.BUY_REPLEN_H();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ReplenCode"] != null && ds.Tables[0].Rows[0]["ReplenCode"].ToString() != "")
                {
                    model.ReplenCode = ds.Tables[0].Rows[0]["ReplenCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UseReplenFormula"] != null && ds.Tables[0].Rows[0]["UseReplenFormula"].ToString() != "")
                {
                    model.UseReplenFormula = int.Parse(ds.Tables[0].Rows[0]["UseReplenFormula"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReplenFormulaID"] != null && ds.Tables[0].Rows[0]["ReplenFormulaID"].ToString() != "")
                {
                    model.ReplenFormulaID = int.Parse(ds.Tables[0].Rows[0]["ReplenFormulaID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoreID"] != null && ds.Tables[0].Rows[0]["StoreID"].ToString() != "")
                {
                    model.StoreID = int.Parse(ds.Tables[0].Rows[0]["StoreID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TargetType"] != null && ds.Tables[0].Rows[0]["TargetType"].ToString() != "")
                {
                    model.TargetType = int.Parse(ds.Tables[0].Rows[0]["TargetType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderTargetID"] != null && ds.Tables[0].Rows[0]["OrderTargetID"].ToString() != "")
                {
                    model.OrderTargetID = int.Parse(ds.Tables[0].Rows[0]["OrderTargetID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StartDate"] != null && ds.Tables[0].Rows[0]["StartDate"].ToString() != "")
                {
                    model.StartDate = DateTime.Parse(ds.Tables[0].Rows[0]["StartDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndDate"] != null && ds.Tables[0].Rows[0]["EndDate"].ToString() != "")
                {
                    model.EndDate = DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Priority"] != null && ds.Tables[0].Rows[0]["Priority"].ToString() != "")
                {
                    model.Priority = int.Parse(ds.Tables[0].Rows[0]["Priority"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedOn"] != null && ds.Tables[0].Rows[0]["CreatedOn"].ToString() != "")
                {
                    model.CreatedOn = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedBy"] != null && ds.Tables[0].Rows[0]["CreatedBy"].ToString() != "")
                {
                    model.CreatedBy = int.Parse(ds.Tables[0].Rows[0]["CreatedBy"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdatedOn"] != null && ds.Tables[0].Rows[0]["UpdatedOn"].ToString() != "")
                {
                    model.UpdatedOn = DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdatedBy"] != null && ds.Tables[0].Rows[0]["UpdatedBy"].ToString() != "")
                {
                    model.UpdatedBy = int.Parse(ds.Tables[0].Rows[0]["UpdatedBy"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ReplenCode,UseReplenFormula,ReplenFormulaID,StoreID,TargetType,OrderTargetID,StartDate,EndDate,Status,Priority,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
            strSql.Append(" FROM BUY_REPLEN_H ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ReplenCode,UseReplenFormula,ReplenFormulaID,StoreID,TargetType,OrderTargetID,StartDate,EndDate,Status,Priority,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
            strSql.Append(" FROM BUY_REPLEN_H ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM BUY_REPLEN_H ");
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
                strSql.Append("order by T.ReplenCode desc");
            }
            strSql.Append(")AS Row, T.*  from BUY_REPLEN_H T ");
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
            parameters[0].Value = "BUY_REPLEN_H";
            parameters[1].Value = "ReplenCode";
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

