using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Edge.Security.Manager;
using Edge.Web.Tools;

namespace Edge.Web.Accounts.LanAdmin
{
    public partial class PermissionLanAdmin : PageBase
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                InsertForm.Hidden = true;
                UpdateForm.Hidden = true;
                BindDDL();
                BindPermissionListByCategory();
                BindLanListByPermission();
                LanTools.BindLanList(this.ddlLanList);
            }
        }

        #region 绑定下拉树
        private void BindDDL()
        {
            List<CustomPermissionCategory> mys = GetCustomPermissionCategory();

            // 绑定到下拉列表（启用模拟树功能）
            ddlCategoryList.EnableSimulateTree = true;
            ddlCategoryList.DataTextField = "Description";
            ddlCategoryList.DataValueField = "Id";
            ddlCategoryList.DataSimulateTreeLevelField = "TreeLevel";
            ddlCategoryList.DataSource = mys;
            ddlCategoryList.DataBind();

            // 选中根节点
            // ddlParent.SelectedValue = "0";
            ddlCategoryList.Items.Insert(0, new FineUI.ListItem() { Text = "----------", Value = "" });//Add by Nathan for All dropdownlist default value.
        }
        private void BindCategoryTree()
        {
            DataSet ds;
            ds = AccountsTool.GetAllCategories(SVASessionInfo.SiteLanguage);


            this.ddlCategoryList.Items.Clear();
            //加载树
            this.ddlCategoryList.Items.Add(new FineUI.ListItem("#", "0"));
            DataRow[] drs = ds.Tables[0].Select("ParentID= " + 0);


            foreach (DataRow r in drs)
            {
                string nodeid = r["CategoryID"].ToString();
                string text = r["Description"].ToString();
                //string parentid=r["ParentID"].ToString();
                //string permissionid=r["PermissionID"].ToString();
                text = "╋" + text;
                this.ddlCategoryList.Items.Add(new FineUI.ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank = "├";

                BindNode(sonparentid, ds.Tables[0], blank);

            }
            this.ddlCategoryList.DataBind();

        }

        private void BindNode(int parentid, DataTable dt, string blank)
        {
            DataRow[] drs = dt.Select("ParentID= " + parentid);

            foreach (DataRow r in drs)
            {
                string nodeid = r["CategoryID"].ToString();
                string text = r["Description"].ToString();
                text = blank + "『" + text + "』";
                this.ddlCategoryList.Items.Add(new FineUI.ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank2 = blank + "─";

                BindNode(sonparentid, dt, blank2);
            }
        }
        #endregion

        private void BindPermissionListByCategory()
        {
            if (!string.IsNullOrEmpty(this.ddlCategoryList.SelectedValue))
            {
                int CategoryId = int.Parse(this.ddlCategoryList.SelectedValue);
                DataSet PermissionsList = AccountsTool.GetPermissionsByCategory(CategoryId, SVASessionInfo.SiteLanguage);//todo: 修改成多语言。
                this.ddlList.DataSource = PermissionsList.Tables["Categories"];
                this.ddlList.DataValueField = "PermissionID";
                this.ddlList.DataTextField = "Description";
                this.ddlList.DataBind();
            }
        }

        private void BindLanListByPermission()
        {
            if (!string.IsNullOrEmpty(this.ddlList.SelectedValue))
            {
                Edge.Security.Manager.Lan_Accounts_Permissions lanBll = new Edge.Security.Manager.Lan_Accounts_Permissions();
                int PermissionId = int.Parse(this.ddlList.SelectedValue);
                DataSet LanList = lanBll.GetList(" PermissionID=" + PermissionId);
                LanTools.AddLanDesc(LanList, "LanDesc", "Lan");
                this.Grid1.DataSource = LanList;
                this.Grid1.DataBind();
            }
        }

        protected void btnDisplayInsertLan_Click(object sender, EventArgs e)
        {
            this.InsertForm.Hidden = false;
            this.UpdateForm.Hidden = true;
            this.txtNewLan.Text = "";
        }

        protected void btnModifyLan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtModifyLan.Text.Trim()))
            {
                FineUI.Alert.ShowInTop(Resources.MessageTips.NameNotEmpty, FineUI.MessageBoxIcon.Warning);
                return;
            }

            Edge.Security.Manager.Lan_Accounts_Permissions p = new Edge.Security.Manager.Lan_Accounts_Permissions();
            Edge.Security.Model.Lan_Accounts_Permissions item = new Edge.Security.Model.Lan_Accounts_Permissions();
            item.Description = this.txtModifyLan.Text.Trim();
            item.Lan = this.hfLan.Text.Trim();
            item.PermissionID = Tools.ConvertTool.ConverType<int>(this.hfnodeID.Text.Trim());
            p.Update(item);
            Logger.Instance.WriteOperationLog(this.PageName, "Update Permission Language: " + item.Description + " and Language: " + item.Lan);

            this.UpdateForm.Hidden = true;
            BindLanListByPermission();
        }

        protected void btnModifyCancel_Click(object sender, EventArgs e)
        {
            this.UpdateForm.Hidden = true;
        }

        protected void btnInsertLan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNewLan.Text.Trim()))
            {
                FineUI.Alert.ShowInTop(Resources.MessageTips.NameNotEmpty, FineUI.MessageBoxIcon.Warning);
                return;
            }

            if (new Edge.Security.Manager.Lan_Accounts_Permissions().GetCount(string.Format(" Lan='{0}' and PermissionID={1}", this.ddlLanList.SelectedItem.Value.Trim(), Tools.ConvertTool.ToInt(this.ddlList.SelectedValue))) > 0)
            {
                FineUI.Alert.ShowInTop(Resources.MessageTips.Exists, FineUI.MessageBoxIcon.Warning);
                return;
            }

            Edge.Security.Manager.Lan_Accounts_Permissions bllLan = new Edge.Security.Manager.Lan_Accounts_Permissions();
            Edge.Security.Model.Lan_Accounts_Permissions item = new Edge.Security.Model.Lan_Accounts_Permissions();
            item.Description = this.txtNewLan.Text.Trim();
            item.Lan = this.ddlLanList.SelectedItem.Value;
            item.PermissionID = Tools.ConvertTool.ToInt(this.ddlList.SelectedValue);
            bllLan.Add(item);
            Logger.Instance.WriteOperationLog(this.PageName, "Add Permission Language: " + item.Description + " and Language: " + item.Lan);

            this.InsertForm.Hidden = true;
            BindLanListByPermission();
        }

        protected void btnInsertCancel_Click(object sender, EventArgs e)
        {
            this.InsertForm.Hidden = true;
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            foreach (int row in Grid1.SelectedRowIndexArray)
            {
                int NodeID = Tools.ConvertTool.ConverType<int>(Grid1.DataKeys[row][0].ToString());
                string strText = Grid1.DataKeys[row][1].ToString();
                string strLan = Grid1.DataKeys[row][2].ToString();


                Edge.Security.Manager.Lan_Accounts_Permissions p = new Edge.Security.Manager.Lan_Accounts_Permissions();
                Edge.Security.Model.Lan_Accounts_Permissions item = new Edge.Security.Model.Lan_Accounts_Permissions();
                item.Description = strText;
                item.Lan = strLan;
                item.PermissionID = NodeID;
                p.Delete(item);
                Logger.Instance.WriteOperationLog(this.PageName, "Delete Permission Language: " + item.Description + " and Language: " + item.Lan);            
            }
            FineUI.Alert.ShowInTop(Resources.MessageTips.DeleteSuccess, FineUI.MessageBoxIcon.Information);

            BindLanListByPermission();
        }

        protected void ddlCategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPermissionListByCategory();
            BindLanListByPermission();
        }

        protected void ddlList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindLanListByPermission();
        }

        protected void Grid1_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            object[] keys = Grid1.DataKeys[e.RowIndex];

            int nodeID = Tools.ConvertTool.ConverType<int>(keys[0].ToString());
            string strDesc = keys[1].ToString();//获取默认的名字
            hfnodeID.Text = nodeID.ToString();
            hfLan.Text = keys[2].ToString();
            switch (e.CommandName.ToLower())
            {
                case "edit":
                    this.UpdateForm.Hidden = false;
                    this.InsertForm.Hidden = true;
                    this.txtModifyLan.Text = strDesc.ToString();
                    break;

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
