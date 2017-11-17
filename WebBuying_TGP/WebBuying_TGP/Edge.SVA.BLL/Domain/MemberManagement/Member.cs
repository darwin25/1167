using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Edge.DBUtility;

namespace Edge.SVA.BLL.Domain.MemberManagement
{
    public class Member
    {
        public int AddData(Edge.SVA.Model.Member model, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
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

            //将空值赋值为默认值
            foreach (SqlParameter parameter in parameters)
            {
                if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;
                }
            }

            //添加主表时需要返回主键ID
            object id = SqlHelper.NewExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL

            return Convert.ToInt32(id);
        }

        public void UpdateData(Edge.SVA.Model.Member model, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
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

            //将空值赋值为默认值
            foreach (SqlParameter parameter in parameters)
            {
                if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;
                }
            }

            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL
        }

        public void DeleteData(int MemberID, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Member ");
            strSql.Append(" where MemberID=@MemberID");
            SqlParameter[] parameters = { new SqlParameter("@MemberID", SqlDbType.Int, 4) };                                        
            parameters[0].Value = MemberID;

            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL
        }
    }
}
