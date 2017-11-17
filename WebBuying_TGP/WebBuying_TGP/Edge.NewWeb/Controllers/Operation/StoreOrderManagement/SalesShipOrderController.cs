using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Edge.Web.Controllers.Operation.StoreOrderManagement
{
    /// <summary>
    /// 创建人：lisa
    /// 创建时间：2016-06-03
    /// </summary>
    public class SalesShipOrderController
    {
        private const string fields = " [SalesShipOrderNumber],[OrderType],[TxnNo],[Status],[ReferenceNo],[CreatedOn],[CreatedBy],[UpdatedOn],[UpdatedBy]";

        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {


            DataSet ds;
            Edge.SVA.BLL.Ord_SalesShipOrder_H bll = new Edge.SVA.BLL.Ord_SalesShipOrder_H()
            {
                StrWhere = strWhere,
                Order = "CreatedOn",
                Fields = fields,
                Ascending = false
            };

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);
            //获取排序字段
            string orderStr = "SalesShipOrderNumber";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetList(pageSize, pageIndex, out recodeCount);
            Tools.DataTool.AddUserName(ds, "CreatedByName", "CreatedBy");

            return ds;
        }

    }
}