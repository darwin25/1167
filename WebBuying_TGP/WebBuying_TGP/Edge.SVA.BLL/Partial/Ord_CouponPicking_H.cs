using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.BLL
{
    public partial class Ord_CouponPicking_H : BaseBLL
    {
        protected override IDAL.IBaseDAL BaseDAL
        {
            get { return DALFactory.DataAccess.CreateOrd_CouponPicking_H() as IDAL.IBaseDAL; }
        }

        public Edge.SVA.Model.Ord_CouponPicking_H GetModelByOrderNumber(string orderNumber)
        {
            List<SVA.Model.Ord_CouponPicking_H> models = this.GetModelList(string.Format("ReferenceNo = '{0}'", orderNumber));
            if (models == null || models.Count <= 0) return null;
            return models[0];
        }
    }
}
