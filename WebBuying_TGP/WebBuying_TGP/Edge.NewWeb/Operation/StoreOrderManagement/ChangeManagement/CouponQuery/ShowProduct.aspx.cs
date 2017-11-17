using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FineUI;

namespace Edge.Web.Operation.CouponManagement.ChangeManagement.CouponQuery
{
    public partial class ShowProduct : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                this.Grid1.PageSize = webset.ContentPageNum;
                BindList();
            }
        }

        private void BindList()
        {
            Edge.SVA.BLL.CouponTypeExchangeBinding bll = new Edge.SVA.BLL.CouponTypeExchangeBinding();

            int couponTypeID = Edge.Utils.Tools.ConvertTool.GetInstance().ConverToType<int>(Request.Params["CouponTypeID"]);

            string strWhere = " CouponTypeID=" + couponTypeID + " and BindingType=2 and DepartCode is null ";

            this.Grid1.RecordCount = bll.GetCount(strWhere);

            DataSet ds = bll.GetList(this.Grid1.PageSize, this.Grid1.PageIndex, strWhere, "BrandID");

            Edge.Web.Tools.DataTool.AddBrandName(ds, "BrandName", "BrandID");

            this.Grid1.DataSource = ds.Tables[0].DefaultView;
            this.Grid1.DataBind();
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            this.Grid1.PageIndex = e.NewPageIndex;
            BindList();
        }
    }
}
