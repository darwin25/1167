using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Edge.DBUtility;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT
{
    public class ProductModifyTempController
    {
        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.ProductModifyTemp bll = new Edge.SVA.BLL.ProductModifyTemp();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);

            //获取排序字段
            string orderStr = "ProdCode";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }
            ds = bll.GetListByPage(strWhere, orderStr, pageSize * pageIndex + 1, pageSize * (pageIndex + 1));
            if (ds != null)
            {
                Tools.DataTool.AddBuyingProdDesc(ds, "ProdName", "ProdCode");
                Tools.DataTool.AddProductModifyTempStatusName(ds, "StatusName", "Status");
                Tools.DataTool.AddProductModifyTempIsOnlineSKUName(ds, "IsOnlineSKUName", "IsOnlineSKU");
            }
            return ds;
        }
        public void InsetData(DataTable dt)
        {

            string strConnection = PubConstant.ConnectionString;
            try
            {

                using (System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy(strConnection))
                {
                    bcp.BatchSize = 100;//每次传输的行数 
                    bcp.NotifyAfter = 100;//进度提示的行数 
                    bcp.DestinationTableName = "ProductModifyTemp";//需要导入的数据库表名
                    //excel表头与数据库列对应关系
                    bcp.ColumnMappings.Add("ProdCode", "ProdCode");
                    bcp.ColumnMappings.Add("IsOnlineSKU", "IsOnlineSKU");
                    bcp.ColumnMappings.Add("Feature", "Feature");
                    bcp.ColumnMappings.Add("HotSale", "HotSale");
                    bcp.ColumnMappings.Add("Price", "Price");
                    bcp.ColumnMappings.Add("RefPrice", "RefPrice");
                    bcp.ColumnMappings.Add("Status", "Status");
                    bcp.ColumnMappings.Add("CreatedOn", "CreatedOn");
                    bcp.WriteToServer(dt);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateSVAProduct()
        {

            DbHelperSQL.RunProcedure("UpdateSVAProduct");
        }
    }
}