using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using System.Data;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.Text;
using Edge.Security;
using Edge.Web.Tools;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.BUY_PRODUCTCLASS
{
    public class BuyingProductClassController
    {
        protected ProductClassViewModel viewModel = new ProductClassViewModel();

        public ProductClassViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(int ProdClassID)
        {
            Edge.SVA.BLL.BUY_PRODUCTCLASS bll = new Edge.SVA.BLL.BUY_PRODUCTCLASS();
            Edge.SVA.Model.BUY_PRODUCTCLASS model = bll.GetModel(ProdClassID);
            viewModel.MainTable = model;
        }

        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.BUY_PRODUCTCLASS bll = new Edge.SVA.BLL.BUY_PRODUCTCLASS();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);

            //获取排序字段
            string orderStr = "ProdClassCode";
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
                Edge.SVA.BLL.BUY_PRODUCTCLASS bll = new SVA.BLL.BUY_PRODUCTCLASS();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.ProdClassCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.ProdClassCode);
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
                Edge.SVA.BLL.BUY_PRODUCTCLASS bll = new SVA.BLL.BUY_PRODUCTCLASS();

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
            Edge.SVA.BLL.BUY_PRODUCTCLASS bll = new SVA.BLL.BUY_PRODUCTCLASS();
            List<Edge.SVA.Model.BUY_PRODUCTCLASS> list = bll.GetModelList("ProdClassCode = '" + strWhere + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }

        public void BindProductSizeType(FineUI.DropDownList ddl)
        {
            Edge.SVA.BLL.BUY_PRODUCTSIZE bll = new SVA.BLL.BUY_PRODUCTSIZE();
            DataSet ds = bll.GetList("");
            ControlTool.BindDataSet(ddl, ds, "ProductSizeCode", "ProductSizeName1", "ProductSizeName2", "ProductSizeName3", "ProductSizeCode");
        }

        public DataSet GetTreeList(string strWhere,string lan)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ProdClassID,ParentID,ProductSizeType,");
            switch (lan.ToLower())
            {
                case "en-us":
                    strSql.Append("(ProdClassCode+'-'+ProdClassDesc1)");
                    break;
                case "zh-cn":
                    strSql.Append("(ProdClassCode+'-'+ProdClassDesc2)");
                    break;
                case "zh-hk":
                    strSql.Append("(ProdClassCode+'-'+ProdClassDesc3)");
                    break;
                default:
                    strSql.Append("(ProdClassCode+'-'+ProdClassDesc1)");
                    break;
            }
            strSql.Append(" as Description from BUY_PRODUCTCLASS");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            strSql.Append(" order by ParentID");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            DataTool.AddBuyingProdTypeSizeName(ds, "ProductSizeTypeName", "ProductSizeType");

            return ds;
        }

        public void DelTreeNode(int nodeid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete BUY_PRODUCTCLASS ");
            strSql.Append(" where ProdClassID=" + nodeid);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
    }
}