using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.Data;
using Edge.Web.Tools;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.PriceSettings.BUY_CPRICE_H
{
    public class BuyingCPriceController
    {
        protected CPriceViewModel viewModel = new CPriceViewModel();

        public CPriceViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(string CPriceCode)
        {
            Edge.SVA.BLL.BUY_CPRICE_H bll = new Edge.SVA.BLL.BUY_CPRICE_H();
            Edge.SVA.Model.BUY_CPRICE_H model = bll.GetModel(CPriceCode);
            viewModel.MainTable = model;

            Edge.SVA.BLL.BUY_CPRICE_D blld = new SVA.BLL.BUY_CPRICE_D();
            DataSet ds = blld.GetList("CPriceCode = '" + CPriceCode + "'");
            viewModel.SubTable = ds.Tables.Count > 0 ? ds.Tables[0] : null;

            Tools.DataTool.AddBuyingProdName(viewModel.SubTable, "ProdName", "ProdCode");
            
        }

        public ExecResult Add()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_CPRICE_H bll = new Edge.SVA.BLL.BUY_CPRICE_H();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.CPriceCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.CPriceCode);
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
                Edge.SVA.BLL.BUY_CPRICE_H bll = new Edge.SVA.BLL.BUY_CPRICE_H();
                Edge.SVA.BLL.BUY_CPRICE_D blld = new SVA.BLL.BUY_CPRICE_D();
                
                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (rtn.Message == "")
                {
                    bll.Update(viewModel.MainTable);
                    blld.Delete(viewModel.MainTable.CPriceCode);
                    if (viewModel.SubTable != null)
                    {
                        for (int i = 0; i < viewModel.SubTable.Rows.Count; i++)
                        {
                            Edge.SVA.Model.BUY_CPRICE_D model = new SVA.Model.BUY_CPRICE_D();
                            DataRow dr = viewModel.SubTable.Rows[i];
                            model.CPriceCode = dr["CPriceCode"].ToString();
                            model.ProdCode = dr["ProdCode"].ToString();
                            model.CPriceGrossCost = ConvertTool.ToDecimal(dr["CPriceGrossCost"].ToString());
                            model.CPriceNetCost = ConvertTool.ToDecimal(dr["CPriceNetCost"].ToString());
                            model.CPriceDisc1 = ConvertTool.ToDecimal(dr["CPriceDisc1"].ToString());
                            model.CPriceDisc2 = ConvertTool.ToDecimal(dr["CPriceDisc2"].ToString());
                            model.CPriceDisc3 = ConvertTool.ToDecimal(dr["CPriceDisc3"].ToString());
                            model.CPriceDisc4 = ConvertTool.ToDecimal(dr["CPriceDisc4"].ToString());
                            model.CPriceBuy = ConvertTool.ToDecimal(dr["CPriceBuy"].ToString());
                            model.CPriceGet = ConvertTool.ToDecimal(dr["CPriceGet"].ToString());
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

        public ExecResult Delete(string CPriceCode)
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_CPRICE_H bll = new Edge.SVA.BLL.BUY_CPRICE_H();
                Edge.SVA.BLL.BUY_CPRICE_D blld = new SVA.BLL.BUY_CPRICE_D();

                if (rtn.Message == "")
                {
                    bll.Delete(CPriceCode);
                    blld.Delete(CPriceCode);
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
            Edge.SVA.BLL.BUY_CPRICE_H bll = new Edge.SVA.BLL.BUY_CPRICE_H();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);
            //获取排序字段
            string orderStr = "CPriceCode";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetListByPage(strWhere, orderStr, pageSize * pageIndex + 1, pageSize * (pageIndex + 1));

            Tools.DataTool.AddCouponApproveStatusName(ds, "ApproveStatusName", "ApproveStatus");
            Tools.DataTool.AddBuyingStoreName(ds, "StoreName", "StoreCode");
            Tools.DataTool.AddBuyingStoreGroupName(ds, "StoreGroupName", "StoreGroupCode");
            Tools.DataTool.AddBuyingCurrencyName(ds, "CurrencyName", "CurrencyCode");
            Tools.DataTool.AddBuyingVendorName(ds, "VendorName", "VendorCode");

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
            Edge.SVA.BLL.BUY_CPRICE_H bll = new SVA.BLL.BUY_CPRICE_H();
            List<Edge.SVA.Model.BUY_CPRICE_H> list = bll.GetModelList("CPriceCode = '" + strWhere + "'");
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

        public void BindCurrency(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_CURRENCY bll = new SVA.BLL.BUY_CURRENCY();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "CurrencyCode", "CurrencyName1", "CurrencyName2", "CurrencyName3", "CurrencyCode");
        }

        public void BindVendor(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_VENDOR bll = new SVA.BLL.BUY_VENDOR();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "VendorCode", "VendorName1", "VendorName2", "VendorName3", "VendorCode");
        }

        public void BindProdCode(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_PRODUCT bll = new SVA.BLL.BUY_PRODUCT();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "ProdCode", "ProdDesc1", "ProdDesc2", "ProdDesc3", "ProdCode");
        }

        public string ApproveCPriceForApproveCode(Edge.SVA.Model.BUY_CPRICE_H model, out bool isSuccess)
        {
            isSuccess = false;
            if (model == null) return "No Data";

            if (model.ApproveStatus != "P") return Resources.MessageTips.TheTransactionStatusNotPending;

            model.ApproveStatus = "A";
            model.ApproveOn = DateTime.Now;
            model.ApproveBy = Tools.DALTool.GetCurrentUser().UserID;
            //model.ApproveBusDate = ConvertTool.ConverNullable<DateTime>(DALTool.GetBusinessDate());

            Edge.SVA.BLL.BUY_CPRICE_H bll = new Edge.SVA.BLL.BUY_CPRICE_H();

            if (bll.Update(model))
            {
                model = new Edge.SVA.BLL.BUY_CPRICE_H().GetModel(model.CPriceCode);
                isSuccess = true;
                return model.ApprovalCode;
            }
            return "";
        }

        private bool VoidCPrice(Edge.SVA.Model.BUY_CPRICE_H model)
        {
            if (model == null) return false;

            if (model.ApproveStatus != "P") return false;

            model.ApproveStatus = "V";
            model.ApproveOn = DateTime.Now;
            model.ApproveBy = Tools.DALTool.GetCurrentUser().UserID;
            //model.ApproveBusDate = ConvertTool.ConverNullable<DateTime>(DALTool.GetBusinessDate());

            Edge.SVA.BLL.BUY_CPRICE_H bll = new Edge.SVA.BLL.BUY_CPRICE_H();

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
                Edge.SVA.Model.BUY_CPRICE_H model = new Edge.SVA.BLL.BUY_CPRICE_H().GetModel(id);
                if (VoidCPrice(model)) success++;
            }
            return string.Format(Resources.MessageTips.ApproveResult, success, count - success);
        }
    }
}