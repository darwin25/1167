using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Edge.SVA.Model.Domain.Operation;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.Controllers.Operation.DeliveryOrderManagement
{
    public class DeliveryOrderController
    {
        protected Sales_HViewModel viewModel = new Sales_HViewModel();

        public Sales_HViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(string TransNum)
        {
            Edge.SVA.BLL.Sales_H bll = new Edge.SVA.BLL.Sales_H();
            Edge.SVA.Model.Sales_H model = bll.GetModel(TransNum);
            viewModel.MainTable = model;

        }


        string fields = @"TransNum,StoreCode,TransType,Status,CardNumber,MemberID,DeliveryNumber,TotalAmount,Contact,ContactPhone,LogisticsProviderID,CreatedOn,CreatedBy,BusDate";
        /// <summary>
        /// 查询送货单信息
        /// 创建人:王丽
        /// 创建时间：2015-12-21
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recodeCount"></param>
        /// <param name="sortFieldStr"></param>
        /// <returns></returns>
        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.Sales_H bll = new Edge.SVA.BLL.Sales_H()
            {
                StrWhere = strWhere,
                Order = "CreatedOn",
                Fields = fields,
                Ascending = false
            };

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);
            //获取排序字段
            string orderStr = "TransNum";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }
            ds = bll.GetList(pageSize, pageIndex, out recodeCount);
            Tools.DataTool.AddLogisticsProviderName(ds, "ProviderName", "LogisticsProviderID");
            Tools.DataTool.AddUserName(ds, "UserName", "CreatedBy");
            return ds;

        }

        public ExecResult Update()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.Sales_H bll = new Edge.SVA.BLL.Sales_H();

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
            Edge.SVA.BLL.Sales_H bll = new SVA.BLL.Sales_H();
            List<Edge.SVA.Model.Sales_H> list = bll.GetModelList("TransNum = '" + strWhere + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }
        /// <summary>
        /// 根据条件查询列表
        /// 创建人：王丽
        /// 创建时间：2016-03-29
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public DataSet GetTransactionListByParm(string strWhere, string filedOrder, string webSiteName)
        {
            Edge.SVA.BLL.Sales_H bll = new Edge.SVA.BLL.Sales_H();
            DataSet ds = bll.GetListByParm(strWhere, filedOrder, webSiteName);
            return ds;
        }

    }
}