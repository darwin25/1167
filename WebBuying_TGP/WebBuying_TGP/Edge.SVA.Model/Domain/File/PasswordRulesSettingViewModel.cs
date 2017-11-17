using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.File
{
    public class PasswordRulesSettingViewModel
    {
        PasswordRule mainTable = new PasswordRule();

        public PasswordRule MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }
    }
}
