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
	/// 机构表donate
	/// </summary>
	public partial class Organization
	{
		private readonly IOrganization dal=DataAccess.CreateOrganization();
		public Organization()
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
		public bool Exists(int OrganizationID)
		{
			return dal.Exists(OrganizationID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.Organization model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Organization model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int OrganizationID)
		{
			
			return dal.Delete(OrganizationID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string OrganizationIDlist )
		{
			return dal.DeleteList(OrganizationIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Organization GetModel(int OrganizationID)
		{
			
			return dal.GetModel(OrganizationID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Organization GetModelByCache(int OrganizationID)
		{
			
			string CacheKey = "OrganizationModel-" + OrganizationID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(OrganizationID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.Organization)objModel;
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
		public List<Edge.SVA.Model.Organization> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Organization> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Organization> modelList = new List<Edge.SVA.Model.Organization>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Organization model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Organization();
					if(dt.Rows[n]["OrganizationID"]!=null && dt.Rows[n]["OrganizationID"].ToString()!="")
					{
						model.OrganizationID=int.Parse(dt.Rows[n]["OrganizationID"].ToString());
					}
					if(dt.Rows[n]["OrganizationName1"]!=null && dt.Rows[n]["OrganizationName1"].ToString()!="")
					{
					model.OrganizationName1=dt.Rows[n]["OrganizationName1"].ToString();
					}
					if(dt.Rows[n]["OrganizationName2"]!=null && dt.Rows[n]["OrganizationName2"].ToString()!="")
					{
					model.OrganizationName2=dt.Rows[n]["OrganizationName2"].ToString();
					}
					if(dt.Rows[n]["OrganizationName3"]!=null && dt.Rows[n]["OrganizationName3"].ToString()!="")
					{
					model.OrganizationName3=dt.Rows[n]["OrganizationName3"].ToString();
					}
					if(dt.Rows[n]["OrganizationNote"]!=null && dt.Rows[n]["OrganizationNote"].ToString()!="")
					{
					model.OrganizationNote=dt.Rows[n]["OrganizationNote"].ToString();
					}
					if(dt.Rows[n]["CardNumber"]!=null && dt.Rows[n]["CardNumber"].ToString()!="")
					{
					model.CardNumber=dt.Rows[n]["CardNumber"].ToString();
					}
					if(dt.Rows[n]["CumulativePoints"]!=null && dt.Rows[n]["CumulativePoints"].ToString()!="")
					{
						model.CumulativePoints=int.Parse(dt.Rows[n]["CumulativePoints"].ToString());
					}
					if(dt.Rows[n]["CumulativeAmt"]!=null && dt.Rows[n]["CumulativeAmt"].ToString()!="")
					{
						model.CumulativeAmt=decimal.Parse(dt.Rows[n]["CumulativeAmt"].ToString());
					}
					if(dt.Rows[n]["OrganizationType"]!=null && dt.Rows[n]["OrganizationType"].ToString()!="")
					{
						model.OrganizationType=int.Parse(dt.Rows[n]["OrganizationType"].ToString());
					}
					if(dt.Rows[n]["OrganizationPicFile"]!=null && dt.Rows[n]["OrganizationPicFile"].ToString()!="")
					{
					model.OrganizationPicFile=dt.Rows[n]["OrganizationPicFile"].ToString();
					}
					if(dt.Rows[n]["CallInterface"]!=null && dt.Rows[n]["CallInterface"].ToString()!="")
					{
						model.CallInterface=int.Parse(dt.Rows[n]["CallInterface"].ToString());
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
					if(dt.Rows[n]["OrganizationCode"]!=null && dt.Rows[n]["OrganizationCode"].ToString()!="")
					{
					model.OrganizationCode=dt.Rows[n]["OrganizationCode"].ToString();
					}
					if(dt.Rows[n]["OrganizationDesc1"]!=null && dt.Rows[n]["OrganizationDesc1"].ToString()!="")
					{
					model.OrganizationDesc1=dt.Rows[n]["OrganizationDesc1"].ToString();
					}
					if(dt.Rows[n]["OrganizationDesc2"]!=null && dt.Rows[n]["OrganizationDesc2"].ToString()!="")
					{
					model.OrganizationDesc2=dt.Rows[n]["OrganizationDesc2"].ToString();
					}
					if(dt.Rows[n]["OrganizationDesc3"]!=null && dt.Rows[n]["OrganizationDesc3"].ToString()!="")
					{
					model.OrganizationDesc3=dt.Rows[n]["OrganizationDesc3"].ToString();
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
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder)
        {
            return dal.GetListByPage(strWhere, filedOrder, (PageSize*PageIndex+1), PageSize*(PageIndex+1));
        }
        ///<summary>
        ///获取分页总数
        ///</summary>
        public int GetCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
		#endregion  Method
	}
}

