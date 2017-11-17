using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class BoxSaleViewModel
    {
        BUY_BOXSALE mainTable = new BUY_BOXSALE();

        public BUY_BOXSALE MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
