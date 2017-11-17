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
	/// 会员地址表
	/// </summary>
	public partial class MemberAddress
	{
		private readonly IMemberAddress dal=DataAccess.CreateMemberAddress();
		public MemberAddress()
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
		public bool Exists(int AddressID)
		{
			return dal.Exists(AddressID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.MemberAddress model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.MemberAddress model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int AddressID)
		{
			
			return dal.Delete(AddressID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string AddressIDlist )
		{
			return dal.DeleteList(AddressIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.MemberAddress GetModel(int AddressID)
		{
			
			return dal.GetModel(AddressID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.MemberAddress GetModelByCache(int AddressID)
		{
			
			string CacheKey = "MemberAddressModel-" + AddressID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(AddressID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.MemberAddress)objModel;
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
		public List<Edge.SVA.Model.MemberAddress> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.MemberAddress> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.MemberAddress> modelList = new List<Edge.SVA.Model.MemberAddress>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.MemberAddress model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.MemberAddress();
					if(dt.Rows[n]["AddressID"]!=null && dt.Rows[n]["AddressID"].ToString()!="")
					{
						model.AddressID=int.Parse(dt.Rows[n]["AddressID"].ToString());
					}
					if(dt.Rows[n]["MemberID"]!=null && dt.Rows[n]["MemberID"].ToString()!="")
					{
						model.MemberID=int.Parse(dt.Rows[n]["MemberID"].ToString());
					}
					if(dt.Rows[n]["MemberFirstAddr"]!=null && dt.Rows[n]["MemberFirstAddr"].ToString()!="")
					{
						model.MemberFirstAddr=int.Parse(dt.Rows[n]["MemberFirstAddr"].ToString());
					}
					if(dt.Rows[n]["AddressCountry"]!=null && dt.Rows[n]["AddressCountry"].ToString()!="")
					{
					model.AddressCountry=dt.Rows[n]["AddressCountry"].ToString();
					}
					if(dt.Rows[n]["AddressProvince"]!=null && dt.Rows[n]["AddressProvince"].ToString()!="")
					{
					model.AddressProvince=dt.Rows[n]["AddressProvince"].ToString();
					}
					if(dt.Rows[n]["AddressCity"]!=null && dt.Rows[n]["AddressCity"].ToString()!="")
					{
					model.AddressCity=dt.Rows[n]["AddressCity"].ToString();
					}
					if(dt.Rows[n]["AddressDistrict"]!=null && dt.Rows[n]["AddressDistrict"].ToString()!="")
					{
					model.AddressDistrict=dt.Rows[n]["AddressDistrict"].ToString();
					}
					if(dt.Rows[n]["AddressDetail"]!=null && dt.Rows[n]["AddressDetail"].ToString()!="")
					{
					model.AddressDetail=dt.Rows[n]["AddressDetail"].ToString();
					}
					if(dt.Rows[n]["AddressFullDetail"]!=null && dt.Rows[n]["AddressFullDetail"].ToString()!="")
					{
					model.AddressFullDetail=dt.Rows[n]["AddressFullDetail"].ToString();
					}
					if(dt.Rows[n]["AddressZipCode"]!=null && dt.Rows[n]["AddressZipCode"].ToString()!="")
					{
					model.AddressZipCode=dt.Rows[n]["AddressZipCode"].ToString();
					}
					if(dt.Rows[n]["Contact"]!=null && dt.Rows[n]["Contact"].ToString()!="")
					{
					model.Contact=dt.Rows[n]["Contact"].ToString();
					}
					if(dt.Rows[n]["ContactPhone"]!=null && dt.Rows[n]["ContactPhone"].ToString()!="")
					{
					model.ContactPhone=dt.Rows[n]["ContactPhone"].ToString();
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

