using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.SQLServerDAL
{
    public partial class STK_STake02 : BaseDAL
    {
        protected override string TableName
        {
            get { return "STK_STake02"; }
        }

        protected override void Initialization()
        {
            base.Initialization();

            this.Order = "STK_STake02.StockTakeNumber";
        }
    }
}
