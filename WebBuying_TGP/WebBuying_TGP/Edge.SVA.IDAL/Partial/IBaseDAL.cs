using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Edge.SVA.IDAL
{
    public interface IBaseDAL
    {
        string Order { get; set; }
        string Fields { get; set; }
        int Timeout { get; set; }
        bool Ascending { get; set; }
        string StrWhere { get; set; }
        DataSet GetList(int pageSize, int pageIndex);
        DataSet GetList(int pageSize, int pageIndex, out int recordCount);

    }
}
