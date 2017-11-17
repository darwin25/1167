using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class StoreViewModel
    {
        BUY_STORE mainTable = new BUY_STORE();

        public BUY_STORE MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
