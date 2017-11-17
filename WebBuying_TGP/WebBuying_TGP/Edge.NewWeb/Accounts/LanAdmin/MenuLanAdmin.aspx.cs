using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Edge.Web.Tools;

namespace Edge.Web.Accounts.LanAdmin
{
    public partial class MenuLanAdmin : PageBase
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
                BindTree();
                BindLanListByNode();
            }
        }

        #region 绑定下拉树
        private void BindTree()
        {
            List<CustomPermissionCategory> mys = GetBindTree();

            // 绑定到下拉列表（启用模拟树功能）
            ddlList.EnableSimulateTree = true;
            ddlList.DataTextField = "Name";
            ddlList.DataValueField = "Id";
            ddlList.DataSimulateTreeLevelField = "TreeLevel";
            ddlList.DataSource = mys;
            ddlList.DataBind();

            // 选中根节点
            // ddlParent.SelectedValue = "0";
            ddlList.Items.Insert(0, new FineUI.ListItem() { Text = "----------", Value = "" });//Add by Nathan for All dropdownlist default value.
        }

        public List<CustomPermissionCategory> GetBindTree()
        {
            List<CustomPermissionCategory> _customPermissionCategory = new List<CustomPermissionCategory>();

            List<CustomPermissionCategory> newList = new List<CustomPermissionCategory>();

            Edge.Security.Manager.SysManage sm = new Edge.Security.Manager.SysManage();
            DataSet ds = sm.GetTreeList("");

            ResolveBindTreeMenuCollection(ds.Tables[0], newList, 0, 0);

            _customPermissionCategory = newList;

            return _customPermissionCategory;
        }

        private int ResolveBindTreeMenuCollection(DataTable oldList, List<CustomPermissionCategory> newList, int parentId, int level)
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
                    my.Id = ConvertTool.ConverType<int>(row["NodeID"].ToString());
                    my.Name = row["Text"].ToString();
                    my.ParentId = ConvertTool.ConverType<int>(row["ParentID"].ToString());
                    level++;
                    int childCount = ResolveBindTreeMenuCollection(oldList, newList, my.Id, level);
                    if (childCount == 0)
                    {
                        my.IsTreeLeaf = true;
                    }
                    level--;
                }
            }

            return count;
        }
        #endregion

        private void BindLanListByNode()
        {
            Edge.Security.Manager.Lan_S_Tree lanBll = new Edge.Security.Manager.Lan_S_Tree();
            if (!string.IsNullOrEmpty(this.ddlList.SelectedValue))
            {
                int NodeID = int.Parse(this.ddlList.SelectedValue);
                DataSet LanList = lanBll.GetList(" NodeID=" + NodeID);
                LanTools.AddLanDesc(LanList, "LanDesc", "Lan");
                this.Grid1.DataSource = LanList;
                this.Grid1.DataBind();
            }
        }

        protected void btnDisplayInsertLan_Click(object sender, EventArgs e)
        {
            this.InsertForm.Hidden = false;
            this.UpdateForm.Hidden = true;
            this.txtNewLan.Text="";
        }

        protected void btnModifyLan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtModifyLan.Text.Trim()))
            {
                FineUI.Alert.ShowInTop(Resources.MessageTips.NameNotEmpty,FineUI.MessageBoxIcon.Warning);
                return;
            }

            Edge.Security.Manager.Lan_S_Tree p = new Edge.Security.Manager.Lan_S_Tree();
            Edge.Security.Model.Lan_S_Tree item = new Edge.Security.Model.Lan_S_Tree();
            item.Text = this.txtModifyLan.Text.Trim();
            item.Lan = this.hfLan.Text.Trim();
            item.NodeID = Tools.ConvertTool.ConverType<int>(this.hfnodeID.Text.Trim());
            p.Update(item);
            Logger.Instance.WriteOperationLog(this.PageName, "Update Menu Language: " + item.Text + " and Language: " + item.Lan);
            this.UpdateForm.Hidden = true;
            BindLanListByNode();
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

            if (new Edge.Security.Manager.Lan_S_Tree().GetCount(string.Format(" Lan='{0}' and NodeID={1}", this.ddlLanList.SelectedItem.Value.Trim(), Tools.ConvertTool.ToInt(this.ddlList.SelectedValue))) > 0)
            {
                FineUI.Alert.ShowInTop(Resources.MessageTips.Exists, FineUI.MessageBoxIcon.Warning);
                return;
            }

            Edge.Security.Manager.Lan_S_Tree bllLan = new Edge.Security.Manager.Lan_S_Tree();
            Edge.Security.Model.Lan_S_Tree item = new Edge.Security.Model.Lan_S_Tree();
            item.Text = this.txtNewLan.Text.Trim();
            item.Lan = this.ddlLanList.SelectedItem.Value;
            item.NodeID = Tools.ConvertTool.ToInt(this.ddlList.SelectedValue);
            bllLan.Add(item);
            Logger.Instance.WriteOperationLog(this.PageName, "Add Menu Language: " + item.Text + " and Language: " + item.Lan);
            this.InsertForm.Hidden = true;

            BindLanListByNode();
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

                Edge.Security.Manager.Lan_S_Tree p = new Edge.Security.Manager.Lan_S_Tree();
                Edge.Security.Model.Lan_S_Tree item = new Edge.Security.Model.Lan_S_Tree();
                item.Text = strText;
                item.Lan = strLan;
                item.NodeID = NodeID;
                p.Delete(item);
                Logger.Instance.WriteOperationLog(this.PageName, "Delete Menu Language: " + item.Text + " and Language: " + item.Lan);
                //保存日志
                // SaveLogs("" + model.Title);                
            }
            FineUI.Alert.ShowInTop(Resources.MessageTips.DeleteSuccess, FineUI.MessageBoxIcon.Information);

            BindLanListByNode();
        }

        protected void ddlList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindLanListByNode();
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

    }
}
