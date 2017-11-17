using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.Operation.StoreOrderManagement.ReceiveStoreOrder;
using System.Data;
using System.IO;
using System.Drawing;

namespace Edge.Web.WebLinks
{
    public partial class StoreReceive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                string ShipmentOrderNumber = Server.UrlDecode(Request.QueryString["id"]);

                this.GetReceiveOrderHeader(ShipmentOrderNumber);

                GridView1.DataBind();

                GridView1.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                GridView1.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                //GridView1.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
                //GridView1.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
                GridView1.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
                GridView1.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
                GridView1.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
                //GridView1.HeaderRow.Cells[7].Attributes["data-hide"] = "phone";

                //Adds THEAD and TBODY to GridView.
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                //ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnExport);
            }
        }

        private void GetReceiveOrderHeader(string ShipmentOrderNumber)
        {
            ReceiveStoreOrderController controller = new ReceiveStoreOrderController();

            DataSet ds = controller.GetReceiveOrderHeader(ShipmentOrderNumber);
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtStoreOrderNumber.Text = ds.Tables[0].Rows[0]["StoreOrderNumber"].ToString();
                txtPickingOrderNumber.Text = ds.Tables[0].Rows[0]["PickingOrderNumber"].ToString();
                txtShippingOrderNumber.Text = ds.Tables[0].Rows[0]["ShipmentOrderNumber"].ToString();
                txtReceiveOrderNumber.Text = ds.Tables[0].Rows[0]["ReceiveOrderNumber"].ToString();
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Page")
            {
                int rIndex;
                string ProdCode;

                rIndex = Convert.ToInt32(e.CommandArgument.ToString());

            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Operation/StoreOrderManagement/ReceiveStoreOrder/List.aspx");

        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            string fromdate = Server.UrlDecode(Request.QueryString["fromdate"]); ;
            string todate = Server.UrlDecode(Request.QueryString["todate"]); ;
            string attachment = "attachment; filename=BayanPay Pending Orders " + fromdate + " to " + todate + ".xls";
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", attachment);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView1.AllowPaging = false;
                GridView1.DataBind();

                GridView1.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    cell.BackColor = GridView1.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                GridView1.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[5].Visible = false;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}   