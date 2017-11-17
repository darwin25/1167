using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.SVA
{
    public class BrandInfo : IKeyValue
    {
        public string Key{get;set;}
        public string Value{get;set;}
        private List<CardTypeInfo> cardTypeInfos = new List<CardTypeInfo>();
        public List<CardTypeInfo> CardTypeInfos
        {
            get { return cardTypeInfos; }
        }
        private List<CouponTypeNatureInfo> couponTypeNatureInfo = new List<CouponTypeNatureInfo>();

        public List<CouponTypeNatureInfo> CouponTypeNatureInfo
        {
            get { return couponTypeNatureInfo; }
        }
        private List<CouponTypeInfo> couponTypeInfos = new List<CouponTypeInfo>();

        public List<CouponTypeInfo> CouponTypeInfos
        {
            get { return couponTypeInfos; }
        }
        private List<StoreInfo> storeInfos = new List<StoreInfo>();

        public List<StoreInfo> StoreInfos
        {
            get { return storeInfos; }
        }
    }
}
