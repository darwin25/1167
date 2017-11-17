using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.Utils.Tools
{
    public class CheckDigitUtil
    {
        private readonly static CheckDigitUtil instance = new CheckDigitUtil();
        private CheckDigitUtil() { }
        public static CheckDigitUtil GetSingleton()
        {
            return instance;
        }
        public string AppendCheckDigitEAN13(string no)
        {
            string rtn = no;
            int len = no.Length;
            int total = 0;
            for (int i = 0; i < len; i++)
            {
                if ((i % 2) == 0)
                {
                    total += int.Parse(no.Substring(len - 1 - i, 1)) * 3;
                }
                else
                {
                    total += int.Parse(no.Substring(len - 1 - i, 1));
                }
            }
            int digit = total % 10;
            string checkDigit = string.Empty;
            if (digit == 0)
            {
                checkDigit = "0";
            }
            else
            {
                checkDigit = (10 - digit).ToString();
            }
            rtn += checkDigit;
            return rtn;
        }
        public string AppendCheckDigitMOD10(string no)
        {
            string rtn = no;
            int len = no.Length;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                if ((i % 2) == 1)
                {
                    sb.Append(int.Parse(no.Substring(i, 1))*2);
                }
                else
                {
                    sb.Append(no.Substring(i, 1));
                }
            }
            string no1=sb.ToString();
            int len1 = no1.Length;
            int total = 0;
            for (int i = 0; i < len1 ; i++)
            {
                total +=int.Parse(no1.Substring(i, 1));
            }
            string checkDigit = (total%10).ToString();
            rtn += checkDigit;
            return rtn;
        }
    }
}
