using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:BUY_PO_H
    /// </summary>
    public partial class BUY_PO_H : IBUY_PO_H
    {
        public BUY_PO_H()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string POCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BUY_PO_H");
            strSql.Append(" where POCode=@POCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@POCode", SqlDbType.VarChar,64)			};
            parameters[0].Value = POCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Edge.SVA.Model.BUY_PO_H model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BUY_PO_H(");
            strSql.Append("POCode,OrderType,VendorID,StoreID,CurrencyCode,Note1,Note2,Note3,ExpectDate,TotalAmount,");
            strSql.Append("VATAmount,DiscountAmount,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,");
            strSql.Append("ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
            strSql.Append(" values (");
            strSql.Append("@POCode,@OrderType,@VendorID,@StoreID,@CurrencyCode,@Note1,@Note2,@Note3,@ExpectDate,");
            strSql.Append("@TotalAmount,@VATAmount,@DiscountAmount,@CreatedBusDate,@ApproveBusDate,@ApprovalCode,");
            strSql.Append("@ApproveStatus,@ApproveOn,@ApproveBy,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
            SqlParameter[] parameters = {
					new SqlParameter("@POCode", SqlDbType.VarChar,64),
					new SqlParameter("@OrderType", SqlDbType.Int,4),
					new SqlParameter("@VendorID", SqlDbType.Int,4),
					new SqlParameter("@StoreID", SqlDbType.Int,4),
					new SqlParameter("@CurrencyCode", SqlDbType.VarChar,64),
					new SqlParameter("@Note1", SqlDbType.NVarChar,512),
					new SqlParameter("@Note2", SqlDbType.NVarChar,512),
					new SqlParameter("@Note3", SqlDbType.NVarChar,512),
					new SqlParameter("@ExpectDate", SqlDbType.DateTime),
					new SqlParameter("@TotalAmount", SqlDbType.Decimal,9),
					new SqlParameter("@VATAmount", SqlDbType.Decimal,9),
					new SqlParameter("@DiscountAmount", SqlDbType.Decimal,9),
					new SqlParameter("@CreatedBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApproveBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApprovalCode", SqlDbType.VarChar,64),
					new SqlParameter("@ApproveStatus", SqlDbType.Char,1),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
            parameters[0].Value = model.POCode;
            parameters[1].Value = model.OrderType;
            parameters[2].Value = model.VendorID;
            parameters[3].Value = model.StoreID;
            parameters[4].Value = model.CurrencyCode;
            parameters[5].Value = model.Note1;
            parameters[6].Value = model.Note2;
            parameters[7].Value = model.Note3;
            parameters[8].Value = model.ExpectDate;
            parameters[9].Value = model.TotalAmount;
            parameters[10].Value = model.VATAmount;
            parameters[11].Value = model.DiscountAmount;
            parameters[12].Value = model.CreatedBusDate;
            parameters[13].Value = model.ApproveBusDate;
            parameters[14].Value = model.ApprovalCode;
            parameters[15].Value = model.ApproveStatus;
            parameters[16].Value = model.ApproveOn;
            parameters[17].Value = model.ApproveBy;
            parameters[18].Value = model.CreatedOn;
            parameters[19].Value = model.CreatedBy;
            parameters[20].Value = model.UpdatedOn;
            parameters[21].Value = model.UpdatedBy;

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
        public bool Update(Edge.SVA.Model.BUY_PO_H model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BUY_PO_H set ");
            strSql.Append("OrderType=@OrderType,");
            strSql.Append("VendorID=@VendorID,");
            strSql.Append("StoreID=@StoreID,");
            strSql.Append("CurrencyCode=@CurrencyCode,");
            strSql.Append("Note1=@Note1,");
            strSql.Append("Note2=@Note2,");
            strSql.Append("Note3=@Note3,");
            strSql.Append("ExpectDate=@ExpectDate,");
            strSql.Append("TotalAmount=@TotalAmount,");
            strSql.Append("VATAmount=@VATAmount,");
            strSql.Append("DiscountAmount=@DiscountAmount,");
            strSql.Append("CreatedBusDate=@CreatedBusDate,");
            strSql.Append("ApproveBusDate=@ApproveBusDate,");
            strSql.Append("ApprovalCode=@ApprovalCode,");
            strSql.Append("ApproveStatus=@ApproveStatus,");
            strSql.Append("ApproveOn=@ApproveOn,");
            strSql.Append("ApproveBy=@ApproveBy,");
            strSql.Append("CreatedOn=@CreatedOn,");
            strSql.Append("CreatedBy=@CreatedBy,");
            strSql.Append("UpdatedOn=@UpdatedOn,");
            strSql.Append("UpdatedBy=@UpdatedBy");
            strSql.Append(" where POCode=@POCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderType", SqlDbType.Int,4),
					new SqlParameter("@VendorID", SqlDbType.Int,4),
					new SqlParameter("@StoreID", SqlDbType.Int,4),
					new SqlParameter("@CurrencyCode", SqlDbType.VarChar,64),
					new SqlParameter("@Note1", SqlDbType.NVarChar,512),
					new SqlParameter("@Note2", SqlDbType.NVarChar,512),
					new SqlParameter("@Note3", SqlDbType.NVarChar,512),
					new SqlParameter("@ExpectDate", SqlDbType.DateTime),
					new SqlParameter("@TotalAmount", SqlDbType.Decimal,9),
					new SqlParameter("@VATAmount", SqlDbType.Decimal,9),
					new SqlParameter("@DiscountAmount", SqlDbType.Decimal,9),
					new SqlParameter("@CreatedBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApproveBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApprovalCode", SqlDbType.VarChar,64),
					new SqlParameter("@ApproveStatus", SqlDbType.Char,1),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@POCode", SqlDbType.VarChar,64)};
            parameters[0].Value = model.OrderType;
            parameters[1].Value = model.VendorID;
            parameters[2].Value = model.StoreID;
            parameters[3].Value = model.CurrencyCode;
            parameters[4].Value = model.Note1;
            parameters[5].Value = model.Note2;
            parameters[6].Value = model.Note3;
            parameters[7].Value = model.ExpectDate;
            parameters[8].Value = model.TotalAmount;
            parameters[9].Value = model.VATAmount;
            parameters[10].Value = model.DiscountAmount;
            parameters[11].Value = model.CreatedBusDate;
            parameters[12].Value = model.ApproveBusDate;
            parameters[13].Value = model.ApprovalCode;
            parameters[14].Value = model.ApproveStatus;
            parameters[15].Value = model.ApproveOn;
            parameters[16].Value = model.ApproveBy;
            parameters[17].Value = model.CreatedOn;
            parameters[18].Value = model.CreatedBy;
            parameters[19].Value = model.UpdatedOn;
            parameters[20].Value = model.UpdatedBy;
            parameters[21].Value = model.POCode;

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
        public bool Delete(string POCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BUY_PO_H ");
            strSql.Append(" where POCode=@POCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@POCode", SqlDbType.VarChar,64)			};
            parameters[0].Value = POCode;

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
        public bool DeleteList(string POCodelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BUY_PO_H ");
            strSql.Append(" where POCode in (" + POCodelist + ")  ");
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
        public Edge.SVA.Model.BUY_PO_H GetModel(string POCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 POCode,OrderType,VendorID,StoreID,CurrencyCode,Note1,Note2,Note3,ExpectDate,TotalAmount,VATAmount,");
            strSql.Append("DiscountAmount,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,");
            strSql.Append("UpdatedOn,UpdatedBy from BUY_PO_H  ");
            strSql.Append(" where POCode=@POCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@POCode", SqlDbType.VarChar,64)			};
            parameters[0].Value = POCode;

            Edge.SVA.Model.BUY_PO_H model = new Edge.SVA.Model.BUY_PO_H();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["POCode"] != null && ds.Tables[0].Rows[0]["POCode"].ToString() != "")
                {
                    model.POCode = ds.Tables[0].Rows[0]["POCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderType"] != null && ds.Tables[0].Rows[0]["OrderType"].ToString() != "")
                {
                    model.OrderType = int.Parse(ds.Tables[0].Rows[0]["OrderType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["VendorID"] != null && ds.Tables[0].Rows[0]["VendorID"].ToString() != "")
                {
                    model.VendorID = int.Parse(ds.Tables[0].Rows[0]["VendorID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoreID"] != null && ds.Tables[0].Rows[0]["StoreID"].ToString() != "")
                {
                    model.StoreID = int.Parse(ds.Tables[0].Rows[0]["StoreID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CurrencyCode"] != null && ds.Tables[0].Rows[0]["CurrencyCode"].ToString() != "")
                {
                    model.CurrencyCode = ds.Tables[0].Rows[0]["CurrencyCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Note1"] != null && ds.Tables[0].Rows[0]["Note1"].ToString() != "")
                {
                    model.Note1 = ds.Tables[0].Rows[0]["Note1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Note2"] != null && ds.Tables[0].Rows[0]["Note2"].ToString() != "")
                {
                    model.Note2 = ds.Tables[0].Rows[0]["Note2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Note3"] != null && ds.Tables[0].Rows[0]["Note3"].ToString() != "")
                {
                    model.Note3 = ds.Tables[0].Rows[0]["Note3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ExpectDate"] != null && ds.Tables[0].Rows[0]["ExpectDate"].ToString() != "")
                {
                    model.ExpectDate = DateTime.Parse(ds.Tables[0].Rows[0]["ExpectDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalAmount"] != null && ds.Tables[0].Rows[0]["TotalAmount"].ToString() != "")
                {
                    model.TotalAmount = decimal.Parse(ds.Tables[0].Rows[0]["TotalAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["VATAmount"] != null && ds.Tables[0].Rows[0]["VATAmount"].ToString() != "")
                {
                    model.VATAmount = decimal.Parse(ds.Tables[0].Rows[0]["VATAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DiscountAmount"] != null && ds.Tables[0].Rows[0]["DiscountAmount"].ToString() != "")
                {
                    model.DiscountAmount = decimal.Parse(ds.Tables[0].Rows[0]["DiscountAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedBusDate"] != null && ds.Tables[0].Rows[0]["CreatedBusDate"].ToString() != "")
                {
                    model.CreatedBusDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedBusDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ApproveBusDate"] != null && ds.Tables[0].Rows[0]["ApproveBusDate"].ToString() != "")
                {
                    model.ApproveBusDate = DateTime.Parse(ds.Tables[0].Rows[0]["ApproveBusDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ApprovalCode"] != null && ds.Tables[0].Rows[0]["ApprovalCode"].ToString() != "")
                {
                    model.ApprovalCode = ds.Tables[0].Rows[0]["ApprovalCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ApproveStatus"] != null && ds.Tables[0].Rows[0]["ApproveStatus"].ToString() != "")
                {
                    model.ApproveStatus = ds.Tables[0].Rows[0]["ApproveStatus"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ApproveOn"] != null && ds.Tables[0].Rows[0]["ApproveOn"].ToString() != "")
                {
                    model.ApproveOn = DateTime.Parse(ds.Tables[0].Rows[0]["ApproveOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ApproveBy"] != null && ds.Tables[0].Rows[0]["ApproveBy"].ToString() != "")
                {
                    model.ApproveBy = int.Parse(ds.Tables[0].Rows[0]["ApproveBy"].ToString());
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
            strSql.Append("select POCode,OrderType,VendorID,StoreID,CurrencyCode,Note1,Note2,Note3,ExpectDate,TotalAmount,VATAmount,");
            strSql.Append("DiscountAmount,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,");
            strSql.Append("CreatedBy,UpdatedOn,UpdatedBy ");
            strSql.Append(" FROM BUY_PO_H ");
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
            strSql.Append(" POCode,OrderType,VendorID,StoreID,CurrencyCode,Note1,Note2,Note3,ExpectDate,");
            strSql.Append("TotalAmount,VATAmount,DiscountAmount,CreatedBusDate,ApproveBusDate,");
            strSql.Append("ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
            strSql.Append(" FROM BUY_PO_H ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据条件查询列表
        /// 创建人：王丽
        /// 创建时间：2015-11-30
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public DataSet GetListByParm(string strWhere, string filedOrder,string webSiteName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("declare @WebSiteName nvarchar(20) ");
            strSql.AppendFormat(" set @WebSiteName='{0}'",webSiteName);
            strSql.Append("select BUY_PO_H.POCode,BUY_PO_H.OrderType,");
            strSql.Append("case BUY_PO_H.OrderType when 0 then'手动'else  '自动'end SimplifiedOrderTypeName,");
            strSql.Append("case BUY_PO_H.OrderType when 0 then '手動'else '手動'end as TraditionalOrderTypeName,");
            strSql.Append("case BUY_PO_H.OrderType when 0 then 'Manually'else 'Auto'end as EnglishOrderTypeName,");
            strSql.Append("BUY_PO_H.VendorID,BUY_PO_H.StoreID,CurrencyCode,Note1,Note2,Note3,Convert(varchar(10),ExpectDate,120)as ExpectDate ,");
            strSql.Append("TotalAmount,VATAmount,DiscountAmount,Convert(varchar(10),CreatedBusDate,120)as CreatedBusDate, ");
            strSql.Append("Convert(varchar(10),ApproveBusDate,120)as ApproveBusDate,ApprovalCode,ApproveStatus,");
            strSql.Append("case ApproveStatus when 'P' then 'PENDING' when 'A' then 'APPROVED'else 'VOID' end as ApproveStatusName,");
            strSql.Append("Convert(varchar(10),ApproveOn,120)as ApproveOn ,ApproveBy,u1.UserName as ApproveName ,");
            strSql.Append("Convert(varchar(10),BUY_PO_H.CreatedOn,120)as CreatedOn,BUY_PO_H.CreatedBy,Accounts_Users.UserName as CreatedName ,");
            strSql.Append("Convert(varchar(10),BUY_PO_H.UpdatedOn,120)as UpdatedOn,BUY_PO_H.UpdatedBy,u.UserName as UpdatedName,BUY_PO_D.ProdCode,");
            strSql.Append("BUY_PO_D.Cost,BUY_PO_D.AverageCost,case when BUY_PO_D.UnitCost is null then '0.0000' else BUY_PO_D.UnitCost end as UnitCost,");
            strSql.Append("BUY_PO_D.Qty,BUY_PO_D.FreeQty,BUY_PO_D.GRNQty,BUY_PRODUCT.ProdDesc1,BUY_PRODUCT.ProdDesc2,BUY_PRODUCT.ProdDesc3,");
            strSql.Append("BUY_VENDOR.VendorName1,BUY_VENDOR.Contact as ContactName,BUY_VENDOR.ContactMobile,BUY_VENDOR.VendorAddress1,");
            strSql.Append("BUY_STORE.StoreName1  as EnglishStoreName  ,BUY_STORE.StoreName2 as SimplifiedStoreName,BUY_STORE.StoreName3 as TraditionalStoreName,");
            strSql.Append("BUY_STORE.StoreAddressDetail1,BUY_STORE.Contact,BUY_STORE.ContactPhone,@WebSiteName as WebSiteName ");
            //strSql.Append(",'" + webSiteName + "' as  WebSiteName ");
            strSql.Append(" from BUY_PO_H ");
            strSql.Append("left join BUY_PO_D on BUY_PO_H.POCode=BUY_PO_D.POCode ");
            strSql.Append("left join BUY_PRODUCT on BUY_PO_D.ProdCode=BUY_PRODUCT.ProdCode ");
            strSql.Append("left join Accounts_Users on BUY_PO_H.CreatedBy=Accounts_Users.UserID ");
            strSql.Append("left join Accounts_Users as u  on BUY_PO_H.UpdatedBy=u.UserID ");
            strSql.Append("left join Accounts_Users as u1  on BUY_PO_H.ApproveBy=u1.UserID ");
            strSql.Append("left join BUY_VENDOR on BUY_PO_H.VendorID=BUY_VENDOR.VendorID ");
            strSql.Append("left join BUY_STORE on BUY_PO_H.StoreID=BUY_STORE.StoreID ");
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
            strSql.Append("select count(1) FROM BUY_PO_H ");
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
                strSql.Append("order by T.POCode desc");
            }
            strSql.Append(")AS Row, T.*  from BUY_PO_H T ");
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
            parameters[0].Value = "BUY_PO_H";
            parameters[1].Value = "POCode";
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

