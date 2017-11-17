using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.Data;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.ProductSettings.BUY_ProductParticulars
{
    public class BuyingProdParticularsController
    {
        private ProdParticularsViewModel viewModel = new ProdParticularsViewModel();

        public ProdParticularsViewModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }

        Edge.SVA.BLL.BUY_ProductParticulars bll = new SVA.BLL.BUY_ProductParticulars();

        public void LoadViewModel(string ProdCode,int langID)
        {
            viewModel.MainTable = bll.GetModel(ProdCode, langID);
        }

        public DataSet GetList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            recodeCount = bll.GetRecordCount(strWhere);
            ds = bll.GetListByPage(strWhere, sortFieldStr, pageSize * pageIndex + 1, pageSize * (pageIndex + 1));
            return ds;
        }

        public ExecResult Add()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                bll.Add(viewModel.MainTable);
            }
            catch(Exception ex)
            {
                rtn.Message = ex.Message;
            }
            return rtn;
        }

        public ExecResult Update()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                bll.Update(viewModel.MainTable);
            }
            catch (Exception ex)
            {
                rtn.Message = ex.Message;
            }
            return rtn;
        }
    }
}