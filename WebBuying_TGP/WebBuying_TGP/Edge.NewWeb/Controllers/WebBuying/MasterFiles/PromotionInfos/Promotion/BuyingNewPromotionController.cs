using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using System.Data;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.SVA.Model.Domain.WebBuying.BasicViewModel;
using Edge.Utils.Tools;
using Edge.DBUtility;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.Promotion
{
    public class BuyingNewPromotionController
    {
        protected NewPromotionViewModel viewModel = new NewPromotionViewModel();

        public NewPromotionViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(string PromotionCode)
        {
            Edge.SVA.BLL.Promotion_H bll = new Edge.SVA.BLL.Promotion_H();
            Edge.SVA.Model.Promotion_H model = bll.GetModel(PromotionCode);
            viewModel.MainTable = model;

            Edge.SVA.BLL.Promotion_Hit bllhit = new SVA.BLL.Promotion_Hit();
            viewModel.PromotionHitList = bllhit.GetNewModelList("PromotionCode = '" + PromotionCode + "'");
            if (ViewModel.PromotionHitList.Count > 0)
            {
                foreach (var item in ViewModel.PromotionHitList)
                {
                    item.LogicalOprName = DALTool.GetLogicalOprName(item.HitLogicalOpr.ToString());
                    item.HitTypeName = DALTool.GetHitTypeName(item.HitType.ToString());
                    item.HitItemName = DALTool.GetHitItemName(item.HitItem.ToString());
                    item.HitOPName = DataTool.GetHitOPName(Convert.ToInt32(item.HitOP));
                    DataTool.AddEntityTypeName(item.HitPluTable, "EntityTypeName", "EntityType");
                }
            }

            Edge.SVA.BLL.Promotion_Gift bllgift = new SVA.BLL.Promotion_Gift();
            viewModel.PromotionGiftList = bllgift.GetNewModelList("PromotionCode = '" + PromotionCode + "'");
            if (ViewModel.PromotionGiftList.Count > 0)
            {
                foreach (var item in ViewModel.PromotionGiftList)
                {
                    item.LogicalOprName = DALTool.GetLogicalOprName(item.GiftLogicalOpr.ToString());
                    item.GiftTypeName = DALTool.GetPromotionGiftTypeName(item.PromotionGiftType.ToString());
                    item.GiftItemName = DALTool.GetPromotionGiftItemName(item.PromotionGiftItem.ToString());
                    item.DiscountTypeName = DALTool.GetPromotionDiscountTypeName(item.PromotionDiscountType.ToString());
                    item.DiscountOnName = DALTool.GetPromotionDiscountOnName(item.PromotionDiscountOn.ToString());
                    DataTool.AddEntityTypeName(item.GiftPluTable, "EntityTypeName", "EntityType");
                }
            }

            Edge.SVA.BLL.Promotion_Member bllmember = new SVA.BLL.Promotion_Member();
            viewModel.PromotionMemberList = bllmember.GetNewModelList("PromotionCode = '" + PromotionCode + "'");
            if (ViewModel.PromotionMemberList.Count > 0)
            {
                foreach (var item in ViewModel.PromotionMemberList)
                {
                    item.LoyaltyCardTypeName = DALTool.GetCardTypeNameFromSVA(item.LoyaltyCardTypeID.ToString());
                    item.LoyaltyCardGradeName = DALTool.GetCardGradeNameFromSVA(item.LoyaltyCardGradeID.ToString());
                    item.LoyaltyBirthdayFlagName = DALTool.GetLoyaltyBirthdayFlagName(item.LoyaltyBirthdayFlag.ToString());
                }
            }
        }

        #region 操作Hit
        public void AddPromotionHitViewModel(string lan, PromotionHitViewModel model)
        {
            this.viewModel.PromotionHitList.Add(model);
        }

        public void UpdatePromotionHitViewModel(string lan, PromotionHitViewModel model)
        {
            PromotionHitViewModel vm = this.viewModel.PromotionHitList.Find(mm => mm.HitSeq.Equals(model.HitSeq));
            if (vm != null)
            {
                DataCopyUtil.CopyData(model, vm);
            }
            //else
            //{
            //    vm.OprFlag = "Add";
            //}
        }

        public bool ValidateHitIsExists(PromotionHitViewModel model)
        {
            PromotionHitViewModel vm = this.viewModel.PromotionHitList.Find(mm => mm.HitSeq.Equals(model.HitSeq));
            if (vm == null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 操作Gift
        public void AddPromotionGiftViewModel(string lan, PromotionGiftViewModel model)
        {
            this.viewModel.PromotionGiftList.Add(model);
        }

        public void UpdatePromotionGiftViewModel(string lan, PromotionGiftViewModel model)
        {
            PromotionGiftViewModel vm = this.viewModel.PromotionGiftList.Find(mm => mm.GiftSeq.Equals(model.GiftSeq));
            if (vm != null)
            {
                DataCopyUtil.CopyData(model, vm);
            }
            //else
            //{
            //    vm.OprFlag = "Add";
            //}
        }

        public bool ValidateGiftIsExists(PromotionGiftViewModel model)
        {
            PromotionGiftViewModel vm = this.viewModel.PromotionGiftList.Find(mm => mm.GiftSeq.Equals(model.GiftSeq));
            if (vm == null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 操作Member
        public void AddPromotionMemberViewModel(string lan, PromotionMemberViewModel model)
        {
            this.viewModel.PromotionMemberList.Add(model);
        }

        public void UpdatePromotionMemberViewModel(string lan, PromotionMemberViewModel model)
        {
            PromotionMemberViewModel vm = this.viewModel.PromotionMemberList.Find(mm => mm.KeyID.Equals(model.KeyID));
            if (vm != null)
            {
                DataCopyUtil.CopyData(model, vm);
            }
            //else
            //{
            //    vm.OprFlag = "Add";
            //}
        }

        public bool ValidateMemberIsExists(PromotionMemberViewModel model)
        {
            PromotionMemberViewModel vm = this.viewModel.PromotionMemberList.Find(mm => mm.KeyID.Equals(model.KeyID));
            if (vm == null)
            {
                return false;
            }
            return true;
        }
        #endregion

        public ExecResult Add()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.Promotion_H bll = new Edge.SVA.BLL.Promotion_H();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.PromotionCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.PromotionCode);
                }
                if (rtn.Message == "")
                {
                    bll.Add(viewModel.MainTable);
                }

            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }

        public ExecResult Update()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.Promotion_H bll = new Edge.SVA.BLL.Promotion_H();
                Edge.SVA.BLL.Promotion_Hit bllhit = new SVA.BLL.Promotion_Hit();
                Edge.SVA.BLL.Promotion_Hit_PLU bllhitplu = new SVA.BLL.Promotion_Hit_PLU();

                Edge.SVA.BLL.Promotion_Gift bllgift = new SVA.BLL.Promotion_Gift();
                Edge.SVA.BLL.Promotion_Gift_PLU bllgiftplu = new SVA.BLL.Promotion_Gift_PLU();

                Edge.SVA.BLL.Promotion_Member bllmember = new SVA.BLL.Promotion_Member();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (rtn.Message == "")
                {
                    bll.Update(viewModel.MainTable);
                    #region 保存Hit
                    if (ViewModel.PromotionHitList.Count > 0)
                    {
                        foreach (var item in ViewModel.PromotionHitList)
                        {
                            if (item.OprFlag == "Add")
                            {
                                bllhit.Add(item);
                                //保存HitPLU
                                foreach (DataRow dr in item.HitPluTable.Rows)
                                {
                                    Edge.SVA.Model.Promotion_Hit_PLU mode = new SVA.Model.Promotion_Hit_PLU();
                                    mode.PromotionCode = item.PromotionCode;
                                    mode.HitSeq = item.HitSeq;
                                    mode.EntityType = Tools.ConvertTool.ToInt(dr["EntityType"].ToString());
                                    mode.EntityNum = dr["EntityNum"].ToString();
                                    bllhitplu.Add(mode);
                                }
                            }
                            else if (item.OprFlag == "Update")
                            {
                                bllhit.Update(item);
                            }
                            else if (item.OprFlag == "Delete")
                            {
                                bllhit.Delete(item.PromotionCode, item.HitSeq);
                            }
                        }
                    }
                    else
                    {
                        bllhit.DeleteData(viewModel.MainTable.PromotionCode);
                    }
                    #endregion

                    #region 保存Gift
                    if (ViewModel.PromotionGiftList.Count > 0)
                    {
                        foreach (var item in ViewModel.PromotionGiftList)
                        {
                            if (item.OprFlag == "Add")
                            {
                                bllgift.Add(item);
                                //保存HitPLU
                                foreach (DataRow dr in item.GiftPluTable.Rows)
                                {
                                    Edge.SVA.Model.Promotion_Gift_PLU mode = new SVA.Model.Promotion_Gift_PLU();
                                    mode.PromotionCode = item.PromotionCode;
                                    mode.GiftSeq = item.GiftSeq;
                                    mode.EntityType = Tools.ConvertTool.ToInt(dr["EntityType"].ToString());
                                    mode.EntityNum = dr["EntityNum"].ToString();
                                    bllgiftplu.Add(mode);
                                }
                            }
                            else if (item.OprFlag == "Update")
                            {
                                bllgift.Update(item);
                            }
                            else if (item.OprFlag == "Delete")
                            {
                                bllgift.Delete(item.PromotionCode, item.GiftSeq);
                            }
                        }
                    }
                    else
                    {
                        bllgift.DeleteData(viewModel.MainTable.PromotionCode);
                    }
                    #endregion

                    #region 保存Member
                    if (ViewModel.PromotionMemberList.Count > 0)
                    {
                        foreach (var item in ViewModel.PromotionMemberList)
                        {
                            if (item.OprFlag == "Add")
                            {
                                bllmember.Add(item);
                            }
                            else if (item.OprFlag == "Update")
                            {
                                Edge.SVA.Model.Promotion_Member member = new SVA.Model.Promotion_Member();
                                member.KeyID = item.KeyID;
                                member.PromotionCode = item.PromotionCode;
                                member.LoyaltyCardTypeID = item.LoyaltyCardTypeID;
                                member.LoyaltyCardGradeID = item.LoyaltyCardGradeID;
                                member.LoyaltyThreshold = item.LoyaltyThreshold;
                                member.LoyaltyBirthdayFlag = item.LoyaltyBirthdayFlag;
                                bllmember.Update(member);
                            }
                            else if (item.OprFlag == "Delete")
                            {
                                bllmember.DeleteData(item.PromotionCode);
                            }
                        }
                    }
                    else
                    {
                        bllmember.DeleteData(viewModel.MainTable.PromotionCode);
                    }
                    #endregion
                }
            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }

        public ExecResult Delete(string PromotionCode)
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.Promotion_H bll = new Edge.SVA.BLL.Promotion_H();
                //Edge.SVA.BLL.BUY_MNM_D blld = new SVA.BLL.BUY_MNM_D();

                if (rtn.Message == "")
                {
                    bll.Delete(PromotionCode);
                    //blld.DeleteData(PromotionCode);
                }

            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }
        public ExecResult DeleteGiftPLU(string PromotionCode)
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.Promotion_Gift_PLU bll = new Edge.SVA.BLL.Promotion_Gift_PLU();

                if (rtn.Message == "")
                {
                    bll.Delete(PromotionCode);
                }

            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }

        public ExecResult DeleteGiftPLU(int keyid)
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.Promotion_Gift_PLU bll = new Edge.SVA.BLL.Promotion_Gift_PLU();

                if (rtn.Message == "")
                {
                    bll.DeleteGif(keyid);
                }

            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }
        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.Promotion_H bll = new Edge.SVA.BLL.Promotion_H();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);
            //获取排序字段
            string orderStr = "PromotionCode";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetListByPage(strWhere, orderStr, pageSize * pageIndex + 1, pageSize * (pageIndex + 1));

            Tools.DataTool.AddCouponApproveStatusName(ds, "ApproveStatusName", "ApproveStatus");
            Tools.DataTool.AddBuyingStoreName(ds, "StoreName", "StoreID");
            Tools.DataTool.AddBuyingStoreGroupNameByID(ds, "StoreGroupName", "StoreGroupID");
            Tools.DataTool.AddUserName(ds, "CreatedName", "CreatedBy");
            Tools.DataTool.AddUserName(ds, "ApproveName", "ApproveBy");

            return ds;
        }

        public string ValidateForm()
        {
            return "";
        }

        public string ValidateObject(string strWhere)
        {
            Edge.SVA.BLL.Promotion_H bll = new SVA.BLL.Promotion_H();
            List<Edge.SVA.Model.Promotion_H> list = bll.GetModelList("PromotionCode = '" + strWhere + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }

        public void BindStore(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_STORE bll = new SVA.BLL.BUY_STORE();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "StoreID", "StoreName1", "StoreName2", "StoreName3", "StoreCode");
        }

        public void BindStoreGroup(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_STOREGROUP bll = new SVA.BLL.BUY_STOREGROUP();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "StoreGroupID", "StoreGroupName1", "StoreGroupName2", "StoreGroupName3", "StoreGroupCode");
        }

        public void BindCardType(FineUI.DropDownList ddl)
        {
            ControlTool.BindCardTypeIDFromSVA(ddl);
        }

        public void BindCardGrade(FineUI.DropDownList ddl, string CardTypeCode)
        {
            ControlTool.BindCardGradeIDFromSVA(ddl, CardTypeCode);
        }

        public string ApprovePromotionForApproveCode(Edge.SVA.Model.Promotion_H model, out bool isSuccess)
        {
            isSuccess = false;
            if (model == null) return "No Data";

            if (model.ApproveStatus != "P") return Resources.MessageTips.TheTransactionStatusNotPending;

            model.ApproveStatus = "A";
            model.ApproveOn = DateTime.Now;
            model.ApproveBy = Tools.DALTool.GetCurrentUser().UserID;
            //model.ApproveBusDate = ConvertTool.ConverNullable<DateTime>(DALTool.GetBusinessDate());

            Edge.SVA.BLL.Promotion_H bll = new Edge.SVA.BLL.Promotion_H();

            if (bll.Update(model))
            {
                model = new Edge.SVA.BLL.Promotion_H().GetModel(model.PromotionCode);
                isSuccess = true;
                return model.ApprovalCode;
            }
            return "";
        }

        private bool VoidPromotion(Edge.SVA.Model.Promotion_H model)
        {
            if (model == null) return false;

            if (model.ApproveStatus != "P") return false;

            model.ApproveStatus = "V";
            model.ApproveOn = DateTime.Now;
            model.ApproveBy = Tools.DALTool.GetCurrentUser().UserID;
            //model.ApproveBusDate = ConvertTool.ConverNullable<DateTime>(DALTool.GetBusinessDate());

            Edge.SVA.BLL.Promotion_H bll = new Edge.SVA.BLL.Promotion_H();

            return bll.Update(model);
        }

        public string BatchVoid(List<string> idList)
        {
            int success = 0;
            int count = 0;
            foreach (string id in idList)
            {
                if (string.IsNullOrEmpty(id)) continue;
                count++;
                Edge.SVA.Model.Promotion_H model = new Edge.SVA.BLL.Promotion_H().GetModel(id);
                if (VoidPromotion(model)) success++;
            }
            return string.Format(Resources.MessageTips.ApproveResult, success, count - success);
        }
        /// <summary>
        /// Promotion_Hit_PLU导入
        /// 创建人：lisa
        /// 创建时间：2016-12-05
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="RPriceCode"></param>
        public ExecResult InsetHitData(DataTable dt)
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            string strConnection = PubConstant.ConnectionString;
           
            try
            {
                using (System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy(strConnection))
                {
                    bcp.BatchSize = 100;//每次传输的行数 
                    bcp.NotifyAfter = 100;//进度提示的行数 
                    bcp.DestinationTableName = "Promotion_Hit_PLU";//需要导入的数据库表名
                    //excel表头与数据库列对应关系
                    bcp.ColumnMappings.Add("PromotionCode", "PromotionCode");
                    bcp.ColumnMappings.Add("HitSeq", "HitSeq");
                    bcp.ColumnMappings.Add("ProdCode", "EntityNum");
                    bcp.ColumnMappings.Add("EntityType", "EntityType");
                    bcp.WriteToServer(dt);
                    rtn.Message = "";
                }

            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }


        /// <summary>
        /// Promotion_Gift_PLU导入
        /// 创建人：lisa
        /// 创建时间：2016-12-05
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="RPriceCode"></param>
        public ExecResult InsetGiftData(DataTable dt)
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            string strConnection = PubConstant.ConnectionString;

            try
            {

                using (System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy(strConnection))
                {
                    bcp.BatchSize = 100;//每次传输的行数 
                    bcp.NotifyAfter = 100;//进度提示的行数 
                    bcp.DestinationTableName = "Promotion_Gift_PLU";//需要导入的数据库表名
                    //excel表头与数据库列对应关系
                    bcp.ColumnMappings.Add("PromotionCode", "PromotionCode");
                    bcp.ColumnMappings.Add("GiftSeq", "GiftSeq");
                    bcp.ColumnMappings.Add("ProdCode", "EntityNum");
                    bcp.ColumnMappings.Add("EntityType", "EntityType");
                    bcp.WriteToServer(dt);
                    rtn.Message = "";
                }

            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }


    }

}