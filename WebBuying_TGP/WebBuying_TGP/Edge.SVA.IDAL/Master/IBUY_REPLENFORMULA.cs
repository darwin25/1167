using System;
using System.Data;
namespace Edge.SVA.IDAL
{
	/// <summary>
	/// 接口层自动补货公式信息表根据销售货品统计每天的销售平均数
    /// 创建人：lisa
    /// 创建时间：2016-07-13
	/// </summary>
	public interface IBUY_REPLENFORMULA
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string ReplenFormulaCode,int ReplenFormulaID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
        int Add(Edge.SVA.Model.BUY_REPLENFORMULA model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
        bool Update(Edge.SVA.Model.BUY_REPLENFORMULA model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int ReplenFormulaID);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string ReplenFormulaCode,int ReplenFormulaID);
		bool DeleteList(string ReplenFormulaIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        Edge.SVA.Model.BUY_REPLENFORMULA GetModel(int ReplenFormulaID);
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
