using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edge.SVA.BLL
{
    public partial class BUY_RPRICE_H : BaseBLL
    {
        protected override IDAL.IBaseDAL BaseDAL
        {
            get { return DALFactory.DataAccess.CreateBUY_RPRICE_H() as IDAL.IBaseDAL; }
        }
    }
}
