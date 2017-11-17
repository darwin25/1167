using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.IDAL
{
    public partial interface IOrd_ImportCouponDispense_H
    {
        List<string> GetCardNumbers(List<int> cardTypes, List<int> members);
        string ExportCSV(Edge.SVA.Model.Ord_ImportCouponDispense_H model);
    }
}
