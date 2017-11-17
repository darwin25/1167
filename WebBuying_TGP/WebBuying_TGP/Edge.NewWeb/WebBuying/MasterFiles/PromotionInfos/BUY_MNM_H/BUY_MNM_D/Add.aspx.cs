using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Edge.Web.Tools;
using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.BUY_MNM_H;

namespace Edge.Web.WebBuying.MasterFiles.PromotionInfos.BUY_MNM_H.BUY_MNM_D
{
    public partial class Add : PageBase
    {
        BuyingMnmController controller = new BuyingMnmController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(this.btnClose);

                InitData();

            }
            controller = SVASessionInfo.BuyingMnmController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            //controller.ViewModel.SubTable.Rows.Add(1);
            //int RowIndex = controller.ViewModel.SubTable.Rows.Count - 1;
            //controller.ViewModel.SubTable.Rows[RowIndex]["KeyID"] = -1 - RowIndex;
            //controller.ViewModel.SubTable.Rows[RowIndex]["MNMCode"] = this.MNMCode.Text;
            //controller.ViewModel.SubTable.Rows[RowIndex]["EntityNum"] = this.EntityNum.Text;
            //controller.ViewModel.SubTable.Rows[RowIndex]["EntityType"] = this.EntityType.SelectedValue;
            //controller.ViewModel.SubTable.Rows[RowIndex]["EntityTypeName"] = this.EntityType.SelectedText;
            //controller.ViewModel.SubTable.Rows[RowIndex]["Type"] = this.Type.SelectedValue;
            //controller.ViewModel.SubTable.Rows[RowIndex]["TypeName"] = this.Type.SelectedText;
            //controller.ViewModel.SubTable.Rows[RowIndex]["Qty"] = this.Qty.Text;

            DataTable dt = ViewState["table"] as DataTable;
            //dt.Columns.Add("MNMCode", typeof(string));
            //dt.Columns.Add("Type", typeof(string));
            //dt.Columns.Add("Qty", typeof(string));
            //dt.Columns.Add("TypeName", typeof(string));
            //foreach (DataRow dr in dt.Rows)
            //{
            //    dr["MNMCode"] = this.MNMCode.Text;
            //    dr["Type"] = this.Type.SelectedValue;
            //    dr["Qty"] = this.Qty.Text;

            //    dr["TypeName"] = this.Type.SelectedText;
            //}
            controller.ViewModel.SubTable = dt;
            CloseAndPostBack();
        }

        protected void InitData()
        {
            this.MNMCode.Text = Request.Params["MNMCode"].ToString();

            DataTable dt = new DataTable();
            dt.Columns.Add("EntityType", typeof(string));
            dt.Columns.Add("EntityTypeName", typeof(string));
            dt.Columns.Add("EntityNum", typeof(string));

            dt.Columns.Add("MNMCode", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Qty", typeof(string));
            dt.Columns.Add("TypeName", typeof(string));

            ViewState["table"] = dt;
            ViewState["count"] = 0;
        }

        protected void EntityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EntityNum.Text = "";
            // to do
            this.Type.SelectedValue = "0";
            this.Qty.Text = "0";
            if (this.EntityType.SelectedValue == "1")
            {
                btnSelect.OnClientClick = Window2.GetShowReference("../../../ComplexInformations/BUY_PRODUCT/List.aspx?picker=true", "Select");
            }
            else if (this.EntityType.SelectedValue == "2")
            {
                btnSelect.OnClientClick = Window2.GetShowReference("../../../BasicInformations/BUY_DEPARTMENT/List.aspx?picker=true", "Select");
            }
            else if (this.EntityType.SelectedValue == "3")
            {
                btnSelect.OnClientClick = Window2.GetShowReference("../../../BasicInformations/BUY_CURRENCY/List.aspx?picker=true", "Select");
            }
        }

        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            if (this.EntityType.SelectedValue == "1")
            {
                this.EntityNum.Text = SVASessionInfo.BuyingProdCode;
            }
            else if (this.EntityType.SelectedValue == "2")
            {
                this.EntityNum.Text = SVASessionInfo.BuyingDepartCode;
            }
            else if (this.EntityType.SelectedValue == "3")
            {
                this.EntityNum.Text = SVASessionInfo.BuyingTendCode;
            }
            RptBind();
        }

        protected void RptBind()
        {
            DataTable dt = ViewState["table"] as DataTable;
            if (this.EntityType.SelectedValue != "-1" && this.EntityNum.Text != "")
            {
                dt.Rows.Add(1);
                int RowIndex = dt.Rows.Count - 1;
                dt.Rows[RowIndex]["EntityType"] = this.EntityType.SelectedValue;
                dt.Rows[RowIndex]["EntityTypeName"] = this.EntityType.SelectedText;
                dt.Rows[RowIndex]["EntityNum"] = this.EntityNum.Text;

                dt.Rows[RowIndex]["MNMCode"] = this.MNMCode.Text;
                dt.Rows[RowIndex]["Type"] = this.Type.SelectedValue;
                dt.Rows[RowIndex]["Qty"] = this.Qty.Text;
                dt.Rows[RowIndex]["TypeName"] = this.Type.SelectedText;

                ViewState["count"] = Convert.ToInt32(ViewState["count"]) + 1;
                ViewState["table"] = dt;

                this.Grid1.RecordCount = Convert.ToInt32(ViewState["count"]);
                this.Grid1.DataSource = dt.DefaultView;
                this.Grid1.DataBind();
            }
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            RptBind();
        }
    }
}