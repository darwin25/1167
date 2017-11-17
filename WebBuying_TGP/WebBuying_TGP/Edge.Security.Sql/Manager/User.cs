using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Edge.SVA.Model.Domain.SVA;
using Edge.SVA.BLL.Domain.DataResources;
using System.Data.SqlClient;

namespace Edge.Security.Manager
{
    public sealed class User
    {
        private List<BrandInfo> brandInfoList = new List<BrandInfo>();

        public List<BrandInfo> BrandInfoList
        {
            get { return brandInfoList; }
            set { brandInfoList = value; }
        }

        //Add By Robin 2015-08-06 员工列表
        private List<string> employeeList = new List<string>();
        public List<string> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value; }
        }
        //

        /// <summary>
        /// empty or (1,2)
        /// </summary>
        public string SqlConditionBrandIDs
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in brandInfoList)
                {
                    sb.Append(',');
                    sb.Append(item.Key);
                }
                if (sb.Length >= 1)
                {
                    return "(" + sb.ToString().Substring(1) + ")";
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        /// <summary>
        /// empty or (1,2)
        /// </summary>
        public string SqlConditionStoreIDs
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item1 in brandInfoList)
                {
                    foreach (var item in item1.StoreInfos)
                    {
                        sb.Append(",");
                        sb.Append(item.Key);
                    }
                }
                if (sb.Length >= 1)
                {
                    return "(" + sb.ToString().Substring(1) + ")";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string SqlConditionStoreIDByUser(string UserName)
        {
           
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StoreID  from RelationUserStore");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,64)
						};
            parameters[0].Value = UserName;


            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return string.Empty;
            }
            else
            {
                return obj.ToString();
            }
    
        }

        public string SqlConditionStoreIDsByBrandID(string brandID)
        {
            BrandInfo bi = brandInfoList.Find(m => m.Key == brandID);
            StringBuilder sb = new StringBuilder();
            foreach (var item in bi.StoreInfos)
            {
                sb.Append(",");
                sb.Append(item.Key);
            }
            if (sb.Length >= 1)
            {
                return "(" + sb.ToString().Substring(1) + ")";
            }
            else
            {
                return string.Empty;
            }
        }
        public string SqlConditionAllStoresIDsByBrandID(string brandID)
        {
            Edge.SVA.BLL.Store storeBll = new Edge.SVA.BLL.Store();
            List<Edge.SVA.Model.Store> storeList = storeBll.DataTableToList(storeBll.GetStores(int.Parse(brandID)).Tables[0]);
            StringBuilder sb = new StringBuilder();
            foreach (var item in storeList)
            {
                sb.Append(",");
                sb.Append(item.StoreID);
            }
            if (sb.Length >= 1)
            {
                return "(" + sb.ToString().Substring(1) + ")";
            }
            else
            {
                return string.Empty;
            }
        }
        //Add By Robin 2015-08-06 增加组织架构
        public string SqlConditionUserIDs 
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in EmployeeList)
                {
                    sb.Append(",");
                    sb.Append(item.ToString());
                }
                if (sb.Length >= 1)
                {
                    return "(" +UserID.ToString()+","+ sb.ToString().Substring(1) + ")";
                }
                else
                {
                    return "(" + UserID.ToString()  + ")";
                }
            }
        }
        //
        // Fields
        private bool activity;
        private string departmentID;
        private string email;
        private int employeeID;
        private byte[] password;
        private string phone;
        private string sex;
        private int style;
        private string trueName;
        private int userID;
        private string userName = string.Empty;
        private string userType;

        // Methods
        public User()
        {
            this.departmentID = "-1";
        }

        public User(AccountsPrincipal existingPrincipal)
        {
            this.departmentID = "-1";
            this.userID = ((SiteIdentity)existingPrincipal.Identity).UserID;
            this.LoadFromID();
        }

        public User(int existingUserID)
        {
            this.departmentID = "-1";
            this.userID = existingUserID;
            this.LoadFromID();
        }

        public User(string UserName)
        {
            this.departmentID = "-1";
            DataRow row = new Edge.Security.Data.User().Retrieve(UserName);
            if (row != null)
            {
                this.userID = (int)row["UserID"];
                this.userName = (string)row["UserName"];
                this.trueName = (string)row["TrueName"];
                if (row["Description"] is DBNull)
                {
                    this.Description = string.Empty;
                }
                else
                {
                    this.Description = (string)row["Description"];
                }
                this.sex = (string)row["Sex"];
                this.phone = (string)row["Phone"];
                this.email = (string)row["Email"];
                this.employeeID = (int)row["EmployeeID"];
                this.password = (byte[])row["Password"];
                this.style = (int)row["Style"];
            }
        }

        public bool AddToRole(int roleId)
        {
            Edge.Security.Data.User user = new Edge.Security.Data.User();
            return user.AddRole(this.userID, roleId);
        }

        public int Create()
        {
            this.userID = new Edge.Security.Data.User().Create(this.userName, this.password, this.trueName, this.sex, this.phone, this.email, this.employeeID, this.departmentID, this.activity, this.userType, this.style, this.Description);
            return this.userID;
        }

        public bool Delete()
        {
            Edge.Security.Data.User user = new Edge.Security.Data.User();
            return user.Delete(this.userID);
        }

        public DataSet GetAllUsers(string key)
        {
            Edge.Security.Data.User user = new Edge.Security.Data.User();
            return user.GetAllUsers(key);
        }

        public DataSet GetUsers(string DepartmentID)
        {
            Edge.Security.Data.User user = new Edge.Security.Data.User();
            return user.GetUsers(DepartmentID);
        }

        public DataSet GetUsersByType(string usertype, string key)
        {
            Edge.Security.Data.User user = new Edge.Security.Data.User();
            return user.GetUsersByType(usertype, key);
        }

        public bool HasUser(string userName)
        {
            Edge.Security.Data.User user = new Edge.Security.Data.User();
            return user.HasUser(userName);
        }

        private void LoadFromID()
        {
            DataRow row = new Edge.Security.Data.User().Retrieve(this.userID);
            if (row != null)
            {
                this.userName = (string)row["UserName"];
                if (!string.IsNullOrEmpty(row["TrueName"].ToString()))
                {
                    this.trueName = (string)row["TrueName"];
                }

                if (!string.IsNullOrEmpty(row["Description"].ToString()))
                {
                    this.Description = (string)row["Description"];
                }
                if (!string.IsNullOrEmpty(row["Sex"].ToString()))
                {
                    this.sex = (string)row["Sex"];
                }
                if (!string.IsNullOrEmpty(row["Phone"].ToString()))
                {
                    this.phone = (string)row["Phone"];
                }
                if (!string.IsNullOrEmpty(row["Email"].ToString()))
                {
                    this.email = (string)row["Email"];
                }
                if (!string.IsNullOrEmpty(row["EmployeeID"].ToString()))
                {
                    this.employeeID = (int)row["EmployeeID"];
                }
                if (!string.IsNullOrEmpty(row["DepartmentID"].ToString()))
                {
                    this.departmentID = (string)row["DepartmentID"];
                }
                if (!string.IsNullOrEmpty(row["Activity"].ToString()))
                {
                    this.activity = (bool)row["Activity"];
                }
                if (!string.IsNullOrEmpty(row["UserType"].ToString()))
                {
                    this.userType = (string)row["UserType"];
                }
                if (!string.IsNullOrEmpty(row["Password"].ToString()))
                {
                    this.password = (byte[])row["Password"];
                }
                if (!string.IsNullOrEmpty(row["Style"].ToString()))
                {
                    this.style = (int)row["Style"];
                }
            }
        }

        public bool RemoveRole(int roleId)
        {
            Edge.Security.Data.User user = new Edge.Security.Data.User();
            return user.RemoveRole(this.userID, roleId);
        }

        public bool SetPassword(string UserName, string password)
        {
            byte[] encPassword = AccountsPrincipal.EncryptPassword(password);
            Edge.Security.Data.User user = new Edge.Security.Data.User();
            return user.SetPassword(UserName, encPassword);
        }

        public bool Update()
        {
            Edge.Security.Data.User user = new Edge.Security.Data.User();
            if (string.IsNullOrEmpty(this.email))
            {
                this.email = "";
            }
            return user.Update(this.userID, this.userName, this.password, this.trueName, this.sex, this.phone, this.email, this.employeeID, this.departmentID, this.activity, this.userType, this.style, this.Description);
        }

        /// <summary>
        /// 返回数据总数(分页用到)
        /// </summary>
        public int GetCount(string strWhere)
        {
            Edge.Security.Data.User user = new Edge.Security.Data.User();
            return user.GetCount(strWhere);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            Edge.Security.Data.User user = new Edge.Security.Data.User();
            return user.GetPageList(pageSize, currentPage, strWhere, filedOrder);
        }

        // Properties
        public bool Activity
        {
            get
            {
                return this.activity;
            }
            set
            {
                this.activity = value;
            }
        }

        public string DepartmentID
        {
            get
            {
                return this.departmentID;
            }
            set
            {
                this.departmentID = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return this.employeeID;
            }
            set
            {
                this.employeeID = value;
            }
        }

        public byte[] Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
            }
        }

        public string Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                this.sex = value;
            }
        }

        public int Style
        {
            get
            {
                return this.style;
            }
            set
            {
                this.style = value;
            }
        }

        public string TrueName
        {
            get
            {
                return this.trueName;
            }
            set
            {
                this.trueName = value;
            }
        }
        public string Description { get; set; }
        public int UserID
        {
            get
            {
                return this.userID;
            }
            set
            {
                this.userID = value;
            }
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }

        public string UserType
        {
            get
            {
                return this.userType;
            }
            set
            {
                this.userType = value;
            }
        }
    }
}
