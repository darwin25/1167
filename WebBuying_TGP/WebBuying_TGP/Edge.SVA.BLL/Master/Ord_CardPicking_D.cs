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
	/// 卡拣货单子表
	///表中brandID
	/// </summary>
	public partial class Ord_CardPicking_D
	{
		private readonly IOrd_CardPicking_D dal=DataAccess.CreateOrd_CardPicking_D();
		public Ord_CardPicking_D()
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
		public int  Add(Edge.SVA.Model.Ord_CardPicking_D model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Ord_CardPicking_D model)
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
		public Edge.SVA.Model.Ord_CardPicking_D GetModel(int KeyID)
		{
			
			return dal.GetModel(KeyID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Ord_CardPicking_D GetModelByCache(int KeyID)
		{
			
			string CacheKey = "Ord_CardPicking_DModel-" + KeyID;
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
			return (Edge.SVA.Model.Ord_CardPicking_D)objModel;
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
		public List<Edge.SVA.Model.Ord_CardPicking_D> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Ord_CardPicking_D> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Ord_CardPicking_D> modelList = new List<Edge.SVA.Model.Ord_CardPicking_D>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Ord_CardPicking_D model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Ord_CardPicking_D();
					if(dt.Rows[n]["KeyID"]!=null && dt.Rows[n]["KeyID"].ToString()!="")
					{
						model.KeyID=int.Parse(dt.Rows[n]["KeyID"].ToString());
					}
					if(dt.Rows[n]["CardPickingNumber"]!=null && dt.Rows[n]["CardPickingNumber"].ToString()!="")
					{
					model.CardPickingNumber=dt.Rows[n]["CardPickingNumber"].ToString();
					}
					if(dt.Rows[n]["BrandID"]!=null && dt.Rows[n]["BrandID"].ToString()!="")
					{
						model.BrandID=int.Parse(dt.Rows[n]["BrandID"].ToString());
					}
					if(dt.Rows[n]["CardTypeID"]!=null && dt.Rows[n]["CardTypeID"].ToString()!="")
					{
						model.CardTypeID=int.Parse(dt.Rows[n]["CardTypeID"].ToString());
					}
					if(dt.Rows[n]["CardGradeID"]!=null && dt.Rows[n]["CardGradeID"].ToString()!="")
					{
						model.CardGradeID=int.Parse(dt.Rows[n]["CardGradeID"].ToString());
					}
					if(dt.Rows[n]["Description"]!=null && dt.Rows[n]["Description"].ToString()!="")
					{
					model.Description=dt.Rows[n]["Description"].ToString();
					}
					if(dt.Rows[n]["OrderQTY"]!=null && dt.Rows[n]["OrderQTY"].ToString()!="")
					{
						model.OrderQTY=int.Parse(dt.Rows[n]["OrderQTY"].ToString());
					}
					if(dt.Rows[n]["PickQTY"]!=null && dt.Rows[n]["PickQTY"].ToString()!="")
					{
						model.PickQTY=int.Parse(dt.Rows[n]["PickQTY"].ToString());
					}
					if(dt.Rows[n]["ActualQTY"]!=null && dt.Rows[n]["ActualQTY"].ToString()!="")
					{
						model.ActualQTY=int.Parse(dt.Rows[n]["ActualQTY"].ToString());
					}
					if(dt.Rows[n]["FirstCardNumber"]!=null && dt.Rows[n]["FirstCardNumber"].ToString()!="")
					{
					model.FirstCardNumber=dt.Rows[n]["FirstCardNumber"].ToString();
					}
					if(dt.Rows[n]["EndCardNumber"]!=null && dt.Rows[n]["EndCardNumber"].ToString()!="")
					{
					model.EndCardNumber=dt.Rows[n]["EndCardNumber"].ToString();
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

