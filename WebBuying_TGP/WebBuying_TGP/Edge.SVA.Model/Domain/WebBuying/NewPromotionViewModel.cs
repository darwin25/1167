using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Edge.SVA.Model.Domain.WebBuying.BasicViewModel;

namespace Edge.SVA.Model.Domain.WebBuying
{
    public class NewPromotionViewModel
    {
        Promotion_H mainTable = new Promotion_H();

        public Promotion_H MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }

        DataTable hitTable = new DataTable();

        public DataTable HitTable
        {
            get { return hitTable; }
            set { hitTable = value; }
        }

        DataTable giftTable = new DataTable();

        public DataTable GiftTable
        {
            get { return giftTable; }
            set { giftTable = value; }
        }

        private string dayCode;

        public string DayCode
        {
            get { return dayCode; }
            set { dayCode = value; }
        }

        private string monthCode;

        public string MonthCode
        {
            get { return monthCode; }
            set { monthCode = value; }
        }

        private string weekCode;

        public string WeekCode
        {
            get { return weekCode; }
            set { weekCode = value; }
        }

        private List<PromotionHitViewModel> promotionHitList = new List<PromotionHitViewModel>();

        public List<PromotionHitViewModel> PromotionHitList
        {
            get { return promotionHitList; }
            set { promotionHitList = value; }
        }

        DataTable hitPluTable = new DataTable();

        public DataTable HitPluTable
        {
            get { return hitPluTable; }
            set { hitPluTable = value; }
        }

        private List<PromotionGiftViewModel> promotionGiftList = new List<PromotionGiftViewModel>();

        public List<PromotionGiftViewModel> PromotionGiftList
        {
            get { return promotionGiftList; }
            set { promotionGiftList = value; }
        }

        DataTable giftPluTable = new DataTable();

        public DataTable GiftPluTable
        {
            get { return giftPluTable; }
            set { giftPluTable = value; }
        }

        private List<PromotionMemberViewModel> promotionMemberList = new List<PromotionMemberViewModel>();

        public List<PromotionMemberViewModel> PromotionMemberList
        {
            get { return promotionMemberList; }
            set { promotionMemberList = value; }
        }
    }
}
