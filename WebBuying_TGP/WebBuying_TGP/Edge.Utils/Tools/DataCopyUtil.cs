using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Edge.Utils.Tools
{
    public class DataCopyUtil
    {
        public static void CopyData(object fromObj, object toObj)
        {
            try
            {
                PropertyInfo[] pis = toObj.GetType().GetProperties();
                PropertyInfo pi;
                foreach (var item in pis)
                {
                    if (item.CanWrite)
                    {
                        pi = fromObj.GetType().GetProperty(item.Name);
                        if (pi != null)
                        {
                            item.SetValue(toObj, pi.GetValue(fromObj, null), null);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
        }
    }
}
