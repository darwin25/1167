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
using FineUI;
using System.Collections.Generic;
using Edge.SVA.Model.Domain.SVA;
using Edge.SVA.BLL.Domain.DataResources;
using Edge.Web.Controllers.Accounts;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.SVA.Model.Domain;
namespace Edge.Web.Accounts
{
    /// <summary>
    /// Add 的摘要说明。
    /// </summary>
    public partial class Add : PageBase, IForm
    {
        protected System.Web.UI.HtmlControls.HtmlInputButton btnCancel;
        public string adminname = "管理部门";
        List<string> SubUserList = new List<string>();
        AccountController controller = new AccountController();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                //分配权限组
                DataSet dsRole = AccountsTool.GetRoleList(SVASessionInfo.SiteLanguage.ToString(), SVASessionInfo.CurrentUser); //todo: 修改成多语言。
                chblRoles.DataSource = dsRole.Tables[0].DefaultView;
                chblRoles.DataTextField = "Description";
                chblRoles.DataValueField = "RoleID";
                chblRoles.DataBind();
                this.txtPassword.Text = webset.UserDefaultPassword;
                this.txtPassword1.Text = webset.UserDefaultPassword;
                {
                    //BrandTree.AutoWidth = true;
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
                        //brandNode.AutoPostBack = true;
                        brandNode.EnableCheckEvent = true;
                        brandNode.EnableCheckBox = true;
                        brandNode.NodeID = brandItem.Key;
                        brandNode.Text = brandItem.Value;
                        BrandTree.Nodes.Add(brandNode);
                    }


                    //StoreTree.AutoWidth = true;
                    foreach (BrandInfo brandItem in listBrandInfo)
                    {
                        if (brandItem.StoreInfos.Count >= 1)
                        {
                            FineUI.TreeNode brandNode = new FineUI.TreeNode();
                            //brandNode.AutoPostBack = true;
                            brandNode.EnableCheckEvent = true;
                            brandNode.EnableCheckBox = true;
                            brandNode.NodeID = brandItem.Key;
                            //brandNode.Text = brandItem.Value; //Remove by Robin 2015-08-06
                            StoreTree.Nodes.Add(brandNode);
                            foreach (StoreInfo item in brandItem.StoreInfos)
                            {
                                FineUI.TreeNode storeNode = new FineUI.TreeNode();
                                //storeNode.AutoPostBack = true;
                                storeNode.EnableCheckEvent = true;
                                storeNode.EnableCheckBox = true;
                                storeNode.NodeID = brandItem.Key + "_" + item.Key;
                                storeNode.Text = item.Value;
                                brandNode.Nodes.Add(storeNode);
                            }
                        }
                        break; //Add By Robin 2015-08-06
                    }

