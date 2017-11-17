using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.File;
using System.Data;
using Edge.Web.Tools;
using Edge.SVA.BLL.Domain.DataResources;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.SVA.Model.Domain.File.BasicViewModel;
using Edge.Utils.Tools;
using System.Text;
using Edge.DBUtility;//Please add references
using System.Data.SqlClient;

namespace Edge.Web.Controllers.Operation.StockTakeController
{
    public class StockTakeController
    {
        private const string fields = " StockTakeID, StockTakeNumber,StockTakeDate,StoreID,Status,StockTakeType,Remark,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy";
        private const string condition = " StoreID IN {0}";
        private const string andCondition = " and StoreID IN {0}";
        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            string storeids = SVASessionInfo.CurrentUser.SqlConditionStoreIDs;
            if (string.IsNullOrEmpty(strWhere))
            {
                if (string.IsNullOrEmpty(storeids))
                {
                    strWhere = " 1=1";
                }
                else
                {
                    strWhere = string.Format(condition, storeids);
                }
            }
            else
            {
                strWhere += string.Format(andCondition, storeids);
            }

            DataSet ds;
            Edge.SVA.BLL.STK_STake_H bll = new Edge.SVA.BLL.STK_STake_H()
            {
                StrWhere = strWhere,
                Order = "CreatedOn",
                Fields = fields,
                Ascending = false
            };

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);
            //获取排序字段
            string orderStr = "StockTakeNumber";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetList(pageSize, pageIndex, out recodeCount);

            Tools.DataTool.AddBuyingStoreNameByID(ds, "StoreName", "StoreID");

            Tools.DataTool.AddUserName(ds, "CreatedByName", "CreatedBy");
            Tools.DataTool.AddUserName(ds, "UpdatedByName", "UpdatedBy");

