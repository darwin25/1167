﻿using System;
using System.Data;
namespace Edge.SVA.IDAL
{
    /// <summary>
    /// 接口层卡订货单
    /// </summary>
    public interface IOrd_TransOutOrder_H
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string TransOutOrderNumber);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(Edge.SVA.Model.Ord_TransOutOrder_H model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Edge.SVA.Model.Ord_TransOutOrder_H model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string TransOutOrderNumber);
        bool DeleteList(string TransOutOrderNumber);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Edge.SVA.Model.Ord_TransOutOrder_H GetModel(string TransOutOrderNumber);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder);
        int GetRecordCount(string strWhere);
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 获取总页数
        /// </summary>
        int GetCount(string strWhere);
        /// <summary>
        /// 根据条件查询列表
        /// 创建人：王丽
        /// 创建时间：2016-03-28
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        DataSet GetListByParm(string strWhere, string filedOrder, string webSiteName);
        #endregion  成员方法
    }
}
