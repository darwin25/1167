using System;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;
using Edge.Security.Model;
using Edge.Security.Manager;
using Edge.Web.Tools;
using FineUI;
using System.Collections.Generic;
namespace Edge.Web.SysManage
{
    /// <summary>
    /// modify 的摘要说明。
    /// </summary>
    public partial class modify : PageBase
    {
        protected System.Web.UI.WebControls.DropDownList dropModule;
        protected System.Web.UI.WebControls.DropDownList Dropdepart;
        protected System.Web.UI.WebControls.CheckBox chkPublic;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideRefreshReference();

                //得到现有菜单
                BindTree();
                //得到所有权限
                BindClassTree();
                if (Request["id"] != null)
                {
                    string id = Request.Params["id"];
                    if (id == null || id.Trim() == "")
                    {
                        return;
                    }
                    else
                    {
                        ShowInfo(id);
                    }
                }
            }

        }

        private void ShowInfo(string id)
        {

            //Navigation01.Para_Str="id="+id;
            Edge.Security.Manager.SysManage sm = new Edge.Security.Manager.SysManage();
            SysNode node = sm.GetNode(int.Parse(id));

            this.hfID.Text = id;
            this.txtOrderId.Text = node.OrderID.ToString();
            this.txtName.Text = node.Text;
            //menu
            if (node.ParentID == 0)
            {
                this.ddlParent.SelectedIndex = 0;
            }
            else
            {
                for (int m = 0; m < this.ddlParent.Items.Count; m++)
                {
                    if (this.ddlParent.Items[m].Value == node.ParentID.ToString())
                    {
                        this.ddlParent.Items[m].Selected = true;
                    }
                    else
                    {
                        this.ddlParent.Items[m].Selected = false;
                    }
                }
            }
            this.txtUrl.Text = node.Url;
            //			this.txtImgUrl.Text=node.ImageUrl;
            this.txtDescription.Text = node.Comment;
         
            DataRow row = AccountsTool.GetPermission(node.PermissionID);
            if (row != null)
            {
                this.ddlCategoryList.SelectedValue = row["CategoryID"].ToString().Trim();
                PermissionsDatabind();
                this.ddlPermissionList.SelectedValue = node.PermissionID.ToString().Trim();
            }
            if (node.KeshiPublic.ToLower() == "true")
            {
                this.ckbKeshi.Checked = true;
            }
            else
            {
                this.ckbKeshi.Checked = false;
            }
        }

        protected void btnSaveClose_Click(object sender, System.EventArgs e)
        {
            string id = Edge.Common.PageValidate.InputText(this.hfID.Text, 10);
            string orderid = Edge.Common.PageValidate.InputText(this.txtOrderId.Text, 5);
            string name = txtName.Text;
            string url = Edge.Common.PageValidate.InputText(txtUrl.Text, 100);
            //			string imgUrl=Edge.Common.PageValidate.InputText(txtImgUrl.Text,100);
            string imgUrl = "";
            string target = this.ddlParent.SelectedValue;
            int parentid = 0;
            if (!string.IsNullOrEmpty(target))
            {
                parentid = int.Parse(target);
            }


            if (orderid.Trim() == "")
            {
                FineUI.Alert.ShowInTop(Resources.MessageTips.NumberNotEmpty, FineUI.MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int.Parse(orderid);
            }
            catch
            {
                FineUI.Alert.ShowInTop(Resources.MessageTips.NumberFormatError, FineUI.MessageBoxIcon.Warning);
                return;
            }
            if (name.Trim() == "")
            {
                FineUI.Alert.ShowInTop(Resources.MessageTips.NameNotEmpty, FineUI.MessageBoxIcon.Warning);
                return;
            }

            int permission_id = -1;
            if (!string.IsNullOrEmpty(this.ddlPermissionList.SelectedValue))
            {
                permission_id = int.Parse(this.ddlPermissionList.SelectedValue);
            }
            int moduleid = -1;

            int keshidm = -1;
            string keshipublic = this.ckbKeshi.Checked ? "true" : "false";
            string comment = Edge.Common.PageValidate.InputText(txtDescription.Text, 100);

            SysNode node = new SysNode();
            node.NodeID = int.Parse(id);
            node.OrderID = int.Parse(orderid);
            node.Text = name;
            node.ParentID = parentid;
            node.Location = parentid + "." + orderid;
            node.Comment = comment;
            node.Url = url;
            node.PermissionID = permission_id;
            node.ImageUrl = imgUrl;
            node.ModuleID = moduleid;
            node.KeShiDM = keshidm;
            node.KeshiPublic = keshipublic;

            Edge.Security.Manager.SysManage sm = new Edge.Security.Manager.SysManage();
            sm.UpdateNode(node);

            Logger.Instance.WriteOperationLog(this.PageName, "Update Tree Menu : " + node.Text);

            PermissionMapper.GetSingleton().Refresh();

            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #region Event
        private void BindTree()
        {
            List<CustomPermissionCategory> mys = GetBindTree();

            // 绑定到下拉列表（启用模拟树功能）
            ddlParent.EnableSimulateTree = true;
            ddlParent.DataTextField = "Name";
            ddlParent.DataValueField = "Id";
            ddlParent.DataSimulateTreeLevelField = "TreeLevel";
            ddlParent.DataSource = mys;
            ddlParent.DataBind();

            // 选中根节点
            // ddlParent.SelectedValue = "0";
            ddlParent.Items.Insert(0, new FineUI.ListItem() { Text = "----------", Value = "" });//Add by Nathan for All dropdownlist default value.
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
        private void BindClassTree()
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

        protected void ddlCategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PermissionsDatabind();
        }

        private void PermissionsDatabind()
        {
            if (!string.IsNullOrEmpty(this.ddlCategoryList.SelectedValue))
            {
                int CategoryId = int.Parse(this.ddlCategoryList.SelectedValue);
                DataSet PermissionsList = AccountsTool.GetPermissionsByCategory(CategoryId, SVASessionInfo.SiteLanguage.ToString());//todo: 修改成多语言。
                this.ddlPermissionList.DataSource = PermissionsList;
                this.ddlPermissionList.DataTextField = "Description";
                this.ddlPermissionList.DataValueField = "PermissionID";
                this.ddlPermissionList.DataBind();
            }
        }

        #endregion

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码Edit器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion

    }
}
