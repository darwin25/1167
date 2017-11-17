using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.Data;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BARCODE
{
    public class BuyingBarCodeController
    {
        protected BarCodeViewModel viewModel = new BarCodeViewModel();

        public BarCodeViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(string BarCode)
        {
            Edge.SVA.BLL.BUY_BARCODE bll = new Edge.SVA.BLL.BUY_BARCODE();
            Edge.SVA.Model.BUY_BARCODE model = bll.GetModel(BarCode);
            viewModel.MainTable = model;
        }

        public ExecResult Add()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_BARCODE bll = new Edge.SVA.BLL.BUY_BARCODE();

                //保存
                if (this.IsExists(viewModel.MainTable.Barcode, viewModel.MainTable.ProdCode))
                {
                    bll.Update(viewModel.MainTable);
                }
                else
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
                Edge.SVA.BLL.BUY_BARCODE bll = new Edge.SVA.BLL.BUY_BARCODE();

                //保存
                if (this.IsExists(viewModel.MainTable.Barcode, viewModel.MainTable.ProdCode))
                {
                    bll.Update(viewModel.MainTable);
                }
                else
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
        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.BUY_BARCODE bll = new Edge.SVA.BLL.BUY_BARCODE();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);
            //获取排序字段
            string orderStr = "BarCode";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetListByPage(strWhere, orderStr, pageSize * pageIndex + 1, pageSize * (pageIndex + 1));

            //ds.Tables[0].Columns.Add(new DataColumn("InternalBarcodeText", typeof(string)));

            return ds;
        }

        public bool IsExists(string BarCode, string ProdCode)
        {
            Edge.SVA.BLL.BUY_BARCODE bll = new Edge.SVA.BLL.BUY_BARCODE();
            string strwhere = " BarCode = '" + BarCode + "' and Prodcode = '" + ProdCode + "'";
            return (bll.GetModelList(strwhere).Count > 0) ? true : false;
        }

    }
}