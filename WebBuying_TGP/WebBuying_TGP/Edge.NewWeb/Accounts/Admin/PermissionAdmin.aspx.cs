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
using Edge.Security.Manager;
using Edge.Web.Tools;
using FineUI;
using System.Collections.Generic;

namespace Edge.Web.Accounts.Admin
{
    /// <summary>
    /// PermissionAdmin 的摘要说明。
    /// </summary>
    public partial class PermissionAdmin : PageBase
    {

        public int pcount;                      //总条数
        public int page;                        //当前页
        public int pagesize;                    //设置每页显示的大小

        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.pagesize = webset.ContentPageNum;

            if (!Page.IsPostBack)
            {

                BindDDL();
                //BindTree();
                btnDelete.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnDelete.ConfirmIcon = FineUI.MessageBoxIcon.Question;
                btnDelete.ConfirmText = Resources.MessageTips.ConfirmDeleteRecord;
            }
        }
        private void CategoriesDatabind()
        {
            DataSet CategoriesList = AccountsTool.GetAllCategories(SVASessionInfo.SiteLanguage);//todo: 修改成多语言。
            this.ClassList.DataSource = CategoriesList;
            this.ClassList.DataTextField = "Description";
            this.ClassList.DataValueField = "CategoryID";
            this.ClassList.DataBind();
        }

        private void PermissionsDatabind()
        {

            int CategoryId = Tools.ConvertTool.ConverType<int>(this.ClassList.SelectedValue);
            DataSet PermissionsList = AccountsTool.GetPermissionsByCategory(CategoryId, SVASessionInfo.SiteLanguage);//todo: 修改成多语言。
            this.Grid1.DataSource = PermissionsList;
            this.Grid1.DataBind();
        }

        #region 绑定下拉树

        private void BindDDL()
        {
            List<CustomPermissionCategory> mys = GetCustomPermissionCategory();

            // 绑定到下拉列表（启用模拟树功能）
            ClassList.EnableSimulateTree = true;
            ClassList.DataTextField = "Description";
            ClassList.DataValueField = "Id";
            ClassList.DataSimulateTreeLevelField = "TreeLevel";
            ClassList.DataSource = mys;
            ClassList.DataBind();

            // 选中根节点
            // ddlParent.SelectedValue = "0";
            ClassList.Items.Insert(0, new FineUI.ListItem() { Text = "----------", Value = "" });//Add by Nathan for All dropdownlist default value.
        }

        private void BindTree()
        {
            DataSet ds;
            ds = AccountsTool.GetAllCategories(SVASessionInfo.SiteLanguage);


            this.ClassList.Items.Clear();
            //加载树
            this.ClassList.Items.Add(new FineUI.ListItem("#", "0"));
            DataRow[] drs = ds.Tables[0].Select("ParentID= " + 0);


            foreach (DataRow r in drs)
            {
                string nodeid = r["CategoryID"].ToString();
                string text = r["Description"].ToString();
                //string parentid=r["ParentID"].ToString();
                //string permissionid=r["PermissionID"].ToString();
                text = "╋" + text;
                this.ClassList.Items.Add(new FineUI.ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank = "├";

                BindNode(sonparentid, ds.Tables[0], blank);

            }
            this.ClassList.DataBind();

        }

        private void BindNode(int parentid, DataTable dt, string blank)
        {
            DataRow[] drs = dt.Select("ParentID= " + parentid);

            foreach (DataRow r in drs)
            {
                string nodeid = r["CategoryID"].ToString();
                string text = r["Description"].ToString();
                text = blank + "『" + text + "』";
                this.ClassList.Items.Add(new FineUI.ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank2 = blank + "─";

                BindNode(sonparentid, dt, blank2);
            }
        }
        #endregion

        protected void BtnDelCategory_Click(object sender, EventArgs e)
        {
            int CategoryId = int.Parse(this.ClassList.SelectedValue);
            PermissionCategories c = new PermissionCategories();
            c.Delete(CategoryId);
            CategoriesDatabind();
            if (this.ClassList.SelectedItem != null)
            {
                PermissionsDatabind();
            }
            PermissionsDatabind();
        }

        protected void BtnAddPermissions_Click(object sender, EventArgs e)
        {
            string Permissions = this.PermissionsName.Text.Trim();
            if (Permissions != "")
            {
                int CategoryId = int.Parse(this.ClassList.SelectedValue);
                Permissions p = new Permissions();
                p.Create(CategoryId, Permissions);

                Logger.Instance.WriteOperationLog(this.PageName, "Add Permission " + Permissions);

                if (this.ClassList.SelectedItem != null)
                {
                    PermissionsDatabind();
                }
                this.PermissionsName.Text = "";
            }
            else
            {
                // this.lbltip2.Text = Resources.MessageTips.NameNotEmpty;
                PermissionsDatabind();
            }
        }

        protected void btnupSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //this.TabEdit.Visible = false;
            PermissionsDatabind();
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
          
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Permissions p = new Permissions();
                foreach (int row in Grid1.SelectedRowIndexArray)
                {
                    int permissionID = int.Parse(Grid1.DataKeys[row][0].ToString());

                    //保存日志
                    Logger.Instance.WriteOperationLog(this.PageName, "Delete Permission id " + permissionID);
                    p.Delete(permissionID);
                }
                PermissionsDatabind();
            }
            catch (System.Exception ex)
            {
                Logger.Instance.WriteErrorLog(" Permission delete ", "", ex);
                ShowError(Resources.MessageTips.UnKnownSystemError);
            }
            
        }

