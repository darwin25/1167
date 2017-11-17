using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.IDAL
{
    public partial interface IOrd_ImportCouponUID_H
    {
      
        bool ExistCouponUID(List<string> couponUIDS);
        bool ExistCouponUID(string beginUID, string endUID, bool isCheckdigit);
        bool Update(Model.Ord_ImportCouponUID_H model, int times);
        string ExportCSV(string importCouponNumber, int couponCount);

    }
}
