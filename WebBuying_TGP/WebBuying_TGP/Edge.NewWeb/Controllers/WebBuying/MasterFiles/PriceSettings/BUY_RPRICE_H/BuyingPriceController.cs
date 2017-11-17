using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.Data;
using Edge.Web.Tools;
using Edge.DBUtility;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.PriceSettings.BUY_RPRICE_H
{
    public class BuyingPriceController
    {
        protected PriceViewModel viewModel = new PriceViewModel();

        public PriceViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(string RPriceCode)
        {
            Edge.SVA.BLL.BUY_RPRICE_H bll = new Edge.SVA.BLL.BUY_RPRICE_H();
            Edge.SVA.Model.BUY_RPRICE_H model = bll.GetModel(RPriceCode);
            viewModel.MainTable = model;
            Edge.SVA.BLL.BUY_RPRICE_D blld = new SVA.BLL.BUY_RPRICE_D();
            viewModel.Modellist = blld.GetModelList("RPriceCode = '" + RPriceCode + "'");
            DataSet ds = blld.GetList("RPriceCode = '" + RPriceCode + "'");
            viewModel.SubTable = ds.Tables.Count > 0 ? ds.Tables[0] : null;
            DataTool.AddBuyingProdName(viewModel.SubTable, "ProdName", "ProdCode");
            DataTool.AddBuyingRPriceTypeName(viewModel.SubTable, "RPriceTypeName", "RPriceTypeCode");
        }

        public ExecResult Add()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_RPRICE_H bll = new Edge.SVA.BLL.BUY_RPRICE_H();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.RPriceCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.RPriceCode);
                }
                if (rtn.Message == "")
                {
                    bll.Add(viewModel.MainTable);
                }

            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }

        public ExecResult Update()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_RPRICE_H bll = new Edge.SVA.BLL.BUY_RPRICE_H();
                Edge.SVA.BLL.BUY_RPRICE_D blld = new SVA.BLL.BUY_RPRICE_D();
                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (rtn.Message == "")
                {
                    bll.Update(viewModel.MainTable);
                    blld.Delete(viewModel.MainTable.RPriceCode);
                    if (viewModel.SubTable != null)
                    {
                        for (int i = 0; i < viewModel.SubTable.Rows.Count; i++)
                        {
                            Edge.SVA.Model.BUY_RPRICE_D model = new SVA.Model.BUY_RPRICE_D();
                            DataRow dr = viewModel.SubTable.Rows[i];
                            model.ProdCode = dr["ProdCode"].ToString();
                            model.Price = ConvertTool.ToDecimal(dr["Price"].ToString());
                            model.RefPrice = ConvertTool.ToDecimal(dr["RefPrice"].ToString());
                            model.RPriceCode = dr["RPriceCode"].ToString();
                            model.RPriceTypeCode = dr["RPriceTypeCode"].ToString();
                            model.PromotionPrice = ConvertTool.ToDecimal(dr["PromotionPrice"].ToString());
                            model.MemberPrice = ConvertTool.ToDecimal(dr["MemberPrice"].ToString());
                            blld.Add(model);
                        }
                    }
                }

            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }

        public ExecResult Delete(string RPriceCode)
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_RPRICE_H bll = new Edge.SVA.BLL.BUY_RPRICE_H();
                Edge.SVA.BLL.BUY_RPRICE_D blld = new SVA.BLL.BUY_RPRICE_D();

                if (rtn.Message == "")
                {
                    bll.Delete(RPriceCode);
                    blld.Delete(RPriceCode);
                }

            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }
        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.BUY_RPRICE_H bll = new Edge.SVA.BLL.BUY_RPRICE_H();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);

            //获取排序字段
            string orderStr = "RPriceCode";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetListByPage(strWhere, orderStr, pageSize * pageIndex + 1, pageSize * (pageIndex + 1));

            Tools.DataTool.AddCouponApproveStatusName(ds, "ApproveStatusName", "ApproveStatus");
            Tools.DataTool.AddBuyingStoreName(ds, "StoreName", "StoreCode");
            Tools.DataTool.AddBuyingStoreGroupName(ds, "StoreGroupName", "StoreGroupCode");
            Tools.DataTool.AddBuyingCurrencyName(ds, "CurrencyName", "CurrencyCode");

            Tools.DataTool.AddUserName(ds, "CreatedName", "CreatedBy");
            Tools.DataTool.AddUserName(ds, "ApproveName", "ApproveBy");

            return ds;
        }

        public string ValidateForm()
        {
            return "";
        }

        public string ValidateObject(string strWhere)
        {
            Edge.SVA.BLL.BUY_RPRICE_H bll = new SVA.BLL.BUY_RPRICE_H();
            List<Edge.SVA.Model.BUY_RPRICE_H> list = bll.GetModelList("RPriceCode = '" + strWhere + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }

        public void BindStore(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_STORE bll = new SVA.BLL.BUY_STORE();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "StoreCode", "StoreName1", "StoreName2", "StoreName3", "StoreCode");
        }

        public void BindStoreGroup(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_STOREGROUP bll = new SVA.BLL.BUY_STOREGROUP();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "StoreGroupCode", "StoreGroupName1", "StoreGroupName2", "StoreGroupName3", "StoreGroupCode");
        }

        public void BindCurrencyCode(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_CURRENCY bll = new SVA.BLL.BUY_CURRENCY();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "CurrencyCode", "CurrencyName1", "CurrencyName2", "CurrencyName3", "CurrencyCode");
        }

        public void BindProdCode(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_PRODUCT bll = new SVA.BLL.BUY_PRODUCT();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "ProdCode", "ProdDesc1", "ProdDesc2", "ProdDesc3", "ProdCode");
        }

        public void BindRPriceTypeCode(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_RPRICETYPE bll = new SVA.BLL.BUY_RPRICETYPE();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "RPriceTypeCode", "RPriceTypeName1", "RPriceTypeName2", "RPriceTypeName3", "RPriceTypeCode");
        }

        //追加新增的数据到SubTable
        //public void AddModelToDatable(List<Edge.SVA.Model.BUY_RPRICE_D> modellist, string RPriceCode)
        //{
        //    //先加载好原有数据
        //    //this.LoadViewModel(PromotionCode);
        //    Edge.SVA.BLL.BUY_RPRICE_D bll = new SVA.BLL.BUY_RPRICE_D();
        //    if (viewModel.SubTable != null)
        //    {
        //        viewModel.Modellist = bll.DataTableToList(viewModel.SubTable);
        //    }
        //    else
        //    {
        //        viewModel.Modellist.Clear();
        //    }

        //    //追加
        //    viewModel.Modellist.Add(modellist[modellist.Count - 1]);
        //    int j = -1;//用作赋值虚拟主键              
        //    if (ViewModel.SubTable == null)
        //    {
        //        //构建表架构
        //        ViewModel.SubTable = new DataTable();
        //        ViewModel.SubTable.Columns.Add("KeyID");
        //        ViewModel.SubTable.Columns.Add("RPriceCode");
        //        ViewModel.SubTable.Columns.Add("ProdCode");
        //        ViewModel.SubTable.Columns.Add("RPriceTypeCode");
        //        ViewModel.SubTable.Columns.Add("Price");
        //        ViewModel.SubTable.Columns.Add("RefPrice");
        //    }
        //    else
        //    {
        //        ViewModel.SubTable.Rows.Add(1);
        //        int k = viewModel.SubTable.Rows.Count - 1;
        //        int l = viewModel.Modellist.Count - 1;
        //        j = j - (viewModel.SubTable.Rows.Count + 1);//避免虚拟主键的值重复
        //        ViewModel.SubTable.Rows[k]["KeyID"] = j;
        //        ViewModel.SubTable.Rows[k]["RPriceCode"] = viewModel.Modellist[l].RPriceCode;
        //        ViewModel.SubTable.Rows[k]["ProdCode"] = viewModel.Modellist[l].ProdCode;
        //        ViewModel.SubTable.Rows[k]["RPriceTypeCode"] = viewModel.Modellist[l].RPriceTypeCode;
        //        ViewModel.SubTable.Rows[k]["Price"] = viewModel.Modellist[l].Price;
        //        ViewModel.SubTable.Rows[k]["RefPrice"] = viewModel.Modellist[l].RefPrice;

        //        viewModel.SubTable.Rows[k]["ProdName"] = DALTool.GetBuyingProdName(viewModel.Modellist[l].ProdCode,null);
        //        viewModel.SubTable.Rows[k]["RPriceTypeName"] = DALTool.GetBuyingRPriceTypeName(viewModel.Modellist[l].RPriceTypeCode, null);
        //    }
        //}

        //public List<Edge.SVA.Model.BUY_RPRICE_D> DataTableToList(DataTable dt)
        //{
        //    Edge.SVA.BLL.BUY_RPRICE_D bll = new SVA.BLL.BUY_RPRICE_D();
        //    List<Edge.SVA.Model.BUY_RPRICE_D> list = new List<SVA.Model.BUY_RPRICE_D>();
        //    List<Edge.SVA.Model.BUY_RPRICE_D> list1 = new List<SVA.Model.BUY_RPRICE_D>();
        //    list = bll.DataTableToList(dt);
        //    foreach (var item in list)
        //    {
        //        if (item.KeyID > 0)
        //        {
        //            list1.Add(item);
        //        }
        //    }
        //    foreach (var item in list1)
        //    {
        //        list.Remove(item);
        //    }
        //    return list;
        //}

        public string ApprovePriceForApproveCode(Edge.SVA.Model.BUY_RPRICE_H model, out bool isSuccess)
        {
            isSuccess = false;
            if (model == null) return "No Data";

            if (model.ApproveStatus != "P") return Resources.MessageTips.TheTransactionStatusNotPending;

            model.ApproveStatus = "A";
            model.ApproveOn = DateTime.Now;
            model.ApproveBy = Tools.DALTool.GetCurrentUser().UserID;
            //model.ApproveBusDate = ConvertTool.ConverNullable<DateTime>(DALTool.GetBusinessDate());

            Edge.SVA.BLL.BUY_RPRICE_H bll = new Edge.SVA.BLL.BUY_RPRICE_H();

            if (bll.Update(model))
            {
                model = new Edge.SVA.BLL.BUY_RPRICE_H().GetModel(model.RPriceCode);
                isSuccess = true;
                return model.ApprovalCode;
            }
            return "";
        }

        private bool VoidPrice(Edge.SVA.Model.BUY_RPRICE_H model)
        {
            if (model == null) return false;

            if (model.ApproveStatus != "P") return false;

            model.ApproveStatus = "V";
            model.ApproveOn = DateTime.Now;
            model.ApproveBy = Tools.DALTool.GetCurrentUser().UserID;
            //model.ApproveBusDate = ConvertTool.ConverNullable<DateTime>(DALTool.GetBusinessDate());

            Edge.SVA.BLL.BUY_RPRICE_H bll = new Edge.SVA.BLL.BUY_RPRICE_H();

            return bll.Update(model);
        }

        public string BatchVoid(List<string> idList)
        {
            int success = 0;
            int count = 0;
            foreach (string id in idList)
            {
                if (string.IsNullOrEmpty(id)) continue;
                count++;
                Edge.SVA.Model.BUY_RPRICE_H model = new Edge.SVA.BLL.BUY_RPRICE_H().GetModel(id);
                if (VoidPrice(model)) success++;
            }
            return string.Format(Resources.MessageTips.ApproveResult, success, count - success);
        }
        /// <summary>
        /// 导入
        /// 创建人：lisa
        /// 创建时间：2016-12-02
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="RPriceCode"></param>
        public ExecResult InsetData(DataTable dt)
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            string strConnection = PubConstant.ConnectionString;
            try
            {

                using (System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy(strConnection))
                {
                    bcp.BatchSize = 100;//每次传输的行数 
                    bcp.NotifyAfter = 100;//进度提示的行数 
                    bcp.DestinationTableName = "BUY_RPRICE_D";//需要导入的数据库表名
                    //excel表头与数据库列对应关系
                    bcp.ColumnMappings.Add("RPriceCode", "RPriceCode");
                    bcp.ColumnMappings.Add("ProdCode", "ProdCode");
                    bcp.ColumnMappings.Add("RPriceTypeCode", "RPriceTypeCode");
                    bcp.ColumnMappings.Add("Price", "Price");
                    bcp.ColumnMappings.Add("Price", "RefPrice");
                    bcp.ColumnMappings.Add("DiscountPrice", "PromotionPrice");
                    bcp.WriteToServer(dt);
                    rtn.Message = "";
                }

            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }
    }
}