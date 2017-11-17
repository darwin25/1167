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
using System.Data.SqlClient;
using Edge.Security.Manager;
using Edge.Common;
using System.Text;
using Edge.Web.Tools;
using System.Collections.Generic;
using Edge.SVA.Model.Domain;
using FineUI;
using Edge.Web.Controllers.Accounts;

namespace Edge.Web.Accounts.Admin
{
    /// <summary>
    /// UserAdmin 的摘要说明。
    /// </summary>
    public partial class UserAdmin : PageBase
    {
        AccountController controller = new AccountController();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                this.Grid1.PageSize = webset.ContentPageNum;

                RptBind();
                btnNew.OnClientClick = Window1.GetShowReference("../Add.aspx", "Add");
                btnDelete.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnDelete.ConfirmIcon = FineUI.MessageBoxIcon.Question;
                btnDelete.ConfirmText = Resources.MessageTips.ConfirmDeleteRecord;
            }
        }

        #region 数据列表绑定
        private void RptBind()
        {
            User bll = new User();

            //获得总条数
            this.Grid1.RecordCount = controller.GetUserListCount(SVASessionInfo.CurrentUser);
            if (this.Grid1.RecordCount > 0)
            {
                this.btnDelete.Enabled = true;
            }
            else
            {
                this.btnDelete.Enabled = false;
                return;
            }

            DataSet ds = new DataSet();
            ds = controller.GetUserListPerPage(SVASessionInfo.CurrentUser,Grid1.PageSize, Grid1.PageIndex);
            
            this.Grid1.DataSource = ds.Tables[0].DefaultView;
            this.Grid1.DataBind();

        }
        #endregion


        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (int row in Grid1.SelectedRowIndexArray)
                {
                    sb.Append(Grid1.DataKeys[row][0].ToString());
                    sb.Append(",");
                }
                ExecuteJS(HiddenWindowForm.GetShowReference("DeleteUser.aspx?ids=" + sb.ToString().TrimEnd(','), "Delete"));
            }
            catch (System.Exception ex)
            {
                Alert.ShowInTop(Resources.MessageTips.DeleteFailed, MessageBoxIcon.Error);
            }
        }


        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            RptBind();
        }
        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            RptBind();
        }
    }
}
