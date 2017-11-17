using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.SQLServerDAL
{
    public partial class BUY_PO_H : BaseDAL
    {
        protected override string TableName
        {
            get { return "BUY_PO_H"; }
        }

        protected override void Initialization()
        {
            base.Initialization();

            this.Order = "BUY_PO_H.POCode";
        }
    }
}
