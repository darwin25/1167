using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Edge.Security.Manager;
using Edge.Web.Tools;

namespace Edge.Web.Accounts.Admin
{
    public partial class DeleteRole : PageBase
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
                        //JscriptPrint(Resources.MessageTips.NotSelected, "List.aspx?page=0", Resources.MessageTips.WARNING_TITLE);
                        Alert.ShowInTop(Resources.MessageTips.NotSelected, "", MessageBoxIcon.Warning, ActiveWindow.GetHidePostBackReference());
                        return;
                    }
                    logger.WriteOperationLog(this.PageName, "Delete");
                    foreach (string item in ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (string.IsNullOrEmpty(item)) continue;
                        int id = Edge.Web.Tools.ConvertTool.ToInt(item);
                        Role bizRole = new Role(id, SVASessionInfo.SiteLanguage);//todo: 修改成多语言。
                        bizRole.Delete();

                        Logger.Instance.WriteOperationLog(this.PageName, "Delete Role " + bizRole.Description);
                    }
                    Alert.ShowInTop(Resources.MessageTips.DeleteSuccess, "", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference());
                }
                catch (System.Exception ex)
                {
                    Logger.Instance.WriteErrorLog(this.PageName, "Delete Role ",ex);
                    Alert.ShowInTop(Resources.MessageTips.SystemError, "", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference());
                }                
            }
        }
    }
}