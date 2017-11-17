using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Edge.SVA.Model.Domain.WebBuying.BasicViewModel
{
    public class PromotionGiftViewModel : Promotion_Gift
    {
        private string oprFlag;

        public string OprFlag
        {
            get { return oprFlag; }
            set { oprFlag = value; }
        }

        DataTable giftPluTable = new DataTable();

        public DataTable GiftPluTable
        {
            get { return giftPluTable; }
            set { giftPluTable = value; }
        }

        private string logicalOprName;

        public string LogicalOprName
        {
            get { return logicalOprName; }
            set { logicalOprName = value; }
        }

        private string giftTypeName;

        public string GiftTypeName
        {
            get { return giftTypeName; }
            set { giftTypeName = value; }
        }

        private string discountOnName;

        public string DiscountOnName
        {
            get { return discountOnName; }
            set { discountOnName = value; }
        }

        private string discountTypeName;

        public string DiscountTypeName
        {
            get { return discountTypeName; }
            set { discountTypeName = value; }
        }

        private string giftItemName;

        public string GiftItemName
        {
            get { return giftItemName; }
            set { giftItemName = value; }
        }
    }
}
