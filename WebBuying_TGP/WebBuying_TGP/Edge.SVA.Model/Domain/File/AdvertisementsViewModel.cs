using System;
using System.Collections.Generic;
using System.Text;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.SVA.Model.Domain.Surpport;
using Edge.SVA.Model.Domain.SVA;

namespace Edge.SVA.Model.Domain.File
{
    public class AdvertisementsViewModel
    {
        PromotionMsg mainTable = new PromotionMsg();

        public PromotionMsg MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }

        private List<BrandInfo> brandInfo = new List<BrandInfo>();

        public List<BrandInfo> BrandInfo
        {
            get { return brandInfo; }
            set { brandInfo = value; }
        }

        private List<int> cardGradeIDList = new List<int>();

        public List<int> CardGradeIDList
        {
            get { return cardGradeIDList; }
            set { cardGradeIDList = value; }
        }


        private List<KeyValue> parentIDList = new List<KeyValue>();

        public List<KeyValue> ParentIDList
        {
            get { return parentIDList; }
            set { parentIDList = value; }
        }

        private List<KeyValue> promotionMsgTypeList = new List<KeyValue>();

        public List<KeyValue> PromotionMsgTypeList
        {
            get { return promotionMsgTypeList; }
            set { promotionMsgTypeList = value; }
        }

    }
}