                    //SubUserTree.AutoWidth = true;
                    DataSet UserList;
                    UserList = controller.GetAllUserList();
                    foreach (DataRow dr in UserList.Tables[0].Rows)
                    {
                        FineUI.TreeNode SubUserNode = new FineUI.TreeNode();
                        //SubUserNode.AutoPostBack = true;
                        SubUserNode.EnableCheckEvent = true;
                        SubUserNode.EnableCheckBox = true;
                        SubUserNode.NodeID = dr["UserID"].ToString();
                        SubUserNode.Text = dr["UserName"].ToString() + '-' + dr["TrueName"].ToString();
                        SubUserTree.Nodes.Add(SubUserNode);
                    }
                }
            }
        }
        //private void BindSuppData()
        //{
        //    Edge.BLL.ADManage.AdSupplier adsupp=new Edge.BLL.ADManage.AdSupplier();
        //    this.Dropdepart.DataSource=adsupp.GetNameList();
        //    this.Dropdepart.DataTextField="SupplierName";
        //    this.Dropdepart.DataValueField="SupplierID";
        //    this.Dropdepart.DataBind();
        //    adminname=Edge.Common.ConfigHelper.GetConfigString("AdManager");
        //    this.Dropdepart.Items.Insert(0,new ListItem(adminname,"-1"));
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

                User newUser = new User();
                string strErr = "";
                //			if(this.Dropdepart.SelectedIndex==0)
                //			{
                //				strErr+="请选择部门!";				
                //			}
                if (newUser.HasUser(txtUserName.Text))
                {
                    strErr += Resources.MessageTips.ExistUser;
                }

                if (strErr != "")
                {
                    //Edge.Common.MessageBox.Show(this,strErr);
                    FineUI.Alert.ShowInTop(strErr, FineUI.MessageBoxIcon.Warning);
                    return;
                }
                newUser.UserName = txtUserName.Text;
                newUser.Password = AccountsPrincipal.EncryptPassword(txtPassword.Text);
                newUser.TrueName = txtTrueName.Text;
                newUser.Description = this.Description.Text;
                newUser.Sex = rdblSex.SelectedValue;
                newUser.Phone = this.txtPhone.Text.Trim();
                newUser.Email = txtEmail.Text;
                newUser.EmployeeID = 0;
                //newUser.DepartmentID=this.Dropdepart.SelectedValue;
                newUser.Activity = true;
                newUser.UserType = "AA";
                newUser.Style = int.Parse(this.Style.SelectedValue);

                #region Add By Len
                foreach (FineUI.TreeNode brandNode in BrandTree.Nodes)
                {
                    if (brandNode.Checked)
                    {
                        BrandInfo bi = new BrandInfo();
                        bi.Key = brandNode.NodeID;
                        newUser.BrandInfoList.Add(bi);
                    }
                }
                #endregion

                SubUserList.Clear();
                foreach (FineUI.TreeNode tn in SubUserTree.Nodes)
                {
                    if (tn.Checked)
                    {
                        SubUserList.Add(tn.NodeID);
                    }
                }

                foreach (FineUI.TreeNode brandNode in StoreTree.Nodes)
                {
                    if (brandNode.Checked)
                    {
                        BrandInfo bi = new BrandInfo();
                        bi.Key = brandNode.NodeID;
                        foreach (FineUI.TreeNode storeNode in brandNode.Nodes)
                        {
                            if (storeNode.Checked)
                            {
                                StoreInfo si = new StoreInfo();
                                si.Key = storeNode.NodeID.Split('_')[1];
                                bi.StoreInfos.Add(si);
                            }
                        }
                        newUser.BrandInfoList.Add(bi);
                    }
                }

                int userid = newUser.Create();
                if (userid == -100)
                {
                    FineUI.Alert.ShowInTop(Resources.MessageTips.ExistUser, FineUI.MessageBoxIcon.Warning);
                    //this.lblMsg.Text = Resources.MessageTips.ExistUser;
                    //this.lblMsg.Visible = true;
                }
                else
                {
                    Logger.Instance.WriteOperationLog("Add", "Update User Roles " + newUser.UserName);
                    //更新权限分组
                    foreach (FineUI.CheckItem item in chblRoles.Items)
                    {
                        if (item.Selected == true)
                        {
                            newUser.AddToRole(Convert.ToInt32(item.Value));
                            Logger.Instance.WriteOperationLog("Add", "Add To Role " + item.Text);
                        }
                        else
                        {
                            newUser.RemoveRole(Convert.ToInt32(item.Value));
                            Logger.Instance.WriteOperationLog("Add", "Remove Role " + item.Text);
                        }
                    }

                    controller.UpdateRelation(newUser);

                    controller.UpdateSubUser(newUser.UserID.ToString(), SubUserList);

                    Logger.Instance.WriteOperationLog("Add", "Create User " + newUser.UserName);
                    // 2. Close本窗体，然后刷新父窗体
                    PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
                    //Response.Redirect("Admin/RoleAssignment.aspx?UserID="+userid);
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.WriteErrorLog("Add", "Create User ", ex);
                ShowError(Resources.MessageTips.AddFailed);
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
                    StoreTree.CheckAllNodes(e.Node.Nodes);
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
                StoreTree.UncheckAllNodes(e.Node.Nodes);
            }
        }
        protected void CheckAll_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.CheckAll.Checked)
            {
                StoreTree.CheckAllNodes(StoreTree.Nodes);
            }
            else
            {
                StoreTree.UncheckAllNodes(StoreTree.Nodes);
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
                if (StoreTree.GetCheckedNodeIDs().Length == 0)
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
