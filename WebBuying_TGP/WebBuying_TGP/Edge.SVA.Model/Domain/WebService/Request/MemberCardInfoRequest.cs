using System;
using System.Collections.Generic;
using System.Text;
using Edge.SVA.Model.Domain.WebService.Response;

namespace Edge.SVA.Model.Domain.WebService.Request
{
    public class MemberCardInfoRequest : WebServiceResponseBase
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

        private int _memberID;

        public int MemberID
        {
            get { return _memberID; }
            set { _memberID = value; }
        }

        private string _cardNumber;

        public string CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }

        private string _conditionStr;

        public string ConditionStr
        {
            get { return _conditionStr; }
            set { _conditionStr = value; }
        }

        private string _pageCurrent;

        public string PageCurrent
        {
            get { return _pageCurrent; }
            set { _pageCurrent = value; }
        }

        private string _pageSize;

        public string PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        private string _language;


        public string Language
        {
            get { return _language; }
            set { _language = value; }
        }
    }
}
