using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.BLL
{
    public partial class Member
    {
        public List<int> GetMembers(string mobileNumber)
        {
            return dal.GetMembers(mobileNumber);
        }
    }
}
