using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using System.Data;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.Web.Tools;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_DEPARTMENT
{
    public class BuyingDepartmentController
    {
        protected DepartmentViewModel viewModel = new DepartmentViewModel();

        public DepartmentViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(string DepartCode)
        {
            Edge.SVA.BLL.BUY_DEPARTMENT bll = new Edge.SVA.BLL.BUY_DEPARTMENT();
            Edge.SVA.Model.BUY_DEPARTMENT model = bll.GetModel(DepartCode);
            viewModel.MainTable = model;
        }

        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.BUY_DEPARTMENT bll = new Edge.SVA.BLL.BUY_DEPARTMENT();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);

            //获取排序字段
            string orderStr = "DepartCode";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetListByPage(strWhere, orderStr, pageSize * pageIndex + 1, pageSize * (pageIndex + 1));

            return ds;
        }

        public ExecResult Add()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_DEPARTMENT bll = new SVA.BLL.BUY_DEPARTMENT();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.DepartCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.DepartCode);
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
                Edge.SVA.BLL.BUY_DEPARTMENT bll = new SVA.BLL.BUY_DEPARTMENT();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (rtn.Message == "")
                {
                    bll.Update(viewModel.MainTable);
                }

            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }

        public string ValidateForm()
        {
            return "";
        }

        public string ValidateObject(string strWhere)
        {
            Edge.SVA.BLL.BUY_DEPARTMENT bll = new SVA.BLL.BUY_DEPARTMENT();
            List<Edge.SVA.Model.BUY_DEPARTMENT> list = bll.GetModelList("DepartCode = '" + strWhere + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }

        public void BindReplenFormula(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_REPLENFORMULA bll = new SVA.BLL.BUY_REPLENFORMULA(); 
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "ReplenFormulaCode", "Description", "Description", "Description", "ReplenFormulaCode");
        }

        public void BindFulfillmentHouse(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_FULFILLMENTHOUSE bll = new SVA.BLL.BUY_FULFILLMENTHOUSE();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "FulfillmentHouseCode", "FulfillmentHouseName1", "FulfillmentHouseName2", "FulfillmentHouseName3", "FulfillmentHouseCode");
        }
    }
}