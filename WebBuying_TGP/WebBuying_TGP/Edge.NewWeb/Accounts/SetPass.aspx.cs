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
using Edge.Web.Tools;

namespace Edge.Web.Accounts
{
	/// <summary>
	/// SetPass 的摘要说明。
	/// </summary>
    public partial class SetPass : PageBase
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
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

		protected void btnUpdate_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid) 
			{	
				string username=this.txtUserName.Text;
				string passward=this.txtPassword.Text;
				
				Edge.Security.Manager.User currentUser=new Edge.Security.Manager.User();				
			
				if (!currentUser.SetPassword(username,passward))
				{
                    Logger.Instance.WriteOperationLog(this.PageName, "Change Password " + username);

					this.lblMsg.ForeColor=Color.Red;
					this.lblMsg.Text = Resources.MessageTips.UpdateFailed;
				}
				else 
				{
					this.lblMsg.ForeColor=Color.Blue;
					this.lblMsg.Text = Resources.MessageTips.UpdateSuccess;
				}
				
			}
		
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.txtPassword.Text="";
			this.txtPassword1.Text="";
		}
	}
}
