using System;
using System.Data;
namespace Edge.SVA.IDAL
{
	/// <summary>
	/// 接口层货品表
	/// </summary>
	public interface IBUY_PRODUCT
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string ProdCode);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(Edge.SVA.Model.BUY_PRODUCT model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Edge.SVA.Model.BUY_PRODUCT model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string ProdCode);
		bool DeleteList(string ProdCodelist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Edge.SVA.Model.BUY_PRODUCT GetModel(string ProdCode);

		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
        DataSet GetListTwoTable(string strWhere, string orderby, int startIndex, int endIndex);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		int GetRecordCount(string strWhere);
        int GetRecordTwoTableCount(string strWhere);
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据条件查询列表
        /// 创建人：Lisa
        /// 创建时间：2016-03-28
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        DataSet GetListByParm(string strWhere, string filedOrder, string webSiteName);
		/// <summary>
		/// 根据分页获得库存数据列表
		/// </summary>
        int GetStockRecordCount(string strWhere);
        DataSet GetStockListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        DataSet GetSummary(string strWhere);
		#endregion  成员方法
	} 
}
