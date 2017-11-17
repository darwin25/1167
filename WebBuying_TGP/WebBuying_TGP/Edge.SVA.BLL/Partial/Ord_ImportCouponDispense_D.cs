using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.BLL
{
    public partial class Ord_ImportCouponDispense_D:BaseBLL 
    {
        protected override IDAL.IBaseDAL BaseDAL
        {
            get { return DALFactory.DataAccess.CreateOrd_ImportCouponDispense_D() as IDAL.IBaseDAL; }
        }
        
    }
}
