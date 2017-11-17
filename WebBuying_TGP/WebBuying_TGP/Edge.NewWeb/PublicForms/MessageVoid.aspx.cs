using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using FineUI;

namespace Edge.Web.PublicForms
{
    public partial class MessageVoid : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.lblMessage.Text = SVASessionInfo.MessageHTML;
                SVASessionInfo.MessageHTML = null;
            }
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            //Response.Redirect("List.aspx");
            //FineUI.PageContext.RegisterStartupScript("history.go(-2)");
            //PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            //Response.Write("<script language=javascript>history.go(-2);</script>");
            CloseAndPostBack();
        }
    }
}