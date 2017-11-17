using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using System.Data;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_FULFILLMENTHOUSE
{
    public class BuyingFulfillmenthouseController
    {
        protected FulfillmenthouseViewModel viewModel = new FulfillmenthouseViewModel();

        public FulfillmenthouseViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(int FulfillmentHouseID)
        {
            Edge.SVA.BLL.BUY_FULFILLMENTHOUSE bll = new Edge.SVA.BLL.BUY_FULFILLMENTHOUSE();
            Edge.SVA.Model.BUY_FULFILLMENTHOUSE model = bll.GetModel(FulfillmentHouseID);
            viewModel.MainTable = model;
        }

        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.BUY_FULFILLMENTHOUSE bll = new Edge.SVA.BLL.BUY_FULFILLMENTHOUSE();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);

            //获取排序字段
            string orderStr = "FulfillmentHouseCode";
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
                Edge.SVA.BLL.BUY_FULFILLMENTHOUSE bll = new SVA.BLL.BUY_FULFILLMENTHOUSE();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.FulfillmentHouseCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.FulfillmentHouseCode);
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
                Edge.SVA.BLL.BUY_FULFILLMENTHOUSE bll = new SVA.BLL.BUY_FULFILLMENTHOUSE();

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
            Edge.SVA.BLL.BUY_FULFILLMENTHOUSE bll = new SVA.BLL.BUY_FULFILLMENTHOUSE();
            List<Edge.SVA.Model.BUY_FULFILLMENTHOUSE> list = bll.GetModelList("FulfillmentHouseCode = '" + strWhere + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }
    }
}