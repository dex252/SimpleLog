using SimpleLog.Models;
using SimpleLog.Models.Attributes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace SimpleLog.Loggers
{
    [LogAttribute(Area.Text)]
    internal class TextExecutor : IExecutor
    {
        private Dictionary<string, TextSource> Sources { get; } = new Dictionary<string, TextSource>();

        private static ConcurrentDictionary<string, object> AquireLock = new ConcurrentDictionary<string, object>();

        public void Write(string message)
        {
            foreach (var source in Sources)
            {
                lock (AquireLock[source.Value.Name])
                {
                    //TODO: реализация записи в файл, как есть
                    Console.WriteLine($"Text in {source.Value.Name}: " + message);
                }
            }
        }

        public void AddSource(Source source)
        {
            if (source is TextSource)
            {
                Sources.Add(source.Name, source as TextSource);

                if (!AquireLock.ContainsKey(source.Name))
                {
                    AquireLock.TryAdd(source.Name, new object());
                }
            }
        }
    }
}
