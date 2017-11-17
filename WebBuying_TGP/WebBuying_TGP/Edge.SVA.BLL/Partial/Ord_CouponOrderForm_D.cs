using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.BLL
{
    public partial class Ord_CouponOrderForm_D : BaseBLL
    {
        protected override IDAL.IBaseDAL BaseDAL
        {
            get { return DALFactory.DataAccess.CreateOrd_CouponOrderForm_D() as IDAL.IBaseDAL; }
        }

        public bool DeleteByOrder(string couponOrderFormNumber)
        {
            return dal.DeleteByOrder(couponOrderFormNumber);
        }
   
    }
}
