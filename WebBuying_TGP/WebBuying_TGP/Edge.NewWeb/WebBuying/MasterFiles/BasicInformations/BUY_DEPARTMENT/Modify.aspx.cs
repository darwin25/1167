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
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_DEPARTMENT, Edge.SVA.Model.BUY_DEPARTMENT>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingDepartmentController controller = new BuyingDepartmentController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!this.IsPostBack)
            {
                if (Model != null)
                {
                    //存在小图片时不需要验证此字段
                    if (!string.IsNullOrEmpty(Model.DepartPicFile))
                    {
                        this.FormLoad.Hidden = true;
                        this.FormReLoad.Hidden = false;
                        this.btnBack1.Hidden = false;
                    }
                    else
                    {
                        this.FormLoad.Hidden = false;
                        this.FormReLoad.Hidden = true;
                        this.btnBack1.Hidden = true;
                    }
                    //存在中图片时不需要验证此字段
                    if (!string.IsNullOrEmpty(Model.DepartPicFile2))
                    {
                        this.FormLoad1.Hidden = true;
                        this.FormReLoad1.Hidden = false;
                        this.btnBack2.Hidden = false;
                    }
                    else
                    {
                        this.FormLoad1.Hidden = false;
                        this.FormReLoad1.Hidden = true;
                        this.btnBack2.Hidden = true;
                    }
                    //存在大图片时不需要验证此字段
                    if (!string.IsNullOrEmpty(Model.DepartPicFile3))
                    {
                        this.FormLoad2.Hidden = true;
                        this.FormReLoad2.Hidden = false;
                        this.btnBack3.Hidden = false;
                    }
                    else
                    {
                        this.FormLoad2.Hidden = false;
                        this.FormReLoad2.Hidden = true;
                        this.btnBack3.Hidden = true;
                    }

                    this.uploadFilePath.Text = Model.DepartPicFile;
                    this.uploadFilePath1.Text = Model.DepartPicFile2;
                    this.uploadFilePath2.Text = Model.DepartPicFile3;

                    this.btnPreview.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image");
                    this.btnPreview1.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath1.Text, "Image");
                    this.btnPreview2.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath2.Text, "Image");

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
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, "Update");

            controller.ViewModel.MainTable = this.GetUpdateObject();
            if (controller.ViewModel.MainTable != null)
            {
                controller.ViewModel.MainTable.UpdatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.UpdatedOn = System.DateTime.Now;

                if (!string.IsNullOrEmpty(this.DepartPicFile.ShortFileName) && this.FormLoad.Hidden == false)
                {
                    if (!ValidateImg(this.DepartPicFile.FileName))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.DepartPicFile = this.DepartPicFile.SaveToServer("BUY_DEPARTMENT");
                }
                else if (this.FormReLoad.Hidden == false && !string.IsNullOrEmpty(this.uploadFilePath.Text))
                {
                    if (!ValidateImg(this.uploadFilePath.Text))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.DepartPicFile = this.uploadFilePath.Text;
                }
                if (!string.IsNullOrEmpty(this.DepartPicFile2.ShortFileName) && this.FormLoad1.Hidden == false)
                {
                    if (!ValidateImg(this.DepartPicFile2.FileName))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.DepartPicFile2 = this.DepartPicFile2.SaveToServer("BUY_DEPARTMENT");
                }
                else if (this.FormReLoad1.Hidden == false && !string.IsNullOrEmpty(this.uploadFilePath1.Text))
                {
                    if (!ValidateImg(this.uploadFilePath1.Text))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.DepartPicFile2 = this.uploadFilePath1.Text;
                }
                if (!string.IsNullOrEmpty(this.DepartPicFile3.ShortFileName) && this.FormLoad2.Hidden == false)
                {
                    if (!ValidateImg(this.DepartPicFile3.FileName))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.DepartPicFile3 = this.DepartPicFile3.SaveToServer("BUY_DEPARTMENT");
                }
                else if (this.FormReLoad2.Hidden == false && !string.IsNullOrEmpty(this.uploadFilePath2.Text))
                {
                    if (!ValidateImg(this.uploadFilePath2.Text))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.DepartPicFile3 = this.uploadFilePath2.Text;
                }
            }

            ExecResult er = controller.Update();
            if (er.Success)
            {
                if (this.FormReLoad.Hidden == true && string.IsNullOrEmpty(controller.ViewModel.MainTable.DepartPicFile))
                {
                    DeleteFile(this.uploadFilePath.Text);
                }
                if (this.FormReLoad1.Hidden == true && string.IsNullOrEmpty(controller.ViewModel.MainTable.DepartPicFile2))
                {
                    DeleteFile(this.uploadFilePath1.Text);
                }
                if (this.FormReLoad2.Hidden == true && string.IsNullOrEmpty(controller.ViewModel.MainTable.DepartPicFile3))
                {
                    DeleteFile(this.uploadFilePath2.Text);
                }
                CloseAndPostBack();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Department\t Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.DepartCode);
                ShowSaveFailed(er.Message);
            }
        }

        #region 图片处理
        protected void btnReUpLoad1_Click(object sender, EventArgs e)
        {
            this.FormLoad.Hidden = false;
            this.FormReLoad.Hidden = true;
        }

        protected void btnBack1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.uploadFilePath.Text))
            {
                this.FormLoad.Hidden = true;
                this.FormReLoad.Hidden = false;
            }
        }

        protected void btnReUpLoad2_Click(object sender, EventArgs e)
        {
            this.FormLoad1.Hidden = false;
            this.FormReLoad1.Hidden = true;
        }

        protected void btnBack2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.uploadFilePath1.Text))
            {
                this.FormLoad1.Hidden = true;
                this.FormReLoad1.Hidden = false;
            }
        }

        protected void btnReUpLoad3_Click(object sender, EventArgs e)
        {
            this.FormLoad2.Hidden = false;
            this.FormReLoad2.Hidden = true;
        }

        protected void btnBack3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.uploadFilePath2.Text))
            {
                this.FormLoad2.Hidden = true;
                this.FormReLoad2.Hidden = false;
            }
        }
        #endregion

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
            //绑定部门
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