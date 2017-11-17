using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.File
{
    public class USEFULEXPRESSIONSViewModel
    {
        USEFULEXPRESSIONS mainTable = new USEFULEXPRESSIONS();

        public USEFULEXPRESSIONS MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
