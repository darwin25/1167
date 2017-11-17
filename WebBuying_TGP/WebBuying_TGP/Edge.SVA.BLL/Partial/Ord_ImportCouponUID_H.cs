using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.BLL
{
    public partial class Ord_ImportCouponUID_H : BaseBLL
    {
        public bool ExistCouponUID(List<string> couponUIDS)
        {
            return dal.ExistCouponUID(couponUIDS);
        }

        public bool ExistCouponUID(string beginUID, string endUID, bool isCheckdigit)
        {
            return dal.ExistCouponUID(beginUID, endUID, isCheckdigit);
        }

        public bool Update(Model.Ord_ImportCouponUID_H model, int times)
        {
            return dal.Update(model, times);
        }

        public string ExportCSV(string importCouponNumber, int couponCount)
        {
            return dal.ExportCSV(importCouponNumber, couponCount);
        }

        protected override IDAL.IBaseDAL BaseDAL
        {
            get { return DALFactory.DataAccess.CreateOrd_ImportCouponUID_H() as IDAL.IBaseDAL; }
        }
    }

}
