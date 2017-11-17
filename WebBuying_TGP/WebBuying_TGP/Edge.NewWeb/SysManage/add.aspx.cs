using System;
using System.Data;
using System.Web.UI.WebControls;
using Edge.Security.Model;
using System.IO;
using Edge.Security.Manager;
using Edge.Web.Tools;
using FineUI;
using System.Collections.Generic;

namespace Edge.Web.SysManage
{
	/// <summary>
	/// TreeAdd 的摘要说明。
	/// </summary>
    public partial class add : PageBase
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				//得到现有菜单
				BindTree();	           
				//得到所有权限
                BindClassTree();
				//BindImages();		
                btnClose.OnClientClick = ActiveWindow.GetHideRefreshReference();
			}
			
		}


        protected void btnSaveClose_Click(object sender, System.EventArgs e)
        {
            string orderid = Edge.Common.PageValidate.InputText(txtOrderId.Text, 10);
            string name = txtName.Text;
            string url = Edge.Common.PageValidate.InputText(txtUrl.Text, 100);
            //string imgUrl=Edge.Common.PageValidate.InputText(txtImgUrl.Text,100);
            //string imgUrl = this.ddlImgUrl.SelectedValue;

            string target = this.ddlParent.SelectedValue;
            int parentid = int.Parse(target);

            if (orderid.Trim() == "")
            {
                FineUI.Alert.ShowInTop(Resources.MessageTips.NumberNotEmpty,FineUI.MessageBoxIcon.Warning);
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
            node.Text = name;
            node.ParentID = parentid;
            node.Location = parentid + "." + orderid;
            node.OrderID = int.Parse(orderid);
            node.Comment = comment;
            node.Url = url;
            node.PermissionID = permission_id;
            node.ImageUrl = "";
            node.ModuleID = moduleid;
            node.KeShiDM = keshidm;
            node.KeshiPublic = keshipublic;
            Edge.Security.Manager.SysManage sm = new Edge.Security.Manager.SysManage();		
            sm.AddTreeNode(node);
            Logger.Instance.WriteOperationLog(this.PageName, "Add Tree Menu : " + node.Text);

            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #region Event
		
       


        protected void ddlCategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PermissionsDatabind();
        }

        private void PermissionsDatabind()
        {
            int CategoryId = int.Parse(this.ddlCategoryList.SelectedValue);
            DataSet PermissionsList = AccountsTool.GetPermissionsByCategory(CategoryId, SVASessionInfo.SiteLanguage.ToString());//todo: 修改成多语言。
            this.ddlPermissionList.DataSource = PermissionsList;
            this.ddlPermissionList.DataTextField = "Description";
            this.ddlPermissionList.DataValueField = "PermissionID";
            this.ddlPermissionList.DataBind();
        }
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
        #endregion
    }
}
