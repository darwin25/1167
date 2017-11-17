using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Edge.SVA.Model.Domain.WebBuying
{
    public class IMP_PRODUCTViewModel
    {
        IMP_PRODUCT mainTable = new IMP_PRODUCT();

        public IMP_PRODUCT MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
        DataTable _dtSUPPROD = new DataTable();

        public DataTable dtSUPPROD
        {
            get { return _dtSUPPROD; }
            set { _dtSUPPROD = value; }
        }
    }
}
