using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebService.Request
{
    public class MemberResetPasswordRequest:WebServiceRequestBase
    {
        public string UserID { get; set; }
        public string MemberRegistID { get; set; }
    }
}
