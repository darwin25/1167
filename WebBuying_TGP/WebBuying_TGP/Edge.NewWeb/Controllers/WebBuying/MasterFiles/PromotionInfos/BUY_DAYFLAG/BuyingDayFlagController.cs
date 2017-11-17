using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using System.Data;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.BUY_DAYFLAG
{
    public class BuyingDayFlagController
    {
        protected DayFlagViewModel viewModel = new DayFlagViewModel();

        public DayFlagViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(int DayFlagID)
        {
            Edge.SVA.BLL.BUY_DAYFLAG bll = new Edge.SVA.BLL.BUY_DAYFLAG();
            Edge.SVA.Model.BUY_DAYFLAG model = bll.GetModel(DayFlagID);
            viewModel.MainTable = model;
        }

        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.BUY_DAYFLAG bll = new Edge.SVA.BLL.BUY_DAYFLAG();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);

            //获取排序字段
            string orderStr = "DayFlagCode";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetListByPage(strWhere, orderStr, pageSize * pageIndex + 1, pageSize * (pageIndex + 1));

            Tools.DataTool.AddDayFlagName(ds, "Day1FlagName", "Day1Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day2FlagName", "Day2Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day3FlagName", "Day3Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day4FlagName", "Day4Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day5FlagName", "Day5Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day6FlagName", "Day6Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day7FlagName", "Day7Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day8FlagName", "Day8Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day9FlagName", "Day9Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day10FlagName", "Day10Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day11FlagName", "Day11Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day12FlagName", "Day12Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day13FlagName", "Day13Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day14FlagName", "Day14Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day15FlagName", "Day15Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day16FlagName", "Day16Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day17FlagName", "Day17Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day18FlagName", "Day18Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day19FlagName", "Day19Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day20FlagName", "Day20Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day21FlagName", "Day21Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day22FlagName", "Day22Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day23FlagName", "Day23Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day24FlagName", "Day24Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day25FlagName", "Day25Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day26FlagName", "Day26Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day27FlagName", "Day27Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day28FlagName", "Day28Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day29FlagName", "Day29Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day30FlagName", "Day30Flag");
            Tools.DataTool.AddDayFlagName(ds, "Day31FlagName", "Day31Flag");

            return ds;
        }

        public ExecResult Add()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_DAYFLAG bll = new SVA.BLL.BUY_DAYFLAG();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.DayFlagCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.DayFlagCode);
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
                Edge.SVA.BLL.BUY_DAYFLAG bll = new SVA.BLL.BUY_DAYFLAG();

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
            Edge.SVA.BLL.BUY_DAYFLAG bll = new SVA.BLL.BUY_DAYFLAG();
            List<Edge.SVA.Model.BUY_DAYFLAG> list = bll.GetModelList("DayFlagCode = '" + strWhere + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }
    }
}