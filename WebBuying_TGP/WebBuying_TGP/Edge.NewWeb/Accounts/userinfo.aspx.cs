﻿using System;
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
using FineUI;
using Edge.Web.Tools;
namespace Edge.Web.Accounts
{
	/// <summary>
	/// userinfo 的摘要说明。
	/// </summary>
    public partial class userinfo : PageBase
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack) 
			{

                if (!hasRight)
                {
                    return;
                }
                 // btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();

				if (Context.User.Identity.IsAuthenticated)
				{

                    AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name,SVASessionInfo.SiteLanguage);//todo: 修改成多语言。
					User currentUser=new Edge.Security.Manager.User(user);

					this.lblName.Text=currentUser.UserName;
                    this.lblTrueName.Text = currentUser.TrueName;
					this.rdblSex.SelectedValue=currentUser.Sex.Trim();
					this.lblPhone.Text=currentUser.Phone;
					this.lblEmail.Text=currentUser.Email;
                    this.lblSex.Text = this.rdblSex.SelectedItem.Text;

                   // lblUserIP.Text = Request.UserHostAddress;

                    //if(currentUser.DepartmentID=="-1")
                    //{
                    //    string herosoftmana=Edge.Common.ConfigHelper.GetConfigString("AdManager");
                    //    this.lblDepart.Text=herosoftmana;
                    //}
                    //else
                    //{
						
                    //        if(Edge.Common.PageValidate.IsNumber(currentUser.DepartmentID))
                    //        {
                    //            Edge.BLL.ADManage.AdSupplier supp=new Edge.BLL.ADManage.AdSupplier();
                    //            Edge.Model.ADManage.AdSupplier suppmodel=supp.GetModel(int.Parse(currentUser.DepartmentID));
                    //            this.lblDepart.Text=suppmodel.SupplierName;
                    //            this.lblModeys.Text=suppmodel.Moneys.ToString();
                    //        }
						
						
                    //}
                    //switch(currentUser.Style)
                    //{
                    //    case 1:
                    //        this.lblStyle.Text="默认蓝";
                    //        break;
                    //    case 2:
                    //        this.lblStyle.Text="橄榄绿";
                    //        break;
                    //    case 3:
                    //        this.lblStyle.Text="深红";
                    //        break;
                    //    case 4:
                    //        this.lblStyle.Text="深绿";
                    //        break;
                    //}
					


//					if(user.Roles.Count>0)
//					{
//						RoleList.Visible = true;
//						ArrayList roles = user.Roles;
//						RoleList.Text = "角色列表：<ul>";
//						for(int i=0;i<roles.Count;i++)
//						{
//							RoleList.Text+="<li>" + roles[i] + "</li>";
//						}
//						RoleList.Text += "</ul>";
//					}



//					if(user.Permissions.Count>0)
//					{
//						RoleList.Visible = true;
//						ArrayList Permissions = user.Permissions;
//						RoleList.Text = "权限列表：<ul>";
//						for(int i=0;i<Permissions.Count;i++)
//						{
//							RoleList.Text+="<li>" + Permissions[i] + "</li>";
//						}
//						RoleList.Text += "</ul>";
//					}




				}



			}

		}

	
		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码Edit器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion
	}
}
