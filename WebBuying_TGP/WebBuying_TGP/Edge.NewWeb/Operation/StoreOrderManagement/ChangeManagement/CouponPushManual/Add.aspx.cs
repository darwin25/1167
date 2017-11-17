using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FineUI;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.Surpport;
using Edge.SVA.Model.Domain;
using Edge.SVA.Model;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Edge.Web.Controllers.Operation.CouponManagement.ChangeManagement.CouponPushManual;
using Edge.Web.Controllers;

namespace Edge.Web.Operation.CouponManagement.ChangeManagement.CouponPushManual
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Ord_CouponPush_H, Edge.SVA.Model.Ord_CouponPush_H>
    {
        #region Basic Event
        CouponPushController controller = new CouponPushController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                this.WindowSearch.Title = "搜索";
                RegisterCloseEvent(btnClose);

                btnDeleteResultItem.OnClientClick = this.AddResultListGrid.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnDeleteResultItem.ConfirmIcon = FineUI.MessageBoxIcon.Question;
                btnDeleteResultItem.ConfirmText = Resources.MessageTips.ConfirmDeleteRecord;

                InitData();
                SVASessionInfo.CouponPushController = null;
            }
            controller = SVASessionInfo.CouponPushController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            Edge.SVA.Model.Ord_CouponPush_H item = this.GetAddObject();

            if (item != null)
            {
                if (item.CouponPushNumber.Equals(string.Empty))
                {
                    ShowAddFailed();
                    return;
                }
                item.PushCardBrandID = Tools.ConvertTool.ToInt(this.PushCardBrandID.SelectedValue);
                item.PushCardTypeID = Tools.ConvertTool.ToInt(this.PushCardTypeID.SelectedValue);
                item.PushCardGradeID = Tools.ConvertTool.ToInt(this.PushCardGradeID.SelectedValue);
                item.RepeatPush = Tools.ConvertTool.ToInt(this.RepeatPush.SelectedValue);
                item.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                item.UpdatedOn = null;
                item.UpdatedBy = null;
                item.ApproveOn = null;
            }
            if (controller.ViewModel.CouponTable == null || controller.ViewModel.CouponTable.Rows.Count <= 0)
            {
                ShowWarning(Resources.MessageTips.SelectCoupons);
                return;
            }
            int count = Edge.Web.Tools.DALTool.Add<Edge.SVA.BLL.Ord_CouponPush_H>(item);
            if (count > 0)
            {
                //批量提交字表数据
                if(controller.ViewModel.CouponTable != null)
                {
                    Edge.SVA.BLL.Ord_CouponPush_D blld = new SVA.BLL.Ord_CouponPush_D();
                    Edge.SVA.Model.Ord_CouponPush_D model = new Ord_CouponPush_D();
                    DataTable issuedDT = controller.ViewModel.CouponTable;
                    
                    for (int i = 0; i < issuedDT.Rows.Count; i++)
                    {
                        model.CouponPushNumber = this.CouponPushNumber.Text;
                        model.CouponBrandID = Convert.ToInt32(issuedDT.Rows[i]["CouponBrandID"].ToString());
                        model.CouponTypeID = Convert.ToInt32(issuedDT.Rows[i]["CouponTypeID"].ToString());
                        model.CouponQty = Convert.ToInt32(issuedDT.Rows[i]["CouponQty"].ToString());
                        blld.Add(model);
                    }
                }
                Logger.Instance.WriteOperationLog(this.PageName, "Add Coupon Push  " + item.CouponPushNumber + " " + Resources.MessageTips.AddSuccess);

                CloseAndRefresh();
            }
            else
            {
                Logger.Instance.WriteOperationLog(this.PageName, "Add Coupon Push  " + item.CouponPushNumber + " " + Resources.MessageTips.AddFailed);

                ShowAddFailed();
            }
        }

        #endregion

        #region Basic Functions
        private void InitData()
        {
            //初始化基本信息
            this.CouponPushNumber.Text = DALTool.GetREFNOCode(Edge.Web.Controllers.CouponController.CouponRefnoCode.ManualPushCoupon);
            CreatedOn.Text = Edge.Web.Tools.DALTool.GetSystemDateTime();
            lblCreatedBy.Text = Edge.Web.Tools.DALTool.GetUserName(Edge.Web.Tools.DALTool.GetCurrentUser().UserID);
            CreatedBusDate.Text = Edge.Web.Tools.DALTool.GetBusinessDate();
            this.lblApproveStatus.Text = DALTool.GetApproveStatusString(ApproveStatus.Text);

            btnDeleteResultItem.Enabled = btnClearAllResultItem.Enabled = AddResultListGrid.RecordCount > 0 ? true : false;

            //初始化下拉框
            Tools.ControlTool.BindBrand(this.PushCardBrandID);
            InitCardTypeByBrand();
            InitCardGradeByCardType();
        }

        #endregion

        #region Search Functions
        private void BindResultList(DataTable dt)
        {
            if (dt != null)
            {
                this.AddResultListGrid.PageSize = webset.ContentPageNum;
                this.AddResultListGrid.RecordCount = dt.Rows.Count;
                DataTable viewDT = Edge.Web.Tools.ConvertTool.GetPagedTable(dt, this.AddResultListGrid.PageIndex + 1, this.AddResultListGrid.PageSize);

                this.AddResultListGrid.DataSource = viewDT;
                this.AddResultListGrid.DataBind();
            }
            else
            {
                this.AddResultListGrid.PageSize = webset.ContentPageNum;
                this.AddResultListGrid.PageIndex = 0;
                this.AddResultListGrid.RecordCount = 0;
                this.AddResultListGrid.DataSource = null;
                this.AddResultListGrid.DataBind();
            }            
            this.btnDeleteResultItem.Enabled = btnClearAllResultItem.Enabled = AddResultListGrid.RecordCount > 0 ? true : false;
        }

        private void DeleteItem()
        {
            if (controller.ViewModel.CouponTable != null)
            {
                DataTable addDT = controller.ViewModel.CouponTable;

                foreach (int row in AddResultListGrid.SelectedRowIndexArray)
                {
                    string coupontypecode = AddResultListGrid.DataKeys[row][0].ToString();
                    for (int j = addDT.Rows.Count - 1; j >= 0; j--)
                    {
                        if (addDT.Rows[j]["CouponTypeCode"].ToString().Trim() == coupontypecode)
                        {
                            addDT.Rows.Remove(addDT.Rows[j]);
                        }
                    }
                    addDT.AcceptChanges();
                }

                controller.ViewModel.CouponTable = addDT;
                BindResultList(controller.ViewModel.CouponTable);
            }
        }

        private void DeleteAllItem()
        {
            if (controller.ViewModel.CouponTable != null)
            {
                DataTable addDT = controller.ViewModel.CouponTable.Clone();
                controller.ViewModel.CouponTable = addDT;
                BindResultList(controller.ViewModel.CouponTable);
            }
        }
        #endregion

        #region Search Events

        protected void btnViewSearch_Click(object sender, EventArgs e)
        {
            //转移界面
            ExecuteJS(WindowSearch.GetShowReference(string.Format("Coupon/Add.aspx")));
        }

        protected void btnDeleteResultItem_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        protected void btnClearAllResultItem_Click(object sender, EventArgs e)
        {
            DeleteAllItem();
        }

        protected void AddResultListGrid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            AddResultListGrid.PageIndex = e.NewPageIndex;
            BindResultList(controller.ViewModel.CouponTable);
        }

        protected void cbSearchAll_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            BindResultList(controller.ViewModel.CouponTable);
        }
        #endregion

        #region 卡信息控制
        protected void PushCardBrandID_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitCardTypeByBrand();
        }
        protected void PushCardTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitCardGradeByCardType();
        }
        private void InitCardTypeByBrand()
        {
            if (this.PushCardBrandID.SelectedValue != "-1")
            {
                DataSet ds = new Edge.SVA.BLL.CardType().GetList("BrandID = " + Convert.ToInt32(this.PushCardBrandID.SelectedValue) + " order by CardTypeCode");
                Edge.Web.Tools.ControlTool.BindDataSet(this.PushCardTypeID, ds, "CardTypeID", "CardTypeName1", "CardTypeName2", "CardTypeName3", "CardTypeCode");
            }
            else
            {
                this.PushCardTypeID.Items.Clear();
            }
        }
        private void InitCardGradeByCardType()
        {
            if (this.PushCardBrandID.SelectedValue != "-1")
            {
                Tools.ControlTool.BindCardGrade(this.PushCardGradeID, Convert.ToInt32(this.PushCardTypeID.SelectedValue));
            }
            else
            {
                this.PushCardGradeID.Items.Clear();
            }
        }
        #endregion

    }
}