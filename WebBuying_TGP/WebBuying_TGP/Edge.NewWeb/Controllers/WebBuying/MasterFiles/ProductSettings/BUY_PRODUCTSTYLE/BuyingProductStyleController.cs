using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using System.Data;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.ProductSettings.BUY_PRODUCTSTYLE
{
    public class BuyingProductStyleController
    {
        private ProductStyleViewModel viewModel = new ProductStyleViewModel();
        Edge.SVA.BLL.BUY_PRODUCTSTYLE bll = new SVA.BLL.BUY_PRODUCTSTYLE();

        public ProductStyleViewModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }

        public void LoadViewModel(string StyleCode,string ProdCode)
        {
            viewModel.MainTable = bll.GetModel(StyleCode, ProdCode);
        }

        public DataSet GetList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);
            //获取排序字段
            string orderStr = "ProdCodeStyle";
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
                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.ProdCodeStyle,viewModel.MainTable.ProdCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.ProdCodeStyle, viewModel.MainTable.ProdCode);
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

        public string ValidateObject(string StyleCode,string ProdCode)
        {
            List<Edge.SVA.Model.BUY_PRODUCTSTYLE> list = bll.GetModelList("ProdCodeStyle='" + StyleCode + "' and ProdCode='" + ProdCode + "'");
            if (list.Count > 0)
            {
               return Resources.MessageTips.ExistRecord;
            }
            return "";
        }
    }
}