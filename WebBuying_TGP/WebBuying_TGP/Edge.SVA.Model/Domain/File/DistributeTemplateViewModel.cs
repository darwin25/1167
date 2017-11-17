using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.File
{
    public class DistributeTemplateViewModel
    {
        DistributeTemplate mainTable = new DistributeTemplate();

        public DistributeTemplate MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
