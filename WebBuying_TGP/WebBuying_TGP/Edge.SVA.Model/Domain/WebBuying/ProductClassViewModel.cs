using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class ProductClassViewModel
    {
        BUY_PRODUCTCLASS mainTable = new BUY_PRODUCTCLASS();

        public BUY_PRODUCTCLASS MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
