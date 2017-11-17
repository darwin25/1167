using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edge.SVA.BLL
{
    public partial class SalesShipOrderNumber : BaseBLL
    {
        protected override IDAL.IBaseDAL BaseDAL
        {
            get { return DALFactory.DataAccess.CreateOrd_SalesShipOrder_H() as IDAL.IBaseDAL; }
        }
    }
}
