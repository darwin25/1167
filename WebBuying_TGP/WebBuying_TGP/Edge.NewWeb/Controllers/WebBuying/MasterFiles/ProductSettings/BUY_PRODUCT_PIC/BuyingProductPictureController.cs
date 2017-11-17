using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using System.Data;
using System.Data.SqlClient;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.ProductSettings.BUY_PRODUCT_PIC
{
    public class BuyingProductPictureController
    {
        private ProductPictureViewModel viewModel = new ProductPictureViewModel();
        Edge.SVA.BLL.BUY_PRODUCT_PIC bll = new SVA.BLL.BUY_PRODUCT_PIC();
        Edge.SVA.BLL.BUY_PRODUCT_PIC_Pending bllPending = new SVA.BLL.BUY_PRODUCT_PIC_Pending();
        public ProductPictureViewModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }

        public void LoadViewModel(int KeyID)
        {
            viewModel.MainTable = bll.GetModel(KeyID);
        }

        public void LoadViewPendingModel(int keyID)
        {
            viewModel.MainPending = bllPending.GetModel(keyID);
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

        public DataSet GetPendingList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            //获得总条数
            recodeCount = bllPending.GetRecordCount(strWhere);
            //获取排序字段
            string orderStr = "KeyID";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bllPending.GetListByPage(strWhere, orderStr, pageSize * pageIndex + 1, pageSize * (pageIndex + 1));

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
        public ExecResult PendingAdd()
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
                    bllPending.Add(viewModel.MainPending);
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
        public ExecResult PendingUpdate()
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
                    bllPending.Update(viewModel.MainPending);
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

    }
}