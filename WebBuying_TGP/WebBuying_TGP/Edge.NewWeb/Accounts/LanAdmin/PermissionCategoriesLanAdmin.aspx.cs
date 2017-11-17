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
    public partial class PermissionCategoriesLanAdmin : PageBase
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
                LanTools.BindLanList(this.ddlLanList);
                BindCategoryTree();
                //BindTreeList();
                //BindLanListByCategory();
                BindDDL();
            }
        }

        #region 绑定下拉树
        private void BindDDL()
        {
            List<CustomPermissionCategory> mys = GetCustomPermissionCategory();

            // 绑定到下拉列表（启用模拟树功能）
            ddlList.EnableSimulateTree = true;
            ddlList.DataTextField = "Description";
            ddlList.DataValueField = "Id";
            ddlList.DataSimulateTreeLevelField = "TreeLevel";
            ddlList.DataSource = mys;
            ddlList.DataBind();

            // 选中根节点
            // ddlParent.SelectedValue = "0";
            ddlList.Items.Insert(0, new FineUI.ListItem() { Text = "----------", Value = "" });//Add by Nathan for All dropdownlist default value.
        }
        private void BindCategoryTree()
        {
            DataSet ds;
            ds = AccountsTool.GetAllCategories(SVASessionInfo.SiteLanguage);

            this.ddlList.Items.Clear();
            //加载树
            this.ddlList.Items.Add(new FineUI.ListItem("#", "0"));
            DataRow[] drs = ds.Tables[0].Select("ParentID= " + 0);


            foreach (DataRow r in drs)
            {
                string nodeid = r["CategoryID"].ToString();
                string text = r["Description"].ToString();
                //string parentid=r["ParentID"].ToString();
                //string permissionid=r["PermissionID"].ToString();
                text = "╋" + text;
                this.ddlList.Items.Add(new FineUI.ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank = "├";

                BindNode(sonparentid, ds.Tables[0], blank);

            }
            this.ddlList.DataBind();
        }

        private void BindNode(int parentid, DataTable dt, string blank)
        {
            DataRow[] drs = dt.Select("ParentID= " + parentid);

            foreach (DataRow r in drs)
            {
                string nodeid = r["CategoryID"].ToString();
                string text = r["Description"].ToString();
                text = blank + "『" + text + "』";
                this.ddlList.Items.Add(new FineUI.ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank2 = blank + "─";

                BindNode(sonparentid, dt, blank2);
            }
        }
        #endregion

        private void BindLanListByCategory()
        {
            Edge.Security.Manager.Lan_Accounts_PermissionCategories lanBll = new Edge.Security.Manager.Lan_Accounts_PermissionCategories();
            int CategoryID = int.Parse(this.ddlList.SelectedValue);

            DataSet LanList = lanBll.GetList(" CategoryID=" + CategoryID);
            LanTools.AddLanDesc(LanList, "LanDesc", "Lan");
            this.Grid1.DataSource = LanList;
            this.Grid1.DataBind();

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

            Edge.Security.Manager.Lan_Accounts_PermissionCategories p = new Edge.Security.Manager.Lan_Accounts_PermissionCategories();
            Edge.Security.Model.Lan_Accounts_PermissionCategories item = new Edge.Security.Model.Lan_Accounts_PermissionCategories();
            item.Description = this.txtModifyLan.Text.Trim();
            item.Lan = this.hfLan.Text.Trim();
            item.CategoryID = Tools.ConvertTool.ConverType<int>(this.hfnodeID.Text.Trim());
            p.Update(item);
            Logger.Instance.WriteOperationLog(this.PageName, "Update Permission Categories  Language: " + item.Description + " and Language: " + item.Lan);

            this.UpdateForm.Hidden = true;
            BindLanListByCategory();
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


            if (new Edge.Security.Manager.Lan_Accounts_PermissionCategories().GetCount(string.Format(" Lan='{0}' and CategoryID={1}", this.ddlLanList.SelectedItem.Value.Trim(), Tools.ConvertTool.ToInt(this.ddlList.SelectedValue))) > 0)
            {
                FineUI.Alert.ShowInTop(Resources.MessageTips.Exists, FineUI.MessageBoxIcon.Warning);
                return;
            }

            Edge.Security.Manager.Lan_Accounts_PermissionCategories bllLan = new Edge.Security.Manager.Lan_Accounts_PermissionCategories();
            Edge.Security.Model.Lan_Accounts_PermissionCategories item = new Edge.Security.Model.Lan_Accounts_PermissionCategories();
            item.Description = this.txtNewLan.Text.Trim();
            item.Lan = this.ddlLanList.SelectedItem.Value;
            item.CategoryID = Tools.ConvertTool.ToInt(this.ddlList.SelectedValue);
            bllLan.Add(item);
            Logger.Instance.WriteOperationLog(this.PageName, "Add Permission Categories  Language: " + item.Description + " and Language: " + item.Lan);

            this.InsertForm.Hidden = true;

            BindLanListByCategory();
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

                Edge.Security.Manager.Lan_Accounts_PermissionCategories p = new Edge.Security.Manager.Lan_Accounts_PermissionCategories();
                Edge.Security.Model.Lan_Accounts_PermissionCategories item = new Edge.Security.Model.Lan_Accounts_PermissionCategories();
                item.Description = strText;
                item.Lan = strLan;
                item.CategoryID = NodeID;
                p.Delete(item);

                Logger.Instance.WriteOperationLog(this.PageName, "Delete Permission Categories  Language: " + item.Description + " and Language: " + item.Lan);
            }
            FineUI.Alert.ShowInTop(Resources.MessageTips.DeleteSuccess, FineUI.MessageBoxIcon.Information);

            BindLanListByCategory();
        }

        protected void ddlList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindLanListByCategory();
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
