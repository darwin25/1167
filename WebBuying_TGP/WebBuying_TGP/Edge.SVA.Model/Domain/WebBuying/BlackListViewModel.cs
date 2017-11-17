using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
   public class BlackListViewModel
    {
        BUY_BLACKLIST mainTable = new BUY_BLACKLIST();

        public BUY_BLACKLIST MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
