using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_DEPARTMENT;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.IO;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_DEPARTMENT
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_DEPARTMENT, Edge.SVA.Model.BUY_DEPARTMENT>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingDepartmentController controller = new BuyingDepartmentController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                SVASessionInfo.BuyingDepartmentController = null;

                InitData();
            }
            controller = SVASessionInfo.BuyingDepartmentController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Add ");

            controller.ViewModel.MainTable = this.GetAddObject();

            if (controller.ViewModel.MainTable != null)
            {
                //校验图片类型是否正确
                if (!ValidateImg(this.DepartPicFile.FileName))
                {
                    return;
                }
                if (!ValidateImg(this.DepartPicFile2.FileName))
                {
                    return;
                }
                if (!ValidateImg(this.DepartPicFile3.FileName))
                {
                    return;
                }
                controller.ViewModel.MainTable.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.CreatedOn = System.DateTime.Now;
                controller.ViewModel.MainTable.DepartPicFile = this.DepartPicFile.SaveToServer("BUY_DEPARTMENT");
                controller.ViewModel.MainTable.DepartPicFile2 = this.DepartPicFile.SaveToServer("BUY_DEPARTMENT");
                controller.ViewModel.MainTable.DepartPicFile3 = this.DepartPicFile.SaveToServer("BUY_DEPARTMENT");
            }

            ExecResult er = controller.Add();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Department Success Code:" + controller.ViewModel.MainTable.DepartCode);
                CloseAndRefresh();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Department Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.DepartCode);
                ShowSaveFailed(er.Message);
            }
        }

        //校验图片文件是否为允许类型
        protected bool ValidateImg(string imgname)
        {
            if (!string.IsNullOrEmpty(imgname))
            {
                imgname = Path.GetExtension(imgname).TrimStart('.');
                if (!webset.WebImageType.ToLower().Split('|').Contains(imgname))
                {
                    ShowWarning(Resources.MessageTips.ImgUpLoadFaild.Replace("{0}", webset.WebImageType.Replace("|", ",")));
                    return false;
                }
            }
            return true;
        }

        protected void InitData()
        {
            controller.BindReplenFormula(this.ReplenFormulaCode);
            controller.BindFulfillmentHouse(this.FulfillmentHouseCode);
            controller.BindFulfillmentHouse(this.WarehouseCode);
            controller.BindFulfillmentHouse(this.DefaultPickupStoreCode);
            //绑定店铺品牌
            ControlTool.BindStoreBrand(this.StoreBrandCode);
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
    }
}