using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class BarCodeViewModel
    {
        BUY_BARCODE mainTable = new BUY_BARCODE();

        public BUY_BARCODE MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
