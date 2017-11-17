using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edge.SVA.BLL.Partial
{
    public partial class LogisticsProvider : BaseBLL
    {
        protected override IDAL.IBaseDAL BaseDAL
        {
            get { return DALFactory.DataAccess.CreateLogisticsProvider() as IDAL.IBaseDAL; }
        }
    }
}
