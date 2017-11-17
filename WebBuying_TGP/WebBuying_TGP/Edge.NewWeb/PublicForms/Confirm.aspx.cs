using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Messages.Manager;
using FineUI;

namespace Edge.Web.PublicForms
{
    public partial class Confirm : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HiddenFormInfo info = SVASessionInfo.HiddenFormInfo;
            //if (!string.IsNullOrEmpty(info.OkScript))
            //{
            //    PageContext.RegisterStartupScript(FineUI.Confirm.GetShowReference(info.Message, info.Title, info.MessageBoxIcon, info.OkScript, "", Target.Top));
            //}
            if (!IsPostBack)
            {
                CloseAndPostBack();
            }
        }
    }
}