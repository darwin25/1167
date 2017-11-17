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
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_BLACKLIST, Edge.SVA.Model.BUY_BLACKLIST>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingProdParticularsController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                InitData();

                SVASessionInfo.BuyingProdParticularsController = null;
            }
            controller = SVASessionInfo.BuyingProdParticularsController;
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
                controller.LoadViewModel(Request.Params["ProdCode"].ToString(), Convert.ToInt32(Request.Params["lanid"]));
                this.SetObject();
                this.LanguageIDView.Text = this.LanguageID.SelectedText;
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
        #endregion
    }
}