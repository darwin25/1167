using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.Operation
{
    /// <summary>
    /// 销售管理View操作类
    /// 创建人：Lisa
    /// 创建时间：2016-1-2
    /// </summary>
    public class Sales_HViewModel
    {
        Sales_H mainTable = new Sales_H();
        public Sales_H MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
