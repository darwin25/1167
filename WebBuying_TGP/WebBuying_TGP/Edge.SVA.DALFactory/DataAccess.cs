using System;
using System.Reflection;
using System.Configuration;
using Edge.SVA.IDAL;
using Edge.Common;
namespace Edge.SVA.DALFactory
{
    /// <summary>
    /// 抽象工厂模式创建DAL。
    /// web.config 需要加入配置：(利用工厂模式+反射机制+缓存机制,实现动态创建不同的数据层对象接口)  
    /// DataCache类在导出代码的文件夹里
    /// <appSettings>  
    /// <add key="DAL" value="Edge.SVA.SQLServerDAL" /> (这里的命名空间根据实际情况更改为自己项目的命名空间)
    /// </appSettings> 
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        /// <summary>
        /// 创建对象或从缓存获取
        /// </summary>
        public static object CreateObject(string AssemblyPath, string ClassNamespace)
        {
            object objType = DataCache.GetCache(ClassNamespace);//从缓存读取
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(ClassNamespace);//反射创建
                    DataCache.SetCache(ClassNamespace, objType);// 写入缓存
                }
                catch
                { }
            }
            return objType;
        }
        
        /// <summary>
        /// 创建Company数据层接口。公司表
        /// </summary>
        public static Edge.SVA.IDAL.ICompany CreateCompany()
        {

            string ClassNamespace = AssemblyPath + ".Company";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ICompany)objType;
        }

        /// <summary>
        /// 创建DataModels数据层接口。送货员位置表
        /// </summary>
        public static Edge.SVA.IDAL.IDataModels CreateDataModels()
        {

            string ClassNamespace = AssemblyPath + ".DataModels";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IDataModels)objType;
        }


        /// <summary>
        /// 创建DEPARTMENT数据层接口。送货员位置表
        /// </summary>
        public static Edge.SVA.IDAL.IDepartment CreateDepartment()
        {

            string ClassNamespace = AssemblyPath + ".Department";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IDepartment)objType;
        }


        /// <summary>
        /// 创建EarnCouponRule数据层接口。获取优惠劵的规则表
        /// </summary>
        public static Edge.SVA.IDAL.IEarnCouponRule CreateEarnCouponRule()
        {

            string ClassNamespace = AssemblyPath + ".EarnCouponRule";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IEarnCouponRule)objType;
        }


        /// <summary>
        /// 创建Education数据层接口。学历表
        /// </summary>
        public static Edge.SVA.IDAL.IEducation CreateEducation()
        {

            string ClassNamespace = AssemblyPath + ".Education";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IEducation)objType;
        }


       


        /// <summary>
        /// 创建LanguageMap数据层接口。kiosk调用
        /// </summary>
        public static Edge.SVA.IDAL.ILanguageMap CreateLanguageMap()
        {

            string ClassNamespace = AssemblyPath + ".LanguageMap";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ILanguageMap)objType;
        }


        /// <summary>
        /// 创建Member数据层接口。会员表
        /// </summary>
        public static Edge.SVA.IDAL.IMember CreateMember()
        {

            string ClassNamespace = AssemblyPath + ".Member";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IMember)objType;
        }


        /// <summary>
        /// 创建MemberAddress数据层接口。会员地址表
        /// </summary>
        public static Edge.SVA.IDAL.IMemberAddress CreateMemberAddress()
        {

            string ClassNamespace = AssemblyPath + ".MemberAddress";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IMemberAddress)objType;
        }


        /// <summary>
        /// 创建MemberCompanyStore数据层接口。会员地址表
        /// </summary>
        public static Edge.SVA.IDAL.IMemberCompanyStore CreateMemberCompanyStore()
        {

            string ClassNamespace = AssemblyPath + ".MemberCompanyStore";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IMemberCompanyStore)objType;
        }


        /// <summary>
        /// 创建MemberDepartment数据层接口。会员部门表
        /// </summary>
        public static Edge.SVA.IDAL.IMemberDepartment CreateMemberDepartment()
        {

            string ClassNamespace = AssemblyPath + ".MemberDepartment";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IMemberDepartment)objType;
        }


        /// <summary>
        /// 创建Nation数据层接口。国家表
        /// </summary>
        public static Edge.SVA.IDAL.INation CreateNation()
        {

            string ClassNamespace = AssemblyPath + ".Nation";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.INation)objType;
        }


        /// <summary>
        /// 创建OtherAccount数据层接口。其他账号
        /// </summary>
        public static Edge.SVA.IDAL.IOtherAccount CreateOtherAccount()
        {

            string ClassNamespace = AssemblyPath + ".OtherAccount";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOtherAccount)objType;
        }


        /// <summary>
        /// 创建OtherExchangeRate数据层接口。与第三方的兑换比率设
        /// </summary>
        public static Edge.SVA.IDAL.IOtherExchangeRate CreateOtherExchangeRate()
        {

            string ClassNamespace = AssemblyPath + ".OtherExchangeRate";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOtherExchangeRate)objType;
        }


        /// <summary>
        /// 创建PointRule数据层接口。卡消费赚积分规则表
        /// </summary>
        public static Edge.SVA.IDAL.IPointRule CreatePointRule()
        {

            string ClassNamespace = AssemblyPath + ".PointRule";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IPointRule)objType;
        }


        /// <summary>
        /// 创建Position数据层接口。卡消费赚积分规则表
        /// </summary>
        public static Edge.SVA.IDAL.IPosition CreatePosition()
        {

            string ClassNamespace = AssemblyPath + ".Position";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IPosition)objType;
        }


        /// <summary>
        /// 创建POSSalesData数据层接口。卡消费赚积分规则表
        /// </summary>
        public static Edge.SVA.IDAL.IPOSSalesData CreatePOSSalesData()
        {

            string ClassNamespace = AssemblyPath + ".POSSalesData";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IPOSSalesData)objType;
        }


        /// <summary>
        /// 创建Profession数据层接口。专业表
        /// </summary>
        public static Edge.SVA.IDAL.IProfession CreateProfession()
        {

            string ClassNamespace = AssemblyPath + ".Profession";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IProfession)objType;
        }


        /// <summary>
        /// 创建PromotionMsg数据层接口。优惠信息表
        /// </summary>
        public static Edge.SVA.IDAL.IPromotionMsg CreatePromotionMsg()
        {

            string ClassNamespace = AssemblyPath + ".PromotionMsg";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IPromotionMsg)objType;
        }


        /// <summary>
        /// 创建QuerySets数据层接口。优惠信息表
        /// </summary>
        public static Edge.SVA.IDAL.IQuerySets CreateQuerySets()
        {

            string ClassNamespace = AssemblyPath + ".QuerySets";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IQuerySets)objType;
        }


        /// <summary>
        /// 创建Reason数据层接口。原因列表
        /// </summary>
        public static Edge.SVA.IDAL.IReason CreateReason()
        {

            string ClassNamespace = AssemblyPath + ".Reason";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IReason)objType;
        }


        /// <summary>
        /// 创建ReceiveTxn数据层接口。接收到的操作指令记录
        /// </summary>
        public static Edge.SVA.IDAL.IReceiveTxn CreateReceiveTxn()
        {

            string ClassNamespace = AssemblyPath + ".ReceiveTxn";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IReceiveTxn)objType;
        }


        /// <summary>
        /// 创建REFNO数据层接口。交易单单号维护表。
        /// </summary>
        public static Edge.SVA.IDAL.IREFNO CreateREFNO()
        {

            string ClassNamespace = AssemblyPath + ".REFNO";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IREFNO)objType;
        }


        /// <summary>
        /// 创建RSAKeyTable数据层接口。交易单单号维护表。
        /// </summary>
        public static Edge.SVA.IDAL.IRSAKeyTable CreateRSAKeyTable()
        {

            string ClassNamespace = AssemblyPath + ".RSAKeyTable";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IRSAKeyTable)objType;
        }


        /// <summary>
        /// 创建Sales_H数据层接口。销售单主表（字段暂定）表中会员部分
        /// </summary>
        public static Edge.SVA.IDAL.ISales_H CreateSales_H()
        {

            string ClassNamespace = AssemblyPath + ".Sales_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ISales_H)objType;
        }


        /// <summary>
        /// 创建Schedule数据层接口。销售单主表（字段暂定）表中会员部分
        /// </summary>
        public static Edge.SVA.IDAL.ISchedule CreateSchedule()
        {

            string ClassNamespace = AssemblyPath + ".Schedule";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ISchedule)objType;
        }


        /// <summary>
        /// 创建ScheduleWeek数据层接口。销售单主表（字段暂定）表中会员部分
        /// </summary>
        public static Edge.SVA.IDAL.IScheduleWeek CreateScheduleWeek()
        {

            string ClassNamespace = AssemblyPath + ".ScheduleWeek";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IScheduleWeek)objType;
        }


        /// <summary>
        /// 创建StaffUpdateXLS_D数据层接口。销售单主表（字段暂定）表中会员部分
        /// </summary>
        public static Edge.SVA.IDAL.IStaffUpdateXLS_D CreateStaffUpdateXLS_D()
        {

            string ClassNamespace = AssemblyPath + ".StaffUpdateXLS_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IStaffUpdateXLS_D)objType;
        }


        /// <summary>
        /// 创建StaffUpdateXLS_M数据层接口。销售单主表（字段暂定）表中会员部分
        /// </summary>
        public static Edge.SVA.IDAL.IStaffUpdateXLS_M CreateStaffUpdateXLS_M()
        {

            string ClassNamespace = AssemblyPath + ".StaffUpdateXLS_M";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IStaffUpdateXLS_M)objType;
        }


        /// <summary>
        /// 创建Store数据层接口。店铺表
        /// </summary>
        public static Edge.SVA.IDAL.IStore CreateStore()
        {

            string ClassNamespace = AssemblyPath + ".Store";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IStore)objType;
        }


        /// <summary>
        /// 创建StoreGroup数据层接口。店铺组
        /// </summary>
        public static Edge.SVA.IDAL.IStoreGroup CreateStoreGroup()
        {

            string ClassNamespace = AssemblyPath + ".StoreGroup";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IStoreGroup)objType;
        }


        /// <summary>
        /// 创建StoreType数据层接口。店铺类型表
        /// </summary>
        public static Edge.SVA.IDAL.IStoreType CreateStoreType()
        {

            string ClassNamespace = AssemblyPath + ".StoreType";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IStoreType)objType;
        }


        /// <summary>
        /// 创建SVA_Transfer_D数据层接口。店铺类型表
        /// </summary>
        public static Edge.SVA.IDAL.ISVA_Transfer_D CreateSVA_Transfer_D()
        {

            string ClassNamespace = AssemblyPath + ".SVA_Transfer_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ISVA_Transfer_D)objType;
        }


        /// <summary>
        /// 创建SVA_Transfer_H数据层接口。店铺类型表
        /// </summary>
        public static Edge.SVA.IDAL.ISVA_Transfer_H CreateSVA_Transfer_H()
        {

            string ClassNamespace = AssemblyPath + ".SVA_Transfer_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ISVA_Transfer_H)objType;
        }


        /// <summary>
        /// 创建SVA_ValueAdjust_D数据层接口。店铺类型表
        /// </summary>
        public static Edge.SVA.IDAL.ISVA_ValueAdjust_D CreateSVA_ValueAdjust_D()
        {

            string ClassNamespace = AssemblyPath + ".SVA_ValueAdjust_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ISVA_ValueAdjust_D)objType;
        }


        /// <summary>
        /// 创建SVA_ValueAdjust_H数据层接口。店铺类型表
        /// </summary>
        public static Edge.SVA.IDAL.ISVA_ValueAdjust_H CreateSVA_ValueAdjust_H()
        {

            string ClassNamespace = AssemblyPath + ".SVA_ValueAdjust_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ISVA_ValueAdjust_H)objType;
        }


        /// <summary>
        /// 创建SVA_VoidCard_D数据层接口。店铺类型表
        /// </summary>
        public static Edge.SVA.IDAL.ISVA_VoidCard_D CreateSVA_VoidCard_D()
        {

            string ClassNamespace = AssemblyPath + ".SVA_VoidCard_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ISVA_VoidCard_D)objType;
        }


        /// <summary>
        /// 创建SVA_VoidCard_H数据层接口。店铺类型表
        /// </summary>
        public static Edge.SVA.IDAL.ISVA_VoidCard_H CreateSVA_VoidCard_H()
        {

            string ClassNamespace = AssemblyPath + ".SVA_VoidCard_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ISVA_VoidCard_H)objType;
        }


        /// <summary>
        /// 创建TENDER数据层接口。店铺类型表
        /// </summary>
        public static Edge.SVA.IDAL.ITENDER CreateTENDER()
        {

            string ClassNamespace = AssemblyPath + ".TENDER";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ITENDER)objType;
        }


        /// <summary>
        /// 创建VenCardIDMap数据层接口。实体卡绑定表
        /// </summary>
        public static Edge.SVA.IDAL.IVenCardIDMap CreateVenCardIDMap()
        {

            string ClassNamespace = AssemblyPath + ".VenCardIDMap";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IVenCardIDMap)objType;
        }


        /// <summary>
        /// 创建VENDOR数据层接口。实体卡绑定表
        /// </summary>
        public static Edge.SVA.IDAL.IVENDOR CreateVENDOR()
        {

            string ClassNamespace = AssemblyPath + ".VENDOR";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IVENDOR)objType;
        }

        

        /// <summary>
        /// 创建MemberClause数据层接口。会员条款
        /// </summary>
        public static Edge.SVA.IDAL.IMemberClause CreateMemberClause()
        {

            string ClassNamespace = AssemblyPath + ".MemberClause";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IMemberClause)objType;
        }


        /// <summary>
        /// 创建PasswordRule数据层接口。密码规则
        /// </summary>
        public static Edge.SVA.IDAL.IPasswordRule CreatePasswordRule()
        {

            string ClassNamespace = AssemblyPath + ".PasswordRule";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IPasswordRule)objType;
        }
        /// <summary>
        /// 创建RelationRoleIssuer数据层接口。
        /// </summary>
        public static Edge.SVA.IDAL.IRelationRoleIssuer CreateRelationRoleIssuer()
        {

            string ClassNamespace = AssemblyPath + ".RelationRoleIssuer";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IRelationRoleIssuer)objType;
        }

        /// <summary>
        /// 创建MemberSNSAccount数据层接口。交友系统账号
        /// </summary>
        public static Edge.SVA.IDAL.IMemberSNSAccount CreateMemberSNSAccount()
        {

            string ClassNamespace = AssemblyPath + ".MemberSNSAccount";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IMemberSNSAccount)objType;
        }


        /// <summary>
        /// 创建SNSType数据层接口。交友系统类型表
        /// </summary>
        public static Edge.SVA.IDAL.ISNSType CreateSNSType()
        {

            string ClassNamespace = AssemblyPath + ".SNSType";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ISNSType)objType;
        }

        /// <summary>
        /// 创建Location数据层接口。区域
        /// </summary>
        public static Edge.SVA.IDAL.ILocation CreateLocation()
        {

            string ClassNamespace = AssemblyPath + ".Location";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ILocation)objType;
        }

       

        /// <summary>
        /// 创建MemberFriend数据层接口。好友表
        /// </summary>
        public static Edge.SVA.IDAL.IMemberFriend CreateMemberFriend()
        {

            string ClassNamespace = AssemblyPath + ".MemberFriend";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IMemberFriend)objType;
        }

    

        /// <summary>
        /// 创建Ord_CardBatchCreate数据层接口。卡批量创建表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CardBatchCreate CreateOrd_CardBatchCreate()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CardBatchCreate";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CardBatchCreate)objType;
        }

        /// <summary>
        /// 创建Ord_CouponBatchCreate数据层接口。优惠劵批量创建表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CouponBatchCreate CreateOrd_CouponBatchCreate()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CouponBatchCreate";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CouponBatchCreate)objType;
        }

        /// <summary>
        /// 创建Ord_ImportCouponUID_D数据层接口。导入Coupon的U
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_ImportCouponUID_D CreateOrd_ImportCouponUID_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_ImportCouponUID_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_ImportCouponUID_D)objType;
        }

        /// <summary>
        /// 创建Ord_ImportCouponUID_H数据层接口。导入Coupon的UID。（销售实体coupon时
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_ImportCouponUID_H CreateOrd_ImportCouponUID_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_ImportCouponUID_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_ImportCouponUID_H)objType;
        }

        /// <summary>
        /// 创建Ord_CardAdjust_D数据层接口。卡调整子表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CardAdjust_D CreateOrd_CardAdjust_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CardAdjust_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CardAdjust_D)objType;
        }

        /// <summary>
        /// 创建Ord_CardAdjust_H数据层接口。卡调整单据主表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CardAdjust_H CreateOrd_CardAdjust_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CardAdjust_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CardAdjust_H)objType;
        }


        /// <summary>
        /// 创建Ord_CardTransfer数据层接口。转赠单据表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CardTransfer CreateOrd_CardTransfer()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CardTransfer";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CardTransfer)objType;
        }


        /// <summary>
        /// 创建Ord_CouponAdjust_D数据层接口。优惠劵调整子表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CouponAdjust_D CreateOrd_CouponAdjust_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CouponAdjust_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CouponAdjust_D)objType;
        }


        /// <summary>
        /// 创建Ord_CouponAdjust_H数据层接口。优惠劵调整单据主表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CouponAdjust_H CreateOrd_CouponAdjust_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CouponAdjust_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CouponAdjust_H)objType;
        }

       

        /// <summary>
        /// 创建Product数据层接口。货品表
        /// </summary>
        public static Edge.SVA.IDAL.IProduct CreateProduct()
        {

            string ClassNamespace = AssemblyPath + ".Product";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IProduct)objType;
        }


        /// <summary>
        /// 创建Product_Price数据层接口。货品价格表。（目前阶段
        /// </summary>
        public static Edge.SVA.IDAL.IProduct_Price CreateProduct_Price()
        {

            string ClassNamespace = AssemblyPath + ".Product_Price";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IProduct_Price)objType;
        }

       

        /// <summary>
        /// 创建RelationRoleBrand数据层接口。
        /// </summary>
        public static Edge.SVA.IDAL.IRelationRoleBrand CreateRelationRoleBrand()
        {

            string ClassNamespace = AssemblyPath + ".RelationRoleBrand";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IRelationRoleBrand)objType;
        }

        

        /// <summary>
        /// 创建DistributeTemplate数据层接口。分发模板发布方法
        /// </summary>
        public static Edge.SVA.IDAL.IDistributeTemplate CreateDistributeTemplate()
        {

            string ClassNamespace = AssemblyPath + ".DistributeTemplate";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IDistributeTemplate)objType;
        }

      

        /// <summary>
        /// 创建Organization数据层接口。机构表donate
        /// </summary>
        public static Edge.SVA.IDAL.IOrganization CreateOrganization()
        {

            string ClassNamespace = AssemblyPath + ".Organization";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrganization)objType;
        }

        /// <summary>
        /// 创建Ord_ImportCouponDispense_D数据层接口。分发优惠劵明细表CardNumber：在填写数据时
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_ImportCouponDispense_D CreateOrd_ImportCouponDispense_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_ImportCouponDispense_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_ImportCouponDispense_D)objType;
        }

        /// <summary>
        /// 创建Ord_ImportCouponDispense_H数据层接口。优惠劵分发单据表（主
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_ImportCouponDispense_H CreateOrd_ImportCouponDispense_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_ImportCouponDispense_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_ImportCouponDispense_H)objType;
        }

       

        /// <summary>
        /// 创建Ord_CardDelivery_D数据层接口。卡送货单子表 根据 Ord_CardPicking_D产生
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CardDelivery_D CreateOrd_CardDelivery_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CardDelivery_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CardDelivery_D)objType;
        }

        /// <summary>
        /// 创建Ord_CardDelivery_H数据层接口。卡送货单主表。（从批核后的拣货单复制过来
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CardDelivery_H CreateOrd_CardDelivery_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CardDelivery_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CardDelivery_H)objType;
        }


        /// <summary>
        /// 创建Ord_CardOrderForm_D数据层接口。卡订货单明细。表中brandID
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CardOrderForm_D CreateOrd_CardOrderForm_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CardOrderForm_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CardOrderForm_D)objType;
        }


        /// <summary>
        /// 创建Ord_CardOrderForm_H数据层接口。卡订货单
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CardOrderForm_H CreateOrd_CardOrderForm_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CardOrderForm_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CardOrderForm_H)objType;
        }


        /// <summary>
        /// 创建Ord_CardPicking_D数据层接口。卡拣货单子表  表中brandID
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CardPicking_D CreateOrd_CardPicking_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CardPicking_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CardPicking_D)objType;
        }


        /// <summary>
        /// 创建Ord_CardPicking_H数据层接口。卡拣货单主表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CardPicking_H CreateOrd_CardPicking_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CardPicking_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CardPicking_H)objType;
        }


        /// <summary>
        /// 创建Ord_CouponDelivery_D数据层接口。优惠劵送货单子表 根据 Ord_CouponPicking_D产生
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CouponDelivery_D CreateOrd_CouponDelivery_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CouponDelivery_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CouponDelivery_D)objType;
        }


        /// <summary>
        /// 创建Ord_CouponDelivery_H数据层接口。优惠劵送货单主表（从批核后的拣货单复制过来
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CouponDelivery_H CreateOrd_CouponDelivery_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CouponDelivery_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CouponDelivery_H)objType;
        }


        /// <summary>
        /// 创建Ord_CouponOrderForm_D数据层接口。优惠劵订货单明细。表中brandID
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CouponOrderForm_D CreateOrd_CouponOrderForm_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CouponOrderForm_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CouponOrderForm_D)objType;
        }


        /// <summary>
        /// 创建Ord_CouponOrderForm_H数据层接口。优惠劵订货单
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CouponOrderForm_H CreateOrd_CouponOrderForm_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CouponOrderForm_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CouponOrderForm_H)objType;
        }


        /// <summary>
        /// 创建Ord_CouponPicking_D数据层接口。优惠劵拣货单子表  表中brandID
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CouponPicking_D CreateOrd_CouponPicking_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CouponPicking_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CouponPicking_D)objType;
        }


        /// <summary>
        /// 创建Ord_CouponPicking_H数据层接口。优惠劵拣货单主表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CouponPicking_H CreateOrd_CouponPicking_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CouponPicking_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CouponPicking_H)objType;
        }

        /// <summary>
        /// 创建MemberNotice数据层接口。会员通知发送设置表
        /// </summary>
        public static Edge.SVA.IDAL.IMemberNotice CreateMemberNotice()
        {

            string ClassNamespace = AssemblyPath + ".MemberNotice";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IMemberNotice)objType;
        }

        /// <summary>
        /// 创建MemberNotice_Filter数据层接口。会员消息发送对象过滤
        /// </summary>
        public static Edge.SVA.IDAL.IMemberNotice_Filter CreateMemberNotice_Filter()
        {

            string ClassNamespace = AssemblyPath + ".MemberNotice_Filter";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IMemberNotice_Filter)objType;
        }


        /// <summary>
        /// 创建MemberNotice_MessageType数据层接口。会员消息 发送类型表
        /// </summary>
        public static Edge.SVA.IDAL.IMemberNotice_MessageType CreateMemberNotice_MessageType()
        {

            string ClassNamespace = AssemblyPath + ".MemberNotice_MessageType";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IMemberNotice_MessageType)objType;
        }


        /// <summary>
        /// 创建MessageTemplate数据层接口。消息内容模板。
        /// </summary>
        public static Edge.SVA.IDAL.IMessageTemplate CreateMessageTemplate()
        {

            string ClassNamespace = AssemblyPath + ".MessageTemplate";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IMessageTemplate)objType;
        }
     
        /// <summary>
        /// 创建City数据层接口。市资料表。（省下一级
        /// </summary>
        public static Edge.SVA.IDAL.ICity CreateCity()
        {

            string ClassNamespace = AssemblyPath + ".City";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ICity)objType;
        }


        /// <summary>
        /// 创建Country数据层接口。国家资料表
        /// </summary>
        public static Edge.SVA.IDAL.ICountry CreateCountry()
        {

            string ClassNamespace = AssemblyPath + ".Country";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ICountry)objType;
        }


        /// <summary>
        /// 创建Province数据层接口。省资料表。（中国一级行政区
        /// </summary>
        public static Edge.SVA.IDAL.IProvince CreateProvince()
        {

            string ClassNamespace = AssemblyPath + ".Province";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IProvince)objType;
        }


        /// <summary>
        /// 创建District数据层接口。区县资料表。（city下一级。中国第三级行政区
        /// </summary>
        public static Edge.SVA.IDAL.IDistrict CreateDistrict()
        {

            string ClassNamespace = AssemblyPath + ".District";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IDistrict)objType;
        }
        /// <summary>
        /// 创建MemberMessageAccount数据层接口。会员消息服务账号
        /// </summary>
        public static Edge.SVA.IDAL.IMemberMessageAccount CreateMemberMessageAccount()
        {

            string ClassNamespace = AssemblyPath + ".MemberMessageAccount";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IMemberMessageAccount)objType;
        }
        /// <summary>
        /// 创建USEFULEXPRESSIONS数据层接口。常用语表
        /// </summary>
        public static Edge.SVA.IDAL.IUSEFULEXPRESSIONS CreateUSEFULEXPRESSIONS()
        {

            string ClassNamespace = AssemblyPath + ".USEFULEXPRESSIONS";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IUSEFULEXPRESSIONS)objType;
        }
        /// <summary>
        /// 创建PromotionCardCondition数据层接口。促销信息（广告）的卡
        /// </summary>
        public static Edge.SVA.IDAL.IPromotionCardCondition CreatePromotionCardCondition()
        {

            string ClassNamespace = AssemblyPath + ".PromotionCardCondition";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IPromotionCardCondition)objType;
        }
        /// <summary>
        /// 创建OperationTable数据层接口。OprID表。
        /// </summary>
        public static Edge.SVA.IDAL.IOperationTable CreateOperationTable()
        {

            string ClassNamespace = AssemblyPath + ".OperationTable";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOperationTable)objType;
        }
        /// <summary>
        /// 创建MessageTemplateDetail数据层接口。消息内容模板明细。
        /// </summary>
        public static Edge.SVA.IDAL.IMessageTemplateDetail CreateMessageTemplateDetail()
        {

            string ClassNamespace = AssemblyPath + ".MessageTemplateDetail";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IMessageTemplateDetail)objType;
        }
        /// <summary>
        /// 创建PromotionMsgType数据层接口。优惠消息类型表
        /// </summary>
        public static Edge.SVA.IDAL.IPromotionMsgType CreatePromotionMsgType()
        {

            string ClassNamespace = AssemblyPath + ".PromotionMsgType";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IPromotionMsgType)objType;
        }
        /// <summary>
        /// 创建Ord_CouponPush_D数据层接口。推送优惠劵（子表）（
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CouponPush_D CreateOrd_CouponPush_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CouponPush_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CouponPush_D)objType;
        }


        /// <summary>
        /// 创建Ord_CouponPush_H数据层接口。推送优惠劵（主表）（注：根据提供的UI需求
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_CouponPush_H CreateOrd_CouponPush_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_CouponPush_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_CouponPush_H)objType;
        }
        /// <summary>
        /// 创建Ord_ImportMember_H数据层接口。导入Member数据（主表） （MII）（只是存储记录
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_ImportMember_H CreateOrd_ImportMember_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_ImportMember_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_ImportMember_H)objType;
        }
        /// <summary>
        /// 订单明细
        /// 创建者：Lisa
        /// 创建时间：2015-12-31
        /// </summary>
        /// <returns></returns>
        public static Edge.SVA.IDAL.ISales_D CreateSales_D()
        {

            string ClassNamespace = AssemblyPath + ".Sales_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ISales_D)objType;
        }
        /// <summary>
        /// 订单明细
        /// 创建者：Lisa
        /// 创建时间：2016-07-08
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// 创建IMP_PRODUCT数据层接口。读入的product
        /// </summary>
        public static Edge.SVA.IDAL.IIMP_PRODUCT CreateIMP_PRODUCT()
        {

            string ClassNamespace = AssemblyPath + ".IMP_PRODUCT";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IIMP_PRODUCT)objType;
        }


        /// <summary>
        /// 创建IMP_PRODUCT_TEMP数据层接口。读入的product
        /// 创建者：Lisa
        /// 创建时间：2016-07-08
        /// </summary>
        public static Edge.SVA.IDAL.IIMP_PRODUCT_TEMP CreateIMP_PRODUCT_TEMP()
        {

            string ClassNamespace = AssemblyPath + ".IMP_PRODUCT_TEMP";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IIMP_PRODUCT_TEMP)objType;
        }


        /// <summary>
        /// 创建BUY_Product_Particulars数据层接口。货品细节描述。（分语
        /// 创建人:Lisa
        /// 创建时间：2016-02-26
        /// </summary>
        public static Edge.IDAL.IBUY_Product_Particulars CreateBUY_Product_Particulars()
        {

            string ClassNamespace = AssemblyPath + ".BUY_Product_Particulars";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.IDAL.IBUY_Product_Particulars)objType;
        }


        /// <summary>
        /// 创建BUY_PRODUCT_CLASSIFY数据层接口。货品划分。（辅助表。 货品和其他表配合
        /// 创建人:Lisa
        /// 创建时间：2016-02-26
        /// </summary>
        public static Edge.IDAL.IBUY_PRODUCT_CLASSIFY CreateBUY_PRODUCT_CLASSIFY()
        {

            string ClassNamespace = AssemblyPath + ".BUY_PRODUCT_CLASSIFY";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.IDAL.IBUY_PRODUCT_CLASSIFY)objType;

        }


        /// <summary>
        /// 创建MATERIAL_IN数据层接口。内部材质。  for
        /// 创建人:Lisa
        /// 创建时间：2016-02-25
        /// </summary>
        public static Edge.SVA.IDAL.IMATERIAL_IN CreateMATERIAL_IN()
        {

            string ClassNamespace = AssemblyPath + ".MATERIAL_IN";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IMATERIAL_IN)objType;
        }


        /// <summary>
        /// 创建MATERIAL_OUT数据层接口。外部材质。  for
        /// 创建人:Lisa
        /// 创建时间：2016-02-25
        /// </summary>
        public static Edge.SVA.IDAL.IMATERIAL_OUT CreateMATERIAL_OUT()
        {

            string ClassNamespace = AssemblyPath + ".MATERIAL_OUT";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IMATERIAL_OUT)objType;
        }


        /// <summary>
        /// 创建SEASON数据层接口。季节。  for B
        /// 创建人:Lisa
        /// 创建时间：2016-02-25
        /// </summary>
        public static Edge.SVA.IDAL.ISEASON CreateSEASON()
        {

            string ClassNamespace = AssemblyPath + ".SEASON";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ISEASON)objType;
        }


        /// <summary>
        /// 创建Gender数据层接口。性别表。（基础表)
        /// 创建人:Lisa
        /// 创建时间：2016-02-25
        /// </summary>
        public static Edge.SVA.IDAL.IGender CreateGender()
        {

            string ClassNamespace = AssemblyPath + ".Gender";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IGender)objType;
        }


        /// <summary>
        /// 创建BUY_Product_Catalog数据层接口。货品目录绑定表（货品和部门)
        /// 创建人:Lisa
        /// 创建时间：2016-02-25
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_Product_Catalog CreateBUY_Product_Catalog()
        {

            string ClassNamespace = AssemblyPath + ".BUY_Product_Catalog";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_Product_Catalog)objType;
        }
        /// <summary>
        /// 创建BUY_SUPPROD数据层接口。供应商与货品的关联表
        /// 创建人:Lisa
        /// 创建时间：2016-02-26
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_SUPPROD CreateBUY_SUPPROD()
        {

            string ClassNamespace = AssemblyPath + ".BUY_SUPPROD";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_SUPPROD)objType;
        }
        /// <summary>
        /// 创建BUY_PRODUCT_ADD_BAU数据层接口。Bauhaus 货品
        /// 创建人:Lisa
        /// 创建时间：2016-02-26
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_PRODUCT_ADD_BAU CreateBUY_PRODUCT_ADD_BAU()
        {

            string ClassNamespace = AssemblyPath + ".BUY_PRODUCT_ADD_BAU";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_PRODUCT_ADD_BAU)objType;
        }
        /// <summary>
        /// 创建BUY_ProductClassify数据层接口。货品划分。（辅助表。 货品和其他表配合
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_ProductClassify CreateBUY_ProductClassify()
        {

            string ClassNamespace = AssemblyPath + ".BUY_ProductClassify";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_ProductClassify)objType;
        }

        #region For Buying
        /// <summary>
        /// 创建BUY_ALLOC_S_D数据层接口。
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_ALLOC_S_D CreateBUY_ALLOC_S_D()
        {

            string ClassNamespace = AssemblyPath + ".BUY_ALLOC_S_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_ALLOC_S_D)objType;
        }


        /// <summary>
        /// 创建BUY_ALLOC_S_H数据层接口。店铺货品分配表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_ALLOC_S_H CreateBUY_ALLOC_S_H()
        {

            string ClassNamespace = AssemblyPath + ".BUY_ALLOC_S_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_ALLOC_S_H)objType;
        }


        /// <summary>
        /// 创建BUY_BANK数据层接口。银行表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_BANK CreateBUY_BANK()
        {

            string ClassNamespace = AssemblyPath + ".BUY_BANK";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_BANK)objType;
        }


        /// <summary>
        /// 创建BUY_BARCODE数据层接口。货品barcode
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_BARCODE CreateBUY_BARCODE()
        {

            string ClassNamespace = AssemblyPath + ".BUY_BARCODE";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_BARCODE)objType;
        }


        /// <summary>
        /// 创建BUY_BLACKLIST数据层接口。黑名单表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_BLACKLIST CreateBUY_BLACKLIST()
        {

            string ClassNamespace = AssemblyPath + ".BUY_BLACKLIST";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_BLACKLIST)objType;
        }


        /// <summary>
        /// 创建BUY_BRAND数据层接口。品牌表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_BRAND CreateBUY_BRAND()
        {

            string ClassNamespace = AssemblyPath + ".BUY_BRAND";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_BRAND)objType;
        }


        /// <summary>
        /// 创建BUY_COLOR数据层接口。颜色表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_COLOR CreateBUY_COLOR()
        {

            string ClassNamespace = AssemblyPath + ".BUY_COLOR";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_COLOR)objType;
        }


        /// <summary>
        /// 创建BUY_CPRICE_D数据层接口。成本价子表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_CPRICE_D CreateBUY_CPRICE_D()
        {

            string ClassNamespace = AssemblyPath + ".BUY_CPRICE_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_CPRICE_D)objType;
        }


        /// <summary>
        /// 创建BUY_CPRICE_H数据层接口。成本价头表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_CPRICE_H CreateBUY_CPRICE_H()
        {

            string ClassNamespace = AssemblyPath + ".BUY_CPRICE_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_CPRICE_H)objType;
        }


        /// <summary>
        /// 创建BUY_CPRICE_M数据层接口。BUY_CPRICE
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_CPRICE_M CreateBUY_CPRICE_M()
        {

            string ClassNamespace = AssemblyPath + ".BUY_CPRICE_M";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_CPRICE_M)objType;
        }


        /// <summary>
        /// 创建BUY_CURRENCY数据层接口。货币支付表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_CURRENCY CreateBUY_CURRENCY()
        {

            string ClassNamespace = AssemblyPath + ".BUY_CURRENCY";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_CURRENCY)objType;
        }


        /// <summary>
        /// 创建BUY_DAYFLAG数据层接口。天标志表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_DAYFLAG CreateBUY_DAYFLAG()
        {

            string ClassNamespace = AssemblyPath + ".BUY_DAYFLAG";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_DAYFLAG)objType;
        }


        /// <summary>
        /// 创建BUY_DEPARTMENT数据层接口。货品部门表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_DEPARTMENT CreateBUY_DEPARTMENT()
        {

            string ClassNamespace = AssemblyPath + ".BUY_DEPARTMENT";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_DEPARTMENT)objType;
        }


        /// <summary>
        /// 创建BUY_DISCOUNT数据层接口。折扣设置表. （手动
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_DISCOUNT CreateBUY_DISCOUNT()
        {

            string ClassNamespace = AssemblyPath + ".BUY_DISCOUNT";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_DISCOUNT)objType;
        }


        /// <summary>
        /// 创建BUY_FULFILLMENTHOUSE数据层接口。供货仓库表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_FULFILLMENTHOUSE CreateBUY_FULFILLMENTHOUSE()
        {

            string ClassNamespace = AssemblyPath + ".BUY_FULFILLMENTHOUSE";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_FULFILLMENTHOUSE)objType;
        }


        /// <summary>
        /// 创建BUY_INSTALLMENT数据层接口。支付分期表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_INSTALLMENT CreateBUY_INSTALLMENT()
        {

            string ClassNamespace = AssemblyPath + ".BUY_INSTALLMENT";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_INSTALLMENT)objType;
        }


        /// <summary>
        /// 创建BUY_LEASECODE数据层接口。租赁代码表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_LEASECODE CreateBUY_LEASECODE()
        {

            string ClassNamespace = AssemblyPath + ".BUY_LEASECODE";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_LEASECODE)objType;
        }


        /// <summary>
        /// 创建BUY_MNM_D数据层接口。混配促销明细表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_MNM_D CreateBUY_MNM_D()
        {

            string ClassNamespace = AssemblyPath + ".BUY_MNM_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_MNM_D)objType;
        }


        /// <summary>
        /// 创建BUY_MNM_H数据层接口。混配促销配置表。主表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_MNM_H CreateBUY_MNM_H()
        {

            string ClassNamespace = AssemblyPath + ".BUY_MNM_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_MNM_H)objType;
        }


        /// <summary>
        /// 创建BUY_MONTHFLAG数据层接口。月标志表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_MONTHFLAG CreateBUY_MONTHFLAG()
        {

            string ClassNamespace = AssemblyPath + ".BUY_MONTHFLAG";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_MONTHFLAG)objType;
        }


        /// <summary>
        /// 创建BUY_PO_D数据层接口。PO单明细表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_PO_D CreateBUY_PO_D()
        {

            string ClassNamespace = AssemblyPath + ".BUY_PO_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_PO_D)objType;
        }


        /// <summary>
        /// 创建BUY_PO_H数据层接口。PO单主表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_PO_H CreateBUY_PO_H()
        {

            string ClassNamespace = AssemblyPath + ".BUY_PO_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_PO_H)objType;
        }

        /// <summary>
        /// 创建Ord_HQReceiveOrder_H数据层接口。Receive Supplier Order单主表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_HQReceiveOrder_H CreateOrd_HQReceiveOrder_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_HQReceiveOrder_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_HQReceiveOrder_H)objType;
        }

        /// <summary>
        /// 创建Ord_HQReceiveOrder_D数据层接口。Receive Supplier Order单明细表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_HQReceiveOrder_D CreateOrd_HQReceiveOrder_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_HQReceiveOrder_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_HQReceiveOrder_D)objType;
        }

        /// <summary>
        /// 创建BUY_PRODUCT数据层接口。货品表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_PRODUCT CreateBUY_PRODUCT()
        {

            string ClassNamespace = AssemblyPath + ".BUY_PRODUCT";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_PRODUCT)objType;
        }


        /// <summary>
        /// 创建BUY_PRODUCTCLASS数据层接口。货品大类
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_PRODUCTCLASS CreateBUY_PRODUCTCLASS()
        {

            string ClassNamespace = AssemblyPath + ".BUY_PRODUCTCLASS";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_PRODUCTCLASS)objType;
        }


        /// <summary>
        /// 创建BUY_PRODUCTSIZE数据层接口。产品尺寸属性。
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_PRODUCTSIZE CreateBUY_PRODUCTSIZE()
        {

            string ClassNamespace = AssemblyPath + ".BUY_PRODUCTSIZE";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_PRODUCTSIZE)objType;
        }


        /// <summary>
        /// 创建BUY_PROMO_D数据层接口。促销设置明细表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_PROMO_D CreateBUY_PROMO_D()
        {

            string ClassNamespace = AssemblyPath + ".BUY_PROMO_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_PROMO_D)objType;
        }


        /// <summary>
        /// 创建BUY_PROMO_H数据层接口。促销设置主表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_PROMO_H CreateBUY_PROMO_H()
        {

            string ClassNamespace = AssemblyPath + ".BUY_PROMO_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_PROMO_H)objType;
        }


        /// <summary>
        /// 创建BUY_PROMO_M数据层接口。促销主档表。
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_PROMO_M CreateBUY_PROMO_M()
        {

            string ClassNamespace = AssemblyPath + ".BUY_PROMO_M";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_PROMO_M)objType;
        }


        /// <summary>
        /// 创建BUY_REASON数据层接口。原因设置表。
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_REASON CreateBUY_REASON()
        {

            string ClassNamespace = AssemblyPath + ".BUY_REASON";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_REASON)objType;
        }


        /// <summary>
        /// 创建BUY_REFNO数据层接口。交易单单号维护表。
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_REFNO CreateBUY_REFNO()
        {

            string ClassNamespace = AssemblyPath + ".BUY_REFNO";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_REFNO)objType;
        }

        /// <summary>
        /// 创建BUY_RPRICE_D数据层接口。零售价格明细表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_RPRICE_D CreateBUY_RPRICE_D()
        {

            string ClassNamespace = AssemblyPath + ".BUY_RPRICE_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_RPRICE_D)objType;
        }


        /// <summary>
        /// 创建BUY_RPRICE_H数据层接口。零售价格表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_RPRICE_H CreateBUY_RPRICE_H()
        {

            string ClassNamespace = AssemblyPath + ".BUY_RPRICE_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_RPRICE_H)objType;
        }


        /// <summary>
        /// 创建BUY_RPRICE_M数据层接口。零售价格主档表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_RPRICE_M CreateBUY_RPRICE_M()
        {

            string ClassNamespace = AssemblyPath + ".BUY_RPRICE_M";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_RPRICE_M)objType;
        }


        /// <summary>
        /// 创建BUY_RPRICETYPE数据层接口。零售价类型表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_RPRICETYPE CreateBUY_RPRICETYPE()
        {

            string ClassNamespace = AssemblyPath + ".BUY_RPRICETYPE";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_RPRICETYPE)objType;
        }


        /// <summary>
        /// 创建BUY_SETTLEMENT数据层接口。交易的结算信息表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_SETTLEMENT CreateBUY_SETTLEMENT()
        {

            string ClassNamespace = AssemblyPath + ".BUY_SETTLEMENT";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_SETTLEMENT)objType;
        }


        /// <summary>
        /// 创建BUY_SETTLEMENT_D数据层接口。结算表子表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_SETTLEMENT_D CreateBUY_SETTLEMENT_D()
        {

            string ClassNamespace = AssemblyPath + ".BUY_SETTLEMENT_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_SETTLEMENT_D)objType;
        }


        /// <summary>
        /// 创建BUY_SGLINK数据层接口。store 和 st
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_SGLINK CreateBUY_SGLINK()
        {

            string ClassNamespace = AssemblyPath + ".BUY_SGLINK";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_SGLINK)objType;
        }


        /// <summary>
        /// 创建BUY_SM_NATURE数据层接口。交易类型定义表。

        /// </summary>
        public static Edge.SVA.IDAL.IBUY_SM_NATURE CreateBUY_SM_NATURE()
        {

            string ClassNamespace = AssemblyPath + ".BUY_SM_NATURE";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_SM_NATURE)objType;
        }


        /// <summary>
        /// 创建BUY_SO_D数据层接口。店铺订单明细
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_SO_D CreateBUY_SO_D()
        {

            string ClassNamespace = AssemblyPath + ".BUY_SO_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_SO_D)objType;
        }


        /// <summary>
        /// 创建BUY_STKDEFINE数据层接口。库存盘点定义
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_STKDEFINE CreateBUY_STKDEFINE()
        {

            string ClassNamespace = AssemblyPath + ".BUY_STKDEFINE";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_STKDEFINE)objType;
        }


        /// <summary>
        /// 创建BUY_STOCKSET数据层接口。货品库存设置表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_STOCKSET CreateBUY_STOCKSET()
        {

            string ClassNamespace = AssemblyPath + ".BUY_STOCKSET";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_STOCKSET)objType;
        }


        /// <summary>
        /// 创建BUY_STOCKTYPE数据层接口。库存类型表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_STOCKTYPE CreateBUY_STOCKTYPE()
        {

            string ClassNamespace = AssemblyPath + ".BUY_STOCKTYPE";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_STOCKTYPE)objType;
        }


        /// <summary>
        /// 创建BUY_STORE数据层接口。店铺表。
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_STORE CreateBUY_STORE()
        {

            string ClassNamespace = AssemblyPath + ".BUY_STORE";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_STORE)objType;
        }


        /// <summary>
        /// 创建BUY_STOREGROUP数据层接口。店铺组
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_STOREGROUP CreateBUY_STOREGROUP()
        {

            string ClassNamespace = AssemblyPath + ".BUY_STOREGROUP";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_STOREGROUP)objType;
        }


        /// <summary>
        /// 创建BUY_SYSOPTION数据层接口。系统设置表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_SYSOPTION CreateBUY_SYSOPTION()
        {

            string ClassNamespace = AssemblyPath + ".BUY_SYSOPTION";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_SYSOPTION)objType;
        }


        /// <summary>
        /// 创建BUY_VENDOR数据层接口。供应商表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_VENDOR CreateBUY_VENDOR()
        {

            string ClassNamespace = AssemblyPath + ".BUY_VENDOR";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_VENDOR)objType;
        }


        /// <summary>
        /// 创建BUY_WEEKFLAG数据层接口。周标志表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_WEEKFLAG CreateBUY_WEEKFLAG()
        {

            string ClassNamespace = AssemblyPath + ".BUY_WEEKFLAG";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_WEEKFLAG)objType;
        }

        /// <summary>
        /// 创建BUY_BOXSALE数据层接口。套餐销售设置表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_BOXSALE CreateBUY_BOXSALE()
        {

            string ClassNamespace = AssemblyPath + ".BUY_BOXSALE";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_BOXSALE)objType;
        }

        /// <summary>
        /// 创建Promotion_Gift数据层接口。促销礼品表。
        /// </summary>
        public static Edge.SVA.IDAL.IPromotion_Gift CreatePromotion_Gift()
        {

            string ClassNamespace = AssemblyPath + ".Promotion_Gift";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IPromotion_Gift)objType;
        }


        /// <summary>
        /// 创建Promotion_Gift_PLU数据层接口。促销赠送表的指定货品
        /// </summary>
        public static Edge.SVA.IDAL.IPromotion_Gift_PLU CreatePromotion_Gift_PLU()
        {

            string ClassNamespace = AssemblyPath + ".Promotion_Gift_PLU";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IPromotion_Gift_PLU)objType;
        }


        /// <summary>
        /// 创建Promotion_H数据层接口。促销头表。 （包含所有被动促销设置.  促销会根据具体的销售单
        /// </summary>
        public static Edge.SVA.IDAL.IPromotion_H CreatePromotion_H()
        {

            string ClassNamespace = AssemblyPath + ".Promotion_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IPromotion_H)objType;
        }


        /// <summary>
        /// 创建Promotion_Hit数据层接口。Promotion_H的子表。 促销命中条件表（多个货品固定搭配的情况）
        /// </summary>
        public static Edge.SVA.IDAL.IPromotion_Hit CreatePromotion_Hit()
        {

            string ClassNamespace = AssemblyPath + ".Promotion_Hit";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IPromotion_Hit)objType;
        }


        /// <summary>
        /// 创建Promotion_Hit_PLU数据层接口。促销命中表的指定货品
        /// </summary>
        public static Edge.SVA.IDAL.IPromotion_Hit_PLU CreatePromotion_Hit_PLU()
        {

            string ClassNamespace = AssemblyPath + ".Promotion_Hit_PLU";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IPromotion_Hit_PLU)objType;
        }

        /// <summary>
        /// 创建Promotion_Member数据层接口。Promotion_H的子表
        /// </summary>
        public static Edge.SVA.IDAL.IPromotion_Member CreatePromotion_Member()
        {

            string ClassNamespace = AssemblyPath + ".Promotion_Member";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IPromotion_Member)objType;
        }

        /// <summary>
        /// 创建BUY_PRODUCT_PIC数据层接口。货品图片
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_PRODUCT_PIC CreateBUY_PRODUCT_PIC()
        {

            string ClassNamespace = AssemblyPath + ".BUY_PRODUCT_PIC";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_PRODUCT_PIC)objType;
        }


        /// <summary>
        /// 创建BUY_ProductAssociated数据层接口。关联货品列表
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_ProductAssociated CreateBUY_ProductAssociated()
        {

            string ClassNamespace = AssemblyPath + ".BUY_ProductAssociated";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_ProductAssociated)objType;
        }


        /// <summary>
        /// 创建BUY_PRODUCTSTYLE数据层接口。货品同类分组表。（相同货品名称
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_PRODUCTSTYLE CreateBUY_PRODUCTSTYLE()
        {

            string ClassNamespace = AssemblyPath + ".BUY_PRODUCTSTYLE";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_PRODUCTSTYLE)objType;
        }

        /// <summary>
        /// 创建BUY_ProductParticulars数据层接口。货品细节描述。（分语
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_ProductParticulars CreateBUY_ProductParticulars()
        {

            string ClassNamespace = AssemblyPath + ".BUY_ProductParticulars";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_ProductParticulars)objType;
        }

        /// <summary>
        /// 创建POSStaff数据层接口。
        /// </summary>
        public static Edge.SVA.IDAL.IPOSSTAFF CreatePOSSTAFF()
        {

            string ClassNamespace = AssemblyPath + ".POSSTAFF";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IPOSSTAFF)objType;
        }

        /// <summary>
        /// 创建STAFFSTOREMAP数据层接口。Staff 和 Store
        /// </summary>
        public static Edge.SVA.IDAL.ISTAFFSTOREMAP CreateSTAFFSTOREMAP()
        {

            string ClassNamespace = AssemblyPath + ".STAFFSTOREMAP";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ISTAFFSTOREMAP)objType;
        }

        /// <summary>
        /// 物流价格设置表。 按省份，按供应商，设置报价
        /// 创建人：Lisa
        /// 创建时间：2015-12-31
        /// </summary>
        public static Edge.SVA.IDAL.ILogisticsPrice CreateLogisticsPrice()
        {

            string ClassNamespace = AssemblyPath + ".LogisticsPrice";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ILogisticsPrice)objType;
        }

        /// <summary>
        /// 物流供应商
        /// 创建人：Lisa
        /// 创建时间：2015-12-31
        /// </summary>
        public static Edge.SVA.IDAL.ILogisticsProvider CreateLogisticsProvider()
        {

            string ClassNamespace = AssemblyPath + ".LogisticsProvider";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ILogisticsProvider)objType;
        }
        #endregion

        #region 创建Store订单系列表
        /// 创建Ord_StoreOrder_D数据层接口。Store Order单明细表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_StoreOrder_D CreateOrd_StoreOrder_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_StoreOrder_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_StoreOrder_D)objType;
        }


        /// <summary>
        /// 创建Ord_StoreOrder_H数据层接口。Store Order单主表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_StoreOrder_H CreateOrd_StoreOrder_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_StoreOrder_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_StoreOrder_H)objType;
        }

        /// 创建Ord_ShipmentOrder_D数据层接口。Shipment Store Order单明细表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_ShipmentOrder_D CreateOrd_ShipmentOrder_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_ShipmentOrder_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_ShipmentOrder_D)objType;
        }


        /// <summary>
        /// 创建Ord_ShipmentOrder_H数据层接口。Shipment Store Order单主表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_ShipmentOrder_H CreateOrd_ShipmentOrder_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_ShipmentOrder_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_ShipmentOrder_H)objType;
        }

        /// <summary>
        /// 创建Ord_ReceiveOrder_H数据层接口。Receive Store Order单主表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_ReceiveOrder_H CreateOrd_ReceiveOrder_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_ReceiveOrder_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_ReceiveOrder_H)objType;
        }

        /// <summary>
        /// 创建Ord_ReceiveOrder_D数据层接口。Receive Store Order单明细表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_ReceiveOrder_D CreateOrd_ReceiveOrder_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_ReceiveOrder_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_ReceiveOrder_D)objType;
        }
        /// <summary>
        /// 创建Ord_PickingOrder_H数据层接口。Picking Store Order单主表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_PickingOrder_H CreateOrd_PickingOrder_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_PickingOrder_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_PickingOrder_H)objType;
        }

        /// <summary>
        /// 创建Ord_PickingOrder_D数据层接口。Picking Store Order单明细表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_PickingOrder_D CreateOrd_PickingOrder_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_PickingOrder_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_PickingOrder_D)objType;
        }
        /// <summary>
        /// 创建Ord_ReturnOrder_H数据层接口。Return Store Order单主表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_ReturnOrder_H CreateOrd_ReturnOrder_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_ReturnOrder_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_ReturnOrder_H)objType;
        }

        /// <summary>
        /// 创建Ord_ReturnOrder_D数据层接口。Return Store Order单明细表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_ReturnOrder_D CreateOrd_ReturnOrder_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_ReturnOrder_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_ReturnOrder_D)objType;
        }
        /// <summary>
        /// 创建Ord_StockAdjust_H数据层接口。Stock Adjust单主表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_StockAdjust_H CreateOrd_StockAdjust_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_StockAdjust_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_StockAdjust_H)objType;
        }

        /// <summary>
        /// 创建Ord_StockAdjust_D数据层接口。Stock Adjust单明细表
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_StockAdjust_D CreateOrd_StockAdjust_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_StockAdjust_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_StockAdjust_D)objType;
        }

        /// <summary>
        /// 创建StockTake数据层接口。盘点注册
        /// </summary>
        public static Edge.SVA.IDAL.ISTK_STake_H CreateSTK_STake_H()
        {

            string ClassNamespace = AssemblyPath + ".STK_STake_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ISTK_STake_H)objType;
        }

        /// <summary>
        /// 创建StockTake数据层接口。第一次盘点
        /// </summary>
        public static Edge.SVA.IDAL.ISTK_STake01 CreateSTK_STake01()
        {

            string ClassNamespace = AssemblyPath + ".STK_STake01";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ISTK_STake01)objType;
        }
        /// <summary>
        /// 创建StockTake数据层接口。第二次盘点
        /// </summary>
        public static Edge.SVA.IDAL.ISTK_STake02 CreateSTK_STake02()
        {

            string ClassNamespace = AssemblyPath + ".STK_STake02";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ISTK_STake02)objType;
        }
        /// <summary>
        /// 创建StockTake数据层接口。盘点差异
        /// </summary>
        public static Edge.SVA.IDAL.ISTK_STakeVAR CreateSTK_STakeVAR()
        {

            string ClassNamespace = AssemblyPath + ".STK_STakeVAR";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ISTK_STakeVAR)objType;
        }


        public static Edge.SVA.IDAL.IOrd_TransOutOrder_H CreateOrd_TransOutOrder_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_TransOutOrder_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_TransOutOrder_H)objType;
        }
        public static Edge.SVA.IDAL.IOrd_TransOutOrder_D CreateOrd_TransOutOrder_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_TransOutOrder_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_TransOutOrder_D)objType;
        }

        public static Edge.SVA.IDAL.IOrd_TransInOrder_H CreateOrd_TransInOrder_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_TransInOrder_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_TransInOrder_H)objType;
        }
        public static Edge.SVA.IDAL.IOrd_TransInOrder_D CreateOrd_TransInOrder_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_TransInOrder_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_TransInOrder_D)objType;
        }

        #endregion

        /// <summary>
        /// 创建Ord_SalesPickOrder_D数据层接口。拣货单（面向订单的拣
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_SalesPickOrder_D CreateOrd_SalesPickOrder_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_SalesPickOrder_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_SalesPickOrder_D)objType;
        }


        /// <summary>
        /// 创建Ord_SalesPickOrder_H数据层接口。拣货订单@20
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_SalesPickOrder_H CreateOrd_SalesPickOrder_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_SalesPickOrder_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_SalesPickOrder_H)objType;
        }


        /// <summary>
        /// 创建Ord_SalesShipOrder_D数据层接口。发货单明细表（面向订单的）
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_SalesShipOrder_D CreateOrd_SalesShipOrder_D()
        {

            string ClassNamespace = AssemblyPath + ".Ord_SalesShipOrder_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_SalesShipOrder_D)objType;
        }


        /// <summary>
        /// 创建Ord_SalesShipOrder_H数据层接口。发货单（面向订单的）。 @2016-05-20（Ord_SalesPickOrder_H 批核后
        /// </summary>
        public static Edge.SVA.IDAL.IOrd_SalesShipOrder_H CreateOrd_SalesShipOrder_H()
        {

            string ClassNamespace = AssemblyPath + ".Ord_SalesShipOrder_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IOrd_SalesShipOrder_H)objType;
        }
        /// <summary>
        /// 创建BUY_REPLEN_D数据层接口。店铺补货设置。从表
        /// 创建人：lisa
        /// 创建时间：2016-07-13
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_REPLEN_D CreateBUY_REPLEN_D()
        {

            string ClassNamespace = AssemblyPath + ".BUY_REPLEN_D";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_REPLEN_D)objType;
        }


        /// <summary>
        /// 创建BUY_REPLEN_H数据层接口。店铺补货设置。主表
        /// 创建人：lisa
        /// 创建时间：2016-07-13
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_REPLEN_H CreateBUY_REPLEN_H()
        {

            string ClassNamespace = AssemblyPath + ".BUY_REPLEN_H";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_REPLEN_H)objType;
        }


        /// <summary>
        /// 创建BUY_REPLENFORMULA数据层接口。自动补货公式信息表（根据销售货品统计每天的销售平均数
        /// 创建人：lisa
        /// 创建时间：2016-07-13
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_REPLENFORMULA CreateBUY_REPLENFORMULA()
        {

            string ClassNamespace = AssemblyPath + ".BUY_REPLENFORMULA";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_REPLENFORMULA)objType;
        }
        /// <summary>
        /// 创建BUY_PRODUCT_ADD_BAU_Pending数据层接口。Bauhaus 货品
        /// 创建人：Lisa
        /// 创建时间：2016-08-08
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_PRODUCT_ADD_BAU_Pending CreateBUY_PRODUCT_ADD_BAU_Pending()
        {

            string ClassNamespace = AssemblyPath + ".BUY_PRODUCT_ADD_BAU_Pending";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_PRODUCT_ADD_BAU_Pending)objType;
        }


        /// <summary>
        /// 创建BUY_Product_Catalog_Pending数据层接口。货品目录绑定表（货品和部门
        /// 创建人：Lisa
        /// 创建时间：2016-08-08
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_Product_Catalog_Pending CreateBUY_Product_Catalog_Pending()
        {

            string ClassNamespace = AssemblyPath + ".BUY_Product_Catalog_Pending";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_Product_Catalog_Pending)objType;
        }


        /// <summary>
        /// 创建BUY_PRODUCT_CLASSIFY_Pending数据层接口。货品划分。（辅助表。 货品和其他表配合
        /// 创建人：Lisa
        /// 创建时间：2016-08-08
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_PRODUCT_CLASSIFY_Pending CreateBUY_PRODUCT_CLASSIFY_Pending()
        {

            string ClassNamespace = AssemblyPath + ".BUY_PRODUCT_CLASSIFY_Pending";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_PRODUCT_CLASSIFY_Pending)objType;
        }


        /// <summary>
        /// 创建BUY_Product_Particulars_Pending数据层接口。货品细节描述。（分语
        /// 创建人：Lisa
        /// 创建时间：2016-08-08
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_Product_Particulars_Pending CreateBUY_Product_Particulars_Pending()
        {

            string ClassNamespace = AssemblyPath + ".BUY_Product_Particulars_Pending";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_Product_Particulars_Pending)objType;
        }


        /// <summary>
        /// 创建BUY_PRODUCT_Pending数据层接口。货品表 (待审核表)
        /// 创建人：Lisa
        /// 创建时间：2016-08-08
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_PRODUCT_Pending CreateBUY_PRODUCT_Pending()
        {

            string ClassNamespace = AssemblyPath + ".BUY_PRODUCT_Pending";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_PRODUCT_Pending)objType;
        }


        /// <summary>
        /// 创建BUY_PRODUCT_PIC_Pending数据层接口。货品图片
        /// 创建人：Lisa
        /// 创建时间：2016-08-08
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_PRODUCT_PIC_Pending CreateBUY_PRODUCT_PIC_Pending()
        {

            string ClassNamespace = AssemblyPath + ".BUY_PRODUCT_PIC_Pending";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_PRODUCT_PIC_Pending)objType;
        }


        /// <summary>
        /// 创建BUY_ProductAssociated_Pending数据层接口。关联货品列表
        /// 创建人：Lisa
        /// 创建时间：2016-08-08
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_ProductAssociated_Pending CreateBUY_ProductAssociated_Pending()
        {

            string ClassNamespace = AssemblyPath + ".BUY_ProductAssociated_Pending";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_ProductAssociated_Pending)objType;
        }


        /// <summary>
        /// 创建BUY_PRODUCTCLASS_Pending数据层接口。货品大类
        /// 创建人：Lisa
        /// 创建时间：2016-08-08
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_PRODUCTCLASS_Pending CreateBUY_PRODUCTCLASS_Pending()
        {

            string ClassNamespace = AssemblyPath + ".BUY_PRODUCTCLASS_Pending";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_PRODUCTCLASS_Pending)objType;
        }


        /// <summary>
        /// 创建BUY_PRODUCTPACKAGE_Pending数据层接口。货品包装设置。（销售
        /// 创建人：Lisa
        /// 创建时间：2016-08-08
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_PRODUCTPACKAGE_Pending CreateBUY_PRODUCTPACKAGE_Pending()
        {

            string ClassNamespace = AssemblyPath + ".BUY_PRODUCTPACKAGE_Pending";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_PRODUCTPACKAGE_Pending)objType;
        }


        /// <summary>
        /// 创建BUY_PRODUCTSIZE_Pending数据层接口。产品尺寸属性。
        /// 创建人：Lisa
        /// 创建时间：2016-08-08
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_PRODUCTSIZE_Pending CreateBUY_PRODUCTSIZE_Pending()
        {

            string ClassNamespace = AssemblyPath + ".BUY_PRODUCTSIZE_Pending";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_PRODUCTSIZE_Pending)objType;
        }


        /// <summary>
        /// 创建BUY_PRODUCTSTYLE_Pending数据层接口。货品同类分组表。（相同货品名称
        /// 创建人：Lisa
        /// 创建时间：2016-08-08
        /// </summary>
        public static Edge.SVA.IDAL.IBUY_PRODUCTSTYLE_Pending CreateBUY_PRODUCTSTYLE_Pending()
        {

            string ClassNamespace = AssemblyPath + ".BUY_PRODUCTSTYLE_Pending";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBUY_PRODUCTSTYLE_Pending)objType;
        }
       
        /// <summary>
        /// 创建Brand数据层接口。店铺品牌表。（运营商
        /// 创建人：Lisa
        /// 创建时间：2016-08-10
        /// </summary>
        public static Edge.SVA.IDAL.IBrand CreateBrand()
        {

            string ClassNamespace = AssemblyPath + ".Brand";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IBrand)objType;
        }
        /// <summary>
        /// 创建ProductStoreMap数据层接口。店铺允许销售的货品列
        /// 创建人：Lisa
        /// 创建时间：2016-08-11
        /// </summary>
        public static Edge.SVA.IDAL.IProductStoreMap CreateProductStoreMap()
        {

            string ClassNamespace = AssemblyPath + ".ProductStoreMap";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.IProductStoreMap)objType;
        }
        /// <summary>
        /// 创建STK_StockOnhand数据层接口。货品库存表。货品实际
        /// </summary>
        public static Edge.SVA.IDAL.ISTK_StockOnhand CreateSTK_StockOnhand()
        {

            string ClassNamespace = AssemblyPath + ".STK_StockOnhand";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Edge.SVA.IDAL.ISTK_StockOnhand)objType;
        }

        /// <summary>
		/// 创建ProductModifyTemp数据层接口。@2016-12-14 @Gavin用户product变更表。  每次操作后清空。status暂时没用。  如果需要批核的话就启用。设置的字段
        /// 创建人：lisa
        /// 创建时间：2016-12-14
		/// </summary>
		public static Edge.SVA.IDAL.IProductModifyTemp CreateProductModifyTemp()
		{

			string ClassNamespace = AssemblyPath +".ProductModifyTemp";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (Edge.SVA.IDAL.IProductModifyTemp)objType;
		}

    }
}