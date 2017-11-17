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
	/// 导入Member数据（主表） （MII）（只是存储记录
	/// </summary>
	public partial class Ord_ImportMember_H
	{
		private readonly IOrd_ImportMember_H dal=DataAccess.CreateOrd_ImportMember_H();
		public Ord_ImportMember_H()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ImportMemberNumber)
		{
			return dal.Exists(ImportMemberNumber);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Ord_ImportMember_H model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Ord_ImportMember_H model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ImportMemberNumber)
		{
			
			return dal.Delete(ImportMemberNumber);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ImportMemberNumberlist )
		{
			return dal.DeleteList(ImportMemberNumberlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Ord_ImportMember_H GetModel(string ImportMemberNumber)
		{
			
			return dal.GetModel(ImportMemberNumber);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Ord_ImportMember_H GetModelByCache(string ImportMemberNumber)
		{
			
			string CacheKey = "Ord_ImportMember_HModel-" + ImportMemberNumber;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ImportMemberNumber);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.Ord_ImportMember_H)objModel;
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
		public List<Edge.SVA.Model.Ord_ImportMember_H> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Ord_ImportMember_H> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Ord_ImportMember_H> modelList = new List<Edge.SVA.Model.Ord_ImportMember_H>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Ord_ImportMember_H model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Ord_ImportMember_H();
					if(dt.Rows[n]["ImportMemberNumber"]!=null && dt.Rows[n]["ImportMemberNumber"].ToString()!="")
					{
					model.ImportMemberNumber=dt.Rows[n]["ImportMemberNumber"].ToString();
					}
					if(dt.Rows[n]["Description"]!=null && dt.Rows[n]["Description"].ToString()!="")
					{
					model.Description=dt.Rows[n]["Description"].ToString();
					}
					if(dt.Rows[n]["Note"]!=null && dt.Rows[n]["Note"].ToString()!="")
					{
					model.Note=dt.Rows[n]["Note"].ToString();
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
					if(dt.Rows[n]["CreatedBusDate"]!=null && dt.Rows[n]["CreatedBusDate"].ToString()!="")
					{
						model.CreatedBusDate=DateTime.Parse(dt.Rows[n]["CreatedBusDate"].ToString());
					}
					if(dt.Rows[n]["ApproveBusDate"]!=null && dt.Rows[n]["ApproveBusDate"].ToString()!="")
					{
						model.ApproveBusDate=DateTime.Parse(dt.Rows[n]["ApproveBusDate"].ToString());
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

