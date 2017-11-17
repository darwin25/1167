using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edge.SVA.BLL
{
    public partial class Ord_SalesPickOrder_H : BaseBLL
    {
        protected override IDAL.IBaseDAL BaseDAL
        {
            get { return DALFactory.DataAccess.CreateOrd_SalesPickOrder_H() as IDAL.IBaseDAL; }
        }
    }
}
