using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ProductSettings.BUY_ProductAssociated;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.IO;
using System.Data;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.ProductSettings.BUY_ProductAssociated
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_ProductAssociated, Edge.SVA.Model.BUY_ProductAssociated>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingProdAssociatedController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                SVASessionInfo.BuyingProdAssociatedController = null;

                this.ProdCode.Text = Request.Params["ProdCode"].ToString();

                btnSelect.OnClientClick = Window2.GetShowReference("../../../ComplexInformations/BUY_PRODUCT/List.aspx?picker=true&ProdCode=" + this.ProdCode.Text, "Select");

            }
            controller = SVASessionInfo.BuyingProdAssociatedController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Add ");

            controller.ViewModel.MainTable = this.GetAddObject();
            if (controller.ViewModel.MainTable != null)
            {
                //校验图片类型是否正确
                string filename = this.AssociatedProdFile.Text;
                if (!ValidateImg(filename))
                {
                    return;
                }
                //保存图片到数据库
                if (controller.ViewModel.MainTable.AssociatedProdFile.Contains("ProdPic"))
                {
                    controller.ViewModel.MainTable.AssociatedProdFile = this.AssociatedProdFile.Text;
                }
                else
                {
                    controller.ViewModel.MainTable.AssociatedProdFile = this.AssociatedProdFilePath.SaveToServer("BUY_ProductAssociated");
                }
            }
            ExecResult er = controller.Add();
            if (er.Success)
            {
                //新增完成后将ProdCode返还到查询界面
                SVASessionInfo.BuyingProdCode = this.ProdCode.Text;
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add ProdAssociated Success Code:" + controller.ViewModel.MainTable.ProdCode);
                CloseAndPostBack();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add ProdAssociated Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.ProdCode);
                ShowAddFailed();
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

        protected void AssociatedProdFilePath_OnFileSelected(object sender, EventArgs e)
        {
            if (AssociatedProdFilePath.HasFile)
            {
                string fileName = this.AssociatedProdFilePath.FileName;
                this.AssociatedProdFile.Text = fileName;
            }
        }

        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);

            if (!string.IsNullOrEmpty(SVASessionInfo.BuyingProdCode))
            {
                this.AssociatedProdCode.Text = SVASessionInfo.BuyingProdCode;

                if (this.AssociatedProdCode.Text != string.Empty)
                {
                    DataSet ds = controller.GetProdInfo(this.AssociatedProdCode.Text);
                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            this.AssociatedProdName.Text = dt.Rows[0]["ProdDesc1"].ToString();
                            this.AssociatedProdFile.Text = dt.Rows[0]["ProdPicFile"].ToString();
                        }
                    }
                }

            }
        }
    }
}