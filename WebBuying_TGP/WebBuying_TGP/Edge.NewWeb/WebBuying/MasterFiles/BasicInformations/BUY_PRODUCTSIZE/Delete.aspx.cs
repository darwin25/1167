using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_PRODUCTSIZE
{
    public partial class Delete : PageBase
    {
        Tools.Logger logger = Tools.Logger.Instance;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    if (!hasRight)
                    {
                        return;
                    }
                    string ids = Request.Params["ids"];
                    if (string.IsNullOrEmpty(ids))
                    {
                        FineUI.Alert.ShowInTop(Resources.MessageTips.NotSelected, "", MessageBoxIcon.Warning, ActiveWindow.GetHidePostBackReference());
                        return;
                    }
                    logger.WriteOperationLog(this.PageName, " Delete " + ids);
                    foreach (string id in ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                    {
                        Edge.Web.Tools.DALTool.Delete<Edge.SVA.BLL.BUY_PRODUCTSIZE>(Tools.ConvertTool.ToInt(id));
                    }
                    Alert.ShowInTop(Resources.MessageTips.DeleteSuccess, "", FineUI.MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference());
                }
                catch (System.Exception ex)
                {
                    logger.WriteErrorLog(this.PageName, "Delete", ex);
                    Alert.ShowInTop(Resources.MessageTips.SystemError, "", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference());
                }
            }
        }
    }
}