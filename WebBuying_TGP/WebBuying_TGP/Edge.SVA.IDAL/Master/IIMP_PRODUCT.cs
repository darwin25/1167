using System;
using System.Data;
namespace Edge.SVA.IDAL
{
	/// <summary>
	/// 接口层读入的product
    /// 创建人：lisa
    /// 创建时间：2016-07-08
	/// </summary>
	public interface IIMP_PRODUCT
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string INTERNAL_PRODUCT_CODE);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(Edge.SVA.Model.IMP_PRODUCT model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Edge.SVA.Model.IMP_PRODUCT model);
        bool UpdateTemp(Edge.SVA.Model.IMP_PRODUCT model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string INTERNAL_PRODUCT_CODE);
		bool DeleteList(string INTERNAL_PRODUCT_CODElist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Edge.SVA.Model.IMP_PRODUCT GetModel(string INTERNAL_PRODUCT_CODE);
		Edge.SVA.Model.IMP_PRODUCT DataRowToModel(DataRow row);
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
