using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.Promotion;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.Data;
using Edge.SVA.Model.Domain.WebBuying.BasicViewModel;

namespace Edge.Web.WebBuying.MasterFiles.PromotionInfos.Promotion
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Promotion_H, Edge.SVA.Model.Promotion_H>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingNewPromotionController controller = new BuyingNewPromotionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                //对详情表的操作
                this.WindowSearch.Title = "Search";
                //if (this.Grid1.RecordCount == 0)
                //{
                //    this.btnClearAllHitItem.Enabled = false;
                //}
                //else
                //{
                //    this.btnClearAllHitItem.Enabled = true;
                //}
                SVASessionInfo.BuyingNewPromotionController = null;
                InitData();
            }
            controller = SVASessionInfo.BuyingNewPromotionController;
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                controller.LoadViewModel(Model.PromotionCode);


                if (controller.ViewModel.MainTable != null)
                {
                    this.StartTime.Text = controller.ViewModel.MainTable.StartDate.HasValue ? controller.ViewModel.MainTable.StartDate.Value.ToString("HH:mm") : string.Empty;
                    this.EndTime.Text = controller.ViewModel.MainTable.EndDate.HasValue ? controller.ViewModel.MainTable.EndDate.Value.ToString("HH:mm") : string.Empty;

                    controller.ViewModel.DayCode = controller.ViewModel.MainTable.DayFlagCode;
                    controller.ViewModel.WeekCode = controller.ViewModel.MainTable.WeekFlagCode;
                    controller.ViewModel.MonthCode = controller.ViewModel.MainTable.MonthFlagCode;
                }

                //下拉框取值
                if (this.StoreID.SelectedValue != "-1")
                {
                    this.StoreGroupID.Enabled = false;
                }
                else
                {
                    this.StoreGroupID.Enabled = true;
                }
                if (this.StoreGroupID.SelectedValue != "-1")
                {
                    this.StoreID.Enabled = false;
                }
                else
                {
                    this.StoreID.Enabled = true;
                }

                //Hit表取值
                if (controller.ViewModel.PromotionHitList != null)
                {
                    BindHitList(controller.ViewModel.PromotionHitList);
                }
                //Gift
                if (controller.ViewModel.PromotionGiftList != null)
                {
                    BindGiftList(controller.ViewModel.PromotionGiftList);
                }
                //Member
                if (controller.ViewModel.PromotionMemberList != null)
                {
                    BindMemberList(controller.ViewModel.PromotionMemberList);
                }
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Update ");

            controller.ViewModel.MainTable = this.GetUpdateObject();
            if (controller.ViewModel.MainTable != null)
            {
                controller.ViewModel.MainTable.UpdatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.UpdatedOn = System.DateTime.Now;
            }

            ExecResult er = controller.Update(); //controller.Update();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update Promotion Success Code:" + controller.ViewModel.MainTable.PromotionCode);
                CloseAndPostBack();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update Promotion Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.PromotionCode);
                ShowSaveFailed(er.Message);
            }

        }

        protected void StoreID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.StoreID.SelectedValue != "-1")
            {
                this.StoreGroupID.Enabled = false;
            }
            else
            {
                this.StoreGroupID.Enabled = true;
            }
        }

        protected void StoreGroupID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.StoreGroupID.SelectedValue != "-1")
            {
                this.StoreID.Enabled = false;
            }
            else
            {
                this.StoreID.Enabled = true;
            }
        }

        protected void LoyaltyFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            //当非会员时不允许新增记录到会员子表
            if (this.LoyaltyFlag.SelectedValue == "0")
            {
                this.Grid3.Enabled = false;
                this.btnMemberAdd.Enabled = btnMemberDelete.Enabled = btnClearAllMember.Enabled = false;
                ClearGird(this.Grid3);
                controller.ViewModel.PromotionMemberList.Clear();
            }
            else
            {
                this.Grid3.Enabled = true;
            }
        }

        #region 操作命中表
        protected void btnHitAdd_Click(object sender, EventArgs e)
        {
            ExecuteJS(WindowSearch.GetShowReference(string.Format("Promotion_Hit/Add.aspx?PromotionCode={0}", this.PromotionCode.Text)));
        }

        protected void btnClearAllHitItem_Click(object sender, EventArgs e)
        {
            ClearGird(this.Grid1);
            controller.ViewModel.PromotionHitList.Clear();

        }
        protected void btnDeleteHitItem_Click(object sender, EventArgs e)
        {
            if (controller.ViewModel.PromotionHitList != null && controller.ViewModel.PromotionHitList.Count > 0)
            {
                List<PromotionHitViewModel> showlist = new List<PromotionHitViewModel>();
                foreach (int row in Grid1.SelectedRowIndexArray)
                {
                    string KeyID = Grid1.DataKeys[row][0].ToString();
                    for (int j = controller.ViewModel.PromotionHitList.Count - 1; j >= 0; j--)
                    {
                        if (controller.ViewModel.PromotionHitList[j].HitSeq.ToString().Trim() == KeyID)
                        {
                            controller.ViewModel.PromotionHitList[j].OprFlag = "Delete";
                        }
                    }
                }
                foreach (var item in controller.ViewModel.PromotionHitList)
                {
                    if (item.OprFlag != "Delete")
                    {
                        showlist.Add(item);
                    }
                }

                BindHitList(showlist);
            }
        }

        private void BindHitList(List<PromotionHitViewModel> list)
        {
            this.Grid1.RecordCount = list.Count; //controller.ViewModel.PromotionHitList.Count;
            this.Grid1.DataSource = list;//controller.ViewModel.PromotionHitList;
            this.Grid1.DataBind();

            this.btnDeleteHitItem.Enabled = btnClearAllHitItem.Enabled = Grid1.RecordCount > 0 ? true : false;
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            BindHitList(controller.ViewModel.PromotionHitList);
        }
        #endregion

        #region 操作礼品表
        protected void btnGiftAdd_Click(object sender, EventArgs e)
        {
            ExecuteJS(WindowSearch.GetShowReference(string.Format("Promotion_Gift/Add.aspx?PromotionCode={0}", this.PromotionCode.Text)));
        }

        protected void btnClearAllGiftItem_Click(object sender, EventArgs e)
        {
            ClearGird(this.Grid2);
            controller.ViewModel.PromotionGiftList.Clear();
            controller.DeleteGiftPLU(this.PromotionCode.Text);
        }
        protected void btnDeleteGiftItem_Click(object sender, EventArgs e)
        {
            if (controller.ViewModel.PromotionGiftList != null && controller.ViewModel.PromotionGiftList.Count > 0)
            {
                List<PromotionGiftViewModel> showlist = new List<PromotionGiftViewModel>();
                foreach (int row in Grid2.SelectedRowIndexArray)
                {
                    string KeyID = Grid2.DataKeys[row][0].ToString();
                    for (int j = controller.ViewModel.PromotionGiftList.Count - 1; j >= 0; j--)
                    {
                        if (controller.ViewModel.PromotionGiftList[j].GiftSeq.ToString().Trim() == KeyID)
                        {
                            controller.ViewModel.PromotionGiftList[j].OprFlag = "Delete";
                        }
                    }
                    controller.DeleteGiftPLU(Convert.ToInt32(KeyID));
                }
                foreach (var item in controller.ViewModel.PromotionGiftList)
                {
                    if (item.OprFlag != "Delete")
                    {
                        showlist.Add(item);
                    }
                }
                BindGiftList(showlist);
            }
        }

        private void BindGiftList(List<PromotionGiftViewModel> list)
        {
            this.Grid2.RecordCount = list.Count; //controller.ViewModel.PromotionHitList.Count;
            this.Grid2.DataSource = list;//controller.ViewModel.PromotionHitList;
            this.Grid2.DataBind();

            this.btnDeleteGiftItem.Enabled = btnClearAllGiftItem.Enabled = Grid2.RecordCount > 0 ? true : false;
        }

        protected void Grid2_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid2.PageIndex = e.NewPageIndex;

            BindGiftList(controller.ViewModel.PromotionGiftList);
        }
        #endregion

        #region 操作促销会员表
        protected void btnMemberAdd_Click(object sender, EventArgs e)
        {
            ExecuteJS(WindowSearch.GetShowReference(string.Format("Promotion_Member/Add.aspx?PromotionCode={0}", this.PromotionCode.Text)));
        }

        protected void btnClearAllMemberItem_Click(object sender, EventArgs e)
        {
            ClearGird(this.Grid3);
            controller.ViewModel.PromotionMemberList.Clear();
        }
        protected void btnDeleteMemberItem_Click(object sender, EventArgs e)
        {
            if (controller.ViewModel.PromotionMemberList != null && controller.ViewModel.PromotionMemberList.Count > 0)
            {
                List<PromotionMemberViewModel> showlist = new List<PromotionMemberViewModel>();
                foreach (int row in Grid3.SelectedRowIndexArray)
                {
                    string KeyID = Grid3.DataKeys[row][0].ToString();
                    for (int j = controller.ViewModel.PromotionMemberList.Count - 1; j >= 0; j--)
                    {
                        if (controller.ViewModel.PromotionMemberList[j].ObjectKey.ToString().Trim() == KeyID)
                        {
                            controller.ViewModel.PromotionMemberList[j].OprFlag = "Delete";
                        }
                    }
                }
                foreach (var item in controller.ViewModel.PromotionMemberList)
                {
                    if (item.OprFlag != "Delete")
                    {
                        showlist.Add(item);
                    }
                }
                BindMemberList(showlist);
            }
        }

        private void BindMemberList(List<PromotionMemberViewModel> list)
        {
            this.Grid3.RecordCount = list.Count;
            this.Grid3.DataSource = list;
            this.Grid3.DataBind();

            this.btnMemberDelete.Enabled = btnClearAllMember.Enabled = Grid3.RecordCount > 0 ? true : false;
        }

        protected void Grid3_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid3.PageIndex = e.NewPageIndex;

            BindMemberList(controller.ViewModel.PromotionMemberList);
        }
        #endregion

        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            if (controller.ViewModel.PromotionHitList.Count > 0)
            {
                List<PromotionHitViewModel> modehitlist = new List<PromotionHitViewModel>();
                foreach (var item in controller.ViewModel.PromotionHitList)
                {
                    if (item.OprFlag != "Delete")
                    {
                        modehitlist.Add(item);
                    }
                }
                BindHitList(modehitlist);
            }
            if (controller.ViewModel.PromotionGiftList.Count > 0)
            {
                List<PromotionGiftViewModel> modegiftlist = new List<PromotionGiftViewModel>();
                foreach (var item in controller.ViewModel.PromotionGiftList)
                {
                    if (item.OprFlag != "Delete")
                    {
                        modegiftlist.Add(item);
                    }
                }
                BindGiftList(modegiftlist);
            }
            BindMemberList(controller.ViewModel.PromotionMemberList);
        }

        protected void Window1Edit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            this.DayFlagCode.Text = controller.ViewModel.DayCode;
            this.MonthFlagCode.Text = controller.ViewModel.MonthCode;
            this.WeekFlagCode.Text = controller.ViewModel.WeekCode;
        }

        protected void InitData()
        {
            controller.BindStore(StoreID);
            controller.BindStoreGroup(StoreGroupID);
        }

        protected void btnAddDay_Click(object sender, EventArgs e)
        {
            ExecuteJS(Window1.GetShowReference("BUY_DAYFLAG/List.aspx"));
        }

        protected void btnAddWeek_Click(object sender, EventArgs e)
        {
            ExecuteJS(Window1.GetShowReference("BUY_WEEKFLAG/List.aspx"));
        }

        protected void btnAddMonth_Click(object sender, EventArgs e)
        {
            ExecuteJS(Window1.GetShowReference("BUY_MONTHFLAG/List.aspx"));
        }
    }
}