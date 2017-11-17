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
    public partial class MessageOK : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.label.Text = SVASessionInfo.MessageHTML;
                SVASessionInfo.MessageHTML = "成功";

                //this.btnOK.OnClientClick = ActiveWindow.GetHidePostBackReference();
            }
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            this.CloseAndPostBack();
        }
    }
}