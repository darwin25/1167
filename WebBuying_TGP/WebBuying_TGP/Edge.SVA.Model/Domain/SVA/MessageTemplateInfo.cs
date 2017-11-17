using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.SVA
{
    [Serializable]
    public class MessageTemplateInfo
    {
        public MessageTemplateInfo() { }
        public MessageTemplateInfo(string transactionTypeID, string messageServiceTypeID, string templateContent1, string templateContent2, string templateContent3)
        {
            TransactionTypeID = transactionTypeID;
            MessageServiceTypeID = messageServiceTypeID;
            TemplateContent1 = templateContent1;
            TemplateContent2 = templateContent2;
            TemplateContent3 = templateContent3;
        }
        public string TransactionTypeID { get; set; }
        public string MessageServiceTypeID { get; set; }
        public string TemplateContent1 { get; set; }
        public string TemplateContent2 { get; set; }
        public string TemplateContent3 { get; set; }
    }
}
