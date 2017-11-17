using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class StockTypeViewModel
    {
        BUY_STOCKTYPE mainTable = new BUY_STOCKTYPE();

        public BUY_STOCKTYPE MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
