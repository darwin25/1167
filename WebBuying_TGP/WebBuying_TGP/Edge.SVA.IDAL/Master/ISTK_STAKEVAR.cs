using System;
using System.Data;
namespace Edge.SVA.IDAL
{
	/// <summary>
	/// 接口层货币支付表
	/// </summary>
    public interface ISTK_STakeVAR
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string StockTakeNumber,int StoreID,string ProdCode, string SerialNo);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Edge.SVA.Model.STK_STAKEVAR model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Edge.SVA.Model.STK_STAKEVAR model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
        bool Delete(string StockTakeNumber, int StoreID, string ProdCode, string StoreType, string SerialNo);
		/// <summary>
		/// 删除一条数据
		/// </summary>
        bool Delete(string StockTakeNumber);
		bool DeleteList(string StockTakeNumber);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        Edge.SVA.Model.STK_STAKEVAR GetModel(string StockTakeNumber, int StoreID, string ProdCode, string StoreType, string SerialNo);
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
		#endregion  成员方法
	} 
}
