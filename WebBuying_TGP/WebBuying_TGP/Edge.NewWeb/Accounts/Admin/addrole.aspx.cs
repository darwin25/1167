using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Edge.Security.Manager;
using Edge.Web.Tools;

namespace Edge.Web.Accounts.Admin
{
    public partial class addrole : PageBase
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            string newname = this.TxtNewname.Text.Trim();
            Role role = new Role();
            role.Description = newname;
            try
            {
                role.Create();
                Logger.Instance.WriteOperationLog(this.PageName, "Add Role " + role.Description);
                CloseAndRefresh();
            }
            catch(Exception ex)
            {
                ShowWarning(ex.Message);
            }
            TxtNewname.Text = "";
        }
    }
}