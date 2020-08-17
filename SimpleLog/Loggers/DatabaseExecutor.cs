using SimpleLog.Models;
using SimpleLog.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLog.Loggers
{
    [LogAttribute(Area.Database)]
    internal class DatabaseExecutor : IExecutor
    {
        private Dictionary<string, DatabaseSource> Sources { get; } = new Dictionary<string, DatabaseSource>();

        public void Write(string message)
        {
            foreach (var source in Sources)
            {
                //TODO: Реализация записи сообщения в бд с указанными настройками из DatabaseSource
                Console.WriteLine($"Database in {source.Value.Name}: " + message);
            }
        }

        public void AddSource(Source source)
        {
            if (source is DatabaseSource)
            {
                Sources.Add(source.Name, source as DatabaseSource);
            }
        }
    }
}
