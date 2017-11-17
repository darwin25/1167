using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Edge.SVA.IDAL
{
    /// <summary>
    /// 物流价格设置表。 按省份
    /// 创建人：Lisa
    /// 创建时间：2015-12-31
    public interface ILogisticsPrice
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int KeyID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Edge.SVA.Model.LogisticsPrice model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Edge.SVA.Model.LogisticsPrice model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int KeyID);
        bool DeleteList(string KeyIDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Edge.SVA.Model.LogisticsPrice GetModel(int KeyID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        int GetRecordCount(string strWhere);
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        #endregion  成员方法
    }
}