        protected void ClassList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PermissionsDatabind();
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] keys = Grid1.DataKeys[e.RowIndex];

            //Tools.ConvertTool.ConverType<int>(e.CommandArgument);
            int PermissionsID = Tools.ConvertTool.ConverType<int>(keys[0].ToString());
            //string strPermissionsDesc = ((Label)e.Item.FindControl("lblDescription")).Text;
            Edge.Security.Manager.Permissions pBll = new Permissions();
            string strPermissionsDesc = pBll.GetPermissionName(PermissionsID);//获取默认的名字
            switch (e.CommandName.ToLower())
            {
                case "edit":
                    this.Window1.Hidden =false;
                    this.lblPermId.Text = PermissionsID.ToString();
                    this.txtNewName.Text = strPermissionsDesc;
                    PermissionsDatabind();
                    break;

            }
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            this.Window1.Hidden = true;
        }
        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (this.txtNewName.Text.Trim() != "")
            {
                Permissions p = new Permissions();
                p.Update(int.Parse(this.lblPermId.Text), this.txtNewName.Text.Trim());

                Logger.Instance.WriteOperationLog(this.PageName, "Update Permission " + txtNewName.Text.Trim());
                PermissionsDatabind();

                this.Window1.Hidden = true;
            }
            else
            {
                PermissionsDatabind();
                Alert.ShowInTop(Resources.MessageTips.NameNotEmpty, MessageBoxIcon.Warning);
            }
        }
        public List<CustomPermissionCategory> GetCustomPermissionCategory()
        {
            List<CustomPermissionCategory> _customPermissionCategory = new List<CustomPermissionCategory>();

            List<CustomPermissionCategory> newList = new List<CustomPermissionCategory>();

            DataSet ds = AccountsTool.GetAllCategories(SVASessionInfo.SiteLanguage);

            ResolveMenuCollection(ds.Tables[0], newList, 0, 0);

            _customPermissionCategory = newList;

            return _customPermissionCategory;
        }

        private int ResolveMenuCollection(DataTable oldList, List<CustomPermissionCategory> newList, int parentId, int level)
        {
            int count = 0;
            foreach (DataRow row in oldList.Rows)
            {
                if (row["ParentID"].ToString().Trim() == parentId.ToString())
                {
                    count++;

                    CustomPermissionCategory my = new CustomPermissionCategory();
                    newList.Add(my);
                    my.TreeLevel = level;
                    my.Id = ConvertTool.ConverType<int>(row["CategoryID"].ToString());
                    my.Name = row["Description"].ToString();
                    my.Title = row["Description"].ToString();
                    my.ParentId = ConvertTool.ConverType<int>(row["ParentID"].ToString());
                    my.Description = row["Description"].ToString();
                    //my.IsModule = menu.IsModule;
                    my.OrderID = ConvertTool.ConverType<int>(row["OrderID"].ToString());

                    level++;
                    int childCount = ResolveMenuCollection(oldList, newList, my.Id, level);
                    if (childCount == 0)
                    {
                        my.IsTreeLeaf = true;
                    }
                    level--;
                }
            }

            return count;
        }
    }
}
