using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class DiscountViewModel
    {
        BUY_DISCOUNT mainTable = new BUY_DISCOUNT();

        public BUY_DISCOUNT MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
