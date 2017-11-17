using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class FulfillmenthouseViewModel
    {
        BUY_FULFILLMENTHOUSE mainTable = new BUY_FULFILLMENTHOUSE();

        public BUY_FULFILLMENTHOUSE MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
