using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.SVA.Model.Domain.WebBuying;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_REPLEN
{
    public class BUY_REPLENController
    {

        protected BUY_REPLENViewModel viewModel = new BUY_REPLENViewModel();

        public BUY_REPLENViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(string ReplenCode)
        {
            Edge.SVA.BLL.BUY_REPLEN_H bll = new Edge.SVA.BLL.BUY_REPLEN_H();
            Edge.SVA.Model.BUY_REPLEN_H model = bll.GetModel(ReplenCode);
            viewModel.MainTable = model;
            Edge.SVA.BLL.BUY_REPLEN_D bllDetail = new SVA.BLL.BUY_REPLEN_D();
            DataSet ds = bllDetail.GetList("ReplenCode='" + ReplenCode + "'");
            AddEntityTypeName(ds, "EntityTypeName", "EntityType");
            viewModel.DetailTable = ds.Tables[0];
        }

        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.BUY_REPLEN_H bll = new Edge.SVA.BLL.BUY_REPLEN_H();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);

            //获取排序字段
            string orderStr = "ReplenCode";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetListByPage(strWhere, orderStr, pageSize * pageIndex + 1, pageSize * (pageIndex + 1));

            if (ds != null)
            {
                Tools.DataTool.AddBuyingStoreNameByID(ds, "StoreName", "StoreID");
                Tools.DataTool.AddUserName(ds, "CreatedByName", "CreatedBy");
            }

            return ds;
        }
        public ExecResult Add()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_REPLEN_H bll = new Edge.SVA.BLL.BUY_REPLEN_H();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.ReplenCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.ReplenCode);
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
                Edge.SVA.BLL.BUY_REPLEN_H bll = new Edge.SVA.BLL.BUY_REPLEN_H();

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
            Edge.SVA.BLL.BUY_REPLEN_H bll = new SVA.BLL.BUY_REPLEN_H();
            List<Edge.SVA.Model.BUY_REPLEN_H> list = bll.GetModelList("ReplenCode = '" + strWhere + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }
        internal static void AddEntityTypeName(DataSet ds, string newColumn, string refKey)
        {
            int id = 0;
            ds.Tables[0].Columns.Add(new DataColumn(newColumn, typeof(string)));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                id = int.TryParse(row[refKey].ToString(), out id) ? id : int.MinValue;
                if (row[refKey].ToString() == "1" || refKey == "0")
                    row[newColumn] = "Prodcode";
                else
                    row[newColumn] = "DepartCode";
            }
        }
    }
}