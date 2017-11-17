using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class CurrencyViewModel
    {
        BUY_CURRENCY mainTable = new BUY_CURRENCY();

        public BUY_CURRENCY MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
