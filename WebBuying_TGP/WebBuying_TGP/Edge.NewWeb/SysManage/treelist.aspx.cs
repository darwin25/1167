using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;

namespace Edge.Web.SysManage
{
	/// <summary>
	/// treelist 的摘要说明。
	/// </summary>
    public partial class treelist : PageBase
	{

        public int pcount;                      //总条数
        public int page;                        //当前页
        public int pagesize;                    //设置每页显示的大小


		protected void Page_Load(object sender, System.EventArgs e)
		{         
            this.pagesize = webset.ContentPageNum;

			if(!Page.IsPostBack)
			{

                RptBind("NodeID>0", "NodeID ASC");
                
			}
		}

        #region 数据列表绑定
        private void RptBind(string strWhere, string orderby)
        {
            if (!int.TryParse(Request.Params["page"] as string, out this.page))
            {
                this.page = 0;
            }
            Edge.Security.Manager.SysManage sm = new Edge.Security.Manager.SysManage();	

         
            //获得总条数
            this.pcount = sm.GetNoteCount(strWhere);
            if (this.pcount > 0)
            {
                this.lbtnDel.Enabled = true;
            }
            else
            {
                this.lbtnDel.Enabled = false;
            }

            DataSet ds = new DataSet();
            ds = sm.GetNotePageList(this.pagesize, this.page, strWhere, orderby);
            this.rptList.DataSource = ds.Tables[0].DefaultView; 
            this.rptList.DataBind();
        }
        #endregion

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((Label)rptList.Items[i].FindControl("lb_id")).Text);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    Edge.Security.Manager.SysManage sm = new Edge.Security.Manager.SysManage();
                    //保存日志
                    // SaveLogs("");
                    sm.DelTreeNode(id);
                }
            }

            JscriptPrint(Resources.MessageTips.DeleteSuccess, "treelist.aspx?page=0", Resources.MessageTips.SUCESS_TITLE);
        }

        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("add.aspx");
        }
	
	}
}
