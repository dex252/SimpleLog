using System;

namespace SimpleLog.Models.Attributes
{
    internal sealed class LogAttribute: Attribute
    {
        public Area Value { get; }
        public LogAttribute(Area area)
        {
            Value = area;
        }

    }
}
