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
	/// 常用语表
	/// </summary>
	public partial class USEFULEXPRESSIONS
	{
		private readonly IUSEFULEXPRESSIONS dal=DataAccess.CreateUSEFULEXPRESSIONS();
		public USEFULEXPRESSIONS()
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
		public bool Exists(int USEFULEXPRESSIONSID)
		{
			return dal.Exists(USEFULEXPRESSIONSID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.USEFULEXPRESSIONS model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.USEFULEXPRESSIONS model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int USEFULEXPRESSIONSID)
		{
			
			return dal.Delete(USEFULEXPRESSIONSID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string USEFULEXPRESSIONSIDlist )
		{
			return dal.DeleteList(USEFULEXPRESSIONSIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.USEFULEXPRESSIONS GetModel(int USEFULEXPRESSIONSID)
		{
			
			return dal.GetModel(USEFULEXPRESSIONSID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.USEFULEXPRESSIONS GetModelByCache(int USEFULEXPRESSIONSID)
		{
			
			string CacheKey = "USEFULEXPRESSIONSModel-" + USEFULEXPRESSIONSID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(USEFULEXPRESSIONSID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.USEFULEXPRESSIONS)objModel;
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
		public List<Edge.SVA.Model.USEFULEXPRESSIONS> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.USEFULEXPRESSIONS> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.USEFULEXPRESSIONS> modelList = new List<Edge.SVA.Model.USEFULEXPRESSIONS>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.USEFULEXPRESSIONS model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.USEFULEXPRESSIONS();
					if(dt.Rows[n]["USEFULEXPRESSIONSID"]!=null && dt.Rows[n]["USEFULEXPRESSIONSID"].ToString()!="")
					{
						model.USEFULEXPRESSIONSID=int.Parse(dt.Rows[n]["USEFULEXPRESSIONSID"].ToString());
					}
					if(dt.Rows[n]["PhraseTitle1"]!=null && dt.Rows[n]["PhraseTitle1"].ToString()!="")
					{
					model.PhraseTitle1=dt.Rows[n]["PhraseTitle1"].ToString();
					}
					if(dt.Rows[n]["PhraseTitle2"]!=null && dt.Rows[n]["PhraseTitle2"].ToString()!="")
					{
					model.PhraseTitle2=dt.Rows[n]["PhraseTitle2"].ToString();
					}
					if(dt.Rows[n]["PhraseTitle3"]!=null && dt.Rows[n]["PhraseTitle3"].ToString()!="")
					{
					model.PhraseTitle3=dt.Rows[n]["PhraseTitle3"].ToString();
					}
					if(dt.Rows[n]["PhraseContent1"]!=null && dt.Rows[n]["PhraseContent1"].ToString()!="")
					{
					model.PhraseContent1=dt.Rows[n]["PhraseContent1"].ToString();
					}
					if(dt.Rows[n]["PhraseContent2"]!=null && dt.Rows[n]["PhraseContent2"].ToString()!="")
					{
					model.PhraseContent2=dt.Rows[n]["PhraseContent2"].ToString();
					}
					if(dt.Rows[n]["PhraseContent3"]!=null && dt.Rows[n]["PhraseContent3"].ToString()!="")
					{
					model.PhraseContent3=dt.Rows[n]["PhraseContent3"].ToString();
					}
					if(dt.Rows[n]["CampaignID"]!=null && dt.Rows[n]["CampaignID"].ToString()!="")
					{
						model.CampaignID=int.Parse(dt.Rows[n]["CampaignID"].ToString());
					}
					if(dt.Rows[n]["PhrasePicFile"]!=null && dt.Rows[n]["PhrasePicFile"].ToString()!="")
					{
					model.PhrasePicFile=dt.Rows[n]["PhrasePicFile"].ToString();
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

