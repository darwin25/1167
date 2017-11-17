using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.SVA.Model.Domain.WebBuying;
using System.Data;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BANK
{
    public class BuyingBankController
    {
        protected BankViewModel viewModel = new BankViewModel();

        public BankViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(int BankID)
        {
            Edge.SVA.BLL.BUY_BANK bll = new Edge.SVA.BLL.BUY_BANK();
            Edge.SVA.Model.BUY_BANK model = bll.GetModel(BankID);
            viewModel.MainTable = model;
        }

        public ExecResult Add()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_BANK bll = new Edge.SVA.BLL.BUY_BANK();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.BankCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.BankCode);
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
                Edge.SVA.BLL.BUY_BANK bll = new Edge.SVA.BLL.BUY_BANK();

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

        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.BUY_BANK bll = new Edge.SVA.BLL.BUY_BANK();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);
            //获取排序字段
            string orderStr = "BankCode";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetListByPage(strWhere, orderStr, pageSize * pageIndex + 1, pageSize * (pageIndex + 1));

            Tools.DataTool.AddBuyingBankName(ds, "BankName", "BankCode");

            return ds;
        }

        public string ValidateForm()
        {
            return "";
        }

        public string ValidateObject(string strWhere)
        {
            Edge.SVA.BLL.BUY_BANK bll = new SVA.BLL.BUY_BANK();
            List<Edge.SVA.Model.BUY_BANK> list = bll.GetModelList("BankCode = '" + strWhere + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }
    }
}