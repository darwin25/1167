using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.File
{
    public class ReasonViewModel
    {
        Reason mainTable = new Reason();

        public Reason MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
