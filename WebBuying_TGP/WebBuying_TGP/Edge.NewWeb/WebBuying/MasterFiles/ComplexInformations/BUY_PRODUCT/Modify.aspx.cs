using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.Data;
using System.IO;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_PRODUCT, Edge.SVA.Model.BUY_PRODUCT>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingProductController controller = new BuyingProductController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);


                //对详情表的操作
                this.WindowSearch.Title = "Add";
                if (this.AddResultListGrid.RecordCount == 0)
                {
                    this.btnClearAllResultItem.Enabled = false;
                }
                else
                {
                    this.btnClearAllResultItem.Enabled = true;
                }

                InitData();
            }
            controller = SVASessionInfo.BuyingProductController;
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                controller.LoadViewModel(Model.ProdCode);

                if (controller.ViewModel.MainTable != null)
                {
                    if (!string.IsNullOrEmpty(controller.ViewModel.MainTable.ProdPicFile))
                    {
                        this.FormLoad.Hidden = true;
                        this.FormReLoad.Hidden = false;
                        this.btnBack.Hidden = false;
                    }
                    else
                    {
                        this.FormLoad.Hidden = false;
                        this.FormReLoad.Hidden = true;
                        this.btnBack.Hidden = true;
                    }
                    this.uploadFilePath.Text = controller.ViewModel.MainTable.ProdPicFile;

                    this.btnPreview.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image");

                }

                if (controller.ViewModel.dtBarCode != null)
                {
                    BindResultList(controller.ViewModel.dtBarCode);

                }
                if (controller.ViewModel.dtRprice != null && controller.ViewModel.dtRprice.Rows.Count > 0)
                {
                    //DataTable dt = controller.ViewModel.dtRprice.Copy();
                    //DataView dvSearch = dt.DefaultView;
                    //for (int i = 0; i < dvSearch.Count; i++)
                    //{
                    //    DataRowView drv = dvSearch[i];
                    //    drv.Delete();
                    //}
                    //dt.AcceptChanges();
                    //BindResultList2(dt);
                    BindResultList2(controller.ViewModel.dtRprice);
                }

                //BOM控制
                if (this.BOM.SelectedItem != null && this.BOM.SelectedValue == "1")
                {
                    this.MutexFlag.Enabled = true;
                }
                else
                {
                    this.MutexFlag.Enabled = false;
                }
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Update ");

            controller.ViewModel.MainTable = this.GetUpdateObject();
            if (controller.ViewModel.MainTable != null)
            {
                if (!string.IsNullOrEmpty(this.ProdPicFile.ShortFileName) && this.FormLoad.Hidden == false)
                {
                    if (!ValidateImg(this.ProdPicFile.FileName))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.ProdPicFile = this.ProdPicFile.SaveToServer("ProdPic");
                }
                else if (this.FormReLoad.Hidden == false && !string.IsNullOrEmpty(this.uploadFilePath.Text))
                {
                    if (!ValidateImg(this.uploadFilePath.Text))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.ProdPicFile = this.uploadFilePath.Text;
                }
                controller.ViewModel.MainTable.UpdatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.UpdatedOn = System.DateTime.Now;
            }

            controller.ViewModel.dtCprice = this.GetCPriceObject();

            ExecResult er = controller.Update(); //controller.Update();
            if (er.Success)
            {
                if (this.FormReLoad.Hidden == true && string.IsNullOrEmpty(controller.ViewModel.MainTable.ProdPicFile))
                {
                    DeleteFile(this.uploadFilePath.Text);
                }
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update Product Success Code:" + controller.ViewModel.MainTable.ProdCode);
                CloseAndPostBack();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update Product Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.ProdCode);
                ShowSaveFailed(er.Message);
            }

        }


        #region 操作条形码表
        protected void btnViewSearch_Click(object sender, EventArgs e)
        {
            ExecuteJS(WindowSearch.GetShowReference(string.Format("BUY_BARCODE/Add.aspx?ProdCode={0}", this.ProdCode.Text)));
        }

        protected void btnClearAllResultItem_Click(object sender, EventArgs e)
        {
            ClearGird(this.AddResultListGrid);
            controller.ViewModel.dtBarCode = null;
        }
        protected void btnDeleteResultItem_Click(object sender, EventArgs e)
        {
            if (controller.ViewModel.dtBarCode != null)
            {
                DataTable addDT = controller.ViewModel.dtBarCode;

                foreach (int row in AddResultListGrid.SelectedRowIndexArray)
                {
                    string storecode = AddResultListGrid.DataKeys[row][0].ToString();
                    for (int j = addDT.Rows.Count - 1; j >= 0; j--)
                    {
                        if (addDT.Rows[j]["Barcode"].ToString().Trim() == storecode)
                        {
                            addDT.Rows.Remove(addDT.Rows[j]);
                        }
                    }
                    addDT.AcceptChanges();
                }

                controller.ViewModel.dtBarCode = addDT;

                BindResultList(controller.ViewModel.dtBarCode);

            }
        }

        private void BindResultList(DataTable dt)
        {
            if (dt != null)
            {
                this.AddResultListGrid.PageSize = webset.ContentPageNum;
                this.AddResultListGrid.RecordCount = dt.Rows.Count;
                DataTable viewDT = Edge.Web.Tools.ConvertTool.GetPagedTable(dt, this.AddResultListGrid.PageIndex + 1, this.AddResultListGrid.PageSize);
                this.AddResultListGrid.DataSource = viewDT;
                this.AddResultListGrid.DataBind();

            }
            else
            {
                this.AddResultListGrid.PageSize = webset.ContentPageNum;
                this.AddResultListGrid.PageIndex = 0;
                this.AddResultListGrid.RecordCount = 0;
                this.AddResultListGrid.DataSource = null;
                this.AddResultListGrid.DataBind();
            }

            this.btnDeleteResultItem.Enabled = btnClearAllResultItem.Enabled = AddResultListGrid.RecordCount > 0 ? true : false;
        }

        protected void AddResultListGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            AddResultListGrid.PageIndex = e.NewPageIndex;

            BindResultList(controller.ViewModel.dtBarCode);
        }

        #endregion

        #region 操作零售价表
        protected void btnViewSearch2_Click(object sender, EventArgs e)
        {
            ExecuteJS(WindowSearch.GetShowReference(string.Format("BUY_RPRICE_M/Add.aspx?ProdCode={0}", this.ProdCode.Text)));
        }

        protected void btnClearAllResultItem2_Click(object sender, EventArgs e)
        {
            ClearGird(this.AddResultListGrid2);
            controller.ViewModel.dtRprice = null;
        }
        protected void btnDeleteResultItem2_Click(object sender, EventArgs e)
        {
            if (controller.ViewModel.dtRprice != null)
            {
                DataTable addDT = controller.ViewModel.dtRprice;

                foreach (int row in AddResultListGrid2.SelectedRowIndexArray)
                {
                    string storecode = AddResultListGrid2.DataKeys[row][0].ToString();
                    for (int j = addDT.Rows.Count - 1; j >= 0; j--)
                    {
                        if (addDT.Rows[j]["KeyID"].ToString().Trim() == storecode)
                        {
                            addDT.Rows.Remove(addDT.Rows[j]);
                        }
                    }
                    addDT.AcceptChanges();
                }

                controller.ViewModel.dtRprice = addDT;

                BindResultList2(controller.ViewModel.dtRprice);

            }
        }

        private void BindResultList2(DataTable dt)
        {
            if (dt != null)
            {
                this.AddResultListGrid2.PageSize = webset.ContentPageNum;
                this.AddResultListGrid2.RecordCount = dt.Rows.Count;
                DataTable viewDT = Edge.Web.Tools.ConvertTool.GetPagedTable(dt, this.AddResultListGrid2.PageIndex + 1, this.AddResultListGrid2.PageSize);
                this.AddResultListGrid2.DataSource = viewDT;
                this.AddResultListGrid2.DataBind();

            }
            else
            {
                this.AddResultListGrid2.PageSize = webset.ContentPageNum;
                this.AddResultListGrid2.PageIndex = 0;
                this.AddResultListGrid2.RecordCount = 0;
                this.AddResultListGrid2.DataSource = null;
                this.AddResultListGrid2.DataBind();
            }

            this.btnDeleteResultItem2.Enabled = btnClearAllResultItem2.Enabled = AddResultListGrid2.RecordCount > 0 ? true : false;
        }

        protected void AddResultListGrid2_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            AddResultListGrid2.PageIndex = e.NewPageIndex;

            BindResultList2(controller.ViewModel.dtRprice);
        }
        #endregion

        #region 操作成本价表
        protected Edge.SVA.Model.BUY_CPRICE_M GetCPriceObject()
        {
            controller.ViewModel.dtCprice.ProdCode = this.ProdCode.Text;
            controller.ViewModel.dtCprice.StartDate = ConvertTool.ToDateTime(this.StartDate1.Text);
            controller.ViewModel.dtCprice.EndDate = ConvertTool.ToDateTime(this.EndDate1.Text);
            controller.ViewModel.dtCprice.CPriceGrossCost = ConvertTool.ToDecimal(this.CPriceGrossCost.Text);
            controller.ViewModel.dtCprice.CPriceDisc1 = ConvertTool.ToDecimal(this.CPriceDisc1.Text);
            controller.ViewModel.dtCprice.CPriceDisc2 = ConvertTool.ToDecimal(this.CPriceDisc2.Text);
            controller.ViewModel.dtCprice.CPriceDisc3 = ConvertTool.ToDecimal(this.CPriceDisc3.Text);
            controller.ViewModel.dtCprice.CPriceDisc4 = ConvertTool.ToDecimal(this.CPriceDisc4.Text);
            controller.ViewModel.dtCprice.CPriceNetCost = ConvertTool.ToDecimal(this.CPriceNetCost.Text);
            return controller.ViewModel.dtCprice;
        }
        #endregion

        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            BindResultList(controller.ViewModel.dtBarCode);
            BindResultList2(controller.ViewModel.dtRprice);
        }

        protected void InitData()
        {
            controller.BindBrand(this.BrandCode);
            controller.BindStore(this.StoreCode);
            controller.BindDepart(this.DepartCode);
            controller.BindColor(this.ColorCode);
            controller.BindFulfillmentHouse(this.FulfillmentHouseCode);
            controller.BindProdClass(this.ProdClassCode);
            controller.BindProSize(this.ProductSizeCode);
            controller.BindReplenFormula(this.ReplenFormulaCode);
            controller.BindFulfillmentHouse(this.WarehouseCode);
            controller.BindFulfillmentHouse(this.DefaultPickupStoreCode);
        }

        protected void BOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.BOM.SelectedItem != null && this.BOM.SelectedValue == "1")
            {
                this.MutexFlag.Enabled = true;
            }
            else
            {
                this.MutexFlag.Enabled = false;
            }
        }

        protected void btnReUpLoad_Click(object sender, EventArgs e)
        {
            this.FormLoad.Hidden = false;
            this.FormReLoad.Hidden = true;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.uploadFilePath.Text))
            {
                this.FormLoad.Hidden = true;
                this.FormReLoad.Hidden = false;
            }
        }

        //校验图片文件是否为允许类型
        protected bool ValidateImg(string imgname)
        {
            if (!string.IsNullOrEmpty(imgname))
            {
                imgname = Path.GetExtension(imgname).TrimStart('.').ToLower();
                if (!webset.WebImageType.ToLower().Split('|').Contains(imgname))
                {
                    ShowWarning(Resources.MessageTips.ImgUpLoadFaild.Replace("{0}", webset.WebImageType.Replace("|", ",")));
                    return false;
                }
            }
            return true;
        }

        protected void WindowPic_Close(object sender, FineUI.WindowCloseEventArgs e)
        {

        }
    }
}