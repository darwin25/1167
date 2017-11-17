using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class ProductSizeViewModel
    {
        BUY_PRODUCTSIZE mainTable = new BUY_PRODUCTSIZE();

        public BUY_PRODUCTSIZE MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }

    }
}
