using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Edge.DBUtility;

namespace Edge.SVA.BLL.Domain.BasicInformationSetting.Advertisements
{
   public class PromotionMsg
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
       public int Add(Edge.SVA.Model.PromotionMsg model, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PromotionMsg(");
            strSql.Append("PromotionTitle1,PromotionTitle2,PromotionTitle3,PromotionMsgStr1,PromotionMsgStr2,PromotionMsgStr3,PromotionPicFile,PromotionRemark,PromptScheduleID,BirthPromotion,DeviceType,StartDate,EndDate,Status,CampaignID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,PromotionMsgTypeID,PromotionMsgCode,AttachmentFilePath)");
            strSql.Append(" values (");
            strSql.Append("@PromotionTitle1,@PromotionTitle2,@PromotionTitle3,@PromotionMsgStr1,@PromotionMsgStr2,@PromotionMsgStr3,@PromotionPicFile,@PromotionRemark,@PromptScheduleID,@BirthPromotion,@DeviceType,@StartDate,@EndDate,@Status,@CampaignID,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@PromotionMsgTypeID,@PromotionMsgCode,@AttachmentFilePath)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PromotionTitle1", SqlDbType.NVarChar,512),
					new SqlParameter("@PromotionTitle2", SqlDbType.NVarChar,512),
					new SqlParameter("@PromotionTitle3", SqlDbType.NVarChar,512),
					new SqlParameter("@PromotionMsgStr1", SqlDbType.NVarChar),
					new SqlParameter("@PromotionMsgStr2", SqlDbType.NVarChar),
					new SqlParameter("@PromotionMsgStr3", SqlDbType.NVarChar),
					new SqlParameter("@PromotionPicFile", SqlDbType.VarChar,512),
					new SqlParameter("@PromotionRemark", SqlDbType.NVarChar,2000),
					new SqlParameter("@PromptScheduleID", SqlDbType.Int,4),
					new SqlParameter("@BirthPromotion", SqlDbType.Int,4),
					new SqlParameter("@DeviceType", SqlDbType.Int,4),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CampaignID", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@PromotionMsgTypeID", SqlDbType.Int,4),
					new SqlParameter("@PromotionMsgCode", SqlDbType.VarChar,64),
					new SqlParameter("@AttachmentFilePath", SqlDbType.NVarChar,512)};
            parameters[0].Value = model.PromotionTitle1;
            parameters[1].Value = model.PromotionTitle2;
            parameters[2].Value = model.PromotionTitle3;
            parameters[3].Value = model.PromotionMsgStr1;
            parameters[4].Value = model.PromotionMsgStr2;
            parameters[5].Value = model.PromotionMsgStr3;
            parameters[6].Value = model.PromotionPicFile;
            parameters[7].Value = model.PromotionRemark;
            parameters[8].Value = model.PromptScheduleID;
            parameters[9].Value = model.BirthPromotion;
            parameters[10].Value = model.DeviceType;
            parameters[11].Value = model.StartDate;
            parameters[12].Value = model.EndDate;
            parameters[13].Value = model.Status;
            parameters[14].Value = model.CampaignID;
            parameters[15].Value = model.CreatedOn;
            parameters[16].Value = model.CreatedBy;
            parameters[17].Value = model.UpdatedOn;
            parameters[18].Value = model.UpdatedBy;
            parameters[19].Value = model.PromotionMsgTypeID;
            parameters[20].Value = model.PromotionMsgCode;
            parameters[21].Value = model.AttachmentFilePath;

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

