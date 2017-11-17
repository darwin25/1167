using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.Data;
using Edge.SVA.Model.Domain.WebBuying;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.BUY_MONTHFLAG
{
    public class BuyingMonthFlagController
    {
        protected MonthFlagViewModel viewModel = new MonthFlagViewModel();

        public MonthFlagViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(int MonthFlagID)
        {
            Edge.SVA.BLL.BUY_MONTHFLAG bll = new Edge.SVA.BLL.BUY_MONTHFLAG();
            Edge.SVA.Model.BUY_MONTHFLAG model = bll.GetModel(MonthFlagID);
            viewModel.MainTable = model;
        }

        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.BUY_MONTHFLAG bll = new Edge.SVA.BLL.BUY_MONTHFLAG();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);

            //获取排序字段
            string orderStr = "MonthFlagCode";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetListByPage(strWhere, orderStr, pageSize * pageIndex + 1, pageSize * (pageIndex + 1));

            Tools.DataTool.AddDayFlagName(ds, "JanuaryFlagName", "JanuaryFlag");
            Tools.DataTool.AddDayFlagName(ds, "FebruaryFlagName", "FebruaryFlag");
            Tools.DataTool.AddDayFlagName(ds, "MarchFlagName", "MarchFlag");
            Tools.DataTool.AddDayFlagName(ds, "AprilFlagName", "AprilFlag");
            Tools.DataTool.AddDayFlagName(ds, "MayFlagName", "MayFlag");
            Tools.DataTool.AddDayFlagName(ds, "JuneFlagName", "JuneFlag");
            Tools.DataTool.AddDayFlagName(ds, "JulyFlagName", "JulyFlag");
            Tools.DataTool.AddDayFlagName(ds, "AugustFlagName", "AugustFlag");
            Tools.DataTool.AddDayFlagName(ds, "SeptemberFlagName", "SeptemberFlag");
            Tools.DataTool.AddDayFlagName(ds, "OctoberFlagName", "OctoberFlag");
            Tools.DataTool.AddDayFlagName(ds, "NovemberFlagName", "NovemberFlag");
            Tools.DataTool.AddDayFlagName(ds, "DecemberFlagName", "DecemberFlag");

            return ds;
        }

        public ExecResult Add()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_MONTHFLAG bll = new SVA.BLL.BUY_MONTHFLAG();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.MonthFlagCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.MonthFlagCode);
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
                Edge.SVA.BLL.BUY_MONTHFLAG bll = new SVA.BLL.BUY_MONTHFLAG();

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
            Edge.SVA.BLL.BUY_MONTHFLAG bll = new SVA.BLL.BUY_MONTHFLAG();
            List<Edge.SVA.Model.BUY_MONTHFLAG> list = bll.GetModelList("MonthFlagCode = '" + strWhere + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }
    }
}