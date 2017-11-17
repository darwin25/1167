using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Edge.Security.Manager;
using Edge.Web.Tools;
using System.Text;

namespace Edge.Web.Accounts.Admin
{
	/// <summary>
	/// Index 的摘要说明。
	/// </summary>
    public partial class RoleAdmin : PageBase
	{

		private DataSet roles;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
//			AccountsPrincipal currentPrincipal=new AccountsPrincipal( Context.User.Identity.Name );

//			AccountsPrincipal currentPrincipal = (AccountsPrincipal)Context.User;
//			if (!currentPrincipal.HasPermission((int)AccountsPermissions.CreateRoles))
//			{
//				NewRoleButton.Visible = false;
//				NewRoleDescription.Visible = false;
//			}
//			else 
//			{
//				NewRoleButton.Visible = true;
//				NewRoleDescription.Visible = true;
//			}
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                btnNew.OnClientClick = Window1.GetShowReference("addrole.aspx", "Add");
                btnDelete.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnDelete.ConfirmIcon = FineUI.MessageBoxIcon.Question;
                btnDelete.ConfirmText = Resources.MessageTips.ConfirmDeleteRecord;
                dataBind();
            }
		}
		private void dataBind()
		{
            roles = AccountsTool.GetRoleList(SVASessionInfo.SiteLanguage);//todo: 修改成多语言。
            Grid1.DataSource = roles.Tables["Roles"];
            Grid1.DataBind();
		}
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            //foreach (int row in Grid1.SelectedRowIndexArray)
            //{
            //    int id = Edge.Web.Tools.ConvertTool.ToInt(Grid1.DataKeys[row][0].ToString());
            //    Role bizRole = new Role(id, SVASessionInfo.SiteLanguage);//todo: 修改成多语言。
            //    bizRole.Delete();

            //    Logger.Instance.WriteOperationLog(this.PageName, "Delete Role " + bizRole.Description);

            //}
            //FineUI.Alert.ShowInTop(Resources.MessageTips.DeleteSuccess, FineUI.MessageBoxIcon.Information);

            //dataBind();
            StringBuilder sb = new StringBuilder();
            foreach (int row in Grid1.SelectedRowIndexArray)
            {
                sb.Append(Grid1.DataKeys[row][0].ToString());
                sb.Append(",");
            }
            ExecuteJS(HiddenWindowForm.GetShowReference("DeleteRole.aspx?ids=" + sb.ToString().TrimEnd(','), "Delete"));

        }
        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            dataBind();
        }
        //protected void BtnAdd_Click(object sender, EventArgs e)
        //{

            
        //    //if (TextBox1.Text.Trim() == "")
        //    //{
        //    //    JscriptPrintAndFocus(Resources.MessageTips.SpecifyRoleName, "", Resources.MessageTips.WARNING_TITLE, TextBox1.ClientID);
        //    //}
        //    Role role = new Role();
        //    role.Description = TextBox1.Text;
        //    try
        //    {
        //        role.Create();

        //        Logger.Instance.WriteOperationLog(this.PageName, "Add Role " + role.Description);
        //    }
        //    catch { }
        //    TextBox1.Text = "";
        //    dataBind();
        //}

	}
}
