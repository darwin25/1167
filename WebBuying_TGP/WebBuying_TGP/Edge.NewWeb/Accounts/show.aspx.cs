using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Security.Manager;
using FineUI;
using System.Data;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.SVA;
using Edge.SVA.Model.Domain;
using Edge.SVA.BLL.Domain.DataResources;
using Edge.Web.Controllers.Accounts;

namespace Edge.Web.Accounts
{
    public partial class show : PageBase
    {
        AccountController controller = new AccountController();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                if (Context.User.Identity.IsAuthenticated)
                {

                    User currentUser;
                    if (Request["username"] != null)
                    {
                        string username = Request["username"].ToString();
                        currentUser = controller.GetUserByName(username, SVASessionInfo.SiteLanguage);
                        if (currentUser == null)
                        {
                            Alert.ShowInTop(Resources.MessageTips.NotExistUser, "", MessageBoxIcon.Warning, ActiveWindow.GetHideRefreshReference());
                            return;
                        }
                        this.lblName.Text = currentUser.UserName;
                        this.Description.Text = currentUser.Description;
                        this.lblTrueName.Text = currentUser.TrueName;
                        if (!string.IsNullOrEmpty(currentUser.Sex.Trim()))
                        {
                            this.rdblSex.SelectedValue = currentUser.Sex.Trim();
                        }
                        this.lblPhone.Text = currentUser.Phone;
                        this.lblEmail.Text = currentUser.Email;
                        this.Style.SelectedValue = currentUser.Style.ToString();

                        //分配权限组
                        //DataSet dsRole=AccountsTool.GetRoleList();
                        DataSet dsRole = AccountsTool.GetRoleList(SVASessionInfo.SiteLanguage.ToString()); //todo: 修改成多语言。
                        chblRoles.DataSource = dsRole.Tables[0].DefaultView;
                        chblRoles.DataTextField = "Description";
                        chblRoles.DataValueField = "RoleID";
                        chblRoles.DataBind();
                        AccountsPrincipal newUser = new AccountsPrincipal(currentUser.UserName, SVASessionInfo.SiteLanguage.ToString());//todo: 修改成多语言。
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

                        if (currentUser.Style == 1)
                        {
                            //BrandTree.AutoWidth = true;
                            List<BrandInfo> listBrandInfo;
                            listBrandInfo = currentUser.BrandInfoList;
                            foreach (BrandInfo brandItem in listBrandInfo)
                            {
                                FineUI.TreeNode brandNode = new FineUI.TreeNode();
                                brandNode.NodeID = brandItem.Key;
                                brandNode.Text = brandItem.Value;
                                BrandTree.Nodes.Add(brandNode);
                            }
                        }
                        else
                        {
                            //StoreTree.AutoWidth = true;
                            List<BrandInfo> listBrandInfo;
                            listBrandInfo = currentUser.BrandInfoList;
                            foreach (BrandInfo brandItem in listBrandInfo)
                            {
                                if (brandItem.StoreInfos.Count >= 1)
                                {
                                    FineUI.TreeNode brandNode = new FineUI.TreeNode();
                                    //brandNode.EnableCheckBox = true;
                                    //brandNode.AutoPostBack = true;
                                    brandNode.NodeID = brandItem.Key;
                                    brandNode.Text = brandItem.Value;
                                    StoreTree.Nodes.Add(brandNode);
                                    foreach (StoreInfo item in brandItem.StoreInfos)
                                    {
                                        FineUI.TreeNode storeNode = new FineUI.TreeNode();
                                        //storeNode.EnableCheckBox = true;
                                        //storeNode.AutoPostBack = true;
                                        storeNode.NodeID = brandItem.Key + "_" + item.Key;
                                        storeNode.Text = item.Value;
                                        brandNode.Nodes.Add(storeNode);
                                    }
                                }
                            }
                        }
                        if (currentUser.Style == 1)
                        {
                            SetBrandTreeHiden(false);
                        }
                        else
                        {
                            SetBrandTreeHiden(true);
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
    }
}