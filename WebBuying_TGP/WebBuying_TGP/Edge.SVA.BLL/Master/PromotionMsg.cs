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
	/// 优惠信息表
	/// </summary>
	public partial class PromotionMsg
	{
		private readonly IPromotionMsg dal=DataAccess.CreatePromotionMsg();
		public PromotionMsg()
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
		public int  Add(Edge.SVA.Model.PromotionMsg model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.PromotionMsg model)
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
		public Edge.SVA.Model.PromotionMsg GetModel(int KeyID)
		{
			
			return dal.GetModel(KeyID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.PromotionMsg GetModelByCache(int KeyID)
		{
			
			string CacheKey = "PromotionMsgModel-" + KeyID;
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
			return (Edge.SVA.Model.PromotionMsg)objModel;
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
		public List<Edge.SVA.Model.PromotionMsg> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.PromotionMsg> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.PromotionMsg> modelList = new List<Edge.SVA.Model.PromotionMsg>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.PromotionMsg model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.PromotionMsg();
					if(dt.Rows[n]["KeyID"]!=null && dt.Rows[n]["KeyID"].ToString()!="")
					{
						model.KeyID=int.Parse(dt.Rows[n]["KeyID"].ToString());
					}
					if(dt.Rows[n]["PromotionTitle1"]!=null && dt.Rows[n]["PromotionTitle1"].ToString()!="")
					{
					model.PromotionTitle1=dt.Rows[n]["PromotionTitle1"].ToString();
					}
					if(dt.Rows[n]["PromotionTitle2"]!=null && dt.Rows[n]["PromotionTitle2"].ToString()!="")
					{
					model.PromotionTitle2=dt.Rows[n]["PromotionTitle2"].ToString();
					}
					if(dt.Rows[n]["PromotionTitle3"]!=null && dt.Rows[n]["PromotionTitle3"].ToString()!="")
					{
					model.PromotionTitle3=dt.Rows[n]["PromotionTitle3"].ToString();
					}
					if(dt.Rows[n]["PromotionMsgStr1"]!=null && dt.Rows[n]["PromotionMsgStr1"].ToString()!="")
					{
					model.PromotionMsgStr1=dt.Rows[n]["PromotionMsgStr1"].ToString();
					}
					if(dt.Rows[n]["PromotionMsgStr2"]!=null && dt.Rows[n]["PromotionMsgStr2"].ToString()!="")
					{
					model.PromotionMsgStr2=dt.Rows[n]["PromotionMsgStr2"].ToString();
					}
					if(dt.Rows[n]["PromotionMsgStr3"]!=null && dt.Rows[n]["PromotionMsgStr3"].ToString()!="")
					{
					model.PromotionMsgStr3=dt.Rows[n]["PromotionMsgStr3"].ToString();
					}
					if(dt.Rows[n]["PromotionPicFile"]!=null && dt.Rows[n]["PromotionPicFile"].ToString()!="")
					{
					model.PromotionPicFile=dt.Rows[n]["PromotionPicFile"].ToString();
					}
					if(dt.Rows[n]["PromotionRemark"]!=null && dt.Rows[n]["PromotionRemark"].ToString()!="")
					{
					model.PromotionRemark=dt.Rows[n]["PromotionRemark"].ToString();
					}
					if(dt.Rows[n]["PromptScheduleID"]!=null && dt.Rows[n]["PromptScheduleID"].ToString()!="")
					{
						model.PromptScheduleID=int.Parse(dt.Rows[n]["PromptScheduleID"].ToString());
					}
					if(dt.Rows[n]["BirthPromotion"]!=null && dt.Rows[n]["BirthPromotion"].ToString()!="")
					{
						model.BirthPromotion=int.Parse(dt.Rows[n]["BirthPromotion"].ToString());
					}
					if(dt.Rows[n]["DeviceType"]!=null && dt.Rows[n]["DeviceType"].ToString()!="")
					{
						model.DeviceType=int.Parse(dt.Rows[n]["DeviceType"].ToString());
					}
					if(dt.Rows[n]["StartDate"]!=null && dt.Rows[n]["StartDate"].ToString()!="")
					{
						model.StartDate=DateTime.Parse(dt.Rows[n]["StartDate"].ToString());
					}
					if(dt.Rows[n]["EndDate"]!=null && dt.Rows[n]["EndDate"].ToString()!="")
					{
						model.EndDate=DateTime.Parse(dt.Rows[n]["EndDate"].ToString());
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if(dt.Rows[n]["CampaignID"]!=null && dt.Rows[n]["CampaignID"].ToString()!="")
					{
						model.CampaignID=int.Parse(dt.Rows[n]["CampaignID"].ToString());
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
					if(dt.Rows[n]["PromotionMsgTypeID"]!=null && dt.Rows[n]["PromotionMsgTypeID"].ToString()!="")
					{
						model.PromotionMsgTypeID=int.Parse(dt.Rows[n]["PromotionMsgTypeID"].ToString());
					}
					if(dt.Rows[n]["PromotionMsgCode"]!=null && dt.Rows[n]["PromotionMsgCode"].ToString()!="")
					{
					model.PromotionMsgCode=dt.Rows[n]["PromotionMsgCode"].ToString();
					}
					if(dt.Rows[n]["AttachmentFilePath"]!=null && dt.Rows[n]["AttachmentFilePath"].ToString()!="")
					{
					model.AttachmentFilePath=dt.Rows[n]["AttachmentFilePath"].ToString();
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

