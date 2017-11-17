using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.BLL
{
     public partial class  Ord_CouponDelivery_D:BaseBLL
    {
        protected override IDAL.IBaseDAL BaseDAL
        {
            get { return DALFactory.DataAccess.CreateOrd_CouponDelivery_D() as IDAL.IBaseDAL; }
        }

        public Dictionary<int, int> GetCouponTypeIndex(string couponDeliveryNumber)
        {
            return dal.GetCouponTypeIndex(couponDeliveryNumber); 
        }
    }
}
