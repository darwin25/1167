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
	/// 消息内容模板。
	/// </summary>
	public partial class MessageTemplate
	{
		private readonly IMessageTemplate dal=DataAccess.CreateMessageTemplate();
		public MessageTemplate()
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
		public bool Exists(int MessageTemplateID)
		{
			return dal.Exists(MessageTemplateID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.MessageTemplate model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.MessageTemplate model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MessageTemplateID)
		{
			
			return dal.Delete(MessageTemplateID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string MessageTemplateIDlist )
		{
			return dal.DeleteList(MessageTemplateIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.MessageTemplate GetModel(int MessageTemplateID)
		{
			
			return dal.GetModel(MessageTemplateID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.MessageTemplate GetModelByCache(int MessageTemplateID)
		{
			
			string CacheKey = "MessageTemplateModel-" + MessageTemplateID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(MessageTemplateID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.MessageTemplate)objModel;
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
		public List<Edge.SVA.Model.MessageTemplate> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.MessageTemplate> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.MessageTemplate> modelList = new List<Edge.SVA.Model.MessageTemplate>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.MessageTemplate model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.MessageTemplate();
					if(dt.Rows[n]["MessageTemplateID"]!=null && dt.Rows[n]["MessageTemplateID"].ToString()!="")
					{
						model.MessageTemplateID=int.Parse(dt.Rows[n]["MessageTemplateID"].ToString());
					}
					if(dt.Rows[n]["MessageTemplateCode"]!=null && dt.Rows[n]["MessageTemplateCode"].ToString()!="")
					{
					model.MessageTemplateCode=dt.Rows[n]["MessageTemplateCode"].ToString();
					}
					if(dt.Rows[n]["MessageTemplateDesc"]!=null && dt.Rows[n]["MessageTemplateDesc"].ToString()!="")
					{
					model.MessageTemplateDesc=dt.Rows[n]["MessageTemplateDesc"].ToString();
					}
					if(dt.Rows[n]["BrandID"]!=null && dt.Rows[n]["BrandID"].ToString()!="")
					{
						model.BrandID=int.Parse(dt.Rows[n]["BrandID"].ToString());
					}
					if(dt.Rows[n]["OprID"]!=null && dt.Rows[n]["OprID"].ToString()!="")
					{
						model.OprID=int.Parse(dt.Rows[n]["OprID"].ToString());
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
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

