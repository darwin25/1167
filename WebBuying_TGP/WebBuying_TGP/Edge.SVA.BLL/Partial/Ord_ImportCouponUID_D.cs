using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Edge.SVA.BLL
{
    public partial class Ord_ImportCouponUID_D
    {
        public bool FastAdd(Model.Ord_ImportCouponUID_D model,ref SqlConnection connection)
        {
            return dal.FastAdd(model,ref connection);
        }

        public DataSet GetListForTotal(int PageSize, int PageIndex, string strWhere, string filedOrder, string fields, int times)
        {
            return dal.GetListForTotal(PageSize, PageIndex, strWhere, filedOrder, fields, times);
        }

        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder, string fields, int times)
        {
            return dal.GetList(PageSize, PageIndex, strWhere, filedOrder, fields, times);
        }

        public int GetCount(string importCouponNumber, int times)
        {
            return dal.GetCount(importCouponNumber, times);
        }

        public decimal GetAllDenomination(string importCouponNumber)
        {
            return dal.GetAllDenomination(importCouponNumber);
        }
    }
}
