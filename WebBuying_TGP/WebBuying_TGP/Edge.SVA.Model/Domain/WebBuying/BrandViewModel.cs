using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
    public class BrandViewModel
    {
        BUY_BRAND mainTable = new BUY_BRAND();

        public BUY_BRAND MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
