using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Edge.SVA.Model.Domain;
using System.Text;
using Edge.Security.Manager;
using Edge.Web.Tools;

namespace Edge.Web.Accounts.Admin
{
    public partial class DeleteUser : PageBase
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

                    StringBuilder sb = new StringBuilder();
                    List<User> needDeleteUserList = new List<User>();
                    foreach (string item in ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (string.IsNullOrEmpty(item)) continue;
                        int id = Edge.Web.Tools.ConvertTool.ToInt(item);

                        User currentUser = new User(id);
                        needDeleteUserList.Add(currentUser);
                    }


                    bool canDelete = true;
                    foreach (var item in needDeleteUserList)
                    {
                        if (ConstParam.SystemAdminName.Equals(item.UserName))
                        {
                            canDelete = false;
                        }
                    }
                    if (!canDelete)
                    {
                        Alert.ShowInTop("System admin user can't be deleted!", "", MessageBoxIcon.Warning, ActiveWindow.GetHidePostBackReference());
                        return;
                    }
                    foreach (var item in needDeleteUserList)
                    {
                        Logger.Instance.WriteOperationLog(this.PageName, "Delete User " + item.UserName);
                        item.Delete();
                    }
                    Alert.ShowInTop(Resources.MessageTips.DeleteSuccess, "", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference());

                    //Alert.ShowInTop(Resources.MessageTips.DeleteSuccess, "", MessageBoxIcon.Information, "location.href='List.aspx'");
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