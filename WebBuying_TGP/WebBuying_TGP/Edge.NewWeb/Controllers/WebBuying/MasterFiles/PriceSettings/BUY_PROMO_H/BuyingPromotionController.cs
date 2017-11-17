using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.Data;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebService.Request;
using Edge.SVA.Model.Domain.WebService.Response;
using Edge.SVA.Model.Domain.Surpport;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.PriceSettings.BUY_PROMO_H
{
    public class BuyingPromotionController
    {
        protected PromotionViewModel viewModel = new PromotionViewModel();

        public PromotionViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(string PromotionCode)
        {
            Edge.SVA.BLL.BUY_PROMO_H bll = new Edge.SVA.BLL.BUY_PROMO_H();
            Edge.SVA.Model.BUY_PROMO_H model = bll.GetModel(PromotionCode);
            viewModel.MainTable = model;

            Edge.SVA.BLL.BUY_PROMO_D blld = new SVA.BLL.BUY_PROMO_D();
            viewModel.Modellist = blld.GetModelList("PromotionCode = '" + PromotionCode + "'");
            DataSet ds = blld.GetList("PromotionCode = '" + PromotionCode + "'");
            viewModel.SubTable = ds.Tables.Count > 0 ? ds.Tables[0] : null;

            if (viewModel.SubTable != null)
            {
                DataTool.AddEntityTypeName(viewModel.SubTable, "EntityTypeName", "EntityType");
                DataTool.AddHitOPName(viewModel.SubTable, "HitOPName", "HitOP");
                DataTool.AddDiscTypeName(viewModel.SubTable, "DiscTypeName", "DiscType");
                DataTool.AddPromotionHitTypeName(viewModel.SubTable, "HitTypeName", "HitType");
            }
        }

        public ExecResult Add()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_PROMO_H bll = new Edge.SVA.BLL.BUY_PROMO_H();

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
                Edge.SVA.BLL.BUY_PROMO_H bll = new Edge.SVA.BLL.BUY_PROMO_H();
                Edge.SVA.BLL.BUY_PROMO_D blld = new SVA.BLL.BUY_PROMO_D();
                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (rtn.Message == "")
                {
                    bll.Update(viewModel.MainTable);
                    blld.Delete(viewModel.MainTable.PromotionCode);
                    if (viewModel.SubTable != null)
                    {
                        for (int i = 0; i < viewModel.SubTable.Rows.Count; i++)
                        {
                            Edge.SVA.Model.BUY_PROMO_D model = new SVA.Model.BUY_PROMO_D();
                            DataRow dr = viewModel.SubTable.Rows[i];
                            model.PromotionCode = dr["PromotionCode"].ToString();
                            model.HitOP = ConvertTool.ToInt(dr["HitOP"].ToString());
                            model.HitType = ConvertTool.ToInt(dr["HitType"].ToString());
                            model.HitAmount = ConvertTool.ToDecimal(dr["HitAmount"].ToString());
                            model.EntityType = ConvertTool.ToInt(dr["EntityType"].ToString());
                            model.EntityNum = dr["EntityNum"].ToString();
                            model.DiscType = ConvertTool.ToInt(dr["DiscType"].ToString());
                            model.DiscPrice = ConvertTool.ToDecimal(dr["DiscPrice"].ToString());
                            blld.Add(model);
                        }
                    }
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
                Edge.SVA.BLL.BUY_PROMO_H bll = new Edge.SVA.BLL.BUY_PROMO_H();
                Edge.SVA.BLL.BUY_PROMO_D blld = new SVA.BLL.BUY_PROMO_D();

                if (rtn.Message == "")
                {
                    bll.Delete(PromotionCode);
                    blld.Delete(PromotionCode);
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
            Edge.SVA.BLL.BUY_PROMO_H bll = new Edge.SVA.BLL.BUY_PROMO_H();

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
            Tools.DataTool.AddBuyingStoreName(ds, "StoreName", "StoreCode");
            Tools.DataTool.AddBuyingStoreGroupName(ds, "StoreGroupName", "StoreGroupCode");

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
            Edge.SVA.BLL.BUY_PROMO_H bll = new SVA.BLL.BUY_PROMO_H();
            List<Edge.SVA.Model.BUY_PROMO_H> list = bll.GetModelList("PromotionCode = '" + strWhere + "'");
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
            ControlTool.BindDataSet(ddl, ds, "StoreCode", "StoreName1", "StoreName2", "StoreName3", "StoreCode");
        }

        public void BindStoreGroup(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_STOREGROUP bll = new SVA.BLL.BUY_STOREGROUP();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "StoreGroupCode", "StoreGroupName1", "StoreGroupName2", "StoreGroupName3", "StoreGroupCode");
        }

        public void BindCardType(FineUI.DropDownList ddl)
        {
            //ResetPasswordUtil rpu = new ResetPasswordUtil();
            //CardTypeInfoRequest request = new CardTypeInfoRequest();
            //CardTypes[] ris = rpu.GetCardTypeInfo(request, SVASessionInfo.SiteLanguage);
            //List<KeyValue> list = new List<KeyValue>();
            //foreach (var item in ris)
            //{
            //    list.Add(new KeyValue() { Key = item.CardTypeCode, Value = item.CardTypeName });
            //}
            //ControlTool.BindKeyValueList(ddl, list);
            ControlTool.BindCardTypeFromSVA(ddl);
        }

        public void BindCardGrade(FineUI.DropDownList ddl, string CardTypeCode)
        {
            //ResetPasswordUtil rpu = new ResetPasswordUtil();
            //CardGradeInfoRequest request = new CardGradeInfoRequest();
            //request.ConditionStr = "CardTypeCode='" + CardTypeCode + "'";
            //CardGrades[] ris = rpu.GetCardGradeInfo(request, SVASessionInfo.SiteLanguage);
            //List<KeyValue> list = new List<KeyValue>();
            //foreach (var item in ris)
            //{
            //    list.Add(new KeyValue() { Key = item.CardGradeCode, Value = item.CardGradeName });
            //}
            //ControlTool.BindKeyValueList(ddl, list);
            ControlTool.BindCardGradeFromSVA(ddl, CardTypeCode);
        }

        public string ApprovePromotionForApproveCode(Edge.SVA.Model.BUY_PROMO_H model, out bool isSuccess)
        {
            isSuccess = false;
            if (model == null) return "No Data";

            if (model.ApproveStatus != "P") return Resources.MessageTips.TheTransactionStatusNotPending;

            model.ApproveStatus = "A";
            model.ApproveOn = DateTime.Now;
            model.ApproveBy = Tools.DALTool.GetCurrentUser().UserID;
            //model.ApproveBusDate = ConvertTool.ConverNullable<DateTime>(DALTool.GetBusinessDate());

            Edge.SVA.BLL.BUY_PROMO_H bll = new Edge.SVA.BLL.BUY_PROMO_H();

            if (bll.Update(model))
            {
                model = new Edge.SVA.BLL.BUY_PROMO_H().GetModel(model.PromotionCode);
                isSuccess = true;
                return model.ApprovalCode;
            }
            return "";
        }

        private bool VoidPrice(Edge.SVA.Model.BUY_PROMO_H model)
        {
            if (model == null) return false;

            if (model.ApproveStatus != "P") return false;

            model.ApproveStatus = "V";
            model.ApproveOn = DateTime.Now;
            model.ApproveBy = Tools.DALTool.GetCurrentUser().UserID;
            //model.ApproveBusDate = ConvertTool.ConverNullable<DateTime>(DALTool.GetBusinessDate());

            Edge.SVA.BLL.BUY_PROMO_H bll = new Edge.SVA.BLL.BUY_PROMO_H();

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
                Edge.SVA.Model.BUY_PROMO_H model = new Edge.SVA.BLL.BUY_PROMO_H().GetModel(id);
                if (VoidPrice(model)) success++;
            }
            return string.Format(Resources.MessageTips.ApproveResult, success, count - success);
        }
    }
}