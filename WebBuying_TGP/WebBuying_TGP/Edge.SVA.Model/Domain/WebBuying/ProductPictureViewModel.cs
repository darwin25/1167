using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class ProductPictureViewModel
    {
        BUY_PRODUCT_PIC mainTable = new BUY_PRODUCT_PIC();

        public BUY_PRODUCT_PIC MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }

        BUY_PRODUCT_PIC_Pending mainPending = new BUY_PRODUCT_PIC_Pending();
        public BUY_PRODUCT_PIC_Pending MainPending
        {
            get { return mainPending; }
            set { mainPending = value; }
        }
    }
}
