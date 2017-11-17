using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.BLL
{
    public partial class BUY_PO_H : BaseBLL
    {
        protected override IDAL.IBaseDAL BaseDAL
        {
            get { return DALFactory.DataAccess.CreateBUY_PO_H() as IDAL.IBaseDAL; }
        }
    }
}
