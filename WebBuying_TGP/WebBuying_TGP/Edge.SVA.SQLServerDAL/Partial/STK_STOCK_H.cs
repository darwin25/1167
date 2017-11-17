using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.SQLServerDAL
{
    public partial class STK_STake_H : BaseDAL
    {
        protected override string TableName
        {
            get { return "STK_STake_H"; }
        }

        protected override void Initialization()
        {
            base.Initialization();

            this.Order = "STK_STake_H.StockTakeNumber";
        }
    }
}
