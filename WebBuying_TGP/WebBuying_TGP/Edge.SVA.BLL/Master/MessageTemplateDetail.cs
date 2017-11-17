using System;
using System.Data;
using System.Collections.Generic;
using Edge.Common;
using Edge.SVA.Model;
using Edge.SVA.DALFactory;
using Edge.SVA.IDAL;
using Edge.SVA.Model.Domain.File.BasicViewModel;
using Edge.SVA.BLL.Domain.DataResources;
namespace Edge.SVA.BLL
{
	/// <summary>
	/// 消息内容模板明细。
	/// </summary>
	public partial class MessageTemplateDetail
	{
		private readonly IMessageTemplateDetail dal=DataAccess.CreateMessageTemplateDetail();
		public MessageTemplateDetail()
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
		public int  Add(Edge.SVA.Model.MessageTemplateDetail model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.MessageTemplateDetail model)
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
		public Edge.SVA.Model.MessageTemplateDetail GetModel(int KeyID)
		{
			
			return dal.GetModel(KeyID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.MessageTemplateDetail GetModelByCache(int KeyID)
		{
			
			string CacheKey = "MessageTemplateDetailModel-" + KeyID;
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
			return (Edge.SVA.Model.MessageTemplateDetail)objModel;
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
        public List<MessageTemplateDetailViewModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<MessageTemplateDetailViewModel> DataTableToList(DataTable dt)
		{
            List<MessageTemplateDetailViewModel> modelList = new List<MessageTemplateDetailViewModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                MessageTemplateDetailViewModel model;
				for (int n = 0; n < rowsCount; n++)
				{
                    model = new MessageTemplateDetailViewModel();
					if(dt.Rows[n]["KeyID"]!=null && dt.Rows[n]["KeyID"].ToString()!="")
					{
						model.KeyID=int.Parse(dt.Rows[n]["KeyID"].ToString());
					}
					if(dt.Rows[n]["MessageTemplateID"]!=null && dt.Rows[n]["MessageTemplateID"].ToString()!="")
					{
						model.MessageTemplateID=int.Parse(dt.Rows[n]["MessageTemplateID"].ToString());
					}
					if(dt.Rows[n]["MessageServiceTypeID"]!=null && dt.Rows[n]["MessageServiceTypeID"].ToString()!="")
					{
						model.MessageServiceTypeID=int.Parse(dt.Rows[n]["MessageServiceTypeID"].ToString());
					}
					if(dt.Rows[n]["status"]!=null && dt.Rows[n]["status"].ToString()!="")
					{
						model.status=int.Parse(dt.Rows[n]["status"].ToString());
					}
					if(dt.Rows[n]["MessageTitle1"]!=null && dt.Rows[n]["MessageTitle1"].ToString()!="")
					{
					model.MessageTitle1=dt.Rows[n]["MessageTitle1"].ToString();
					}
					if(dt.Rows[n]["MessageTitle3"]!=null && dt.Rows[n]["MessageTitle3"].ToString()!="")
					{
					model.MessageTitle3=dt.Rows[n]["MessageTitle3"].ToString();
					}
					if(dt.Rows[n]["MessageTitle2"]!=null && dt.Rows[n]["MessageTitle2"].ToString()!="")
					{
					model.MessageTitle2=dt.Rows[n]["MessageTitle2"].ToString();
					}
					if(dt.Rows[n]["TemplateContent1"]!=null && dt.Rows[n]["TemplateContent1"].ToString()!="")
					{
					model.TemplateContent1=dt.Rows[n]["TemplateContent1"].ToString();
					}
					if(dt.Rows[n]["TemplateContent2"]!=null && dt.Rows[n]["TemplateContent2"].ToString()!="")
					{
					model.TemplateContent2=dt.Rows[n]["TemplateContent2"].ToString();
					}
					if(dt.Rows[n]["TemplateContent3"]!=null && dt.Rows[n]["TemplateContent3"].ToString()!="")
					{
					model.TemplateContent3=dt.Rows[n]["TemplateContent3"].ToString();
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

