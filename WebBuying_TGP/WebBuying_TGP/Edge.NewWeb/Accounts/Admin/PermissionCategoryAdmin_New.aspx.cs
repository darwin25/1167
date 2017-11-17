using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Security.Manager;
using Edge.Web.Tools;
using FineUI;
using System.Data;

namespace Edge.Web.Accounts.Admin
{
    public partial class PermissionCategoryAdmin_New : PageBase
    {
        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                BindDDL();
            }
        }

        private void BindDDL()
        {
            List<CustomPermissionCategory> mys = GetCustomPermissionCategory();

            // 绑定到下拉列表（启用模拟树功能）
            ddlParent.EnableSimulateTree = true;
            ddlParent.DataTextField = "Description";
            ddlParent.DataValueField = "Id";
            ddlParent.DataSimulateTreeLevelField = "TreeLevel";
            ddlParent.DataSource = mys;
            ddlParent.DataBind();

            // 选中根节点
           // ddlParent.SelectedValue = "0";
            ddlParent.Items.Insert(0, new FineUI.ListItem() { Text = "----------", Value = "" });//Add by Nathan for All dropdownlist default value.
        }

        #endregion

        #region Events

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

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            string name = this.txtName.Text;
            int parentID = Tools.ConvertTool.ConverType<int>(this.ddlParent.SelectedValue);
            int orderID = Tools.ConvertTool.ConverType<int>(this.txtOrderID.Text);
            PermissionCategories c = new PermissionCategories();
            int count = c.Create(name,parentID,orderID);

            if (count > 0)
            {
                Logger.Instance.WriteOperationLog(this.PageName, "Add Category " + name);

                PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
                //JscriptPrint(Resources.MessageTips.UpdateSuccess, "", Resources.MessageTips.SUCESS_TITLE);
                // BindCategoriesTree();
            }
            else
            {
                Alert.ShowInTop(Resources.MessageTips.AddFailed, MessageBoxIcon.Error);
                //  JscriptPrint(Resources.MessageTips.UpdateFailed, "", Resources.MessageTips.FAILED_TITLE);
            }
        }

        #endregion
    }
}