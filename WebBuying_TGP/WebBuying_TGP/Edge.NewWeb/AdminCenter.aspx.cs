using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Edge.Web
{
    public partial class AdminCenter : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    //Button1.OnClientClick = Window1.GetShowReference("AdminConfig.aspx", "弹出窗口一");
            //    //Button2.OnClientClick = checkright1.ModelDialogParent.GetShowReference("../AdminConfig.aspx", "弹出窗口二");
            //    //Window1.Close += new EventHandler<WindowCloseEventArgs>(ModelDialogSelf_Close);

            //    this.lblWebName.Text=webset.WebName.ToString();
            //    this.lblWebUrl.Text = webset.WebUrl.ToString();
            //    this.lblWebPath.Text = webset.WebPath.ToString();
            //    this.lblWebManagePath.Text = webset.WebManagePath.ToString();
            //    this.lblWebTel.Text = webset.WebTel.ToString();
            //    this.lblWebFax.Text = webset.WebFax.ToString();
            //    this.lblWebEmail.Text = webset.WebEmail.ToString();

            //    lblMachineName.Text = Server.MachineName;
            //    lblIP.Text = Request.ServerVariables["LOCAL_ADDR"];
            //    lblVersion.Text = Environment.Version.ToString();
            //    lblOS.Text = Environment.OSVersion.ToString();
            //    lblIIS.Text = Request.ServerVariables["SERVER_SOFTWARE"];
            //    lblPort.Text = Request.ServerVariables["SERVER_PORT"];
            //    lblAPPL_PHYSICAL_PATH.Text=Request.ServerVariables["APPL_PHYSICAL_PATH"];
            //    lblHTTPS.Text = Request.ServerVariables["HTTPS"];
            //    lblSession.Text = Session.Keys.Count.ToString();

            //}
        }

        //void ModelDialogSelf_Close(object sender, WindowCloseEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        //{
        //    Alert.ShowInTop("Window1被Close了！");
        //}

        //protected void Window2_Close(object sender, FineUI.WindowCloseEventArgs e)
        //{
        //    Alert.ShowInTop("Window2被Close了！");
        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    checkright1.ModelDialogSelf.GetShowReference("../AdminConfig.aspx", "弹出窗口一");
        //}

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    checkright1.ModelDialogParent.GetShowReference("../AdminConfig.aspx", "弹出窗口二");
        //}
    }
}
