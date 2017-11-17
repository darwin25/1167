using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Edge.Web.Controllers.Operation.CouponManagement.BatchImportCoupons
{
    public class BatchImportCouponsController
    {
        private const string fields = " [ImportCouponNumber],[ApprovalCode],[ApproveStatus],[ApproveOn],[ApproveBy],[CreatedOn],[CreatedBy],[UpdatedOn],[UpdatedBy],[CreatedBusDate],[ApproveBusDate]";
        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            //Edge.SVA.BLL.Ord_ImportCouponUID_H bll = new Edge.SVA.BLL.Ord_ImportCouponUID_H();
            ////获得总条数
            //int count = bll.GetCount(strWhere);
            //recodeCount = count;
            //DataSet ds = new DataSet();
            //ds = bll.GetList(pageSize, pageIndex, strWhere, "ImportCouponNumber");

            //Tools.DataTool.AddUserName(ds, "CreatedByName", "CreatedBy");
            //Tools.DataTool.AddUserName(ds, "ApproveByName", "ApproveBy");
            //Tools.DataTool.AddCouponApproveStatusName(ds, "ApproveStatusName", "ApproveStatus");

            //return ds;

            string OrderField = "ImportCouponNumber";
            bool OrderType = false;
            if (sortFieldStr.ToLower().EndsWith(" asc"))
            {
                OrderType = true;
                OrderField = sortFieldStr.Substring(0, sortFieldStr.ToLower().IndexOf(" asc"));
            }
            else if (sortFieldStr.ToLower().EndsWith(" desc"))
            {
                OrderField = sortFieldStr.Substring(0, sortFieldStr.ToLower().IndexOf(" desc"));
            }

            Edge.SVA.BLL.Ord_ImportCouponUID_H bll = new Edge.SVA.BLL.Ord_ImportCouponUID_H()
            {
                StrWhere = strWhere,
                Order = OrderField,//"ImportCouponNumber",
                Fields = fields,
                Ascending = OrderType//false
            };

            System.Data.DataSet ds = null;
            ds = bll.GetList(pageSize, pageIndex, out recodeCount);

            Tools.DataTool.AddUserName(ds, "CreatedByName", "CreatedBy");
            Tools.DataTool.AddUserName(ds, "ApproveByName", "ApproveBy");
            Tools.DataTool.AddCouponApproveStatusName(ds, "ApproveStatusName", "ApproveStatus");

            return ds;
        }
    }
}