using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using System.Data;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.ProductSettings.BUY_ProductAssociated
{
    public class BuyingProdAssociatedController
    {
        private ProductAssociatedViewModel viewModel = new ProductAssociatedViewModel();
        Edge.SVA.BLL.BUY_ProductAssociated bll = new SVA.BLL.BUY_ProductAssociated();

        public ProductAssociatedViewModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }

        public void LoadViewModel(int KeyID)
        {
            viewModel.MainTable = bll.GetModel(KeyID);
        }

        public DataSet GetList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);
            //获取排序字段
            string orderStr = "KeyID";
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

        public DataSet GetProdInfo(string prodcode)
        {
            DataSet ds;
            if (!string.IsNullOrEmpty(prodcode))
            {
                string sql = @"select ProdDesc1,ProdDesc2,ProdDesc3,ProdPicFile from BUY_PRODUCT where ProdCode='" + prodcode + "'";
                ds = DBUtility.DbHelperSQL.Query(sql);
                return ds;
            }
            else
            {
                return null;
            }
        }
    }
}