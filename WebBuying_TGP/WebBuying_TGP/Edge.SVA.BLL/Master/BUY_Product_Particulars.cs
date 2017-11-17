using System;
using System.Data;
using System.Collections.Generic;
using Edge.Common;
using Edge.SVA.Model;
using Edge.SVA.DALFactory;
using Edge.IDAL;
namespace Edge.SVA.BLL
{
	/// <summary>
	/// 货品细节描述。（分语
    /// 创建人:Lisa
    /// 创建时间：2016-02-25
	/// </summary>
	public partial class BUY_Product_Particulars
	{
		private readonly IBUY_Product_Particulars dal=DataAccess.CreateBUY_Product_Particulars();
		public BUY_Product_Particulars()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ProdCode,int LanguageID)
		{
			return dal.Exists(ProdCode,LanguageID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(Edge.SVA.Model.BUY_Product_Particulars model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(Edge.SVA.Model.BUY_Product_Particulars model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ProdCode,int LanguageID)
		{
			
			return dal.Delete(ProdCode,LanguageID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Edge.SVA.Model.BUY_Product_Particulars GetModel(string ProdCode, int LanguageID)
		{
			
			return dal.GetModel(ProdCode,LanguageID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public Edge.SVA.Model.BUY_Product_Particulars GetModelByCache(string ProdCode, int LanguageID)
		{
			
			string CacheKey = "BUY_Product_ParticularsModel-" + ProdCode+LanguageID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProdCode,LanguageID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (Edge.SVA.Model.BUY_Product_Particulars)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Edge.SVA.Model.BUY_Product_Particulars> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Edge.SVA.Model.BUY_Product_Particulars> DataTableToList(DataTable dt)
		{
            List<Edge.SVA.Model.BUY_Product_Particulars> modelList = new List<Edge.SVA.Model.BUY_Product_Particulars>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Edge.SVA.Model.BUY_Product_Particulars model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
		
	}
}

