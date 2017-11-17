using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ProductSettings.BUY_PRODUCTSTYLE;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.Data;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.ProductSettings.BUY_PRODUCTSTYLE
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_PRODUCTSTYLE, Edge.SVA.Model.BUY_PRODUCTSTYLE>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingProductStyleController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                SVASessionInfo.BuyingProductStyleController = null;

                //btnSelect.OnClientClick = Window2.GetShowReference("../../../ComplexInformations/BUY_PRODUCT/List.aspx?picker=true", "Select");

            }
            controller = SVASessionInfo.BuyingProductStyleController;
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                if (!hasRight) return;
                controller.LoadViewModel(Request.Params["id"], Request["code"]);
                this.SetObject();
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Update ");

            controller.ViewModel.MainTable = this.GetPageObject(controller.ViewModel.MainTable);
            ExecResult er = controller.Update();
            if (er.Success)
            {
                //新增完成后将ProdCode返还到查询界面
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update Product Style Success Code:" + controller.ViewModel.MainTable.ProdCode);
                CloseAndPostBack();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update Product Style Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.ProdCode);
                ShowSaveFailed(er.Message);
            }
        }

        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);

            //if (!string.IsNullOrEmpty(SVASessionInfo.BuyingProdCode))
            //{
            //    this.ProdCode.Text = SVASessionInfo.BuyingProdCode;
            //}
        }

        #region 由于表主键是组合主键，故需重载基类取数方式以及存储方式
        protected override void SetObject()
        {
            SetObject(controller.ViewModel.MainTable, this.Form.Controls.GetEnumerator());
        }
        protected override SVA.Model.BUY_PRODUCTSTYLE GetPageObject(SVA.Model.BUY_PRODUCTSTYLE obj)
        {
            return base.GetPageObject(obj, this.Form.Controls.GetEnumerator());
        }
        #endregion
    }
}