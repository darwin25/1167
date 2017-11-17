using System;
using System.Collections.Generic;
using System.Text;
using Edge.SVA.Model.Domain.WebService.Response;

namespace Edge.SVA.Model.Domain.WebService.Request
{
    public class GetMemberTxnListRequest : WebServiceResponseBase
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

        private string _TxnNo;

        public string TxnNo
        {
            get { return _TxnNo; }
            set { _TxnNo = value; }
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

        private string _storecode;
        public string Storecode
        {
            get { return _storecode; }
            set { _storecode = value; }
        }

        private DateTime? _startBusDate;

        public DateTime? StartBusDate
        {
            get { return _startBusDate; }
            set { _startBusDate = value; }
        }

        private DateTime? _endBusDate;

        public DateTime? EndBusDate
        {
            get { return _endBusDate; }
            set { _endBusDate = value; }
        }

        private decimal _minTotalAmount;

        public decimal MinTotalAmount
        {
            get { return _minTotalAmount; }
            set { _minTotalAmount = value; }
        }

        private decimal _maxTotalAmount;
        public decimal MaxTotalAmount
        {
            get { return _maxTotalAmount; }
            set { _maxTotalAmount = value; }
        }

        private int _salesType;

        public int SalesType
        {
            get { return _salesType; }
            set { _salesType = value; }
        }

        private string _txnStatus;

        public string TxnStatus
        {
            get { return _txnStatus; }
            set { _txnStatus = value; }
        }
        private string _rewardPoints;

        public string RewardPoints
        {
            get { return _rewardPoints; }
            set { _rewardPoints = value; }
        }
        private string _freight;

        public string Freight
        {
            get { return _freight; }
            set { _freight = value; }
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
    }
}