            return ds;
        }
        /// <summary>
        /// 根据条件查询列表
        /// 创建人：王丽
        /// 创建时间：2015-11-30
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public DataSet GetTransactionListByParm(string strWhere, string filedOrder, string webSiteName, string type)
        {
            Edge.SVA.BLL.STK_STake_H bll = new Edge.SVA.BLL.STK_STake_H();
            DataSet ds = bll.GetListByParm(strWhere, filedOrder, webSiteName, type);
            return ds;
        }
        /// <summary>
        /// 判断店铺是否存在未批核的盘点
        /// 创建者：Lisa
        /// 创建时间：2016-03-31
        /// </summary>
        /// <param name="stroreID"></param>
        /// <returns></returns>
        public DataSet GetList(int stroreID)
        {
            Edge.SVA.BLL.Ord_StockAdjust_H bll = new Edge.SVA.BLL.Ord_StockAdjust_H();
            DataSet dsOrdStockAdjustH = bll.GetList("StoreID=" + stroreID + " and ApproveStatus='P'");
            return dsOrdStockAdjustH;
        }

        public int GetCount(string strWhere)
        {
            Edge.SVA.BLL.Ord_StockAdjust_H bll = new Edge.SVA.BLL.Ord_StockAdjust_H();
            return bll.GetCount(strWhere);
        }

        public int Register(int StockTakeType, int StoreID, string DeptCode, DateTime StockTakeDate, string Remark)
        {
            int rowsAffected = 0;
            /*
            *      @StockTakeType      INT,          -- 盘点类型, 0: 只盘点数量. 1: 盘点serialno
                   @StoreID            INT,          -- 店铺ID ,必填
                   @DeptCode           VARCHAR(64),  -- 部门代码
                   @StockTakeDate      DATETIME,     -- 盘点日期
                   @Remark             VARCHAR(512)  -- 备注 */
            SqlParameter[] parameters = {
                    new SqlParameter("@StockTakeType", SqlDbType.Int),
                    new SqlParameter("@StoreID", SqlDbType.Int),
                    new SqlParameter("@DeptCode ",SqlDbType.VarChar,64),
                    new SqlParameter("@StockTakeDate",SqlDbType.DateTime),
                    new SqlParameter("@Remark", SqlDbType.VarChar,512),
                    new SqlParameter("@UserID", SqlDbType.Int),
                    };
            parameters[0].Value = StockTakeType;
            parameters[1].Value = StoreID;
            parameters[2].Value = DeptCode;
            parameters[3].Value = StockTakeDate;
            parameters[4].Value = Remark;
            parameters[5].Value = SVASessionInfo.CurrentUser.UserID;
            return DbHelperSQL.RunProcedure("StockTakeRegister", parameters, out rowsAffected);
        }

        /// <summary>
        /// 检查盘点
        /// 创建人：Lisa
        /// 创建时间：2016-04-13
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public DataSet CheckPrepareOrder(int storeId)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@StoreID", SqlDbType.Int)
                    };
            parameters[0].Value = storeId;
            return DbHelperSQL.RunProcedure("CheckPrepareOrder", parameters, "ds");
        }
        public DataSet GetSTK01(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.STK_STake01 bll = new Edge.SVA.BLL.STK_STake01()
            {
                StrWhere = strWhere,
                Order = "ProdCode",
                Fields = fields,
                Ascending = false
            };

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);
            //获取排序字段
            string orderStr = "ProdCode";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetList(recodeCount, strWhere, "ProdCode");

            //Tools.DataTool.AddBuyingStoreNameByID(ds, "StoreName", "StoreID");
            //Tools.DataTool.AddUserName(ds, "CreatedByName", "CreatedBy");
            Tools.DataTool.AddBuyingProdDesc(ds, "ProdDesc", "ProdCode");
            Tools.DataTool.AddBuyingProdDeptCode(ds, "DeptCode", "ProdCode");
            return ds;
        }


        public int InitSTK02FromSTK01(string StockTakeNumber)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                    new SqlParameter("@StockTakeNumber", SqlDbType.VarChar,64),
                    };
            parameters[0].Value = StockTakeNumber;
            return DbHelperSQL.RunProcedure("CopyStockTake1To2", parameters, out rowsAffected);
        }

        public DataSet GetSTK02(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.STK_STake02 bll = new Edge.SVA.BLL.STK_STake02()
            {
                StrWhere = strWhere,
                Order = "ProdCode",
                Fields = fields,
                Ascending = false
            };

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);
            //获取排序字段
            string orderStr = "ProdCode";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetList(recodeCount, strWhere, "ProdCode");

            //Tools.DataTool.AddBuyingStoreNameByID(ds, "StoreName", "StoreID");
            //Tools.DataTool.AddUserName(ds, "CreatedByName", "CreatedBy");
            Tools.DataTool.AddBuyingProdDesc(ds, "ProdDesc", "ProdCode");
            Tools.DataTool.AddBuyingProdDeptCode(ds, "DeptCode", "ProdCode");
            return ds;
        }


        public int GenStockTakeVAR(string StockTakeNumber)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                    new SqlParameter("@StockTakeNumber", SqlDbType.VarChar,64),
                    };
            parameters[0].Value = StockTakeNumber;
            DbHelperSQL.RunProcedure("GenStockTakeVAR", parameters, out rowsAffected);
            return 0;
        }

        public DataSet GetSTKVAR(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.STK_STakeVAR bll = new Edge.SVA.BLL.STK_STakeVAR()
            {
                StrWhere = strWhere,
                Order = "ProdCode",
                Fields = fields,
                Ascending = false
            };

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);
            //获取排序字段
            string orderStr = "ProdCode";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetList(recodeCount, strWhere, "ProdCode");

            //Tools.DataTool.AddBuyingStoreNameByID(ds, "StoreName", "StoreID");
            //Tools.DataTool.AddUserName(ds, "CreatedByName", "CreatedBy");
            Tools.DataTool.AddBuyingProdDesc(ds, "ProdDesc", "ProdCode");
            Tools.DataTool.AddBuyingProdDeptCode(ds, "DeptCode", "ProdCode");
            return ds;
        }

        public int CloseStockTake(string StockTakeNumber,int operatorID)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                    new SqlParameter("@StockTakeNumber", SqlDbType.VarChar,64),
                    new SqlParameter("@UserID", SqlDbType.Int)
                    };
            parameters[0].Value = StockTakeNumber;
            parameters[1].Value = operatorID;
            int count= DbHelperSQL.RunProcedure("CloseStockTake", parameters, out rowsAffected);
            return count;
        }

        public int UpdateStatus(string StockTakeNumber, int Status)
        {
            string SQLStr = "Update STK_STAKE_H set Status = " + Status.ToString() + " where StockTakeNumber = '" + StockTakeNumber + "'";
            DbHelperSQL.ExecuteSql(SQLStr);
            return 0;
        }

    }
}