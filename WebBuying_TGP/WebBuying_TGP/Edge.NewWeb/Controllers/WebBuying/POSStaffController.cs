using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using System.Data;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.SVA.BLL;
using System.Text;

namespace Edge.Web.Controllers.WebBuying.POSStaff
{
    public class POSStaffController
    {
        protected POSStaffViewModel viewModel = new POSStaffViewModel();

        public POSStaffViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(int StaffID)
        {
            Edge.SVA.BLL.POSSTAFF bll = new Edge.SVA.BLL.POSSTAFF();
            Edge.SVA.Model.POSSTAFF model = bll.GetModel(StaffID);
            viewModel.MainTable = model;
        }

        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.POSSTAFF bll = new Edge.SVA.BLL.POSSTAFF();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);

            //获取排序字段
            string orderStr = "StaffCode";
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
                Edge.SVA.BLL.POSSTAFF bll = new SVA.BLL.POSSTAFF();

                //保存
                if (bll.Exists(viewModel.MainTable.StaffID))
                {
                    //rtn.Success = false;
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
                Edge.SVA.BLL.POSSTAFF bll = new SVA.BLL.POSSTAFF();

                //保存
                bll.Update(viewModel.MainTable);
            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }

        #region
        public void GetStoreList()
        {
            Edge.SVA.BLL.BUY_STORE bll = new BUY_STORE();
            DataSet ds = bll.GetList("");
            viewModel.StoreTable = ds.Tables.Count > 0 ? ds.Tables[0] : null;
        }

        public ExecResult AddData()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.POSSTAFF bll = new SVA.BLL.POSSTAFF();
                Edge.SVA.BLL.STAFFSTOREMAP blllink = new STAFFSTOREMAP();
                List<Edge.SVA.Model.STAFFSTOREMAP> modellist = new List<SVA.Model.STAFFSTOREMAP>();
                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.StaffCode.ToString()) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.StaffCode.ToString());
                }
                if (rtn.Message == "")
                {
                    bll.Add(viewModel.MainTable);
                    Edge.SVA.Model.POSSTAFF staffmodel = bll.GetModel(viewModel.MainTable.StaffCode.ToString());

                    if (viewModel.StoreTable != null)
                    {
                        for (int i = 0; i < viewModel.StoreTable.Rows.Count; i++)
                        {
                            Edge.SVA.Model.STAFFSTOREMAP model = new SVA.Model.STAFFSTOREMAP();
                            DataRow dr = viewModel.StoreTable.Rows[i];
                            model.StaffID = staffmodel.StaffID;
                            model.StoreID = int.Parse(dr["StoreID"].ToString());
                            model.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                            model.CreatedOn = DateTime.Now;
                            model.UpdatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                            model.UpdatedOn = DateTime.Now;
                            modellist.Add(model);
                        }
                    }

                    blllink.Delete(viewModel.MainTable.StaffID);
                    foreach (var item in modellist)
                    {
                        blllink.Add(item);
                    }
                }
            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }

        public ExecResult UpdateData()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.POSSTAFF bll = new SVA.BLL.POSSTAFF();
                Edge.SVA.BLL.STAFFSTOREMAP blllink = new STAFFSTOREMAP();
                List<Edge.SVA.Model.STAFFSTOREMAP> modellist = new List<SVA.Model.STAFFSTOREMAP>();
                if (viewModel.StoreTable != null)
                {
                    for (int i = 0; i < viewModel.StoreTable.Rows.Count; i++)
                    {
                        Edge.SVA.Model.STAFFSTOREMAP model = new SVA.Model.STAFFSTOREMAP();
                        DataRow dr = viewModel.StoreTable.Rows[i];
                        model.StaffID = viewModel.MainTable.StaffID;
                        model.StoreID = int.Parse(dr["StoreID"].ToString());
                        model.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                        model.CreatedOn = DateTime.Now;
                        model.UpdatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                        model.UpdatedOn = DateTime.Now;
                        modellist.Add(model);
                    }
                }

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (rtn.Message == "")
                {
                    bll.Update(viewModel.MainTable);
                    blllink.Delete(viewModel.MainTable.StaffID);
                    foreach (var item in modellist)
                    {
                        blllink.Add(item);
                    }
                }
            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }

        public ExecResult DeleteData(int StaffID)
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                this.LoadViewModel(StaffID);
                Edge.SVA.BLL.POSSTAFF bll = new SVA.BLL.POSSTAFF();
                Edge.SVA.BLL.STAFFSTOREMAP blllink = new STAFFSTOREMAP();

                //保存
                bll.Delete(StaffID);
                blllink.Delete(viewModel.MainTable.StaffID);
            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }

        public void LoadStoreListByStaffID(int StaffID)
        {
            DataSet ds = new DataSet();
            DataSet dsSearch = new DataSet();
            STAFFSTOREMAP bll = new STAFFSTOREMAP();
            BUY_STORE bllstore = new BUY_STORE();
            if (StaffID!=0)
            {
                ds = bll.GetList("StaffID = " + StaffID + "");
                string strWhere = "";
                DataTable dt = ds.Tables.Count > 0 ? ds.Tables[0] : null;
                if (dt != null && dt.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sb.Append(dt.Rows[i]["StoreID"].ToString());
                        sb.Append(",");
                    }
                    strWhere = "StoreID in (" + sb.ToString().TrimEnd(',') + ")";
                    dsSearch = bllstore.GetList(strWhere);
                }
                viewModel.StoreTable = dsSearch.Tables.Count > 0 ? dsSearch.Tables[0] : null;
            }
        }
        #endregion

        public string ValidateForm()
        {
            return "";
        }

        public string ValidateObject(string strWhere)
        {
            Edge.SVA.BLL.POSSTAFF bll = new SVA.BLL.POSSTAFF();
            List<Edge.SVA.Model.POSSTAFF> list = bll.GetModelList("StaffCode = '" + strWhere + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }
    }
}