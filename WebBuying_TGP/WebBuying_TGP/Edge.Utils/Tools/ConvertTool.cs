using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.Utils.Tools
{
    public class ConvertTool
    {
        public static ConvertTool GetInstance()
        {
            return new ConvertTool();
        }

        public Nullable<T> ConverNullable<T>(object value) where T : struct
        {
            if (value == null || string.IsNullOrEmpty(value.ToString())) return null;
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return null;
            }
        }

        public T ConverToType<T>(object value) where T : struct
        {
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return default(T);
            }

        }

        public object ChangeType(Type type, string value)
        {
            if (type.FullName == "System.String") return value;

            else if (string.IsNullOrEmpty(value)) return Activator.CreateInstance(type);

            return Convert.ChangeType(value, type);
        }

    }
}
