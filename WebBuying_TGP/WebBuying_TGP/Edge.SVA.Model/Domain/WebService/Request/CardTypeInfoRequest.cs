using System;
using System.Collections.Generic;
using System.Text;
using Edge.SVA.Model.Domain.WebService.Response;

namespace Edge.SVA.Model.Domain.WebService.Request
{
    public class CardTypeInfoRequest : WebServiceResponseBase
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

        private int _cardTypeID;

        public int CardTypeID
        {
            get { return _cardTypeID; }
            set { _cardTypeID = value; }
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
