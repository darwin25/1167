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
	/// 套餐销售设置表
	/// </summary>
	public partial class BUY_BOXSALE
	{
		private readonly IBUY_BOXSALE dal=DataAccess.CreateBUY_BOXSALE();
		public BUY_BOXSALE()
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
		public bool Exists(int KeyID)
		{
			return dal.Exists(KeyID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_BOXSALE model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_BOXSALE model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int KeyID)
		{
			
			return dal.Delete(KeyID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string KeyIDlist )
		{
			return dal.DeleteList(KeyIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_BOXSALE GetModel(int KeyID)
		{
			
			return dal.GetModel(KeyID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_BOXSALE GetModelByCache(int KeyID)
		{
			
			string CacheKey = "BUY_BOXSALEModel-" + KeyID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(KeyID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_BOXSALE)objModel;
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
		public List<Edge.SVA.Model.BUY_BOXSALE> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_BOXSALE> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_BOXSALE> modelList = new List<Edge.SVA.Model.BUY_BOXSALE>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_BOXSALE model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_BOXSALE();
                    if (dt.Rows[n]["BOMID"] != null && dt.Rows[n]["BOMID"].ToString() != "")
					{
                        model.BOMID = int.Parse(dt.Rows[n]["BOMID"].ToString());
					}
					if(dt.Rows[n]["BOMCode"]!=null && dt.Rows[n]["BOMCode"].ToString()!="")
					{
					model.BOMCode=dt.Rows[n]["BOMCode"].ToString();
					}
					if(dt.Rows[n]["ProdCode"]!=null && dt.Rows[n]["ProdCode"].ToString()!="")
					{
					model.ProdCode=dt.Rows[n]["ProdCode"].ToString();
					}
					if(dt.Rows[n]["Qty"]!=null && dt.Rows[n]["Qty"].ToString()!="")
					{
						model.Qty=decimal.Parse(dt.Rows[n]["Qty"].ToString());
					}
					if(dt.Rows[n]["MinQty"]!=null && dt.Rows[n]["MinQty"].ToString()!="")
					{
						model.MinQty=int.Parse(dt.Rows[n]["MinQty"].ToString());
					}
					if(dt.Rows[n]["MaxQty"]!=null && dt.Rows[n]["MaxQty"].ToString()!="")
					{
						model.MaxQty=int.Parse(dt.Rows[n]["MaxQty"].ToString());
					}
					if(dt.Rows[n]["DefaultQty"]!=null && dt.Rows[n]["DefaultQty"].ToString()!="")
					{
						model.DefaultQty=int.Parse(dt.Rows[n]["DefaultQty"].ToString());
					}
					if(dt.Rows[n]["Price"]!=null && dt.Rows[n]["Price"].ToString()!="")
					{
						model.Price=decimal.Parse(dt.Rows[n]["Price"].ToString());
					}
					if(dt.Rows[n]["PartValue"]!=null && dt.Rows[n]["PartValue"].ToString()!="")
					{
						model.PartValue=decimal.Parse(dt.Rows[n]["PartValue"].ToString());
					}
					if(dt.Rows[n]["ValueType"]!=null && dt.Rows[n]["ValueType"].ToString()!="")
					{
						model.ValueType=int.Parse(dt.Rows[n]["ValueType"].ToString());
					}
					if(dt.Rows[n]["ActPrice"]!=null && dt.Rows[n]["ActPrice"].ToString()!="")
					{
						model.ActPrice=decimal.Parse(dt.Rows[n]["ActPrice"].ToString());
					}
					if(dt.Rows[n]["StartDate"]!=null && dt.Rows[n]["StartDate"].ToString()!="")
					{
						model.StartDate=DateTime.Parse(dt.Rows[n]["StartDate"].ToString());
					}
					if(dt.Rows[n]["EndDate"]!=null && dt.Rows[n]["EndDate"].ToString()!="")
					{
						model.EndDate=DateTime.Parse(dt.Rows[n]["EndDate"].ToString());
					}
					if(dt.Rows[n]["MutexTag"]!=null && dt.Rows[n]["MutexTag"].ToString()!="")
					{
						model.MutexTag=int.Parse(dt.Rows[n]["MutexTag"].ToString());
					}
					if(dt.Rows[n]["CreatedOn"]!=null && dt.Rows[n]["CreatedOn"].ToString()!="")
					{
						model.CreatedOn=DateTime.Parse(dt.Rows[n]["CreatedOn"].ToString());
					}
					if(dt.Rows[n]["CreatedBy"]!=null && dt.Rows[n]["CreatedBy"].ToString()!="")
					{
						model.CreatedBy=int.Parse(dt.Rows[n]["CreatedBy"].ToString());
					}
					if(dt.Rows[n]["UpdatedOn"]!=null && dt.Rows[n]["UpdatedOn"].ToString()!="")
					{
						model.UpdatedOn=DateTime.Parse(dt.Rows[n]["UpdatedOn"].ToString());
					}
					if(dt.Rows[n]["UpdatedBy"]!=null && dt.Rows[n]["UpdatedBy"].ToString()!="")
					{
						model.UpdatedBy=int.Parse(dt.Rows[n]["UpdatedBy"].ToString());
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
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder)
        {
            return dal.GetList(PageSize, PageIndex, strWhere, filedOrder);
        }

		#endregion  Method
	}
}

