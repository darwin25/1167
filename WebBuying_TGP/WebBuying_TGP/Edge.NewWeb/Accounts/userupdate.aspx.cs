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
using System.Configuration;
using Edge.Web.Tools;
using FineUI;
using System.Collections.Generic;
using Edge.Web.Controllers.Accounts;
using Edge.SVA.BLL.Domain.DataResources;
using Edge.SVA.Model.Domain.SVA;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.SVA.Model.Domain;

namespace Edge.Web.Accounts
{
    /// <summary>
    /// userupdate 的摘要说明。
    /// </summary>
    public partial class userupdate : PageBase, IForm
    {
        protected System.Web.UI.HtmlControls.HtmlInputText txtDate;
        AccountController controller = new AccountController();
        List<string> SubUserList = new List<string>();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                //BindSuppData();								
                User editUser;
                if (Request["username"] != null)
                {
                    string username = Request["username"].ToString();
                    editUser = controller.GetUserByName(username, SVASessionInfo.SiteLanguage);
                    if (editUser == null)
                    {
                        Alert.ShowInTop(Resources.MessageTips.NotExistUser, "", MessageBoxIcon.Warning, ActiveWindow.GetHideRefreshReference());
                        return;
                    }
                    if (editUser.UserName.Equals(ConstParam.SystemAdminName))
                    {
                        this.Style.Enabled = false;
                        editUser.Style = 1;
                    }
                    this.userid.Text = editUser.UserID.ToString();
                    this.txtUserName.Text = editUser.UserName;
                    this.txtTrueName.Text = editUser.TrueName;
                    this.rdblSex.SelectedValue = editUser.Sex.Trim();
                    this.txtPhone.Text = editUser.Phone;
                    this.txtEmail.Text = editUser.Email;
                    this.Description.Text = editUser.Description;
                    this.Style.SelectedValue = editUser.Style.ToString();

                    //分配权限组
                    DataSet dsRole = AccountsTool.GetRoleList(SVASessionInfo.SiteLanguage.ToString(), SVASessionInfo.CurrentUser); //todo: 修改成多语言。
                    chblRoles.DataSource = dsRole.Tables[0].DefaultView;
                    chblRoles.DataTextField = "Description";
                    chblRoles.DataValueField = "RoleID";
                    chblRoles.DataBind();
                    AccountsPrincipal newUser = new AccountsPrincipal(editUser.UserName, SVASessionInfo.SiteLanguage.ToString());//todo: 修改成多语言。
                    if (newUser.RoleIDList.Count > 0)
                    {
                        IList<int> roles = newUser.RoleIDList;
                        for (int i = 0; i < roles.Count; i++)
                        {
                            //						RoleList.Text += "<li>" + roles[i] + "</li>";
                            foreach (FineUI.CheckItem item in chblRoles.Items)
                            {
                                if (item.Value == roles[i].ToString()) item.Selected = true;
                            }
                        }
                    }

                    //List<BrandInfo> brandlist = PublicInfoReostory.Singleton.GetBrandInfoList(SVASessionInfo.SiteLanguage);
                    //this.chblBrandID.DataSource = brandlist;
                    //this.chblBrandID.DataValueField = "Key";
                    //this.chblBrandID.DataTextField = "Value";
                    //this.chblBrandID.DataBind();
                    //foreach (BrandInfo item in editUser.BrandInfoList)
                    //{
                    //    CheckItem ci = this.chblBrandID.Items.FindByValue(item.Key);
                    //    if (ci != null)
                    //    {
                    //        ci.Selected = true;
                    //    }
                    //}

                    {
                        List<BrandInfo> listBrandInfo;
                        if (SVASessionInfo.CurrentUser.UserName.Equals(ConstParam.SystemAdminName))
                        {
                            listBrandInfo = PublicInfoReostory.Singleton.GetAllBrandInfoList(SVASessionInfo.SiteLanguage);
                        }
                        else
                        {
                            listBrandInfo = SVASessionInfo.CurrentUser.BrandInfoList;
                        }
                        foreach (BrandInfo brandItem in listBrandInfo)
                        {
                            FineUI.TreeNode brandNode = new FineUI.TreeNode();
                            brandNode.EnableCheckBox = true;
                            brandNode.EnableCheckEvent = true;
                            brandNode.NodeID = brandItem.Key;
                            brandNode.Text = brandItem.Value;
                            BrandTree.Nodes.Add(brandNode);
                        }


                        foreach (BrandInfo brandItem in listBrandInfo)
                        {
                            if (brandItem.StoreInfos.Count >= 1)
                            {
                                FineUI.TreeNode brandNode = new FineUI.TreeNode();
                                brandNode.EnableCheckBox = true;
                                brandNode.EnableCheckEvent = true;
                                brandNode.NodeID = brandItem.Key;
                                //brandNode.Text = brandItem.Value; //Remove by Robin 2015-08-06
                                MyTree.Nodes.Add(brandNode);
                                foreach (StoreInfo item in brandItem.StoreInfos)
                                {
                                    FineUI.TreeNode storeNode = new FineUI.TreeNode();
                                    storeNode.EnableCheckBox = true;
                                    storeNode.EnableCheckEvent = true;
                                    storeNode.NodeID = brandItem.Key + "_" + item.Key;
                                    storeNode.Text = item.Value;
                                    brandNode.Nodes.Add(storeNode);
                                }
                            }
                            break; //Add By Robin 2015-08-06
                        }

                        DataSet UserList;
                        UserList = controller.GetAllUserList();
                        foreach (DataRow dr in UserList.Tables[0].Rows)
                        {
                            if (dr["UserID"].ToString() != userid.Text)
                            {
                                FineUI.TreeNode SubUserNode = new FineUI.TreeNode();
                                SubUserNode.EnableCheckBox = true;
                                SubUserNode.EnableCheckEvent = true;
                                SubUserNode.NodeID = dr["UserID"].ToString();
                                SubUserNode.Text = dr["UserName"].ToString() + '-' + dr["TrueName"].ToString();
                                SubUserTree.Nodes.Add(SubUserNode);
                            }
                        }

                        SubUserTree.UncheckAllNodes(SubUserTree.Nodes);
                        foreach (FineUI.TreeNode SUNode in SubUserTree.Nodes)
                        {
                            string bi = editUser.EmployeeList.Find(m => m == SUNode.NodeID);
                            if (bi != null)
                            {
                                SUNode.Checked = true;
                            }
                        }
                    }


                    if (editUser.Style == 1)//品牌用户
                    {
                        SetBrandTreeHiden(false);
                        BrandTree.UncheckAllNodes(BrandTree.Nodes);
                        foreach (FineUI.TreeNode tn in BrandTree.Nodes)
                        {
                            BrandInfo bi = editUser.BrandInfoList.Find(m => m.Key == tn.NodeID);
                            if (bi != null)
                            {
                                tn.Checked = true;
                            }
                        }
                    }
                    else//0 店铺用户
                    {
                        SetBrandTreeHiden(true);

                        MyTree.UncheckAllNodes(MyTree.Nodes);
                        foreach (FineUI.TreeNode brandNode in MyTree.Nodes)
                        {
                            BrandInfo bi = editUser.BrandInfoList.Find(m => m.Key == brandNode.NodeID);
                            if (bi != null)
                            {
                                brandNode.Checked = true;
                                foreach (FineUI.TreeNode storeNode in brandNode.Nodes)
                                {
                                    if (bi.StoreInfos.Exists(m => (brandNode.NodeID + "_" + m.Key) == storeNode.NodeID))
                                    {
                                        storeNode.Checked = true;
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }

        private void SetBrandTreeHiden(bool hid)
        {
            this.FormBrand.Hidden = hid;
            this.FormBrandStore.Hidden = !hid;
        }

        protected void Style_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = this.Style.SelectedValue;
            if (val == "1")//品牌用户
            {
                SetBrandTreeHiden(false);
            }
            else  //0 店铺用户
            {
                SetBrandTreeHiden(true);
            }
        }
        protected void BindTree_NodeCheck(object sender, FineUI.TreeCheckEventArgs e)
        {
            if (e.Checked)
            {
                if (e.Node.ParentNode != null && !e.Node.ParentNode.Checked)
                {
                    e.Node.ParentNode.Checked = true;
                }
                else
                {
                    BrandTree.CheckAllNodes(e.Node.Nodes);
                }
            }
            else
            {
                if (e.Node.ParentNode != null && e.Node.ParentNode.Checked)
                {
                    bool needChecked = false;
                    foreach (FineUI.TreeNode item in e.Node.ParentNode.Nodes)
                    {
                        if (item.Checked)
                        {
                            needChecked = true;
                        }
                    }
                    e.Node.ParentNode.Checked = needChecked;
                }
                BrandTree.UncheckAllNodes(e.Node.Nodes);
            }
        }
        protected void StoreTree_NodeCheck(object sender, FineUI.TreeCheckEventArgs e)
        {
            if (e.Checked)
            {
                if (e.Node.ParentNode != null && !e.Node.ParentNode.Checked)
                {
                    e.Node.ParentNode.Checked = true;
                }
                else
                {
                    MyTree.CheckAllNodes(e.Node.Nodes);
                }
            }
            else
            {
                if (e.Node.ParentNode != null && e.Node.ParentNode.Checked)
                {
                    bool needChecked = false;
                    foreach (FineUI.TreeNode item in e.Node.ParentNode.Nodes)
                    {
                        if (item.Checked)
                        {
                            needChecked = true;
                        }
                    }
                    e.Node.ParentNode.Checked = needChecked;
                }
                MyTree.UncheckAllNodes(e.Node.Nodes);
            }
        }
        protected void CheckAll_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.CheckAll.Checked)
            {
                MyTree.CheckAllNodes(MyTree.Nodes);
            }
            else
            {
                MyTree.UncheckAllNodes(MyTree.Nodes);
            }
        }

        protected void CheakAllBrands_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.CheakAllBrands.Checked)
            {
                BrandTree.CheckAllNodes(BrandTree.Nodes);
            }
            else
            {
                BrandTree.UncheckAllNodes(BrandTree.Nodes);
            }
        }

