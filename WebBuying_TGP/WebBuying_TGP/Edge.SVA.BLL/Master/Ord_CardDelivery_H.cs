﻿using System;
using System.Data;
using System.Collections.Generic;
using Edge.Common;
using Edge.SVA.Model;
using Edge.SVA.DALFactory;
using Edge.SVA.IDAL;
namespace Edge.SVA.BLL
{
	/// <summary>
	/// 卡送货单主表。
	///（从批核后的拣货单复制过来
	/// </summary>
	public partial class Ord_CardDelivery_H
	{
		private readonly IOrd_CardDelivery_H dal=DataAccess.CreateOrd_CardDelivery_H();
		public Ord_CardDelivery_H()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CardDeliveryNumber)
		{
			return dal.Exists(CardDeliveryNumber);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Ord_CardDelivery_H model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Ord_CardDelivery_H model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string CardDeliveryNumber)
		{
			
			return dal.Delete(CardDeliveryNumber);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string CardDeliveryNumberlist )
		{
			return dal.DeleteList(CardDeliveryNumberlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Ord_CardDelivery_H GetModel(string CardDeliveryNumber)
		{
			
			return dal.GetModel(CardDeliveryNumber);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Ord_CardDelivery_H GetModelByCache(string CardDeliveryNumber)
		{
			
			string CacheKey = "Ord_CardDelivery_HModel-" + CardDeliveryNumber;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CardDeliveryNumber);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.Ord_CardDelivery_H)objModel;
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
		public List<Edge.SVA.Model.Ord_CardDelivery_H> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Ord_CardDelivery_H> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Ord_CardDelivery_H> modelList = new List<Edge.SVA.Model.Ord_CardDelivery_H>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Ord_CardDelivery_H model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Ord_CardDelivery_H();
					if(dt.Rows[n]["CardDeliveryNumber"]!=null && dt.Rows[n]["CardDeliveryNumber"].ToString()!="")
					{
					model.CardDeliveryNumber=dt.Rows[n]["CardDeliveryNumber"].ToString();
					}
					if(dt.Rows[n]["ReferenceNo"]!=null && dt.Rows[n]["ReferenceNo"].ToString()!="")
					{
					model.ReferenceNo=dt.Rows[n]["ReferenceNo"].ToString();
					}
					if(dt.Rows[n]["StoreID"]!=null && dt.Rows[n]["StoreID"].ToString()!="")
					{
						model.StoreID=int.Parse(dt.Rows[n]["StoreID"].ToString());
					}
					if(dt.Rows[n]["CustomerID"]!=null && dt.Rows[n]["CustomerID"].ToString()!="")
					{
						model.CustomerID=int.Parse(dt.Rows[n]["CustomerID"].ToString());
					}
					if(dt.Rows[n]["NeedActive"]!=null && dt.Rows[n]["NeedActive"].ToString()!="")
					{
						model.NeedActive=int.Parse(dt.Rows[n]["NeedActive"].ToString());
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
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
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

