using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Edge.SVA.Model.Domain.Operation.MemberManagement.OtherInformation.ResetMemberLoginPassword
{
    public class ResetMemberLoginPasswordViewModel
    {
        private DataTable mainTable;

        public DataTable MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }

        private string cardNumber;

        public string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }

        private int cardTypeID;

        public int CardTypeID
        {
            get { return cardTypeID; }
            set { cardTypeID = value; }
        }

        private int cardGradeID;

        public int CardGradeID
        {
            get { return cardGradeID; }
            set { cardGradeID = value; }
        }

        private string memberRegisterMobile;

        public string MemberRegisterMobile
        {
          get { return memberRegisterMobile; }
          set { memberRegisterMobile = value; }
        }


        private string countryCode;

        public string CountryCode
        {
            get { return countryCode; }
            set { countryCode = value; }
        }

        private List<int> memberMessageTypeIDList = new List<int>();

        public List<int> MemberMessageTypeIDList
        {
            get { return memberMessageTypeIDList; }
            set { memberMessageTypeIDList = value; }
        }

        private string facebookNumber;

        public string FacebookNumber
        {
            get { return facebookNumber; }
            set { facebookNumber = value; }
        }
        private string qQNumber;

        public string QQNumber
        {
            get { return qQNumber; }
            set { qQNumber = value; }
        }
        private string mSNNumber;

        public string MSNNumber
        {
            get { return mSNNumber; }
            set { mSNNumber = value; }
        }
        private string sinaNumber;

        public string SinaNumber
        {
            get { return sinaNumber; }
            set { sinaNumber = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        private string aPP;

        public string APP
        {
            get { return aPP; }
            set { aPP = value; }
        }
    }
}
