using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.IDAL
{
    public partial interface IMember
    {
        List<int> GetMembers(string mobileNumber);
    }
}
