using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class WeekFlagViewModel
    {
        BUY_WEEKFLAG mainTable = new BUY_WEEKFLAG();

        public BUY_WEEKFLAG MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }

    }
}
