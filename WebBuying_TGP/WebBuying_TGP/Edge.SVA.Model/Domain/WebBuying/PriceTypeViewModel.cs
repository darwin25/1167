using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class PriceTypeViewModel
    {
        BUY_RPRICETYPE mainTable = new BUY_RPRICETYPE();

        public BUY_RPRICETYPE MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }

    }
}
