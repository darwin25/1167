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
	/// 分发优惠劵明细表
	///CardNumber：在填写数据时
	/// </summary>
	public partial class Ord_ImportCouponDispense_D
	{
		private readonly IOrd_ImportCouponDispense_D dal=DataAccess.CreateOrd_ImportCouponDispense_D();
		public Ord_ImportCouponDispense_D()
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
		public int  Add(Edge.SVA.Model.Ord_ImportCouponDispense_D model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Ord_ImportCouponDispense_D model)
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
		public Edge.SVA.Model.Ord_ImportCouponDispense_D GetModel(int KeyID)
		{
			
			return dal.GetModel(KeyID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Ord_ImportCouponDispense_D GetModelByCache(int KeyID)
		{
			
			string CacheKey = "Ord_ImportCouponDispense_DModel-" + KeyID;
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
			return (Edge.SVA.Model.Ord_ImportCouponDispense_D)objModel;
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
		public List<Edge.SVA.Model.Ord_ImportCouponDispense_D> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Ord_ImportCouponDispense_D> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Ord_ImportCouponDispense_D> modelList = new List<Edge.SVA.Model.Ord_ImportCouponDispense_D>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Ord_ImportCouponDispense_D model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Ord_ImportCouponDispense_D();
					if(dt.Rows[n]["KeyID"]!=null && dt.Rows[n]["KeyID"].ToString()!="")
					{
						model.KeyID=int.Parse(dt.Rows[n]["KeyID"].ToString());
					}
					if(dt.Rows[n]["CouponDispenseNumber"]!=null && dt.Rows[n]["CouponDispenseNumber"].ToString()!="")
					{
					model.CouponDispenseNumber=dt.Rows[n]["CouponDispenseNumber"].ToString();
					}
					if(dt.Rows[n]["CampaignCode"]!=null && dt.Rows[n]["CampaignCode"].ToString()!="")
					{
					model.CampaignCode=dt.Rows[n]["CampaignCode"].ToString();
					}
					if(dt.Rows[n]["CouponTypeCode"]!=null && dt.Rows[n]["CouponTypeCode"].ToString()!="")
					{
					model.CouponTypeCode=dt.Rows[n]["CouponTypeCode"].ToString();
					}
					if(dt.Rows[n]["MemberRegisterMobile"]!=null && dt.Rows[n]["MemberRegisterMobile"].ToString()!="")
					{
					model.MemberRegisterMobile=dt.Rows[n]["MemberRegisterMobile"].ToString();
					}
					if(dt.Rows[n]["ExportDatetime"]!=null && dt.Rows[n]["ExportDatetime"].ToString()!="")
					{
						model.ExportDatetime=DateTime.Parse(dt.Rows[n]["ExportDatetime"].ToString());
					}
					if(dt.Rows[n]["CardNumber"]!=null && dt.Rows[n]["CardNumber"].ToString()!="")
					{
					model.CardNumber=dt.Rows[n]["CardNumber"].ToString();
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
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder)
        {
            return dal.GetList(PageSize, PageIndex, strWhere, filedOrder);
        }
        ///<summary>
        ///获取分页总数
        ///</summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

		#endregion  Method
	}
}

