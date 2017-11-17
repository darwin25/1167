using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Edge.SVA.IDAL
{
    public partial interface  IOrd_ImportCouponUID_D
    {
        bool FastAdd(Model.Ord_ImportCouponUID_D model,ref SqlConnection connection);
        DataSet GetListForTotal(int PageSize, int PageIndex, string strWhere, string filedOrder, string fields, int times);
        DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder, string fields, int times);
        int GetCount(string importCouponNumber, int times);
        decimal GetAllDenomination(string importCouponNumber);
    }
}
