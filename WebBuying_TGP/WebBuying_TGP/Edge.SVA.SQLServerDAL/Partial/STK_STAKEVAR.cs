using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.SQLServerDAL
{
    public partial class STK_STakeVAR : BaseDAL
    {
        protected override string TableName
        {
            get { return "STK_STakeVAR"; }
        }

        protected override void Initialization()
        {
            base.Initialization();

            this.Order = "STK_STakeVAR.StockTakeNumber";
        }
    }
}
