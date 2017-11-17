using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:BUY_BOXSALE
    /// </summary>
    public partial class BUY_BOXSALE : IBUY_BOXSALE
    {
        public BUY_BOXSALE()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("BOMID", "BUY_BOXSALE");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int KeyID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BUY_BOXSALE");
            strSql.Append(" where BOMID=@BOMID");
            SqlParameter[] parameters = {
					new SqlParameter("@BOMID", SqlDbType.Int,4)
			};
            parameters[0].Value = KeyID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Edge.SVA.Model.BUY_BOXSALE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BUY_BOXSALE(");
            strSql.Append("BOMCode,ProdCode,Qty,MinQty,MaxQty,DefaultQty,Price,PartValue,ValueType,ActPrice,StartDate,EndDate,MutexTag,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
            strSql.Append(" values (");
            strSql.Append("@BOMCode,@ProdCode,@Qty,@MinQty,@MaxQty,@DefaultQty,@Price,@PartValue,@ValueType,@ActPrice,@StartDate,@EndDate,@MutexTag,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@BOMCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@Qty", SqlDbType.Decimal,9),
					new SqlParameter("@MinQty", SqlDbType.Int,4),
					new SqlParameter("@MaxQty", SqlDbType.Int,4),
					new SqlParameter("@DefaultQty", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@PartValue", SqlDbType.Decimal,9),
					new SqlParameter("@ValueType", SqlDbType.Int,4),
					new SqlParameter("@ActPrice", SqlDbType.Decimal,9),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@MutexTag", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
            parameters[0].Value = model.BOMCode;
            parameters[1].Value = model.ProdCode;
            parameters[2].Value = model.Qty;
            parameters[3].Value = model.MinQty;
            parameters[4].Value = model.MaxQty;
            parameters[5].Value = model.DefaultQty;
            parameters[6].Value = model.Price;
            parameters[7].Value = model.PartValue;
            parameters[8].Value = model.ValueType;
            parameters[9].Value = model.ActPrice;
            parameters[10].Value = model.StartDate;
            parameters[11].Value = model.EndDate;
            parameters[12].Value = model.MutexTag;
            parameters[13].Value = model.CreatedOn;
            parameters[14].Value = model.CreatedBy;
            parameters[15].Value = model.UpdatedOn;
            parameters[16].Value = model.UpdatedBy;

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
        public bool Update(Edge.SVA.Model.BUY_BOXSALE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BUY_BOXSALE set ");
            strSql.Append("BOMCode=@BOMCode,");
            strSql.Append("ProdCode=@ProdCode,");
            strSql.Append("Qty=@Qty,");
            strSql.Append("MinQty=@MinQty,");
            strSql.Append("MaxQty=@MaxQty,");
            strSql.Append("DefaultQty=@DefaultQty,");
            strSql.Append("Price=@Price,");
            strSql.Append("PartValue=@PartValue,");
            strSql.Append("ValueType=@ValueType,");
            strSql.Append("ActPrice=@ActPrice,");
            strSql.Append("StartDate=@StartDate,");
            strSql.Append("EndDate=@EndDate,");
            strSql.Append("MutexTag=@MutexTag,");
            strSql.Append("CreatedOn=@CreatedOn,");
            strSql.Append("CreatedBy=@CreatedBy,");
            strSql.Append("UpdatedOn=@UpdatedOn,");
            strSql.Append("UpdatedBy=@UpdatedBy");
            strSql.Append(" where BOMID=@BOMID");
            SqlParameter[] parameters = {
					new SqlParameter("@BOMCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@Qty", SqlDbType.Decimal,9),
					new SqlParameter("@MinQty", SqlDbType.Int,4),
					new SqlParameter("@MaxQty", SqlDbType.Int,4),
					new SqlParameter("@DefaultQty", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@PartValue", SqlDbType.Decimal,9),
					new SqlParameter("@ValueType", SqlDbType.Int,4),
					new SqlParameter("@ActPrice", SqlDbType.Decimal,9),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@MutexTag", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@BOMID", SqlDbType.Int,4)};
            parameters[0].Value = model.BOMCode;
            parameters[1].Value = model.ProdCode;
            parameters[2].Value = model.Qty;
            parameters[3].Value = model.MinQty;
            parameters[4].Value = model.MaxQty;
            parameters[5].Value = model.DefaultQty;
            parameters[6].Value = model.Price;
            parameters[7].Value = model.PartValue;
            parameters[8].Value = model.ValueType;
            parameters[9].Value = model.ActPrice;
            parameters[10].Value = model.StartDate;
            parameters[11].Value = model.EndDate;
            parameters[12].Value = model.MutexTag;
            parameters[13].Value = model.CreatedOn;
            parameters[14].Value = model.CreatedBy;
            parameters[15].Value = model.UpdatedOn;
            parameters[16].Value = model.UpdatedBy;
            parameters[17].Value = model.BOMID;

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
        public bool Delete(int KeyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BUY_BOXSALE ");
            strSql.Append(" where BOMID=@BOMID");
            SqlParameter[] parameters = {
					new SqlParameter("@BOMID", SqlDbType.Int,4)
			};
            parameters[0].Value = KeyID;

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
        public bool DeleteList(string KeyIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BUY_BOXSALE ");
            strSql.Append(" where BOMID in (" + KeyIDlist + ")  ");
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
        public Edge.SVA.Model.BUY_BOXSALE GetModel(int KeyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BOMID,BOMCode,ProdCode,Qty,MinQty,MaxQty,DefaultQty,Price,PartValue,ValueType,ActPrice,StartDate,EndDate,MutexTag,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_BOXSALE ");
            strSql.Append(" where BOMID=@BOMID");
            SqlParameter[] parameters = {
					new SqlParameter("@BOMID", SqlDbType.Int,4)
			};
            parameters[0].Value = KeyID;

            Edge.SVA.Model.BUY_BOXSALE model = new Edge.SVA.Model.BUY_BOXSALE();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["BOMID"] != null && ds.Tables[0].Rows[0]["BOMID"].ToString() != "")
                {
                    model.BOMID = int.Parse(ds.Tables[0].Rows[0]["BOMID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BOMCode"] != null && ds.Tables[0].Rows[0]["BOMCode"].ToString() != "")
                {
                    model.BOMCode = ds.Tables[0].Rows[0]["BOMCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProdCode"] != null && ds.Tables[0].Rows[0]["ProdCode"].ToString() != "")
                {
                    model.ProdCode = ds.Tables[0].Rows[0]["ProdCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Qty"] != null && ds.Tables[0].Rows[0]["Qty"].ToString() != "")
                {
                    model.Qty = decimal.Parse(ds.Tables[0].Rows[0]["Qty"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MinQty"] != null && ds.Tables[0].Rows[0]["MinQty"].ToString() != "")
                {
                    model.MinQty = int.Parse(ds.Tables[0].Rows[0]["MinQty"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MaxQty"] != null && ds.Tables[0].Rows[0]["MaxQty"].ToString() != "")
                {
                    model.MaxQty = int.Parse(ds.Tables[0].Rows[0]["MaxQty"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DefaultQty"] != null && ds.Tables[0].Rows[0]["DefaultQty"].ToString() != "")
                {
                    model.DefaultQty = int.Parse(ds.Tables[0].Rows[0]["DefaultQty"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"] != null && ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PartValue"] != null && ds.Tables[0].Rows[0]["PartValue"].ToString() != "")
                {
                    model.PartValue = decimal.Parse(ds.Tables[0].Rows[0]["PartValue"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ValueType"] != null && ds.Tables[0].Rows[0]["ValueType"].ToString() != "")
                {
                    model.ValueType = int.Parse(ds.Tables[0].Rows[0]["ValueType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ActPrice"] != null && ds.Tables[0].Rows[0]["ActPrice"].ToString() != "")
                {
                    model.ActPrice = decimal.Parse(ds.Tables[0].Rows[0]["ActPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StartDate"] != null && ds.Tables[0].Rows[0]["StartDate"].ToString() != "")
                {
                    model.StartDate = DateTime.Parse(ds.Tables[0].Rows[0]["StartDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndDate"] != null && ds.Tables[0].Rows[0]["EndDate"].ToString() != "")
                {
                    model.EndDate = DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MutexTag"] != null && ds.Tables[0].Rows[0]["MutexTag"].ToString() != "")
                {
                    model.MutexTag = int.Parse(ds.Tables[0].Rows[0]["MutexTag"].ToString());
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
            strSql.Append("select BOMID,BOMCode,ProdCode,Qty,MinQty,MaxQty,DefaultQty,Price,PartValue,ValueType,ActPrice,StartDate,EndDate,MutexTag,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
            strSql.Append(" FROM BUY_BOXSALE ");
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
            strSql.Append(" BOMID,BOMCode,ProdCode,Qty,MinQty,MaxQty,DefaultQty,Price,PartValue,ValueType,ActPrice,StartDate,EndDate,MutexTag,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
            strSql.Append(" FROM BUY_BOXSALE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder)
        {
            /*
             *    @tblName varchar(255),   -- 表名 
                  @fldName varchar(255),   -- 显示字段名 
                  @OrderfldName varchar(255),  -- 排序字段名 
                  @StatfldName varchar(255),  -- 统计字段名 
                  @PageSize int = 10,   -- 页尺寸 
                  @PageIndex int = 1,   -- 页码 
                  @IsReCount bit = 0,   -- 返回记录总数, 非 0 值则返回 
                  @OrderType bit = 0,   -- 设置排序类型, 非 0 值则降序 
                  @strWhere varchar(1000) = ''  -- 查询条件 (注意: 不要加 where) */
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
            parameters[0].Value = "BUY_BOXSALE";
            parameters[1].Value = "*";
            parameters[2].Value = filedOrder;
            parameters[3].Value = "";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 0;
            parameters[7].Value = 0;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPageOrder", parameters, "ds");
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) FROM BUY_BOXSALE ");
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
                strSql.Append("order by T.BOMID desc");
            }
            strSql.Append(")AS Row, T.*  from BUY_BOXSALE T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  Method
    }
}

