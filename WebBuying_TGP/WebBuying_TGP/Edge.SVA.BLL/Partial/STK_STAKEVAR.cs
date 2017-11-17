using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.BLL
{
    public partial class STK_STakeVAR : BaseBLL
    {
        protected override IDAL.IBaseDAL BaseDAL
        {
            get { return DALFactory.DataAccess.CreateSTK_STakeVAR() as IDAL.IBaseDAL; }
        }
    }
}
