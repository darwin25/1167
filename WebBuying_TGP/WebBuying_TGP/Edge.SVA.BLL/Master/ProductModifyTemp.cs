using System;
using System.Data;
using System.Collections.Generic;
using Edge.Common;
using Edge.SVA.Model;
using Edge.SVA.DALFactory;
using Edge.SVA.IDAL;
namespace Edge.SVA.BLL
{
	/// <summary>
	/// @2016-12-14 @Gavin
	///用户product变更表。  每次操作后清空。
	///status暂时没用。  如果需要批核的话就启用。
	///设置的字段
	/// </summary>
	public partial class ProductModifyTemp
	{
		private readonly IProductModifyTemp dal=DataAccess.CreateProductModifyTemp();
		public ProductModifyTemp()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ProdCode)
		{
			return dal.Exists(ProdCode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.ProductModifyTemp model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.ProductModifyTemp model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ProdCode)
		{
			
			return dal.Delete(ProdCode);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ProdCodelist )
		{
			return dal.DeleteList(ProdCodelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.ProductModifyTemp GetModel(string ProdCode)
		{
			
			return dal.GetModel(ProdCode);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.ProductModifyTemp GetModelByCache(string ProdCode)
		{
			
			string CacheKey = "ProductModifyTempModel-" + ProdCode;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProdCode);
					if (objModel != null)
					{
                        int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.ProductModifyTemp)objModel;
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
		public List<Edge.SVA.Model.ProductModifyTemp> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.ProductModifyTemp> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.ProductModifyTemp> modelList = new List<Edge.SVA.Model.ProductModifyTemp>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.ProductModifyTemp model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.ProductModifyTemp();
					if(dt.Rows[n]["ProdCode"]!=null && dt.Rows[n]["ProdCode"].ToString()!="")
					{
					model.ProdCode=dt.Rows[n]["ProdCode"].ToString();
					}
					if(dt.Rows[n]["IsOnlineSKU"]!=null && dt.Rows[n]["IsOnlineSKU"].ToString()!="")
					{
						model.IsOnlineSKU=int.Parse(dt.Rows[n]["IsOnlineSKU"].ToString());
					}
					if(dt.Rows[n]["Feature"]!=null && dt.Rows[n]["Feature"].ToString()!="")
					{
						model.Feature=int.Parse(dt.Rows[n]["Feature"].ToString());
					}
					if(dt.Rows[n]["HotSale"]!=null && dt.Rows[n]["HotSale"].ToString()!="")
					{
						model.HotSale=int.Parse(dt.Rows[n]["HotSale"].ToString());
					}
					if(dt.Rows[n]["Price"]!=null && dt.Rows[n]["Price"].ToString()!="")
					{
						model.Price=decimal.Parse(dt.Rows[n]["Price"].ToString());
					}
					if(dt.Rows[n]["RefPrice"]!=null && dt.Rows[n]["RefPrice"].ToString()!="")
					{
						model.RefPrice=decimal.Parse(dt.Rows[n]["RefPrice"].ToString());
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if(dt.Rows[n]["CreatedOn"]!=null && dt.Rows[n]["CreatedOn"].ToString()!="")
					{
						model.CreatedOn=DateTime.Parse(dt.Rows[n]["CreatedOn"].ToString());
					}
					modelList.Add(model);
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

