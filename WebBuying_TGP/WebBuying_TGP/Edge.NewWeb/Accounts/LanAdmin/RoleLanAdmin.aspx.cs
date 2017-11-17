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
    public partial class RoleLanAdmin : PageBase
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
                BindRoleList();
                BindLanListByRole();
            }
        }

        private void BindRoleList()
        {
            DataSet CategoryList = AccountsTool.GetRoleList(SVASessionInfo.SiteLanguage.ToString());//todo: 修改成多语言。	
            this.ddlList.DataSource = CategoryList.Tables["Roles"];
            this.ddlList.DataValueField = "RoleID";
            this.ddlList.DataTextField = "Description";
            this.ddlList.DataBind();
        }

        private void BindLanListByRole()
        {
            Edge.Security.Manager.Lan_Accounts_Roles lanBll = new Edge.Security.Manager.Lan_Accounts_Roles();
            int RoleID = int.Parse(this.ddlList.SelectedValue);
            DataSet LanList = lanBll.GetList(" RoleID=" + RoleID);
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

            Edge.Security.Manager.Lan_Accounts_Roles p = new Edge.Security.Manager.Lan_Accounts_Roles();
            Edge.Security.Model.Lan_Accounts_Roles item = new Edge.Security.Model.Lan_Accounts_Roles();
            item.Description = this.txtModifyLan.Text.Trim();
            item.Lan = this.hfLan.Text.Trim();
            item.RoleID = Tools.ConvertTool.ConverType<int>(this.hfnodeID.Text.Trim());
            p.Update(item);
            Logger.Instance.WriteOperationLog(this.PageName, "Update Role Language: " + item.Description + " and Language: " + item.Lan);

            this.UpdateForm.Hidden = true;
            BindLanListByRole();
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

            if (new Edge.Security.Manager.Lan_Accounts_Roles().GetCount(string.Format(" Lan='{0}' and RoleID={1}", this.ddlLanList.SelectedItem.Value.Trim(), Tools.ConvertTool.ToInt(this.ddlList.SelectedValue))) > 0)
            {
                FineUI.Alert.ShowInTop(Resources.MessageTips.Exists, FineUI.MessageBoxIcon.Warning);
                return;
            }

            Edge.Security.Manager.Lan_Accounts_Roles bllLan = new Edge.Security.Manager.Lan_Accounts_Roles();
            Edge.Security.Model.Lan_Accounts_Roles item = new Edge.Security.Model.Lan_Accounts_Roles();
            item.Description = this.txtNewLan.Text.Trim();
            item.Lan = this.ddlLanList.SelectedItem.Value;
            item.RoleID = Tools.ConvertTool.ToInt(this.ddlList.SelectedValue);
            bllLan.Add(item);
            Logger.Instance.WriteOperationLog(this.PageName, "Add Role Language: " + item.Description + " and Language: " + item.Lan);

            this.InsertForm.Hidden = true;
            BindLanListByRole();
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

                Edge.Security.Manager.Lan_Accounts_Roles p = new Edge.Security.Manager.Lan_Accounts_Roles();
                Edge.Security.Model.Lan_Accounts_Roles item = new Edge.Security.Model.Lan_Accounts_Roles();
                item.Description = strText;
                item.Lan = strLan;
                item.RoleID = NodeID;
                p.Delete(item);
                Logger.Instance.WriteOperationLog(this.PageName, "Delete Role Language: " + item.Description + " and Language: " + item.Lan);
                
                //保存日志
                // SaveLogs("" + model.Title);                
            }
            FineUI.Alert.ShowInTop(Resources.MessageTips.DeleteSuccess, FineUI.MessageBoxIcon.Information);

            BindLanListByRole();
        }

        protected void ddlList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindLanListByRole();
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
