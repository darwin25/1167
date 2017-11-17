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
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_ProductParticulars, Edge.SVA.Model.BUY_ProductParticulars>
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

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Add ");

            controller.ViewModel.MainTable = this.GetAddObject();
            ExecResult er = controller.Add();
            if (er.Success)
            {
                //新增完成后将ProdCode返还到查询界面
                SVASessionInfo.BuyingProdCode = this.ProdCode.Text;
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add ProductParticulars Success Code:" + controller.ViewModel.MainTable.ProdCode);
                CloseAndPostBack();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add ProductParticulars Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.ProdCode);
                ShowAddFailed();
            }
        }

        protected void InitData()
        {
            Edge.SVA.BLL.LanguageMap bll = new SVA.BLL.LanguageMap();
            DataSet ds = bll.GetList("");
            Tools.ControlTool.BindDataSet(this.LanguageID, ds, "KeyID", "LanguageDesc", "LanguageDesc", "LanguageDesc");
        }
    }
}