using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.SQLServerDAL.Partial
{
    public partial class BUY_RPRICE_H : BaseDAL
    {
        protected override string TableName
        {
            get { return "BUY_RPRICE_H"; }
        }

        protected override void Initialization()
        {
            base.Initialization();

            this.Order = "BUY_RPRICE_H.RPriceCode";
        }
    }
}
