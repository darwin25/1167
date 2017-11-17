using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.SVA.Model.Domain.Operation.MemberManagement.MemberInformation;
using System.Data;

namespace Edge.Web.Controllers.Operation.MemberManagement
{
    public class MemberController
    {
        protected MemberViewModel viewModel = new MemberViewModel();

        public MemberViewModel ViewModel
        {
            get { return viewModel; }
        }

        public DataSet GetTransactionList(string strWhere, int pageSize, int pageIndex, out int recodeCount, string sortFieldStr)
        {
            Edge.SVA.BLL.Member bll = new Edge.SVA.BLL.Member();

            DataSet ds = new DataSet();

            //获得总条数
            recodeCount = bll.GetCount(strWhere);
            //获取排序字段
            string orderStr = "MemberID";
            if (!string.IsNullOrEmpty(sortFieldStr))
            {
                orderStr = sortFieldStr;
            }

            ds = bll.GetList(pageSize, pageIndex, strWhere, orderStr);

            return ds;
        } 
    }
}