using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
    public class ReplenformulaViewModel
    {
        BUY_REPLENFORMULA mainTable = new BUY_REPLENFORMULA();

        public BUY_REPLENFORMULA MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
