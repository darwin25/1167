using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Text;

namespace Edge.Web.SysManage
{
	/// <summary>
	/// LogIndex 的摘要说明。
	/// </summary>
    public partial class LogIndex : PageBase
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
            this.Grid1.PageSize = webset.ContentPageNum;
            if (!Page.IsPostBack)
            {
                RptBind("ID>0", "ID ASC");
                btnDelete.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnDelete.ConfirmIcon = FineUI.MessageBoxIcon.Question;
                btnDelete.ConfirmText = Resources.MessageTips.ConfirmDeleteRecord;

                btnDeleteAll.ConfirmIcon = FineUI.MessageBoxIcon.Question;
                btnDeleteAll.ConfirmText = Resources.MessageTips.ConfirmDeleteRecord;
            }

		}

        #region 数据列表绑定

        private void RptBind(string strWhere, string orderby)
        {
            Edge.Security.Manager.SysManage sm = new Edge.Security.Manager.SysManage();

            //获得总条数
            this.Grid1.RecordCount = sm.GetLogCount(strWhere);
            if (this.Grid1.RecordCount > 0)
            {
                this.btnDelete.Enabled = true;
                this.btnDeleteAll.Enabled = true;
            }
            else
            {
                this.btnDelete.Enabled = false;
                this.btnDeleteAll.Enabled = false;
            }

            DataSet ds = new DataSet();

            ds = sm.GetLogPageList(Grid1.PageSize, Grid1.PageIndex, strWhere, orderby);
            this.Grid1.DataSource = ds.Tables[0].DefaultView;
            this.Grid1.DataBind();
        }
        #endregion

		protected string FormatString(string str) 
		{ 
//			str=str.Replace(" ","&nbsp;&nbsp;"); 
//			str=str.Replace("<","&lt;"); 
//			str=str.Replace(">","&gt;"); 
//			str=str.Replace('\n'.ToString(),"<br>"); 
			if(str.Length>16)
			{
				str=str.Substring(0,16)+"...";
			}			
			return str; 
		} 

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            foreach (int row in Grid1.SelectedRowIndexArray)
            {
                Edge.Security.Manager.SysManage sm = new Edge.Security.Manager.SysManage();
                //保存日志
                // SaveLogs("");
                sm.DeleteLog(Grid1.DataKeys[row][0].ToString());
            }
            FineUI.Alert.ShowInTop(Resources.MessageTips.DeleteSuccess, FineUI.MessageBoxIcon.Information);

            RptBind("ID>0", "ID ASC");
        }

        protected void lbtnDelAll_Click(object sender, EventArgs e)
        {
            Edge.Security.Manager.SysManage sm = new Edge.Security.Manager.SysManage();
            sm.DeleteLog("");


            RptBind("ID>0", "ID ASC");
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            RptBind("ID>0", "ID ASC");
        }

	}
}
