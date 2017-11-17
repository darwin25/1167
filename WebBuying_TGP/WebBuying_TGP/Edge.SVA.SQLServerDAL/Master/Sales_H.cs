using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Sales_H
	/// </summary>
	public partial class Sales_H:ISales_H
	{
		public Sales_H()
		{}

        #region Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string TransNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sales_H");
            strSql.Append(" where TransNum=@TransNum ");
            SqlParameter[] parameters = {
					new SqlParameter("@TransNum", SqlDbType.VarChar,64)			};
            parameters[0].Value = TransNum;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Edge.SVA.Model.Sales_H model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sales_H(");
            strSql.Append("TransNum,TransType,StoreCode,RegisterCode,BusDate,TxnDate,CashierID,SalesManID,TotalAmount,Status,TransDiscount,TransDiscountType,TransReason,RefTransNum,InvalidateFlag,MemberSalesFlag,MemberID,CardNumber,DeliveryFlag,DeliveryCountry,DeliveryProvince,DeliveryCity,DeliveryDistrict,DeliveryAddressDetail,DeliveryFullAddress,DeliveryNumber,RequestDeliveryDate,DeliveryDate,DeliveryBy,Contact,ContactPhone,PickupType,PickupStoreCode,CODFlag,Remark,SettlementDate,SettlementStaffID,PaySettleDate,CompleteDate,SalesReceipt,SalesReceiptBIN,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,LogisticsProviderID)");
            strSql.Append(" values (");
            strSql.Append("@TransNum,@TransType,@StoreCode,@RegisterCode,@BusDate,@TxnDate,@CashierID,@SalesManID,@TotalAmount,@Status,@TransDiscount,@TransDiscountType,@TransReason,@RefTransNum,@InvalidateFlag,@MemberSalesFlag,@MemberID,@CardNumber,@DeliveryFlag,@DeliveryCountry,@DeliveryProvince,@DeliveryCity,@DeliveryDistrict,@DeliveryAddressDetail,@DeliveryFullAddress,@DeliveryNumber,@RequestDeliveryDate,@DeliveryDate,@DeliveryBy,@Contact,@ContactPhone,@PickupType,@PickupStoreCode,@CODFlag,@Remark,@SettlementDate,@SettlementStaffID,@PaySettleDate,@CompleteDate,@SalesReceipt,@SalesReceiptBIN,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@LogisticsProviderID)");
            SqlParameter[] parameters = {
					new SqlParameter("@TransNum", SqlDbType.VarChar,64),
					new SqlParameter("@TransType", SqlDbType.Int,4),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@RegisterCode", SqlDbType.VarChar,64),
					new SqlParameter("@BusDate", SqlDbType.DateTime),
					new SqlParameter("@TxnDate", SqlDbType.DateTime),
					new SqlParameter("@CashierID", SqlDbType.Int,4),
					new SqlParameter("@SalesManID", SqlDbType.Int,4),
					new SqlParameter("@TotalAmount", SqlDbType.Decimal,9),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@TransDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@TransDiscountType", SqlDbType.Int,4),
					new SqlParameter("@TransReason", SqlDbType.NVarChar,512),
					new SqlParameter("@RefTransNum", SqlDbType.VarChar,64),
					new SqlParameter("@InvalidateFlag", SqlDbType.Int,4),
					new SqlParameter("@MemberSalesFlag", SqlDbType.Int,4),
					new SqlParameter("@MemberID", SqlDbType.VarChar,64),
					new SqlParameter("@CardNumber", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryFlag", SqlDbType.Int,4),
					new SqlParameter("@DeliveryCountry", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryProvince", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryCity", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryDistrict", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryAddressDetail", SqlDbType.NVarChar,512),
					new SqlParameter("@DeliveryFullAddress", SqlDbType.NVarChar,512),
					new SqlParameter("@DeliveryNumber", SqlDbType.VarChar,64),
					new SqlParameter("@RequestDeliveryDate", SqlDbType.DateTime),
					new SqlParameter("@DeliveryDate", SqlDbType.DateTime),
					new SqlParameter("@DeliveryBy", SqlDbType.Int,4),
					new SqlParameter("@Contact", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactPhone", SqlDbType.NVarChar,512),
					new SqlParameter("@PickupType", SqlDbType.Int,4),
					new SqlParameter("@PickupStoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@CODFlag", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@SettlementDate", SqlDbType.DateTime),
					new SqlParameter("@SettlementStaffID", SqlDbType.Int,4),
					new SqlParameter("@PaySettleDate", SqlDbType.DateTime),
					new SqlParameter("@CompleteDate", SqlDbType.DateTime),
					new SqlParameter("@SalesReceipt", SqlDbType.VarChar,-1),
					new SqlParameter("@SalesReceiptBIN", SqlDbType.VarBinary,-1),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@LogisticsProviderID", SqlDbType.Int,4)};
            parameters[0].Value = model.TransNum;
            parameters[1].Value = model.TransType;
            parameters[2].Value = model.StoreCode;
            parameters[3].Value = model.RegisterCode;
            parameters[4].Value = model.BusDate;
            parameters[5].Value = model.TxnDate;
            parameters[6].Value = model.CashierID;
            parameters[7].Value = model.SalesManID;
            parameters[8].Value = model.TotalAmount;
            parameters[9].Value = model.Status;
            parameters[10].Value = model.TransDiscount;
            parameters[11].Value = model.TransDiscountType;
            parameters[12].Value = model.TransReason;
            parameters[13].Value = model.RefTransNum;
            parameters[14].Value = model.InvalidateFlag;
            parameters[15].Value = model.MemberSalesFlag;
            parameters[16].Value = model.MemberID;
            parameters[17].Value = model.CardNumber;
            parameters[18].Value = model.DeliveryFlag;
            parameters[19].Value = model.DeliveryCountry;
            parameters[20].Value = model.DeliveryProvince;
            parameters[21].Value = model.DeliveryCity;
            parameters[22].Value = model.DeliveryDistrict;
            parameters[23].Value = model.DeliveryAddressDetail;
            parameters[24].Value = model.DeliveryFullAddress;
            parameters[25].Value = model.DeliveryNumber;
            parameters[26].Value = model.RequestDeliveryDate;
            parameters[27].Value = model.DeliveryDate;
            parameters[28].Value = model.DeliveryBy;
            parameters[29].Value = model.Contact;
            parameters[30].Value = model.ContactPhone;
            parameters[31].Value = model.PickupType;
            parameters[32].Value = model.PickupStoreCode;
            parameters[33].Value = model.CODFlag;
            parameters[34].Value = model.Remark;
            parameters[35].Value = model.SettlementDate;
            parameters[36].Value = model.SettlementStaffID;
            parameters[37].Value = model.PaySettleDate;
            parameters[38].Value = model.CompleteDate;
            parameters[39].Value = model.SalesReceipt;
            parameters[40].Value = model.SalesReceiptBIN;
            parameters[41].Value = model.CreatedOn;
            parameters[42].Value = model.CreatedBy;
            parameters[43].Value = model.UpdatedOn;
            parameters[44].Value = model.UpdatedBy;
            parameters[45].Value = model.LogisticsProviderID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(Edge.SVA.Model.Sales_H model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sales_H set ");
            strSql.Append("TransType=@TransType,");
            strSql.Append("StoreCode=@StoreCode,");
            strSql.Append("RegisterCode=@RegisterCode,");
            strSql.Append("BusDate=@BusDate,");
            strSql.Append("TxnDate=@TxnDate,");
            strSql.Append("CashierID=@CashierID,");
            strSql.Append("SalesManID=@SalesManID,");
            strSql.Append("TotalAmount=@TotalAmount,");
            strSql.Append("Status=@Status,");
            strSql.Append("TransDiscount=@TransDiscount,");
            strSql.Append("TransDiscountType=@TransDiscountType,");
            strSql.Append("TransReason=@TransReason,");
            strSql.Append("RefTransNum=@RefTransNum,");
            strSql.Append("InvalidateFlag=@InvalidateFlag,");
            strSql.Append("MemberSalesFlag=@MemberSalesFlag,");
            strSql.Append("MemberID=@MemberID,");
            strSql.Append("CardNumber=@CardNumber,");
            strSql.Append("DeliveryFlag=@DeliveryFlag,");
            strSql.Append("DeliveryCountry=@DeliveryCountry,");
            strSql.Append("DeliveryProvince=@DeliveryProvince,");
            strSql.Append("DeliveryCity=@DeliveryCity,");
            strSql.Append("DeliveryDistrict=@DeliveryDistrict,");
            strSql.Append("DeliveryAddressDetail=@DeliveryAddressDetail,");
            strSql.Append("DeliveryFullAddress=@DeliveryFullAddress,");
            strSql.Append("DeliveryNumber=@DeliveryNumber,");
            strSql.Append("RequestDeliveryDate=@RequestDeliveryDate,");
            strSql.Append("DeliveryDate=@DeliveryDate,");
            strSql.Append("DeliveryBy=@DeliveryBy,");
            strSql.Append("Contact=@Contact,");
            strSql.Append("ContactPhone=@ContactPhone,");
            strSql.Append("PickupType=@PickupType,");
            strSql.Append("PickupStoreCode=@PickupStoreCode,");
            strSql.Append("CODFlag=@CODFlag,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("SettlementDate=@SettlementDate,");
            strSql.Append("SettlementStaffID=@SettlementStaffID,");
            strSql.Append("PaySettleDate=@PaySettleDate,");
            strSql.Append("CompleteDate=@CompleteDate,");
            strSql.Append("SalesReceipt=@SalesReceipt,");
            strSql.Append("SalesReceiptBIN=@SalesReceiptBIN,");
            strSql.Append("CreatedOn=@CreatedOn,");
            strSql.Append("CreatedBy=@CreatedBy,");
            strSql.Append("UpdatedOn=@UpdatedOn,");
            strSql.Append("UpdatedBy=@UpdatedBy,");
            strSql.Append("LogisticsProviderID=@LogisticsProviderID");
            strSql.Append(" where TransNum=@TransNum ");
            SqlParameter[] parameters = {
					new SqlParameter("@TransType", SqlDbType.Int,4),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@RegisterCode", SqlDbType.VarChar,64),
					new SqlParameter("@BusDate", SqlDbType.DateTime),
					new SqlParameter("@TxnDate", SqlDbType.DateTime),
					new SqlParameter("@CashierID", SqlDbType.Int,4),
					new SqlParameter("@SalesManID", SqlDbType.Int,4),
					new SqlParameter("@TotalAmount", SqlDbType.Decimal,9),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@TransDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@TransDiscountType", SqlDbType.Int,4),
					new SqlParameter("@TransReason", SqlDbType.NVarChar,512),
					new SqlParameter("@RefTransNum", SqlDbType.VarChar,64),
					new SqlParameter("@InvalidateFlag", SqlDbType.Int,4),
					new SqlParameter("@MemberSalesFlag", SqlDbType.Int,4),
					new SqlParameter("@MemberID", SqlDbType.VarChar,64),
					new SqlParameter("@CardNumber", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryFlag", SqlDbType.Int,4),
					new SqlParameter("@DeliveryCountry", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryProvince", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryCity", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryDistrict", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryAddressDetail", SqlDbType.NVarChar,512),
					new SqlParameter("@DeliveryFullAddress", SqlDbType.NVarChar,512),
					new SqlParameter("@DeliveryNumber", SqlDbType.VarChar,64),
					new SqlParameter("@RequestDeliveryDate", SqlDbType.DateTime),
					new SqlParameter("@DeliveryDate", SqlDbType.DateTime),
					new SqlParameter("@DeliveryBy", SqlDbType.Int,4),
					new SqlParameter("@Contact", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactPhone", SqlDbType.NVarChar,512),
					new SqlParameter("@PickupType", SqlDbType.Int,4),
					new SqlParameter("@PickupStoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@CODFlag", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@SettlementDate", SqlDbType.DateTime),
					new SqlParameter("@SettlementStaffID", SqlDbType.Int,4),
					new SqlParameter("@PaySettleDate", SqlDbType.DateTime),
					new SqlParameter("@CompleteDate", SqlDbType.DateTime),
					new SqlParameter("@SalesReceipt", SqlDbType.VarChar,-1),
					new SqlParameter("@SalesReceiptBIN", SqlDbType.VarBinary,-1),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@LogisticsProviderID", SqlDbType.Int,4),
					new SqlParameter("@TransNum", SqlDbType.VarChar,64)};
            parameters[0].Value = model.TransType;
            parameters[1].Value = model.StoreCode;
            parameters[2].Value = model.RegisterCode;
            parameters[3].Value = model.BusDate;
            parameters[4].Value = model.TxnDate;
            parameters[5].Value = model.CashierID;
            parameters[6].Value = model.SalesManID;
            parameters[7].Value = model.TotalAmount;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.TransDiscount;
            parameters[10].Value = model.TransDiscountType;
            parameters[11].Value = model.TransReason;
            parameters[12].Value = model.RefTransNum;
            parameters[13].Value = model.InvalidateFlag;
            parameters[14].Value = model.MemberSalesFlag;
            parameters[15].Value = model.MemberID;
            parameters[16].Value = model.CardNumber;
            parameters[17].Value = model.DeliveryFlag;
            parameters[18].Value = model.DeliveryCountry;
            parameters[19].Value = model.DeliveryProvince;
            parameters[20].Value = model.DeliveryCity;
            parameters[21].Value = model.DeliveryDistrict;
            parameters[22].Value = model.DeliveryAddressDetail;
            parameters[23].Value = model.DeliveryFullAddress;
            parameters[24].Value = model.DeliveryNumber;
            parameters[25].Value = model.RequestDeliveryDate;
            parameters[26].Value = model.DeliveryDate;
            parameters[27].Value = model.DeliveryBy;
            parameters[28].Value = model.Contact;
            parameters[29].Value = model.ContactPhone;
            parameters[30].Value = model.PickupType;
            parameters[31].Value = model.PickupStoreCode;
            parameters[32].Value = model.CODFlag;
            parameters[33].Value = model.Remark;
            parameters[34].Value = model.SettlementDate;
            parameters[35].Value = model.SettlementStaffID;
            parameters[36].Value = model.PaySettleDate;
            parameters[37].Value = model.CompleteDate;
            parameters[38].Value = model.SalesReceipt;
            parameters[39].Value = model.SalesReceiptBIN;
            parameters[40].Value = model.CreatedOn;
            parameters[41].Value = model.CreatedBy;
            parameters[42].Value = model.UpdatedOn;
            parameters[43].Value = model.UpdatedBy;
            parameters[44].Value = model.LogisticsProviderID;
            parameters[45].Value = model.TransNum;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(string TransNum)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sales_H ");
            strSql.Append(" where TransNum=@TransNum ");
            SqlParameter[] parameters = {
					new SqlParameter("@TransNum", SqlDbType.VarChar,64)			};
            parameters[0].Value = TransNum;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string TransNumlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sales_H ");
            strSql.Append(" where TransNum in (" + TransNumlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Edge.SVA.Model.Sales_H GetModel(string TransNum)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 TransNum,TransType,StoreCode,RegisterCode,BusDate,TxnDate,CashierID,SalesManID,TotalAmount,Status,TransDiscount,TransDiscountType,TransReason,RefTransNum,InvalidateFlag,MemberSalesFlag,MemberID,CardNumber,DeliveryFlag,DeliveryCountry,DeliveryProvince,DeliveryCity,DeliveryDistrict,DeliveryAddressDetail,DeliveryFullAddress,DeliveryNumber,RequestDeliveryDate,DeliveryDate,DeliveryBy,Contact,ContactPhone,PickupType,PickupStoreCode,CODFlag,Remark,SettlementDate,SettlementStaffID,PaySettleDate,CompleteDate,SalesReceipt,SalesReceiptBIN,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,LogisticsProviderID from Sales_H ");
            strSql.Append(" where TransNum=@TransNum ");
            SqlParameter[] parameters = {
					new SqlParameter("@TransNum", SqlDbType.VarChar,64)			};
            parameters[0].Value = TransNum;

            Edge.SVA.Model.Sales_H model = new Edge.SVA.Model.Sales_H();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Edge.SVA.Model.Sales_H DataRowToModel(DataRow row)
        {
            Edge.SVA.Model.Sales_H model = new Edge.SVA.Model.Sales_H();
            if (row != null)
            {
                if (row["TransNum"] != null)
                {
                    model.TransNum = row["TransNum"].ToString();
                }
                if (row["TransType"] != null && row["TransType"].ToString() != "")
                {
                    model.TransType = int.Parse(row["TransType"].ToString());
                }
                if (row["StoreCode"] != null)
                {
                    model.StoreCode = row["StoreCode"].ToString();
                }
                if (row["RegisterCode"] != null)
                {
                    model.RegisterCode = row["RegisterCode"].ToString();
                }
                if (row["BusDate"] != null && row["BusDate"].ToString() != "")
                {
                    model.BusDate = DateTime.Parse(row["BusDate"].ToString());
                }
                if (row["TxnDate"] != null && row["TxnDate"].ToString() != "")
                {
                    model.TxnDate = DateTime.Parse(row["TxnDate"].ToString());
                }
                if (row["CashierID"] != null && row["CashierID"].ToString() != "")
                {
                    model.CashierID = int.Parse(row["CashierID"].ToString());
                }
                if (row["SalesManID"] != null && row["SalesManID"].ToString() != "")
                {
                    model.SalesManID = int.Parse(row["SalesManID"].ToString());
                }
                if (row["TotalAmount"] != null && row["TotalAmount"].ToString() != "")
                {
                    model.TotalAmount = decimal.Parse(row["TotalAmount"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["TransDiscount"] != null && row["TransDiscount"].ToString() != "")
                {
                    model.TransDiscount = decimal.Parse(row["TransDiscount"].ToString());
                }
                if (row["TransDiscountType"] != null && row["TransDiscountType"].ToString() != "")
                {
                    model.TransDiscountType = int.Parse(row["TransDiscountType"].ToString());
                }
                if (row["TransReason"] != null)
                {
                    model.TransReason = row["TransReason"].ToString();
                }
                if (row["RefTransNum"] != null)
                {
                    model.RefTransNum = row["RefTransNum"].ToString();
                }
                if (row["InvalidateFlag"] != null && row["InvalidateFlag"].ToString() != "")
                {
                    model.InvalidateFlag = int.Parse(row["InvalidateFlag"].ToString());
                }
                if (row["MemberSalesFlag"] != null && row["MemberSalesFlag"].ToString() != "")
                {
                    model.MemberSalesFlag = int.Parse(row["MemberSalesFlag"].ToString());
                }
                if (row["MemberID"] != null)
                {
                    model.MemberID = row["MemberID"].ToString();
                }
                if (row["CardNumber"] != null)
                {
                    model.CardNumber = row["CardNumber"].ToString();
                }
                if (row["DeliveryFlag"] != null && row["DeliveryFlag"].ToString() != "")
                {
                    model.DeliveryFlag = int.Parse(row["DeliveryFlag"].ToString());
                }
                if (row["DeliveryCountry"] != null)
                {
                    model.DeliveryCountry = row["DeliveryCountry"].ToString();
                }
                if (row["DeliveryProvince"] != null)
                {
                    model.DeliveryProvince = row["DeliveryProvince"].ToString();
                }
                if (row["DeliveryCity"] != null)
                {
                    model.DeliveryCity = row["DeliveryCity"].ToString();
                }
                if (row["DeliveryDistrict"] != null)
                {
                    model.DeliveryDistrict = row["DeliveryDistrict"].ToString();
                }
                if (row["DeliveryAddressDetail"] != null)
                {
                    model.DeliveryAddressDetail = row["DeliveryAddressDetail"].ToString();
                }
                if (row["DeliveryFullAddress"] != null)
                {
                    model.DeliveryFullAddress = row["DeliveryFullAddress"].ToString();
                }
                if (row["DeliveryNumber"] != null)
                {
                    model.DeliveryNumber = row["DeliveryNumber"].ToString();
                }
                if (row["RequestDeliveryDate"] != null && row["RequestDeliveryDate"].ToString() != "")
                {
                    model.RequestDeliveryDate = DateTime.Parse(row["RequestDeliveryDate"].ToString());
                }
                if (row["DeliveryDate"] != null && row["DeliveryDate"].ToString() != "")
                {
                    model.DeliveryDate = DateTime.Parse(row["DeliveryDate"].ToString());
                }
                if (row["DeliveryBy"] != null && row["DeliveryBy"].ToString() != "")
                {
                    model.DeliveryBy = int.Parse(row["DeliveryBy"].ToString());
                }
                if (row["Contact"] != null)
                {
                    model.Contact = row["Contact"].ToString();
                }
                if (row["ContactPhone"] != null)
                {
                    model.ContactPhone = row["ContactPhone"].ToString();
                }
                if (row["PickupType"] != null && row["PickupType"].ToString() != "")
                {
                    model.PickupType = int.Parse(row["PickupType"].ToString());
                }
                if (row["PickupStoreCode"] != null)
                {
                    model.PickupStoreCode = row["PickupStoreCode"].ToString();
                }
                if (row["CODFlag"] != null && row["CODFlag"].ToString() != "")
                {
                    model.CODFlag = int.Parse(row["CODFlag"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["SettlementDate"] != null && row["SettlementDate"].ToString() != "")
                {
                    model.SettlementDate = DateTime.Parse(row["SettlementDate"].ToString());
                }
                if (row["SettlementStaffID"] != null && row["SettlementStaffID"].ToString() != "")
                {
                    model.SettlementStaffID = int.Parse(row["SettlementStaffID"].ToString());
                }
                if (row["PaySettleDate"] != null && row["PaySettleDate"].ToString() != "")
                {
                    model.PaySettleDate = DateTime.Parse(row["PaySettleDate"].ToString());
                }
                if (row["CompleteDate"] != null && row["CompleteDate"].ToString() != "")
                {
                    model.CompleteDate = DateTime.Parse(row["CompleteDate"].ToString());
                }
                if (row["SalesReceipt"] != null)
                {
                    model.SalesReceipt = row["SalesReceipt"].ToString();
                }
                if (row["SalesReceiptBIN"] != null && row["SalesReceiptBIN"].ToString() != "")
                {
                    model.SalesReceiptBIN = (byte[])row["SalesReceiptBIN"];
                }
                if (row["CreatedOn"] != null && row["CreatedOn"].ToString() != "")
                {
                    model.CreatedOn = DateTime.Parse(row["CreatedOn"].ToString());
                }
                if (row["CreatedBy"] != null && row["CreatedBy"].ToString() != "")
                {
                    model.CreatedBy = int.Parse(row["CreatedBy"].ToString());
                }
                if (row["UpdatedOn"] != null && row["UpdatedOn"].ToString() != "")
                {
                    model.UpdatedOn = DateTime.Parse(row["UpdatedOn"].ToString());
                }
                if (row["UpdatedBy"] != null && row["UpdatedBy"].ToString() != "")
                {
                    model.UpdatedBy = int.Parse(row["UpdatedBy"].ToString());
                }
                if (row["LogisticsProviderID"] != null && row["LogisticsProviderID"].ToString() != "")
                {
                    model.LogisticsProviderID = int.Parse(row["LogisticsProviderID"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TransNum,TransType,StoreCode,RegisterCode,BusDate,TxnDate,CashierID,SalesManID,TotalAmount,Status,TransDiscount,TransDiscountType,TransReason,RefTransNum,InvalidateFlag,MemberSalesFlag,MemberID,CardNumber,DeliveryFlag,DeliveryCountry,DeliveryProvince,DeliveryCity,DeliveryDistrict,DeliveryAddressDetail,DeliveryFullAddress,DeliveryNumber,RequestDeliveryDate,DeliveryDate,DeliveryBy,Contact,ContactPhone,PickupType,PickupStoreCode,CODFlag,Remark,SettlementDate,SettlementStaffID,PaySettleDate,CompleteDate,SalesReceipt,SalesReceiptBIN,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,LogisticsProviderID ");
            strSql.Append(" FROM Sales_H ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" TransNum,TransType,StoreCode,RegisterCode,BusDate,TxnDate,CashierID,SalesManID,TotalAmount,Status,TransDiscount,TransDiscountType,TransReason,RefTransNum,InvalidateFlag,MemberSalesFlag,MemberID,CardNumber,DeliveryFlag,DeliveryCountry,DeliveryProvince,DeliveryCity,DeliveryDistrict,DeliveryAddressDetail,DeliveryFullAddress,DeliveryNumber,RequestDeliveryDate,DeliveryDate,DeliveryBy,Contact,ContactPhone,PickupType,PickupStoreCode,CODFlag,Remark,SettlementDate,SettlementStaffID,PaySettleDate,CompleteDate,SalesReceipt,SalesReceiptBIN,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,LogisticsProviderID ");
            strSql.Append(" FROM Sales_H ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据条件查询列表
        /// 创建人：王丽
        /// 创建时间：2016-03-29
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public DataSet GetListByParm(string strWhere, string filedOrder, string webSiteName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("declare @WebSiteName nvarchar(20) ");
            strSql.AppendFormat(" set @WebSiteName='{0}'", webSiteName);
            strSql.Append("select Sales_H.TransNum ,case Sales_H.TransType when 0 then 'Normal Sales'  when 1 then 'Advance Sales' ");
            strSql.Append("when 2 then 'Deposit Sales' when 3 then 'Remote Collection' when 4 then 'Void' ");
            strSql.Append("when 5 then 'Refund' else 'Exchange'end as TransType ,");
            strSql.Append("Convert(varchar(10),Sales_H.BusDate,120)as BusDate,case Sales_H.Status when 0 then '购物车' when 1 then '暂存' ");
            strSql.Append("when 2 then '取消'when 3 then '未确认支付' when 4 then '已付款未提货' ");
            strSql.Append("when 5 then '交易完成' when 6 then '交付运送' when 8 then '拒收' when 9 then '已延迟' end as Status, ");
            strSql.Append("Convert(varchar(10),Sales_H.CreatedOn,120)as CreatedOn,Accounts_Users.UserName,");
            strSql.Append("BUY_STORE.StoreCode,BUY_STORE.StoreName1,BUY_STORE.StoreName2,BUY_STORE.StoreName3,");
            strSql.Append("case PickupType when 1 then '用叫快递送' else '店铺上门取货'end  PickupType,PickupStoreCode,");
            strSql.Append("Convert(varchar(10),Sales_H.PaySettleDate,120)as PaySettleDate,");
            strSql.Append("Convert(varchar(10),Sales_H.CompleteDate,120)as CompleteDate,Sales_H.Remark,");
            strSql.Append("DeliveryNumber,LogisticsProvider.ProviderName1,LogisticsProvider.ProviderName2,LogisticsProvider.ProviderName3,");
            strSql.Append("case DeliveryFlag when 0 then '自提，不送货' else '送货' end DeliveryFlag,d.UserName as dName,DeliveryFullAddress,");
            strSql.Append("DeliveryAddressDetail,Sales_H.Contact,Sales_H.ContactPhone,Convert(varchar(10),Sales_H.SettlementDate,120)as SettlementDate,");
            strSql.Append("s.UserName as sName,BUY_PRODUCT.ProdCode,BUY_PRODUCT.ProdDesc1,BUY_PRODUCT.ProdDesc2,BUY_PRODUCT.ProdDesc3,Sales_D.Qty,@WebSiteName as WebSiteName ");
            strSql.Append("FROM Sales_H ");
            strSql.Append("left join Accounts_Users on Sales_H.CreatedBy=Accounts_Users.UserID ");
            strSql.Append("left join BUY_STORE on Sales_H.StoreCode=BUY_STORE.StoreCode ");
            strSql.Append("left join LogisticsProvider on Sales_H.LogisticsProviderID=LogisticsProvider.LogisticsProviderID ");
            strSql.Append("left join Accounts_Users as d  on Sales_H.DeliveryBy=d.UserID ");
            strSql.Append("left join Accounts_Users as s  on Sales_H.SettlementStaffID=s.UserID ");
            strSql.Append("left join Sales_D   on Sales_H.TransNum=Sales_D.TransNum ");
            strSql.Append("left join BUY_PRODUCT on Sales_D.ProdCode=BUY_PRODUCT.ProdCode");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Sales_H ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.TransNum desc");
            }
            strSql.Append(")AS Row, T.*  from Sales_H T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Sales_H";
            parameters[1].Value = "TransNum";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
	}
}

