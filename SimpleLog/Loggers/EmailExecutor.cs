using SimpleLog.Models;
using SimpleLog.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLog.Loggers
{
    [LogAttribute(Area.Email)]
    internal class EmailExecutor : IExecutor
    {
        private Dictionary<string, EmailSource> Sources { get; } = new Dictionary<string, EmailSource>();

        public void Write(string message)
        {
            foreach (var source in Sources)
            {
               //TODO: Реализация отправки email с настойками из EmailSource
               Console.WriteLine($"Email in {source.Value.Name}: " + message);
            }
        }

        public void AddSource(Source source)
        {
            if (source is EmailSource)
            {
                Sources.Add(source.Name, source as EmailSource);
            }
        }
    }
}
