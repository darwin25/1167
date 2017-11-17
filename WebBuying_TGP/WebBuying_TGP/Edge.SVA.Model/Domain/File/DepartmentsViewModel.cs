using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.File
{
   public class DepartmentsViewModel
    {
        Department mainTable = new Department();

        public Department MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
