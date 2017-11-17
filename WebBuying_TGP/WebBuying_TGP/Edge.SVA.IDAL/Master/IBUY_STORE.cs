using System;
using System.Data;
namespace Edge.SVA.IDAL
{
	/// <summary>
	/// 接口层店铺表。
	/// </summary>
	public interface IBUY_STORE
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string StoreCode,int StoreID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Edge.SVA.Model.BUY_STORE model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Edge.SVA.Model.BUY_STORE model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int StoreID);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string StoreCode,int StoreID);
		bool DeleteList(string StoreIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Edge.SVA.Model.BUY_STORE GetModel(int StoreID);
        Edge.SVA.Model.BUY_STORE GetStoreByCode(string code);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		int GetRecordCount(string strWhere);
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
        int GetStoreIDByUser(string UserName);
		#endregion  成员方法
	} 
}
