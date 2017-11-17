using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Edge.Security.Manager;
using Edge.Web.Tools;
using FineUI;
using System.Text;

namespace Edge.Web.Accounts.Admin
{
    public partial class PermissionCategoryAdmin : PageBase
    {
        AccountsPrincipal user;
        User currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                LoadData();
            }
        }
        #region Events

        protected void Grid1_PreDataBound(object sender, EventArgs e)
        {
            // 数据绑定之前，进行权限检查
          //  CheckPowerEditWithWindowField(Grid1, "editField");
         //   CheckPowerDeleteWithLinkButtonField(Grid1, "deleteField");
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            int menuId = Convert.ToInt32(Grid1.DataKeys[e.RowIndex][0]);

        }

        protected void Window1_Close(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            if (Grid1.SelectedRowIndexArray.Length > 0)
            {
                PermissionCategories c = new PermissionCategories();
                foreach (int row in Grid1.SelectedRowIndexArray)
                {
                    //保存日志
                    // SaveLogs("");
                    int categoryID = int.Parse(Grid1.DataKeys[row][0].ToString());
                    Logger.Instance.WriteOperationLog(this.PageName, "Delete Category " + categoryID);
                    c.Delete(categoryID);
                }
                string msg = string.Format(Resources.MessageTips.DeleteMenu, Grid1.SelectedRowIndexArray.Length);
                BindGrid();
                FineUI.Alert.ShowInTop(msg, MessageBoxIcon.Information);

            }
            else
            {
                Alert.ShowInTop(Resources.MessageTips.NotSelected, "", MessageBoxIcon.Warning);
            }
        }

        #endregion

        private void LoadData()
        {
            btnNew.OnClientClick = Window1.GetShowReference("PermissionCategoryAdmin_New.aspx","Add");

            BindGrid();
        }

        private void BindGrid()
        {
            List<CustomPermissionCategory> menus = GetCustomPermissionCategory();
            Grid1.DataSource = menus;
            Grid1.DataBind();
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
