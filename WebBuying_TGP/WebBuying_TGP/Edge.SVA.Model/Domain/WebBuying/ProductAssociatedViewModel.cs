using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class ProductAssociatedViewModel
    {
        BUY_ProductAssociated mainTable = new BUY_ProductAssociated();

        public BUY_ProductAssociated MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
