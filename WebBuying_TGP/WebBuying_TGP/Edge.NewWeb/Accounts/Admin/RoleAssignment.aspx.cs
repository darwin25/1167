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
using System.Collections.Generic;
using Edge.Web.Tools;

namespace Edge.Web.Accounts.Admin
{
	/// <summary>
	/// RoleAssignment 的摘要说明。
	/// </summary>
    public partial class RoleAssignment : PageBase
	{
		private int userID;
		User currentUser;
	
		protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!hasRight)
            {
                return;
            }		
			string s=Request.Params["UserID"];
			userID=int.Parse(Request.Params["UserID"]);
			currentUser = new User(userID);

            Label1.Text = Resources.MessageTips.User + " " + currentUser.UserName + Resources.MessageTips.RoleAssignment;
			if(!Page.IsPostBack)
			{
				//DataSet dsRole=AccountsTool.GetRoleList();
                DataSet dsRole = AccountsTool.GetRoleList(SVASessionInfo.SiteLanguage); //todo: 修改成多语言。
				CheckBoxList1.DataSource=dsRole.Tables[0].DefaultView;
				CheckBoxList1.DataTextField="Description";
				CheckBoxList1.DataValueField="RoleID";
				CheckBoxList1.DataBind();
                AccountsPrincipal newUser = new AccountsPrincipal(currentUser.UserName, SVASessionInfo.SiteLanguage);//todo: 修改成多语言。

				if ( newUser.RoleIDList.Count > 0 )
				{
                    IList<int> roles = newUser.RoleIDList;
					for(int i=0; i<roles.Count; i++)
					{
//						RoleList.Text += "<li>" + roles[i] + "</li>";
						foreach(ListItem item in CheckBoxList1.Items)
						{
							if(item.Value==roles[i].ToString())item.Selected=true;
						}
					}
				}
			}
		}

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected == true)
                {
                    currentUser.AddToRole(Convert.ToInt32(item.Value));


                    Logger.Instance.WriteOperationLog(this.PageName, "Add To Role " + item.Text);
                }
                else
                {
                    currentUser.RemoveRole(Convert.ToInt32(item.Value));

                    Logger.Instance.WriteOperationLog(this.PageName, "Remove Role " + item.Text);
                }
            }
            Response.Redirect("UserAdmin.aspx?page=" + Request.Params["PageIndex"]);
        }

        protected void Btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserAdmin.aspx?page=" + Request.Params["PageIndex"]);
        }
	}
}
