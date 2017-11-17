using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebService.Response
{
    public class GetMemberTxnListResponse
    {
        private string _action;

        public string Action
        {
            get
            {
                return _action;
            }
            set
            {
                _action = value;
            }
        }

        private int _responseCode;

        public int ResponseCode
        {
            get
            {
                return _responseCode;
            }
            set
            {
                _responseCode = value;
            }
        }

        private int _pageCount;

        public int PageCount
        {
            get { return _pageCount; }
            set { _pageCount = value; }
        }

        private int _recordCount;

        public int RecordCount
        {
            get { return _recordCount; }
            set { _recordCount = value; }
        }

        private GetMemberTxn[] _memberTxn;

        public GetMemberTxn[] MemberTxn
        {
            get
            {
                return _memberTxn;
            }
            set
            {
                _memberTxn = value;
            }
        }
        private List<GetMemberTxn> list;

        public List<GetMemberTxn> List
        {
            get { return list; }
            set { list = value; }
        }
    }
}
