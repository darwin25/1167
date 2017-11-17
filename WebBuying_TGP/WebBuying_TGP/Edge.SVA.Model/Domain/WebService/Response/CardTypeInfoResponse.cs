using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebService.Response
{
    public class CardTypeInfoResponse
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

        private CardTypes[] _cardTypes;

        public CardTypes[] CardTypes
        {
            get
            {
                return _cardTypes;
            }
            set
            {
                _cardTypes = value;
            }
        }
    }
}
