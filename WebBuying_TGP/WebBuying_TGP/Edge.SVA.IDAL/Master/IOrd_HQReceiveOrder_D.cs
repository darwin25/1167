using System;
using System.Data;
namespace Edge.SVA.IDAL
{
	/// <summary>
	/// 接口层卡订货单明细。 表中brandID
	/// </summary>
	public interface IOrd_HQReceiveOrder_D
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int KeyID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
        int Add(Edge.SVA.Model.Ord_HQReceiveOrder_D model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
        bool Update(Edge.SVA.Model.Ord_HQReceiveOrder_D model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int KeyID);
		/// <summary>
		/// 删除一条数据
		/// </summary>
        bool Delete(string HQReceiveOrderNumber);
		bool DeleteList(string KeyIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Edge.SVA.Model.Ord_HQReceiveOrder_D GetModel(int KeyID);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder);
        int GetRecordCount(string strWhere);
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        DataSet GetSummary(string strWhere);
        /// <summary>
        /// 获取总页数
        /// </summary>
        int GetCount(string strWhere);
		#endregion  成员方法
	} 
}
