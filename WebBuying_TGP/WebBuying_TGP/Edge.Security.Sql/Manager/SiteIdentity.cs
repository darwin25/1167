using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Security.Principal;
using System.Security.Cryptography;

namespace Edge.Security.Manager
{
    public class SiteIdentity : IIdentity
    {
        // Fields
        private string email;
        private byte[] password;
        private string sex;
        private string trueName;
        private int userID;
        private string userName;

        // Methods
        public SiteIdentity(int currentUserID)
        {
            DataRow row = new Edge.Security.Data.User().Retrieve(currentUserID);
            this.userName = (string)row["UserName"];
            this.trueName = (string)row["TrueName"];
            this.email = (string)row["Email"];
            this.userID = currentUserID;
            this.password = (byte[])row["Password"];
            this.sex = (string)row["Sex"];
        }

        public SiteIdentity(string currentUserName)
        {
            DataRow row = new Edge.Security.Data.User().Retrieve(currentUserName);
            if (row!=null)
            {
                this.userName = currentUserName;
                this.trueName = (string)row["TrueName"];
                this.email = (string)row["Email"];
                this.userID = (int)row["UserID"];
                this.password = (byte[])row["Password"];
                this.sex = (string)row["Sex"];
            }
        }

        public int TestPassword(string password)
        {
            byte[] bytes = new UnicodeEncoding().GetBytes(password);
            byte[] encPassword = new SHA1CryptoServiceProvider().ComputeHash(bytes);
            Edge.Security.Data.User user = new Edge.Security.Data.User();
            return user.TestPassword(this.userID, encPassword);
        }

        // Properties
        public string AuthenticationType
        {
            get
            {
                return "Custom Authentication";
            }
            set
            {
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return true;
            }
        }

        public string Name
        {
            get
            {
                return this.userName;
            }
        }

        public byte[] Password
        {
            get
            {
                return this.password;
            }
        }

        public string Sex
        {
            get
            {
                return this.sex;
            }
        }

        public string TrueName
        {
            get
            {
                return this.trueName;
            }
        }

        public int UserID
        {
            get
            {
                return this.userID;
            }
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }
        }
    }
}
