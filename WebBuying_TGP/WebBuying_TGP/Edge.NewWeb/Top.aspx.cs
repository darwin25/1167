using System;
using Edge.Web.Tools;

namespace Edge.Web.Admin
{
	/// <summary>
	/// Top 的摘要说明。
	/// </summary>
	public partial class Top : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblMember;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				
				if (!Context.User.Identity.IsAuthenticated )
				{
//					Session["message"]="你没有通过权限审核！";
//					Session["returnPage"]="main.htm";
//					Response.Redirect("Login.aspx",true);
					Response.Clear();
					Response.Write("<script language=javascript>window.alert('您没有权限进入本页！\\n请登录或与管理员联系！');history.back();</script>");
					Response.End();
				}
				else
				{
//					AccountsPrincipal user=new AccountsPrincipal(Context.User.Identity.Name);
//					Edge.Security.Manager.User usern=new Edge.Security.Manager.User(user);
                    if (SVASessionInfo.CurrentUser.UserName.Length==0)
					{
						return ;
					}
                    Edge.Security.Manager.User currentUser = SVASessionInfo.CurrentUser;
					//this.lblSignIn.Text=currentUser.TrueName;
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
