﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Web.Controllers;
using FineUI;
using Edge.Web.Controllers.Operation.CouponManagement.CouponReturnManagement.CouponReturnOrder;
using System.Data;

namespace Edge.Web.Operation.CouponManagement.CouponReturnManagement.CouponReturnOrder
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Ord_CouponReturn_H, Edge.SVA.Model.Ord_CouponReturn_H>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                this.CouponReturnNumber.Text = DALTool.GetREFNOCode(CouponController.CouponRefnoCode.CouponReturnOrder);
                this.CreatedBusDate.Text = DALTool.GetBusinessDate();
                this.lblApproveStatus.Text = DALTool.GetApproveStatusString(ApproveStatus.Text);
                this.CreatedOn.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                this.lblCreatedBy.Text = Tools.DALTool.GetCurrentUser().UserName;

                ControlTool.BindBrand(BrandID);
                ControlTool.BindStore(FromStoreID,-1);
                ControlTool.BindStore(StoreID);

                ControlTool.BindCouponType(CouponTypeID);
                ControlTool.BindBatchID(BatchCouponID);

                RegisterCloseEvent(btnClose);
            }
        }

        protected void BrandID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int brandID = 0;
            brandID = int.TryParse(this.BrandID.SelectedValue, out brandID) ? brandID : 0;
            ControlTool.BindStore(FromStoreID, brandID);
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            Edge.SVA.Model.Ord_CouponReturn_H item = this.GetAddObject();

            if (item == null)
            {
                Logger.Instance.WriteOperationLog(this.PageName, string.Format("Coupon Return Order {0} No Data", item.CouponReturnNumber));
                ShowWarning(Resources.MessageTips.NoData);
                return;
            }
            if (ViewState["DetailResult2"] == null ||this.Detail2.Rows.Count <= 0)
            {
                Logger.Instance.WriteOperationLog(this.PageName, string.Format("Coupon Return Order  {0} Detail No Data", item.CouponReturnNumber));
                ShowWarning(Resources.MessageTips.NoData);
                return;
            }

            foreach (System.Data.DataRow detail in this.Detail2.Rows)
            {
                if (Convert.ToString(detail["FromStoreName"]) != FromStoreID.SelectedItem.Text)
                {
                    ShowWarning("明细店铺与主表店铺不一致！");
                    return;
                }
            }

            item.UpdatedBy = DALTool.GetCurrentUser().UserID;
            item.CreatedBy = DALTool.GetCurrentUser().UserID;
            item.UpdatedOn = DateTime.Now;
            item.CreatedOn = DateTime.Now;
            item.ApproveOn = null;
            item.ApprovalCode = null;

            if (Tools.DALTool.Add<Edge.SVA.BLL.Ord_CouponReturn_H>(item) > 0)
            {
                try
                {
                    DatabaseUtil.Factory.SetConnecctionString(DBUtility.PubConstant.ConnectionString);
                    DatabaseUtil.Interface.IDatabase database = DatabaseUtil.Factory.CreateIDatabase();
                    database.SetExecuteTimeout(6000);
                    System.Data.DataTable sourceTable = database.GetTableSchema("Ord_CouponReturn_D");
                    DatabaseUtil.Interface.IExecStatus es = null;
                    foreach (System.Data.DataRow detail in this.Detail2.Rows)
                    {
                        System.Data.DataRow row = sourceTable.NewRow();
                        row["CouponReturnNumber"] = item.CouponReturnNumber;
                        //row["BrandID"] = detail["BrandID"];
                        row["CouponTypeID"] = detail["CouponTypeID"];
                        row["Description"] = "";
                        row["OrderQTY"] = 1;
                        row["ActualQTY"] = 1;
                        row["FirstCouponNumber"] = detail["CouponNumber"];
                        row["EndCouponNumber"] = detail["CouponNumber"];
                        row["BatchCouponCode"] = detail["BatchCouponCode"];
                        sourceTable.Rows.Add(row);
                    }
                    es = database.InsertBigData(sourceTable, "Ord_CouponReturn_D");
                    if (es.Success)
                    {
                        sourceTable.Rows.Clear();
                    }
                    else
                    {
                        throw es.Ex;
                    }
                }
                catch (Exception ex)
                {
                    //TODO

                    Logger.Instance.WriteErrorLog(this.PageName, string.Format("Coupon Return Order  {0} Add Success But Detail Failed", item.CouponReturnNumber), ex);
                    //JscriptPrint(Resources.MessageTips.AddFailed, "List.aspx", Resources.MessageTips.FAILED_TITLE);
                    ShowAddFailed();
                    return;
                }

                Logger.Instance.WriteOperationLog(this.PageName, string.Format("Coupon Return Order  {0} Add Success", item.CouponReturnNumber));
                CloseAndRefresh();
            }
            else
            {
                Logger.Instance.WriteOperationLog(this.PageName, string.Format("Coupon Return Order  {0} Add Failed", item.CouponReturnNumber));
                ShowAddFailed();
            }
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            this.BindDetail();
        }

        protected void Grid2_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid2.PageIndex = e.NewPageIndex;
            this.BindDetail2();
        }

        protected void FromStoreID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Edge.SVA.Model.Store model = new Edge.SVA.BLL.Store().GetModel(Tools.ConvertTool.ConverType<int>(FromStoreID.SelectedValue.ToString()));
            if (model != null)
            {
                FromAddress.Text = model.StoreAddressDetail;
                FromContactName.Text = model.Contact;
                FromContactNumber.Text = model.StoreTel;
            }
            else
            {
                FromAddress.Text = "";
                FromContactName.Text = "";
                FromContactNumber.Text = "";
            }
        }

        protected void StoreID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Edge.SVA.Model.Store model = new Edge.SVA.BLL.Store().GetModel(Tools.ConvertTool.ConverType<int>(StoreID.SelectedValue.ToString()));
            if (model != null)
            {
                SendAddress.Text = model.StoreAddressDetail;
                StoreContactName.Text = model.Contact;
                StoreContactPhone.Text = model.StoreTel;
            }
            else
            {
                SendAddress.Text = "";
                StoreContactName.Text = "";
                StoreContactPhone.Text = "";
            }
        }

        private System.Data.DataTable Detail
        {
            get
            {
                if (ViewState["DetailResult"] == null)
                {
                    int type = 0;
                    string para1 = "";

                    if (FromStoreID.SelectedValue == "-1") 
                    {
                        this.FromStoreID.MarkInvalid(String.Format("'{0}' Can't Empty！", FromStoreID.SelectedText));
                        ViewState["DetailResult"] = new DataTable();
                        return ViewState["DetailResult"] as System.Data.DataTable;
                    }
                    if (!string.IsNullOrEmpty(sFirstCouponNumber.Text))
                    {
                        if (string.IsNullOrEmpty(sCouponQty.Text))
                        {
                            this.sCouponQty.MarkInvalid(String.Format("'{0}' Can't Empty！", sCouponQty.Text));
                            ViewState["DetailResult"] = new DataTable();
                            return ViewState["DetailResult"] as System.Data.DataTable;
                        }
                        else
                        {
                            type = 1;
                            para1 = sFirstCouponNumber.Text;
                        }
                    }
                    else if (!string.IsNullOrEmpty(sCouponUID1.Text))
                    {
                        if (string.IsNullOrEmpty(sCouponQty.Text))
                        {
                            this.sCouponQty.MarkInvalid(String.Format("'{0}' Can't Empty！", sCouponQty.Text));
                            ViewState["DetailResult"] = new DataTable();
                            return ViewState["DetailResult"] as System.Data.DataTable;
                        }
                        else
                        {
                            type = 2;
                            para1 = sCouponUID1.Text;
                        }
                    }
                    else
                    {
                        type = 0;
                        para1 = "";
                    }

                    CouponReturnOrderController controller = new CouponReturnOrderController();
                    System.Data.DataSet ds = controller.GetDetailList(type,CouponTypeID.SelectedValue,BatchCouponID.SelectedValue,sCouponQty.Text,FromStoreID.SelectedValue,FromStoreID.SelectedText,para1);
                    if (ds == null || ds.Tables.Count <= 0) return null;

                    Tools.DataTool.AddID(ds, "ID", 0, 0);

                    //Modified By Robin 2014-12-04
                    //ViewState["DetailResult"] = ds.Tables[0];
                    DataView dv = ds.Tables[0].DefaultView;
                    dv.RowFilter = "StockStatus= '6'";
                    ViewState["DetailResult"] = dv.ToTable();
                    //End

                    if (ViewState["DetailResult2"] == null)
                    {
                        DataTable dt2 = ds.Tables[0].Clone();
                        ViewState["DetailResult2"] = dt2;
                    }
                }
                return ViewState["DetailResult"] as System.Data.DataTable;
            }
        }

        private System.Data.DataTable Detail2
        {
            get
            {
                return ViewState["DetailResult2"] as System.Data.DataTable;
            }
        }

        private void BindDetail()
        {
            this.Grid1.RecordCount = this.Detail.Rows.Count;
            this.Grid1.DataSource = DataTool.GetPaggingTable(this.Grid1.PageIndex, this.Grid1.PageSize, this.Detail);
            this.Grid1.DataBind();
        }

        private void BindDetail2()
        {
            this.Grid2.RecordCount = this.Detail2.Rows.Count;
            this.Grid2.DataSource = DataTool.GetPaggingTable(this.Grid2.PageIndex, this.Grid2.PageSize, this.Detail2);
            this.Grid2.DataBind();
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            ViewState["DetailResult"] = null;
            this.BindDetail();
        }

        protected void btnAdd1_OnClick(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["DetailResult"];
            DataTable dt2 = (DataTable)ViewState["DetailResult2"];
            List<string> couponNumber = new List<string>();
            foreach (int i in Grid1.SelectedRowIndexArray)
            {
                couponNumber.Insert(0, Grid1.DataKeys[i][0].ToString());
            }
            if (couponNumber.Count == 0) 
            {
                return;
            }
            for (int i = dt.Rows.Count - 1; i > -1; i--)
            {
                if (couponNumber.Contains(dt.Rows[i]["CouponNumber"].ToString()))
                {
                    DataRow dr = dt2.NewRow();
                    dr["FromStoreName"] = dt.Rows[i]["FromStoreName"];
                    dr["CouponTypeID"] = dt.Rows[i]["CouponTypeID"];
                    dr["CouponTypeCode"] = dt.Rows[i]["CouponTypeCode"];
                    dr["CouponTypeName"] = dt.Rows[i]["CouponTypeName"];
                    dr["BatchCouponCode"] = dt.Rows[i]["BatchCouponCode"];
                    dr["CouponNumber"] = dt.Rows[i]["CouponNumber"];
                    dr["CouponAmount"] = dt.Rows[i]["CouponAmount"];
                    dr["Status"] = dt.Rows[i]["Status"];
                    dr["StockStatus"] = dt.Rows[i]["StockStatus"];
                    dr["CouponIssueDate"] = dt.Rows[i]["CouponIssueDate"];
                    dr["CouponExpiryDate"] = dt.Rows[i]["CouponExpiryDate"];
                    dr["CouponUID"] = dt.Rows[i]["CouponUID"];
                    dr["StatusName"] = dt.Rows[i]["StatusName"];
                    dr["StockStatusName"] = dt.Rows[i]["StockStatusName"];
                    dr["ID"] = dt.Rows[i]["ID"];
                    if (dt2.Select("CouponNumber = " + dr["CouponNumber"].ToString()).Length == 0)
                    {
                        dt2.Rows.InsertAt(dr, 0);
                    }
                }
            }
            ViewState["DetailResult2"] = dt2;
            this.BindDetail2();
        }

        protected void btnDelete1_OnClick(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["DetailResult"];
            List<string> couponNumber = new List<string>();
            foreach (int i in Grid1.SelectedRowIndexArray)
            {
                couponNumber.Insert(0, Grid1.DataKeys[i][0].ToString());
            }
            if (couponNumber.Count == 0)
            {
                return;
            }
            for (int i = dt.Rows.Count - 1; i > -1; i--)
            {
                if (couponNumber.Contains(dt.Rows[i]["CouponNumber"].ToString()))
                {
                    dt.Rows.RemoveAt(i);
                }
            }
            ViewState["DetailResult"] = dt;
            this.BindDetail();
        }

        protected void btnDelete2_OnClick(object sender, EventArgs e)
        {
            DataTable dt2 = (DataTable)ViewState["DetailResult2"];
            List<string> couponNumber = new List<string>();
            foreach (int i in Grid2.SelectedRowIndexArray)
            {
                couponNumber.Insert(0, Grid2.DataKeys[i][0].ToString());
            }
            if (couponNumber.Count == 0)
            {
                return;
            }
            for (int i = dt2.Rows.Count - 1; i > -1; i--)
            {
                if (couponNumber.Contains(dt2.Rows[i]["CouponNumber"].ToString()))
                {
                    dt2.Rows.RemoveAt(i);
                }
            }
            ViewState["DetailResult2"] = dt2;
            this.BindDetail2();
        }

        protected void btnAddAll_OnClick(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["DetailResult"];
            DataTable dt2 = (DataTable)ViewState["DetailResult2"];
            //List<string> couponNumber = new List<string>();
            //foreach (int i in Grid1.SelectedRowIndexArray)
            //{
            //    couponNumber.Insert(0, Grid1.DataKeys[i][0].ToString());
            //}
            //if (couponNumber.Count == 0)
            //{
            //    return;
            //}
            if (dt == null)
            {
                return;
            }
            for (int i = dt.Rows.Count - 1; i > -1; i--)
            {
                //if (couponNumber.Contains(dt.Rows[i]["CouponNumber"].ToString()))
                {
                    DataRow dr = dt2.NewRow();
                    dr["FromStoreName"] = dt.Rows[i]["FromStoreName"];
                    dr["CouponTypeID"] = dt.Rows[i]["CouponTypeID"];
                    dr["CouponTypeCode"] = dt.Rows[i]["CouponTypeCode"];
                    dr["CouponTypeName"] = dt.Rows[i]["CouponTypeName"];
                    dr["BatchCouponCode"] = dt.Rows[i]["BatchCouponCode"];
                    dr["CouponNumber"] = dt.Rows[i]["CouponNumber"];
                    dr["CouponAmount"] = dt.Rows[i]["CouponAmount"];
                    dr["Status"] = dt.Rows[i]["Status"];
                    dr["StockStatus"] = dt.Rows[i]["StockStatus"];
                    dr["CouponIssueDate"] = dt.Rows[i]["CouponIssueDate"];
                    dr["CouponExpiryDate"] = dt.Rows[i]["CouponExpiryDate"];
                    dr["CouponUID"] = dt.Rows[i]["CouponUID"];
                    dr["StatusName"] = dt.Rows[i]["StatusName"];
                    dr["StockStatusName"] = dt.Rows[i]["StockStatusName"];
                    dr["ID"] = dt.Rows[i]["ID"];
                    if (dt2.Select("CouponNumber = " + dr["CouponNumber"].ToString()).Length == 0)
                    {
                        dt2.Rows.InsertAt(dr, 0);
                    }
                }
            }
            ViewState["DetailResult2"] = dt2;
            this.BindDetail2();
        }

        protected void btnDeleteAll_OnClick(object sender, EventArgs e)
        {
            DataTable dt2 = (DataTable)ViewState["DetailResult2"];
            //List<string> couponNumber = new List<string>();
            //foreach (int i in Grid2.SelectedRowIndexArray)
            //{
            //    couponNumber.Insert(0, Grid2.DataKeys[i][0].ToString());
            //}
            //if (couponNumber.Count == 0)
            //{
            //    return;
            //}
            if (dt2 == null)
            {
                return;
            }
            for (int i = dt2.Rows.Count - 1; i > -1; i--)
            {
                //if (couponNumber.Contains(dt2.Rows[i]["CouponNumber"].ToString()))
                {
                    dt2.Rows.RemoveAt(i);
                }
            }
            ViewState["DetailResult2"] = dt2;
            this.BindDetail2();
        }
    }
}