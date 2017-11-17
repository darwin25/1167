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
	/// 优惠消息类型表
	/// </summary>
	public partial class PromotionMsgType
	{
		private readonly IPromotionMsgType dal=DataAccess.CreatePromotionMsgType();
		public PromotionMsgType()
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
		public bool Exists(int PromotionMsgTypeID)
		{
			return dal.Exists(PromotionMsgTypeID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.PromotionMsgType model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.PromotionMsgType model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int PromotionMsgTypeID)
		{
			
			return dal.Delete(PromotionMsgTypeID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string PromotionMsgTypeIDlist )
		{
			return dal.DeleteList(PromotionMsgTypeIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.PromotionMsgType GetModel(int PromotionMsgTypeID)
		{
			
			return dal.GetModel(PromotionMsgTypeID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.PromotionMsgType GetModelByCache(int PromotionMsgTypeID)
		{
			
			string CacheKey = "PromotionMsgTypeModel-" + PromotionMsgTypeID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PromotionMsgTypeID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.PromotionMsgType)objModel;
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
		public List<Edge.SVA.Model.PromotionMsgType> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.PromotionMsgType> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.PromotionMsgType> modelList = new List<Edge.SVA.Model.PromotionMsgType>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.PromotionMsgType model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.PromotionMsgType();
					if(dt.Rows[n]["PromotionMsgTypeID"]!=null && dt.Rows[n]["PromotionMsgTypeID"].ToString()!="")
					{
						model.PromotionMsgTypeID=int.Parse(dt.Rows[n]["PromotionMsgTypeID"].ToString());
					}
					if(dt.Rows[n]["BrandID"]!=null && dt.Rows[n]["BrandID"].ToString()!="")
					{
						model.BrandID=int.Parse(dt.Rows[n]["BrandID"].ToString());
					}
					if(dt.Rows[n]["PromotionMsgTypeName1"]!=null && dt.Rows[n]["PromotionMsgTypeName1"].ToString()!="")
					{
					model.PromotionMsgTypeName1=dt.Rows[n]["PromotionMsgTypeName1"].ToString();
					}
					if(dt.Rows[n]["PromotionMsgTypeName2"]!=null && dt.Rows[n]["PromotionMsgTypeName2"].ToString()!="")
					{
					model.PromotionMsgTypeName2=dt.Rows[n]["PromotionMsgTypeName2"].ToString();
					}
					if(dt.Rows[n]["PromotionMsgTypeName3"]!=null && dt.Rows[n]["PromotionMsgTypeName3"].ToString()!="")
					{
					model.PromotionMsgTypeName3=dt.Rows[n]["PromotionMsgTypeName3"].ToString();
					}
					if(dt.Rows[n]["ParentID"]!=null && dt.Rows[n]["ParentID"].ToString()!="")
					{
						model.ParentID=int.Parse(dt.Rows[n]["ParentID"].ToString());
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

