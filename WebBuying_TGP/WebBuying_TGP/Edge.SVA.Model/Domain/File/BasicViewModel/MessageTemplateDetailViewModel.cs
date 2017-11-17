using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.File.BasicViewModel
{
    public class MessageTemplateDetailViewModel : MessageTemplateDetail
    {
        private string messageServiceTypeDesc = string.Empty;

        public string MessageServiceTypeDesc
        {
            get { return messageServiceTypeDesc; }
            set { messageServiceTypeDesc = value; }
        }
        private string statusDesc = string.Empty;

        public string StatusDesc
        {
            get { return statusDesc; }
            set { statusDesc = value; }
        }
        private string objectKey = Guid.NewGuid().ToString();

        public string ObjectKey
        {
            get { return objectKey; }
            set { objectKey = value; }
        }
    }
}
