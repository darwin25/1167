using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using System.Data;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.Web.Tools;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_STORE
{
    public class BuyingStoreController
    {
        protected StoreViewModel viewModel = new StoreViewModel();

        public StoreViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(int StoreID)
        {
            Edge.SVA.BLL.BUY_STORE bll = new Edge.SVA.BLL.BUY_STORE();
            Edge.SVA.Model.BUY_STORE model = bll.GetModel(StoreID);
            viewModel.MainTable = model;
        }

        private const string condition = " StoreBrandCode in (select StoreBrandCode from Brand where StoreID in {0})";
        private const string andCondition = " and StoreBrandCode in (select StoreBrandCode from Brand where StoreID in {0})";
        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            string userids = SVASessionInfo.CurrentUser.SqlConditionUserIDs;
            string storeids = SVASessionInfo.CurrentUser.SqlConditionStoreIDs;
            if (string.IsNullOrEmpty(strWhere))
            {
                if (string.IsNullOrEmpty(storeids))
                {
                    strWhere = "1 = 1"; //" 1=1";
                }
                else
                {
                    strWhere = string.Format(condition, storeids, userids);
                }
            }
            else
            {
                strWhere += string.Format(andCondition, storeids, userids);
            }
            Edge.SVA.BLL.BUY_STORE bll = new Edge.SVA.BLL.BUY_STORE();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);

            //获取排序字段
            string orderStr = "StoreCode";
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
                Edge.SVA.BLL.BUY_STORE bll = new SVA.BLL.BUY_STORE();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.StoreCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.StoreCode);
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
                Edge.SVA.BLL.BUY_STORE bll = new SVA.BLL.BUY_STORE();

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
            Edge.SVA.BLL.BUY_STORE bll = new SVA.BLL.BUY_STORE();
            List<Edge.SVA.Model.BUY_STORE> list = bll.GetModelList("StoreCode = '" + strWhere + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }
    }
}