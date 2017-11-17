using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Edge.SVA.Model.Domain.WebBuying;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_PRODUCTSIZE
{
    public class BuyingProductSizeController
    {
        protected ProductSizeViewModel viewModel = new ProductSizeViewModel();

        public ProductSizeViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(int ProductSizeID)
        {
            Edge.SVA.BLL.BUY_PRODUCTSIZE bll = new Edge.SVA.BLL.BUY_PRODUCTSIZE();
            Edge.SVA.Model.BUY_PRODUCTSIZE model = bll.GetModel(ProductSizeID);
            viewModel.MainTable = model;
        }

        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.BUY_PRODUCTSIZE bll = new Edge.SVA.BLL.BUY_PRODUCTSIZE();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);

            //获取排序字段
            string orderStr = "ProductSizeCode";
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
                Edge.SVA.BLL.BUY_PRODUCTSIZE bll = new SVA.BLL.BUY_PRODUCTSIZE();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.ProductSizeCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.ProductSizeCode);
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
                Edge.SVA.BLL.BUY_PRODUCTSIZE bll = new SVA.BLL.BUY_PRODUCTSIZE();

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
            Edge.SVA.BLL.BUY_PRODUCTSIZE bll = new SVA.BLL.BUY_PRODUCTSIZE();
            List<Edge.SVA.Model.BUY_PRODUCTSIZE> list = bll.GetModelList("ProductSizeCode = '" + strWhere + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }
    }
}