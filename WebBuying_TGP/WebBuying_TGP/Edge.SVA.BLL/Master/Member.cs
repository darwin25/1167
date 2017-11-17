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
	/// 会员表
	/// </summary>
	public partial class Member
	{
		private readonly IMember dal=DataAccess.CreateMember();
		public Member()
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
		public bool Exists(int MemberID)
		{
			return dal.Exists(MemberID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.Member model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Member model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MemberID)
		{
			
			return dal.Delete(MemberID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string MemberIDlist )
		{
			return dal.DeleteList(MemberIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Member GetModel(int MemberID)
		{
			
			return dal.GetModel(MemberID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Member GetModelByCache(int MemberID)
		{
			
			string CacheKey = "MemberModel-" + MemberID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(MemberID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.Member)objModel;
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
		public List<Edge.SVA.Model.Member> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Member> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Member> modelList = new List<Edge.SVA.Model.Member>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Member model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Member();
					if(dt.Rows[n]["MemberID"]!=null && dt.Rows[n]["MemberID"].ToString()!="")
					{
						model.MemberID=int.Parse(dt.Rows[n]["MemberID"].ToString());
					}
					if(dt.Rows[n]["MemberPassword"]!=null && dt.Rows[n]["MemberPassword"].ToString()!="")
					{
					model.MemberPassword=dt.Rows[n]["MemberPassword"].ToString();
					}
					if(dt.Rows[n]["MemberIdentityType"]!=null && dt.Rows[n]["MemberIdentityType"].ToString()!="")
					{
						model.MemberIdentityType=int.Parse(dt.Rows[n]["MemberIdentityType"].ToString());
					}
					if(dt.Rows[n]["MemberIdentityRef"]!=null && dt.Rows[n]["MemberIdentityRef"].ToString()!="")
					{
					model.MemberIdentityRef=dt.Rows[n]["MemberIdentityRef"].ToString();
					}
					if(dt.Rows[n]["MemberRegisterMobile"]!=null && dt.Rows[n]["MemberRegisterMobile"].ToString()!="")
					{
					model.MemberRegisterMobile=dt.Rows[n]["MemberRegisterMobile"].ToString();
					}
					if(dt.Rows[n]["MemberMobilePhone"]!=null && dt.Rows[n]["MemberMobilePhone"].ToString()!="")
					{
					model.MemberMobilePhone=dt.Rows[n]["MemberMobilePhone"].ToString();
					}
					if(dt.Rows[n]["MemberEmail"]!=null && dt.Rows[n]["MemberEmail"].ToString()!="")
					{
					model.MemberEmail=dt.Rows[n]["MemberEmail"].ToString();
					}
					if(dt.Rows[n]["MemberAppellation"]!=null && dt.Rows[n]["MemberAppellation"].ToString()!="")
					{
					model.MemberAppellation=dt.Rows[n]["MemberAppellation"].ToString();
					}
					if(dt.Rows[n]["MemberEngFamilyName"]!=null && dt.Rows[n]["MemberEngFamilyName"].ToString()!="")
					{
					model.MemberEngFamilyName=dt.Rows[n]["MemberEngFamilyName"].ToString();
					}
					if(dt.Rows[n]["MemberEngGivenName"]!=null && dt.Rows[n]["MemberEngGivenName"].ToString()!="")
					{
					model.MemberEngGivenName=dt.Rows[n]["MemberEngGivenName"].ToString();
					}
					if(dt.Rows[n]["MemberChiFamilyName"]!=null && dt.Rows[n]["MemberChiFamilyName"].ToString()!="")
					{
					model.MemberChiFamilyName=dt.Rows[n]["MemberChiFamilyName"].ToString();
					}
					if(dt.Rows[n]["MemberChiGivenName"]!=null && dt.Rows[n]["MemberChiGivenName"].ToString()!="")
					{
					model.MemberChiGivenName=dt.Rows[n]["MemberChiGivenName"].ToString();
					}
					if(dt.Rows[n]["MemberSex"]!=null && dt.Rows[n]["MemberSex"].ToString()!="")
					{
						model.MemberSex=int.Parse(dt.Rows[n]["MemberSex"].ToString());
					}
					if(dt.Rows[n]["MemberDateOfBirth"]!=null && dt.Rows[n]["MemberDateOfBirth"].ToString()!="")
					{
						model.MemberDateOfBirth=DateTime.Parse(dt.Rows[n]["MemberDateOfBirth"].ToString());
					}
					if(dt.Rows[n]["MemberDayOfBirth"]!=null && dt.Rows[n]["MemberDayOfBirth"].ToString()!="")
					{
						model.MemberDayOfBirth=int.Parse(dt.Rows[n]["MemberDayOfBirth"].ToString());
					}
					if(dt.Rows[n]["MemberMonthOfBirth"]!=null && dt.Rows[n]["MemberMonthOfBirth"].ToString()!="")
					{
						model.MemberMonthOfBirth=int.Parse(dt.Rows[n]["MemberMonthOfBirth"].ToString());
					}
					if(dt.Rows[n]["MemberYearOfBirth"]!=null && dt.Rows[n]["MemberYearOfBirth"].ToString()!="")
					{
						model.MemberYearOfBirth=int.Parse(dt.Rows[n]["MemberYearOfBirth"].ToString());
					}
					if(dt.Rows[n]["MemberMarital"]!=null && dt.Rows[n]["MemberMarital"].ToString()!="")
					{
						model.MemberMarital=int.Parse(dt.Rows[n]["MemberMarital"].ToString());
					}
					if(dt.Rows[n]["HomeAddress"]!=null && dt.Rows[n]["HomeAddress"].ToString()!="")
					{
					model.HomeAddress=dt.Rows[n]["HomeAddress"].ToString();
					}
					if(dt.Rows[n]["HomeTelNum"]!=null && dt.Rows[n]["HomeTelNum"].ToString()!="")
					{
					model.HomeTelNum=dt.Rows[n]["HomeTelNum"].ToString();
					}
					if(dt.Rows[n]["HomeFaxNum"]!=null && dt.Rows[n]["HomeFaxNum"].ToString()!="")
					{
					model.HomeFaxNum=dt.Rows[n]["HomeFaxNum"].ToString();
					}
					if(dt.Rows[n]["OfficeAddress"]!=null && dt.Rows[n]["OfficeAddress"].ToString()!="")
					{
					model.OfficeAddress=dt.Rows[n]["OfficeAddress"].ToString();
					}
					if(dt.Rows[n]["OfficeTelNum"]!=null && dt.Rows[n]["OfficeTelNum"].ToString()!="")
					{
					model.OfficeTelNum=dt.Rows[n]["OfficeTelNum"].ToString();
					}
					if(dt.Rows[n]["OfficeFaxNum"]!=null && dt.Rows[n]["OfficeFaxNum"].ToString()!="")
					{
					model.OfficeFaxNum=dt.Rows[n]["OfficeFaxNum"].ToString();
					}
					if(dt.Rows[n]["EducationID"]!=null && dt.Rows[n]["EducationID"].ToString()!="")
					{
						model.EducationID=int.Parse(dt.Rows[n]["EducationID"].ToString());
					}
					if(dt.Rows[n]["ProfessionID"]!=null && dt.Rows[n]["ProfessionID"].ToString()!="")
					{
						model.ProfessionID=int.Parse(dt.Rows[n]["ProfessionID"].ToString());
					}
					if(dt.Rows[n]["MemberPosition"]!=null && dt.Rows[n]["MemberPosition"].ToString()!="")
					{
					model.MemberPosition=dt.Rows[n]["MemberPosition"].ToString();
					}
					if(dt.Rows[n]["NationID"]!=null && dt.Rows[n]["NationID"].ToString()!="")
					{
						model.NationID=int.Parse(dt.Rows[n]["NationID"].ToString());
					}
					if(dt.Rows[n]["CompanyDesc"]!=null && dt.Rows[n]["CompanyDesc"].ToString()!="")
					{
					model.CompanyDesc=dt.Rows[n]["CompanyDesc"].ToString();
					}
					if(dt.Rows[n]["SpRemark"]!=null && dt.Rows[n]["SpRemark"].ToString()!="")
					{
					model.SpRemark=dt.Rows[n]["SpRemark"].ToString();
					}
					if(dt.Rows[n]["OtherContact"]!=null && dt.Rows[n]["OtherContact"].ToString()!="")
					{
					model.OtherContact=dt.Rows[n]["OtherContact"].ToString();
					}
					if(dt.Rows[n]["Hobbies"]!=null && dt.Rows[n]["Hobbies"].ToString()!="")
					{
					model.Hobbies=dt.Rows[n]["Hobbies"].ToString();
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if(dt.Rows[n]["MemberDefLanguage"]!=null && dt.Rows[n]["MemberDefLanguage"].ToString()!="")
					{
						model.MemberDefLanguage=int.Parse(dt.Rows[n]["MemberDefLanguage"].ToString());
					}
					if(dt.Rows[n]["CreatedOn"]!=null && dt.Rows[n]["CreatedOn"].ToString()!="")
					{
						model.CreatedOn=DateTime.Parse(dt.Rows[n]["CreatedOn"].ToString());
					}
					if(dt.Rows[n]["UpdatedOn"]!=null && dt.Rows[n]["UpdatedOn"].ToString()!="")
					{
						model.UpdatedOn=DateTime.Parse(dt.Rows[n]["UpdatedOn"].ToString());
					}
					if(dt.Rows[n]["CreatedBy"]!=null && dt.Rows[n]["CreatedBy"].ToString()!="")
					{
						model.CreatedBy=int.Parse(dt.Rows[n]["CreatedBy"].ToString());
					}
					if(dt.Rows[n]["UpdatedBy"]!=null && dt.Rows[n]["UpdatedBy"].ToString()!="")
					{
						model.UpdatedBy=int.Parse(dt.Rows[n]["UpdatedBy"].ToString());
					}
					if(dt.Rows[n]["PasswordExpiryDate"]!=null && dt.Rows[n]["PasswordExpiryDate"].ToString()!="")
					{
						model.PasswordExpiryDate=DateTime.Parse(dt.Rows[n]["PasswordExpiryDate"].ToString());
					}
					if(dt.Rows[n]["PWDExpiryPromptDays"]!=null && dt.Rows[n]["PWDExpiryPromptDays"].ToString()!="")
					{
						model.PWDExpiryPromptDays=int.Parse(dt.Rows[n]["PWDExpiryPromptDays"].ToString());
					}
					if(dt.Rows[n]["CountryCode"]!=null && dt.Rows[n]["CountryCode"].ToString()!="")
					{
					model.CountryCode=dt.Rows[n]["CountryCode"].ToString();
					}
					if(dt.Rows[n]["NickName"]!=null && dt.Rows[n]["NickName"].ToString()!="")
					{
					model.NickName=dt.Rows[n]["NickName"].ToString();
					}
					if(dt.Rows[n]["MemberPictureFile"]!=null && dt.Rows[n]["MemberPictureFile"].ToString()!="")
					{
					model.MemberPictureFile=dt.Rows[n]["MemberPictureFile"].ToString();
					}
					if(dt.Rows[n]["MemberPicture"]!=null && dt.Rows[n]["MemberPicture"].ToString()!="")
					{
						model.MemberPicture=(byte[])dt.Rows[n]["MemberPicture"];
					}
					if(dt.Rows[n]["ReadReguFlag"]!=null && dt.Rows[n]["ReadReguFlag"].ToString()!="")
					{
						model.ReadReguFlag=int.Parse(dt.Rows[n]["ReadReguFlag"].ToString());
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

