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
	/// 导入Coupon的U
	/// </summary>
	public partial class Ord_ImportCouponUID_D
	{
		private readonly IOrd_ImportCouponUID_D dal=DataAccess.CreateOrd_ImportCouponUID_D();
		public Ord_ImportCouponUID_D()
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
		public int  Add(Edge.SVA.Model.Ord_ImportCouponUID_D model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Ord_ImportCouponUID_D model)
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
		public Edge.SVA.Model.Ord_ImportCouponUID_D GetModel(int KeyID)
		{
			
			return dal.GetModel(KeyID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Ord_ImportCouponUID_D GetModelByCache(int KeyID)
		{
			
			string CacheKey = "Ord_ImportCouponUID_DModel-" + KeyID;
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
			return (Edge.SVA.Model.Ord_ImportCouponUID_D)objModel;
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
		public List<Edge.SVA.Model.Ord_ImportCouponUID_D> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Ord_ImportCouponUID_D> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Ord_ImportCouponUID_D> modelList = new List<Edge.SVA.Model.Ord_ImportCouponUID_D>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Ord_ImportCouponUID_D model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Ord_ImportCouponUID_D();
					if(dt.Rows[n]["KeyID"]!=null && dt.Rows[n]["KeyID"].ToString()!="")
					{
						model.KeyID=int.Parse(dt.Rows[n]["KeyID"].ToString());
					}
					if(dt.Rows[n]["ImportCouponNumber"]!=null && dt.Rows[n]["ImportCouponNumber"].ToString()!="")
					{
					model.ImportCouponNumber=dt.Rows[n]["ImportCouponNumber"].ToString();
					}
					if(dt.Rows[n]["CouponTypeID"]!=null && dt.Rows[n]["CouponTypeID"].ToString()!="")
					{
						model.CouponTypeID=int.Parse(dt.Rows[n]["CouponTypeID"].ToString());
					}
					if(dt.Rows[n]["CouponUID"]!=null && dt.Rows[n]["CouponUID"].ToString()!="")
					{
					model.CouponUID=dt.Rows[n]["CouponUID"].ToString();
					}
					if(dt.Rows[n]["ExpiryDate"]!=null && dt.Rows[n]["ExpiryDate"].ToString()!="")
					{
						model.ExpiryDate=DateTime.Parse(dt.Rows[n]["ExpiryDate"].ToString());
					}
					if(dt.Rows[n]["BatchID"]!=null && dt.Rows[n]["BatchID"].ToString()!="")
					{
					model.BatchID=dt.Rows[n]["BatchID"].ToString();
					}
					if(dt.Rows[n]["Denomination"]!=null && dt.Rows[n]["Denomination"].ToString()!="")
					{
						model.Denomination=decimal.Parse(dt.Rows[n]["Denomination"].ToString());
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
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder)
        {
            return dal.GetList(PageSize, PageIndex, strWhere, filedOrder);
        }
        ///<summary>
        ///获取分页总数
        ///</summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

		#endregion  Method
	}
}

