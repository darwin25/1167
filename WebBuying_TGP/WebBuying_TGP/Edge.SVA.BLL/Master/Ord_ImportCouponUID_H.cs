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
	/// 导入Coupon的UID。（销售实体coupon时
	/// </summary>
	public partial class Ord_ImportCouponUID_H
	{
		private readonly IOrd_ImportCouponUID_H dal=DataAccess.CreateOrd_ImportCouponUID_H();
		public Ord_ImportCouponUID_H()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ImportCouponNumber)
		{
			return dal.Exists(ImportCouponNumber);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Ord_ImportCouponUID_H model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Ord_ImportCouponUID_H model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ImportCouponNumber)
		{
			
			return dal.Delete(ImportCouponNumber);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ImportCouponNumberlist )
		{
			return dal.DeleteList(ImportCouponNumberlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Ord_ImportCouponUID_H GetModel(string ImportCouponNumber)
		{
			
			return dal.GetModel(ImportCouponNumber);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Ord_ImportCouponUID_H GetModelByCache(string ImportCouponNumber)
		{
			
			string CacheKey = "Ord_ImportCouponUID_HModel-" + ImportCouponNumber;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ImportCouponNumber);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.Ord_ImportCouponUID_H)objModel;
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
		public List<Edge.SVA.Model.Ord_ImportCouponUID_H> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Ord_ImportCouponUID_H> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Ord_ImportCouponUID_H> modelList = new List<Edge.SVA.Model.Ord_ImportCouponUID_H>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Ord_ImportCouponUID_H model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Ord_ImportCouponUID_H();
					if(dt.Rows[n]["ImportCouponNumber"]!=null && dt.Rows[n]["ImportCouponNumber"].ToString()!="")
					{
					model.ImportCouponNumber=dt.Rows[n]["ImportCouponNumber"].ToString();
					}
					if(dt.Rows[n]["ImportCouponDesc1"]!=null && dt.Rows[n]["ImportCouponDesc1"].ToString()!="")
					{
					model.ImportCouponDesc1=dt.Rows[n]["ImportCouponDesc1"].ToString();
					}
					if(dt.Rows[n]["ImportCouponDesc2"]!=null && dt.Rows[n]["ImportCouponDesc2"].ToString()!="")
					{
					model.ImportCouponDesc2=dt.Rows[n]["ImportCouponDesc2"].ToString();
					}
					if(dt.Rows[n]["ImportCouponDesc3"]!=null && dt.Rows[n]["ImportCouponDesc3"].ToString()!="")
					{
					model.ImportCouponDesc3=dt.Rows[n]["ImportCouponDesc3"].ToString();
					}
					if(dt.Rows[n]["NeedActive"]!=null && dt.Rows[n]["NeedActive"].ToString()!="")
					{
						model.NeedActive=int.Parse(dt.Rows[n]["NeedActive"].ToString());
					}
					if(dt.Rows[n]["NeedNewBatch"]!=null && dt.Rows[n]["NeedNewBatch"].ToString()!="")
					{
						model.NeedNewBatch=int.Parse(dt.Rows[n]["NeedNewBatch"].ToString());
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

