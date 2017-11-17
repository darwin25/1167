using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class DayFlagViewModel
    {
        BUY_DAYFLAG mainTable = new BUY_DAYFLAG();

        public BUY_DAYFLAG MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }

    }
}
