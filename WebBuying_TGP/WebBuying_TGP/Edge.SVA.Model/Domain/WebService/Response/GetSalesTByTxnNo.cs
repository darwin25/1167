using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebService.Response
{
    public class GetSalesTByTxnNo
    {
        private int _keyID;

        public int KeyID
        {
            get { return _keyID; }
            set { _keyID = value; }
        }

        private string _txnNo;

        public string TxnNo
        {
            get { return _txnNo; }
            set { _txnNo = value; }
        }

        private int _seqNo;

        public int SeqNo
        {
            get { return _seqNo; }
            set { _seqNo = value; }
        }

        private int _tenderID;

        public int TenderID
        {
            get { return _tenderID; }
            set { _tenderID = value; }
        }

        private string _tenderCode;

        public string TenderCode
        {
            get { return _tenderCode; }
            set { _tenderCode = value; }
        }

        private string _tenderName;

        public string TenderName
        {
            get { return _tenderName; }
            set { _tenderName = value; }
        }

        private decimal _tenderAmount;

        public decimal TenderAmount
        {
            get { return _tenderAmount; }
            set { _tenderAmount = value; }
        }
        private decimal _localAmount;

        public decimal LocalAmount
        {
            get { return _localAmount; }
            set { _localAmount = value; }
        }
        private decimal _exchangeRate;

        public decimal ExchangeRate
        {
            get { return _exchangeRate; }
            set { _exchangeRate = value; }
        }

        private string _additional;

        public string Additional
        {
            get { return _additional; }
            set { _additional = value; }
        }
        private int _tenderType;

        public int TenderType
        {
            get { return _tenderType; }
            set { _tenderType = value; }
        }
    }
}
