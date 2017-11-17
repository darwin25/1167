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
	/// 优惠劵调整单据主表
	/// </summary>
	public partial class Ord_CouponAdjust_H
	{
		private readonly IOrd_CouponAdjust_H dal=DataAccess.CreateOrd_CouponAdjust_H();
		public Ord_CouponAdjust_H()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CouponAdjustNumber)
		{
			return dal.Exists(CouponAdjustNumber);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Ord_CouponAdjust_H model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Ord_CouponAdjust_H model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string CouponAdjustNumber)
		{
			
			return dal.Delete(CouponAdjustNumber);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string CouponAdjustNumberlist )
		{
			return dal.DeleteList(CouponAdjustNumberlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Ord_CouponAdjust_H GetModel(string CouponAdjustNumber)
		{
			
			return dal.GetModel(CouponAdjustNumber);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Ord_CouponAdjust_H GetModelByCache(string CouponAdjustNumber)
		{
			
			string CacheKey = "Ord_CouponAdjust_HModel-" + CouponAdjustNumber;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CouponAdjustNumber);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.Ord_CouponAdjust_H)objModel;
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
		public List<Edge.SVA.Model.Ord_CouponAdjust_H> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Ord_CouponAdjust_H> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Ord_CouponAdjust_H> modelList = new List<Edge.SVA.Model.Ord_CouponAdjust_H>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Ord_CouponAdjust_H model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Ord_CouponAdjust_H();
					if(dt.Rows[n]["CouponAdjustNumber"]!=null && dt.Rows[n]["CouponAdjustNumber"].ToString()!="")
					{
					model.CouponAdjustNumber=dt.Rows[n]["CouponAdjustNumber"].ToString();
					}
					if(dt.Rows[n]["OprID"]!=null && dt.Rows[n]["OprID"].ToString()!="")
					{
						model.OprID=int.Parse(dt.Rows[n]["OprID"].ToString());
					}
					if(dt.Rows[n]["OriginalTxnNo"]!=null && dt.Rows[n]["OriginalTxnNo"].ToString()!="")
					{
					model.OriginalTxnNo=dt.Rows[n]["OriginalTxnNo"].ToString();
					}
					if(dt.Rows[n]["TxnDate"]!=null && dt.Rows[n]["TxnDate"].ToString()!="")
					{
						model.TxnDate=DateTime.Parse(dt.Rows[n]["TxnDate"].ToString());
					}
					if(dt.Rows[n]["StoreCode"]!=null && dt.Rows[n]["StoreCode"].ToString()!="")
					{
					model.StoreCode=dt.Rows[n]["StoreCode"].ToString();
					}
					if(dt.Rows[n]["ServerCode"]!=null && dt.Rows[n]["ServerCode"].ToString()!="")
					{
					model.ServerCode=dt.Rows[n]["ServerCode"].ToString();
					}
					if(dt.Rows[n]["RegisterCode"]!=null && dt.Rows[n]["RegisterCode"].ToString()!="")
					{
					model.RegisterCode=dt.Rows[n]["RegisterCode"].ToString();
					}
					if(dt.Rows[n]["ReasonID"]!=null && dt.Rows[n]["ReasonID"].ToString()!="")
					{
						model.ReasonID=int.Parse(dt.Rows[n]["ReasonID"].ToString());
					}
					if(dt.Rows[n]["Note"]!=null && dt.Rows[n]["Note"].ToString()!="")
					{
					model.Note=dt.Rows[n]["Note"].ToString();
					}
					if(dt.Rows[n]["ActExpireDate"]!=null && dt.Rows[n]["ActExpireDate"].ToString()!="")
					{
						model.ActExpireDate=DateTime.Parse(dt.Rows[n]["ActExpireDate"].ToString());
					}
					if(dt.Rows[n]["CouponCount"]!=null && dt.Rows[n]["CouponCount"].ToString()!="")
					{
						model.CouponCount=int.Parse(dt.Rows[n]["CouponCount"].ToString());
					}
					if(dt.Rows[n]["ApproveStatus"]!=null && dt.Rows[n]["ApproveStatus"].ToString()!="")
					{
					model.ApproveStatus=dt.Rows[n]["ApproveStatus"].ToString();
					}
					if(dt.Rows[n]["ApproveOn"]!=null && dt.Rows[n]["ApproveOn"].ToString()!="")
					{
						model.ApproveOn=DateTime.Parse(dt.Rows[n]["ApproveOn"].ToString());
					}
					if(dt.Rows[n]["ApproveBy"]!=null && dt.Rows[n]["ApproveBy"].ToString()!="")
					{
						model.ApproveBy=int.Parse(dt.Rows[n]["ApproveBy"].ToString());
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
					if(dt.Rows[n]["CreatedBusDate"]!=null && dt.Rows[n]["CreatedBusDate"].ToString()!="")
					{
						model.CreatedBusDate=DateTime.Parse(dt.Rows[n]["CreatedBusDate"].ToString());
					}
					if(dt.Rows[n]["ApproveBusDate"]!=null && dt.Rows[n]["ApproveBusDate"].ToString()!="")
					{
						model.ApproveBusDate=DateTime.Parse(dt.Rows[n]["ApproveBusDate"].ToString());
					}
					if(dt.Rows[n]["ApprovalCode"]!=null && dt.Rows[n]["ApprovalCode"].ToString()!="")
					{
					model.ApprovalCode=dt.Rows[n]["ApprovalCode"].ToString();
					}
					if(dt.Rows[n]["BrandCode"]!=null && dt.Rows[n]["BrandCode"].ToString()!="")
					{
					model.BrandCode=dt.Rows[n]["BrandCode"].ToString();
					}
					if(dt.Rows[n]["ActAmount"]!=null && dt.Rows[n]["ActAmount"].ToString()!="")
					{
						model.ActAmount=decimal.Parse(dt.Rows[n]["ActAmount"].ToString());
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

