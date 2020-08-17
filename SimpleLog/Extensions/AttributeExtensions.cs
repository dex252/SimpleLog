using System;
using System.Linq;

namespace SimpleLog.Extensions
{
    internal static class AttributeExtensions
    {
        public static TAttribute GetAttributeValue<TAttribute>(this Type type)
            where TAttribute : Attribute
        {
            var att = type.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;

            return att;
        }
    }
}
