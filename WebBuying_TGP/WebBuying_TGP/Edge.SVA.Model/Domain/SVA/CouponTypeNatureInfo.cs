using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.SVA
{
    public class CouponTypeNatureInfo : IKeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
        private List<CardTypeInfo> cardTypeInfos = new List<CardTypeInfo>();
        public List<CardTypeInfo> CardTypeInfos
        {
            get { return cardTypeInfos; }
        }

    }
}
