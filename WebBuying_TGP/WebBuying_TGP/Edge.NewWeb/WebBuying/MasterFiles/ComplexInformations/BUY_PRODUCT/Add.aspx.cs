using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.IO;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_PRODUCT, Edge.SVA.Model.BUY_PRODUCT>
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

                SVASessionInfo.BuyingProductController = null;

                InitData();
            }
            controller = SVASessionInfo.BuyingProductController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Add ");

            controller.ViewModel.MainTable = this.GetAddObject();
            if (controller.ViewModel.MainTable != null)
            {
                //校验图片类型是否正确
                if (!ValidateImg(this.ProdPicFile.FileName))
                {
                    return;
                }
                controller.ViewModel.MainTable.ProdPicFile = this.ProdPicFile.SaveToServer("ProdPic");
                controller.ViewModel.MainTable.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.CreatedOn = System.DateTime.Now;
            }

            ExecResult er = controller.Add();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Product Success Code:" + controller.ViewModel.MainTable.ProdCode);
                CloseAndRefresh();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Product Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.ProdCode);
                ShowSaveFailed(er.Message);
            }

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
    }
}