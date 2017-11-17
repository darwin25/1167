using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Edge.SVA.Model.Domain.WebBuying;
using Edge.SVA.Model.Domain.WebInterfaces;
namespace Edge.Web.Controllers.WebBuying.MasterFiles.FreightSettings
{
    /// <summary>
    /// 运费设置
    /// 创建人：Lisa
    /// 创建时间：2015-12-31
    /// </summary>
    public class LogisticsPriceController
    {
        protected LogisticsPriceViewModel viewModel = new LogisticsPriceViewModel();

        public LogisticsPriceViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(int KeyID)
        {
            Edge.SVA.BLL.LogisticsPrice bll = new Edge.SVA.BLL.LogisticsPrice();
            Edge.SVA.Model.LogisticsPrice model = bll.GetModel(KeyID);
            viewModel.MainTable = model;
          
        }

        private const string fields = " KeyID,LogisticsProviderID,ProvinceCode,StartPrice,StartWeight,OverflowPricePerKG";
        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            if (string.IsNullOrEmpty(strWhere))
            {

                strWhere = " 1=1";
            }

            DataSet ds;
            Edge.SVA.BLL.LogisticsPrice bll = new Edge.SVA.BLL.LogisticsPrice()
            {
                StrWhere = strWhere,
                Order = "KeyID",
                Fields = fields,
                Ascending = false
            };
            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);
            //获取排序字段
            string orderStr = "KeyID";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetList(pageSize, pageIndex, out recodeCount);
            Tools.DataTool.AddLogisticsProviderName(ds, "LogisticsProviderName", "LogisticsProviderID");
            Tools.DataTool.AddProviceName(ds, "LogisticsProvinceName", "ProvinceCode");
            return ds;

        }

        public ExecResult Add()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.LogisticsPrice bll = new Edge.SVA.BLL.LogisticsPrice();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (viewModel.MainTable.ProvinceCode != "" && viewModel.MainTable.LogisticsProviderID!=0)
                {
                    string where = "LogisticsProviderID=" + viewModel.MainTable.LogisticsProviderID + " and ProvinceCode='"+viewModel.MainTable.ProvinceCode+"'";
                    rtn.Message = ValidateObject(where);
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
                Edge.SVA.BLL.LogisticsPrice bll = new Edge.SVA.BLL.LogisticsPrice();

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
        public ExecResult Delete(string keyIDList)
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.LogisticsPrice bll = new Edge.SVA.BLL.LogisticsPrice();

                if (rtn.Message == "")
                {
                    bll.DeleteList(keyIDList);
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
            Edge.SVA.BLL.LogisticsPrice bll = new SVA.BLL.LogisticsPrice();
            List<Edge.SVA.Model.LogisticsPrice> list = bll.GetModelList(strWhere);
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }
    }
}