    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.Data;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BRAND
{
    public class BrandController
    {
        protected StoreBrandViewModel viewModel = new StoreBrandViewModel();

        public StoreBrandViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(int BrandID)
        {
            Edge.SVA.BLL.Brand bll = new Edge.SVA.BLL.Brand();
            Edge.SVA.Model.Brand model = bll.GetModel(BrandID);
            viewModel.MainTable = model;
        }

        public ExecResult Add()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.Brand bll = new Edge.SVA.BLL.Brand();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.StoreBrandCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.StoreBrandCode);
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
                Edge.SVA.BLL.Brand bll = new Edge.SVA.BLL.Brand();

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
            Edge.SVA.BLL.Brand bll = new Edge.SVA.BLL.Brand();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);

            //获取排序字段
            string orderStr = "StoreBrandCode";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetListByPage(strWhere, orderStr, pageSize * pageIndex + 1, pageSize * (pageIndex + 1));

            if (ds != null)
            {
                Tools.DataTool.AddBrandName(ds, "StoreBrandName", "StoreBrandCode");
            }

            return ds;
        }

        public string ValidateForm()
        {
            return "";
        }

        public string ValidateObject(string strWhere)
        {
            Edge.SVA.BLL.Brand bll = new SVA.BLL.Brand();
            List<Edge.SVA.Model.Brand> list = bll.GetModelList("StoreBrandCode = '" + strWhere + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }
    }
}