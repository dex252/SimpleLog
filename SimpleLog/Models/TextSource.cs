using SimpleLog.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLog.Models
{
    [LogAttribute(Area.Text)]
    public class TextSource: Source
    {
    }
}
