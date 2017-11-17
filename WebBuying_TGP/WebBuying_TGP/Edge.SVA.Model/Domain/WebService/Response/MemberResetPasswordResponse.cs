using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebService.Response
{
    public class MemberResetPasswordResponse : WebServiceResponseBase
    {
        public string NewPassword { get; set; }
    }
}
