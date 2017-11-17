using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Edge.SVA.Model.Domain.Operation.MemberManagement.MemberInformation
{
    public class MemberViewModel
    {
        private Member mainObject = new Member();

        public Member MainObject
        {
            get { return mainObject; }
            set { mainObject = value; }
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

        private int messageAccountID;

        public int MessageAccountID
        {
            get { return messageAccountID; }
            set { messageAccountID = value; }
        }

        private MemberAddress subTable = new MemberAddress();

        public MemberAddress SubTable
        {
            get { return subTable; }
            set { subTable = value; }
        }
    }
}
