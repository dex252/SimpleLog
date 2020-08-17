using SimpleLog.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLog.Models
{
    [LogAttribute(Area.Database)]
    public class DatabaseSource : Source
    {
    }
}
