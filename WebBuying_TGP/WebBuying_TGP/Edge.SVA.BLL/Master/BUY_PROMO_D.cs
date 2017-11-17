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
	/// 促销设置明细表
	/// </summary>
	public partial class BUY_PROMO_D
	{
		private readonly IBUY_PROMO_D dal=DataAccess.CreateBUY_PROMO_D();
		public BUY_PROMO_D()
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
		public int  Add(Edge.SVA.Model.BUY_PROMO_D model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_PROMO_D model)
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
		public Edge.SVA.Model.BUY_PROMO_D GetModel(int KeyID)
		{
			
			return dal.GetModel(KeyID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_PROMO_D GetModelByCache(int KeyID)
		{
			
			string CacheKey = "BUY_PROMO_DModel-" + KeyID;
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
			return (Edge.SVA.Model.BUY_PROMO_D)objModel;
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
		public List<Edge.SVA.Model.BUY_PROMO_D> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_PROMO_D> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_PROMO_D> modelList = new List<Edge.SVA.Model.BUY_PROMO_D>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_PROMO_D model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_PROMO_D();
					if(dt.Rows[n]["KeyID"]!=null && dt.Rows[n]["KeyID"].ToString()!="")
					{
						model.KeyID=int.Parse(dt.Rows[n]["KeyID"].ToString());
					}
					if(dt.Rows[n]["PromotionCode"]!=null && dt.Rows[n]["PromotionCode"].ToString()!="")
					{
					model.PromotionCode=dt.Rows[n]["PromotionCode"].ToString();
					}
					if(dt.Rows[n]["EntityNum"]!=null && dt.Rows[n]["EntityNum"].ToString()!="")
					{
					model.EntityNum=dt.Rows[n]["EntityNum"].ToString();
					}
					if(dt.Rows[n]["EntityType"]!=null && dt.Rows[n]["EntityType"].ToString()!="")
					{
						model.EntityType=int.Parse(dt.Rows[n]["EntityType"].ToString());
					}
					if(dt.Rows[n]["HitOP"]!=null && dt.Rows[n]["HitOP"].ToString()!="")
					{
						model.HitOP=int.Parse(dt.Rows[n]["HitOP"].ToString());
					}
					if(dt.Rows[n]["HitAmount"]!=null && dt.Rows[n]["HitAmount"].ToString()!="")
					{
						model.HitAmount=decimal.Parse(dt.Rows[n]["HitAmount"].ToString());
					}
					if(dt.Rows[n]["DiscPrice"]!=null && dt.Rows[n]["DiscPrice"].ToString()!="")
					{
						model.DiscPrice=decimal.Parse(dt.Rows[n]["DiscPrice"].ToString());
					}
					if(dt.Rows[n]["DiscType"]!=null && dt.Rows[n]["DiscType"].ToString()!="")
					{
						model.DiscType=int.Parse(dt.Rows[n]["DiscType"].ToString());
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

