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
using System.Collections.Generic;
using System.Text;
using Edge.SVA.Model;
using FineUI;
using Edge.Web.Controllers.Accounts;

namespace Edge.Web.Accounts.Admin
{
    /// <summary>
    /// EditRole 的摘要说明。
    /// </summary>
    public partial class EditRole : PageBase
    {
        protected System.Web.UI.WebControls.Button Button1;

        private Role currentRole;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                if (Request["RoleID"] != null)
                {
                    this.RoleID.Text = Request["RoleID"].ToString().Trim();
                }
                RegisterCloseEvent(btnClose);
                //btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
                //Button btn = (Button)Page.FindControl("RemoveRoleButton");
                //btn.Attributes.Add("onclick", string.Format("return confirm('{0}');", Resources.MessageTips.ConfirmDeleteRole));
                //DoInitialDataBind();
                //CategoryDownList_SelectedIndexChanged(sender, e);
                LoadTree();
            }
        }

        //绑定类别列表
        private void DoInitialDataBind()
        {
            string roleID = this.RoleID.Text;
            //DataSet dsCardIssuer = new Edge.SVA.BLL.CardIssuer().GetAllRecordList();            
            DataSet dsBrandID = new Edge.SVA.BLL.Brand().GetAllRecordList();
            List<string> list = new List<string>();
            //DataSet dsRelationRoleIssuer = new Edge.SVA.BLL.RelationRoleIssuer().GetList(" RoleID=" +roleID);
            DataSet dsRelationRoleBrand = new Edge.SVA.BLL.RelationRoleBrand().GetList(" RoleID=" + roleID);
            foreach (DataRow item in dsRelationRoleBrand.Tables[0].Rows)
            {
                string id = item["BrandID"].ToString();
                if (!list.Contains(id))
                {
                    list.Add(id);
                }
            }

            //ControlTool.BindDataSetCheckboxList(this.CheckBoxList1, dsBrandID, "CardIssuerID", "CardIssuerName1", "CardIssuerName2", "CardIssuerName3", list);
            //ControlTool.BindDataSetCheckboxList(this.ckblBrand, dsBrandID, "BrandID", "BrandName1", "BrandName2", "BrandName3", list);


            currentRole = new Role(Convert.ToInt32(Request["RoleID"]), SVASessionInfo.SiteLanguage);//todo: 修改成多语言。
            //RoleLabel.Text = Resources.MessageTips.CurrentRole + currentRole.Description;
            this.TxtNewname.Text = currentRole.Description;

            //DataSet allCategories = AccountsTool.GetAllCategories(SVASessionInfo.SiteLanguage.ToString());//todo: 修改成多语言。
            //CategoryDownList.DataSource = allCategories.Tables[0];
            //CategoryDownList.DataTextField = "Description";
            //CategoryDownList.DataValueField = "CategoryID";
            //CategoryDownList.DataBind();

            BindTree();
        }

        #region 绑定下拉树
        private void BindTree()
        {
            DataSet ds;
            ds = AccountsTool.GetAllCategories(SVASessionInfo.SiteLanguage);


            this.CategoryDownList.Items.Clear();
            //加载树
            this.CategoryDownList.Items.Add(new FineUI.ListItem("#", "0"));
            DataRow[] drs = ds.Tables[0].Select("ParentID= " + 0);


            foreach (DataRow r in drs)
            {
                string nodeid = r["CategoryID"].ToString();
                string text = r["Description"].ToString();
                //string parentid=r["ParentID"].ToString();
                //string permissionid=r["PermissionID"].ToString();
                text = "╋" + text;
                this.CategoryDownList.Items.Add(new FineUI.ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank = "├";

                BindNode(sonparentid, ds.Tables[0], blank);

            }
            this.CategoryDownList.DataBind();

        }

        private void BindNode(int parentid, DataTable dt, string blank)
        {
            DataRow[] drs = dt.Select("ParentID= " + parentid);

            foreach (DataRow r in drs)
            {
                string nodeid = r["CategoryID"].ToString();
                string text = r["Description"].ToString();
                text = blank + "『" + text + "』";
                this.CategoryDownList.Items.Add(new FineUI.ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank2 = blank + "─";

                BindNode(sonparentid, dt, blank2);
            }
        }
        #endregion


        #region Event
        //选择类别，填充2个listbox
        protected void CategoryDownList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (CategoryDownList.SelectedItem != null)
            {
                int categoryID = Convert.ToInt32(CategoryDownList.SelectedItem.Value);
                FillLeftPermissionList(categoryID);
                FillRightPermissionList(categoryID, false);
            }
        }

        protected void RemoveRoleButton_Click(object sender, System.EventArgs e)
        {
            int currentRole = Convert.ToInt32(Request["RoleID"]);
            Role bizRole = new Role(currentRole, SVASessionInfo.SiteLanguage);//todo: 修改成多语言。
            bizRole.Delete();
            Server.Transfer("RoleAdmin.aspx");
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            string newname = this.TxtNewname.Text.Trim();
            int roleID = ConvertTool.ConverType<int>(Request["RoleID"]);
            try
            {
                currentRole = new Role(roleID, SVASessionInfo.SiteLanguage);//todo: 修改成多语言。
                currentRole.Description = newname;
                currentRole.Update();

                Logger.Instance.WriteOperationLog(this.PageName, "Update Role " + currentRole.Description);

                List<string> nodeidList = new List<string>();
                foreach (FineUI.TreeNode item in this.MyTree1.Nodes)
                {
                    AddNodeIDToList(nodeidList, item);
                }

                AccountController controller = new AccountController();
                controller.UpdateRolePermission(this.RoleID.Text, nodeidList);
                //Edge.SVA.BLL.RelationRoleIssuer bll = new Edge.SVA.BLL.RelationRoleIssuer();
                //foreach (ListItem item in this.CheckBoxList1.Items)
                //{
                //    int RoleID=ConvertTool.ToInt(item.Value);
                //    if (item.Selected)
                //    {
                //        if (!bll.Exists(roleID,RoleID))
                //        {
                //            Edge.SVA.Model.RelationRoleIssuer model = new Edge.SVA.Model.RelationRoleIssuer();
                //            model.RoleID = roleID;
                //            model.CardIssuerID = RoleID;
                //            bll.Add(model);
                //        }
                //    } 
                //    else
                //    {
                //        if (bll.Exists(roleID, RoleID))
                //        {
                //            bll.Delete(roleID,RoleID);
                //        }
                //    }
                //}

                //Edge.SVA.BLL.RelationRoleBrand bll = new Edge.SVA.BLL.RelationRoleBrand();
                //foreach (FineUI.CheckItem item in this.ckblBrand.Items)
                //{
                //    int RoleID = ConvertTool.ToInt(item.Value);
                //    if (item.Selected)
                //    {
                //        if (!bll.Exists(roleID, RoleID))
                //        {
                //            Edge.SVA.Model.RelationRoleBrand model = new Edge.SVA.Model.RelationRoleBrand();
                //            model.RoleID = roleID;
                //            model.BrandID = RoleID;
                //            bll.Add(model);
                //        }
                //    }
                //    else
                //    {
                //        if (bll.Exists(roleID, RoleID))
                //        {
                //            bll.Delete(roleID, RoleID);
                //        }
                //    }
                //}
                //DoInitialDataBind();
                Edge.SVA.BLL.RelationRoleBrand bll1 = new Edge.SVA.BLL.RelationRoleBrand();
                AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name, SVASessionInfo.SiteLanguage);

                // 2. Close本窗体，然后刷新父窗体
                CloseAndRefresh();
            }
            catch (System.Exception ex)
            {
                Alert.ShowInTop(Resources.MessageTips.UpdateFailed, MessageBoxIcon.Error);
                // JscriptPrint(Resources.MessageTips.UpdateFailed, "editrole.aspx?roleid=" + roleID.ToString(), Resources.MessageTips.FAILED_TITLE);
            }
        }

        private static void AddNodeIDToList(List<string> nodeidList, FineUI.TreeNode tn)
        {
            if (tn.Checked)
            {
                nodeidList.Add(tn.NodeID);
                if (tn.Nodes.Count >= 1)
                {
                    foreach (FineUI.TreeNode item in tn.Nodes)
                    {
                        AddNodeIDToList(nodeidList, item);
                    }
                }
            }
        }

        //protected void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    bool status = this.cbSelectAll.Checked;
        //    foreach (FineUI.CheckItem item in this.ckblBrand.Items)
        //    {
        //        item.Selected = status;
        //    }
        //}

        //增加权限
        protected void treeLeftPermission_NodeCommand(object sender, FineUI.TreeCommandEventArgs e)
        {
            try
            {
                int currentRole = Convert.ToInt32(Request["RoleID"]);
                Role bizRole = new Role(currentRole, SVASessionInfo.SiteLanguage);//todo: 修改成多语言。
                bizRole.AddPermission(Convert.ToInt32(e.NodeID));
                CategoryDownList_SelectedIndexChanged(sender, e);
            }
            catch (System.Exception ex)
            {

            }
        }

        //移除权限
        protected void treeRightPermission_NodeCommand(object sender, FineUI.TreeCommandEventArgs e)
        {
            try
            {
                int currentRole = Convert.ToInt32(Request["RoleID"]);
                Role bizRole = new Role(currentRole, SVASessionInfo.SiteLanguage);//todo: 修改成多语言。
                bizRole.RemovePermission(Convert.ToInt32(e.NodeID));
                CategoryDownList_SelectedIndexChanged(sender, e);
            }
            catch (System.Exception ex)
            {

            }
        }
        #endregion


        #region Function
        //填充非权限列表
        private void FillLeftPermissionList(int categoryId)
        {
            currentRole = new Role(Convert.ToInt32(Request["RoleID"]), SVASessionInfo.SiteLanguage);//todo: 修改成多语言。
            DataTable categories = currentRole.NoPermissions.Tables["Categories"];
            DataRow currentCategory = categories.Rows.Find(categoryId);

            if (currentCategory != null)
            {
                DataRow[] permissions = currentCategory.GetChildRows("PermissionCategories");

                this.treeLeftPermission.Nodes.Clear();
                foreach (DataRow currentRow in permissions)
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    //node.EnablePostBack = true;
                    node.EnableCheckBox = true;
                    node.EnableCheckEvent=true;
                    node.Text = (string)currentRow["Description"];
                    node.NodeID = Convert.ToString(currentRow["PermissionID"]);
                    this.treeLeftPermission.Nodes.Add(node);
                }

            }
        }


        //填充已有权限listbox
        private void FillRightPermissionList(int categoryId, bool forceSelection)
        {
            currentRole = new Role(Convert.ToInt32(Request["RoleID"]), SVASessionInfo.SiteLanguage);//todo: 修改成多语言。
            DataTable categories = currentRole.Permissions.Tables["Categories"];
            DataRow currentCategory = categories.Rows.Find(categoryId);

            if (currentCategory != null)
            {
                DataRow[] permissions = currentCategory.GetChildRows("PermissionCategories");

                this.treeRightPermission.Nodes.Clear();
                foreach (DataRow currentRow in permissions)
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    //node.EnablePostBack = true;
                    node.EnableCheckBox = true;
                    node.EnableCheckEvent = true;
                    node.Text = (string)currentRow["Description"];
                    node.NodeID = Convert.ToString(currentRow["PermissionID"]);
                    this.treeRightPermission.Nodes.Add(node);
                }
            }


        }
        #endregion

        protected void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            //bool status = this.cbSelectAll.Checked;
            //foreach (FineUI.CheckItem item in this.ckblBrand.Items)
            //{
            //    item.Selected = status;
            //}
        }

        #region for permission tree
        private void LoadTree()
        {
            try
            {
                string roleID = this.RoleID.Text;

                currentRole = new Role(int.Parse(roleID), SVASessionInfo.SiteLanguage);//todo: 修改成多语言。
                //RoleLabel.Text = Resources.MessageTips.CurrentRole + currentRole.Description;
                this.TxtNewname.Text = currentRole.Description;

                DataTable dt4 = AccountsTool.GetAllPermissionChecked(roleID);

                DataTable dt = AccountsTool.GetAllCategories(SVASessionInfo.SiteLanguage).Tables[0];
                DataTable dt2 = AccountsTool.GetAllPermission(SVASessionInfo.SiteLanguage);

                FineUI.Tree tree = this.MyTree1;
                tree.Nodes.Clear();
                DataRow[] drs = dt.Select("ParentID=0", "OrderID asc");
                foreach (DataRow item in drs)
                {
                    string nodeid = item["CategoryID"].ToString();
                    string desc = item["Description"].ToString();
                    FineUI.TreeNode tn = CreateTreeNode(nodeid, desc);
                    tree.Nodes.Add(tn);
                    CheckChildTreeNode(dt, dt2, nodeid, tn);
                }
                foreach (FineUI.TreeNode item in tree.Nodes)
                {
                    CheckedTreeNode(dt4, item);
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private static void CheckedTreeNode(DataTable dt4, FineUI.TreeNode currentTreeNode)
        {
            string[] strs = currentTreeNode.NodeID.Split('_');
            if (strs.Length == 2)
            {
                DataRow[] drs1 = dt4.Select("PermissionID=" + strs[1]);
                if (drs1.Length >= 1)
                {
                    currentTreeNode.Checked = true;
                    CheckParentNode(currentTreeNode);
                }
            }
            foreach (FineUI.TreeNode item1 in currentTreeNode.Nodes)
            {
                CheckedTreeNode(dt4, item1);

            }
        }
        private static void CheckChildTreeNode(DataTable dt, DataTable dt2, string nodeid, FineUI.TreeNode parent)
        {
            DataRow[] drs1 = dt.Select("ParentID=" + nodeid);
            foreach (DataRow item1 in drs1)
            {
                string nodeid1 = item1["CategoryID"].ToString();
                string desc1 = item1["Description"].ToString();
                FineUI.TreeNode tn1 = CreateTreeNode(nodeid1, desc1);
                parent.Nodes.Add(tn1);

                CheckChildTreeNode(dt, dt2, nodeid1, tn1);
            }
            DataRow[] drs2 = dt2.Select("CategoryID=" + nodeid);
            foreach (DataRow item2 in drs2)
            {
                string nodeid2 = item2["KeyID"].ToString();
                string desc2 = item2["Description"].ToString();
                FineUI.TreeNode tn2 = CreateTreeNode(nodeid2, desc2);
                parent.Nodes.Add(tn2);
            }
        }

        private static FineUI.TreeNode CreateTreeNode(string nodeid, string desc)
        {
            FineUI.TreeNode tn = new FineUI.TreeNode();
            tn.EnableCheckBox = true;
            tn.EnableCheckEvent = true;
            //tn.AutoPostBack = true;
            tn.NodeID = nodeid;
            tn.Text = desc;
            return tn;
        }
        protected void MyTree1_NodeCheck(object sender, FineUI.TreeCheckEventArgs e)
        {
            FineUI.Tree tree = this.MyTree1;
            if (e.Checked)
            {
                CheckParentNode(e.Node);
                if (e.Node.Nodes.Count >= 1)
                {
                    tree.CheckAllNodes(e.Node.Nodes);
                }
            }
            else
            {
                if (e.Node.Nodes.Count >= 1)
                {
                    tree.UncheckAllNodes(e.Node.Nodes);
                }
                UncheckParentNode(e.Node);
            }
        }

        private static void UncheckParentNode(FineUI.TreeNode currentNode)
        {
            FineUI.TreeNode parent = currentNode.ParentNode;
            if (parent != null)
            {
                bool treeNodeChecked = false;
                foreach (FineUI.TreeNode item in parent.Nodes)
                {
                    if (item.Checked)
                    {
                        treeNodeChecked = true;
                        break;
                    }
                }
                if (!treeNodeChecked)
                {
                    if (parent.Checked)
                    {
                        parent.Checked = false;
                    }
                    if (parent.ParentNode != null)
                    {
                        UncheckParentNode(parent);
                    }
                }
            }
        }

        private static void CheckParentNode(FineUI.TreeNode currentNode)
        {
            FineUI.TreeNode tn = currentNode.ParentNode;
            if (tn != null)
            {
                if (!tn.Checked)
                {
                    tn.Checked = true;
                }
                if (tn.ParentNode != null)
                {
                    CheckParentNode(tn);
                }
            }
        }
        protected void MyTree1CheckAll_CheckedChanged(object sender, System.EventArgs e)
        {
            FineUI.Tree tree = this.MyTree1;
            FineUI.CheckBox cb = this.MyTree1CheckAll;
            if (cb.Checked)
            {
                tree.CheckAllNodes(tree.Nodes);
            }
            else
            {
                tree.UncheckAllNodes(tree.Nodes);
            }
        }
        #endregion
    }
}
