using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Edge.Security.Manager;
using System.Data;
using Edge.Web.Tools;

namespace Edge.Web.Accounts.Admin
{
    public partial class viewrole : PageBase
    {
        private Role currentRole;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RegisterCloseEvent(btnClose);

                if (!hasRight)
                {
                    return;
                }
                DoInitialDataBind();
            }
        }

        //绑定类别列表
        private void DoInitialDataBind()
        {
            string roleID = string.Empty;
            if (Request["RoleID"] != null)
            {
                roleID = Request["RoleID"].ToString().Trim();

                //DataSet dsCardIssuer = new Edge.SVA.BLL.CardIssuer().GetAllRecordList();            
                //DataSet dsBrandID = new Edge.SVA.BLL.Brand().GetAllRecordList();
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
                //ControlTool.BindDataSetCheckboxList(this.ckblBrand, dsBrandID, "BrandID", "BrandName1", "BrandName2", "BrandName3", list);

                currentRole = new Role(Convert.ToInt32(Request["RoleID"]), SVASessionInfo.SiteLanguage);//todo: 修改成多语言。
                //RoleLabel.Text = Resources.MessageTips.CurrentRole + currentRole.Description;
                this.TxtNewname.Text = currentRole.Description;
            }
        }
    }
}