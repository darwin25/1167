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
    public partial class STK_STake_H : ISTK_STake_H
    {
        public STK_STake_H()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("StockTakeID", "STK_STake_H");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string StockTakeNumber, int StockTakeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from STK_STake_H");
            strSql.Append(" where StockTakeNumber=@StockTakeNumber and StockTakeID=@StockTakeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StockTakeNumber", SqlDbType.VarChar,64),
					new SqlParameter("@StockTakeID", SqlDbType.Int,4)			};
            parameters[0].Value = StockTakeNumber;
            parameters[1].Value = StockTakeID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Edge.SVA.Model.STK_STake_H model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into STK_STake_H(");
            strSql.Append("StockTakeNumber,StockTakeDate,StoreID,Status,StockTakeType,Remark,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
            strSql.Append(" values (");
            strSql.Append("@StockTakeNumber,@StockTakeDate,@StoreID,@Status,@StockTakeType,@Remark,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StockTakeNumber", SqlDbType.VarChar,64),
					new SqlParameter("@StockTakeDate", SqlDbType.DateTime),
        				new SqlParameter("@StoreID", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@StockTakeType", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,255),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
            parameters[0].Value = model.StockTakeNumber;
            parameters[1].Value = model.StockTakeDate;
            parameters[2].Value = model.StoreID;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.StockTakeType;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.CreatedOn;
            parameters[7].Value = model.CreatedBy;
            parameters[8].Value = model.UpdatedOn;
            parameters[9].Value = model.UpdatedBy;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Edge.SVA.Model.STK_STake_H model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update STK_STake_H set ");
            strSql.Append("StockTakeDate=@StockTakeDate,");
            strSql.Append("StoreID=@StoreID,");
            strSql.Append("Status=@Status,");
            strSql.Append("StockTakeType=@StockTakeType,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("CreatedOn=@CreatedOn,");
            strSql.Append("CreatedBy=@CreatedBy,");
            strSql.Append("UpdatedOn=@UpdatedOn,");
            strSql.Append("UpdatedBy=@UpdatedBy");
            strSql.Append(" where StockTakeID=@StockTakeID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockTakeDate", SqlDbType.DateTime),
        				new SqlParameter("@StoreID", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@StockTakeType", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,255),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
                    new SqlParameter("@StockTakeNumber", SqlDbType.VarChar,64)};
            parameters[0].Value = model.StockTakeDate;
            parameters[1].Value = model.StoreID;
            parameters[2].Value = model.Status;
            parameters[3].Value = model.StockTakeType;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.CreatedOn;
            parameters[6].Value = model.CreatedBy;
            parameters[7].Value = model.UpdatedOn;
            parameters[8].Value = model.UpdatedBy;
            parameters[9].Value = model.StockTakeNumber;

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
        public bool Delete(int StockTakeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from STK_STake_H ");
            strSql.Append(" where StockTakeID=@StockTakeID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockTakeID", SqlDbType.Int,4)
			};
            parameters[0].Value = StockTakeID;

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
        public bool Delete(string StockTakeNumber, int StockTakeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from STK_STake_H ");
            strSql.Append(" where StockTakeNumber=@StockTakeNumber and StockTakeID=@StockTakeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StockTakeNumber", SqlDbType.VarChar,64),
					new SqlParameter("@StockTakeID", SqlDbType.Int,4)			};
            parameters[0].Value = StockTakeNumber;
            parameters[1].Value = StockTakeID;

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
        public bool DeleteList(string StockTakeIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from STK_STake_H ");
            strSql.Append(" where StockTakeID in (" + StockTakeIDlist + ")  ");
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
        public Edge.SVA.Model.STK_STake_H GetModel(int StockTakeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StockTakeID,StockTakeNumber,StockTakeDate,StoreID,Status,StockTakeType,Remark,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from STK_STake_H ");
            strSql.Append(" where StockTakeID=@StockTakeID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockTakeID", SqlDbType.Int,4)
			};
            parameters[0].Value = StockTakeID;

            Edge.SVA.Model.STK_STake_H model = new Edge.SVA.Model.STK_STake_H();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StockTakeID"] != null && ds.Tables[0].Rows[0]["StockTakeID"].ToString() != "")
                {
                    model.StockTakeID = int.Parse(ds.Tables[0].Rows[0]["StockTakeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StockTakeNumber"] != null && ds.Tables[0].Rows[0]["StockTakeNumber"].ToString() != "")
                {
                    model.StockTakeNumber = ds.Tables[0].Rows[0]["StockTakeNumber"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StockTakeDate"] != null && ds.Tables[0].Rows[0]["StockTakeDate"].ToString() != "")
                {
                    model.StockTakeDate = DateTime.Parse(ds.Tables[0].Rows[0]["StockTakeDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoreID"] != null && ds.Tables[0].Rows[0]["StoreID"].ToString() != "")
                {
                    model.StoreID = int.Parse(ds.Tables[0].Rows[0]["StoreID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StockTakeType"] != null && ds.Tables[0].Rows[0]["StockTakeType"].ToString() != "")
                {
                    model.StockTakeType = int.Parse(ds.Tables[0].Rows[0]["StockTakeType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
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
            strSql.Append("select StockTakeID,StockTakeNumber,StockTakeDate,StoreID,Status,StockTakeType,Remark,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
            strSql.Append(" FROM STK_STake_H ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据条件查询列表
        /// 创建人：王丽
        /// 创建时间：2015-12-02
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public DataSet GetListByParm(string strWhere, string filedOrder, string webSiteName,string type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("declare @WebSiteName nvarchar(20) ");
            strSql.AppendFormat(" set @WebSiteName='{0}'", webSiteName);
            strSql.Append("select STK_STake_H.StockTakeNumber, STK_STake_H.StoreID,STK_STake_H.[Status],STK_STake_H.StockTakeType,");
            strSql.Append("case STK_STake_H.StockTakeType when 0 then'盘数量'else  '盘序列号'end SimplifiedStockTakeTypeName,");
            strSql.Append("case STK_STake_H.StockTakeType when 0 then '盤數量'else '盤序列號'end as TraditionalStockTakeTypeName,");
            strSql.Append("case STK_STake_H.StockTakeType when 0 then 'By Quantity'else 'By Serial No'end as EnglishStockTypeName,STK_STake_H.Remark,");
            strSql.Append("Convert(varchar(10),StockTakeDate,120)as StockTakeDate ,");
            strSql.Append("case STK_STake_H.[Status] when 1 then '注册结束' ");
            strSql.Append("when 2 then '第一次盘点结束'");
            strSql.Append("when 3 then '第二次盘点结束'");
            strSql.Append("when 4 then '产生差异表'");
            strSql.Append("else  '盘点结束' end as StatusName,");
            strSql.Append("Convert(varchar(10),STK_STake_H.CreatedOn,120)as CreatedOn,STK_STake_H.CreatedBy,Accounts_Users.UserName as CreatedName,");
            strSql.Append("Convert(varchar(10),STK_STake_H.UpdatedOn,120)as UpdatedOn,STK_STake_H.UpdatedBy,u.UserName as UpdatedName,STK_STAKE_H.StockTakeID,");
            strSql.Append("BUY_PRODUCT.ProdCode,BUY_PRODUCT.ProdDesc1,BUY_PRODUCT.ProdDesc2,BUY_PRODUCT.ProdDesc3,BUY_PRODUCT.DepartCode,");
            if (type == "StockTake01")
            {
                strSql.Append("STK_STAKE01.STOCKTYPE,STK_STAKE01.QTY,STK_STAKE01.[STATUS],STK_STAKE01.SerialNo,STK_STAKE01.SEQ,");
            }
            else if (type == "StockTake02")
            {
                strSql.Append("STK_STake02.STOCKTYPE,STK_STake02.QTY,STK_STake02.[STATUS],STK_STake02.SerialNo,STK_STake02.SEQ,");
            }
            else
            {
                strSql.Append("STK_STAKEVAR.STOCKTYPE,STK_STAKEVAR.SerialNo,STK_STAKEVAR.VARQTY,");
            }
            strSql.Append("BUY_STORE.StoreName1 as EEnglishStoreName ,BUY_STORE.StoreName2 as ESimplifiedStoreName,");
            strSql.Append("BUY_STORE.StoreName3 as ETraditionalStoreName,BUY_STORE.StoreAddressDetail1,");
            strSql.Append("BUY_STORE.Contact,BUY_STORE.ContactPhone,");
            strSql.Append("BUY_PRODUCT.ProdDesc1,BUY_PRODUCT.ProdDesc2,BUY_PRODUCT.ProdDesc3,@WebSiteName as WebSiteName ");
            strSql.Append("from STK_STake_H ");
            if (type == "StockTake01")
            {
                strSql.Append("left join STK_STake01 on STK_STake_H.StockTakeNumber=STK_STake01.StockTakeNumber ");
                strSql.Append("left join BUY_PRODUCT on STK_STake01.ProdCode=BUY_PRODUCT.ProdCode ");
            }
            else if (type == "StockTake02")
            {
                strSql.Append("left join STK_STake02 on STK_STake_H.StockTakeNumber=STK_STake02.StockTakeNumber ");
                strSql.Append("left join BUY_PRODUCT on STK_STake02.ProdCode=BUY_PRODUCT.ProdCode ");
            }
            else
            {
                strSql.Append("left join STK_STAKEVAR on STK_STake_H.StockTakeNumber=STK_STAKEVAR.StockTakeNumber ");
                strSql.Append("left join BUY_PRODUCT on STK_STAKEVAR.ProdCode=BUY_PRODUCT.ProdCode ");
            }
            strSql.Append("left join Accounts_Users on STK_STake_H.CreatedBy=Accounts_Users.UserID ");
            strSql.Append("left join Accounts_Users as u  on STK_STake_H.UpdatedBy=u.UserID ");
            strSql.Append("left join BUY_STORE on STK_STake_H.StoreID=BUY_STORE.StoreID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
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
            strSql.Append(" StockTakeID,StockTakeNumber,StockTakeDate,StoreID,Status,StockTakeType,Remark,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
            strSql.Append(" FROM STK_STake_H ");
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
            strSql.Append("select count(1) FROM STK_STake_H ");
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
                strSql.Append("order by T.StockTakeID desc");
            }
            strSql.Append(")AS Row, T.*  from STK_STake_H T ");
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

