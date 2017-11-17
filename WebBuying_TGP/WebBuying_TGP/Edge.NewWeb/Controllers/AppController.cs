using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.Security.Manager;
using System.Data;
using Edge.SVA.Model.Domain;
using Edge.SVA.Model.Domain.SVA;
using Edge.SVA.BLL.Domain.DataResources;
using Edge.Web.Controllers.Accounts;

namespace Edge.Web.Controllers
{
    public class AppController
    {
        public bool CheckLogin(string username,string password)
        {
            bool rtn = false;

            return rtn;
        }
        public User GetLoginUser(string username,string lan)
        {
            AccountController ac = new AccountController();
            User user = ac.GetUserByName(username, lan);
            return user;
        }
    }
}