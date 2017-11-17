    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.Data;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BRAND
{
    public class BuyingBrandController
    {
        protected BrandViewModel viewModel = new BrandViewModel();

        public BrandViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(int BrandID)
        {
            Edge.SVA.BLL.BUY_BRAND bll = new Edge.SVA.BLL.BUY_BRAND();
            Edge.SVA.Model.BUY_BRAND model = bll.GetModel(BrandID);
            viewModel.MainTable = model;
        }

        public ExecResult Add()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_BRAND bll = new Edge.SVA.BLL.BUY_BRAND();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.BrandCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.BrandCode);
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
                Edge.SVA.BLL.BUY_BRAND bll = new Edge.SVA.BLL.BUY_BRAND();

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
            Edge.SVA.BLL.BUY_BRAND bll = new Edge.SVA.BLL.BUY_BRAND();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);

            //获取排序字段
            string orderStr = "BrandCode";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetListByPage(strWhere, orderStr, pageSize * pageIndex + 1, pageSize * (pageIndex + 1));

            if (ds != null)
            {
                Tools.DataTool.AddBuyingBrandName(ds, "BrandName", "BrandCode");
            }

            return ds;
        }

        public string ValidateForm()
        {
            return "";
        }

        public string ValidateObject(string strWhere)
        {
            Edge.SVA.BLL.BUY_BRAND bll = new SVA.BLL.BUY_BRAND();
            List<Edge.SVA.Model.BUY_BRAND> list = bll.GetModelList("BrandCode = '" + strWhere + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }
    }
}