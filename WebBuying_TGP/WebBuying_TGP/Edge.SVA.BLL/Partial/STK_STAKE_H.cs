﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.BLL
{
    public partial class STK_STake_H : BaseBLL
    {
        protected override IDAL.IBaseDAL BaseDAL
        {
            get { return DALFactory.DataAccess.CreateSTK_STake_H() as IDAL.IBaseDAL; }
        }
    }
}
