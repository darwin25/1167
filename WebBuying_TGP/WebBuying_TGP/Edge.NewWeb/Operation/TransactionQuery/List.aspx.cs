using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Edge.Web.Tools;
using Edge.Web.Controllers.Operation.DeliveryOrderManagement;
using Edge.Web.Controllers.Operation.StoreOrderManagement;
using Edge.SVA.Model.Domain.WebService.Response;

namespace Edge.Web.Operation.TransactionQuery
{
    public partial class List : PageBase
    {
        #region 公用业务逻辑类
        DeliveryOrderController Controller = new DeliveryOrderController();
        SalesPickOrderController controller = new SalesPickOrderController();
        SalesShipOrderController controller_ship = new SalesShipOrderController();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                //RptBind("", "TransNum");
                //RptBindSalesPickOrder("", "SalesPickOrderNumber");
                //RptBindSalesShipOrder("", "SalesShipOrderNumber");
            }
            string url = this.Request.Url.AbsolutePath.Substring(0, this.Request.Url.AbsolutePath.LastIndexOf("/") + 1);
        }

        #region 数据列表绑定

        private int RecordCount
        {
            get
            {
                if (ViewState["RecordCount"] == null || string.IsNullOrEmpty(ViewState["RecordCount"].ToString())) return -1;
                int count = 0;
                return int.TryParse(ViewState["RecordCount"].ToString(), out count) ? count : -1;
            }
            set
            {
                if (value < 0) return;
                //if (value > 0)
                //{

                //}
                //else
                //{

                //}
                this.Grid1.RecordCount = value;
                ViewState["RecordCount"] = value;
            }
        }
        private int RecordCount2
        {
            get
            {
                if (ViewState["RecordCount2"] == null || string.IsNullOrEmpty(ViewState["RecordCount2"].ToString())) return -1;
                int count = 0;
                return int.TryParse(ViewState["RecordCount2"].ToString(), out count) ? count : -1;
            }
            set
            {
                if (value < 0) return;
                //if (value > 0)
                //{

                //}
                //else
                //{

                //}
                this.Grid2.RecordCount = value;
                ViewState["RecordCount2"] = value;
            }
        }
        private int RecordCount3
        {
            get
            {
                if (ViewState["RecordCount3"] == null || string.IsNullOrEmpty(ViewState["RecordCount3"].ToString())) return -1;
                int count = 0;
                return int.TryParse(ViewState["RecordCount3"].ToString(), out count) ? count : -1;
            }
            set
            {
                if (value < 0) return;
                //if (value > 0)
                //{

                //}
                //else
                //{

                //}
                this.Grid3.RecordCount = value;
                ViewState["RecordCount3"] = value;
            }
        }
        private void RptBind(string strWhere, string orderby)
        {
            try
            {
                StringBuilder sb = new StringBuilder(strWhere);
                StringBuilder sbsearch = new StringBuilder();
                sb.Append(" 1=1 and Status>3 ");
                #region for search
                if (SearchFlag.Text == "1")
                {
                    string memberEmail = this.MemberEmail.Text.Trim();
                    string memberMobilePhone = this.MemberMobilePhone.Text.Trim();
                    string cardnumber = this.CardNumber.Text.Trim();
                    string transNum = this.TransNum.Text.Trim();
                    string salesPickOrderNumber = this.SalesPickOrderNumber.Text.Trim();
                    string salesShipOrderNumber = this.SalesShipOrderNumber.Text.Trim();
                    //会员Email
                    if (!string.IsNullOrEmpty(memberEmail))
                    {
                        MemberInfoResponse member = ControlTool.BindMember(memberEmail, 1, 1, "", 0, 0, "");
                        if (member != null)
                        {
                            if (sb.Length > 0)
                            {
                                sb.Append(" and ");
                            }
                            sb.AppendFormat(" MemberID={0} ", member.MemberID);
                        }

                    }
                    //会员手机
                    if (!string.IsNullOrEmpty(memberMobilePhone))
                    {
                        MemberInfoResponse member = ControlTool.BindMember(memberMobilePhone, 2, 1, "", 0, 0, "");
                        if (member != null)
                        {
                            if (sb.Length > 0)
                            {
                                sb.Append(" and ");
                            }
                            sb.AppendFormat(" MemberID={0} ", member.MemberID);
                        }

                    }
                    //卡号
                    if (!string.IsNullOrEmpty(cardnumber))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.AppendFormat(" CardNumber like '%{0}%' ", cardnumber);
                    }
                    //交易编号
                    if (!string.IsNullOrEmpty(transNum))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.AppendFormat(" TransNum like '%{0}%' ", transNum);
                    }
                    //拣货单编号
                    if (!string.IsNullOrEmpty(salesPickOrderNumber))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }

                        if (this.Grid2.Rows.Count > 0)
                        {
                            for (int i = 0; i < Grid2.Rows.Count; i++)
                            {
                                sbsearch.AppendFormat("{0}", Grid2.Rows[i].DataKeys[2].ToString());
                                sbsearch.Append(",");
                            }
                        }
                        sb.AppendFormat(" TransNum like '%{0}%' ", sbsearch.ToString().TrimEnd(','));
                    }
                    //送货单编号
                    if (!string.IsNullOrEmpty(salesShipOrderNumber))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }

                        if (this.Grid2.Rows.Count > 0)
                        {
                            for (int i = 0; i < Grid2.Rows.Count; i++)
                            {
                                sbsearch.AppendFormat("{0}", Grid2.Rows[i].DataKeys[2].ToString());
                                sbsearch.Append(",");
                            }
                        }
                        sb.AppendFormat(" TransNum like '%{0}%' ", sbsearch.ToString().TrimEnd(','));
                    }
                }
                #endregion
                //记录查询条件用于排序
                strWhere = sb.ToString();
                ViewState["strWhere"] = strWhere;
                int recodeCount = 0;
                DataSet ds = Controller.GetTransactionList(strWhere, Grid1.PageSize, Grid1.PageIndex, out recodeCount, orderby);
                this.Grid1.RecordCount = recodeCount;
                this.Grid1.DataSource = ds.Tables[0].DefaultView;
                this.Grid1.DataBind();
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteErrorLog("Sales_H", "Load Faild", ex);
            }
        }
        //销售拣货单加载
        private void RptBindSalesPickOrder(string strWhere, string orderby)
        {
            try
            {
                StringBuilder sb = new StringBuilder(strWhere);
                #region for search
                if (SearchFlag.Text == "1")
                {
                    string memberEmail = this.MemberEmail.Text.Trim();
                    string memberMobilePhone = this.MemberMobilePhone.Text.Trim();
                    string cardnumber = this.CardNumber.Text.Trim();
                    string transNum = this.TransNum.Text.Trim();
                    string salesPickOrderNumber = this.SalesPickOrderNumber.Text.Trim();
                    string salesShipOrderNumber = this.SalesShipOrderNumber.Text.Trim();
                    //会员Email
                    if (!string.IsNullOrEmpty(memberEmail))
                    {
                        MemberInfoResponse member = ControlTool.BindMember(memberEmail, 1, 1, "", 0, 0, "");
                        if (member != null)
                        {
                            if (sb.Length > 0)
                            {
                                sb.Append(" and ");
                            }
                            sb.AppendFormat(" MemberID={0} ", member.MemberID);
                        }

                    }
                    //会员手机
                    if (!string.IsNullOrEmpty(memberMobilePhone))
                    {
                        MemberInfoResponse member = ControlTool.BindMember(memberMobilePhone, 2, 1, "", 0, 0, "");
                        if (member != null)
                        {
                            if (sb.Length > 0)
                            {
                                sb.Append(" and ");
                            }
                            sb.AppendFormat(" MemberID={0} ", member.MemberID);
                        }

                    }
                    //卡号
                    if (!string.IsNullOrEmpty(cardnumber))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.AppendFormat(" CardNumber like '%{0}%' ", cardnumber);
                    }
                    //交易编号
                    if (!string.IsNullOrEmpty(transNum))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.AppendFormat(" ReferenceNo like '%{0}%' ", transNum);
                    }
                    //拣货单号
                    if (!string.IsNullOrEmpty(salesPickOrderNumber))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.AppendFormat(" SalesPickOrderNumber like '%{0}%' ", salesPickOrderNumber);
                    }
                    //送货单号
                    if (!string.IsNullOrEmpty(salesShipOrderNumber))
                    {
                        StringBuilder sbPickSearch = new StringBuilder();
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        if (this.Grid3.Rows.Count > 0)
                        {
                            for (int i = 0; i < Grid3.Rows.Count; i++)
                            {
                                sbPickSearch.AppendFormat("{0}", Grid3.Rows[i].DataKeys[4].ToString());
                                sbPickSearch.Append(",");
                            }
                        }
                        sb.AppendFormat(" SalesPickOrderNumber like '%{0}%' ", sbPickSearch.ToString().TrimEnd(','));
                    }
                }
                #endregion
                //记录查询条件用于排序
                strWhere = sb.ToString();
                ViewState["strWhere"] = strWhere;
                int count = 0;
                DataSet ds = controller.GetTransactionList(strWhere, Grid2.PageSize, Grid2.PageIndex, out count, orderby);
                ds.Tables[0].Columns.Add(new DataColumn("OrderTypeName", typeof(string)));
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int orderType = dr["OrderType"] == null ? 0 : Convert.ToInt32(dr["OrderType"]);
                    if (orderType == 1)
                    {
                        switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                        {
                            case "en-us": dr["OrderTypeName"] = "Direct delivery orders"; break;
                            case "zh-cn": dr["OrderTypeName"] = "直接产生快递单，拣货单完成"; break;
                            case "zh-hk": dr["OrderTypeName"] = "直接產生快遞單，揀貨單完成"; break;
                        }
                    }
                    else
                    {
                        switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                        {
                            case "en-us": dr["OrderTypeName"] = "Need third party transfer"; break;
                            case "zh-cn": dr["OrderTypeName"] = "需要第三方中转"; break;
                            case "zh-hk": dr["OrderTypeName"] = "需要協力廠商中轉"; break;
                        }
                    }
                }

                this.RecordCount2 = count;
                this.Grid2.DataSource = ds.Tables[0].DefaultView;
                this.Grid2.DataBind();
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteErrorLog("SalesPickOrder", "Load Faild", ex);
            }
        }
        //销售送货单加载
        private void RptBindSalesShipOrder(string strWhere, string orderby)
        {
            try
            {
                StringBuilder sb = new StringBuilder(strWhere);
                #region for search
                if (SearchFlag.Text == "1")
                {
                    string memberEmail = this.MemberEmail.Text.Trim();
                    string memberMobilePhone = this.MemberMobilePhone.Text.Trim();
                    string cardnumber = this.CardNumber.Text.Trim();
                    string transNum = this.TransNum.Text.Trim();
                    string salesPickOrderNumber = this.SalesPickOrderNumber.Text.Trim();
                    string salesShipOrderNumber = this.SalesShipOrderNumber.Text.Trim();
                    //会员Email
                    if (!string.IsNullOrEmpty(memberEmail))
                    {
                        MemberInfoResponse member = ControlTool.BindMember(memberEmail, 1, 1, "", 0, 0, "");
                        if (member != null)
                        {
                            if (sb.Length > 0)
                            {
                                sb.Append(" and ");
                            }
                            sb.AppendFormat(" MemberID={0} ", member.MemberID);
                        }

                    }
                    //会员手机
                    if (!string.IsNullOrEmpty(memberMobilePhone))
                    {
                        MemberInfoResponse member = ControlTool.BindMember(memberMobilePhone, 2, 1, "", 0, 0, "");
                        if (member != null)
                        {
                            if (sb.Length > 0)
                            {
                                sb.Append(" and ");
                            }
                            sb.AppendFormat(" MemberID={0} ", member.MemberID);
                        }

                    }
                    //卡号
                    if (!string.IsNullOrEmpty(cardnumber))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.AppendFormat(" CardNumber like '%{0}%' ", cardnumber);
                    }
                    //交易编号
                    if (!string.IsNullOrEmpty(transNum))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.AppendFormat(" TxnNo like '%{0}%' ", transNum);
                    }
                    //拣货单号
                    if (!string.IsNullOrEmpty(salesPickOrderNumber))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.AppendFormat(" ReferenceNo like '%{0}%' ", salesPickOrderNumber);
                    }
                    //送货单号
                    if (!string.IsNullOrEmpty(salesShipOrderNumber))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.AppendFormat(" SalesShipOrderNumber like '%{0}%' ", salesShipOrderNumber);
                    }
                }
                #endregion
                //记录查询条件用于排序
                strWhere = sb.ToString();
                ViewState["strWhere"] = strWhere;
                int count = 0;
                DataSet ds = controller_ship.GetTransactionList(strWhere, Grid3.PageSize, Grid3.PageIndex, out count, orderby);
                ds.Tables[0].Columns.Add(new DataColumn("OrderTypeName", typeof(string)));
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int orderType = dr["OrderType"] == null ? 0 : Convert.ToInt32(dr["OrderType"]);
                    if (orderType == 1)
                    {
                        switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                        {
                            case "en-us": dr["OrderTypeName"] = "Need third party transfer"; break;
                            case "zh-cn": dr["OrderTypeName"] = "需要第三方中转"; break;
                            case "zh-hk": dr["OrderTypeName"] = "需要協力廠商中轉"; break;
                        }
                    }
                    else
                    {
                        switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                        {
                            case "en-us": dr["OrderTypeName"] = "Direct delivery, express delivery completed"; break;
                            case "zh-cn": dr["OrderTypeName"] = "直接产生送货单，交付快递就算完成"; break;
                            case "zh-hk": dr["OrderTypeName"] = "直接產生送貨單，交付快遞就算完成"; break;
                        }
                    }

                }

                this.RecordCount3 = count;
                this.Grid3.DataSource = ds.Tables[0].DefaultView;
                this.Grid3.DataBind();
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteErrorLog("Store Order", "Load Faild", ex);
            }
        }
        #endregion

        #region Event

        //分页
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            RptBind("", "TransNum");
        }
        protected void Grid2_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid2.PageIndex = e.NewPageIndex;
            RptBindSalesPickOrder("", "SalesPickOrderNumber");
        }
        protected void Grid3_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid3.PageIndex = e.NewPageIndex;
            RptBindSalesShipOrder("", "SalesShipOrderNumber");
        }
        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            RptBind("", "TransNum");
        }
        protected void Grid3_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            if (e.DataItem is DataRowView)
            {
                DataRowView drv = e.DataItem as DataRowView;
                string Status = drv["Status"].ToString().Trim();
                if (Status != "")
                {
                    switch (Status)
                    {
                        case "0":
                            (Grid3.Rows[e.RowIndex].FindControl("lblStatus") as Label).Text = "创建";
                            break;
                        case "1":
                            (Grid3.Rows[e.RowIndex].FindControl("lblStatus") as Label).Text = "发货";
                            break;
                        case "2":
                            (Grid3.Rows[e.RowIndex].FindControl("lblStatus") as Label).Text = "中转签收";
                            break;
                        case "3":
                            (Grid3.Rows[e.RowIndex].FindControl("lblStatus") as Label).Text = "顾客签收";
                            break;
                        case "4":
                            (Grid3.Rows[e.RowIndex].FindControl("lblStatus") as Label).Text = "未发送作废";
                            break;
                        case "5":
                            (Grid3.Rows[e.RowIndex].FindControl("lblStatus") as Label).Text = "退回";
                            break;
                    }
                }
            }
        }
        //查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.Grid1.PageIndex = 0;
            this.SearchFlag.Text = "1";
            //不填内容直接搜索时要弹出提示消息
            if (!this.hasInput())
            {
                ShowWarning(Resources.MessageTips.NoSearchCondition);
                //RptBind(null,"");
                //RptBindSalesPickOrder(null, "");
                //RptBindSalesShipOrder(null, "");
                return;
            }
            else
            {
                //根据拣货单查询
                if (!string.IsNullOrEmpty(this.SalesPickOrderNumber.Text.Trim()) && string.IsNullOrEmpty(this.SalesShipOrderNumber.Text.Trim()))
                {
                    RptBindSalesPickOrder("", "SalesPickOrderNumber");
                    RptBindSalesShipOrder("", "SalesShipOrderNumber");
                    RptBind("", "TransNum");
                }
                //根据送货单查询
                else if (!string.IsNullOrEmpty(this.SalesShipOrderNumber.Text.Trim()) && string.IsNullOrEmpty(this.SalesPickOrderNumber.Text.Trim()))
                {
                    RptBindSalesShipOrder("", "SalesShipOrderNumber");
                    RptBindSalesPickOrder("", "SalesPickOrderNumber");
                    RptBind("", "TransNum");
                }
                else
                {
                    RptBind("", "TransNum");
                    RptBindSalesPickOrder("", "SalesPickOrderNumber");
                    RptBindSalesShipOrder("", "SalesShipOrderNumber");
                }
            }
        }

        #endregion

        private bool hasInput()
        {
            if (!string.IsNullOrEmpty(this.MemberMobilePhone.Text))
            {
                return true;
            }
            if (!string.IsNullOrEmpty(this.MemberEmail.Text)) return true;
            if (!string.IsNullOrEmpty(this.CardNumber.Text)) return true;
            if (!string.IsNullOrEmpty(this.TransNum.Text)) return true;
            if (!string.IsNullOrEmpty(this.SalesPickOrderNumber.Text)) return true;
            if (!string.IsNullOrEmpty(this.SalesShipOrderNumber.Text)) return true;
            return false;
        }
    }
}