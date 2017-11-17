using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Edge.Web.Controllers
{
    public class RegexController
    {
        private RegexController()
        {
        }
        public static RegexController GetInstance()
        {
            return new RegexController();
        }

        public bool IsMatch(string input,string pattern)
        {
            if (string.IsNullOrEmpty(input)) return false;
            if (string.IsNullOrEmpty(pattern)) throw new Exception("Pattern Can Not Empty");

            return Regex.IsMatch(input,pattern);
        }

        public string FirstMatch(string input, string pattern)
        {
            if (string.IsNullOrEmpty(input)) throw new Exception("Input Value Can Not Empty");
            if (string.IsNullOrEmpty(pattern)) throw new Exception("Pattern Can Not Empty");

            return Regex.Match(input, pattern).Value;
        }

        
        public bool IsSvaCode(string code)
        {
            string pattern = "^[A-Z0-9]+$";

            return IsMatch(code, pattern);
        }

        public bool IsNumMask(string numMask, string numPattern)
        {
            if (!Regex.IsMatch(numMask, @"^A+9+$")) return false;
            if (!Regex.IsMatch(numPattern, @"^\d+$")) return false;

            string prefix = Regex.Match(numMask, "A+").Value;

            return prefix.Length == numPattern.Length;
        }

        public bool IsMobileNumber(string mobileNumber)
        {
            return Regex.IsMatch(mobileNumber, @"^\+{0,1}\d+$");
        }
    }


}
