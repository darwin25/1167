using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Edge.SVA.BLL
{
    public partial class Ord_CouponPicking_D : BaseBLL
    {
        protected override IDAL.IBaseDAL BaseDAL
        {
            get { return DALFactory.DataAccess.CreateOrd_CouponPicking_D() as IDAL.IBaseDAL; }
        }

        public DataSet GetListGroupByCouponType(string strWhere)
        {
            return dal.GetListGroupByCouponType(strWhere);
        }

        public Dictionary<int, int> GetCouponTypeIndex(string couponPickingNumber)
        {
            return dal.GetCouponTypeIndex(couponPickingNumber);
        }
    
    }
}
