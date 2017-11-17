using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using System.Data;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_VENDOR
{
    public class BuyingVendorController
    {
        protected VendorViewModel viewModel = new VendorViewModel();

        public VendorViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(int VendorID)
        {
            Edge.SVA.BLL.BUY_VENDOR bll = new Edge.SVA.BLL.BUY_VENDOR();
            Edge.SVA.Model.BUY_VENDOR model = bll.GetModel(VendorID);
            viewModel.MainTable = model;
        }

        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.BUY_VENDOR bll = new Edge.SVA.BLL.BUY_VENDOR();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);

            //获取排序字段
            string orderStr = "VendorCode";
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
                Edge.SVA.BLL.BUY_VENDOR bll = new SVA.BLL.BUY_VENDOR();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.VendorCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.VendorCode);
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
                Edge.SVA.BLL.BUY_VENDOR bll = new SVA.BLL.BUY_VENDOR();

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
            Edge.SVA.BLL.BUY_VENDOR bll = new SVA.BLL.BUY_VENDOR();
            List<Edge.SVA.Model.BUY_VENDOR> list = bll.GetModelList("VendorCode = '" + strWhere + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }
    }
}