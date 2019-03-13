using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBLTr21.XmlGenerator
{
    public static class Utils
    {

        public static bool IsNull<T>(this T obj) where T : class
        {
            return obj == null;
        }
        public static bool IsNotNull<T>(this T obj) where T : class
        {
            return obj != null;
        }
        public static T With<T>(this T item, Action<T> action)
        {
            if (item != null)
            {
                action(item);
            }
            return item;
        }
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
            return enumeration;
        }
    }
}
