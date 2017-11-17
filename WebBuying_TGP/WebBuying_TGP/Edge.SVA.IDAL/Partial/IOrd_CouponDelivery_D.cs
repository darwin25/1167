using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.IDAL
{
    public partial interface IOrd_CouponDelivery_D
    {
        Dictionary<int, int> GetCouponTypeIndex(string couponDeliveryNumber);
    }
}
