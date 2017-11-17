using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ProductSettings.BUY_ProductParticulars;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.Data;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.ProductSettings.BUY_ProductParticulars
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_ProductParticulars, Edge.SVA.Model.BUY_ProductParticulars>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingProdParticularsController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                InitData();

                SVASessionInfo.BuyingProdParticularsController = null;

                this.ProdCode.Text = Request.Params["ProdCode"].ToString();
            }
            controller = SVASessionInfo.BuyingProdParticularsController;
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                if (!hasRight) return;
                controller.LoadViewModel(Request.Params["ProdCode"].ToString(), Convert.ToInt32(Request.Params["lanid"]));
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
                SVASessionInfo.BuyingProdCode = this.ProdCode.Text;
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update ProductParticulars Success Code:" + controller.ViewModel.MainTable.ProdCode);
                CloseAndPostBack();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update ProductParticulars Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.ProdCode);
                ShowUpdateFailed();
            }
        }

        protected void InitData()
        {
            Edge.SVA.BLL.LanguageMap bll = new SVA.BLL.LanguageMap();
            DataSet ds = bll.GetList("");
            Tools.ControlTool.BindDataSet(this.LanguageID, ds, "KeyID", "LanguageDesc", "LanguageDesc", "LanguageDesc");
        }

        #region 由于表主键是组合主键，故需重载基类取数方式以及存储方式
        protected override void SetObject()
        {
            SetObject(controller.ViewModel.MainTable, this.Form.Controls.GetEnumerator());
        }

        protected override SVA.Model.BUY_ProductParticulars GetPageObject(SVA.Model.BUY_ProductParticulars obj)
        {
            return base.GetPageObject(obj, this.Form.Controls.GetEnumerator());
        }
        #endregion
    }
}