        /// <summary>
        /// 更新一条数据
        /// </summary>
       public void Update(Edge.SVA.Model.PromotionMsg model, SqlTransaction trans)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update PromotionMsg set ");
           strSql.Append("PromotionTitle1=@PromotionTitle1,");
           strSql.Append("PromotionTitle2=@PromotionTitle2,");
           strSql.Append("PromotionTitle3=@PromotionTitle3,");
           strSql.Append("PromotionMsgStr1=@PromotionMsgStr1,");
           strSql.Append("PromotionMsgStr2=@PromotionMsgStr2,");
           strSql.Append("PromotionMsgStr3=@PromotionMsgStr3,");
           strSql.Append("PromotionPicFile=@PromotionPicFile,");
           strSql.Append("PromotionRemark=@PromotionRemark,");
           strSql.Append("PromptScheduleID=@PromptScheduleID,");
           strSql.Append("BirthPromotion=@BirthPromotion,");
           strSql.Append("DeviceType=@DeviceType,");
           strSql.Append("StartDate=@StartDate,");
           strSql.Append("EndDate=@EndDate,");
           strSql.Append("Status=@Status,");
           strSql.Append("CampaignID=@CampaignID,");
           strSql.Append("CreatedOn=@CreatedOn,");
           strSql.Append("CreatedBy=@CreatedBy,");
           strSql.Append("UpdatedOn=@UpdatedOn,");
           strSql.Append("UpdatedBy=@UpdatedBy,");
           strSql.Append("PromotionMsgTypeID=@PromotionMsgTypeID,");
           strSql.Append("PromotionMsgCode=@PromotionMsgCode,");
           strSql.Append("AttachmentFilePath=@AttachmentFilePath");
           strSql.Append(" where KeyID=@KeyID");
           SqlParameter[] parameters = {
					new SqlParameter("@PromotionTitle1", SqlDbType.NVarChar,512),
					new SqlParameter("@PromotionTitle2", SqlDbType.NVarChar,512),
					new SqlParameter("@PromotionTitle3", SqlDbType.NVarChar,512),
					new SqlParameter("@PromotionMsgStr1", SqlDbType.NVarChar),
					new SqlParameter("@PromotionMsgStr2", SqlDbType.NVarChar),
					new SqlParameter("@PromotionMsgStr3", SqlDbType.NVarChar),
					new SqlParameter("@PromotionPicFile", SqlDbType.VarChar,512),
					new SqlParameter("@PromotionRemark", SqlDbType.NVarChar,2000),
					new SqlParameter("@PromptScheduleID", SqlDbType.Int,4),
					new SqlParameter("@BirthPromotion", SqlDbType.Int,4),
					new SqlParameter("@DeviceType", SqlDbType.Int,4),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CampaignID", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@PromotionMsgTypeID", SqlDbType.Int,4),
					new SqlParameter("@PromotionMsgCode", SqlDbType.VarChar,64),
					new SqlParameter("@AttachmentFilePath", SqlDbType.NVarChar,512),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
           parameters[0].Value = model.PromotionTitle1;
           parameters[1].Value = model.PromotionTitle2;
           parameters[2].Value = model.PromotionTitle3;
           parameters[3].Value = model.PromotionMsgStr1;
           parameters[4].Value = model.PromotionMsgStr2;
           parameters[5].Value = model.PromotionMsgStr3;
           parameters[6].Value = model.PromotionPicFile;
           parameters[7].Value = model.PromotionRemark;
           parameters[8].Value = model.PromptScheduleID;
           parameters[9].Value = model.BirthPromotion;
           parameters[10].Value = model.DeviceType;
           parameters[11].Value = model.StartDate;
           parameters[12].Value = model.EndDate;
           parameters[13].Value = model.Status;
           parameters[14].Value = model.CampaignID;
           parameters[15].Value = model.CreatedOn;
           parameters[16].Value = model.CreatedBy;
           parameters[17].Value = model.UpdatedOn;
           parameters[18].Value = model.UpdatedBy;
           parameters[19].Value = model.PromotionMsgTypeID;
           parameters[20].Value = model.PromotionMsgCode;
           parameters[21].Value = model.AttachmentFilePath;
           parameters[22].Value = model.KeyID;

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

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public void Delete(int KeyID,SqlTransaction trans)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from PromotionMsg ");
           strSql.Append(" where KeyID=@KeyID");
           SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
           parameters[0].Value = KeyID;

           SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL
       }
    }
}
