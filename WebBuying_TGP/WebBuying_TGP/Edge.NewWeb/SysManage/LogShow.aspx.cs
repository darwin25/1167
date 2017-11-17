using System;
using System.Data;
using FineUI;
namespace Edge.Web.SysManage
{
	/// <summary>
	/// LogShow 的摘要说明。
	/// </summary>
	public partial class LogShow : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
                btnClose.OnClientClick = ActiveWindow.GetHideRefreshReference();

				if(Request.Params["id"]!=null && Request.Params["id"].Trim()!="")
				{
					string id=Request.Params["id"];
					Edge.Security.Manager.SysManage sm=new Edge.Security.Manager.SysManage();
					DataRow row=sm.GetLog(id);
                    this.lblTime.Text= row["datetime"].ToString();
                    this.lblErrMsg.Text= row["loginfo"].ToString();
                    this.lblParticular.Text= row["Particular"].ToString().Replace("\r\n", "<br>");	
					
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
