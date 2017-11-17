using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebService.Response
{
    public class GetSalesTByTxnNoResponse
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
        private List<GetSalesTByTxnNo> list;

        public List<GetSalesTByTxnNo> List
        {
            get { return list; }
            set { list = value; }
        }
    }
}
