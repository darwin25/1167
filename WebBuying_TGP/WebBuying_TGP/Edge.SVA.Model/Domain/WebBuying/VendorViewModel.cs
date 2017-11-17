using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class VendorViewModel
    {
        BUY_VENDOR mainTable = new BUY_VENDOR();

        public BUY_VENDOR MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
