using SimpleLog.Models;
using SimpleLog.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLog.Loggers
{
    [LogAttribute(Area.Http)]
    internal class HttpExecutor : IExecutor
    {
        private Dictionary<string, HttpSource> Sources { get; } = new Dictionary<string, HttpSource>();

        public void Write(string message)
        {
            foreach (var source in Sources)
            {
                //TODO: Реализация отправки сообщения, как http запрос куда-либо
                Console.WriteLine($"Http in {source.Value.Name}: " + message);
            }
        }

        public void AddSource(Source source)
        {
            if (source is HttpSource)
            {
                Sources.Add(source.Name, source as HttpSource);
            }
        }
    }
}
