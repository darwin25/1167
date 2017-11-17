using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.Surpport;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain;
using Edge.SVA.Model;
using Edge.SVA.BLL.Domain.DataResources;
using System.Text;
using System.Data.SqlClient;

namespace Edge.Web.Controllers.Operation.MemberManagement
{
    public class MemberDeleteController : MemberController
    {
        public void DeleteModel(int memberID)
        {
            Edge.SVA.BLL.Member bll = new SVA.BLL.Member();
            Edge.SVA.Model.Member model = bll.GetModel(memberID);
            Edge.SVA.BLL.MemberMessageAccount bll1 = new SVA.BLL.MemberMessageAccount();
            List<Edge.SVA.Model.MemberMessageAccount> list = bll1.GetModelList("MemberID=" + model.MemberID);
            foreach (var item in list)
            {
                if (item.MessageServiceTypeID == 4 || item.MessageServiceTypeID == 5 || item.MessageServiceTypeID == 7 || item.MessageServiceTypeID == 8)
                {
                    if (IsExistsMemberAccount(memberID, item.MessageServiceTypeID))
                    {
                        item.MessageAccountID = viewModel.MessageAccountID;
                        bll1.Delete(item.MessageAccountID);
                    }
                }
            }
        }

        private bool IsExistsMemberAccount(int MemberID, int MessageServiceTypeID)
        {
            Edge.SVA.BLL.MemberMessageAccount bll = new SVA.BLL.MemberMessageAccount();
            string strwhere = " MemberID =" + MemberID + " and MessageServiceTypeID =" + MessageServiceTypeID;
            if (bll.GetModelList(strwhere).Count > 0)
            {
                viewModel.MessageAccountID = bll.GetModelList(strwhere)[0].MessageAccountID;
                return true;
            }
            else
            {
                return false;
            }
        }

        public ExecResult DeleteData(List<int> MemberIDList)
        {
            ExecResult rtn = ExecResult.CreateExecResult();   

            DBUtility.Transaction tr = new DBUtility.Transaction();
            tr.OpenConnSVAWithTrans();
            SqlTransaction trans = tr.Trans;

            try
            {
                foreach (int MemberID in MemberIDList)
                {
                    //主表删除
                    Edge.SVA.BLL.Domain.MemberManagement.Member bll = new SVA.BLL.Domain.MemberManagement.Member();
                    bll.DeleteData(MemberID, trans);

                    //第一个子表的删除
                    Edge.SVA.BLL.Domain.MemberManagement.MemberMessageAccount bllme = new SVA.BLL.Domain.MemberManagement.MemberMessageAccount();
                    if (bllme.GetRecord("MemberID = " + MemberID, trans) > 0)
                    {
                        bllme.DeleteData(MemberID, trans);
                    }

                    //第二个子表的删除
                    Edge.SVA.BLL.Domain.MemberManagement.MemberAddress blladd = new SVA.BLL.Domain.MemberManagement.MemberAddress();
                    Edge.SVA.Model.MemberAddress modeladd = new MemberAddress();
                    blladd.DeleteData(MemberID, trans);
                }
                trans.Commit();
            }
            catch(Exception ex)
            {
                rtn.Ex = ex;
                trans.Rollback();
            }
            finally
            {
                tr.CloseConn();
            }
            return rtn;
        }
    }
}