using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using System.Data;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.BUY_WEEKFLAG
{
    public class BuyingWeekFlagController
    {
        protected WeekFlagViewModel viewModel = new WeekFlagViewModel();

        public WeekFlagViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(int WeekFlagID)
        {
            Edge.SVA.BLL.BUY_WEEKFLAG bll = new Edge.SVA.BLL.BUY_WEEKFLAG();
            Edge.SVA.Model.BUY_WEEKFLAG model = bll.GetModel(WeekFlagID);
            viewModel.MainTable = model;
        }

        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.BUY_WEEKFLAG bll = new Edge.SVA.BLL.BUY_WEEKFLAG();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);

            //获取排序字段
            string orderStr = "WeekFlagCode";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetListByPage(strWhere, orderStr, pageSize * pageIndex + 1, pageSize * (pageIndex + 1));

            Tools.DataTool.AddDayFlagName(ds, "SundayFlagName", "SundayFlag");
            Tools.DataTool.AddDayFlagName(ds, "MondayFlagName", "MondayFlag");
            Tools.DataTool.AddDayFlagName(ds, "TuesdayFlagName", "TuesdayFlag");
            Tools.DataTool.AddDayFlagName(ds, "WednesdayFlagName", "WednesdayFlag");
            Tools.DataTool.AddDayFlagName(ds, "ThursdayFlagName", "ThursdayFlag");
            Tools.DataTool.AddDayFlagName(ds, "FridayFlagName", "FridayFlag");
            Tools.DataTool.AddDayFlagName(ds, "SaturdayFlagName", "SaturdayFlag");

            return ds;
        }

        public ExecResult Add()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_WEEKFLAG bll = new SVA.BLL.BUY_WEEKFLAG();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.WeekFlagCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.WeekFlagCode);
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
                Edge.SVA.BLL.BUY_WEEKFLAG bll = new SVA.BLL.BUY_WEEKFLAG();

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
            Edge.SVA.BLL.BUY_WEEKFLAG bll = new SVA.BLL.BUY_WEEKFLAG();
            List<Edge.SVA.Model.BUY_WEEKFLAG> list = bll.GetModelList("WeekFlagCode = '" + strWhere + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }
    }
}