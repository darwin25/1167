using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Web.Controllers.WebBuying.MasterFiles.ProductSettings.BUY_PRODUCTSTYLE;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.ProductSettings.BUY_PRODUCTSTYLE
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_PRODUCTSTYLE, Edge.SVA.Model.BUY_PRODUCTSTYLE>
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

        #region 由于表主键是组合主键，故需重载基类取数方式以及存储方式
        protected override void SetObject()
        {
            SetObject(controller.ViewModel.MainTable, this.Form.Controls.GetEnumerator());
        }
        #endregion
    }
}