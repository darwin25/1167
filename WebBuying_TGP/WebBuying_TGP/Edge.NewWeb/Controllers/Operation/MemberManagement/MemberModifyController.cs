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
using System.Data;
using System.Data.SqlClient;

namespace Edge.Web.Controllers.Operation.MemberManagement
{
    public class MemberModifyController : MemberController
    {
        public void LoadViewModel(int memberID)
        {
            Edge.SVA.BLL.Member bll = new SVA.BLL.Member();
            Edge.SVA.Model.Member model = bll.GetModel(memberID);
            viewModel.MainObject = model;
            Edge.SVA.BLL.MemberAddress blladd = new SVA.BLL.MemberAddress();
            viewModel.SubTable = blladd.GetModelList("MemberID=" + model.MemberID).Count > 0 ? blladd.GetModelList("MemberID=" + model.MemberID)[0] : null;
            Edge.SVA.BLL.MemberMessageAccount bll1 = new SVA.BLL.MemberMessageAccount();
            List<Edge.SVA.Model.MemberMessageAccount> list= bll1.GetModelList("MemberID=" + model.MemberID);
            foreach (var item in list)
            {
                switch (item.MessageServiceTypeID)//4:msn,5:qq,7:facebook,8:sina
                {
                    case 4:
                        viewModel.MSNNumber = item.AccountNumber;
                        break;
                    case 5:
                        viewModel.QQNumber = item.AccountNumber;
                        break;
                    case 7:
                        viewModel.FacebookNumber = item.AccountNumber;
                        break;
                    case 8:
                        viewModel.SinaNumber = item.AccountNumber;
                        break;
                }
            }
        }

        public ExecResult Submit()
        {
            ExecResult rtn = ExecResult.CreateExecResult();
            Edge.SVA.BLL.MemberMessageAccount bll = new SVA.BLL.MemberMessageAccount();
            Edge.SVA.Model.MemberMessageAccount model = new MemberMessageAccount();

            Edge.SVA.BLL.MemberAddress blladd = new SVA.BLL.MemberAddress();
            Edge.SVA.Model.MemberAddress modeladd = new MemberAddress();

            int memberid = viewModel.MainObject.MemberID;
            string accountnumber = "";
            foreach (var item in viewModel.MemberMessageTypeIDList)
            {
                switch (item)//4:msn,5:qq,7:facebook,8:sina
                {
                    case 4:
                        accountnumber = viewModel.MSNNumber;
                        break;
                    case 5:
                        accountnumber = viewModel.QQNumber;
                        break;
                    case 7:
                        accountnumber = viewModel.FacebookNumber;
                        break;
                    case 8:
                        accountnumber = viewModel.SinaNumber;
                        break;
                }

                model.MemberID = memberid;
                model.MessageServiceTypeID = item;
                model.AccountNumber = accountnumber;
                model.Status = 1;

                if (IsExistsMemberAccount(memberid, item))
                {
                    model.MessageAccountID = viewModel.MessageAccountID;
                    bll.Update(model);
                }
                else
                {
                    bll.Add(model);
                }
            }

            //地址
            if (IsExistsMemberAddress(memberid))
            {
                blladd.Delete(viewModel.SubTable.AddressID);
            }
            modeladd.MemberID = memberid;
            modeladd.AddressCountry = viewModel.SubTable.AddressCountry;
            modeladd.AddressProvince = viewModel.SubTable.AddressProvince;
            modeladd.AddressCity = viewModel.SubTable.AddressCity;
            modeladd.AddressDistrict = viewModel.SubTable.AddressDistrict;
            modeladd.AddressDetail = viewModel.SubTable.AddressDetail;
            modeladd.AddressFullDetail = viewModel.SubTable.AddressFullDetail;
            blladd.Add(modeladd);
            return rtn;
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

        private bool IsExistsMemberAddress(int MemberID)
        {
            Edge.SVA.BLL.MemberAddress bll = new SVA.BLL.MemberAddress();
            string strwhere = " MemberID =" + MemberID;
            if (bll.GetModelList(strwhere).Count > 0)
            {
                viewModel.SubTable.AddressID = bll.GetModelList(strwhere)[0].AddressID;
                return true;
            }
            else
            {
                return false;
            }
        }

        public ExecResult Save()
        {
            ExecResult rtn = ExecResult.CreateExecResult();

            DBUtility.Transaction tr = new DBUtility.Transaction();
            tr.OpenConnSVAWithTrans();
            SqlTransaction trans = tr.Trans;

            //bool successful = false;
            try
            {
                //主表保存
                int memberid = viewModel.MainObject.MemberID;
                Edge.SVA.BLL.Domain.MemberManagement.Member bllmember = new SVA.BLL.Domain.MemberManagement.Member();
                bllmember.UpdateData(viewModel.MainObject, trans);

                if (viewModel.MemberMessageTypeIDList.Count > 0)
                {
                    //第一个子表的保存
                    Edge.SVA.BLL.Domain.MemberManagement.MemberMessageAccount bll = new SVA.BLL.Domain.MemberManagement.MemberMessageAccount();
                    Edge.SVA.Model.MemberMessageAccount model = new MemberMessageAccount();
                    string accountnumber = "";
                    foreach (var item in viewModel.MemberMessageTypeIDList)
                    {
                        switch (item)//4:msn,5:qq,7:facebook,8:sina
                        {
                            case 4:
                                accountnumber = viewModel.MSNNumber;
                                break;
                            case 5:
                                accountnumber = viewModel.QQNumber;
                                break;
                            case 7:
                                accountnumber = viewModel.FacebookNumber;
                                break;
                            case 8:
                                accountnumber = viewModel.SinaNumber;
                                break;
                        }

                        model.MemberID = memberid;
                        model.MessageServiceTypeID = item;
                        model.AccountNumber = accountnumber;
                        model.Status = 1;

                        if (bll.GetRecord(" MemberID =" + memberid + " and MessageServiceTypeID =" + item, trans) > 0)
                        {
                            bll.UpdateData(model, trans);
                        }
                        else
                        {
                            bll.AddData(model, trans);
                        }
                    }
                }
                if (viewModel.SubTable != null)
                {
                    //第二个子表的保存
                    Edge.SVA.BLL.Domain.MemberManagement.MemberAddress blladd = new SVA.BLL.Domain.MemberManagement.MemberAddress();
                    Edge.SVA.Model.MemberAddress modeladd = new MemberAddress();
                    modeladd.MemberID = memberid;
                    modeladd.AddressCountry = viewModel.SubTable.AddressCountry;
                    modeladd.AddressProvince = viewModel.SubTable.AddressProvince;
                    modeladd.AddressCity = viewModel.SubTable.AddressCity;
                    modeladd.AddressDistrict = viewModel.SubTable.AddressDistrict;
                    modeladd.AddressDetail = viewModel.SubTable.AddressDetail;
                    modeladd.AddressFullDetail = viewModel.SubTable.AddressFullDetail;
                    blladd.DeleteData(memberid, trans);
                    blladd.AddData(modeladd, trans);
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