using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.SQLServerDAL
{
    public partial class Ord_CouponAdjust_H : BaseDAL
    {
        protected override string TableName
        {
            get { return "Ord_CouponAdjust_H"; }
        }

        protected override void Initialization()
        {
            base.Initialization();

            this.Order = "Ord_CouponAdjust_H.CouponAdjustNumber";
        }
    }
}
