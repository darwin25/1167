using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using System.Data;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.Web.Tools;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT
{
    public class BuyingProductController
    {
        protected ProductViewModel viewModel = new ProductViewModel();

        public ProductViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(string ProdCode)
        {
            Edge.SVA.BLL.BUY_PRODUCT bll = new Edge.SVA.BLL.BUY_PRODUCT();
            Edge.SVA.Model.BUY_PRODUCT model = bll.GetModel(ProdCode);
            viewModel.MainTable = model;

            Edge.SVA.BLL.BUY_BARCODE bllbar = new SVA.BLL.BUY_BARCODE();
            viewModel.dtBarCode = bllbar.GetList("ProdCode='" + ProdCode + "'").Tables[0];

            Edge.SVA.BLL.BUY_RPRICE_M bllrp = new SVA.BLL.BUY_RPRICE_M();
            //viewModel.dtRprice = bllrp.GetList("ProdCode='" + ProdCode + "'").Tables[0];
            string sql = @"select top 1* from BUY_RPRICE_M where ProdCode='" + ProdCode + "' order by keyID desc";
            viewModel.dtRprice = DBUtility.DbHelperSQL.Query(sql).Tables[0];

            Edge.SVA.BLL.BUY_SUPPROD bllSUPPROD = new SVA.BLL.BUY_SUPPROD();
            viewModel.dtSUPPROD = bllSUPPROD.GetList("ProdCode='" + ProdCode + "'").Tables[0];

            Edge.SVA.BLL.ProductStoreMap bllStoreMap = new SVA.BLL.ProductStoreMap();
            viewModel.dtStore = bllStoreMap.GetList("ProdCode='" + ProdCode + "'").Tables[0];

            DataTool.AddBuyingRPriceTypeName(viewModel.dtRprice, "RPriceTypeName", "RPriceTypeCode");
        }

        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds = null;
            Edge.SVA.BLL.BUY_PRODUCT bll = new SVA.BLL.BUY_PRODUCT();
            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);

            //获取排序字段
            string orderStr = "ProdCode";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetListByPage(strWhere, orderStr, pageSize * pageIndex + 1, pageSize * (pageIndex + 1));
            Tools.DataTool.AddID(ds, "ID", 0, 0);
            Tools.DataTool.AddBuyingDepartName(ds.Tables[0], "DepartName", "DepartCode");
            Tools.DataTool.AddBuyingProdName(ds.Tables[0], "ProdDesc", "ProdCode");
            DataTool.AddBuyingBrandName(ds, "BrandName", "BrandCode");
            DataTool.AddBuyingStoreName(ds, "StoreName", "StoreCode");
            return ds;
        }

        public DataSet GetTransactionList_New(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds = null;
            Edge.SVA.BLL.BUY_PRODUCT bll = new SVA.BLL.BUY_PRODUCT();
            //获得总条数
            recodeCount = bll.GetRecordTwoTableCount(strWhere);

            //获取排序字段
            string orderStr = "ProdCode";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetListTwoTable(strWhere, orderStr, pageSize * pageIndex + 1, pageSize * (pageIndex + 1));


            DataTool.AddBuyingBrandName(ds, "BrandName", "BrandCode");
            DataTool.AddBuyingStoreName(ds, "StoreName", "StoreCode");
            return ds;
        }


        public DataSet GetStockList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.BUY_PRODUCT bll = new Edge.SVA.BLL.BUY_PRODUCT();

            //获得总条数
            recodeCount = bll.GetStockRecordCount(strWhere);

            //获取排序字段
            string orderStr = "ProdCode";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetStockListByPage(strWhere, orderStr, pageSize * pageIndex + 1, pageSize * (pageIndex + 1));

            DataTool.AddBuyingBrandName(ds, "BrandName", "BrandCode");
            DataTool.AddBuyingDepartName(ds.Tables[0], "DepartName", "DepartCode");
            DataTool.GetBuyingStoreNameByStoreCode(ds, "StoreName", "StoreCode");
            return ds;
        }

        public ExecResult Add()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_PRODUCT bll = new SVA.BLL.BUY_PRODUCT();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.ProdCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.ProdCode);
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

        public ExecResult bauHausAdd()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_PRODUCT bll = new SVA.BLL.BUY_PRODUCT();
                Edge.SVA.BLL.BUY_RPRICE_M bllrp = new SVA.BLL.BUY_RPRICE_M();
                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.ProdCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.ProdCode);
                }
                if (rtn.Message == "")
                {
                    bll.Add(viewModel.MainTable);
                    if (viewModel.dtRprice != null)
                    {
                        for (int i = 0; i < viewModel.dtRprice.Rows.Count; i++)
                        {
                            Edge.SVA.Model.BUY_RPRICE_M model = new SVA.Model.BUY_RPRICE_M();
                            DataRow dr = viewModel.dtRprice.Rows[i];
                            if (ConvertTool.ToInt(dr["KeyID"].ToString()) < 0)
                            {
                                model.ProdCode = dr["ProdCode"].ToString();
                                model.RPriceCode = "";
                                model.RPriceTypeCode = dr["RPriceTypeCode"].ToString();
                                model.RefPrice = ConvertTool.ToDecimal(dr["RefPrice"].ToString());
                                model.Price = ConvertTool.ToDecimal(dr["Price"].ToString());
                                model.StartDate = ConvertTool.ToDateTime(dr["StartDate"].ToString());
                                model.EndDate = ConvertTool.ToDateTime(dr["EndDate"].ToString());
                                model.MemberPrice = ConvertTool.ToDecimal(dr["MemberPrice"].ToString());
                                bllrp.Add(model);
                            }
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


        public ExecResult Update()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_PRODUCT bll = new Edge.SVA.BLL.BUY_PRODUCT();
                Edge.SVA.BLL.BUY_BARCODE bllbar = new SVA.BLL.BUY_BARCODE();
                Edge.SVA.BLL.BUY_RPRICE_M bllrp = new SVA.BLL.BUY_RPRICE_M();
                Edge.SVA.BLL.BUY_CPRICE_M bllcp = new SVA.BLL.BUY_CPRICE_M();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (rtn.Message == "")
                {
                    bll.Update(viewModel.MainTable);
                    //BARCODE
                    bllbar.DeleteData(viewModel.MainTable.ProdCode);
                    if (viewModel.dtBarCode != null)
                    {
                        for (int i = 0; i < viewModel.dtBarCode.Rows.Count; i++)
                        {
                            Edge.SVA.Model.BUY_BARCODE model = new SVA.Model.BUY_BARCODE();
                            DataRow dr = viewModel.dtBarCode.Rows[i];
                            model.ProdCode = dr["ProdCode"].ToString();
                            model.Barcode = dr["Barcode"].ToString();
                            model.InternalBarcode = Convert.ToInt32(dr["InternalBarcode"].ToString());
                            bllbar.Add(model);
                        }
                    }
                    //RPRICE no need to delete
                    //bllrp.Delete(viewModel.MainTable.ProdCode);
                    if (viewModel.dtRprice != null)
                    {
                        for (int i = 0; i < viewModel.dtRprice.Rows.Count; i++)
                        {
                            Edge.SVA.Model.BUY_RPRICE_M model = new SVA.Model.BUY_RPRICE_M();
                            DataRow dr = viewModel.dtRprice.Rows[i];
                            if (ConvertTool.ToInt(dr["KeyID"].ToString()) < 0)
                            {
                                model.ProdCode = dr["ProdCode"].ToString();
                                model.RPriceCode = "";
                                model.RPriceTypeCode = dr["RPriceTypeCode"].ToString();
                                model.RefPrice = ConvertTool.ToDecimal(dr["RefPrice"].ToString());
                                model.Price = ConvertTool.ToDecimal(dr["Price"].ToString());
                                model.StartDate = ConvertTool.ToDateTime(dr["StartDate"].ToString());
                                model.EndDate = ConvertTool.ToDateTime(dr["EndDate"].ToString());
                                model.MemberPrice = ConvertTool.ToDecimal(dr["MemberPrice"].ToString());
                                bllrp.Add(model);
                            }
                        }
                    }
                    //CPRICE
                    bllcp.Add(viewModel.dtCprice);
                }

            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }


        public void InsetNoSalesData(DataTable dt)
        {
            Edge.SVA.BLL.BUY_PRODUCT bll = new Edge.SVA.BLL.BUY_PRODUCT();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    Edge.SVA.Model.BUY_PRODUCT product = bll.GetModel(item["ProdCode"].ToString());
                    if (product != null)
                    {
                        product.NonSale = 1;
                        bll.Update(product);
                    }
                }
            }
        }


        /// <summary>
        /// Bauhaus货品修改
        /// </summary>
        /// <returns></returns>
        public ExecResult BauhausUpdate()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_PRODUCT bll = new Edge.SVA.BLL.BUY_PRODUCT();
                Edge.SVA.BLL.BUY_BARCODE bllbar = new SVA.BLL.BUY_BARCODE();
                Edge.SVA.BLL.BUY_RPRICE_M bllrp = new SVA.BLL.BUY_RPRICE_M();
                Edge.SVA.BLL.BUY_SUPPROD bllsp = new SVA.BLL.BUY_SUPPROD();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (rtn.Message == "")
                {
                    bll.Update(viewModel.MainTable);
                    //BARCODE
                    bllbar.DeleteData(viewModel.MainTable.ProdCode);
                    if (viewModel.dtBarCode != null)
                    {
                        for (int i = 0; i < viewModel.dtBarCode.Rows.Count; i++)
                        {
                            Edge.SVA.Model.BUY_BARCODE model = new SVA.Model.BUY_BARCODE();
                            DataRow dr = viewModel.dtBarCode.Rows[i];
                            model.ProdCode = dr["ProdCode"].ToString();
                            model.Barcode = dr["Barcode"].ToString();
                            model.InternalBarcode = Convert.ToInt32(dr["InternalBarcode"].ToString());
                            bllbar.Add(model);
                        }
                    }
                    //RPRICE no need to delete
                    //bllrp.Delete(viewModel.MainTable.ProdCode);
                    if (viewModel.dtRprice != null)
                    {
                        for (int i = 0; i < viewModel.dtRprice.Rows.Count; i++)
                        {
                            Edge.SVA.Model.BUY_RPRICE_M model = new SVA.Model.BUY_RPRICE_M();
                            DataRow dr = viewModel.dtRprice.Rows[i];
                            if (ConvertTool.ToInt(dr["KeyID"].ToString()) < 0)
                            {
                                model.ProdCode = dr["ProdCode"].ToString();
                                model.RPriceCode = "";
                                model.RPriceTypeCode = dr["RPriceTypeCode"].ToString();
                                model.RefPrice = ConvertTool.ToDecimal(dr["RefPrice"].ToString());
                                model.Price = ConvertTool.ToDecimal(dr["Price"].ToString());
                                model.StartDate = ConvertTool.ToDateTime(dr["StartDate"].ToString());
                                model.EndDate = ConvertTool.ToDateTime(dr["EndDate"].ToString());
                                model.MemberPrice = ConvertTool.ToDecimal(dr["MemberPrice"].ToString());
                                bllrp.Add(model);
                            }
                        }
                    }
                    //BUY_SUPPROD删除
                    bllsp.Delete(viewModel.MainTable.ProdCode);
                    if (viewModel.dtSUPPROD != null)
                    {
                        for (int i = 0; i < viewModel.dtSUPPROD.Rows.Count; i++)
                        {
                            Edge.SVA.Model.BUY_SUPPROD model = new SVA.Model.BUY_SUPPROD();
                            DataRow dr = viewModel.dtSUPPROD.Rows[i];
                            model.ProdCode = dr["ProdCode"].ToString();
                            model.VendorCode = dr["VendorCode"].ToString();
                            model.SUPPLIER_PRODUCT_CODE = dr["SUPPLIER_PRODUCT_CODE"].ToString();
                            if (!string.IsNullOrEmpty(dr["in_tax"].ToString()))
                            {
                                model.in_tax = Convert.ToDecimal(dr["in_tax"]);
                            }
                            else
                            {
                                model.in_tax = 0;
                            }
                            model.Prefer = Convert.ToInt32(dr["Prefer"]);
                            model.IsDefault = Convert.ToInt32(dr["IsDefault"]);
                            bllsp.Add(model);
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

        public ExecResult Delete(string ProdCode)
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_PRODUCT bll = new Edge.SVA.BLL.BUY_PRODUCT();
                Edge.SVA.BLL.BUY_BARCODE bllbar = new SVA.BLL.BUY_BARCODE();
                Edge.SVA.BLL.BUY_RPRICE_M bllrp = new SVA.BLL.BUY_RPRICE_M();
                Edge.SVA.BLL.BUY_CPRICE_M bllcp = new SVA.BLL.BUY_CPRICE_M();

                if (rtn.Message == "")
                {
                    bllbar.DeleteData(ProdCode);
                    bllcp.Delete(ProdCode);
                    bllrp.Delete(ProdCode);
                    bll.Delete(ProdCode);
                }

            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }


        /// <summary>
        /// 根据条件查询列表
        /// 创建人：王丽
        /// 创建时间：2016-03-28
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public DataSet GetTransactionListByParm(string strWhere, string filedOrder, string webSiteName)
        {
            Edge.SVA.BLL.BUY_PRODUCT bll = new Edge.SVA.BLL.BUY_PRODUCT();
            DataSet ds = bll.GetListByParm(strWhere, filedOrder, webSiteName);
            return ds;
        }

        public string ValidateForm()
        {
            return "";
        }

        public string ValidateObject(string strWhere)
        {
            Edge.SVA.BLL.BUY_PRODUCT bll = new SVA.BLL.BUY_PRODUCT();
            List<Edge.SVA.Model.BUY_PRODUCT> list = bll.GetModelList("ProdCode = '" + strWhere + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }

        #region 下拉框绑定
        public void BindBrand(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_BRAND bll = new SVA.BLL.BUY_BRAND();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "BrandCode", "BrandName1", "BrandName2", "BrandName3", "BrandCode");
        }
        public void BindProSize(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_PRODUCTSIZE bll = new SVA.BLL.BUY_PRODUCTSIZE();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "ProductSizeCode", "ProductSizeName1", "ProductSizeName2", "ProductSizeName3", "ProductSizeCode");
        }
        public void BindDepart(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_DEPARTMENT bll = new SVA.BLL.BUY_DEPARTMENT();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "DepartCode", "DepartName1", "DepartName2", "DepartName3", "DepartCode");
        }
        public void BindStore(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_STORE bll = new SVA.BLL.BUY_STORE();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "StoreCode", "StoreName1", "StoreName2", "StoreName3", "StoreCode");
        }
        public void BindProdClass(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_PRODUCTCLASS bll = new SVA.BLL.BUY_PRODUCTCLASS();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "ProdClassCode", "ProdClassDesc1", "ProdClassDesc2", "ProdClassDesc3", "ProdClassCode");
        }
        public void BindReplenFormula(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_REPLENFORMULA bll = new SVA.BLL.BUY_REPLENFORMULA();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "ReplenFormulaCode", "Description", "Description", "Description", "ReplenFormulaCode");
        }
        public void BindFulfillmentHouse(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_FULFILLMENTHOUSE bll = new SVA.BLL.BUY_FULFILLMENTHOUSE();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "FulfillmentHouseCode", "FulfillmentHouseName1", "FulfillmentHouseName2", "FulfillmentHouseName3", "FulfillmentHouseCode");
        }
        public void BindColor(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_COLOR bll = new SVA.BLL.BUY_COLOR();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "ColorCode", "ColorName1", "ColorName2", "ColorName3", "ColorCode");
        }
        public void BindRPriceType(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_RPRICETYPE bll = new SVA.BLL.BUY_RPRICETYPE();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "RPriceTypeCode", "RPriceTypeName1", "RPriceTypeName2", "RPriceTypeName3", "RPriceTypeCode");
        }
        public void BindStoreGroup(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_STOREGROUP bll = new SVA.BLL.BUY_STOREGROUP();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "StoreGroupCode", "StoreGroupName1", "StoreGroupName2", "StoreGroupName3", "StoreGroupCode");
        }
        #endregion

    }
}