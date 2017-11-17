using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebService.Response
{
    public class GetMemberTxn
    {
        private string _billContact;
        public string BillContact
        {
            get { return _billContact; }
            set { _billContact = value; }
        }

        private string _billContactPhone;
        public string BillContactPhone
        {
            get { return _billContactPhone; }
            set { _billContactPhone = value; }
        }
        private string _billAddress;

        public string BillAddress
        {
            get { return _billAddress; }
            set { _billAddress = value; }
        }

        private string _MemberEmail;

        public string MemberEmail
        {
            get { return _MemberEmail; }
            set { _MemberEmail = value; }
        }
        private string _txnNo;

        public string TxnNo
        {
            get { return _txnNo; }
            set { _txnNo = value; }
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
    }
}
