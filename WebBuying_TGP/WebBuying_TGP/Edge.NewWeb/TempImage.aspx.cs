using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Edge.Web.Tools;

namespace Edge.Web
{
    public partial class TempImage : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["TempImage"] != null)
            //{
            //    byte[] bytes = Session["TempImage"] as byte[];

            //    if (bytes != null && bytes.Length >= 1)
            //    {
            //        Response.BinaryWrite(bytes);
            //    }
            //}
            if (SVASessionInfo.TempImage != null)
            {
                byte[] bytes = SVASessionInfo.TempImage;

                if (bytes != null && bytes.Length >= 1)
                {
                    Response.BinaryWrite(bytes);
                }
            }
            if (!this.IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideRefreshReference();
                string url = Request.QueryString["url"];
                if (!url.StartsWith("~"))
                {
                    url = url.Insert(0, "~");
                }
                if (!System.IO.File.Exists(Server.MapPath(url)))
                {
                    Alert.ShowInTop(Resources.MessageTips.FileNotExist, "", MessageBoxIcon.Warning, ActiveWindow.GetHideReference());
                    //this.ErrorMessage.Text = Resources.MessageTips.FileNotExist;
                    this.img.Visible = false;
                }
                else
                {
                    this.img.ImageUrl = url;
                }
            }
        }
    }
}
