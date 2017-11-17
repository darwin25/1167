using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.IDAL
{
    public partial interface  IOrd_CardBatchCreate
    {
        string ExportCSV(int batchID,int cardCount);
    }
}
