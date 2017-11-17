using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edge.Web.Tools
{
    public class CheckTool
    {

        public static bool IsMatchNumMask(string numMask, string numPattern,bool allowEmpty)
        {
            int length = 0;
            foreach (Char ch in numMask.ToCharArray())
            {
                if (ch == 'A')
                {
                    length++;
                }
                else
                {
                    break;
                }
            }

            if (length == 0 && allowEmpty)//可以不输入前缀A
            {
                return true;
            }

            if (length == numPattern.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsMatchNumMask(FineUI.TextBox numMask, FineUI.TextBox numPattern)
        {
            numMask.ClearInvalid();
            numPattern.ClearInvalid();

            //只输入numPattern不输入numMask
            if (string.IsNullOrEmpty(numMask.Text) && !string.IsNullOrEmpty(numPattern.Text))
            {
                numPattern.MarkInvalid(Resources.MessageTips.NumPatternValid);
                return false;
            }

            //输入的是9999
            if (IsRegex("^9+$", numMask.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(numPattern.Text))
                {
                    numPattern.MarkInvalid(Resources.MessageTips.NotRequiredField);
                    return false;
                }

                int len = numMask.Text.Trim().Length;
                if (len > 18)
                {
                    numMask.MarkInvalid(string.Format(Resources.MessageTips.MaxInputLimit, 18));
                    return false;
                }

                return true;
            }

            //输入的是AAAA999
            if (!IsRegex("^A*9+$", numMask.Text.Trim()))
            {
                numMask.MarkInvalid(Resources.MessageTips.NumMaskValid);
                return false;
            }
            else
            {
                //判断输入是否符合规则
                int length = 0;
                foreach (Char ch in numMask.Text.Trim().ToCharArray())
                {
                    if (ch == 'A')
                    {
                        length++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (length != numPattern.Text.Trim().Length)
                {
                    numPattern.MarkInvalid(Resources.MessageTips.NumPatternValid);
                    return false;
                }            
            }

            return true;
        }

        private static bool IsRegex(string regexvalue, string itemvalue)
        {
            try
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(regexvalue);
                if (regex.IsMatch(itemvalue)) return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }  
    }
}