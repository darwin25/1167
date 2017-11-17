using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Edge.Web.Tools;

namespace Edge.Web.Controllers.Operation.StoreOrderManagement.ReturnStoreOrder
{
    public class ReturnStoreOrderController
    {
        private const string fields = " [ReturnOrderNumber],[OrderType],[ReferenceNo],[FromStoreID],[FromContactName],[FromContactPhone],[FromMobile],[FromEmail],[FromAddress],[StoreID],[StoreContactName],[StoreContactPhone],[StoreContactEmail],[StoreMobile],[StoreAddress],[Remark],[CreatedBusDate],[ApproveBusDate],[ApprovalCode],[ApproveStatus],[ApproveOn],[ApproveBy],[CreatedOn],[CreatedBy],[UpdatedOn],[UpdatedBy]";
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

            DataSet ds;
            Edge.SVA.BLL.Ord_ReturnOrder_H bll = new Edge.SVA.BLL.Ord_ReturnOrder_H()
            {
                StrWhere = strWhere,
                Order = "CreatedOn",
                Fields = fields,
                Ascending = false
            };
            
            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);
            //获取排序字段
            string orderStr = "ReturnOrderNumber";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            //ds = bll.GetListByPage(strWhere, orderStr, pageSize * pageIndex + 1, pageSize * (pageIndex + 1));
            ds = bll.GetList(pageSize, pageIndex, out recodeCount);

            Tools.DataTool.AddCouponApproveStatusName(ds, "ApproveStatusName", "ApproveStatus");
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
            Edge.SVA.BLL.Ord_ReturnOrder_H bll = new Edge.SVA.BLL.Ord_ReturnOrder_H();
            DataSet ds = bll.GetListByParm(strWhere, filedOrder, webSiteName);
            return ds;
        }
        public static string Approve(Edge.SVA.Model.Ord_ReturnOrder_H model, out bool isSuccess)
        {
            isSuccess = false;
            if (model == null) return "No Data";

            if (model.ApproveStatus != "P") return Resources.MessageTips.TheTransactionStatusNotPending;

            model.ApproveStatus = "A";
            model.ApproveOn = DateTime.Now;
            model.ApproveBy = Tools.DALTool.GetCurrentUser().UserID;
            model.ApproveBusDate = ConvertTool.ConverNullable<DateTime>(DALTool.GetBusinessDate());

            Edge.SVA.BLL.Ord_ReturnOrder_H bll = new Edge.SVA.BLL.Ord_ReturnOrder_H();

            if (bll.Update(model))
            {
                model = new Edge.SVA.BLL.Ord_ReturnOrder_H().GetModel(model.ReturnOrderNumber);
                isSuccess = true;
                return model.ApprovalCode;
            }
            return "";
        }

        public static string Void(Edge.SVA.Model.Ord_ReturnOrder_H model, out bool isSuccess)
        {
            isSuccess = false;
            if (model == null) return "No Data";

            if (model.ApproveStatus != "P") return Resources.MessageTips.TheTransactionStatusNotPending;

            model.ApproveStatus = "V";
            model.ApproveOn = DateTime.Now;
            model.ApproveBy = Tools.DALTool.GetCurrentUser().UserID;
            model.ApproveBusDate = ConvertTool.ConverNullable<DateTime>(DALTool.GetBusinessDate());

            Edge.SVA.BLL.Ord_ReturnOrder_H bll = new Edge.SVA.BLL.Ord_ReturnOrder_H();

            if (bll.Update(model))
            {
                model = new Edge.SVA.BLL.Ord_ReturnOrder_H().GetModel(model.ReturnOrderNumber);
                isSuccess = true;
                return model.ApprovalCode;
            }
            return "";
        }
    }
}