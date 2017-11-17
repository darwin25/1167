using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Edge.Security.Manager;
using Edge.Web.Tools;
using FineUI;

namespace Edge.Web.SysManage
{
    public partial class TreeAdmin : PageBase
    {
        AccountsPrincipal user;
        User currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
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
            //if (Grid1.SelectedRowIndexArray.Length > 0)
            //{
            //    foreach (int row in Grid1.SelectedRowIndexArray)
            //    {
            //        PermissionCategories c = new PermissionCategories();
            //        //保存日志
            //        // SaveLogs("");
            //        //Logger.Instance.WriteOperationLog(this.PageName, "Delete Category " + row);
            //        c.Delete(row);
            //    }
            //    string msg = string.Format(Resources.MessageTips.DeleteMenu, Grid1.SelectedRowIndexArray.Length);
            //    FineUI.Alert.ShowInTop(msg, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    Alert.ShowInTop(Resources.MessageTips.NotSelected, "", MessageBoxIcon.Warning);
            //}

            try
            {
                if (Grid1.SelectedRowIndexArray.Length > 0)
                {
                    foreach (int row in this.Grid1.SelectedRowIndexArray)
                    {
                        string id = Grid1.DataKeys[row][0].ToString();
                        Edge.Security.Manager.SysManage sm = new Edge.Security.Manager.SysManage();
                        //保存日志
                        // SaveLogs("");
                        Logger.Instance.WriteOperationLog(this.PageName, "Delete Tree Menu : " + id);

                        int idd = 0;
                        if (int.TryParse(id, out idd))
                        {
                            sm.DelTreeNode(idd);
                            string msg = string.Format(Resources.MessageTips.DeleteMenu, Grid1.SelectedRowIndexArray.Length);
                            FineUI.Alert.ShowInTop(msg, MessageBoxIcon.Information);

                            BindGrid();
                        }
                        else
                        {
                            Logger.Instance.WriteErrorLog(" DeleteMenu ", " id is not number");
                            ShowError(Resources.MessageTips.UnKnownSystemError);
                        }
                    }
                }
                else
                {
                    Alert.ShowInTop(Resources.MessageTips.NotSelected, "", MessageBoxIcon.Warning);
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.WriteErrorLog(" DeleteMenu ", "", ex);
                ShowError(Resources.MessageTips.UnKnownSystemError);
            }

        }

        #endregion

        private void LoadData()
        {
            btnNew.OnClientClick = Window1.GetShowReference("add.aspx", "Add");

            BindGrid();
        }

        private void BindGrid()
        {
            List<CustomMenu> menus = GetCustomMenus();
            Grid1.DataSource = menus;
            Grid1.DataBind();
        }

        public List<CustomMenu> GetCustomMenus()
        {
            List<CustomMenu> _customMenu = new List<CustomMenu>();

            List<CustomMenu> newList = new List<CustomMenu>();

            Edge.Security.Manager.SysManage sm = new Edge.Security.Manager.SysManage();
            DataSet ds = sm.GetTreeListByLan("", SVASessionInfo.SiteLanguage.ToString());

            ResolveMenuCollection(ds.Tables[0], newList, 0, 0);

            _customMenu = newList;

            return _customMenu;
        }

        private int ResolveMenuCollection(DataTable oldList, List<CustomMenu> newList, int parentId, int level)
        {
            int count = 0;
            foreach (DataRow row in oldList.Rows)
            {
                if (row["ParentID"].ToString().Trim() == parentId.ToString())
                {
                    count++;

                    CustomMenu my = new CustomMenu();
                    newList.Add(my);
                    my.TreeLevel = level;
                    my.Id = ConvertTool.ConverType<int>(row["NodeID"].ToString());
                    my.Name = row["Text"].ToString();
                    my.Title = row["Text"].ToString();
                    my.ParentId = ConvertTool.ConverType<int>(row["ParentID"].ToString());
                    my.Description = row["Text"].ToString();
                    my.Location = row["Location"].ToString();
                    my.Url = row["Url"].ToString();
                    my.Imageurl = row["ImageUrl"].ToString();
                    my.ModuleID = ConvertTool.ConverType<int>(row["ModuleID"].ToString());
                    my.KeShiDM = ConvertTool.ConverType<int>(row["KeShiDM"].ToString());
                    my.KeshiPublic = row["KeshiPublic"].ToString();
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
