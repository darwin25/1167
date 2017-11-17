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
using System.Configuration;
using Edge.Web.Tools;

namespace Edge.Web.Accounts
{
	/// <summary>
	/// usermodify 的摘要说明。
	/// </summary>
    public partial class usermodify : PageBase
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack) 
			{


                if (!hasRight)
                {
                    return;
                }
				if (Context.User.Identity.IsAuthenticated)
				{
                    AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name, SVASessionInfo.SiteLanguage.ToString());	//todo: 修改成多语言。					
					User currentUser=new Edge.Security.Manager.User(user);

                    this.txtUserName.Text = currentUser.UserName; txtUserName.Enabled = false;
					txtTrueName.Text=currentUser.TrueName;
                    this.rdblSex.SelectedValue = currentUser.Sex.Trim();
					this.txtPhone.Text=currentUser.Phone;
					txtEmail.Text=currentUser.Email;

//					for(int i=0;i<this.Dropdepart.Items.Count;i++)
//					{
//						if(this.Dropdepart.Items[i].Value==currentUser.DepartmentID)
//						{
//							this.Dropdepart.Items[i].Selected=true;
//						}
//					}

                    //for (int i = 0; i < this.dropUserType.Items.Count; i++)
                    //{
                    //    if (this.dropUserType.Items[i].Value == currentUser.UserType)
                    //    {
                    //        this.dropUserType.Items[i].Selected = true;
                    //    }
                    //}

					//this.dropStyle.SelectedIndex=currentUser.Style-1;

					//BindRoles(user);

					
				}

			}

		}

        protected void btnSaveClose_Click(object sender, System.EventArgs e)
        {
            string username = this.txtUserName.Text.Trim();
            AccountsPrincipal user = new AccountsPrincipal(username, SVASessionInfo.SiteLanguage.ToString());//todo: 修改成多语言。
            User currentUser = new Edge.Security.Manager.User(user);
            currentUser.UserName = username;
            currentUser.TrueName = txtTrueName.Text.Trim();
            currentUser.Sex = this.rdblSex.SelectedValue;
            currentUser.Phone = this.txtPhone.Text.Trim();
            currentUser.Email = txtEmail.Text.Trim();
            //currentUser.UserType = dropUserType.SelectedValue;
            //int style=int.Parse(this.dropStyle.SelectedValue);
            //currentUser.Style=style;
            currentUser.Style = 1;
            if (!currentUser.Update())
            {
                FineUI.Alert.ShowInTop(Resources.MessageTips.UpdateFailed, FineUI.MessageBoxIcon.Error);
            }
            else
            {
                Logger.Instance.WriteOperationLog(this.PageName, "Update User " + currentUser.UserName);

                FineUI.Alert.ShowInTop(Resources.MessageTips.UpdateSuccess, FineUI.MessageBoxIcon.Information);
            }
        }

        //private void BindRoles(AccountsPrincipal user)
        //{
        //    //if(user.Permissions.Count>0)
        //    //{
        //    //    RoleList.Visible = true;
        //    //    ArrayList Permissions = user.Permissions;
        //    //    RoleList.Text = "<ul>";
        //    //    for(int i=0;i<Permissions.Count;i++)
        //    //    {
        //    //        RoleList.Text+="<li>" + Permissions[i] + "</li>";
        //    //    }
        //    //    RoleList.Text += "</ul>";
        //    //}
        //    if (user.Roles.Count > 0)
        //    {
        //        RoleList.Visible = true;
        //        ArrayList Roles = user.Roles;
        //        RoleList.Text = "<ul>";
        //        for (int i = 0; i < Roles.Count; i++)
        //        {
        //            RoleList.Text += "<li>" + Roles[i] + "</li>";
        //        }
        //        RoleList.Text += "</ul>";
        //    }
        //}

        //protected void btnAdd_Click(object sender, System.EventArgs e)
        //{
        //    if (Page.IsValid) 
        //    {			
        //        string username=this.lblName.Text.Trim();
        //        AccountsPrincipal user = new AccountsPrincipal(username,SVASessionInfo.SiteLanguage.ToString());//todo: 修改成多语言。
        //        User currentUser=new Edge.Security.Manager.User(user);
        //        currentUser.UserName=username;
        //        currentUser.TrueName=txtTrueName.Text.Trim();
        //        currentUser.Sex = this.rdblSex.SelectedValue;
        //        currentUser.Phone=this.txtPhone.Text.Trim();
        //        currentUser.Email=txtEmail.Text.Trim();
        //        //currentUser.UserType = dropUserType.SelectedValue;
        //        //int style=int.Parse(this.dropStyle.SelectedValue);
        //        //currentUser.Style=style;
        //        currentUser.Style = 1;
        //        if (!currentUser.Update())
        //        {
        //            this.lblMsg.ForeColor=Color.Red;
        //            this.lblMsg.Text = Resources.MessageTips.UpdateFailed;
        //        }
        //        else 
        //        {
        //            Logger.Instance.WriteOperationLog(this.PageName, "Update User " + currentUser.UserName);

        //            this.lblMsg.ForeColor=Color.Blue;
        //            this.lblMsg.Text = Resources.MessageTips.UpdateSuccess;
        //            Response.Redirect("userinfo.aspx");
        //        }
        //    }
        //}

        //protected void btnReturn_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("userinfo.aspx");
        //}
	}
}
