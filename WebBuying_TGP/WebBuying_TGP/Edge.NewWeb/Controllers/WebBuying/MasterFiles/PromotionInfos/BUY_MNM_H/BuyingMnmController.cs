using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.Data;
using Edge.Web.Tools;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.BUY_MNM_H
{
    public class BuyingMnmController
    {
        protected MnmViewModel viewModel = new MnmViewModel();

        public MnmViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(string MNMCode)
        {
            Edge.SVA.BLL.BUY_MNM_H bll = new Edge.SVA.BLL.BUY_MNM_H();
            Edge.SVA.Model.BUY_MNM_H model = bll.GetModel(MNMCode);
            viewModel.MainTable = model;

            Edge.SVA.BLL.BUY_MNM_D blld = new SVA.BLL.BUY_MNM_D();
            DataSet ds = blld.GetList("MNMCode = '" + MNMCode + "'");
            viewModel.SubTable = ds.Tables.Count > 0 ? ds.Tables[0] : null;

            DataTool.AddEntityTypeName(viewModel.SubTable, "EntityTypeName", "EntityType");
            DataTool.AddHitTypeName(viewModel.SubTable, "TypeName", "Type");

        }

        public ExecResult Add()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_MNM_H bll = new Edge.SVA.BLL.BUY_MNM_H();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.MNMCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.MNMCode);
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
                Edge.SVA.BLL.BUY_MNM_H bll = new Edge.SVA.BLL.BUY_MNM_H();
                Edge.SVA.BLL.BUY_MNM_D blld = new SVA.BLL.BUY_MNM_D();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (rtn.Message == "")
                {
                    bll.Update(viewModel.MainTable);
                    blld.DeleteData(viewModel.MainTable.MNMCode);
                    if (viewModel.SubTable != null && viewModel.SubTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < viewModel.SubTable.Rows.Count; i++)
                        {
                            Edge.SVA.Model.BUY_MNM_D model = new SVA.Model.BUY_MNM_D();
                            DataRow dr = viewModel.SubTable.Rows[i];
                            model.MNMCode = dr["MNMCode"].ToString();
                            model.EntityNum = dr["EntityNum"].ToString();
                            model.EntityType = ConvertTool.ToInt(dr["EntityType"].ToString());
                            model.Type = ConvertTool.ToInt(dr["Type"].ToString());
                            model.Qty = ConvertTool.ToInt(dr["Qty"].ToString());
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

        public ExecResult Delete(string MNMCode)
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_MNM_H bll = new Edge.SVA.BLL.BUY_MNM_H();
                Edge.SVA.BLL.BUY_MNM_D blld = new SVA.BLL.BUY_MNM_D();

                if (rtn.Message == "")
                {
                    bll.Delete(MNMCode);
                    blld.DeleteData(MNMCode);
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
            Edge.SVA.BLL.BUY_MNM_H bll = new Edge.SVA.BLL.BUY_MNM_H();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);
            //获取排序字段
            string orderStr = "MNMCode";
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
            Edge.SVA.BLL.BUY_MNM_H bll = new SVA.BLL.BUY_MNM_H();
            List<Edge.SVA.Model.BUY_MNM_H> list = bll.GetModelList("MNMCode = '" + strWhere + "'");
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
            ControlTool.BindCardTypeFromSVA(ddl);
        }

        public void BindCardGrade(FineUI.DropDownList ddl, string CardTypeCode)
        {
            ControlTool.BindCardGradeFromSVA(ddl, CardTypeCode);
        }

        public string ApproveMnmForApproveCode(Edge.SVA.Model.BUY_MNM_H model, out bool isSuccess)
        {
            isSuccess = false;
            if (model == null) return "No Data";

            if (model.ApproveStatus != "P") return Resources.MessageTips.TheTransactionStatusNotPending;

            model.ApproveStatus = "A";
            model.ApproveOn = DateTime.Now;
            model.ApproveBy = Tools.DALTool.GetCurrentUser().UserID;
            //model.ApproveBusDate = ConvertTool.ConverNullable<DateTime>(DALTool.GetBusinessDate());

            Edge.SVA.BLL.BUY_MNM_H bll = new Edge.SVA.BLL.BUY_MNM_H();

            if (bll.Update(model))
            {
                model = new Edge.SVA.BLL.BUY_MNM_H().GetModel(model.MNMCode);
                isSuccess = true;
                return model.ApprovalCode;
            }
            return "";
        }

        private bool VoidMnm(Edge.SVA.Model.BUY_MNM_H model)
        {
            if (model == null) return false;

            if (model.ApproveStatus != "P") return false;

            model.ApproveStatus = "V";
            model.ApproveOn = DateTime.Now;
            model.ApproveBy = Tools.DALTool.GetCurrentUser().UserID;
            //model.ApproveBusDate = ConvertTool.ConverNullable<DateTime>(DALTool.GetBusinessDate());

            Edge.SVA.BLL.BUY_MNM_H bll = new Edge.SVA.BLL.BUY_MNM_H();

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
                Edge.SVA.Model.BUY_MNM_H model = new Edge.SVA.BLL.BUY_MNM_H().GetModel(id);
                if (VoidMnm(model)) success++;
            }
            return string.Format(Resources.MessageTips.ApproveResult, success, count - success);
        }
    }
}