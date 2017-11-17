using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.SQLServerDAL
{
    public partial class Ord_CouponPicking_H : BaseDAL
    {
        protected override string TableName
        {
            get { return "Ord_CouponPicking_H"; }
        }

        protected override void Initialization()
        {
            base.Initialization();

            this.Order = "Ord_CouponPicking_H.CouponPickingNumber";
        }
    }
}
