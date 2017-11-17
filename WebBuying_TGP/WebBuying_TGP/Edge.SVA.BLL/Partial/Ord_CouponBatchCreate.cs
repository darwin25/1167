using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.BLL
{
    public partial class Ord_CouponBatchCreate : BaseBLL
    {
        public string ExportCSV(Edge.SVA.Model.Ord_CouponBatchCreate model)
        {
            return dal.ExportCSV(model);
        }

        protected override IDAL.IBaseDAL BaseDAL
        {
            get { return DALFactory.DataAccess.CreateOrd_CouponBatchCreate() as IDAL.IBaseDAL; }
        }
    }
}
