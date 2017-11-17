using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Member
	/// </summary>
	public partial class Member:IMember
	{
		public Member()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MemberID", "Member"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MemberID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Member");
			strSql.Append(" where MemberID=@MemberID");
			SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.Int,4)
};
			parameters[0].Value = MemberID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.Member model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Member(");
			strSql.Append("MemberPassword,MemberIdentityType,MemberIdentityRef,MemberRegisterMobile,MemberMobilePhone,MemberEmail,MemberAppellation,MemberEngFamilyName,MemberEngGivenName,MemberChiFamilyName,MemberChiGivenName,MemberSex,MemberDateOfBirth,MemberDayOfBirth,MemberMonthOfBirth,MemberYearOfBirth,MemberMarital,HomeAddress,HomeTelNum,HomeFaxNum,OfficeAddress,OfficeTelNum,OfficeFaxNum,EducationID,ProfessionID,MemberPosition,NationID,CompanyDesc,SpRemark,OtherContact,Hobbies,Status,MemberDefLanguage,CreatedOn,UpdatedOn,CreatedBy,UpdatedBy,PasswordExpiryDate,PWDExpiryPromptDays,CountryCode,NickName,MemberPictureFile,MemberPicture,ReadReguFlag)");
			strSql.Append(" values (");
			strSql.Append("@MemberPassword,@MemberIdentityType,@MemberIdentityRef,@MemberRegisterMobile,@MemberMobilePhone,@MemberEmail,@MemberAppellation,@MemberEngFamilyName,@MemberEngGivenName,@MemberChiFamilyName,@MemberChiGivenName,@MemberSex,@MemberDateOfBirth,@MemberDayOfBirth,@MemberMonthOfBirth,@MemberYearOfBirth,@MemberMarital,@HomeAddress,@HomeTelNum,@HomeFaxNum,@OfficeAddress,@OfficeTelNum,@OfficeFaxNum,@EducationID,@ProfessionID,@MemberPosition,@NationID,@CompanyDesc,@SpRemark,@OtherContact,@Hobbies,@Status,@MemberDefLanguage,@CreatedOn,@UpdatedOn,@CreatedBy,@UpdatedBy,@PasswordExpiryDate,@PWDExpiryPromptDays,@CountryCode,@NickName,@MemberPictureFile,@MemberPicture,@ReadReguFlag)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MemberPassword", SqlDbType.VarChar,512),
					new SqlParameter("@MemberIdentityType", SqlDbType.Int,4),
					new SqlParameter("@MemberIdentityRef", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberRegisterMobile", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberMobilePhone", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberEmail", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberAppellation", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberEngFamilyName", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberEngGivenName", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberChiFamilyName", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberChiGivenName", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberSex", SqlDbType.Int,4),
					new SqlParameter("@MemberDateOfBirth", SqlDbType.DateTime),
					new SqlParameter("@MemberDayOfBirth", SqlDbType.Int,4),
					new SqlParameter("@MemberMonthOfBirth", SqlDbType.Int,4),
					new SqlParameter("@MemberYearOfBirth", SqlDbType.Int,4),
					new SqlParameter("@MemberMarital", SqlDbType.Int,4),
					new SqlParameter("@HomeAddress", SqlDbType.NVarChar,512),
					new SqlParameter("@HomeTelNum", SqlDbType.NVarChar,512),
					new SqlParameter("@HomeFaxNum", SqlDbType.NVarChar,512),
					new SqlParameter("@OfficeAddress", SqlDbType.NVarChar,512),
					new SqlParameter("@OfficeTelNum", SqlDbType.NVarChar,512),
					new SqlParameter("@OfficeFaxNum", SqlDbType.NVarChar,512),
					new SqlParameter("@EducationID", SqlDbType.Int,4),
					new SqlParameter("@ProfessionID", SqlDbType.Int,4),
					new SqlParameter("@MemberPosition", SqlDbType.NVarChar,512),
					new SqlParameter("@NationID", SqlDbType.Int,4),
					new SqlParameter("@CompanyDesc", SqlDbType.NVarChar,512),
					new SqlParameter("@SpRemark", SqlDbType.NVarChar,512),
					new SqlParameter("@OtherContact", SqlDbType.NVarChar,512),
					new SqlParameter("@Hobbies", SqlDbType.NVarChar,512),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@MemberDefLanguage", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@PasswordExpiryDate", SqlDbType.DateTime),
					new SqlParameter("@PWDExpiryPromptDays", SqlDbType.Int,4),
					new SqlParameter("@CountryCode", SqlDbType.VarChar,64),
					new SqlParameter("@NickName", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberPictureFile", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberPicture", SqlDbType.VarBinary),
					new SqlParameter("@ReadReguFlag", SqlDbType.Int,4)};
			parameters[0].Value = model.MemberPassword;
			parameters[1].Value = model.MemberIdentityType;
			parameters[2].Value = model.MemberIdentityRef;
			parameters[3].Value = model.MemberRegisterMobile;
			parameters[4].Value = model.MemberMobilePhone;
			parameters[5].Value = model.MemberEmail;
			parameters[6].Value = model.MemberAppellation;
			parameters[7].Value = model.MemberEngFamilyName;
			parameters[8].Value = model.MemberEngGivenName;
			parameters[9].Value = model.MemberChiFamilyName;
			parameters[10].Value = model.MemberChiGivenName;
			parameters[11].Value = model.MemberSex;
			parameters[12].Value = model.MemberDateOfBirth;
			parameters[13].Value = model.MemberDayOfBirth;
			parameters[14].Value = model.MemberMonthOfBirth;
			parameters[15].Value = model.MemberYearOfBirth;
			parameters[16].Value = model.MemberMarital;
			parameters[17].Value = model.HomeAddress;
			parameters[18].Value = model.HomeTelNum;
			parameters[19].Value = model.HomeFaxNum;
			parameters[20].Value = model.OfficeAddress;
			parameters[21].Value = model.OfficeTelNum;
			parameters[22].Value = model.OfficeFaxNum;
			parameters[23].Value = model.EducationID;
			parameters[24].Value = model.ProfessionID;
			parameters[25].Value = model.MemberPosition;
			parameters[26].Value = model.NationID;
			parameters[27].Value = model.CompanyDesc;
			parameters[28].Value = model.SpRemark;
			parameters[29].Value = model.OtherContact;
			parameters[30].Value = model.Hobbies;
			parameters[31].Value = model.Status;
			parameters[32].Value = model.MemberDefLanguage;
			parameters[33].Value = model.CreatedOn;
			parameters[34].Value = model.UpdatedOn;
			parameters[35].Value = model.CreatedBy;
			parameters[36].Value = model.UpdatedBy;
			parameters[37].Value = model.PasswordExpiryDate;
			parameters[38].Value = model.PWDExpiryPromptDays;
			parameters[39].Value = model.CountryCode;
			parameters[40].Value = model.NickName;
			parameters[41].Value = model.MemberPictureFile;
			parameters[42].Value = model.MemberPicture;
			parameters[43].Value = model.ReadReguFlag;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Member model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Member set ");
			strSql.Append("MemberPassword=@MemberPassword,");
			strSql.Append("MemberIdentityType=@MemberIdentityType,");
			strSql.Append("MemberIdentityRef=@MemberIdentityRef,");
			strSql.Append("MemberRegisterMobile=@MemberRegisterMobile,");
			strSql.Append("MemberMobilePhone=@MemberMobilePhone,");
			strSql.Append("MemberEmail=@MemberEmail,");
			strSql.Append("MemberAppellation=@MemberAppellation,");
			strSql.Append("MemberEngFamilyName=@MemberEngFamilyName,");
			strSql.Append("MemberEngGivenName=@MemberEngGivenName,");
			strSql.Append("MemberChiFamilyName=@MemberChiFamilyName,");
			strSql.Append("MemberChiGivenName=@MemberChiGivenName,");
			strSql.Append("MemberSex=@MemberSex,");
			strSql.Append("MemberDateOfBirth=@MemberDateOfBirth,");
			strSql.Append("MemberDayOfBirth=@MemberDayOfBirth,");
			strSql.Append("MemberMonthOfBirth=@MemberMonthOfBirth,");
			strSql.Append("MemberYearOfBirth=@MemberYearOfBirth,");
			strSql.Append("MemberMarital=@MemberMarital,");
			strSql.Append("HomeAddress=@HomeAddress,");
			strSql.Append("HomeTelNum=@HomeTelNum,");
			strSql.Append("HomeFaxNum=@HomeFaxNum,");
			strSql.Append("OfficeAddress=@OfficeAddress,");
			strSql.Append("OfficeTelNum=@OfficeTelNum,");
			strSql.Append("OfficeFaxNum=@OfficeFaxNum,");
			strSql.Append("EducationID=@EducationID,");
			strSql.Append("ProfessionID=@ProfessionID,");
			strSql.Append("MemberPosition=@MemberPosition,");
			strSql.Append("NationID=@NationID,");
			strSql.Append("CompanyDesc=@CompanyDesc,");
			strSql.Append("SpRemark=@SpRemark,");
			strSql.Append("OtherContact=@OtherContact,");
			strSql.Append("Hobbies=@Hobbies,");
			strSql.Append("Status=@Status,");
			strSql.Append("MemberDefLanguage=@MemberDefLanguage,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("PasswordExpiryDate=@PasswordExpiryDate,");
			strSql.Append("PWDExpiryPromptDays=@PWDExpiryPromptDays,");
			strSql.Append("CountryCode=@CountryCode,");
			strSql.Append("NickName=@NickName,");
			strSql.Append("MemberPictureFile=@MemberPictureFile,");
			strSql.Append("MemberPicture=@MemberPicture,");
			strSql.Append("ReadReguFlag=@ReadReguFlag");
			strSql.Append(" where MemberID=@MemberID");
			SqlParameter[] parameters = {
					new SqlParameter("@MemberPassword", SqlDbType.VarChar,512),
					new SqlParameter("@MemberIdentityType", SqlDbType.Int,4),
					new SqlParameter("@MemberIdentityRef", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberRegisterMobile", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberMobilePhone", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberEmail", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberAppellation", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberEngFamilyName", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberEngGivenName", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberChiFamilyName", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberChiGivenName", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberSex", SqlDbType.Int,4),
					new SqlParameter("@MemberDateOfBirth", SqlDbType.DateTime),
					new SqlParameter("@MemberDayOfBirth", SqlDbType.Int,4),
					new SqlParameter("@MemberMonthOfBirth", SqlDbType.Int,4),
					new SqlParameter("@MemberYearOfBirth", SqlDbType.Int,4),
					new SqlParameter("@MemberMarital", SqlDbType.Int,4),
					new SqlParameter("@HomeAddress", SqlDbType.NVarChar,512),
					new SqlParameter("@HomeTelNum", SqlDbType.NVarChar,512),
					new SqlParameter("@HomeFaxNum", SqlDbType.NVarChar,512),
					new SqlParameter("@OfficeAddress", SqlDbType.NVarChar,512),
					new SqlParameter("@OfficeTelNum", SqlDbType.NVarChar,512),
					new SqlParameter("@OfficeFaxNum", SqlDbType.NVarChar,512),
					new SqlParameter("@EducationID", SqlDbType.Int,4),
					new SqlParameter("@ProfessionID", SqlDbType.Int,4),
					new SqlParameter("@MemberPosition", SqlDbType.NVarChar,512),
					new SqlParameter("@NationID", SqlDbType.Int,4),
					new SqlParameter("@CompanyDesc", SqlDbType.NVarChar,512),
					new SqlParameter("@SpRemark", SqlDbType.NVarChar,512),
					new SqlParameter("@OtherContact", SqlDbType.NVarChar,512),
					new SqlParameter("@Hobbies", SqlDbType.NVarChar,512),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@MemberDefLanguage", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@PasswordExpiryDate", SqlDbType.DateTime),
					new SqlParameter("@PWDExpiryPromptDays", SqlDbType.Int,4),
					new SqlParameter("@CountryCode", SqlDbType.VarChar,64),
					new SqlParameter("@NickName", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberPictureFile", SqlDbType.NVarChar,512),
					new SqlParameter("@MemberPicture", SqlDbType.VarBinary),
					new SqlParameter("@ReadReguFlag", SqlDbType.Int,4),
					new SqlParameter("@MemberID", SqlDbType.Int,4)};
			parameters[0].Value = model.MemberPassword;
			parameters[1].Value = model.MemberIdentityType;
			parameters[2].Value = model.MemberIdentityRef;
			parameters[3].Value = model.MemberRegisterMobile;
			parameters[4].Value = model.MemberMobilePhone;
			parameters[5].Value = model.MemberEmail;
			parameters[6].Value = model.MemberAppellation;
			parameters[7].Value = model.MemberEngFamilyName;
			parameters[8].Value = model.MemberEngGivenName;
			parameters[9].Value = model.MemberChiFamilyName;
			parameters[10].Value = model.MemberChiGivenName;
			parameters[11].Value = model.MemberSex;
			parameters[12].Value = model.MemberDateOfBirth;
			parameters[13].Value = model.MemberDayOfBirth;
			parameters[14].Value = model.MemberMonthOfBirth;
			parameters[15].Value = model.MemberYearOfBirth;
			parameters[16].Value = model.MemberMarital;
			parameters[17].Value = model.HomeAddress;
			parameters[18].Value = model.HomeTelNum;
			parameters[19].Value = model.HomeFaxNum;
			parameters[20].Value = model.OfficeAddress;
			parameters[21].Value = model.OfficeTelNum;
			parameters[22].Value = model.OfficeFaxNum;
			parameters[23].Value = model.EducationID;
			parameters[24].Value = model.ProfessionID;
			parameters[25].Value = model.MemberPosition;
			parameters[26].Value = model.NationID;
			parameters[27].Value = model.CompanyDesc;
			parameters[28].Value = model.SpRemark;
			parameters[29].Value = model.OtherContact;
			parameters[30].Value = model.Hobbies;
			parameters[31].Value = model.Status;
			parameters[32].Value = model.MemberDefLanguage;
			parameters[33].Value = model.CreatedOn;
			parameters[34].Value = model.UpdatedOn;
			parameters[35].Value = model.CreatedBy;
			parameters[36].Value = model.UpdatedBy;
			parameters[37].Value = model.PasswordExpiryDate;
			parameters[38].Value = model.PWDExpiryPromptDays;
			parameters[39].Value = model.CountryCode;
			parameters[40].Value = model.NickName;
			parameters[41].Value = model.MemberPictureFile;
			parameters[42].Value = model.MemberPicture;
			parameters[43].Value = model.ReadReguFlag;
			parameters[44].Value = model.MemberID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MemberID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Member ");
			strSql.Append(" where MemberID=@MemberID");
			SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.Int,4)
};
			parameters[0].Value = MemberID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string MemberIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Member ");
			strSql.Append(" where MemberID in ("+MemberIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Member GetModel(int MemberID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MemberID,MemberPassword,MemberIdentityType,MemberIdentityRef,MemberRegisterMobile,MemberMobilePhone,MemberEmail,MemberAppellation,MemberEngFamilyName,MemberEngGivenName,MemberChiFamilyName,MemberChiGivenName,MemberSex,MemberDateOfBirth,MemberDayOfBirth,MemberMonthOfBirth,MemberYearOfBirth,MemberMarital,HomeAddress,HomeTelNum,HomeFaxNum,OfficeAddress,OfficeTelNum,OfficeFaxNum,EducationID,ProfessionID,MemberPosition,NationID,CompanyDesc,SpRemark,OtherContact,Hobbies,Status,MemberDefLanguage,CreatedOn,UpdatedOn,CreatedBy,UpdatedBy,PasswordExpiryDate,PWDExpiryPromptDays,CountryCode,NickName,MemberPictureFile,MemberPicture,ReadReguFlag from Member ");
			strSql.Append(" where MemberID=@MemberID");
			SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.Int,4)
};
			parameters[0].Value = MemberID;

			Edge.SVA.Model.Member model=new Edge.SVA.Model.Member();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["MemberID"]!=null && ds.Tables[0].Rows[0]["MemberID"].ToString()!="")
				{
					model.MemberID=int.Parse(ds.Tables[0].Rows[0]["MemberID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberPassword"]!=null && ds.Tables[0].Rows[0]["MemberPassword"].ToString()!="")
				{
					model.MemberPassword=ds.Tables[0].Rows[0]["MemberPassword"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemberIdentityType"]!=null && ds.Tables[0].Rows[0]["MemberIdentityType"].ToString()!="")
				{
					model.MemberIdentityType=int.Parse(ds.Tables[0].Rows[0]["MemberIdentityType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberIdentityRef"]!=null && ds.Tables[0].Rows[0]["MemberIdentityRef"].ToString()!="")
				{
					model.MemberIdentityRef=ds.Tables[0].Rows[0]["MemberIdentityRef"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemberRegisterMobile"]!=null && ds.Tables[0].Rows[0]["MemberRegisterMobile"].ToString()!="")
				{
					model.MemberRegisterMobile=ds.Tables[0].Rows[0]["MemberRegisterMobile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemberMobilePhone"]!=null && ds.Tables[0].Rows[0]["MemberMobilePhone"].ToString()!="")
				{
					model.MemberMobilePhone=ds.Tables[0].Rows[0]["MemberMobilePhone"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemberEmail"]!=null && ds.Tables[0].Rows[0]["MemberEmail"].ToString()!="")
				{
					model.MemberEmail=ds.Tables[0].Rows[0]["MemberEmail"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemberAppellation"]!=null && ds.Tables[0].Rows[0]["MemberAppellation"].ToString()!="")
				{
					model.MemberAppellation=ds.Tables[0].Rows[0]["MemberAppellation"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemberEngFamilyName"]!=null && ds.Tables[0].Rows[0]["MemberEngFamilyName"].ToString()!="")
				{
					model.MemberEngFamilyName=ds.Tables[0].Rows[0]["MemberEngFamilyName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemberEngGivenName"]!=null && ds.Tables[0].Rows[0]["MemberEngGivenName"].ToString()!="")
				{
					model.MemberEngGivenName=ds.Tables[0].Rows[0]["MemberEngGivenName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemberChiFamilyName"]!=null && ds.Tables[0].Rows[0]["MemberChiFamilyName"].ToString()!="")
				{
					model.MemberChiFamilyName=ds.Tables[0].Rows[0]["MemberChiFamilyName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemberChiGivenName"]!=null && ds.Tables[0].Rows[0]["MemberChiGivenName"].ToString()!="")
				{
					model.MemberChiGivenName=ds.Tables[0].Rows[0]["MemberChiGivenName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemberSex"]!=null && ds.Tables[0].Rows[0]["MemberSex"].ToString()!="")
				{
					model.MemberSex=int.Parse(ds.Tables[0].Rows[0]["MemberSex"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberDateOfBirth"]!=null && ds.Tables[0].Rows[0]["MemberDateOfBirth"].ToString()!="")
				{
					model.MemberDateOfBirth=DateTime.Parse(ds.Tables[0].Rows[0]["MemberDateOfBirth"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberDayOfBirth"]!=null && ds.Tables[0].Rows[0]["MemberDayOfBirth"].ToString()!="")
				{
					model.MemberDayOfBirth=int.Parse(ds.Tables[0].Rows[0]["MemberDayOfBirth"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberMonthOfBirth"]!=null && ds.Tables[0].Rows[0]["MemberMonthOfBirth"].ToString()!="")
				{
					model.MemberMonthOfBirth=int.Parse(ds.Tables[0].Rows[0]["MemberMonthOfBirth"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberYearOfBirth"]!=null && ds.Tables[0].Rows[0]["MemberYearOfBirth"].ToString()!="")
				{
					model.MemberYearOfBirth=int.Parse(ds.Tables[0].Rows[0]["MemberYearOfBirth"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberMarital"]!=null && ds.Tables[0].Rows[0]["MemberMarital"].ToString()!="")
				{
					model.MemberMarital=int.Parse(ds.Tables[0].Rows[0]["MemberMarital"].ToString());
				}
				if(ds.Tables[0].Rows[0]["HomeAddress"]!=null && ds.Tables[0].Rows[0]["HomeAddress"].ToString()!="")
				{
					model.HomeAddress=ds.Tables[0].Rows[0]["HomeAddress"].ToString();
				}
				if(ds.Tables[0].Rows[0]["HomeTelNum"]!=null && ds.Tables[0].Rows[0]["HomeTelNum"].ToString()!="")
				{
					model.HomeTelNum=ds.Tables[0].Rows[0]["HomeTelNum"].ToString();
				}
				if(ds.Tables[0].Rows[0]["HomeFaxNum"]!=null && ds.Tables[0].Rows[0]["HomeFaxNum"].ToString()!="")
				{
					model.HomeFaxNum=ds.Tables[0].Rows[0]["HomeFaxNum"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OfficeAddress"]!=null && ds.Tables[0].Rows[0]["OfficeAddress"].ToString()!="")
				{
					model.OfficeAddress=ds.Tables[0].Rows[0]["OfficeAddress"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OfficeTelNum"]!=null && ds.Tables[0].Rows[0]["OfficeTelNum"].ToString()!="")
				{
					model.OfficeTelNum=ds.Tables[0].Rows[0]["OfficeTelNum"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OfficeFaxNum"]!=null && ds.Tables[0].Rows[0]["OfficeFaxNum"].ToString()!="")
				{
					model.OfficeFaxNum=ds.Tables[0].Rows[0]["OfficeFaxNum"].ToString();
				}
				if(ds.Tables[0].Rows[0]["EducationID"]!=null && ds.Tables[0].Rows[0]["EducationID"].ToString()!="")
				{
					model.EducationID=int.Parse(ds.Tables[0].Rows[0]["EducationID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProfessionID"]!=null && ds.Tables[0].Rows[0]["ProfessionID"].ToString()!="")
				{
					model.ProfessionID=int.Parse(ds.Tables[0].Rows[0]["ProfessionID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberPosition"]!=null && ds.Tables[0].Rows[0]["MemberPosition"].ToString()!="")
				{
					model.MemberPosition=ds.Tables[0].Rows[0]["MemberPosition"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NationID"]!=null && ds.Tables[0].Rows[0]["NationID"].ToString()!="")
				{
					model.NationID=int.Parse(ds.Tables[0].Rows[0]["NationID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CompanyDesc"]!=null && ds.Tables[0].Rows[0]["CompanyDesc"].ToString()!="")
				{
					model.CompanyDesc=ds.Tables[0].Rows[0]["CompanyDesc"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SpRemark"]!=null && ds.Tables[0].Rows[0]["SpRemark"].ToString()!="")
				{
					model.SpRemark=ds.Tables[0].Rows[0]["SpRemark"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OtherContact"]!=null && ds.Tables[0].Rows[0]["OtherContact"].ToString()!="")
				{
					model.OtherContact=ds.Tables[0].Rows[0]["OtherContact"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Hobbies"]!=null && ds.Tables[0].Rows[0]["Hobbies"].ToString()!="")
				{
					model.Hobbies=ds.Tables[0].Rows[0]["Hobbies"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberDefLanguage"]!=null && ds.Tables[0].Rows[0]["MemberDefLanguage"].ToString()!="")
				{
					model.MemberDefLanguage=int.Parse(ds.Tables[0].Rows[0]["MemberDefLanguage"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedOn"]!=null && ds.Tables[0].Rows[0]["CreatedOn"].ToString()!="")
				{
					model.CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedOn"]!=null && ds.Tables[0].Rows[0]["UpdatedOn"].ToString()!="")
				{
					model.UpdatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedBy"]!=null && ds.Tables[0].Rows[0]["CreatedBy"].ToString()!="")
				{
					model.CreatedBy=int.Parse(ds.Tables[0].Rows[0]["CreatedBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedBy"]!=null && ds.Tables[0].Rows[0]["UpdatedBy"].ToString()!="")
				{
					model.UpdatedBy=int.Parse(ds.Tables[0].Rows[0]["UpdatedBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PasswordExpiryDate"]!=null && ds.Tables[0].Rows[0]["PasswordExpiryDate"].ToString()!="")
				{
					model.PasswordExpiryDate=DateTime.Parse(ds.Tables[0].Rows[0]["PasswordExpiryDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PWDExpiryPromptDays"]!=null && ds.Tables[0].Rows[0]["PWDExpiryPromptDays"].ToString()!="")
				{
					model.PWDExpiryPromptDays=int.Parse(ds.Tables[0].Rows[0]["PWDExpiryPromptDays"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CountryCode"]!=null && ds.Tables[0].Rows[0]["CountryCode"].ToString()!="")
				{
					model.CountryCode=ds.Tables[0].Rows[0]["CountryCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NickName"]!=null && ds.Tables[0].Rows[0]["NickName"].ToString()!="")
				{
					model.NickName=ds.Tables[0].Rows[0]["NickName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemberPictureFile"]!=null && ds.Tables[0].Rows[0]["MemberPictureFile"].ToString()!="")
				{
					model.MemberPictureFile=ds.Tables[0].Rows[0]["MemberPictureFile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemberPicture"]!=null && ds.Tables[0].Rows[0]["MemberPicture"].ToString()!="")
				{
					model.MemberPicture=(byte[])ds.Tables[0].Rows[0]["MemberPicture"];
				}
				if(ds.Tables[0].Rows[0]["ReadReguFlag"]!=null && ds.Tables[0].Rows[0]["ReadReguFlag"].ToString()!="")
				{
					model.ReadReguFlag=int.Parse(ds.Tables[0].Rows[0]["ReadReguFlag"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MemberID,MemberPassword,MemberIdentityType,MemberIdentityRef,MemberRegisterMobile,MemberMobilePhone,MemberEmail,MemberAppellation,MemberEngFamilyName,MemberEngGivenName,MemberChiFamilyName,MemberChiGivenName,MemberSex,MemberDateOfBirth,MemberDayOfBirth,MemberMonthOfBirth,MemberYearOfBirth,MemberMarital,HomeAddress,HomeTelNum,HomeFaxNum,OfficeAddress,OfficeTelNum,OfficeFaxNum,EducationID,ProfessionID,MemberPosition,NationID,CompanyDesc,SpRemark,OtherContact,Hobbies,Status,MemberDefLanguage,CreatedOn,UpdatedOn,CreatedBy,UpdatedBy,PasswordExpiryDate,PWDExpiryPromptDays,CountryCode,NickName,MemberPictureFile,MemberPicture,ReadReguFlag ");
			strSql.Append(" FROM Member ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" MemberID,MemberPassword,MemberIdentityType,MemberIdentityRef,MemberRegisterMobile,MemberMobilePhone,MemberEmail,MemberAppellation,MemberEngFamilyName,MemberEngGivenName,MemberChiFamilyName,MemberChiGivenName,MemberSex,MemberDateOfBirth,MemberDayOfBirth,MemberMonthOfBirth,MemberYearOfBirth,MemberMarital,HomeAddress,HomeTelNum,HomeFaxNum,OfficeAddress,OfficeTelNum,OfficeFaxNum,EducationID,ProfessionID,MemberPosition,NationID,CompanyDesc,SpRemark,OtherContact,Hobbies,Status,MemberDefLanguage,CreatedOn,UpdatedOn,CreatedBy,UpdatedBy,PasswordExpiryDate,PWDExpiryPromptDays,CountryCode,NickName,MemberPictureFile,MemberPicture,ReadReguFlag ");
			strSql.Append(" FROM Member ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder)
        {
            int OrderType = 0;
            string OrderField = filedOrder;
            if (filedOrder.ToLower().EndsWith(" desc"))
            {
                OrderType = 1;
                OrderField = filedOrder.Substring(0, filedOrder.ToLower().IndexOf(" desc"));
            }
            else if (filedOrder.ToLower().EndsWith(" asc"))
            {
                OrderField = filedOrder.Substring(0, filedOrder.ToLower().IndexOf(" asc"));
            }
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@OrderfldName",SqlDbType.VarChar,255),
                    new SqlParameter("@StatfldName",SqlDbType.VarChar,255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.NText),
					};
            parameters[0].Value = "Member";
            parameters[1].Value = "*";
            parameters[2].Value = OrderField;
            parameters[3].Value = "";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 0;
            parameters[7].Value = OrderType;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPageOrder", parameters, "ds");
        }

        /// <summary>
        /// 获取行总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select count(*) from Member ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

