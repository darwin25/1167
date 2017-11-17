using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.BLL
{
    public partial class Ord_HQReceiveOrder_H : BaseBLL
    {
        protected override IDAL.IBaseDAL BaseDAL
        {
            get { return DALFactory.DataAccess.CreateOrd_HQReceiveOrder_H() as IDAL.IBaseDAL; }
        }
    }
}
