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
	/// 店铺表。
	/// </summary>
	public partial class POSSTAFF
	{
		private readonly IPOSSTAFF dal=DataAccess.CreatePOSSTAFF();
		public POSSTAFF()
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
		public bool Exists(string StaffCode,int StaffID)
		{
			return dal.Exists(StaffCode,StaffID);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int StaffID)
        {
            return dal.Exists(StaffID);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string StaffCode)
        {
            return dal.Exists(StaffCode);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.POSSTAFF model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.POSSTAFF model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StaffID)
		{
			
			return dal.Delete(StaffID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string StaffCode,int StaffID)
		{
			
			return dal.Delete(StaffCode,StaffID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string StaffIDlist )
		{
			return dal.DeleteList(StaffIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.POSSTAFF GetModel(int StaffID)
		{
			
			return dal.GetModel(StaffID);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Edge.SVA.Model.POSSTAFF GetModel(string StaffCode)
        {

            return dal.GetModel(StaffCode);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.POSSTAFF GetModelByCache(int StaffID)
		{
			
			string CacheKey = "POSSTAFFModel-" + StaffID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(StaffID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.POSSTAFF)objModel;
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
		public List<Edge.SVA.Model.POSSTAFF> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.POSSTAFF> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.POSSTAFF> modelList = new List<Edge.SVA.Model.POSSTAFF>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.POSSTAFF model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.POSSTAFF();
					if (dt.Rows[n]["StaffID"] != null && dt.Rows[n]["StaffID"].ToString() != "")
                    {
                        model.StaffID = int.Parse(dt.Rows[n]["StaffID"].ToString());
                    }
                    if (dt.Rows[n]["StaffCode"] != null && dt.Rows[n]["StaffCode"].ToString() != "")
                    {
                        model.StaffCode = dt.Rows[n]["StaffCode"].ToString();
                    }
                    if (dt.Rows[n]["StaffName"] != null && dt.Rows[n]["StaffName"].ToString() != "")
                    {
                        model.StaffName = dt.Rows[n]["StaffName"].ToString();
                    }
                    if (dt.Rows[n]["StaffPWD"] != null && dt.Rows[n]["StaffPWD"].ToString() != "")
                    {
                        model.StaffPWD = dt.Rows[n]["StaffPWD"].ToString();
                    }
                    if (dt.Rows[n]["StaffLevel"] != null && dt.Rows[n]["StaffLevel"].ToString() != "")
                    {
                        model.StaffLevel = int.Parse(dt.Rows[n]["StaffLevel"].ToString());
                    }
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["LanguageID"] != null && dt.Rows[n]["LanguageID"].ToString() != "")
                    {
                        model.LanguageID = int.Parse(dt.Rows[n]["LanguageID"].ToString());
                    }
                    if (dt.Rows[n]["Def_Reset_PWD_DAYS"] != null && dt.Rows[n]["Def_Reset_PWD_DAYS"].ToString() != "")
                    {
                        model.Def_Reset_PWD_DAYS = int.Parse(dt.Rows[n]["Def_Reset_PWD_DAYS"].ToString());
                    }
                    if (dt.Rows[n]["Grace_Login_Count"] != null && dt.Rows[n]["Grace_Login_Count"].ToString() != "")
                    {
                        model.Grace_Login_Count = int.Parse(dt.Rows[n]["Grace_Login_Count"].ToString());
                    }
                    if (dt.Rows[n]["PWD_Valid_Days"] != null && dt.Rows[n]["PWD_Valid_Days"].ToString() != "")
                    {
                        model.PWD_Valid_Days = int.Parse(dt.Rows[n]["PWD_Valid_Days"].ToString());
                    }
                    if (dt.Rows[n]["Last_Reset_PWD"] != null && dt.Rows[n]["Last_Reset_PWD"].ToString() != "")
                    {
                        model.Last_Reset_PWD = DateTime.Parse(dt.Rows[n]["Last_Reset_PWD"].ToString());
                    }
                    if (dt.Rows[n]["LastLoginTime"] != null && dt.Rows[n]["LastLoginTime"].ToString() != "")
                    {
                        model.LastLoginTime = DateTime.Parse(dt.Rows[n]["LastLoginTime"].ToString());
                    }
                    if (dt.Rows[n]["LastLoginStore"] != null && dt.Rows[n]["LastLoginStore"].ToString() != "")
                    {
                        model.LastLoginStore = dt.Rows[n]["LastLoginStore"].ToString();
                    }
                    if (dt.Rows[n]["LastLoginRegister"] != null && dt.Rows[n]["LastLoginRegister"].ToString() != "")
                    {
                        model.LastLoginRegister = dt.Rows[n]["LastLoginRegister"].ToString();
                    }
                    if (dt.Rows[n]["CreatedOn"] != null && dt.Rows[n]["CreatedOn"].ToString() != "")
                    {
                        model.CreatedOn = DateTime.Parse(dt.Rows[n]["CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["CreatedBy"] != null && dt.Rows[n]["CreatedBy"].ToString() != "")
                    {
                        model.CreatedBy = int.Parse(dt.Rows[n]["CreatedBy"].ToString());
                    }
                    if (dt.Rows[n]["UpdatedOn"] != null && dt.Rows[n]["UpdatedOn"].ToString() != "")
                    {
                        model.UpdatedOn = DateTime.Parse(dt.Rows[n]["UpdatedOn"].ToString());
                    }
                    if (dt.Rows[n]["UpdatedBy"] != null && dt.Rows[n]["UpdatedBy"].ToString() != "")
                    {
                        model.UpdatedBy = int.Parse(dt.Rows[n]["UpdatedBy"].ToString());
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

