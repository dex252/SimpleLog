using SimpleLog.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLog.Models
{
    [LogAttribute(Area.Email)]
    public class EmailSource: Source
    {
    }
}
