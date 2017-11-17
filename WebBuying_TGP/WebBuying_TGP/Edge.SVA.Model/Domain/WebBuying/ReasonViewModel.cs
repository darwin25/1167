using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class ReasonViewModel
    {
        BUY_REASON mainTable = new BUY_REASON();

        public BUY_REASON MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
