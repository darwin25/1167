using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class ProductStyleViewModel
    {
        BUY_PRODUCTSTYLE mainTable = new BUY_PRODUCTSTYLE();

        public BUY_PRODUCTSTYLE MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
