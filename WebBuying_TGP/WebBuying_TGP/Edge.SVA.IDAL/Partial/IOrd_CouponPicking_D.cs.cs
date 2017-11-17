using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Edge.SVA.IDAL
{
    public partial interface IOrd_CouponPicking_D
    {
        DataSet GetListGroupByCouponType(string strWhere);
        Dictionary<int, int> GetCouponTypeIndex(string couponPickingNumber);
    }

  
}
