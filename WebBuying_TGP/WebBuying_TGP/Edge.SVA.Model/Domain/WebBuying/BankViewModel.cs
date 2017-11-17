using System;
using System.Collections.Generic;
using System.Text;
using Edge.SVA.Model;

namespace Edge.SVA.Model.Domain.WebBuying
{
    public class BankViewModel
    {
        BUY_BANK mainTable = new BUY_BANK();

        public BUY_BANK MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
