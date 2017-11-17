using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.WebBuying
{
    public class ColorViewModel
    {
        BUY_COLOR mainTable = new BUY_COLOR();

        public BUY_COLOR MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
