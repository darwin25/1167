using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edge.SVA.BLL
{
    public partial class LogisticsPrice : BaseBLL
    {
        protected override IDAL.IBaseDAL BaseDAL
        {
            get { return DALFactory.DataAccess.CreateLogisticsPrice() as IDAL.IBaseDAL; }
        }
    }
}
