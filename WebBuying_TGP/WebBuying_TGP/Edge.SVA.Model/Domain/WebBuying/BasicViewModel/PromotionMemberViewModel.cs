using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying.BasicViewModel
{
    public class PromotionMemberViewModel : Promotion_Member
    {
        private string objectKey = Guid.NewGuid().ToString();

        public string ObjectKey
        {
            get { return objectKey; }
            set { objectKey = value; }
        }
        private int _keyid;
        /// <summary>
        /// 自增长主键
        /// </summary>
        public int KeyID
        {
            set { _keyid = value; }
            get { return _keyid; }
        }
        private string oprFlag;

        public string OprFlag
        {
            get { return oprFlag; }
            set { oprFlag = value; }
        }

        private string loyaltyCardTypeName;

        public string LoyaltyCardTypeName
        {
            get { return loyaltyCardTypeName; }
            set { loyaltyCardTypeName = value; }
        }

        private string loyaltyCardGradeName;

        public string LoyaltyCardGradeName
        {
            get { return loyaltyCardGradeName; }
            set { loyaltyCardGradeName = value; }
        }

        private string loyaltyBirthdayFlagName;

        public string LoyaltyBirthdayFlagName
        {
            get { return loyaltyBirthdayFlagName; }
            set { loyaltyBirthdayFlagName = value; }
        }
    }
}
