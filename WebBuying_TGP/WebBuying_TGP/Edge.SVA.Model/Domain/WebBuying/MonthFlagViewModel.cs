using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class MonthFlagViewModel
    {
        BUY_MONTHFLAG mainTable = new BUY_MONTHFLAG();

        public BUY_MONTHFLAG MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }

    }
}
