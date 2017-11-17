using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edge.SVA.BLL
{
    public partial class Sales_H : BaseBLL
    {
        protected override IDAL.IBaseDAL BaseDAL
        {
            get
            {
                return DALFactory.DataAccess.CreateSales_H() as IDAL.IBaseDAL;
            }
        }
    }
}
