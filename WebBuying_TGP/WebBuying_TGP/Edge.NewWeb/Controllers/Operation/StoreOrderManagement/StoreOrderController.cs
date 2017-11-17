using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Edge.Web.Tools;

namespace Edge.Web.Controllers.Operation.StoreOrderManagement.StoreOrder
{
    public class StoreOrderController
    {
        private const string fields = " [StoreOrderNumber],[OrderType],[ReferenceNo],[FromStoreID],[FromContactName],[FromContactPhone],[FromMobile],[FromEmail],[FromAddress],[StoreID],[StoreContactName],[StoreContactPhone],[StoreContactEmail],[StoreMobile],[StoreAddress],[Remark],[CreatedBusDate],[ApproveBusDate],[ApprovalCode],[ApproveStatus],[ApproveOn],[ApproveBy],[CreatedOn],[CreatedBy],[UpdatedOn],[UpdatedBy],[DeliveryStatus]";
        private const string condition = " StoreID IN {0} and FromStoreID IN {0} and (CreatedBy IN {1} or UpdatedBy IN {1} or ApproveBy IN {1})";
        private const string andCondition = " and StoreID IN {0} and FromStoreID IN {0} and (CreatedBy IN {1} or UpdatedBy IN {1} or ApproveBy IN {1})";
        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            string userids = SVASessionInfo.CurrentUser.SqlConditionUserIDs;
            string storeids = SVASessionInfo.CurrentUser.SqlConditionStoreIDs;
            if (string.IsNullOrEmpty(strWhere))
            {
                if (string.IsNullOrEmpty(storeids))
                {
                    //strWhere = " 1=1";
                    strWhere = " 1=1";
                }
                else
                {
                    strWhere = string.Format(condition, storeids, userids);
                }
            }
            else
            {
                strWhere += string.Format(andCondition, storeids, userids);
            }

            DataSet ds=null;
            Edge.SVA.BLL.Ord_StoreOrder_H bll = new Edge.SVA.BLL.Ord_StoreOrder_H()
            {
                StrWhere = strWhere,
                Order = "CreatedOn",
                Fields = fields,
                Ascending = false
            };

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);
            //获取排序字段
            string orderStr = "StoreOrderNumber";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            //ds = bll.GetListByPage(strWhere, orderStr, pageSize * pageIndex + 1, pageSize * (pageIndex + 1));
            ds = bll.GetList(pageSize, pageIndex, out recodeCount);
            Tools.DataTool.AddCouponApproveStatusName(ds, "ApproveStatusName", "ApproveStatus");
            Tools.DataTool.AddDeliveryStatusName(ds, "DeliveryStatusName", "DeliveryStatus");
            Tools.DataTool.AddBuyingStoreNameByID(ds, "FromStoreName", "FromStoreID");
            Tools.DataTool.AddBuyingStoreNameByID(ds, "StoreName", "StoreID");

            Tools.DataTool.AddUserName(ds, "CreatedByName", "CreatedBy");
            Tools.DataTool.AddUserName(ds, "ApproveByName", "ApproveBy");

            return ds;
        }
        /// <summary>
        /// 根据条件查询列表
        /// 创建人：王丽
        /// 创建时间：2015-12-02
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public DataSet GetTransactionListByParm(string strWhere, string filedOrder, string webSiteName)
        {
            Edge.SVA.BLL.Ord_StoreOrder_H bll = new Edge.SVA.BLL.Ord_StoreOrder_H();
            DataSet ds = bll.GetListByParm(strWhere, filedOrder, webSiteName);
            return ds;
        }
        public static string Approve(Edge.SVA.Model.Ord_StoreOrder_H model, out bool isSuccess)
        {
            isSuccess = false;
            if (model == null) return "No Data";

            if (model.ApproveStatus != "P") return Resources.MessageTips.TheTransactionStatusNotPending;

            model.ApproveStatus = "A";
            model.ApproveOn = DateTime.Now;
            model.ApproveBy = Tools.DALTool.GetCurrentUser().UserID;
            model.ApproveBusDate = ConvertTool.ConverNullable<DateTime>(DALTool.GetBusinessDate());

            Edge.SVA.BLL.Ord_StoreOrder_H bll = new Edge.SVA.BLL.Ord_StoreOrder_H();

            if (bll.Update(model))
            {
                model = new Edge.SVA.BLL.Ord_StoreOrder_H().GetModel(model.StoreOrderNumber);
                isSuccess = true;
                return model.ApprovalCode;
            }
            return "";
        }

        public static string Void(Edge.SVA.Model.Ord_StoreOrder_H model, out bool isSuccess)
        {
            isSuccess = false;
            if (model == null) return "No Data";

            if (model.ApproveStatus != "P") return Resources.MessageTips.TheTransactionStatusNotPending;

            model.ApproveStatus = "V";
            model.ApproveOn = DateTime.Now;
            model.ApproveBy = Tools.DALTool.GetCurrentUser().UserID;
            model.ApproveBusDate = ConvertTool.ConverNullable<DateTime>(DALTool.GetBusinessDate());

            Edge.SVA.BLL.Ord_StoreOrder_H bll = new Edge.SVA.BLL.Ord_StoreOrder_H();

            if (bll.Update(model))
            {
                model = new Edge.SVA.BLL.Ord_StoreOrder_H().GetModel(model.StoreOrderNumber);
                isSuccess = true;
                return model.ApprovalCode;
            }
            return "";
        }

        public DataSet ExportStoreOrderData(string StoreOrderNumber)
        {
            Edge.SVA.BLL.Ord_StoreOrder_H bll = new Edge.SVA.BLL.Ord_StoreOrder_H();
            DataSet ds = bll.ExportStoreOrderData(StoreOrderNumber);
            return ds;
        }

    }
}