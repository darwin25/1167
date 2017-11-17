using System;
using System.Collections.Generic;
using System.Text;
using Edge.SVA.Model.Domain.SVA;
using Edge.SVA.Model.Domain.Surpport;
using Edge.SVA.Model.Domain.File.BasicViewModel;

namespace Edge.SVA.Model.Domain.File
{
    public class MessageTemplateViewModel
    {
        private MessageTemplate mainTable = new MessageTemplate();

        public MessageTemplate MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
        private List<MessageTemplateDetailViewModel> messageTemplateDetailList = new List<MessageTemplateDetailViewModel>();

        public List<MessageTemplateDetailViewModel> MessageTemplateDetailViewModelList
        {
            get { return messageTemplateDetailList; }
            set { messageTemplateDetailList = value; }
        }
        private List<int> deleteTemplateDetailIDList = new List<int>();

        public List<int> DeleteTemplateDetailIDList
        {
            get { return deleteTemplateDetailIDList; }
        }

        public List<BrandInfo> BrandInfoList { get; set; }
        public List<KeyValue> TransactionTypeList { get; set; }
        public List<KeyValue> MessageSerivceTypeList { get; set; }
    }
}
