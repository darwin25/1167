using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using System.Data;
using System.Text;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BOXSALE
{
    public class BuyingBoxSaleController
    {
        protected BoxSaleViewModel viewModel = new BoxSaleViewModel();

        public BoxSaleViewModel ViewModel
        {
            get { return viewModel; }
        }

        public void LoadViewModel(int KeyID)//(string BomCode,string ProdCode)
        {
            Edge.SVA.BLL.BUY_BOXSALE bll = new Edge.SVA.BLL.BUY_BOXSALE();
            Edge.SVA.Model.BUY_BOXSALE model = bll.GetModel(KeyID);
            viewModel.MainTable = model;
        }

        public DataSet GetTransList(string strWhere, int startIndex, int endIndex, out int recodeCount, string filedOrder)
        {
            //获取总条数首句
            string sqlcount = "select count(*) from ";
            //获取分页数据首句
            string sqlquery = "select * from ";

            StringBuilder strSql = new StringBuilder();
            filedOrder = "BUY_BOXSALE.ProdCode";
            strSql.AppendFormat("(SELECT ROW_NUMBER() OVER(order by {0}) as Row,", filedOrder);
            strSql.Append("BUY_PRODUCT.ProdDesc1,BUY_PRODUCT.PackageSizeCode,BUY_BOXSALE.* from BUY_BOXSALE");
            strSql.Append(" join BUY_PRODUCT on BUY_BOXSALE.ProdCode=BUY_PRODUCT.ProdCode");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ) TT");

            //获取总条数
            object obj = DBUtility.DbHelperSQL.GetSingle(sqlcount + strSql.ToString());
            if (obj == null)
            {
                recodeCount = 0;
            }
            else
            {
                recodeCount = Convert.ToInt32(obj);
            }

            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            //获取分页数据
            DataSet ds = DBUtility.DbHelperSQL.Query(sqlquery + strSql.ToString());

            Tools.DataTool.AddBuyingProdDesc(ds, "ProdDesc", "ProdCode");
            return ds;
        }

        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            DataSet ds;
            Edge.SVA.BLL.BUY_BOXSALE bll = new Edge.SVA.BLL.BUY_BOXSALE();

            //获得总条数
            recodeCount = bll.GetRecordCount(strWhere);
            //获取排序字段
            string orderStr = "CreatedOn";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetList(pageSize, pageIndex, strWhere, orderStr);
            return ds;
        }

        public DataSet GetList(string strWhere)
        {
            Edge.SVA.BLL.BUY_BOXSALE bll = new Edge.SVA.BLL.BUY_BOXSALE();
            return bll.GetList(strWhere);
               
        }
        public ExecResult Add()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_BOXSALE bll = new Edge.SVA.BLL.BUY_BOXSALE();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTable.BOMCode, viewModel.MainTable.ProdCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTable.BOMCode, viewModel.MainTable.ProdCode);
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
                Edge.SVA.BLL.BUY_BOXSALE bll = new Edge.SVA.BLL.BUY_BOXSALE();

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

        public string ValidateObject(string BomCode, string ProdCode)
        {
            Edge.SVA.BLL.BUY_BOXSALE bll = new SVA.BLL.BUY_BOXSALE();
            List<Edge.SVA.Model.BUY_BOXSALE> list = bll.GetModelList("BOMCode='" + BomCode + "' and ProdCode = '" + ProdCode + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }

        public ExecResult Save(DateTime startdate,DateTime enddate,string BomCode)
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                string sql = @"update BUY_BOXSALE set StartDate='" + startdate + "',EndDate='" + enddate + "' where BOMCode='" + BomCode + "'";
                int row = DBUtility.DbHelperSQL.ExecuteSql(sql);
            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }

        public ExecResult Copy(string ToBomCode,string FromBomCode)
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                string delsql = @"delete BUY_BOXSALE where BOMCode='" + ToBomCode + "'";
                int row = DBUtility.DbHelperSQL.ExecuteSql(delsql);
                Edge.SVA.BLL.BUY_BOXSALE bll = new SVA.BLL.BUY_BOXSALE();
                List<Edge.SVA.Model.BUY_BOXSALE> modellist = bll.GetModelList("BOMCode='" + FromBomCode + "'");
                List<Edge.SVA.Model.BUY_BOXSALE> newmodellist = new List<SVA.Model.BUY_BOXSALE>();
                foreach (Edge.SVA.Model.BUY_BOXSALE model in modellist)
                {
                    model.BOMCode = ToBomCode;
                    newmodellist.Add(model);
                }
                foreach (Edge.SVA.Model.BUY_BOXSALE model in newmodellist)
                {
                    bll.Add(model);
                }
            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        } 
    }
}