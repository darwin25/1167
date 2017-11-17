using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using System.Data;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.SVA.BLL;
using System.Text;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_STOREGROUP
{
    public class BuyingStoreGroupController
    {
        protected StoreGroupViewModel viewModel = new StoreGroupViewModel();

        public StoreGroupViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(int StoreGroupID)
        {
            Edge.SVA.BLL.BUY_STOREGROUP bll = new Edge.SVA.BLL.BUY_STOREGROUP();
            Edge.SVA.Model.BUY_STOREGROUP model = bll.GetModel(StoreGroupID);
            viewModel.MainTable = model;
        }

        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.BUY_STOREGROUP bll = new Edge.SVA.BLL.BUY_STOREGROUP();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);

            //获取排序字段
            string orderStr = "StoreGroupCode";
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
                Edge.SVA.BLL.BUY_STOREGROUP bll = new SVA.BLL.BUY_STOREGROUP();

                //保存
                if (bll.Exists(viewModel.MainTable.StoreGroupID))
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
                Edge.SVA.BLL.BUY_STOREGROUP bll = new SVA.BLL.BUY_STOREGROUP();

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
                Edge.SVA.BLL.BUY_STOREGROUP bll = new SVA.BLL.BUY_STOREGROUP();
                Edge.SVA.BLL.BUY_SGLINK blllink = new BUY_SGLINK();
                List<Edge.SVA.Model.BUY_SGLINK> modellist = new List<SVA.Model.BUY_SGLINK>();
                if (viewModel.StoreTable != null)
                {
                    for (int i = 0; i < viewModel.StoreTable.Rows.Count; i++)
                    {
                        Edge.SVA.Model.BUY_SGLINK model = new SVA.Model.BUY_SGLINK();
                        DataRow dr = viewModel.StoreTable.Rows[i];
                        model.StoreGroupCode = viewModel.MainTable.StoreGroupCode;
                        model.StoreCode = dr["StoreCode"].ToString();
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
                if (ValidateObject(viewModel.MainTable.StoreGroupCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.StoreGroupCode);
                }
                if (rtn.Message == "")
                {
                    bll.Add(viewModel.MainTable);
                    blllink.Delete(viewModel.MainTable.StoreGroupCode);
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
                Edge.SVA.BLL.BUY_STOREGROUP bll = new SVA.BLL.BUY_STOREGROUP();
                Edge.SVA.BLL.BUY_SGLINK blllink = new BUY_SGLINK();
                List<Edge.SVA.Model.BUY_SGLINK> modellist = new List<SVA.Model.BUY_SGLINK>();
                if (viewModel.StoreTable != null)
                {
                    for (int i = 0; i < viewModel.StoreTable.Rows.Count; i++)
                    {
                        Edge.SVA.Model.BUY_SGLINK model = new SVA.Model.BUY_SGLINK();
                        DataRow dr = viewModel.StoreTable.Rows[i];
                        model.StoreGroupCode = viewModel.MainTable.StoreGroupCode;
                        model.StoreCode = dr["StoreCode"].ToString();
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
                    blllink.Delete(viewModel.MainTable.StoreGroupCode);
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

        public ExecResult DeleteData(int StoreGroupID)
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                this.LoadViewModel(StoreGroupID);
                Edge.SVA.BLL.BUY_STOREGROUP bll = new SVA.BLL.BUY_STOREGROUP();
                Edge.SVA.BLL.BUY_SGLINK blllink = new BUY_SGLINK();

                //保存
                bll.Delete(StoreGroupID);
                blllink.Delete(viewModel.MainTable.StoreGroupCode);
            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }

        public void LoadStoreListByGroupCode(string StoreGroupCode)
        {
            DataSet ds = new DataSet();
            DataSet dsSearch = new DataSet();
            BUY_SGLINK bll = new BUY_SGLINK();
            BUY_STORE bllstore = new BUY_STORE();
            if (!string.IsNullOrEmpty(StoreGroupCode))
            {
                ds = bll.GetList("StoreGroupCode = '" + StoreGroupCode + "'");
                string strWhere = "";
                DataTable dt = ds.Tables.Count > 0 ? ds.Tables[0] : null;
                if (dt != null && dt.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sb.Append("'");
                        sb.Append(dt.Rows[i]["StoreCode"].ToString());
                        sb.Append("',");
                    }
                    strWhere = "StoreCode in (" + sb.ToString().TrimEnd(',') + ")";
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
            Edge.SVA.BLL.BUY_STOREGROUP bll = new SVA.BLL.BUY_STOREGROUP();
            List<Edge.SVA.Model.BUY_STOREGROUP> list = bll.GetModelList("StoreGroupCode = '" + strWhere + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }

        public int GetStoreIDByUser(string UserName)
        {
            Edge.SVA.BLL.BUY_STORE bll = new SVA.BLL.BUY_STORE();

            return bll.GetStoreIDByUser(UserName);
        }
    }
}