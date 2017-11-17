using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.WebBuying;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT
{
    /// <summary>
    /// Bauhaus 产品
    /// 创建人:Lisa
    /// 创建时间：2016-02-26
    /// </summary>
    public class BUY_PRODUCT_ADD_BAU_PedingController
    {
        protected BauhausProductViewModel viewModel = new BauhausProductViewModel();

        public BauhausProductViewModel ViewModel
        {
            get { return viewModel; }
        }
        public void LoadViewModel(string ProdCode)
        {
            Edge.SVA.BLL.BUY_PRODUCT_ADD_BAU_Pending bll = new Edge.SVA.BLL.BUY_PRODUCT_ADD_BAU_Pending();
            Edge.SVA.Model.BUY_PRODUCT_ADD_BAU_Pending model = bll.GetModel(ProdCode);
            viewModel.MainTablePeding = model;

            Edge.SVA.BLL.BUY_SUPPROD bllSUPPROD = new SVA.BLL.BUY_SUPPROD();
            viewModel.dtSUPPROD = bllSUPPROD.GetList("ProdCode='" + ProdCode + "'").Tables[0];

        }
        public string ValidateForm()
        {
            return "";
        }
        public string ValidateObject(string strWhere)
        {
            Edge.SVA.BLL.BUY_PRODUCT_ADD_BAU_Pending bll = new SVA.BLL.BUY_PRODUCT_ADD_BAU_Pending();
            List<Edge.SVA.Model.BUY_PRODUCT_ADD_BAU_Pending> list = bll.GetModelList("ProdCode = '" + strWhere + "'");
            if (list.Count > 0)
            {
                return Resources.MessageTips.ExistRecord;
            }
            return "";
        }
        public ExecResult Add()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_PRODUCT_ADD_BAU_Pending bll = new SVA.BLL.BUY_PRODUCT_ADD_BAU_Pending();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (ValidateObject(viewModel.MainTablePeding.ProdCode) != "")
                {
                    rtn.Message = ValidateObject(viewModel.MainTablePeding.ProdCode);
                }
                if (rtn.Message == "")
                {
                    bll.Add(viewModel.MainTablePeding);
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
                Edge.SVA.BLL.BUY_PRODUCT_ADD_BAU_Pending bll = new Edge.SVA.BLL.BUY_PRODUCT_ADD_BAU_Pending();

                //保存
                if (ValidateForm() != "")
                {
                    rtn.Message = ValidateForm();
                }
                if (rtn.Message == "")
                {
                    bll.Update(viewModel.MainTablePeding);
                }

            }
            catch (System.Exception ex)
            {
                rtn.Ex = ex;
            }
            return rtn;
        }
        public ExecResult Delete(string ProdCode)
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            try
            {
                Edge.SVA.BLL.BUY_PRODUCT_Pending bll = new Edge.SVA.BLL.BUY_PRODUCT_Pending();
                Edge.SVA.BLL.BUY_BARCODE bllbar = new SVA.BLL.BUY_BARCODE();
                Edge.SVA.BLL.BUY_RPRICE_M bllrp = new SVA.BLL.BUY_RPRICE_M();
                Edge.SVA.BLL.BUY_CPRICE_M bllcp = new SVA.BLL.BUY_CPRICE_M();
                Edge.SVA.BLL.BUY_PRODUCT_ADD_BAU bllbau = new SVA.BLL.BUY_PRODUCT_ADD_BAU();
                Edge.SVA.BLL.BUY_PRODUCT_CLASSIFY_Pending bllfy = new SVA.BLL.BUY_PRODUCT_CLASSIFY_Pending();
                if (rtn.Message == "")
                {
                    bllbar.DeleteData(ProdCode);
                    bllcp.Delete(ProdCode);
                    bllrp.Delete(ProdCode);
                    bll.Delete(ProdCode);
                    bllbau.Delete(ProdCode);
                    bllfy.Delete(ProdCode);
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