        protected void CheckAllEmployee_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.CheckAllSubUser.Checked)
            {
                SubUserTree.CheckAllNodes(SubUserTree.Nodes);
            }
            else
            {
                SubUserTree.UncheckAllNodes(SubUserTree.Nodes);
            }
        }
        //private void ResolveSubTree(DataRow dataRow, TreeNode treeNode)
        //{
        //    DataRow[] rows = dataRow.GetChildRows("TreeRelation");
        //    if (rows.Length > 0)
        //    {
        //        treeNode.Expanded = true;
        //        foreach (DataRow row in rows)
        //        {
        //            TreeNode node = new TreeNode();
        //            node.Text = row["Text"].ToString();
        //            treeNode.Nodes.Add(node);

        //            ResolveSubTree(row, node);
        //        }
        //    }
        //}

        //private void BindRoles(AccountsPrincipal user)
        //{
        //    //if(user.Permissions.Count>0)
        //    //{
        //    //    RoleList.Visible = true;
        //    //    ArrayList Permissions = user.Permissions;
        //    //    RoleList.Text ="<ul>";
        //    //    for(int i=0;i<Permissions.Count;i++)
        //    //    {
        //    //        RoleList.Text+="<li>" + Permissions[i] + "</li>";
        //    //    }
        //    //    RoleList.Text += "</ul>";
        //    //}
        //    if (user.Roles.Count > 0)
        //    {
        //        RoleList.Visible = true;
        //        ArrayList Roles = user.Roles;
        //        RoleList.Text = "<ul>";
        //        for (int i = 0; i < Roles.Count; i++)
        //        {
        //            RoleList.Text += "<li>" + Roles[i] + "</li>";
        //        }
        //        RoleList.Text += "</ul>";
        //    }
        //}

        //private void BindSuppData()
        //{
        //    Edge.BLL.ADManage.AdSupplier adsupp=new Edge.BLL.ADManage.AdSupplier();
        //    this.Dropdepart.DataSource=adsupp.GetNameList();
        //    this.Dropdepart.DataTextField="SupplierName";
        //    this.Dropdepart.DataValueField="SupplierID";
        //    this.Dropdepart.DataBind();
        //    string herosoftmana=Edge.Common.ConfigHelper.GetConfigString("AdManager");
        //    this.Dropdepart.Items.Insert(0,new ListItem(herosoftmana,"-1"));

        //}

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

        protected void btnSaveClose_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!ValidateForm())
                {
                    return;
                }
                string username = this.txtUserName.Text.Trim();
                AccountsPrincipal user = new AccountsPrincipal(username, SVASessionInfo.SiteLanguage.ToString());//todo: 修改成多语言。
                User editUser = new Edge.Security.Manager.User(int.Parse(this.userid.Text));
                editUser.UserName = username;
                editUser.TrueName = txtTrueName.Text.Trim();
                editUser.Description = this.Description.Text;
                if (txtPassword.Text.Trim() != "") editUser.Password = AccountsPrincipal.EncryptPassword(txtPassword.Text);
                editUser.Sex = this.rdblSex.SelectedValue;
                editUser.Phone = this.txtPhone.Text.Trim();
                editUser.Email = txtEmail.Text.Trim();
                //currentUser.EmployeeID=0;
                //currentUser.DepartmentID=this.Dropdepart.SelectedValue;			          
                //int style=int.Parse(this.dropStyle.SelectedValue);
                //currentUser.Style=style;
                editUser.Style = int.Parse(this.Style.SelectedValue);

                SubUserList.Clear();
                foreach (FineUI.TreeNode tn in SubUserTree.Nodes)
                {
                    if (tn.Checked)
                    {
                        SubUserList.Add(tn.NodeID);
                    }
                }

                if (editUser.Style == 1)
                {
                    foreach (FineUI.TreeNode tn in BrandTree.Nodes)
                    {
                        if (tn.Checked)
                        {
                            BrandInfo bi = new BrandInfo();
                            bi.Key = tn.NodeID;
                            editUser.BrandInfoList.Add(bi);
                        }
                    }
                }
                else
                {
                    foreach (FineUI.TreeNode sn in MyTree.Nodes)
                    {
                        if (sn.Checked)
                        {
                            BrandInfo bi = new BrandInfo();
                            bi.Key = sn.NodeID;
                            foreach (FineUI.TreeNode storeNode in sn.Nodes)
                            {
                                if (storeNode.Checked)
                                {
                                    StoreInfo si = new StoreInfo();
                                    si.Key = storeNode.NodeID.Split('_')[1];
                                    bi.StoreInfos.Add(si);
                                }
                            }
                            editUser.BrandInfoList.Add(bi);
                        }
                    }
                }


                if (!editUser.Update())
                {
                    FineUI.Alert.ShowInTop(Resources.MessageTips.UpdateFailed, FineUI.MessageBoxIcon.Error);
                    //this.lblMsg.ForeColor=Color.Red;
                    //this.lblMsg.Text = Resources.MessageTips.UpdateFailed;
                }
                else
                {
                    Logger.Instance.WriteOperationLog("update", "Update User " + editUser.UserName);
                    //更新权限分组
                    foreach (FineUI.CheckItem item in chblRoles.Items)
                    {
                        if (item.Selected == true)
                        {
                            editUser.AddToRole(Convert.ToInt32(item.Value));
                            Logger.Instance.WriteOperationLog("update", "Add To Role " + item.Text);
                        }
                        else
                        {
                            editUser.RemoveRole(Convert.ToInt32(item.Value));
                            Logger.Instance.WriteOperationLog("update", "Remove Role " + item.Text);
                        }
                    }
                    controller.UpdateRelation(editUser);

                    controller.UpdateSubUser(editUser.UserID.ToString(), SubUserList);

                    string currentUserName = SVASessionInfo.CurrentUser.UserName;
                    if (currentUserName.Equals(ConstParam.SystemAdminName) && currentUserName.Equals(editUser.UserName))
                    {
                        CloseAndRefresh();
                    }
                    else
                    {
                        CloseAndPostBack();
                    }
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.WriteErrorLog("update", "Remove Role ", ex);
                ShowError(Resources.MessageTips.UpdateFailed);
            }

        }

        protected void EmployeeButton_Click(object sender, EventArgs e)
        {
            if (this.FormSubUser.Hidden)
            {
                this.FormSubUser.Hidden = false;
                this.EmployeeButton.Text = "隐藏下属列表";
            }
            else
            {
                this.FormSubUser.Hidden = true;
                this.EmployeeButton.Text = "Show Employee List";
            }
        }

        #region IForm Members

        public bool ValidateForm()
        {
            string currentUserName = SVASessionInfo.CurrentUser.UserName;
            if (!currentUserName.Equals(ConstParam.SystemAdminName) && currentUserName.Equals(this.txtUserName.Text))
            {
                bool roleschanged = false;
                foreach (var item in this.chblRoles.Items)
                {
                    if (!item.Selected)
                    {
                        roleschanged = true;
                        break;
                    }
                }
                if (roleschanged)
                {
                    ShowWarning("You can't change your role permission!");
                    return false;
                }
                if (this.Style.SelectedValue == "1")
                {
                    bool brandsChanged = false;
                    foreach (var item in BrandTree.Nodes)
                    {
                        if (brandsChanged)
                        {
                            break;
                        }
                        if (!item.Checked)
                        {
                            brandsChanged = true;
                            break;
                        }
                        foreach (var item1 in item.Nodes)
                        {
                            if (!item1.Checked)
                            {
                                brandsChanged = true;
                                break;
                            }
                        }
                    }
                    if (brandsChanged)
                    {
                        ShowWarning("You can't change your brand permission!");
                        return false;
                    }
                }
                else
                {
                    bool storesChanged = false;
                    foreach (var item in MyTree.Nodes)
                    {
                        if (storesChanged)
                        {
                            break;
                        }
                        if (!item.Checked)
                        {
                            storesChanged = true;
                            break;
                        }
                        foreach (var item1 in item.Nodes)
                        {
                            if (!item1.Checked)
                            {
                                storesChanged = true;
                                break;
                            }
                        }
                    }
                    if (storesChanged)
                    {
                        ShowWarning("You can't change your store permission!");
                        return false;
                    }
                }
            }
            if (this.Style.SelectedValue == "1")
            {
                if (BrandTree.GetCheckedNodeIDs().Length == 0)
                {
                    ShowWarning("Must select brand!");
                    return false;
                }
            }
            else
            {
                if (MyTree.GetCheckedNodeIDs().Length == 0)
                {
                    ShowWarning("Must select store!");
                    return false;
                }
            }
            return true;
        }

        #endregion

    }
}
