using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.SQLServerDAL
{
    public partial class Ord_SalesShipOrder_H : BaseDAL
    {
        protected override string TableName
        {
            get { return "Ord_SalesShipOrder_H"; }
        }

        protected override void Initialization()
        {
            base.Initialization();

            this.Order = "Ord_SalesShipOrder_H.SalesShipOrderNumber";
        }
    }
}
