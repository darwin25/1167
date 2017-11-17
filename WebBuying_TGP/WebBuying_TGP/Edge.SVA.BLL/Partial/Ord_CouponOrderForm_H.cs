using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.BLL
{
    public partial class Ord_CouponOrderForm_H : BaseBLL
    {
        protected override IDAL.IBaseDAL BaseDAL
        {
            get 
            {
                return DALFactory.DataAccess.CreateOrd_CouponOrderForm_H() as IDAL.IBaseDAL;
            }
        }
    }
}
