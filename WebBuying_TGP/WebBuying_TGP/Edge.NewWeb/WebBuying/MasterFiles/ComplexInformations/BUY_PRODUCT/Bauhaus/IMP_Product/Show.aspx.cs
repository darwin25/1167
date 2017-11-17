using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;
using Edge.Web.Tools;
using System.Data;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT.Bauhaus.IMP_Product
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.IMP_PRODUCT, Edge.SVA.Model.IMP_PRODUCT>
    {
        #region 公用业务逻辑类
        Tools.Logger logger = Tools.Logger.Instance;
        IMP_PRODUCTController controller = new IMP_PRODUCTController();
        Edge.SVA.BLL.Company companyBLL =new SVA.BLL.Company();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                SVASessionInfo.IMP_PRODUCTController = null;

            }
            controller = SVASessionInfo.IMP_PRODUCTController;
            logger.WriteOperationLog(this.PageName, "Show");

        }
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);

            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                controller.LoadViewModel(Model.INTERNAL_PRODUCT_CODE);
                if (controller.ViewModel.MainTable != null)
                {
                    Edge.SVA.Model.Company company = companyBLL.GetCompanyByCode(controller.ViewModel.MainTable.COMPANY_ID);
                   if (company != null)
                   {
                       CompanyID.Text = company.CompanyName;
                   }
                   LAST_UPDATE_DATE.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(controller.ViewModel.MainTable.LAST_UPDATE_DATE);
                   if (controller.ViewModel.MainTable.RETIRED == "N")
                   {
                       RETIRED.Text = "过期产品";
                   }
                   //供应商产品
                   if (controller.ViewModel.dtSUPPROD != null && controller.ViewModel.dtSUPPROD.Rows.Count > 0)
                   {
                       BindResultList3(controller.ViewModel.dtSUPPROD);

                   }
                }
            }
        }

        #region 操作供应商
        private void BindResultList3(DataTable dt)
        {
            if (dt != null)
            {
                this.AddResultListGrid3.PageSize = webset.ContentPageNum;
                this.AddResultListGrid3.RecordCount = dt.Rows.Count;
                DataTable viewDT = Edge.Web.Tools.ConvertTool.GetPagedTable(dt, this.AddResultListGrid3.PageIndex + 1, this.AddResultListGrid3.PageSize);
                this.AddResultListGrid3.DataSource = viewDT;
                this.AddResultListGrid3.DataBind();

            }
            else
            {
                this.AddResultListGrid3.PageSize = webset.ContentPageNum;
                this.AddResultListGrid3.PageIndex = 0;
                this.AddResultListGrid3.RecordCount = 0;
                this.AddResultListGrid3.DataSource = null;
                this.AddResultListGrid3.DataBind();
            }
        }

        protected void AddResultListGrid3_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            AddResultListGrid3.PageIndex = e.NewPageIndex;

            BindResultList3(controller.ViewModel.dtSUPPROD);
        }
        #endregion
        protected string GetIsDefault(int IsDefault)
        {
            if (IsDefault == 0)
                return "No";
            else
                return "Yes";
        }
    }
}