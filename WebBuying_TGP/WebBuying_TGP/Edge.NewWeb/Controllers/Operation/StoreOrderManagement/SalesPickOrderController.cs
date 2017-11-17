using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.Web.Tools;
using System.Data;
using System.Data.SqlClient;
using Edge.DBUtility;

namespace Edge.Web.Controllers.Operation.StoreOrderManagement
{
    /// <summary>
    /// 创建人：lisa
    /// 创建时间：2016-06-02
    /// </summary>
    public class SalesPickOrderController
    {
        private const string fields = " [SalesPickOrderNumber],[OrderType],[CardNumber],[ReferenceNo],[CreatedBusDate],[ApproveBusDate],[ApprovalCode],[ApproveStatus],[ApproveOn],[ApproveBy],[CreatedOn],[CreatedBy],[UpdatedOn],[UpdatedBy]";

        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {


            DataSet ds;
            Edge.SVA.BLL.Ord_SalesPickOrder_H bll = new Edge.SVA.BLL.Ord_SalesPickOrder_H()
            {
                StrWhere = strWhere,
                Order = "CreatedOn",
                Fields = fields,
                Ascending = false
            };

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);
            //获取排序字段
            string orderStr = "SalesPickOrderNumber";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetList(pageSize, pageIndex, out recodeCount);

            Tools.DataTool.AddCouponApproveStatusName(ds, "ApproveStatusName", "ApproveStatus");

            Tools.DataTool.AddUserName(ds, "CreatedByName", "CreatedBy");
            Tools.DataTool.AddUserName(ds, "ApproveByName", "ApproveBy");

            return ds;
        }
        //批核
        public static string Approve(Edge.SVA.Model.Ord_SalesPickOrder_H model, out bool isSuccess)
        {
            isSuccess = false;
            if (model == null) return "No Data";

            if (model.ApproveStatus != "P") return Resources.MessageTips.TheTransactionStatusNotPending;

            model.ApproveStatus = "A";
            model.ApproveOn = DateTime.Now;
            model.ApproveBy = Tools.DALTool.GetCurrentUser().UserID;
            model.ApproveBusDate = ConvertTool.ConverNullable<DateTime>(DALTool.GetBusinessDate());

            Edge.SVA.BLL.Ord_SalesPickOrder_H bll = new Edge.SVA.BLL.Ord_SalesPickOrder_H();

            if (bll.Update(model))
            {
                model = new Edge.SVA.BLL.Ord_SalesPickOrder_H().GetModel(model.SalesPickOrderNumber);
                isSuccess = true;
                return model.ApprovalCode;
            }
            return "";
        }


        public static string Void(Edge.SVA.Model.Ord_SalesPickOrder_H model, out bool isSuccess)
        {
            isSuccess = false;
            if (model == null) return "No Data";

            if (model.ApproveStatus != "P") return Resources.MessageTips.TheTransactionStatusNotPending;

            model.ApproveStatus = "V";
            model.ApproveOn = DateTime.Now;
            model.ApproveBy = Tools.DALTool.GetCurrentUser().UserID;
            model.ApproveBusDate = ConvertTool.ConverNullable<DateTime>(DALTool.GetBusinessDate());

            Edge.SVA.BLL.Ord_SalesPickOrder_H bll = new Edge.SVA.BLL.Ord_SalesPickOrder_H();

            if (bll.Update(model))
            {
                model = new Edge.SVA.BLL.Ord_SalesPickOrder_H().GetModel(model.SalesPickOrderNumber);
                isSuccess = true;
                return model.ApprovalCode;
            }
            return "";
        }


        public string GetStoreName(string Code)
        {
            Edge.SVA.BLL.BUY_STORE storeBll = new SVA.BLL.BUY_STORE();
            string storeName = "";
            Edge.SVA.Model.BUY_STORE stroes = storeBll.GetStoreByCode(Code);
            if (stroes != null)
            {
                switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                {
                    case "en-us": storeName = stroes.StoreName1; break;
                    case "zh-cn": storeName = stroes.StoreName2; break;
                    case "zh-hk": storeName = stroes.StoreName3; break;
                }
            }
            else
            {
                storeName = "";
            }
            return storeName;
        }
        public string GetStoreName(int StoreID)
        {
            Edge.SVA.BLL.BUY_STORE storeBll = new SVA.BLL.BUY_STORE();
            string storeName = "";
            Edge.SVA.Model.BUY_STORE stroes = storeBll.GetModel(StoreID);
            if (stroes != null)
            {
                switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                {
                    case "en-us": storeName = stroes.StoreName1; break;
                    case "zh-cn": storeName = stroes.StoreName2; break;
                    case "zh-hk": storeName = stroes.StoreName3; break;
                }
            }
            else
            {
                storeName = "";
            }
            return storeName;
        }
        public string CheckStockOnhand(int TypeID,string orderNumber,string storeID)
        {
            string storeCode = "";
            Edge.SVA.BLL.BUY_STORE storeBLL = new SVA.BLL.BUY_STORE();
            Edge.SVA.Model.BUY_STORE stores = storeBLL.GetModel(Convert.ToInt32(storeID));
            if (stores != null)
            {
                storeCode = stores.StoreCode;
            }
            return DbHelperSQL.CheckStockOnhand(TypeID,orderNumber, storeCode);
        }

    }
}