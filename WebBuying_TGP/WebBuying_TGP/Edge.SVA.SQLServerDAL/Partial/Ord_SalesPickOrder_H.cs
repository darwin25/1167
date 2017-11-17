using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.SQLServerDAL
{
    public partial class Ord_SalesPickOrder_H : BaseDAL
    {
        protected override string TableName
        {
            get { return "Ord_SalesPickOrder_H"; }
        }

        protected override void Initialization()
        {
            base.Initialization();

            this.Order = "Ord_SalesPickOrder_H.SalesPickOrderNumber";
        }
    }
}
